var room = new Room
{
    Id = "celar",
    Name = "Celar",
    Description = "You wake up in a dark celar."
};

room.Choices.Add(new Choice { Text = "Look around" });
room.Choices.Add(new Choice { Text = "Go to the corridor", TargetRoomId = "corridor" });

Console.WriteLine(room.Name);
Console.WriteLine(room.Description);

for (int i = 0; i < room.Choices.Count; i++)
{
    Console.WriteLine($"{i + 1}. {room.Choices[i].Text}");
}