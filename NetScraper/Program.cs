using HtmlAgilityPack;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace NetScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            GetHTMLAsync();
            

            Console.ReadKey();
        }

        private static async void GetHTMLAsync()
        {
            string url = "https://understat.com/league/Bundesliga";

            var httpClient = new HttpClient();
            var htmlDoc = new HtmlDocument();

            
            var html = await httpClient.GetStringAsync(url);

            htmlDoc.LoadHtml(html);

            // write html to File
        }
    }
}
