namespace DialogueSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DialogueReader reader = new("nazar.json");

            while (true)
            {
                reader.Next();
            }
        }
    }
}
