using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace SeekScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = @"https://www.seek.com.au/jobs-in-information-communication-technology?keywords=c%23&subclassification=6290%2C6291%2C6287%2C6302";

        //var links = seekSearch.ExtractSearchHref(url);

        //foreach (var link in links)
        //{
        //    Console.WriteLine(searchResults.pageResults(link));
        //}

        go:
            {
                try
                {
                    var main = MainAsync(url).GetAwaiter();
                    main.GetResult();
                }
                catch (HttpRequestException)
                {
                    Task.Delay(5000);
                    goto go;
                }
            }
        }


        public static async Task MainAsync(string lpUrl)
        {
            var jobs = await seekSearch.ExtractSearchResults(lpUrl);

            foreach (var job in jobs)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(job.Title);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(job.UrlString);

                Console.ResetColor();
            }
        }






    }
}
