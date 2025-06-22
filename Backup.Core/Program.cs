using Backup.Ultilities;
using Backup.Ultilities.Models;
using BackupCore.Services;

class Program
{
    static async Task Main(string[] args)
    {
        Guid profileId = Guid.Empty;
        string workerLogFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log", "Worker_Fallback_log.txt");

        // Parse arguments
        if (args.Length > 1 && args[0].Equals("--profileId", StringComparison.OrdinalIgnoreCase))
        {
            if (Guid.TryParse(args[1], out Guid parsedId))
            {
                profileId = parsedId;
            }
        }

        if (profileId == Guid.Empty)
        {
            // Fallback for direct execution without profile ID, or error
            // In a real scenario, this might indicate a misconfiguration of the scheduled task.
            Logger.Log($"Không tìm thấy Profile ID được truyền vào. Không thể thực hiện sao lưu.", workerLogFilePath);
            Environment.Exit(1); // Exit with error
        }

        // Get the specific profile
        BackupProfile profile = ProfileManager.GetProfileById(profileId);

        if (profile == null)
        {
            Logger.Log($"Không tìm thấy profile với ID '{profileId}'. Không thể thực hiện sao lưu.", workerLogFilePath);
            Environment.Exit(1); // Exit with error
        }

        // Dynamically set log file path based on profile name or ID for better organization
        string workerLogFileName = $"Worker_Log_{profile.Name.Replace(" ", "_")}_{profile.Id.ToString().Substring(0, 8)}.txt";
        workerLogFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "BackupSchedulerApp", workerLogFileName);

        Logger.Log($"Backup Worker khởi động cho profile '{profile.Name}' (ID: {profile.Id}).", workerLogFilePath);
        Logger.Log($"Đang thực hiện sao lưu từ '{profile.SourcePath}' đến '{profile.DestinationPath}'.", workerLogFilePath);

        try
        {
            await BackupService.PerformBackup(profile.SourcePath, profile.DestinationPath, workerLogFilePath);
            Logger.Log($"Quá trình sao lưu cho profile '{profile.Name}' hoàn tất thành công.", workerLogFilePath);
            Environment.Exit(0); // Success
        }
        catch (Exception ex)
        {
            Logger.Log($"Lỗi nghiêm trọng khi sao lưu profile '{profile.Name}': {ex.Message}\n{ex.StackTrace}", workerLogFilePath);
            Environment.Exit(1); // Failure
        }
    }
}