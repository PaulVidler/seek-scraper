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
            // method for returning list of job links
            // ExtractSearchHref(string URL)

            // method returns html content strings
            // static void pageResults(string urlExt)

            string url = "https://www.seek.com.au/jobs-in-information-communication-technology?keywords=c%23&subclassification=6290%2C6291%2C6287%2C6302";

            var linkList = ExtractSearchHref(url);


            foreach (var link in linkList)
            {
                // Console.WriteLine(pageResults(link));
                var result = pageResults(link);

                Console.WriteLine(pageResults(link));

                
                Console.ReadKey();
            }

        }

       
        
        

        
        
    }
}
