using Terminal_Escape.Models;
using Terminal_Escape.Services;


namespace Terminal_Escape.Screens
{
    public static class LevelSelectMenu
    {
        public static Level? LevelSelect(List<Level> levels, GameData data)
        {
            while (true)
            {
                Ui.Clear();
                Ui.Title("===SELECT LEVEL===");
                for (int i = 0; i < levels.Count; i++)
                {
                    Ui.Line($"{i + 1}. {levels[i].Title} {ProgressService.GetStatus(data, levels[i].Number)}");
                }
                Ui.Line("0. Back");
                string line = Ui.Ask("> ");
                if (!Int32.TryParse(line, out int number))
                {
                    continue;
                }
                if (number == 0)
                {
                    return null;
                }

                Level? selected = levels.FirstOrDefault(l => l.Number == number);

                if(selected == null || !ProgressService.IsUnlocked(data, selected.Number))
                {
                    Ui.Pause("this level has yet to be unlocked.");
                    continue; 
                }

                return selected;
            }
        }
    }
}
