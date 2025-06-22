using Backup.Ultilities.Models;
using System.Text.Json;

namespace BackupCore.Services;

public static class ProfileManager
{
    private static readonly string _appDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "log", "BackupSchedulerApp");
    private static readonly string _profilesFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "profiles.json");

    static ProfileManager()
    {
        if (!Directory.Exists(_appDataFolder))
        {
            Directory.CreateDirectory(_appDataFolder);
        }
    }

    /// <summary>
    /// Loads a list of backup profiles from the profiles.json file.
    /// </summary>
    /// <returns>A list of BackupProfile objects, or an empty list if the file does not exist or an error occurs.</returns>
    public static List<BackupProfile> LoadProfiles()
    {
        if (!File.Exists(_profilesFilePath))
        {
            return new List<BackupProfile>();
        }

        try
        {
            string jsonString = File.ReadAllText(_profilesFilePath);
            var profiles = JsonSerializer.Deserialize<List<BackupProfile>>(jsonString);
            return profiles ?? new List<BackupProfile>();
        }
        catch (JsonException ex)
        {
            // In a real worker, you might log this to a general worker error log
            Console.Error.WriteLine($"Lỗi khi deserialize file cấu hình profiles.json (Worker): {ex.Message}");
            return new List<BackupProfile>();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Lỗi khi tải file profiles.json (Worker): {ex.Message}");
            return new List<BackupProfile>();
        }
    }

    /// <summary>
    /// Saves a list of backup profiles to the profiles.json file.
    /// (This method is primarily used by Configurator, but kept for completeness if needed in worker).
    /// </summary>
    /// <param name="profiles">The list of BackupProfile objects to save.</param>
    public static void SaveProfiles(List<BackupProfile> profiles)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(profiles, options);
        File.WriteAllText(_profilesFilePath, jsonString);
    }

    /// <summary>
    /// Gets a specific profile by its ID.
    /// </summary>
    /// <param name="profileId">The ID of the profile to retrieve.</param>
    /// <returns>The BackupProfile if found, otherwise null.</returns>
    public static BackupProfile GetProfileById(Guid profileId)
    {
        var profiles = LoadProfiles();
        return profiles.FirstOrDefault(p => p.Id == profileId);
    }
}
