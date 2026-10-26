public class Choice
{
    public string Text { get; set; } = "";
    public string? TargetRoomId { get; set; }
    public Action? Action { get; set; }
}

public class Room
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public List<Choice> Choices { get; set; } = new();
}

public class Level
{
    public int Number { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public List<Room> Rooms = new();
}