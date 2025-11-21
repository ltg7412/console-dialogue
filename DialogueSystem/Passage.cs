using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DialogueSystem
{
    internal class Passage
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("options")]
        public Option[] Options { get; set; }

        internal Option[] GetOptions()
        {
            return Options;
        }
        internal string GetText()
        {
            return Text;
        }
    }
}
