using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeekScraper
{
    public class Seeker
    {
        const string JOBS_FOUND_PREDICATE = @"(?<=)(.*)(?=jobs found)";
        const string JOBS_URL_PREDICATER  = @"job.[0-9]{1,10}";
        public static bool JobResults(string lpSubject, out decimal prmJobs)
        {
            var result = Regex.Match(lpSubject, JOBS_FOUND_PREDICATE);
            prmJobs = 0;

            if (result.Success) {
                decimal.TryParse(result.Value, out prmJobs);
            }

            return result.Success;
        }

        public static bool TryGetJob(string lpSubject, out string prmJobUrl)
        {
            var result = Regex.Match(lpSubject, JOBS_URL_PREDICATER);
            prmJobUrl  = string.Empty;

            if (result.Success) {
                prmJobUrl = result.Value;
            }

            return result.Success;
        }
    }

    class seekSearch
    {
        //something like this bra
        static readonly Uri SEEK_BASE_URL = new Uri("https://www.seek.com.au");
        static readonly int DATE_IDX      = (4);

        public static int SearchResults;

        public static async Task<IEnumerable<seekAd>> ExtractSearchResults(string lpUrl)
        {
            var urls     = new Collection<seekAd>();
            var web      = new HtmlWeb();
            var document = await web.LoadFromWebAsync(lpUrl);

            foreach (var node in document.DocumentNode.Descendants("article"))
            {
                /* This gets us the number of search results */
                if (Seeker.JobResults(node.InnerText, out var jobCount)) {
                    SearchResults = (int)jobCount;
                }

                /* This gets us each Joband Url */
                if (Seeker.TryGetJob(node.InnerHtml, out var jobUrl)) {

                    var strtimeSpan = node.Descendants("span").ElementAt(DATE_IDX);
                    var title       = node.GetAttributeValue("aria-label", string.Empty);

                    if (strtimeSpan.InnerText != "Featured" && title != string.Empty)
                    {
                        urls.Add(new seekAd()
                        {
                            Title      = title, 
                            UrlString  = new Uri(SEEK_BASE_URL, jobUrl).AbsoluteUri,
                            ListedDate = DateFromSpanStr(strtimeSpan)
                        });
                    }
                }
            }

            return urls;
        }

        private static DateTime DateFromSpanStr(HtmlNode strtimeSpan)
        {

            return DateTime.UtcNow;
        }



        // method for returning list of job links
        public static List<string> ExtractSearchHref(string URL)
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
