using BackupSchedulerApp.Enums;
using Microsoft.Win32.TaskScheduler;

namespace BackupSchedulerApp;

internal class BackupSchedulerApp
{
    private const string TaskFolderName = "BackupSchedulerAppTasks"; // A subfolder for your tasks

    /// <summary>
    /// Creates or updates a Windows Scheduled Task to run the backup application.
    /// </summary>
    /// <param name="taskName">The name of the scheduled task.</param>
    /// <param name="appPath">The full path to the application executable.</param>
    /// <param name="scheduleType">The type of schedule (Hourly, Daily, Weekly).</param>
    /// <param name="hourlyInterval">Interval in hours for hourly schedule.</param>
    /// <param name="dailyTime">Time of day for daily schedule.</param>
    /// <param name="weeklyDay">Day of week for weekly schedule.</param>
    /// <param name="weeklyTime">Time of day for weekly schedule.</param>
    /// <param name="logFilePath">Path to the log file for logging task-related errors.</param>
    public static void CreateOrUpdateBackupTask(
        string taskName,
        string appPath,
        ScheduleType scheduleType,
        int hourlyInterval,
        TimeSpan dailyTime,
        DayOfWeek weeklyDay,
        TimeSpan weeklyTime,
        string logFilePath)
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
                    Logger.Log($"Đã tạo thư mục tác vụ: \\{TaskFolderName}", logFilePath);
                }

                // Fix for CS1061: Replace 'TaskExists' with LINQ-based check
                if (folder.Tasks.Any(task => task.Name.Equals(taskName, StringComparison.OrdinalIgnoreCase)))
                {
                    folder.DeleteTask(taskName);
                    Logger.Log($"Đã xóa tác vụ cũ: '{taskName}'.", logFilePath);
                }

                TaskDefinition td = ts.NewTask();

                // Task settings
                td.RegistrationInfo.Description = "Thực hiện sao lưu thư mục tự động theo lịch đã cấu hình bởi Backup Scheduler App.";
                td.Settings.Hidden = false; // Set to true if you want it completely hidden from Task Scheduler UI
                td.Settings.Enabled = true;
                td.Settings.StopIfGoingOnBatteries = false; // Allow running on battery
                td.Settings.DisallowStartIfOnBatteries = false;
                td.Settings.WakeToRun = true; // Wake computer to run task
                td.Settings.RunOnlyIfNetworkAvailable = false;
                td.Settings.StartWhenAvailable = true; // Run if missed
                td.Settings.AllowDemandStart = true;
                td.Settings.ExecutionTimeLimit = TimeSpan.FromHours(4); // Max run time
                td.Settings.Priority = System.Diagnostics.ProcessPriorityClass.Normal;
                td.Settings.MultipleInstances = TaskInstancesPolicy.IgnoreNew; // Ignore new instances if one is running

                // Action: Run the application with the --backup argument
                td.Actions.Add(new ExecAction(appPath, "--backup", null));
                Logger.Log($"Đã thêm hành động chạy ứng dụng: '{appPath}' với đối số '--backup'.", logFilePath);

                // Add Trigger based on schedule type
                Trigger trigger;
                switch (scheduleType)
                {
                    case ScheduleType.Hourly:
                        trigger = new TimeTrigger();
                        ((TimeTrigger)trigger).Repetition.Interval = TimeSpan.FromHours(hourlyInterval);
                        ((TimeTrigger)trigger).Repetition.Duration = TimeSpan.Zero; // Run indefinitely
                        ((TimeTrigger)trigger).StartBoundary = DateTime.Now.AddSeconds(30); // Start soon
                        Logger.Log($"Đã thêm lịch hourly: mỗi {hourlyInterval} giờ.", logFilePath);
                        break;
                    case ScheduleType.Daily:
                        trigger = new DailyTrigger();
                        ((DailyTrigger)trigger).DaysInterval = 1; // Every day
                        ((DailyTrigger)trigger).StartBoundary = DateTime.Today.Add(dailyTime);
                        // If the time is in the past today, schedule for tomorrow
                        if (td.Settings.StartWhenAvailable && ((DailyTrigger)trigger).StartBoundary < DateTime.Now)
                        {
                            ((DailyTrigger)trigger).StartBoundary = ((DailyTrigger)trigger).StartBoundary.AddDays(1);
                            Logger.Log($"Thời gian hàng ngày đã qua, tác vụ sẽ bắt đầu vào ngày mai lúc {dailyTime}.", logFilePath);
                        }
                        Logger.Log($"Đã thêm lịch daily: hàng ngày lúc {dailyTime}.", logFilePath);
                        break;
                    case ScheduleType.Weekly:
                        trigger = new WeeklyTrigger();
                        ((WeeklyTrigger)trigger).DaysOfWeek = (DaysOfTheWeek)(1 << (int)weeklyDay); // Convert DayOfWeek to DaysOfTheWeek enum
                        ((WeeklyTrigger)trigger).WeeksInterval = 1; // Every week
                        ((WeeklyTrigger)trigger).StartBoundary = DateTime.Today.Add(weeklyTime);
                        // If the time for the chosen day is in the past this week, schedule for next week
                        if (td.Settings.StartWhenAvailable && ((WeeklyTrigger)trigger).StartBoundary < DateTime.Now && DateTime.Now.DayOfWeek == weeklyDay)
                        {
                            ((WeeklyTrigger)trigger).StartBoundary = ((WeeklyTrigger)trigger).StartBoundary.AddDays(7);
                            Logger.Log($"Thời gian hàng tuần đã qua, tác vụ sẽ bắt đầu vào tuần tới lúc {weeklyTime}.", logFilePath);
                        }
                        else if (((WeeklyTrigger)trigger).StartBoundary.DayOfWeek != weeklyDay)
                        {
                            // Adjust to the next occurrence of the selected day
                            int daysToAdd = (weeklyDay - DateTime.Today.DayOfWeek + 7) % 7;
                            ((WeeklyTrigger)trigger).StartBoundary = DateTime.Today.AddDays(daysToAdd).Add(weeklyTime);
                            Logger.Log($"Tác vụ hàng tuần sẽ bắt đầu vào {weeklyDay} lúc {weeklyTime}.", logFilePath);
                        }
                        Logger.Log($"Đã thêm lịch weekly: hàng tuần vào thứ {weeklyDay} lúc {weeklyTime}.", logFilePath);
                        break;
                    default:
                        throw new ArgumentException("Loại lịch không hợp lệ.");
                }

                td.Triggers.Add(trigger);

                // Register the task
                folder.RegisterTaskDefinition(taskName, td);
                Logger.Log($"Đã đăng ký tác vụ '{taskName}' thành công trong thư mục '{TaskFolderName}'.", logFilePath);
            }
        }
        catch (Exception ex)
        {
            Logger.Log($"Lỗi khi tạo/cập nhật tác vụ theo lịch '{taskName}': {ex.Message}\n{ex.StackTrace}", logFilePath);
            throw; // Re-throw to be caught by UI
        }
    }
}
