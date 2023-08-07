using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace eindopdrachtdesign.Models
{
    public class GraphQlBoardsResponse
    {
        [JsonProperty("data")]
        public Boards data { get; set; }
    }
    public class Boards
    {
        [JsonProperty("boards")]
        public List<Board> board { get; set; }
    }
    public class Board
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("items")]
        public List<Item> items { get; set; }

    }

    public class Item
    {
        [JsonProperty ("name")]
        public string name { get; set; }
    }

}
    