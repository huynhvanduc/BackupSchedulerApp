using BackupSchedulerApp.Models;
using BackupSchedulerApp.Services;


namespace BackupSchedulerApp;

internal static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static async Task Main(string[] args)
    {
        // Set the current directory to the application's executable directory.
        // This ensures log.txt and config.json are created next to the .exe.
        Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

        string configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
        string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "backup_log.txt");

        if (args.Length > 0 && args[0].Equals("--backup", StringComparison.OrdinalIgnoreCase))
        {
            // Running in silent backup mode triggered by Scheduled Task
            try
            {
                Logger.Log("Ứng dụng khởi động ở chế độ sao lưu ẩn.", logFilePath);
                var settings = AppSettings.Load(configFilePath);
                if (settings != null)
                {
                    Logger.Log($"Đang thực hiện sao lưu từ '{settings.SourcePath}' đến '{settings.DestinationPath}'.", logFilePath);
                    await BackupService.PerformBackup(settings.SourcePath, settings.DestinationPath, logFilePath);
                    Logger.Log("Quá trình sao lưu ẩn hoàn tất.", logFilePath);
                }
                else
                {
                    Logger.Log("Không thể tải cấu hình cho chế độ sao lưu ẩn. Đảm bảo 'config.json' tồn tại và hợp lệ.", logFilePath);
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"Lỗi nghiêm trọng trong chế độ sao lưu ẩn: {ex.Message}\n{ex.StackTrace}", logFilePath);
            }
            finally
            {
                // Ensure the application exits immediately after silent backup
                Application.Exit();
            }
        }
        else
        {
            // Running in UI mode
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize(); // For .NET 6+
            Application.Run(new Form1());
        }
    }
}