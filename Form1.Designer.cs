namespace frmqmrcheck
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnfix = new System.Windows.Forms.Button();
            this.lblinfo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblwinreinfo = new System.Windows.Forms.Label();
            this.btnwinrecheck = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblqmrinfo = new System.Windows.Forms.Label();
            this.btnqmrcheck = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblWindowsVersion = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerMonitorQMR = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnfix);
            this.groupBox1.Controls.Add(this.lblinfo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(2, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(493, 72);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SUMARY INFO:";
            // 
            // btnfix
            // 
            this.btnfix.Enabled = false;
            this.btnfix.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnfix.Location = new System.Drawing.Point(202, 43);
            this.btnfix.Name = "btnfix";
            this.btnfix.Size = new System.Drawing.Size(85, 23);
            this.btnfix.TabIndex = 4;
            this.btnfix.Text = "FIX ALL";
            this.btnfix.UseVisualStyleBackColor = true;
            this.btnfix.Click += new System.EventHandler(this.btnfix_Click);
            // 
            // lblinfo
            // 
            this.lblinfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblinfo.AutoSize = true;
            this.lblinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblinfo.Location = new System.Drawing.Point(19, 22);
            this.lblinfo.Name = "lblinfo";
            this.lblinfo.Size = new System.Drawing.Size(52, 17);
            this.lblinfo.TabIndex = 3;
            this.lblinfo.Text = "label1";
            this.lblinfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblwinreinfo);
            this.groupBox2.Controls.Add(this.btnwinrecheck);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(2, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(491, 66);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "WINRE CHECK";
            // 
            // lblwinreinfo
            // 
            this.lblwinreinfo.AutoSize = true;
            this.lblwinreinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblwinreinfo.Location = new System.Drawing.Point(113, 32);
            this.lblwinreinfo.Name = "lblwinreinfo";
            this.lblwinreinfo.Size = new System.Drawing.Size(52, 17);
            this.lblwinreinfo.TabIndex = 1;
            this.lblwinreinfo.Text = "label1";
            // 
            // btnwinrecheck
            // 
            this.btnwinrecheck.Enabled = false;
            this.btnwinrecheck.Location = new System.Drawing.Point(10, 25);
            this.btnwinrecheck.Name = "btnwinrecheck";
            this.btnwinrecheck.Size = new System.Drawing.Size(97, 34);
            this.btnwinrecheck.TabIndex = 0;
            this.btnwinrecheck.Text = "EXCUTE";
            this.btnwinrecheck.UseVisualStyleBackColor = true;
            this.btnwinrecheck.Click += new System.EventHandler(this.btnwinrecheck_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblqmrinfo);
            this.groupBox3.Controls.Add(this.btnqmrcheck);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(2, 145);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(491, 83);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "QMR CHECK";
            // 
            // lblqmrinfo
            // 
            this.lblqmrinfo.AutoSize = true;
            this.lblqmrinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblqmrinfo.Location = new System.Drawing.Point(108, 41);
            this.lblqmrinfo.Name = "lblqmrinfo";
            this.lblqmrinfo.Size = new System.Drawing.Size(52, 17);
            this.lblqmrinfo.TabIndex = 2;
            this.lblqmrinfo.Text = "label2";
            // 
            // btnqmrcheck
            // 
            this.btnqmrcheck.Enabled = false;
            this.btnqmrcheck.Location = new System.Drawing.Point(10, 34);
            this.btnqmrcheck.Name = "btnqmrcheck";
            this.btnqmrcheck.Size = new System.Drawing.Size(97, 34);
            this.btnqmrcheck.TabIndex = 1;
            this.btnqmrcheck.Text = "EXCUTE";
            this.btnqmrcheck.UseVisualStyleBackColor = true;
            this.btnqmrcheck.Click += new System.EventHandler(this.btnqmrcheck_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblWindowsVersion);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(2, 234);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(491, 49);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Your OS:";
            // 
            // lblWindowsVersion
            // 
            this.lblWindowsVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWindowsVersion.AutoSize = true;
            this.lblWindowsVersion.Location = new System.Drawing.Point(198, 22);
            this.lblWindowsVersion.Name = "lblWindowsVersion";
            this.lblWindowsVersion.Size = new System.Drawing.Size(57, 20);
            this.lblWindowsVersion.TabIndex = 0;
            this.lblWindowsVersion.Text = "label1";
            this.lblWindowsVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(0, 72);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(372, 66);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "groupBox5";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // timerMonitorQMR
            // 
            this.timerMonitorQMR.Interval = 2000;
            this.timerMonitorQMR.Tick += new System.EventHandler(this.timerMonitorQMR_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 286);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(511, 325);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(511, 325);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblWindowsVersion;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblwinreinfo;
        private System.Windows.Forms.Button btnwinrecheck;
        private System.Windows.Forms.Label lblqmrinfo;
        private System.Windows.Forms.Button btnqmrcheck;
        private System.Windows.Forms.Label lblinfo;
        private System.Windows.Forms.Button btnfix;
        public System.Windows.Forms.Timer timerMonitorQMR;
    }
}

