Level level = BuildLevel();

string currentLevelId = level.StartRoomId;
while (true)
{
    Room room = level.Rooms.First(r => r.Id == currentLevelId);
    Console.Clear();
    Console.WriteLine($"--{room.Name}--");
    Console.WriteLine(room.Description);
    Console.WriteLine();

    for(int i = 0; i< room.Choices.Count; i++)
    {
        Console.WriteLine($"{i+1}. {room.Choices[i].Text}");
    }
    Console.WriteLine("q. Quit");
    Console.Write("> ");
    string? input = Console.ReadLine();

    if (input == "q") break;

    if (int.TryParse(input, out int number) && number >= 1 && number <= room.Choices.Count)
    {
        Choice choice = room.Choices[number - 1];

        if (choice.TargetRoomId != null)
        {
            currentLevelId = choice.TargetRoomId;
        }
    }
}
static Level BuildLevel()
{
    var celar = new Room()
    {
        Id = "celar",
        Name = "Celar",
        Description = "A dark celar. Two paths: \n-one leads to a even darker corridor, \n-one leads to a boiler room."
    };
    celar.Choices.AddRange(new List<Choice>{
        new Choice
        {
            Text = "Go down the corridor",
            TargetRoomId = "corridor"
        },
        new Choice
        {
            Text = "Go to the boiler room",
            TargetRoomId = "boilerroom"
        }
    });
    var corridor = new Room()
    {
        Id = "corridor",
        Name = "Corridor",
        Description = "It's to dark to see anything."
    };
    corridor.Choices.Add(new Choice
    {
        Text = "Go back.",
        TargetRoomId = "celar"
    });
    var boilerRoom = new Room()
    {
        Id = "boilerroom",
        Name = "Boiler Room",
        Description = "It's hot in here."
    };
    boilerRoom.Choices.Add(new Choice
    {
        Text = "Go back.",
        TargetRoomId = "celar"
    });
    var level = new Level
    {
        Number = 1,
        Title = "Locked cellar",
        Description = "Try getting out from the dark cellar.",
        StartRoomId = "celar"
    };
    level.Rooms.Add(celar);
    level.Rooms.Add(corridor);
    level.Rooms.Add(boilerRoom);
    return level;
}