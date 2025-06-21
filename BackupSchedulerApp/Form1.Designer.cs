namespace BackupSchedulerApp
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSourcePath = new System.Windows.Forms.TextBox();
            this.btnBrowseSource = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDestinationPath = new System.Windows.Forms.TextBox();
            this.btnBrowseDestination = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpWeeklyTime = new System.Windows.Forms.DateTimePicker();
            this.cbDayOfWeek = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpDailyTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.nudHourlyInterval = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.rbWeekly = new System.Windows.Forms.RadioButton();
            this.rbDaily = new System.Windows.Forms.RadioButton();
            this.rbHourly = new System.Windows.Forms.RadioButton();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.btnRunNow = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHourlyInterval)).BeginInit();
            this.SuspendLayout();
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đường dẫn nguồn (A):";
            //
            // txtSourcePath
            //
            this.txtSourcePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSourcePath.Location = new System.Drawing.Point(12, 38);
            this.txtSourcePath.Name = "txtSourcePath";
            this.txtSourcePath.Size = new System.Drawing.Size(395, 23);
            this.txtSourcePath.TabIndex = 1;
            //
            // btnBrowseSource
            //
            this.btnBrowseSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseSource.Location = new System.Drawing.Point(413, 38);
            this.btnBrowseSource.Name = "btnBrowseSource";
            this.btnBrowseSource.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseSource.TabIndex = 2;
            this.btnBrowseSource.Text = "Duyệt...";
            this.btnBrowseSource.UseVisualStyleBackColor = true;
            this.btnBrowseSource.Click += new System.EventHandler(this.btnBrowseSource_Click);
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Đường dẫn đích (B):";
            //
            // txtDestinationPath
            //
            this.txtDestinationPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestinationPath.Location = new System.Drawing.Point(12, 88);
            this.txtDestinationPath.Name = "txtDestinationPath";
            this.txtDestinationPath.Size = new System.Drawing.Size(395, 23);
            this.txtDestinationPath.TabIndex = 4;
            //
            // btnBrowseDestination
            //
            this.btnBrowseDestination.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseDestination.Location = new System.Drawing.Point(413, 88);
            this.btnBrowseDestination.Name = "btnBrowseDestination";
            this.btnBrowseDestination.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseDestination.TabIndex = 5;
            this.btnBrowseDestination.Text = "Duyệt...";
            this.btnBrowseDestination.UseVisualStyleBackColor = true;
            this.btnBrowseDestination.Click += new System.EventHandler(this.btnBrowseDestination_Click);
            //
            // groupBox1
            //
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dtpWeeklyTime);
            this.groupBox1.Controls.Add(this.cbDayOfWeek);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtpDailyTime);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nudHourlyInterval);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rbWeekly);
            this.groupBox1.Controls.Add(this.rbDaily);
            this.groupBox1.Controls.Add(this.rbHourly);
            this.groupBox1.Location = new System.Drawing.Point(12, 130);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(476, 170);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cấu hình lịch sao lưu";
            //
            // dtpWeeklyTime
            //
            this.dtpWeeklyTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpWeeklyTime.Location = new System.Drawing.Point(269, 127);
            this.dtpWeeklyTime.Name = "dtpWeeklyTime";
            this.dtpWeeklyTime.ShowUpDown = true;
            this.dtpWeeklyTime.Size = new System.Drawing.Size(95, 23);
            this.dtpWeeklyTime.TabIndex = 9;
            //
            // cbDayOfWeek
            //
            this.cbDayOfWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDayOfWeek.FormattingEnabled = true;
            this.cbDayOfWeek.Location = new System.Drawing.Point(180, 127);
            this.cbDayOfWeek.Name = "cbDayOfWeek";
            this.cbDayOfWeek.Size = new System.Drawing.Size(83, 23);
            this.cbDayOfWeek.TabIndex = 8;
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(145, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "vào:";
            //
            // dtpDailyTime
            //
            this.dtpDailyTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpDailyTime.Location = new System.Drawing.Point(180, 80);
            this.dtpDailyTime.Name = "dtpDailyTime";
            this.dtpDailyTime.ShowUpDown = true;
            this.dtpDailyTime.Size = new System.Drawing.Size(95, 23);
            this.dtpDailyTime.TabIndex = 6;
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(145, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "vào:";
            //
            // nudHourlyInterval
            //
            this.nudHourlyInterval.Location = new System.Drawing.Point(180, 33);
            this.nudHourlyInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHourlyInterval.Name = "nudHourlyInterval";
            this.nudHourlyInterval.Size = new System.Drawing.Size(50, 23);
            this.nudHourlyInterval.TabIndex = 4;
            this.nudHourlyInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            //
            // label3
            //
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(236, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "giờ/lần";
            //
            // rbWeekly
            //
            this.rbWeekly.AutoSize = true;
            this.rbWeekly.Location = new System.Drawing.Point(19, 129);
            this.rbWeekly.Name = "rbWeekly";
            this.rbWeekly.Size = new System.Drawing.Size(120, 19);
            this.rbWeekly.TabIndex = 2;
            this.rbWeekly.Text = "Hàng tuần vào thứ:";
            this.rbWeekly.UseVisualStyleBackColor = true;
            //
            // rbDaily
            //
            this.rbDaily.AutoSize = true;
            this.rbDaily.Location = new System.Drawing.Point(19, 82);
            this.rbDaily.Name = "rbDaily";
            this.rbDaily.Size = new System.Drawing.Size(99, 19);
            this.rbDaily.TabIndex = 1;
            this.rbDaily.Text = "Hàng ngày vào:";
            this.rbDaily.UseVisualStyleBackColor = true;
            //
            // rbHourly
            //
            this.rbHourly.AutoSize = true;
            this.rbHourly.Checked = true;
            this.rbHourly.Location = new System.Drawing.Point(19, 35);
            this.rbHourly.Name = "rbHourly";
            this.rbHourly.Size = new System.Drawing.Size(117, 19);
            this.rbHourly.TabIndex = 0;
            this.rbHourly.TabStop = true;
            this.rbHourly.Text = "Mỗi khoảng thời gian:";
            this.rbHourly.UseVisualStyleBackColor = true;
            //
            // btnSaveConfig
            //
            this.btnSaveConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveConfig.Location = new System.Drawing.Point(388, 306);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(100, 30);
            this.btnSaveConfig.TabIndex = 7;
            this.btnSaveConfig.Text = "Lưu cấu hình";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            //
            // btnRunNow
            //
            this.btnRunNow.Location = new System.Drawing.Point(12, 306);
            this.btnRunNow.Name = "btnRunNow";
            this.btnRunNow.Size = new System.Drawing.Size(100, 30);
            this.btnRunNow.TabIndex = 8;
            this.btnRunNow.Text = "Chạy ngay";
            this.btnRunNow.UseVisualStyleBackColor = true;
            this.btnRunNow.Click += new System.EventHandler(this.btnRunNow_Click);
            //
            // lblStatus
            //
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.Location = new System.Drawing.Point(12, 350);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(65, 15);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Trạng thái:";
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 380);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnRunNow);
            this.Controls.Add(this.btnSaveConfig);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBrowseDestination);
            this.Controls.Add(this.txtDestinationPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowseSource);
            this.Controls.Add(this.txtSourcePath);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(500, 380);
            this.Name = "Form1";
            this.Text = "Ứng dụng sao lưu theo lịch";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHourlyInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSourcePath;
        private System.Windows.Forms.Button btnBrowseSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDestinationPath;
        private System.Windows.Forms.Button btnBrowseDestination;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbWeekly;
        private System.Windows.Forms.RadioButton rbDaily;
        private System.Windows.Forms.RadioButton rbHourly;
        private System.Windows.Forms.DateTimePicker dtpWeeklyTime;
        private System.Windows.Forms.ComboBox cbDayOfWeek;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDailyTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudHourlyInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.Button btnRunNow;
        private System.Windows.Forms.Label lblStatus;
    }
}
