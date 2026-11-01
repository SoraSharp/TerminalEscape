using Terminal_Escape.Services;
using Terminal_Escape.Models;

namespace Terminal_Escape.Game
{
    public static class RoomView
    {
        public static void Draw(Level level, Room room, List<Choice> choices)
        {
            Ui.Clear();
            Ui.Title($"=== {level.Number}: {level.Title} ===");
            Ui.Title($"-- {room.Name} --");
            Ui.Line("");
            Ui.Print(room.Description);
            if (room.IsExit)
            {
                return;
            }
            Ui.Print("");
            for(int i = 0; i < choices.Count; i++)
            {
                Ui.Line($"{i + 1}. {choices[i].Text}");
            }
            Ui.Line("");
            Ui.Line("i. inventory     m. Back to menu (resets all level progress)");
        }

        public static void ShowInventory(Inventory inventory)
        {
            Ui.Line("Inventory: ");
            Ui.Line(inventory.Items.Count>0?string.Join(", ", inventory.Items) : "(empty)");
            Ui.Pause("Press any key...");
        }
    }
}
