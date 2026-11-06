namespace Terminal_Escape.Services
{
    public static class Ui
    {
        public static void Title(string text)
        {
            Console.WriteLine(text);
        }
        public static void Print(string text)
        {
            Console.WriteLine(text);
        }
        public static void Line(string? text = "")
        {
            Console.WriteLine(text);
        }
        public static void Clear()
        {
            Console.Clear();
        }
        public static void Pause(string? text)
        {
            Console.WriteLine(text);
            Console.ReadLine();
        }
        public static string Ask(string prompt)
        {
            Console.WriteLine(prompt);
            return (Console.ReadLine() ?? "").Trim();
        } 
         
    }
}
