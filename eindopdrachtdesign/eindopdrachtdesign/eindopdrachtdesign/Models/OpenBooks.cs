using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace eindopdrachtdesign.Models
{
    public class OpenBooks
    {
        [JsonProperty("name")]
        public string naam { get; set; }

    }
    public class Boeken
    {
        [JsonProperty("title")]
        public string title { get; set; }

    }
}
