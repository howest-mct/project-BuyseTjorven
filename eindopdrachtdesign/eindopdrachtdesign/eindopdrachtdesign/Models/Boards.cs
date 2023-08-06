using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace eindopdrachtdesign.Models
{
    public class GraphQlBoardsResponse
    {
        //[JsonProperty("data")]
        public Boards boards { get; set; }
    }
    public class Boards
    {
        public string name { get; set; }
    }
}
    