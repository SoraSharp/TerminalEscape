Level level = BuildLevel();

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

static Level BuildLevel()
{
    var cellar = new Room()
    {
        Id = "cellar",
        Name = "Cellar",
        Description = "A dark cellar. Two paths: \n-one leads to a even darker corridor, \n-one leads to a boiler room."
    };
    cellar.Choices.AddRange(new List<Choice>{
        new Choice
        {
            Text = "Go down the corridor",
            TargetRoomId = "corridor",
            RequiredItemId = "flashlight",
            LockedMessage = "It's too dark to see anything without a light source."
        },
        new Choice
        {
            Text = "Go to the boiler room",
            TargetRoomId = "boilerroom"
        },
        new Choice
        {
            Text = "Take flashlight",
            GivesItemId = "flashlight",
            GivesItemName = "a flashlight"
        }
        
    });
    var corridor = new Room()
    {
        Id = "corridor",
        Name = "Corridor",
        Description = "Despite its best effort the flashlight didn't light up the place very well. \nYou can bearly see the light bouncing off of something metalic."
    };
    corridor.Choices.AddRange(new List<Choice>
    {
        new Choice
        {
            Text = "Go back.",
            TargetRoomId = "cellar"
        },
        new Choice
        {
            Text = "Go to the reflection.",
            TargetRoomId = "exitdoor"
        }
    });
    var boilerRoom = new Room()
    {
        Id = "boilerroom",
        Name = "Boiler Room",
        Description = "It's hot in here."
    };
    boilerRoom.Choices.AddRange(new List<Choice>
    {
        new Choice
        {
            Text = "Go back.",
            TargetRoomId = "cellar"
        },
        new Choice
        {
            Text = "Grab the key.",
            GivesItemId = "key",
            GivesItemName = "a rusty key"
        }
    });
    var exitDoor = new Room()
    {
        Id = "exitdoor",
        Name = "Exit Door",
        Description = "A locked door. You need a key to open it.",
    };
    exitDoor.Choices.AddRange(new List<Choice>
    {
        new Choice
        {
            Text = "Go back",
            TargetRoomId = "corridor"
        },
        new Choice
        {
            Text = "Use the key to open the door.",
            TargetRoomId = "exit",
            RequiredItemId = "key",
            LockedMessage = "You need a key to open this door."
        }

    });
    var exit = new Room()
    {
        Id = "exit",
        Name = "",
        Description = "",
        IsExit = true
    };
    var level = new Level
    {
        Number = 1,
        Title = "Locked cellar",
        Description = "Try getting out from the dark cellar.",
        StartRoomId = "cellar"
    };
    level.Rooms.AddRange(new List<Room>{
        cellar,
        corridor,
        boilerRoom,
        exitDoor,
        exit
    });
    return level;
}