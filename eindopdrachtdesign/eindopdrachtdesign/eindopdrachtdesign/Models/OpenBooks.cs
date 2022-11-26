using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace eindopdrachtdesign.Models
{
    public class OpenBooks
    {
        [JsonProperty("name")]
        public string naam { get; set; }
        [JsonProperty("works")]
        public List<Boeken> works { get; set; }
    }
    public class Boeken
    {
        [JsonProperty("title")]
        public string Title { get; set; }

    }
}
