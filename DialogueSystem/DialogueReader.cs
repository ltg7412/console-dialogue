using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DialogueSystem
{
    internal class DialogueReader
    {
        private Dialogue dialogue;
        private Passage currentPassage;
        internal DialogueReader(string filename)
        {
            string filePath = @$"Dialogue\{filename}";

            try
            {
                var options = new JsonSerializerOptions
                {
                    IncludeFields = true
                };
                string jsonString = File.ReadAllText(filePath);
                dialogue = JsonSerializer.Deserialize<Dialogue>(jsonString, options)!;
                Start();
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error reading Json File '{filePath}': {e.Message}");
            }
        }

        private void Start()
        {
            currentPassage = dialogue.GetStartingPassage();
            //currentPassageKey = dialogue.StartingPassageKey;
        }
        internal bool HasEnded()
        {
            return false;
        }
        internal string GetText()
        {
            return currentPassage.GetText();
        }
        internal Option[] GetOptions()
        {
            return currentPassage.GetOptions();
        }
        internal void ChooseOption(Option option)
        {
            currentPassage = dialogue.GetPassage(option.Link);
        }
        internal void ChooseOption(string link)
        {
            currentPassage = dialogue.GetPassage(link);
        }
        internal string GetName()
        {
            return dialogue.Name;
        }
        internal void Debug()
        {
            dialogue.Debug();
        }
        internal void PrintPassage()
        {
            Console.WriteLine($"{dialogue.Name}: {GetText()}");
        }
        internal void PromptOptions()
        {
            Option[] options = GetOptions();
            for (int i = 0; i < options.Length; i++)
            {
                Option option = options[i];
                Console.WriteLine($"{i+1}: {option.Text}");
            }
            Console.Write($"Choose 1-{options.Length}: ");
            int chosenOptionIndex = Utility.UserInputInt(1, options.Length)-1;
            ChooseOption(options[chosenOptionIndex]);
            Console.WriteLine();
        }
        internal void Next()
        {
            PrintPassage();
            PromptOptions();
        }
    }
}
