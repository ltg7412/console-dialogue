namespace DialogueSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            DialogueReader dialogue = new("nazar.json");
        }
    }
}
