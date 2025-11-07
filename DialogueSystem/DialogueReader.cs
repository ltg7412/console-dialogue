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
                string jsonString = File.ReadAllText(filePath);
                JsonSerializer.Deserialize<>(jsonString);
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error reading Json File '{filePath}': {e.Message}");
            }
        }
    }
}
