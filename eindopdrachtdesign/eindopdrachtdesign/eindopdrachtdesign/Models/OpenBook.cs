using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;


namespace eindopdrachtdesign.Models
{
    public class OpenBookDetail
    {
        [JsonProperty("title")]
        public String Title { get; set; }

        [JsonProperty("description")]
        public Object Description { get; set; }

        [JsonProperty("publishers")]
        public List<String> Publishers { get; set; }

    }
}
