using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmqmrcheck
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (!(new WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator))
            {
                MessageBox.Show("Please run the app as Administrator!", "Privilege Error");
                this.Close();
                return;
            }
            this.Text = $"QRM And WinRE Check - {DateTime.Now:dd/MM/yyyy}";

            // Kiểm tra phiên bản Build
            int build = GetWinRegistryInt("CurrentBuildNumber");
            if (build >= 22631 && build < 26100)
            {
                MessageBox.Show("QRM is not supported on Windows 11 23H2 or earlier.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            lblWindowsVersion.Text = $"{GetWinRegistryString("DisplayVersion")}";
            // THÊM DÒNG NÀY: Tự động bấm nút Check khi vừa mở App
            btnwinrecheck_Click(null, null);
            btnqmrcheck_Click(null, null);
        }

        // Retrieves the Windows "DisplayVersion" from the registry
        #region Registry Helpers
        private string GetWinRegistryString(string valueName)
        {
            var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            return key?.GetValue(valueName)?.ToString() ?? "Unknown";
        }

        private int GetWinRegistryInt(string valueName)
        {
            return int.TryParse(GetWinRegistryString(valueName), out int val) ? val : 0;
        }
        #endregion
        private string GetWindowsDisplayVersion()
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion"))
            {
                if (key != null)
                {
                    object displayVersion = key.GetValue("DisplayVersion");
                    if (displayVersion != null)
                    {
                        return displayVersion.ToString();
                    }
                }
            }
            return "Unknown";
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
        }

        private void btnwinrecheck_Click(object sender, EventArgs e)
        {
            // Chạy lệnh và lấy output
            string output = ExecuteCommand("cmd.exe", "/c reagentc /info", true);

            var reader = new StringReader(output);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains("Windows RE status:"))
                {
                    // Thu hẹp khoảng trống bằng Regex
                    string cleanLine = Regex.Replace(line, @"\s+", " ").Trim();
                    lblwinreinfo.Text = cleanLine;
                    lblwinreinfo.ForeColor = cleanLine.Contains("Enabled") ? Color.Green : Color.Red;
                    return;
                }
            }
            lblwinreinfo.Text = "Not Found";
        }

        private void btnqmrcheck_Click(object sender, EventArgs e)
        {
            string tempFile = Path.Combine(Path.GetTempPath(), "qmr_res.txt");
            try
            {
                // Sử dụng ShellExecute để ép quyền Admin
                ExecuteCommand("cmd.exe", $"/c reagentc /getrecoverysettings > \"{tempFile}\"", false, true);

                if (File.Exists(tempFile))
                {
                    string output = File.ReadAllText(tempFile);
                    File.Delete(tempFile);

                    if (output.Contains("CloudRemediation"))
                    {
                        bool isEnabled = Regex.Replace(output, "['\" ]", "").Contains("state=1");
                        lblqmrinfo.Text = isEnabled ? "QRM: Enabled" : "QRM: Disabled";
                        lblqmrinfo.ForeColor = isEnabled ? Color.Green : Color.Red;
                    }
                    else lblqmrinfo.Text = "Format Error.";
                }
                UpdateFinalRequirement();
            }
            catch (Exception ex) { lblqmrinfo.Text = $"Error: {ex.Message}"; }
        }

        /// <summary>
        /// Hàm dùng chung để thực thi lệnh hệ thống
        /// </summary>
        private string ExecuteCommand(string fileName, string args, bool redirectOutput, bool runAsAdmin = false)
        {
            var proc = new Process();
            proc.StartInfo = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = args,
                UseShellExecute = runAsAdmin, // Phải là true nếu dùng Verb "runas"
                Verb = runAsAdmin ? "runas" : "",
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardOutput = redirectOutput,
                StandardOutputEncoding = redirectOutput ? System.Text.Encoding.UTF8 : null
            };

            proc.Start();
            string result = redirectOutput ? proc.StandardOutput.ReadToEnd() : "";
            proc.WaitForExit();
            return result;
        }
        private void UpdateFinalRequirement()
        {
            // 1. Kiểm tra xem người dùng đã bấm Check cả hai chưa
            // Nếu Label vẫn là tên mặc định hoặc trống thì thông báo nhắc nhở
            if (lblwinreinfo.Text == "label1" || string.IsNullOrEmpty(lblwinreinfo.Text) ||
                lblqmrinfo.Text == "label1" || string.IsNullOrEmpty(lblqmrinfo.Text))
            {
                lblinfo.Text = "RESULT: Please check both WinRE and QMR";
                lblinfo.ForeColor = Color.Gray;
                return;
            }

            // 2. Xác định trạng thái Bật/Tắt từ nội dung Label
            // Kiểm tra "Enabled" cho WinRE và "Bật" cho QMR
            bool isWinreEnabled = lblwinreinfo.Text.Contains("Enabled");
            bool isQmrEnabled = lblqmrinfo.Text.Contains("Enabled");

            // 3. Phân loại kịch bản để hiển thị kết quả
            if (isWinreEnabled && isQmrEnabled)
            {
                // Kịch bản: Cả hai cùng Bật
                lblinfo.Text = "RESULT: PASSED (System fully protected)";
                lblinfo.ForeColor = Color.Green;
                btnfix.Visible= false;
            }
            else if (!isWinreEnabled && !isQmrEnabled)
            {
                // Kịch bản: Cả hai cùng Tắt
                lblinfo.Text = "RESULT: FAILED (Both WinRE and QMR are OFF)";
                lblinfo.ForeColor = Color.Red;
                btnfix.Enabled = true;
            }
            else if (isQmrEnabled && !isWinreEnabled)
            {
                // Kịch bản: QMR Bật nhưng WinRE Tắt
                lblinfo.Text = "RESULT: INCOMPLETE (Local WinRE missing)";
                lblinfo.ForeColor = Color.Blue;
                btnfix.Enabled = true;
            }
            else
            {
                // Kịch bản: WinRE Bật nhưng QMR Tắt
                lblinfo.Text = "RESULT: INCOMPLETE (Cloud WinRE missing)";
                lblinfo.ForeColor = Color.Blue;
                btnfix.Enabled = true;

            }
        }

        private void btnfix_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                // Xác định trạng thái thực tế từ các nhãn
                bool isWinreEnabled = lblwinreinfo.Text.Contains("Enabled");
                bool isQmrEnabled = lblqmrinfo.Text.Contains("Bật");

                // --- KỊCH BẢN 1: CẢ HAI CÙNG ĐẠT ---
                if (isWinreEnabled && isQmrEnabled)
                {
                    MessageBox.Show("System meets requirements, no fix needed.", "Thông báo");
                    btnfix.Visible = false;
                    return;
                }

                // --- KỊCH BẢN 2: CHƯA ĐẠT WINRE (Bất kể QMR thế nào cũng phải Fix RE trước) ---
                if (!isWinreEnabled)
                {
                    lblinfo.Text = "Processing: Enabling WinRE...";
                    lblinfo.ForeColor = Color.Blue;

                    // Chạy lệnh bật WinRE
                    ExecuteCommand("cmd.exe", "/c reagentc /enable", false, true);

                    // Cập nhật lại nhãn WinRE ngay lập tức
                    btnwinrecheck_Click(null, null);
                }

                // --- KỊCH BẢN 3 & 4: XỬ LÝ QMR (Nếu QMR chưa đạt thì mới mở Settings) ---
                if (!isQmrEnabled)
                {
                    lblinfo.Text = "PLEASE ENABLE 'CLOUD REMEDIATION' IN SETTINGS...";
                    lblinfo.ForeColor = Color.Blue;

                    // Mở trang Settings Recovery
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "ms-settings:recovery",
                        UseShellExecute = true
                    });

                    // Kích hoạt Timer để theo dõi khi người dùng bật xong
                    timerMonitorQMR.Start();

                    string helpMsg = !isWinreEnabled
                        ? "WinRE enabled. Now toggle 'On' for Cloud Remediation in Settings."
                        : "WinRE is OK. Please enable 'Cloud Remediation' in Settings to complete.";

                    MessageBox.Show(helpMsg, "Fix Instructions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Nếu RE vừa fix xong mà QMR vốn đã OK rồi thì chốt kết quả luôn
                    UpdateFinalRequirement();
                    MessageBox.Show("WinRE activated successfully!", "Completed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void timerMonitorQMR_Tick(object sender, EventArgs e)
        {
            // Chỉ thực hiện check nếu Form đã load xong và nhãn chưa ở trạng thái Đạt
            // Gọi hàm check QMR để cập nhật lblqmrinfo
            btnqmrcheck_Click(null, null);

            // Kiểm tra nếu QMR đã được bật
            if (lblqmrinfo.Text.Contains("Enabled") || lblqmrinfo.Text.Contains("Enabled"))
            {
                timerMonitorQMR.Stop(); // Dừng quét ngay khi đạt yêu cầu

                UpdateFinalRequirement(); // Cập nhật nhãn tổng kết (Summary Info)

                // Hiện thông báo thành công
                lblinfo.Text = "RESULT: PASSED (Synced)";
                lblinfo.ForeColor = Color.Green;

                // Ẩn nút Fix đi vì đã xong
                btnfix.Visible = false;

                MessageBox.Show("Great! Recovery system is fully activated.", "Success");
            }
        }
    }
}
