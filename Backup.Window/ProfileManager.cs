using Backup.Ultilities;
using Backup.Ultilities.Models;
using System.Text.Json;

namespace Backup.Window;

public static class ProfileManager
{
    // Use CommonApplicationData to ensure profiles.json is accessible by both applications
    // and persists across user sessions, suitable for shared configurations.
    private static readonly string _appDataFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log", "BackupSchedulerApp");
    private static readonly string _profilesFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "profiles.json");

    static ProfileManager()
    {
        // Ensure the application data directory exists
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
            Logger.Log($"Lỗi khi deserialize file cấu hình profiles.json: {ex.Message}", Path.Combine(_appDataFolder, "Configurator_ProfileManager_Log.txt")); // Pass log file path
            return new List<BackupProfile>();
        }
        catch (Exception ex)
        {
            Logger.Log($"Lỗi khi tải file profiles.json: {ex.Message}", Path.Combine(_appDataFolder, "Configurator_ProfileManager_Log.txt")); // Pass log file path
            return new List<BackupProfile>();
        }
    }

    /// <summary>
    /// Saves a list of backup profiles to the profiles.json file.
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