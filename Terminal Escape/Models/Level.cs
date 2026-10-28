public class Level
{
    public int Number { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string StartRoomId { get; set; } = "";
    public List<Room> Rooms { get; set; } = new();
}