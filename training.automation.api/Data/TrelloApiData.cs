using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace training.automation.api.Data
{
    public class TrelloApiData
    {
        private static string apiKey;
        private static string apiToken;

        public static string GetApiKey() { return apiKey; }
        public static string GetApiToken() { return apiToken; }

        public static void ReadApiKeyToken()
        {
            var sourceFile = "C:\\Users\\michael.butterfield\\Desktop\\trello.txt";

            var line = System.IO.File.ReadAllText(@sourceFile);

            String[] lines = line.Split('\t');

            apiKey = lines[0];

            apiToken = lines[1];
        }
    }
}
