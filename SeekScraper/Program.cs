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
            string url = "https://www.seek.com.au/jobs-in-information-communication-technology?keywords=c%23&subclassification=6290%2C6291%2C6287%2C6302";

            ExtractSearchHref(url);

            // GetHTMLAsync();
            Console.ReadLine();

        }

        //public static async void GetHTMLAsync()
        //{
        //    //          https://www.seek.com.au/jobs-in-information-communication-technology?keywords=c%23&page=3&subclassification=6290%2C6291%2C6287%2C6302

        //    var url = @"https://www.seek.com.au/jobs-in-information-communication-technology?keywords=c%23&subclassification=6290%2C6291%2C6287%2C6302";


        //    // show all html on 'url' variable
        //    //var httpClient = new HttpClient();
        //    //var html = await httpClient.GetStringAsync(url);

        //    //var htmlDocument = new HtmlDocument();
        //    //htmlDocument.LoadHtml(html);

        //    // Console.WriteLine(html);


        //    // extract links from 'url' variable and print to console
        //    var linksList = ExtractSearchHref(url);
        //    foreach (var item in linksList)
        //    {
        //        pageResults(item);
        //    }

        //}



        // method for returning list of job links
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

        static void pageResults(string urlExt)
        {
            // declaring & loading dom
            HtmlWeb webJobPage = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc = webJobPage.Load("https://www.seek.com.au" + urlExt);

            Console.WriteLine(doc.Text.ToString());
            Console.ReadKey();
        }
    }
}
