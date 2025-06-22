using Backup.Ultilities;
using Backup.Ultilities.Enums;
using Backup.Ultilities.Models;
using Microsoft.Win32.TaskScheduler;

namespace Backup.Window;

internal class TaskSchedulerService
{
    private const string TaskFolderName = "BackupSchedulerAppTasks"; // A subfolder for your tasks
    private static readonly string _configuratorLogFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log", "Configurator_TaskScheduler_Log.txt"); // Dedicated log for task scheduler ops

    /// <summary>
    /// Creates or updates a Windows Scheduled Task to run the BackupWorker application for a specific profile.
    /// </summary>
    /// <param name="profile">The BackupProfile containing scheduling details.</param>
    /// <param name="workerAppPath">The full path to the BackupWorker executable.</param>
    public static void CreateOrUpdateBackupTask(BackupProfile profile, string workerAppPath)
    {
        try
        {
            using (TaskService ts = new TaskService())
            {
                // Create a folder for the tasks if it doesn't exist
                TaskFolder folder = ts.GetFolder($"\\{TaskFolderName}");
                if (folder == null)
                {
                    folder = ts.RootFolder.CreateFolder(TaskFolderName);
                    Logger.Log($"Đã tạo thư mục tác vụ: \\{TaskFolderName}", _configuratorLogFilePath);
                }

                // Task name includes the profile ID to make it unique
                string taskName = $"BackupTask_{profile.Name}";

                // Remove existing task for this profile if it exists

                // Replace the problematic line with the following code:
                if (folder.Tasks.Any(task => task.Name.Equals(taskName, StringComparison.OrdinalIgnoreCase)))
                {
                    folder.DeleteTask(taskName);
                    Logger.Log($"Đã xóa tác vụ cũ cho profile '{profile.Name}'", _configuratorLogFilePath);
                }

                TaskDefinition td = ts.NewTask();

                // Task settings
                td.RegistrationInfo.Description = $"Thực hiện sao lưu cho profile '{profile.Name}' theo lịch đã cấu hình bởi Backup Scheduler App.";
                td.Settings.Hidden = false; // Set to true if you want it completely hidden from Task Scheduler UI
                td.Settings.Enabled = true;
                td.Settings.StopIfGoingOnBatteries = false;
                td.Settings.DisallowStartIfOnBatteries = false;
                td.Settings.WakeToRun = true;
                td.Settings.RunOnlyIfNetworkAvailable = false;
                td.Settings.StartWhenAvailable = true;
                td.Settings.AllowDemandStart = true;
                td.Settings.ExecutionTimeLimit = TimeSpan.FromHours(4);
                td.Settings.Priority = System.Diagnostics.ProcessPriorityClass.Normal;
                td.Settings.MultipleInstances = TaskInstancesPolicy.IgnoreNew;

                // Action: Run the BackupWorker application with the profile ID as argument
                td.Actions.Add(new ExecAction(workerAppPath, $"--profileName {profile.Name}", null));
                Logger.Log($"Đã thêm hành động chạy Worker: '{workerAppPath}' với đối số '--profileName {profile.Name}'.", _configuratorLogFilePath);

                // Add Trigger based on schedule type
                Trigger trigger;
                switch (profile.ScheduleType)
                {
                    case ScheduleType.Hourly:
                        trigger = new TimeTrigger();
                        ((TimeTrigger)trigger).Repetition.Interval = TimeSpan.FromHours(profile.HourlyInterval);
                        ((TimeTrigger)trigger).Repetition.Duration = TimeSpan.Zero;
                        ((TimeTrigger)trigger).StartBoundary = DateTime.Now.AddSeconds(30);
                        Logger.Log($"Đã thêm lịch hourly: mỗi {profile.HourlyInterval} giờ.", _configuratorLogFilePath);
                        break;
                    case ScheduleType.Daily:
                        trigger = new DailyTrigger();
                        ((DailyTrigger)trigger).DaysInterval = 1;
                        ((DailyTrigger)trigger).StartBoundary = DateTime.Today.Add(profile.DailyTime);
                        if (((DailyTrigger)trigger).StartBoundary < DateTime.Now && td.Settings.StartWhenAvailable)
                        {
                            ((DailyTrigger)trigger).StartBoundary = ((DailyTrigger)trigger).StartBoundary.AddDays(1);
                            Logger.Log($"Thời gian hàng ngày đã qua, tác vụ sẽ bắt đầu vào ngày mai lúc {profile.DailyTime}.", _configuratorLogFilePath);
                        }
                        Logger.Log($"Đã thêm lịch daily: hàng ngày lúc {profile.DailyTime}.", _configuratorLogFilePath);
                        break;
                    case ScheduleType.Weekly:
                        trigger = new WeeklyTrigger();
                        ((WeeklyTrigger)trigger).DaysOfWeek = (DaysOfTheWeek)(1 << (int)profile.WeeklyDay);
                        ((WeeklyTrigger)trigger).WeeksInterval = 1;
                        ((WeeklyTrigger)trigger).StartBoundary = DateTime.Today.Add(profile.WeeklyTime);
                        if (((WeeklyTrigger)trigger).StartBoundary < DateTime.Now && DateTime.Now.DayOfWeek == profile.WeeklyDay && td.Settings.StartWhenAvailable)
                        {
                            ((WeeklyTrigger)trigger).StartBoundary = ((WeeklyTrigger)trigger).StartBoundary.AddDays(7);
                            Logger.Log($"Thời gian hàng tuần đã qua, tác vụ sẽ bắt đầu vào tuần tới lúc {profile.WeeklyTime}.", _configuratorLogFilePath);
                        }
                        else if (((WeeklyTrigger)trigger).StartBoundary.DayOfWeek != profile.WeeklyDay)
                        {
                            int daysToAdd = (profile.WeeklyDay - DateTime.Today.DayOfWeek + 7) % 7;
                            ((WeeklyTrigger)trigger).StartBoundary = DateTime.Today.AddDays(daysToAdd).Add(profile.WeeklyTime);
                            Logger.Log($"Tác vụ hàng tuần sẽ bắt đầu vào {profile.WeeklyDay} lúc {profile.WeeklyTime}.", _configuratorLogFilePath);
                        }
                        Logger.Log($"Đã thêm lịch weekly: hàng tuần vào thứ {profile.WeeklyDay} lúc {profile.WeeklyTime}.", _configuratorLogFilePath);
                        break;
                    default:
                        throw new ArgumentException("Loại lịch không hợp lệ.");
                }

                td.Triggers.Add(trigger);

                // Register the task
                folder.RegisterTaskDefinition(taskName, td);
                Logger.Log($"Đã đăng ký tác vụ '{taskName}' thành công trong thư mục '{TaskFolderName}'.", _configuratorLogFilePath);
            }
        }
        catch (Exception ex)
        {
            Logger.Log($"Lỗi khi tạo/cập nhật tác vụ theo lịch '{profile.Name}': {ex.Message}\n{ex.StackTrace}", _configuratorLogFilePath);
            throw;
        }
    }

