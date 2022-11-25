using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;


namespace eindopdrachtdesign.Models
{
    public class OpenBook
    {
        [JsonProperty("publish_date")]
        public string PublishDate { get; set; }

        [JsonProperty("publishers")]
        public List<String> Publishers { get; set; }

    }
}
