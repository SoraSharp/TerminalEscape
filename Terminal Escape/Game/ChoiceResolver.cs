using System;
using System.Collections.Generic;
using System.Text;
using Terminal_Escape.Services;

namespace Terminal_Escape.Game
{
    internal class ChoiceResolver
    {
        public static List<Choice> GetVisible(Room room, Inventory inventory)
        {
            return room.Choices.Where(c => c.GivesItemId == null || !inventory.Has(c.GivesItemId)).ToList();
        }
        
        public static string? Apply(Choice choice, Inventory inventory)
        {
            if (choice.RequiredItemId != null && !inventory.Has(choice.RequiredItemId))
            {
                Ui.Print(choice.LockedMessage ?? "You can't do this yet");
                Ui.Pause();
                return null;
            }

            if (choice.GivesItemId != null)
            {
                inventory.Add(choice.GivesItemId);
                Ui.Print($"You got {choice.GivesItemName}");
                Ui.Pause();
            }

            return choice.TargetRoomId;
        }
    }
}
