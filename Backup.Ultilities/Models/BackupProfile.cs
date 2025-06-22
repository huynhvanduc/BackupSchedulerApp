using Backup.Ultilities.Enums;

namespace Backup.Ultilities.Models;

public class BackupProfile
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = "Cấu hình mới";
    public string SourcePath { get; set; } = string.Empty;
    public string DestinationPath { get; set; } = string.Empty;
    public ScheduleType ScheduleType { get; set; } = ScheduleType.Daily;
    public int HourlyInterval { get; set; } = 1; // Default to 1 hour
    public TimeSpan DailyTime { get; set; } = new TimeSpan(7, 0, 0); // Default to 7 AM
    public DayOfWeek WeeklyDay { get; set; } = DayOfWeek.Monday; // Default to Monday
    public TimeSpan WeeklyTime { get; set; } = new TimeSpan(10, 0, 0); // Default to 10 AM

    // For display in ListBox (will be used by BackupConfigurator)
    public override string ToString()
    {
        return Name;
    }
}
