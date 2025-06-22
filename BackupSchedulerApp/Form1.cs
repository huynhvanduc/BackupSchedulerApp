using BackupSchedulerApp.Enums;
using BackupSchedulerApp.Models;
using BackupSchedulerApp.Services;

namespace BackupSchedulerApp
{
    public partial class Form1 : Form
    {
        private readonly string _configFilePath;
        private readonly string _logFilePath;

        public Form1()
        {
            InitializeComponent();
            _configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
            _logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "backup_log.txt");
            InitializeUI();
            LoadConfiguration();
            // Set initial status
            UpdateStatus("Sẵn sàng.", false);
        }

        private void InitializeUI()
        {
            UpdateScheduleControls(); // Initial call to set correct visibility
        }

        private void UpdateScheduleControls()
        {
        }

        private void LoadConfiguration()
        {
            try
            {
                var settings = AppSettings.Load(_configFilePath);
                if (settings != null)
                {
                    txtSourcePath.Text = settings.SourcePath;
                    txtDestinationPath.Text = settings.DestinationPath;

                    UpdateStatus("Đã tải cấu hình.", false);
                }
                else
                {
                    UpdateStatus("Không tìm thấy cấu hình cũ. Vui lòng thiết lập.", false);
                }
            }
            catch (Exception ex)
            {
                UpdateStatus($"Lỗi khi tải cấu hình: {ex.Message}", true);
                Logger.Log($"Lỗi khi tải cấu hình: {ex.Message}", _logFilePath);
            }
        }

        private AppSettings GetCurrentSettings()
        {
            var settings = new AppSettings
            {
                SourcePath = txtSourcePath.Text,
                DestinationPath = txtDestinationPath.Text
            };

            settings.ScheduleType = ScheduleType.Daily;
            return settings;
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtSourcePath.Text) || !Directory.Exists(txtSourcePath.Text))
            {
                MessageBox.Show("Đường dẫn nguồn không hợp lệ hoặc không tồn tại.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDestinationPath.Text))
            {
                MessageBox.Show("Đường dẫn đích không được để trống.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private async void btnRunNow_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            string sourcePath = txtSourcePath.Text;
            string destinationPath = txtDestinationPath.Text;

            UpdateStatus("Đang chạy sao lưu thủ công...", false);
            btnSaveConfig.Enabled = false;

            await Task.Run(async () => // Run backup and task creation on a background thread
            {
                try
                {
                    await BackupService.PerformBackup(sourcePath, destinationPath, _logFilePath);
                    Logger.Log("Sao lưu thủ công thành công.", _logFilePath);

                    // Save current configuration after successful manual backup
                    var settings = GetCurrentSettings();
                    AppSettings.Save(settings, _configFilePath);
                    Logger.Log("Đã lưu cấu hình ứng dụng sau sao lưu thủ công.", _logFilePath);

                    // Create or update Windows Scheduled Task with current settings
                    string appPath = Application.ExecutablePath;
                    string taskName = "BackupSchedulerAppTask";
                    TaskSchedulerService.CreateOrUpdateBackupTask(
                        taskName,
                        appPath,
                        settings.ScheduleType,
                        settings.HourlyInterval,
                        settings.DailyTime,
                        settings.WeeklyDay,
                        settings.WeeklyTime,
                        _logFilePath
                    );
                    Logger.Log("Đã tạo/cập nhật tác vụ theo lịch sau sao lưu thủ công.", _logFilePath);

                    Invoke((MethodInvoker)delegate
                    {
                        UpdateStatus("Sao lưu thủ công và cập nhật tác vụ thành công!", false);
                    });
                }
                catch (Exception ex)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        UpdateStatus($"Thao tác thất bại: {ex.Message}", true);
                    });
                    Logger.Log($"Lỗi trong thao tác chạy ngay: {ex.Message}\n{ex.StackTrace}", _logFilePath);
                }
                finally
                {
                    Invoke((MethodInvoker)delegate
                    {
                        btnSaveConfig.Enabled = true;
                    });
                }
            });
        }

        private void btnBrowseSource_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                // Set the owner to this form to ensure the dialog appears on top
                // This line is added/modified for fixing the issue.
                if (!string.IsNullOrWhiteSpace(txtSourcePath.Text) && Directory.Exists(txtSourcePath.Text))
                {
                    fbd.SelectedPath = txtSourcePath.Text;
                }
                if (fbd.ShowDialog(this) == DialogResult.OK) // Pass 'this' as the owner
                {
                    txtSourcePath.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnBrowseDestination_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                // Set the owner to this form to ensure the dialog appears on top
                // This line is added/modified for fixing the issue.
                if (!string.IsNullOrWhiteSpace(txtDestinationPath.Text) && Directory.Exists(txtDestinationPath.Text))
                {
                    fbd.SelectedPath = txtDestinationPath.Text;
                }
                if (fbd.ShowDialog(this) == DialogResult.OK) // Pass 'this' as the owner
                {
                    txtDestinationPath.Text = fbd.SelectedPath;
                }
            }
        }

        private async void btnSaveConfig_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                var settings = GetCurrentSettings();
                AppSettings.Save(settings, _configFilePath);
                Logger.Log("Đã lưu cấu hình ứng dụng.", _logFilePath);

                // Create or update Windows Scheduled Task
                string appPath = Application.ExecutablePath;
                string taskName = "BackupSchedulerAppTask";

                await Task.Run(() => // Run Task Scheduler interaction on a background thread
                {
                    TaskSchedulerService.CreateOrUpdateBackupTask(
                        taskName,
                        appPath,
                        settings.ScheduleType,
                        settings.HourlyInterval,
                        settings.DailyTime,
                        settings.WeeklyDay,
                        settings.WeeklyTime,
                        _logFilePath
                    );
                });

                UpdateStatus("Đã lưu cấu hình và tạo/cập nhật tác vụ theo lịch thành công!", false);
                MessageBox.Show("Cấu hình và tác vụ sao lưu đã được lưu/cập nhật thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                UpdateStatus($"Lỗi khi lưu cấu hình hoặc tạo tác vụ: {ex.Message}", true);
                Logger.Log($"Lỗi khi lưu cấu hình hoặc tạo tác vụ: {ex.Message}\n{ex.StackTrace}", _logFilePath);
                MessageBox.Show($"Lỗi khi lưu cấu hình hoặc tạo tác vụ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatus(string message, bool isError)
        {
            // Ensure UI update happens on the UI thread
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    UpdateStatus(message, isError);
                });
                return;
            }

            lblStatus.Text = $"Trạng thái: {message}";
            lblStatus.ForeColor = isError ? System.Drawing.Color.Red : System.Drawing.Color.DarkGreen;
        }


        // Add this method to display log in the UI if needed for debugging
        private void AppendLogToUI(string message)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate
                {
                    AppendLogToUI(message);
                });
                return;
            }
            //txtLogDisplay.AppendText($"{DateTime.Now:HH:mm:ss} {message}{Environment.NewLine}");
            //txtLogDisplay.ScrollToCaret();
        }
    }
}
