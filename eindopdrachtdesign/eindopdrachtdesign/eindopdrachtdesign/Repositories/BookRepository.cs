using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using GraphQL.Client;
using System.Text;
using System.Threading.Tasks;
using eindopdrachtdesign.Models;
using GraphQL.Client.Abstractions;
using GraphQL;
using Newtonsoft.Json;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using System.Net;
using System.IO;
using System.IO.Pipes;
using System.ComponentModel.Design;

namespace eindopdrachtdesign.Repositories
{
    public static class BookRepository
    {
        public const string _BASEURL = "https://api.monday.com/v2";
        public class MondayHelper
        {
            private const string MondayApiKey = "eyJhbGciOiJIUzI1NiJ9.eyJ0aWQiOjI2NjE2MzYxOCwiYWFpIjoxMSwidWlkIjo0NTIwMDIyMSwiaWFkIjoiMjAyMy0wNy0wMVQwODoyNjo1NS4wMDBaIiwicGVyIjoibWU6d3JpdGUiLCJhY3RpZCI6MTc2Mjk1NjYsInJnbiI6ImV1YzEifQ.w_ElgYIGXQZDomYCcfu0PL8z3WNjpCL4t9rESot9ai4";
            private const string MondayApiUrl = "https://api.monday.com/v2/";

            /// <summary>
            /// Get a JSON response from the Monday.com V2 API.
            /// </summary>
            /// <param name="query">GraphQL Query to apply to the Monday.com production instance for Grange.</param>
            /// <returns>JSON response of query results.</returns>
            /// <remarks>
            /// Query must be in JSON,
            ///		e.g. = "{\"query\": \"{boards(ids: 1234) {id name}}\"}"
            /// </remarks>
            public async Task<string> QueryMondayApiV2(string query)
            {
                byte[] dataBytes = System.Text.Encoding.UTF8.GetBytes(query);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(MondayApiUrl);
                request.ContentType = "application/json";
                request.Method = "POST";
                request.Headers.Add("Authorization", MondayApiKey);

                using (Stream requestBody = request.GetRequestStream())
                {
                    await requestBody.WriteAsync(dataBytes, 0, dataBytes.Length);
                }

                using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    return await reader.ReadToEndAsync();
                }
            }
        }

        public static async Task<GraphQlBoardsResponse> GetBoards()
        {
            var helper = new MondayHelper();
            string json = await helper.QueryMondayApiV2("{\"query\": \"{boards{id name}}\"}");
            //Console.WriteLine(json);
            Console.WriteLine("hiervoor de print");
            GraphQlBoardsResponse boards;

            if(json != null)
            {
                boards = JsonConvert.DeserializeObject<GraphQlBoardsResponse>(json);
                return boards;
            }
            else
            {
                return null;
            }

        }