    /// <summary>
    /// Deletes a scheduled task associated with a backup profile.
    /// </summary>
    /// <param name="name">The name of the profile whose task should be deleted.</param>
    public static void DeleteBackupTask(string name)
    {
        try
        {
            using (TaskService ts = new TaskService())
            {
                TaskFolder folder = ts.GetFolder($"\\{TaskFolderName}");
                if (folder != null)
                {
                    string taskName = $"BackupTask_{name}";

                    // Replace the problematic line with the following code:
                    if (folder.Tasks.Any(task => task.Name.Equals(taskName, StringComparison.OrdinalIgnoreCase)))
                    {
                        folder.DeleteTask(taskName);
                        Logger.Log($"Đã xóa tác vụ theo lịch '{taskName}'.", _configuratorLogFilePath);
                    }
                    else
                    {
                        Logger.Log($"Không tìm thấy tác vụ theo lịch '{taskName}' để xóa.", _configuratorLogFilePath);
                    }
                }
                else
                {
                    Logger.Log($"Không tìm thấy thư mục tác vụ '\\{TaskFolderName}'.", _configuratorLogFilePath);
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Log($"Lỗi khi xóa tác vụ theo lịch cho profile name '{name}': {ex.Message}\n{ex.StackTrace}", _configuratorLogFilePath);
            throw;
        }
    }
}
