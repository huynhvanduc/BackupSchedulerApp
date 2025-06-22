using Backup.Ultilities;
using Backup.Ultilities.Enums;
using Backup.Ultilities.Models;
using System;
using System.Runtime.InteropServices;

namespace Backup.Window;

public partial class FormMain : Form
{
    private List<BackupProfile> _backupProfiles;
    private BackupProfile _currentSelectedProfile;
    private readonly string _configuratorLogFilePath; // Added for configurator's own log
    private const string BackupBatchName = "BackupCore";

    public FormMain()
    {
        InitializeComponent();
        // Initialize configurator's log file path
        _configuratorLogFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configurator_log.txt");
        InitializeUI();
        LoadBackupProfiles();
        UpdateStatus("Sẵn sàng.", false);
    }

    private void InitializeUI()
    {
        // Event handlers for radio buttons
        rbHourly.CheckedChanged += (s, e) => UpdateScheduleControls();
        rbDaily.CheckedChanged += (s, e) => UpdateScheduleControls();
        rbWeekly.CheckedChanged += (s, e) => UpdateScheduleControls();

        // Populate DayOfWeek ComboBox
        cbDayOfWeek.Items.AddRange(Enum.GetNames(typeof(DayOfWeek)));
        cbDayOfWeek.SelectedItem = DayOfWeek.Monday.ToString(); // Default selection

        // Set DateTimePickers to show time only
        dtpDailyTime.Format = DateTimePickerFormat.Time;
        dtpDailyTime.ShowUpDown = true;
        dtpWeeklyTime.Format = DateTimePickerFormat.Time;
        dtpWeeklyTime.ShowUpDown = true;

        // Handle ListBox selection change
        lstProfiles.SelectedIndexChanged += lstProfiles_SelectedIndexChanged;

        UpdateScheduleControls(); // Initial call
    }

    private void LoadBackupProfiles()
    {
        try
        {
            _backupProfiles = ProfileManager.LoadProfiles();
            if (_backupProfiles == null)
            {
                _backupProfiles = new List<BackupProfile>();
                UpdateStatus("Không tìm thấy cấu hình sao lưu cũ. Tạo mới.", false);
            }
            else
            {
                UpdateStatus($"Đã tải {_backupProfiles.Count} cấu hình sao lưu.", false);
            }
            RefreshProfileList();
        }
        catch (Exception ex)
        {
            _backupProfiles = new List<BackupProfile>();
            UpdateStatus($"Lỗi khi tải cấu hình: {ex.Message}", true);
            Logger.Log($"Lỗi khi tải cấu hình: {ex.Message}\n{ex.StackTrace}", _configuratorLogFilePath); // Use the correct Logger.Log overload
        }
    }

    private void RefreshProfileList()
    {
        lstProfiles.Items.Clear();
        foreach (var profile in _backupProfiles.OrderBy(p => p.Name))
        {
            lstProfiles.Items.Add(profile); // ListBox will display Profile.ToString()
        }
        // Clear current selection and UI fields
        ClearProfileUI();
    }

    private void ClearProfileUI()
    {
        txtProfileName.Text = string.Empty;
        txtSourcePath.Text = string.Empty;
        txtDestinationPath.Text = string.Empty;
        rbDaily.Checked = true; // Default schedule type
        nudHourlyInterval.Value = 1;
        dtpDailyTime.Value = DateTime.Today.Add(new TimeSpan(7, 0, 0));
        cbDayOfWeek.SelectedItem = DayOfWeek.Monday.ToString();
        dtpWeeklyTime.Value = DateTime.Today.Add(new TimeSpan(10, 0, 0));
        _currentSelectedProfile = null;
        lstProfiles.ClearSelected();
        btnDeleteProfile.Enabled = false;
        btnApplyToTaskScheduler.Enabled = false;
    }

