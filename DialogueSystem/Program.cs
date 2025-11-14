namespace DialogueSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DialogueReader dialogue = new("nazar.json");
            dialogue.Debug();
        }
    }
}
