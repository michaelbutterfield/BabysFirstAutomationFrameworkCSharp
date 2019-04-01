using System;
using training.automation.common.Utilities;

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
            try
            {
                string SourceFile = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\trello.txt";

                string line = System.IO.File.ReadAllText(@SourceFile);

                string[] lines = line.Split('\t');

                apiKey = lines[0];

                apiToken = lines[1];
            }
            catch (Exception e)
            {
                string errorMessage = string.Format("Could not read key and token from Trello API File");

                TestHelper.HandleException(errorMessage, e);
            }
        }
    }
}
