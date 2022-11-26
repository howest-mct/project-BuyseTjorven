using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        public static async Task<List<Works>> GetBooks()
        {
            string url = $"{_BASEURL}subjects/hate.json?limit=20";
            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string json = await client.GetStringAsync(url);
                    Debug.WriteLine(json);
                    FilterResult books = JsonConvert.DeserializeObject<FilterResult>(json);
                    //Console.WriteLine(books.naam);
                    //for(int i =0; i<books.works.Count(); i++)
                    //{
                    //    Console.WriteLine(books.works[i].Title);
                    //}
                    List<Works> test = new List<Works>();
                    test = books.works;
                    return test;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
        public static async Task<List<OpenBookDetail>> GetBook()
        {
            string url = $"{_BASEURL}isbn/9780140328721.json";
            using (HttpClient client = GetHttpClient())
            {
                try
                {
                    string json = await client.GetStringAsync(url);
                    List<OpenBookDetail> books = new List<OpenBookDetail>();
                    books.Add(JsonConvert.DeserializeObject<OpenBookDetail>(json));

                    return books;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
    }
}
