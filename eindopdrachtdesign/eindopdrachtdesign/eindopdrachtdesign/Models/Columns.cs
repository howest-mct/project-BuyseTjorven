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
        public List<Board> boards { get; set; }
    }
    public class Board
    {
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("items")]
        public List<Item> items { get; set; }
    }
    public class Item
    {
        [JsonProperty ("column_values")]
        public List<Column_value> values { get; set; }
        [JsonProperty ("name")]
        public string name { get; set; }
        [JsonProperty("id")]
        public string id { get; set; }
    }
    public class Column_value
    {
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("id")]
        public string id { get; set; }
        [JsonProperty("text")]
        public string text { get; set; }
    }
}
