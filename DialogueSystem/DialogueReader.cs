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
        Dialogue dialogue;
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
                dialogue = JsonSerializer.Deserialize<Dialogue>(jsonString, options);
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error reading Json File '{filePath}': {e.Message}");
            }
        }

        internal void Debug()
        {
            dialogue.Debug();
        }
    }
}
