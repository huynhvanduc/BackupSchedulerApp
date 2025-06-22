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
            groupBoxProfiles = new GroupBox();
            btnDeleteProfile = new Button();
            btnSaveProfile = new Button();
            btnAddProfile = new Button();
            txtProfileName = new TextBox();
            label6 = new Label();
            lstProfiles = new ListBox();
            groupBoxBackupConfig = new GroupBox();
            dtpWeeklyTime = new DateTimePicker();
            cbDayOfWeek = new ComboBox();
            label5 = new Label();
            dtpDailyTime = new DateTimePicker();
            label4 = new Label();
            nudHourlyInterval = new NumericUpDown();
            label3 = new Label();
            rbWeekly = new RadioButton();
            rbDaily = new RadioButton();
            rbHourly = new RadioButton();
            btnBrowseDestination = new Button();
            txtDestinationPath = new TextBox();
            label2 = new Label();
            btnBrowseSource = new Button();
            txtSourcePath = new TextBox();
            label1 = new Label();
            lblStatus = new Label();
            btnRunNow = new Button();
            btnApplyToTaskScheduler = new Button();
            groupBoxProfiles.SuspendLayout();
            groupBoxBackupConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudHourlyInterval).BeginInit();
            SuspendLayout();
            // 
            // groupBoxProfiles
            // 
            groupBoxProfiles.Controls.Add(btnDeleteProfile);
            groupBoxProfiles.Controls.Add(btnSaveProfile);
            groupBoxProfiles.Controls.Add(btnAddProfile);
            groupBoxProfiles.Controls.Add(txtProfileName);
            groupBoxProfiles.Controls.Add(label6);
            groupBoxProfiles.Controls.Add(lstProfiles);
            groupBoxProfiles.Location = new Point(14, 16);
            groupBoxProfiles.Margin = new Padding(3, 4, 3, 4);
            groupBoxProfiles.Name = "groupBoxProfiles";
            groupBoxProfiles.Padding = new Padding(3, 4, 3, 4);
            groupBoxProfiles.Size = new Size(286, 533);
            groupBoxProfiles.TabIndex = 0;
            groupBoxProfiles.TabStop = false;
            groupBoxProfiles.Text = "Quản lý cấu hình sao lưu";
            // 
            // btnDeleteProfile
            // 
            btnDeleteProfile.Enabled = false;
            btnDeleteProfile.Location = new Point(191, 480);
            btnDeleteProfile.Margin = new Padding(3, 4, 3, 4);
            btnDeleteProfile.Name = "btnDeleteProfile";
            btnDeleteProfile.Size = new Size(86, 33);
            btnDeleteProfile.TabIndex = 5;
            btnDeleteProfile.Text = "Xóa";
            btnDeleteProfile.UseVisualStyleBackColor = true;
            btnDeleteProfile.Click += btnDeleteProfile_Click;
            // 
            // btnSaveProfile
            // 
            btnSaveProfile.Location = new Point(98, 480);
            btnSaveProfile.Margin = new Padding(3, 4, 3, 4);
            btnSaveProfile.Name = "btnSaveProfile";
            btnSaveProfile.Size = new Size(86, 33);
            btnSaveProfile.TabIndex = 4;
            btnSaveProfile.Text = "Lưu";
            btnSaveProfile.UseVisualStyleBackColor = true;
            btnSaveProfile.Click += btnSaveProfile_Click;
            // 
            // btnAddProfile
            // 
            btnAddProfile.Location = new Point(7, 480);
            btnAddProfile.Margin = new Padding(3, 4, 3, 4);
            btnAddProfile.Name = "btnAddProfile";
            btnAddProfile.Size = new Size(86, 33);
            btnAddProfile.TabIndex = 3;
            btnAddProfile.Text = "Thêm mới";
            btnAddProfile.UseVisualStyleBackColor = true;
            btnAddProfile.Click += btnAddProfile_Click;
            // 
            // txtProfileName
            // 
            txtProfileName.Location = new Point(98, 36);
            txtProfileName.Margin = new Padding(3, 4, 3, 4);
            txtProfileName.Name = "txtProfileName";
            txtProfileName.Size = new Size(178, 27);
            txtProfileName.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(7, 40);
            label6.Name = "label6";
            label6.Size = new Size(94, 20);
            label6.TabIndex = 1;
            label6.Text = "Tên cấu hình:";
            // 
            // lstProfiles
            // 
            lstProfiles.FormattingEnabled = true;
            lstProfiles.Location = new Point(7, 75);
            lstProfiles.Margin = new Padding(3, 4, 3, 4);
            lstProfiles.Name = "lstProfiles";
            lstProfiles.Size = new Size(269, 384);
            lstProfiles.TabIndex = 0;
            // 
            // groupBoxBackupConfig
            // 
            groupBoxBackupConfig.Controls.Add(dtpWeeklyTime);
            groupBoxBackupConfig.Controls.Add(cbDayOfWeek);
            groupBoxBackupConfig.Controls.Add(label5);
            groupBoxBackupConfig.Controls.Add(dtpDailyTime);
            groupBoxBackupConfig.Controls.Add(label4);
            groupBoxBackupConfig.Controls.Add(nudHourlyInterval);
            groupBoxBackupConfig.Controls.Add(label3);
            groupBoxBackupConfig.Controls.Add(rbWeekly);
            groupBoxBackupConfig.Controls.Add(rbDaily);
            groupBoxBackupConfig.Controls.Add(rbHourly);
            groupBoxBackupConfig.Controls.Add(btnBrowseDestination);
            groupBoxBackupConfig.Controls.Add(txtDestinationPath);
            groupBoxBackupConfig.Controls.Add(label2);
            groupBoxBackupConfig.Controls.Add(btnBrowseSource);
            groupBoxBackupConfig.Controls.Add(txtSourcePath);
            groupBoxBackupConfig.Controls.Add(label1);
            groupBoxBackupConfig.Location = new Point(306, 16);
            groupBoxBackupConfig.Margin = new Padding(3, 4, 3, 4);
            groupBoxBackupConfig.Name = "groupBoxBackupConfig";
            groupBoxBackupConfig.Padding = new Padding(3, 4, 3, 4);
            groupBoxBackupConfig.Size = new Size(560, 480);
            groupBoxBackupConfig.TabIndex = 1;
            groupBoxBackupConfig.TabStop = false;
            groupBoxBackupConfig.Text = "Cấu hình chi tiết sao lưu";
            // 
            // dtpWeeklyTime
            // 
            dtpWeeklyTime.Format = DateTimePickerFormat.Time;
            dtpWeeklyTime.Location = new Point(307, 373);
            dtpWeeklyTime.Margin = new Padding(3, 4, 3, 4);
            dtpWeeklyTime.Name = "dtpWeeklyTime";
            dtpWeeklyTime.ShowUpDown = true;
            dtpWeeklyTime.Size = new Size(108, 27);
            dtpWeeklyTime.TabIndex = 9;
            // 
            // cbDayOfWeek
            // 
            cbDayOfWeek.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDayOfWeek.FormattingEnabled = true;
            cbDayOfWeek.Location = new Point(206, 373);
            cbDayOfWeek.Margin = new Padding(3, 4, 3, 4);
            cbDayOfWeek.Name = "cbDayOfWeek";
            cbDayOfWeek.Size = new Size(94, 28);
            cbDayOfWeek.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(166, 379);
            label5.Name = "label5";
            label5.Size = new Size(36, 20);
            label5.TabIndex = 7;
            label5.Text = "vào:";
            // 
            // dtpDailyTime
            // 
            dtpDailyTime.Format = DateTimePickerFormat.Time;
            dtpDailyTime.Location = new Point(206, 311);
            dtpDailyTime.Margin = new Padding(3, 4, 3, 4);
            dtpDailyTime.Name = "dtpDailyTime";
            dtpDailyTime.ShowUpDown = true;
            dtpDailyTime.Size = new Size(108, 27);
            dtpDailyTime.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(166, 316);
            label4.Name = "label4";
            label4.Size = new Size(36, 20);
            label4.TabIndex = 5;
            label4.Text = "vào:";
            // 
            // nudHourlyInterval
            // 
            nudHourlyInterval.Location = new Point(206, 248);
            nudHourlyInterval.Margin = new Padding(3, 4, 3, 4);
            nudHourlyInterval.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudHourlyInterval.Name = "nudHourlyInterval";
            nudHourlyInterval.Size = new Size(57, 27);
            nudHourlyInterval.TabIndex = 4;
            nudHourlyInterval.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(270, 251);
            label3.Name = "label3";
            label3.Size = new Size(57, 20);
            label3.TabIndex = 3;
            label3.Text = "giờ/lần";
            // 
            // rbWeekly
            // 
            rbWeekly.AutoSize = true;
            rbWeekly.Location = new Point(22, 376);
            rbWeekly.Margin = new Padding(3, 4, 3, 4);
            rbWeekly.Name = "rbWeekly";
            rbWeekly.Size = new Size(156, 24);
            rbWeekly.TabIndex = 2;
            rbWeekly.Text = "Hàng tuần vào thứ:";
            rbWeekly.UseVisualStyleBackColor = true;
            // 
            // rbDaily
            // 
            rbDaily.AutoSize = true;
            rbDaily.Checked = true;
            rbDaily.Location = new Point(22, 313);
            rbDaily.Margin = new Padding(3, 4, 3, 4);
            rbDaily.Name = "rbDaily";
            rbDaily.Size = new Size(133, 24);
            rbDaily.TabIndex = 1;
            rbDaily.TabStop = true;
            rbDaily.Text = "Hàng ngày vào:";
            rbDaily.UseVisualStyleBackColor = true;
            // 
            // rbHourly
            // 
            rbHourly.AutoSize = true;
            rbHourly.Location = new Point(22, 251);
            rbHourly.Margin = new Padding(3, 4, 3, 4);
            rbHourly.Name = "rbHourly";
            rbHourly.Size = new Size(175, 24);
            rbHourly.TabIndex = 0;
            rbHourly.Text = "Mỗi khoảng thời gian:";
            rbHourly.UseVisualStyleBackColor = true;
            // 
            // btnBrowseDestination
            // 
            btnBrowseDestination.Location = new Point(467, 124);
            btnBrowseDestination.Margin = new Padding(3, 4, 3, 4);
            btnBrowseDestination.Name = "btnBrowseDestination";
            btnBrowseDestination.Size = new Size(86, 31);
            btnBrowseDestination.TabIndex = 5;
            btnBrowseDestination.Text = "Duyệt...";
            btnBrowseDestination.UseVisualStyleBackColor = true;
            btnBrowseDestination.Click += btnBrowseDestination_Click;
            // 
            // txtDestinationPath
            // 
            txtDestinationPath.Location = new Point(17, 124);
            txtDestinationPath.Margin = new Padding(3, 4, 3, 4);
            txtDestinationPath.Name = "txtDestinationPath";
            txtDestinationPath.Size = new Size(443, 27);
            txtDestinationPath.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 100);
            label2.Name = "label2";
            label2.Size = new Size(142, 20);
            label2.TabIndex = 3;
            label2.Text = "Đường dẫn đích (B):";
            // 
            // btnBrowseSource
            // 
            btnBrowseSource.Location = new Point(467, 51);
            btnBrowseSource.Margin = new Padding(3, 4, 3, 4);
            btnBrowseSource.Name = "btnBrowseSource";
            btnBrowseSource.Size = new Size(86, 31);
            btnBrowseSource.TabIndex = 2;
            btnBrowseSource.Text = "Duyệt...";
            btnBrowseSource.UseVisualStyleBackColor = true;
            btnBrowseSource.Click += btnBrowseSource_Click;
            // 
            // txtSourcePath
            // 
            txtSourcePath.Location = new Point(17, 51);
            txtSourcePath.Margin = new Padding(3, 4, 3, 4);
            txtSourcePath.Name = "txtSourcePath";
            txtSourcePath.Size = new Size(443, 27);
            txtSourcePath.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 27);
            label1.Name = "label1";
            label1.Size = new Size(157, 20);
            label1.TabIndex = 0;
            label1.Text = "Đường dẫn nguồn (A):";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatus.Location = new Point(306, 513);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(84, 20);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Trạng thái:";
            // 
            // btnRunNow
            // 
            btnRunNow.Location = new Point(306, 537);
            btnRunNow.Margin = new Padding(3, 4, 3, 4);
            btnRunNow.Name = "btnRunNow";
            btnRunNow.Size = new Size(114, 40);
            btnRunNow.TabIndex = 3;
            btnRunNow.Text = "Chạy ngay";
            btnRunNow.UseVisualStyleBackColor = true;
            btnRunNow.Click += btnRunNow_Click;
            // 
            // btnApplyToTaskScheduler
            // 
            btnApplyToTaskScheduler.Enabled = false;
            btnApplyToTaskScheduler.Location = new Point(626, 537);
            btnApplyToTaskScheduler.Margin = new Padding(3, 4, 3, 4);
            btnApplyToTaskScheduler.Name = "btnApplyToTaskScheduler";
            btnApplyToTaskScheduler.Size = new Size(240, 40);
            btnApplyToTaskScheduler.TabIndex = 4;
            btnApplyToTaskScheduler.Text = "Áp dụng vào Task Scheduler";
            btnApplyToTaskScheduler.UseVisualStyleBackColor = true;
            btnApplyToTaskScheduler.Click += btnApplyToTaskScheduler_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 587);
            Controls.Add(btnApplyToTaskScheduler);
            Controls.Add(btnRunNow);
            Controls.Add(lblStatus);
            Controls.Add(groupBoxBackupConfig);
            Controls.Add(groupBoxProfiles);
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(896, 623);
            Name = "FormMain";
            Text = "Quản lý sao lưu theo lịch";
            groupBoxProfiles.ResumeLayout(false);
            groupBoxProfiles.PerformLayout();
            groupBoxBackupConfig.ResumeLayout(false);
            groupBoxBackupConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudHourlyInterval).EndInit();
            ResumeLayout(false);
            PerformLayout();

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