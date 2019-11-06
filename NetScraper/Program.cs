using HtmlAgilityPack;
using System;
using System.IO;
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

            var neededText = GetBetween(html, "teamsData ", ";");
            var correctUTFJSON = GetBetween(neededText, "'", "'");

            StreamWriter File = new StreamWriter("C://Users//Mark//Documents//angularCrawler//AngularCrawler//src//assets//data//data.txt");
            File.Write(correctUTFJSON);
            File.Close();
            htmlDoc.LoadHtml(html);

            // write html to File
        }

        public static string GetBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }
    }
}
