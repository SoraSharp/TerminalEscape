public class Choice
{
    public string Text { get; set; } = "";
    public string? TargetRoomId { get; set; }
    public string? RequiredItemId { get; set; }
    public string? GivesItemId { get; set; }
    public string? GivesItemName { get; set; }
    public string? LockedMessage { get; set; }
}

public class Room
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public bool IsExit { get; set; }
    public List<Choice> Choices { get; set; } = new();
}

public class Level
{
    public int Number { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string StartRoomId { get; set; } = "";
    public List<Room> Rooms { get; set; } = new();
}