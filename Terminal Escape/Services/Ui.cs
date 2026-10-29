namespace Terminal_Escape.Services
{
    internal class Ui
    {
        public static void Text(string text)
        {
            Console.WriteLine(text);
        }
        public static void Print(string text)
        {
            Console.WriteLine(text);
        }
        public static void Pouse()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
        public static string Ask(string prompt)
        {
            Console.WriteLine(prompt);
            return (Console.ReadLine() ?? "").Trim();
        } 
         
    }
}
