using System;
using System.Collections.Generic;
using System.Text;

namespace SeekScraper
{
    class cSharpSeekAd : seekAd
    {
        public bool dapperCount { get; set; }
        public bool mySqlCount { get; set; }
        public bool mvcCount { get; set; }
        public bool agileCount { get; set; }
        public bool yearsExpCount { get; set; }
        public bool entityCount { get; set; }
        public bool typeScriptCount { get; set; }
        public bool devOpsCount { get; set; }
        public bool dotNetCoreCount { get; set; }
        public bool azureCount { get; set; }
        public bool cloudCount { get; set; }
        public bool wpfCount { get; set; }
        public bool awsCount { get; set; }

        public void keywordCounter(string htmlString)
        {
            // not exactly sure how to loop through each keyword property with a heap of if else statements
            if (htmlString.Contains(KEYWORD_IN_HERE))
            {
                keyword = true;
            }


        }

    }
}
