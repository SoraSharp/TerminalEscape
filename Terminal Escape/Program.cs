Level level = LevelLoader.Load()[0];

string currentRoomId = level.StartRoomId;
var inventory = new List<string>();
while (true)
{
    Room room = level.Rooms.First(r => r.Id == currentRoomId);
    Console.Clear();
    Console.WriteLine($"--{room.Name}--");
    Console.WriteLine(room.Description);
    Console.WriteLine();

    if (room.IsExit)
    {
        Console.WriteLine("\n You escaped! Congrats!");
        Console.ReadKey();
        break;
    }

    var visibleChoices = room.Choices.Where(c => c.GivesItemId == null || !inventory.Contains(c.GivesItemId)).ToList();

    for (int i = 0; i < visibleChoices.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {visibleChoices[i].Text}");
    }

    Console.WriteLine("q. Quit");
    Console.Write("> ");
    string? input = Console.ReadLine();

    if (input == "q") break;

    if (int.TryParse(input, out int number) && number >= 1 && number <= visibleChoices.Count)
    {
        Choice choice = visibleChoices[number - 1];

        if (choice.RequiredItemId != null && !inventory.Contains(choice.RequiredItemId))
        {
            Console.WriteLine(choice.LockedMessage ?? "You can't do that yet.");
            Console.ReadKey();
        }
        else
        {
            if (choice.GivesItemId != null)
            {
                inventory.Add(choice.GivesItemId);
                Console.WriteLine($"You got {choice.GivesItemName}");
                Console.ReadKey();
            }
            if (choice.TargetRoomId != null)
            {
                currentRoomId = choice.TargetRoomId;
            }
        }
    }
}