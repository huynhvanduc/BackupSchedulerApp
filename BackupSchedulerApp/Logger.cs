namespace BackupSchedulerApp;

public static class Logger
{
    private static readonly object _lock = new object();

    /// <summary>
    /// Logs a message with a timestamp to the specified log file.
    /// </summary>
    /// <param name="message">The message to log.</param>
    /// <param name="logFilePath">The full path to the log file.</param>
    public static void Log(string message, string logFilePath)
    {
        string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
        Console.WriteLine(logEntry); // Also output to console for debugging silent mode

        lock (_lock) // Ensure only one thread writes to the log file at a time
        {
            try
            {
                File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // If logging fails, output to console/debug output
                Console.Error.WriteLine($"Lỗi khi ghi vào tệp log '{logFilePath}': {ex.Message}");
            }
        }
    }
}
