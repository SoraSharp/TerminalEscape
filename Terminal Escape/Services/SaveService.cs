using System.Text.Json;
using Terminal_Escape.Models;

namespace Terminal_Escape.Services
{
    public static class SaveService
    {
        private static readonly JsonSerializerOptions Options = new(){WriteIndented = true};
        private static string GetSavePath()
        {
            string folderPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Terminal Escape"
            );
            Directory.CreateDirectory(folderPath);
            return Path.Combine(folderPath, "save.json");
        }

        public static void SaveGame(GameData data)
        {
            string json = JsonSerializer.Serialize(data, Options);
            File.WriteAllText(GetSavePath(), json);
        }

        public static GameData Load()
        {
            string path = GetSavePath();
            if (!File.Exists(path))
            {
                return null;
            }
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<GameData>(json, Options) ?? new GameData();
        }

        public static void Delete()
        {
            string path = GetSavePath();
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
