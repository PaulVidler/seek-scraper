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
            var url = @"https://www.seek.com.au/jobs-in-information-communication-technology?keywords=c%23&subclassification=6290%2C6291%2C6287%2C6302";
            var links = seekSearch.ExtractSearchHref(url);

            foreach (var link in links)
            {
                Console.WriteLine(searchResults.pageResults(link));
            }

        }

       
        
        

        
        
    }
}
