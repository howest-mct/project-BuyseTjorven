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
        public List<Works> works { get; set; }
    }
    public class Works
    {
        [JsonProperty("title")]
        public string Title { get; set; }

    }
}
