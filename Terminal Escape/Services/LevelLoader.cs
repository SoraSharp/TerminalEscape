using System.Text.Json;

public static class LevelLoader
{
	public static List<Level> Load()
	{
		string folder = Path.Combine(AppContext.BaseDirectory, "Data", "Levels");
		var levels = new List<Level>();

		foreach (string file in Directory.GetFiles(folder, "*.json"))
		{
			string json = File.ReadAllText(file);
			Level? level = JsonSerializer.Deserialize<Level>(json);

			if (level != null)
			{
				levels.Add(level);
			}
		}

		return levels.OrderBy(l => l.Number).ToList();
	}
}