    private void LoadProfileToUI(BackupProfile profile)
    {
        if (profile == null)
        {
            ClearProfileUI();
            return;
        }

        txtProfileName.Text = profile.Name;
        txtSourcePath.Text = profile.SourcePath;
        txtDestinationPath.Text = profile.DestinationPath;

        switch (profile.ScheduleType)
        {
            case ScheduleType.Hourly:
                rbHourly.Checked = true;
                nudHourlyInterval.Value = profile.HourlyInterval;
                break;
            case ScheduleType.Daily:
                rbDaily.Checked = true;
                dtpDailyTime.Value = DateTime.Today.Add(profile.DailyTime);
                break;
            case ScheduleType.Weekly:
                rbWeekly.Checked = true;
                cbDayOfWeek.SelectedItem = profile.WeeklyDay.ToString();
                dtpWeeklyTime.Value = DateTime.Today.Add(profile.WeeklyTime);
                break;
        }
        UpdateScheduleControls();
        _currentSelectedProfile = profile;
        btnDeleteProfile.Enabled = true;
        btnApplyToTaskScheduler.Enabled = true;
    }

    private BackupProfile GetProfileFromUI()
    {
        var profile = _currentSelectedProfile ?? new BackupProfile { Id = Guid.NewGuid() };

        profile.Name = txtProfileName.Text.Trim();
        profile.SourcePath = txtSourcePath.Text.Trim();
        profile.DestinationPath = txtDestinationPath.Text.Trim();

        if (rbHourly.Checked)
        {
            profile.ScheduleType = ScheduleType.Hourly;
            profile.HourlyInterval = (int)nudHourlyInterval.Value;
        }
        else if (rbDaily.Checked)
        {
            profile.ScheduleType = ScheduleType.Daily;
            profile.DailyTime = dtpDailyTime.Value.TimeOfDay;
        }
        else if (rbWeekly.Checked)
        {
            profile.ScheduleType = ScheduleType.Weekly;
            profile.WeeklyDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), cbDayOfWeek.SelectedItem.ToString());
            profile.WeeklyTime = dtpWeeklyTime.Value.TimeOfDay;
        }
        return profile;
    }

    private bool ValidateInputs()
    {
        if (string.IsNullOrWhiteSpace(txtProfileName.Text))
        {
            MessageBox.Show("Tên cấu hình không được để trống.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
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

    private void UpdateScheduleControls()
    {
        nudHourlyInterval.Enabled = rbHourly.Checked;
        dtpDailyTime.Enabled = rbDaily.Checked;
        cbDayOfWeek.Enabled = rbWeekly.Checked;
        dtpWeeklyTime.Enabled = rbWeekly.Checked;
    }

    private void lstProfiles_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lstProfiles.SelectedItem is BackupProfile selectedProfile)
        {
            LoadProfileToUI(selectedProfile);
        }
        else
        {
            ClearProfileUI();
        }
    }

    private void btnAddProfile_Click(object sender, EventArgs e)
    {
        ClearProfileUI();
        UpdateStatus("Tạo cấu hình mới...", false);
    }

    private void btnSaveProfile_Click(object sender, EventArgs e)
    {
        if (!ValidateInputs()) return;

        try
        {
            BackupProfile profileToSave = GetProfileFromUI();

            if (_backupProfiles.Any(p => p.Id == profileToSave.Id))
            {
                // Update existing profile
                var existingProfile = _backupProfiles.First(p => p.Id == profileToSave.Id);
                existingProfile.Name = profileToSave.Name;
                existingProfile.SourcePath = profileToSave.SourcePath;
                existingProfile.DestinationPath = profileToSave.DestinationPath;
                existingProfile.ScheduleType = profileToSave.ScheduleType;
                existingProfile.HourlyInterval = profileToSave.HourlyInterval;
                existingProfile.DailyTime = profileToSave.DailyTime;
                existingProfile.WeeklyDay = profileToSave.WeeklyDay;
                existingProfile.WeeklyTime = profileToSave.WeeklyTime;

                UpdateStatus($"Đã cập nhật cấu hình '{profileToSave.Name}'.", false);
                Logger.Log($"Đã cập nhật cấu hình '{profileToSave.Name}'.", _configuratorLogFilePath);
            }
            else
            {
                // Add new profile
                _backupProfiles.Add(profileToSave);
                UpdateStatus($"Đã thêm cấu hình mới '{profileToSave.Name}'.", false);
                Logger.Log($"Đã thêm cấu hình mới '{profileToSave.Name}'.", _configuratorLogFilePath);
            }

            ProfileManager.SaveProfiles(_backupProfiles);
            RefreshProfileList();
            // Select the newly saved/updated profile in the list
            lstProfiles.SelectedItem = profileToSave;
            UpdateStatus("Đã lưu cấu hình và profile. Vui lòng nhấn 'Áp dụng vào Task Scheduler' để lên lịch.", false);
        }
        catch (Exception ex)
        {
            UpdateStatus($"Lỗi khi lưu cấu hình: {ex.Message}", true);
            Logger.Log($"Lỗi khi lưu cấu hình: {ex.Message}\n{ex.StackTrace}", _configuratorLogFilePath);
            MessageBox.Show($"Lỗi khi lưu cấu hình: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnDeleteProfile_Click(object sender, EventArgs e)
    {
        if (_currentSelectedProfile == null) return;

        var result = MessageBox.Show($"Bạn có chắc muốn xóa cấu hình '{_currentSelectedProfile.Name}'? Tác vụ theo lịch tương ứng cũng sẽ bị xóa.", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (result == DialogResult.Yes)
        {
            try
            {
                // Remove from list
                _backupProfiles.RemoveAll(p => p.Id == _currentSelectedProfile.Id);
                ProfileManager.SaveProfiles(_backupProfiles);
                Logger.Log($"Đã xóa cấu hình '{_currentSelectedProfile.Name}'.", _configuratorLogFilePath);

                // Remove associated scheduled task
                TaskSchedulerService.DeleteBackupTask(_currentSelectedProfile.Id);
                Logger.Log($"Đã xóa tác vụ theo lịch cho cấu hình '{_currentSelectedProfile.Name}'.", _configuratorLogFilePath);

                RefreshProfileList();
                UpdateStatus($"Đã xóa cấu hình '{_currentSelectedProfile?.Name}' và tác vụ liên quan.", false);
            }
            catch (Exception ex)
            {
                UpdateStatus($"Lỗi khi xóa cấu hình: {ex.Message}", true);
                Logger.Log($"Lỗi khi xóa cấu hình: {ex.Message}\n{ex.StackTrace}", _configuratorLogFilePath);
                MessageBox.Show($"Lỗi khi xóa cấu hình: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private async void btnApplyToTaskScheduler_Click(object sender, EventArgs e)
    {
        if (_currentSelectedProfile == null)
        {
            MessageBox.Show("Vui lòng chọn hoặc tạo một cấu hình trước khi áp dụng vào Task Scheduler.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        if (!ValidateInputs()) return;

        UpdateStatus("Đang áp dụng vào Task Scheduler...", false);
        btnApplyToTaskScheduler.Enabled = false;

        try
        {
            // Ensure the latest changes are saved before applying
            btnSaveProfile_Click(sender, e); // This will save the profile to profiles.json

            // Adjust this path based on your build configuration (Debug/Release) and solution structure
            // For Debug:
            string workerAppPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{BackupBatchName}.exe");

            // For Release build, use:
            // string workerAppPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "BackupWorker", "bin", "Release", "net6.0", "BackupWorker.exe");

            // Verify worker executable exists
            if (!File.Exists(workerAppPath))
            {
                MessageBox.Show($"Không tìm thấy ứng dụng Worker tại đường dẫn: {workerAppPath}. Vui lòng đảm bảo dự án {BackupBatchName} đã được build.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Log($"Không tìm thấy {BackupBatchName}.exe tại: {workerAppPath}", _configuratorLogFilePath);
                UpdateStatus($"Lỗi: Không tìm thấy {BackupBatchName}.exe.", true);
                return;
            }

            await Task.Run(() =>
            {
                TaskSchedulerService.CreateOrUpdateBackupTask(_currentSelectedProfile, workerAppPath);
            });

            UpdateStatus($"Đã áp dụng cấu hình '{_currentSelectedProfile.Name}' vào Task Scheduler thành công!", false);
            MessageBox.Show($"Đã tạo/cập nhật tác vụ sao lưu cho cấu hình '{_currentSelectedProfile.Name}' trong Task Scheduler.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            UpdateStatus($"Lỗi khi áp dụng vào Task Scheduler: {ex.Message}", true);
            Logger.Log($"Lỗi khi áp dụng vào Task Scheduler: {ex.Message}\n{ex.StackTrace}", _configuratorLogFilePath);
            MessageBox.Show($"Lỗi khi áp dụng vào Task Scheduler: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnApplyToTaskScheduler.Enabled = true;
        }
    }


    private async void btnRunNow_Click(object sender, EventArgs e)
    {
        if (_currentSelectedProfile == null)
        {
            MessageBox.Show("Vui lòng chọn hoặc tạo một cấu hình để chạy ngay.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        if (!ValidateInputs()) return;

        UpdateStatus("Đang chạy sao lưu thủ công...", false);
        btnRunNow.Enabled = false;
        btnSaveProfile.Enabled = false;
        btnApplyToTaskScheduler.Enabled = false;

        try
        {
            // Save current configuration to ensure worker uses latest settings
            btnSaveProfile_Click(sender, e);

            // Adjust this path based on your build configuration (Debug/Release) and solution structure
            // For Debug:
            string workerAppPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{BackupBatchName}.exe");

            // For Release build, use:
            // string workerAppPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "BackupWorker", "bin", "Release", "net6.0", "BackupWorker.exe");

            if (!File.Exists(workerAppPath))
            {
                MessageBox.Show($"Không tìm thấy ứng dụng Worker tại đường dẫn: {workerAppPath}. Vui lòng đảm bảo dự án {BackupBatchName} đã được build.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Log($"Không tìm thấy {BackupBatchName}.exe tại: {workerAppPath}", _configuratorLogFilePath);
                UpdateStatus($"Lỗi: Không tìm thấy {BackupBatchName}.exe.", true);
                return;
            }

            // Run the worker immediately
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = workerAppPath,
                Arguments = $"--profileId {_currentSelectedProfile.Id}",
                UseShellExecute = false, // Set to false to hide console window
                CreateNoWindow = true,   // Ensure no window is created
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            using (System.Diagnostics.Process process = System.Diagnostics.Process.Start(startInfo))
            {
                // You might want to read output for real-time status or just wait
                string output = await process.StandardOutput.ReadToEndAsync();
                string error = await process.StandardError.ReadToEndAsync();
                await Task.Run(() => process.WaitForExit()); // Wait for the worker process to finish

                if (process.ExitCode == 0)
                {
                    UpdateStatus($"Sao lưu thủ công cho '{_currentSelectedProfile.Name}' thành công!", false);
                    Logger.Log($"Sao lưu thủ công cho '{_currentSelectedProfile.Name}' thành công. Output: {output}", _configuratorLogFilePath);
                }
                else
                {
                    UpdateStatus($"Sao lưu thủ công cho '{_currentSelectedProfile.Name}' thất bại (Exit Code: {process.ExitCode}).", true);
                    Logger.Log($"Sao lưu thủ công cho '{_currentSelectedProfile.Name}' thất bại. Error: {error}. Output: {output}", _configuratorLogFilePath);
                }
            }
        }
        catch (Exception ex)
        {
            UpdateStatus($"Lỗi khi chạy sao lưu thủ công: {ex.Message}", true);
            Logger.Log($"Lỗi khi chạy sao lưu thủ công: {ex.Message}\n{ex.StackTrace}", _configuratorLogFilePath);
            MessageBox.Show($"Lỗi khi chạy sao lưu thủ công: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            btnRunNow.Enabled = true;
            btnSaveProfile.Enabled = true;
            btnApplyToTaskScheduler.Enabled = true;
        }
    }

    private void btnBrowseSource_Click(object sender, EventArgs e)
    {
        using (var fbd = new FolderBrowserDialog())
        {
            if (!string.IsNullOrWhiteSpace(txtSourcePath.Text) && Directory.Exists(txtSourcePath.Text))
            {
                fbd.SelectedPath = txtSourcePath.Text;
            }
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                txtSourcePath.Text = fbd.SelectedPath;
            }
        }
    }

    private void btnBrowseDestination_Click(object sender, EventArgs e)
    {
        using (var fbd = new FolderBrowserDialog())
        {
            if (!string.IsNullOrWhiteSpace(txtDestinationPath.Text) && Directory.Exists(txtDestinationPath.Text))
            {
                fbd.SelectedPath = txtDestinationPath.Text;
            }
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                txtDestinationPath.Text = fbd.SelectedPath;
            }
        }
    }

    private void UpdateStatus(string message, bool isError)
    {
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
}