namespace Backup.Ultilities;

public static class Logger
{
    private static readonly object _lock = new object();

    /// <summary>
    /// Ghi một thông báo có dấu thời gian vào tệp log được chỉ định.
    /// </summary>
    /// <param name="message">Thông báo cần ghi.</param>
    /// <param name="logFilePath">Đường dẫn đầy đủ đến tệp log.</param>
    public static void Log(string message, string logFilePath)
    {
        string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
        Console.WriteLine(logEntry); // Luôn xuất ra console để tiện gỡ lỗi (cho cả WinForms và Console)

        lock (_lock) // Đảm bảo chỉ một luồng ghi vào tệp log tại một thời điểm
        {
            try
            {
                // Đảm bảo thư mục cho tệp log tồn tại
                string logDir = Path.GetDirectoryName(logFilePath);
                if (!string.IsNullOrEmpty(logDir) && !Directory.Exists(logDir))
                {
                    Directory.CreateDirectory(logDir);
                }
                File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Lỗi khi ghi vào tệp log '{logFilePath}': {ex.Message}");
            }
        }
    }
}
