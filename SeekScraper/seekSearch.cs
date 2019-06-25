using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeekScraper
{
    class seekSearch
    {
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


    }
}
