using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeekScraper
{
    class searchResults
    {
        
        
        
        // method returns html content strings from one page. Given the 'url' extension which is taken from the search results
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
