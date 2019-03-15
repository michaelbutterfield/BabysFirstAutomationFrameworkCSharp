using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using training.automation.common.utilities;

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

                String[] lines = line.Split('\t');

                apiKey = lines[0];

                apiToken = lines[1];
            }
            catch (Exception e)
            {
                String errorMessage = String.Format("Could not read key and token from Trello API File");

                TestHelper.HandleException(errorMessage, e, false);
            }
        }
    }
}
