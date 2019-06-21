using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Xml;

namespace SeekScraper
{
    class Program
    {
        int dapperCount = 0;
        int mySqlCount = 0;
        int mvcCount = 0;
        int agileCount = 0;
        int yearsExpCount = 0;
        int entityCount = 0;
        int typeScriptCount = 0;
        int coreCount = 0;
        int devOpsCount = 0;
        int azureCount = 0;
        int cloudCount = 0;
        int wpfCount = 0;
        int awsCount = 0;
        



        static void Main(string[] args)
        {
            // method for returning list of job links
            // ExtractSearchHref(string URL)

            // method returns html content strings
            // static void pageResults(string urlExt)

            int scopingCount = 0;

            string url = "https://www.seek.com.au/jobs-in-information-communication-technology?keywords=c%23&subclassification=6290%2C6291%2C6287%2C6302";

            var linkList = ExtractSearchHref(url);


            foreach (var link in linkList)
            {
                // Console.WriteLine(pageResults(link));
                var result = pageResults(link);

                Console.WriteLine(pageResults(link));

                //if (result.Contains("scoping"))
                //{
                //    scopingCount++;
                //}

                //Console.WriteLine(scopingCount);
                Console.ReadKey();
            }

        }

       
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

        // method returns html content strings
        static string pageResults(string urlExt)
        {
            // declaring & loading dom
            HtmlWeb webJobPage = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc = webJobPage.Load("https://www.seek.com.au" + urlExt);

            // Console.WriteLine(doc.Text.ToString());
            return doc.Text.ToString();
        }
    }
}
