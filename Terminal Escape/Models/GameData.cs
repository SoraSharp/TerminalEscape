namespace Terminal_Escape.Models
{
    internal class GameData
    {
        public int Version { get; set; } = 1;
        public string PlayerName { get; set; }
        public int UnlockedLevels { get; set; }
        public List<int> CompletedLevels { get; set; }
    }
}
