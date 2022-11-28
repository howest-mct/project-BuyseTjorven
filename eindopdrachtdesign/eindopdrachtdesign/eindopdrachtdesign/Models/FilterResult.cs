using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace eindopdrachtdesign.Models
{
    public class FilterResult
    {
        [JsonProperty("name")]
        public string naam { get; set; }
        [JsonProperty("works")]
        public List<Work> works { get; set; }
    }
    public class Work
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("key")]
        public string Key { get; set; }
    }
}
