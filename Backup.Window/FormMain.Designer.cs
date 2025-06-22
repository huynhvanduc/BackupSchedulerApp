namespace Backup.Window
{
    partial class FormMain
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
            this.groupBoxProfiles = new System.Windows.Forms.GroupBox();
            this.btnDeleteProfile = new System.Windows.Forms.Button();
            this.btnSaveProfile = new System.Windows.Forms.Button();
            this.btnAddProfile = new System.Windows.Forms.Button();
            this.txtProfileName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lstProfiles = new System.Windows.Forms.ListBox();
            this.groupBoxBackupConfig = new System.Windows.Forms.GroupBox();
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
            this.btnBrowseDestination = new System.Windows.Forms.Button();
            this.txtDestinationPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowseSource = new System.Windows.Forms.Button();
            this.txtSourcePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnRunNow = new System.Windows.Forms.Button();
            this.btnApplyToTaskScheduler = new System.Windows.Forms.Button();
            this.groupBoxProfiles.SuspendLayout();
            this.groupBoxBackupConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHourlyInterval)).BeginInit();
            this.SuspendLayout();
            //
            // groupBoxProfiles
            //
            this.groupBoxProfiles.Controls.Add(this.btnDeleteProfile);
            this.groupBoxProfiles.Controls.Add(this.btnSaveProfile);
            this.groupBoxProfiles.Controls.Add(this.btnAddProfile);
            this.groupBoxProfiles.Controls.Add(this.txtProfileName);
            this.groupBoxProfiles.Controls.Add(this.label6);
            this.groupBoxProfiles.Controls.Add(this.lstProfiles);
            this.groupBoxProfiles.Location = new System.Drawing.Point(12, 12);
            this.groupBoxProfiles.Name = "groupBoxProfiles";
            this.groupBoxProfiles.Size = new System.Drawing.Size(250, 400);
            this.groupBoxProfiles.TabIndex = 0;
            this.groupBoxProfiles.TabStop = false;
            this.groupBoxProfiles.Text = "Quản lý cấu hình sao lưu";
            //
            // btnDeleteProfile
            //
            this.btnDeleteProfile.Enabled = false;
            this.btnDeleteProfile.Location = new System.Drawing.Point(167, 360);
            this.btnDeleteProfile.Name = "btnDeleteProfile";
            this.btnDeleteProfile.Size = new System.Drawing.Size(75, 25);
            this.btnDeleteProfile.TabIndex = 5;
            this.btnDeleteProfile.Text = "Xóa";
            this.btnDeleteProfile.UseVisualStyleBackColor = true;
            this.btnDeleteProfile.Click += new System.EventHandler(this.btnDeleteProfile_Click);
            //
            // btnSaveProfile
            //
            this.btnSaveProfile.Location = new System.Drawing.Point(86, 360);
            this.btnSaveProfile.Name = "btnSaveProfile";
            this.btnSaveProfile.Size = new System.Drawing.Size(75, 25);
            this.btnSaveProfile.TabIndex = 4;
            this.btnSaveProfile.Text = "Lưu";
            this.btnSaveProfile.UseVisualStyleBackColor = true;
            this.btnSaveProfile.Click += new System.EventHandler(this.btnSaveProfile_Click);
            //
            // btnAddProfile
            //
            this.btnAddProfile.Location = new System.Drawing.Point(6, 360);
            this.btnAddProfile.Name = "btnAddProfile";
            this.btnAddProfile.Size = new System.Drawing.Size(75, 25);
            this.btnAddProfile.TabIndex = 3;
            this.btnAddProfile.Text = "Thêm mới";
            this.btnAddProfile.UseVisualStyleBackColor = true;
            this.btnAddProfile.Click += new System.EventHandler(this.btnAddProfile_Click);
            //
            // txtProfileName
            //
            this.txtProfileName.Location = new System.Drawing.Point(86, 27);
            this.txtProfileName.Name = "txtProfileName";
            this.txtProfileName.Size = new System.Drawing.Size(156, 23);
            this.txtProfileName.TabIndex = 2;
            //
            // label6
            //
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Tên cấu hình:";
            //
            // lstProfiles
            //
            this.lstProfiles.FormattingEnabled = true;
            this.lstProfiles.ItemHeight = 15;
            this.lstProfiles.Location = new System.Drawing.Point(6, 56);
            this.lstProfiles.Name = "lstProfiles";
            this.lstProfiles.Size = new System.Drawing.Size(236, 289);
            this.lstProfiles.TabIndex = 0;
            //
            // groupBoxBackupConfig
            //
            this.groupBoxBackupConfig.Controls.Add(this.dtpWeeklyTime);
            this.groupBoxBackupConfig.Controls.Add(this.cbDayOfWeek);
            this.groupBoxBackupConfig.Controls.Add(this.label5);
            this.groupBoxBackupConfig.Controls.Add(this.dtpDailyTime);
            this.groupBoxBackupConfig.Controls.Add(this.label4);
            this.groupBoxBackupConfig.Controls.Add(this.nudHourlyInterval);
            this.groupBoxBackupConfig.Controls.Add(this.label3);
            this.groupBoxBackupConfig.Controls.Add(this.rbWeekly);
            this.groupBoxBackupConfig.Controls.Add(this.rbDaily);
            this.groupBoxBackupConfig.Controls.Add(this.rbHourly);
            this.groupBoxBackupConfig.Controls.Add(this.btnBrowseDestination);
            this.groupBoxBackupConfig.Controls.Add(this.txtDestinationPath);
            this.groupBoxBackupConfig.Controls.Add(this.label2);
            this.groupBoxBackupConfig.Controls.Add(this.btnBrowseSource);
            this.groupBoxBackupConfig.Controls.Add(this.txtSourcePath);
            this.groupBoxBackupConfig.Controls.Add(this.label1);
            this.groupBoxBackupConfig.Location = new System.Drawing.Point(268, 12);
            this.groupBoxBackupConfig.Name = "groupBoxBackupConfig";
            this.groupBoxBackupConfig.Size = new System.Drawing.Size(490, 360);
            this.groupBoxBackupConfig.TabIndex = 1;
            this.groupBoxBackupConfig.TabStop = false;
            this.groupBoxBackupConfig.Text = "Cấu hình chi tiết sao lưu";
            //
            // dtpWeeklyTime
            //
            this.dtpWeeklyTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpWeeklyTime.Location = new System.Drawing.Point(269, 280);
            this.dtpWeeklyTime.Name = "dtpWeeklyTime";
            this.dtpWeeklyTime.ShowUpDown = true;
            this.dtpWeeklyTime.Size = new System.Drawing.Size(95, 23);
            this.dtpWeeklyTime.TabIndex = 9;
            //
            // cbDayOfWeek
            //
            this.cbDayOfWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDayOfWeek.FormattingEnabled = true;
            this.cbDayOfWeek.Location = new System.Drawing.Point(180, 280);
            this.cbDayOfWeek.Name = "cbDayOfWeek";
            this.cbDayOfWeek.Size = new System.Drawing.Size(83, 23);
            this.cbDayOfWeek.TabIndex = 8;
            //
            // label5
            //
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(145, 284);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "vào:";
            //
            // dtpDailyTime
            //
            this.dtpDailyTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpDailyTime.Location = new System.Drawing.Point(180, 233);
            this.dtpDailyTime.Name = "dtpDailyTime";
            this.dtpDailyTime.ShowUpDown = true;
            this.dtpDailyTime.Size = new System.Drawing.Size(95, 23);
            this.dtpDailyTime.TabIndex = 6;
            //
            // label4
            //
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(145, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "vào:";
            //
            // nudHourlyInterval
            //
            this.nudHourlyInterval.Location = new System.Drawing.Point(180, 186);
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
            this.label3.Location = new System.Drawing.Point(236, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "giờ/lần";
            //
            // rbWeekly
            //
            this.rbWeekly.AutoSize = true;
            this.rbWeekly.Location = new System.Drawing.Point(19, 282);
            this.rbWeekly.Name = "rbWeekly";
            this.rbWeekly.Size = new System.Drawing.Size(120, 19);
            this.rbWeekly.TabIndex = 2;
            this.rbWeekly.Text = "Hàng tuần vào thứ:";
            this.rbWeekly.UseVisualStyleBackColor = true;
            //
            // rbDaily
            //
            this.rbDaily.AutoSize = true;
            this.rbDaily.Checked = true;
            this.rbDaily.Location = new System.Drawing.Point(19, 235);
            this.rbDaily.Name = "rbDaily";
            this.rbDaily.Size = new System.Drawing.Size(99, 19);
            this.rbDaily.TabIndex = 1;
            this.rbDaily.TabStop = true;
            this.rbDaily.Text = "Hàng ngày vào:";
            this.rbDaily.UseVisualStyleBackColor = true;
            //
            // rbHourly
            //
            this.rbHourly.AutoSize = true;
            this.rbHourly.Location = new System.Drawing.Point(19, 188);
            this.rbHourly.Name = "rbHourly";
            this.rbHourly.Size = new System.Drawing.Size(117, 19);
            this.rbHourly.TabIndex = 0;
            this.rbHourly.Text = "Mỗi khoảng thời gian:";
            this.rbHourly.UseVisualStyleBackColor = true;
            //
            // btnBrowseDestination
            //
            this.btnBrowseDestination.Location = new System.Drawing.Point(409, 93);
            this.btnBrowseDestination.Name = "btnBrowseDestination";
            this.btnBrowseDestination.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseDestination.TabIndex = 5;
            this.btnBrowseDestination.Text = "Duyệt...";
            this.btnBrowseDestination.UseVisualStyleBackColor = true;
            this.btnBrowseDestination.Click += new System.EventHandler(this.btnBrowseDestination_Click);
            //
            // txtDestinationPath
            //
            this.txtDestinationPath.Location = new System.Drawing.Point(15, 93);
            this.txtDestinationPath.Name = "txtDestinationPath";
            this.txtDestinationPath.Size = new System.Drawing.Size(388, 23);
            this.txtDestinationPath.TabIndex = 4;
            //
            // label2
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Đường dẫn đích (B):";
            //
            // btnBrowseSource
            //
            this.btnBrowseSource.Location = new System.Drawing.Point(409, 38);
            this.btnBrowseSource.Name = "btnBrowseSource";
            this.btnBrowseSource.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseSource.TabIndex = 2;
            this.btnBrowseSource.Text = "Duyệt...";
            this.btnBrowseSource.UseVisualStyleBackColor = true;
            this.btnBrowseSource.Click += new System.EventHandler(this.btnBrowseSource_Click);
            //
            // txtSourcePath
            //
            this.txtSourcePath.Location = new System.Drawing.Point(15, 38);
            this.txtSourcePath.Name = "txtSourcePath";
            this.txtSourcePath.Size = new System.Drawing.Size(388, 23);
            this.txtSourcePath.TabIndex = 1;
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đường dẫn nguồn (A):";
            //
            // lblStatus
            //
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.Location = new System.Drawing.Point(268, 385);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(65, 15);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Trạng thái:";
            //
            // btnRunNow
            //
            this.btnRunNow.Location = new System.Drawing.Point(268, 403);
            this.btnRunNow.Name = "btnRunNow";
            this.btnRunNow.Size = new System.Drawing.Size(100, 30);
            this.btnRunNow.TabIndex = 3;
            this.btnRunNow.Text = "Chạy ngay";
            this.btnRunNow.UseVisualStyleBackColor = true;
            this.btnRunNow.Click += new System.EventHandler(this.btnRunNow_Click);
            //
            // btnApplyToTaskScheduler
            //
            this.btnApplyToTaskScheduler.Enabled = false;
            this.btnApplyToTaskScheduler.Location = new System.Drawing.Point(548, 403);
            this.btnApplyToTaskScheduler.Name = "btnApplyToTaskScheduler";
            this.btnApplyToTaskScheduler.Size = new System.Drawing.Size(210, 30);
            this.btnApplyToTaskScheduler.TabIndex = 4;
            this.btnApplyToTaskScheduler.Text = "Áp dụng vào Task Scheduler";
            this.btnApplyToTaskScheduler.UseVisualStyleBackColor = true;
            this.btnApplyToTaskScheduler.Click += new System.EventHandler(this.btnApplyToTaskScheduler_Click);
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 440);
            this.Controls.Add(this.btnApplyToTaskScheduler);
            this.Controls.Add(this.btnRunNow);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.groupBoxBackupConfig);
            this.Controls.Add(this.groupBoxProfiles);
            this.MinimumSize = new System.Drawing.Size(786, 479);
            this.Name = "Form1";
            this.Text = "Quản lý sao lưu theo lịch";
            this.groupBoxProfiles.ResumeLayout(false);
            this.groupBoxProfiles.PerformLayout();
            this.groupBoxBackupConfig.ResumeLayout(false);
            this.groupBoxBackupConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHourlyInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxProfiles;
        private System.Windows.Forms.Button btnDeleteProfile;
        private System.Windows.Forms.Button btnSaveProfile;
        private System.Windows.Forms.Button btnAddProfile;
        private System.Windows.Forms.TextBox txtProfileName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lstProfiles;
        private System.Windows.Forms.GroupBox groupBoxBackupConfig;
        private System.Windows.Forms.DateTimePicker dtpWeeklyTime;
        private System.Windows.Forms.ComboBox cbDayOfWeek;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpDailyTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudHourlyInterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbWeekly;
        private System.Windows.Forms.RadioButton rbDaily;
        private System.Windows.Forms.RadioButton rbHourly;
        private System.Windows.Forms.Button btnBrowseDestination;
        private System.Windows.Forms.TextBox txtDestinationPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowseSource;
        private System.Windows.Forms.TextBox txtSourcePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnRunNow;
        private System.Windows.Forms.Button btnApplyToTaskScheduler;
    }
}