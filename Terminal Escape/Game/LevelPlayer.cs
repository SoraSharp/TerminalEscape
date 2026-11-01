using Terminal_Escape.Models;
using Terminal_Escape.Services;

namespace Terminal_Escape.Game
{
    public static class LevelPlayer
    {
        public static bool Play(Level level)
        {
            Inventory inventory = new Inventory();
            string currentRoomId = level.StartRoomId;

            while (true)
            {
                Room? room = level.Rooms.FirstOrDefault(r => r.Id == currentRoomId);
                if (room == null)
                {
                    Ui.Pause($"Error: room '{currentRoomId}' does not exist in level {level.Number}.");
                    return false;
                }
                List<Choice> choices = ChoiceResolver.GetVisible(room, inventory);
                RoomView.Draw(level, room, choices);
                if (room.IsExit)
                {
                    Ui.Pause("Level complete! Press any key.. ");
                    return true;
                }
                string input = Ui.Ask("> ").ToLower();
                if (input == "m")
                {
                    return false;
                }
                else if (input == "i")
                {
                    RoomView.ShowInventory(inventory);
                    continue;
                }
                else if (int.TryParse(input, out int number) && number >= 1 && number <= choices.Count)
                {
                    string? nextRoomId = ChoiceResolver.Apply(choices[number - 1], inventory);
                    if (nextRoomId != null)
                    {
                        currentRoomId = nextRoomId;
                    }
                }
            }
        }
    }
}
