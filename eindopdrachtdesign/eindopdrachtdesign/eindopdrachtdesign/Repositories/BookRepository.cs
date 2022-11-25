using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using eindopdrachtdesign.Models;
using Newtonsoft.Json;

namespace eindopdrachtdesign.Repositories
{
    public static class BookRepository
    {
        public const string _BASEURL = "https://openlibrary.org/";
        public static HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
        public static async Task<OpenBook> GetBook()
        {
            string url = $"{_BASEURL}isbn/9780140328721.json";
            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string json = await client.GetStringAsync(url);
                    OpenBook book = JsonConvert.DeserializeObject<OpenBook>(json);

                    return book;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
    }
}
