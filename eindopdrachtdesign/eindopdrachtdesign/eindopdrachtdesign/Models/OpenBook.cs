using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;


namespace eindopdrachtdesign.Models
{
    public class OpenBookDetail
    {
        [JsonProperty("publish_date")]
        public string PublishDate { get; set; }

        [JsonProperty("publishers")]
        public List<String> Publishers { get; set; }

        [JsonProperty("title")]
        public String Title{ get; set; }

    }
}