        public static async Task<List<Item>> GetItemsAsync(string BoardId)
        {
            var helper = new MondayHelper();
            string json = await helper.QueryMondayApiV2($"{{\"query\": \"{{boards(ids: [{BoardId}]){{id name items{{name id}}}}}}\"}}");
            Console.WriteLine(json);
            GraphQlBoardsResponse response;

            if (json != null)
            {
                response = JsonConvert.DeserializeObject<GraphQlBoardsResponse>(json);
                List<Item> items = new List<Item>();
                items = response.data.board[0].items;
                return items;
            }
            else
            {
                return null;
            }
        }
        public static async Task<List<Column_value>> GetColumn_ValuesAsync(string BoardId, string ItemId)
        {
            var helper = new MondayHelper();
            Console.WriteLine(BoardId);
            Console.WriteLine(ItemId);
            string json = await helper.QueryMondayApiV2($"{{\"query\":\"query{{boards(ids: [{BoardId}]){{items(ids:{ItemId}){{column_values{{title id value text}}}}}}}}\"}}"); //nog aanpassen
            Console.WriteLine(json);
            Console.WriteLine("json geprint van colums");
            GraphQlColumnsResponse response;

            if (json != null)
            {
                response = JsonConvert.DeserializeObject<GraphQlColumnsResponse>(json);
                List<Column_value> items = new List<Column_value>();
                if(items != null)
                {
                    items = response.data.boards[0].items[0].values;  //index out of range error, ergens anders word wel geprint.
                    Console.WriteLine(items);
                    return items;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async static Task AddITemAsync(ColumnItems newcolumn, string BoardID)
        {
            //alle nodige info kan in newcolumn gevonden worden.

            //hier request met data van newcolumn ingevuld. Niet met json meesturen zoals in video want da ga nie.
            string boardId = BoardID;
            string newItem = newcolumn.name;
            string statusValue = "Ermee bezig"; //hier moeje dan into columnitems gaan en de juiste er uit halen.
            var helper = new MondayHelper();
            string json = await helper.QueryMondayApiV2($"{{\"query\": \"mutation {{create_item (board_id:{boardId}, group_id: \\\"topics\\\", item_name: \\\"{newItem}\\\", column_values: \\\"{{\\\\\\\"status\\\\\\\":\\\\\\\"{statusValue}\\\\\\\", \\\\\\\"text\\\\\\\":\\\\\\\"My Text\\\\\\\"}}\\\") {{id}}}}\"}}");
            Console.WriteLine(json);
            //GraphQlBoardsResponse response;

            if (json != null)
            {
                Console.WriteLine(json);
                //return items;
            }
            else
            {
                //return null;
            }

        }
        public async static Task UpdateITemAsync(ColumnItems item, string BoardID, Column_value value, string newvalue)
        {
            //alle nodige info kan in newcolumn gevonden worden.
            //boardID
            //itemID
            //column_value (de klasse)
            //hier request met data van newcolumn ingevuld. Niet met json meesturen zoals in video want da ga nie.
            string boardId = BoardID;
            string itemID = item.id;
            string columnId = value.id;
            string indexValue;
            string dateValue;
            string json;
            var helper = new MondayHelper();
            switch (value.id)
            {
                case "person":
                    json = await helper.QueryMondayApiV2($"mutation {{ change_column_value (board_id: {boardId}, item_id: {itemID}, column_id: \"{columnId}\", value: \"{{\\\"changed_at\\\":\\\"2023-08-08T09:11:56.714Z\\\",\\\"personsAndTeams\\\":[{{\\\"id\\\":45200221,\\\"kind\\\":\\\"person\\\"}}]}}\" ) {{ id }} }}");
                    Console.WriteLine(json);
                    break;
                case "status":
                    switch (newvalue)
                    {
                        case "Klaar":
                            indexValue = "1";
                            break;
                        case "Ermee bezig":
                            indexValue = "0";
                            break;
                        case "Vastgelopen":
                            indexValue = "2";
                            break;
                        default:
                            indexValue = "";
                            Console.WriteLine("iets mis met status text");
                            break;
                    }
                    json = await helper.QueryMondayApiV2($"mutation {{ change_column_value (board_id: {boardId}, item_id: {itemID}, column_id: \"{columnId}\", value: \"{{\\\"index\\\":{indexValue},\\\"post_id\\\":null,\\\"changed_at\\\":\\\"2018-07-30T06:27:07.264Z\\\"}}\" ) {{ id }} }}");
                    Console.WriteLine(json);
                    break;
                case "date":
                    dateValue = newvalue;
                    json = await helper.QueryMondayApiV2($"mutation {{ change_column_value (board_id: {boardId}, item_id: {itemID}, column_id: \"{columnId}\", value: \"{{\\\"date\\\":\\\"{dateValue}\\\",\\\"icon\\\":null,\\\"changed_at\\\":\\\"2023-08-07T09:41:51.344Z\\\"}}\" ) {{ id }} }}");
                    Console.WriteLine(json);
                    break;
                default:
                    json = null;
                    break;
            }
            //GraphQlBoardsResponse response;

            if (json != null)
            {
                Console.WriteLine(json);
                //return items;
            }
            else
            {
                //return null;
            }

        }
    }
}
