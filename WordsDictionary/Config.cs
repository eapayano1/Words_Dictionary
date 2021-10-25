using System;
using System.Collections.Generic;
using System.Text;

namespace WordsDictionary
{
    public static class Config
    {
        private static string apiKey;

        public const string apiBaseAddress = "https://wordsapiv1.p.rapidapi.com/";
        public static string ApiKey
        {
            get { return apiKey = "YOUR API KEY"; }
           
        }

        public const string HomePage = "HomePage";  

        public const string NavigationPage = "NavigationPage";  


        public const string SearchPage = "SearchPage";  

        public const string SynonymsPage = "SynonymsPage";  

        public const string CategoryPage = "CategoryPage";  

    }
}
