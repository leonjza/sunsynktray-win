using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;


namespace SunSynkTray
{
    [Serializable]
    internal class UserSettings
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string AuthToken { get; set; }
        public DateTime TokenExpiresAt { get; set; }
        public int? PlantId { get; set; }
        public string PlantName { get; set; }
    }

    internal static class SettingsManager
    {
        private static string settingsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SunSynkTray");
        private static string settingsLocation = Path.Combine(settingsPath, "settings.dat");

        public static void Save(UserSettings settings)
        {
            if (!Directory.Exists(settingsPath)) Directory.CreateDirectory(settingsPath);

            string asJson = JsonSerializer.Serialize(settings);
            byte[] asBytes = Encoding.UTF8.GetBytes(asJson);
            byte[] asEncryptedBytes = ProtectedData.Protect(asBytes, null, DataProtectionScope.CurrentUser);

            File.WriteAllBytes(settingsLocation, asEncryptedBytes);
        }

        public static UserSettings Load()
        {
            try
            {
                byte[] asEncryptedBytes = File.ReadAllBytes(settingsLocation);
                byte[] asBytes = ProtectedData.Unprotect(asEncryptedBytes, null, DataProtectionScope.CurrentUser);
                string asString = Encoding.UTF8.GetString(asBytes);

                return JsonSerializer.Deserialize<UserSettings>(asString);
            }
            catch (Exception)
            {
                // maybe the file does not exist, so just return a new instance
                return new UserSettings { };
            }
        }
    }
}
