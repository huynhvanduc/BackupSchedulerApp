namespace BackupSchedulerApp.Services;

internal class BackupService
{
    /// <summary>
    /// Performs the backup operation from source to destination.
    /// Creates a new timestamped folder at the destination for each backup.
    /// </summary>
    /// <param name="sourcePath">The path to the source directory.</param>
    /// <param name="destinationPath">The path to the destination directory where backups will be stored.</param>
    /// <param name="logFilePath">The path to the log file.</param>
    public static async Task PerformBackup(string sourcePath, string destinationPath, string logFilePath)
    {
        if (!Directory.Exists(sourcePath))
        {
            throw new DirectoryNotFoundException($"Thư mục nguồn không tồn tại: '{sourcePath}'");
        }

        DirectoryInfo dirInfo = new DirectoryInfo(sourcePath);

        // Create a timestamped folder for the current backup
        string backupFolderName = dirInfo.Name + DateTime.Now.ToString("yyyy_MM_dd_HHmmss");
        string currentBackupDestination = Path.Combine(destinationPath, backupFolderName);

        Logger.Log($"Bắt đầu sao lưu từ '{sourcePath}' đến '{currentBackupDestination}'.", logFilePath);

        try
        {
            // Ensure the destination path exists
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
                Logger.Log($"Đã tạo thư mục đích: '{destinationPath}'.", logFilePath);
            }

            // Create the new backup directory
            Directory.CreateDirectory(currentBackupDestination);
            Logger.Log($"Đã tạo thư mục sao lưu mới: '{currentBackupDestination}'.", logFilePath);

            // Copy all files and subdirectories
            await CopyDirectory(sourcePath, currentBackupDestination, logFilePath);

            Logger.Log($"Sao lưu thành công đến '{currentBackupDestination}'.", logFilePath);
        }
        catch (Exception ex)
        {
            Logger.Log($"Lỗi khi sao lưu thư mục '{sourcePath}': {ex.Message}\n{ex.StackTrace}", logFilePath);
            throw new Exception($"Lỗi khi sao lưu: {ex.Message}", ex); // Re-throw to be caught by caller (UI or Program.cs)
        }
    }

    /// <summary>
    /// Recursively copies files and subdirectories from source to destination.
    /// </summary>
    private static async Task CopyDirectory(string sourceDir, string destinationDir, string logFilePath)
    {
        // Create all of the directories
        foreach (string dirPath in Directory.GetDirectories(sourceDir, "*", SearchOption.AllDirectories))
        {
            string targetDir = dirPath.Replace(sourceDir, destinationDir);
            Directory.CreateDirectory(targetDir);
            Logger.Log($"Đã tạo thư mục con: '{targetDir}'.", logFilePath);
        }

        // Copy all the files
        foreach (string newPath in Directory.GetFiles(sourceDir, "*.*", SearchOption.AllDirectories))
        {
            string targetPath = newPath.Replace(sourceDir, destinationDir);
            try
            {
                File.Copy(newPath, targetPath, true); // Overwrite if exists
                Logger.Log($"Đã sao chép tệp: '{newPath}' đến '{targetPath}'.", logFilePath);
            }
            catch (Exception ex)
            {
                Logger.Log($"Lỗi khi sao chép tệp '{newPath}' đến '{targetPath}': {ex.Message}", logFilePath);
                // Continue with other files even if one fails
            }
        }
        await Task.CompletedTask; // Mark as async method completion
    }
}
