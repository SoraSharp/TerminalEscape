public class Room
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public bool IsExit { get; set; }
    public List<Choice> Choices { get; set; } = new();
}
