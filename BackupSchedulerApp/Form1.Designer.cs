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
            label1 = new Label();
            txtSourcePath = new TextBox();
            btnBrowseSource = new Button();
            label2 = new Label();
            txtDestinationPath = new TextBox();
            btnBrowseDestination = new Button();
            btnSaveConfig = new Button();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 33);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(191, 25);
            label1.TabIndex = 0;
            label1.Text = "Đường dẫn nguồn (A):";
            // 
            // txtSourcePath
            // 
            txtSourcePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSourcePath.Location = new Point(17, 63);
            txtSourcePath.Margin = new Padding(4, 5, 4, 5);
            txtSourcePath.Name = "txtSourcePath";
            txtSourcePath.Size = new Size(580, 31);
            txtSourcePath.TabIndex = 1;
            // 
            // btnBrowseSource
            // 
            btnBrowseSource.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBrowseSource.Location = new Point(607, 63);
            btnBrowseSource.Margin = new Padding(4, 5, 4, 5);
            btnBrowseSource.Name = "btnBrowseSource";
            btnBrowseSource.Size = new Size(107, 38);
            btnBrowseSource.TabIndex = 2;
            btnBrowseSource.Text = "Duyệt...";
            btnBrowseSource.UseVisualStyleBackColor = true;
            btnBrowseSource.Click += btnBrowseSource_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 117);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(170, 25);
            label2.TabIndex = 3;
            label2.Text = "Đường dẫn đích (B):";
            // 
            // txtDestinationPath
            // 
            txtDestinationPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDestinationPath.Location = new Point(17, 147);
            txtDestinationPath.Margin = new Padding(4, 5, 4, 5);
            txtDestinationPath.Name = "txtDestinationPath";
            txtDestinationPath.Size = new Size(580, 31);
            txtDestinationPath.TabIndex = 4;
            // 
            // btnBrowseDestination
            // 
            btnBrowseDestination.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBrowseDestination.Location = new Point(607, 147);
            btnBrowseDestination.Margin = new Padding(4, 5, 4, 5);
            btnBrowseDestination.Name = "btnBrowseDestination";
            btnBrowseDestination.Size = new Size(107, 38);
            btnBrowseDestination.TabIndex = 5;
            btnBrowseDestination.Text = "Duyệt...";
            btnBrowseDestination.UseVisualStyleBackColor = true;
            btnBrowseDestination.Click += btnBrowseDestination_Click;
            // 
            // btnSaveConfig
            // 
            btnSaveConfig.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSaveConfig.Location = new Point(571, 215);
            btnSaveConfig.Margin = new Padding(4, 5, 4, 5);
            btnSaveConfig.Name = "btnSaveConfig";
            btnSaveConfig.Size = new Size(143, 50);
            btnSaveConfig.TabIndex = 7;
            btnSaveConfig.Text = "Lưu cấu hình";
            btnSaveConfig.UseVisualStyleBackColor = true;
            btnSaveConfig.Click += btnSaveConfig_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lblStatus.Location = new Point(34, 240);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(104, 25);
            lblStatus.TabIndex = 9;
            lblStatus.Text = "Trạng thái:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(731, 540);
            Controls.Add(lblStatus);
            Controls.Add(btnSaveConfig);
            Controls.Add(btnBrowseDestination);
            Controls.Add(txtDestinationPath);
            Controls.Add(label2);
            Controls.Add(btnBrowseSource);
            Controls.Add(txtSourcePath);
            Controls.Add(label1);
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(705, 596);
            Name = "Form1";
            Text = "Ứng dụng sao lưu theo lịch";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSourcePath;
        private System.Windows.Forms.Button btnBrowseSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDestinationPath;
        private System.Windows.Forms.Button btnBrowseDestination;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.Label lblStatus;
    }
}
