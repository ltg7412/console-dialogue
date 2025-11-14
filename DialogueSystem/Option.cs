using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DialogueSystem
{
    internal class Option
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("link")]
        public string Link { get; set; }
    }
}
