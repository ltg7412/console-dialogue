using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DialogueSystem
{
    internal class Dialogue
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("starting_passage")]
        public string StartingPassageKey { get; set; }

        [JsonPropertyName("passages")]
        public Dictionary<string, Passage> Passages { get; set; }

        internal Passage GetPassage(string key)
        {
            if (!Passages.ContainsKey(key))
            {
                throw new Exception($"Key '{key}' does not exist in passages");
            }
            return Passages[key];
        }
        internal Passage GetStartingPassage()
        {
            return GetPassage(StartingPassageKey);
        }
        internal void Debug()
        {
            Console.WriteLine(Name);
            Console.WriteLine(StartingPassageKey);
            Console.WriteLine(Passages[StartingPassageKey].Text);
        }
    }
}
