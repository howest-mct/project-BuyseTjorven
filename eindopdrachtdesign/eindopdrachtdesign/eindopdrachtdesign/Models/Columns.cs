using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace eindopdrachtdesign.Models
{
    public class GraphQlColumnsResponse
    {
        [JsonProperty("data")]
        public ColumnBoards data { get; set; }
    }
    public class ColumnBoards
    {
        [JsonProperty("boards")]
        public List<ColumnBoard> boards { get; set; }
    }
    public class ColumnBoard
    {
        [JsonProperty("items")]
        public List<ColumnItems> items { get; set; }
    }
    public class ColumnItems
    {
        [JsonProperty ("column_values")]
        public List<Column_value> values { get; set; }
    }
    public class Column_value
    {
        [JsonProperty("title")]
        public string title { get; set; }
    }
}
