using Terminal_Escape.Models;
using Terminal_Escape.Services;

namespace Terminal_Escape.Screens
{
    public static class MainMenu
    {
        public static MainMenuAction Show(GameData data)
        {
            while (true)
            {
                Ui.Clear();
                Ui.Title($"===TERMINAL ESCAPE=== (player: {data.PlayerName})");
                Ui.Line("");
                Ui.Line($"1. Select level");
                Ui.Line($"2. New game");
                Ui.Line($"3. Exit");
                string input = Ui.Ask("> ");
                switch( input )
                {
                    case "1":
                        return MainMenuAction.SelectedLevel;
                    case "2":
                        return MainMenuAction.NewGame;
                    case "3":
                        return MainMenuAction.Exit;
                    default:
                        continue;
                }
            }
        }
    }
}
