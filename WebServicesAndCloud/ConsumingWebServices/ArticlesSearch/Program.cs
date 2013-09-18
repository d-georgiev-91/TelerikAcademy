using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace ArticlesSearch
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient { BaseAddress = new Uri("http://api.feedzilla.com") };

        static void Main() 
        {
            Console.Write("Enter search string: ");
            string queryString = Console.ReadLine();
            Console.Write("Enter result count: ");
            int queryResultCount = int.Parse(Console.ReadLine());

            ArticlesCollection articles = GetArticles(queryString, queryResultCount);

            PrintArticles(articles);
        }
  
        private static void PrintArticles(ArticlesCollection articles)
        {
            if (articles.Count == 0)
            {
                Console.WriteLine("No result were found");
            }
            else
            {
                foreach (var article in articles)
                {
                    Console.WriteLine(article);
                }
            }
        }

        private static ArticlesCollection GetArticles(string queryString, int queryResultCount)
        {
            
            string serviceUrl = string.Format("v1/articles/search.json?q={0}&count={1}", queryString, queryResultCount);
            var articles = Get<ArticlesCollection>(serviceUrl);

            return articles;
        }

        public static T Get<T>(string serviceUrl, string mediaType = "application/json")
        {
            var request = new HttpRequestMessage();

            request.RequestUri = new Uri(client.BaseAddress + serviceUrl);
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mediaType));
            request.Method = HttpMethod.Get;

            var response = client.SendAsync(request).Result;

            var returnObj = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<T>(returnObj);
        }
    }
}