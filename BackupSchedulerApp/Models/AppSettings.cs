using BackupSchedulerApp.Enums;
using System.Text.Json;

namespace BackupSchedulerApp.Models;

internal class AppSettings
{
    public string SourcePath { get; set; } = string.Empty;
    public string DestinationPath { get; set; } = string.Empty;
    public ScheduleType ScheduleType { get; set; } = ScheduleType.Daily;
    public int HourlyInterval { get; set; } = 1; // Default to 1 hour
    public TimeSpan DailyTime { get; set; } = new TimeSpan(7, 0, 0); // Default to 7 AM
    public DayOfWeek WeeklyDay { get; set; } = DayOfWeek.Monday; // Default to Monday
    public TimeSpan WeeklyTime { get; set; } = new TimeSpan(10, 0, 0); // Default to 10 AM

    /// <summary>
    /// Saves the current settings to a JSON file.
    /// </summary>
    /// <param name="settings">The AppSettings object to save.</param>
    /// <param name="filePath">The path to the JSON file.</param>
    public static void Save(AppSettings settings, string filePath)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(settings, options);
        File.WriteAllText(filePath, jsonString);
    }

    /// <summary>
    /// Loads settings from a JSON file.
    /// </summary>
    /// <param name="filePath">The path to the JSON file.</param>
    /// <returns>The loaded AppSettings object, or null if the file does not exist or an error occurs.</returns>
    public static AppSettings? Load(string filePath)
    {
        if (!File.Exists(filePath))
        {
            return null;
        }

        try
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<AppSettings>(jsonString);
        }
        catch (JsonException ex)
        {
            // Log the JSON deserialization error but don't rethrow, return null instead.
            Console.Error.WriteLine($"Lỗi khi deserialize file cấu hình JSON: {ex.Message}");
            return null;
        }
        catch (Exception ex)
        {
            // Catch any other exceptions during file read/processing
            Console.Error.WriteLine($"Lỗi khi tải file cấu hình: {ex.Message}");
            return null;
        }
    }
}
