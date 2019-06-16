using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Xml;

namespace SeekScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = @"https://www.seek.com.au/jobs?keywords=c%23";

            ExtractSearchHref(url);

            GetHTMLAsync();
            Console.ReadLine();

        }

        public static async void GetHTMLAsync()
        {
            var url = @"https://www.seek.com.au/jobs?keywords=c%23";

            var httpClient = new HttpClient();
            var html = await httpClient.GetStringAsync(url);

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            // Console.WriteLine(html);
        }

        static List<string> ExtractSearchHref(string URL)
        {
            // declaring & loading dom
            HtmlWeb web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc = web.Load(URL);

            List<string> links = new List<string>();


            // extracting all links
            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                HtmlAttribute att = link.Attributes["href"];
                var outer = link.OuterHtml.ToString();
                // extracting links that are returned in the result
                if (att.Value.Contains("a") && att.Value.Contains("/job/"))
                {
                    // add links to list
                    links.Add(att.Value);
                    // Console.WriteLine(att.Value);
                }
            }

            return links;
        }
    }
}
