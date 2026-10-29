using Terminal_Escape.Models;

namespace Terminal_Escape.Services
{
    internal class ProgressService
    {
        public static bool IsUnlocked(GameData data, int levelNumber) => levelNumber <= data.UnlockedLevels;
        public static bool IsCompleted(GameData data, int levelNumber) => data.CompletedLevels.Contains(levelNumber);
        public static string GameStatus(GameData data, int levelNumber) => IsCompleted(data, levelNumber) ? "[completed]" : IsUnlocked(data, levelNumber) ? "[unlocked]" : "[locked]";
        public static void CompleteLevel(GameData data, int levelNumber)
        {
            if (!IsCompleted(data, levelNumber))
            {
                data.CompletedLevels.Add(levelNumber);
            }

            data.UnlockedLevels = Math.Max(data.UnlockedLevels, levelNumber + 1);
        }
    }
}
