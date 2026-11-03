using Terminal_Escape.Models;
using Terminal_Escape.Services;

var data = new GameData();

Console.WriteLine(ProgressService.GetStatus(data, 1));   // expected: [unlocked]
Console.WriteLine(ProgressService.GetStatus(data, 2));   // expected: [locked]

ProgressService.CompleteLevel(data, 1);
Console.WriteLine(ProgressService.GetStatus(data, 1));   // expected: [completed]
Console.WriteLine(ProgressService.GetStatus(data, 2));   // expected: [unlocked]
Console.WriteLine(ProgressService.GetStatus(data, 3));   // expected: [locked]

ProgressService.CompleteLevel(data, 3);                  // skip ahead
ProgressService.CompleteLevel(data, 1);                  // replay level 1
Console.WriteLine(data.UnlockedLevels);                  // expected: 4 (must NOT drop to 2)
Console.WriteLine(data.CompletedLevels.Count);           // expected: 2 (no duplicate of 1)

/*Level level = LevelLoader.Load()[0];

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
}*/