using System;
using System.Collections.Generic;
using System.Text;

namespace SeekScraper
{
    class cSharpSeekAd : SeekAd
    {
        public bool DapperCount { get; set; }
        public bool MySqlCount { get; set; }
        public bool MvcCount { get; set; }
        public bool AgileCount { get; set; }
        public bool YearsExpCount { get; set; }
        public bool EntityCount { get; set; }
        public bool TypeScriptCount { get; set; }
        public bool DevOpsCount { get; set; }
        public bool DotNetCoreCount { get; set; }
        public bool AzureCount { get; set; }
        public bool CloudCount { get; set; }
        public bool WpfCount { get; set; }
        public bool AwsCount { get; set; }

        public void keywordCounter(string htmlString)
        {
            // not exactly sure how to loop through each keyword property with a heap of if else statements
            //if (htmlString.Contains(KEYWORD_IN_HERE))
            //{
            //    keyword = true;
            //}


        }

    }
}
