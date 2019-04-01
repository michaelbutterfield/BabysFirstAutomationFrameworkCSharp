using System;
using training.automation.common.Utilities;

namespace training.automation.specflow.Data
{
    class TrelloWebData
    {
        private static string username;
        private static string password;

        public TrelloWebData() { }

        public static string GetUsername()
        {
            return username;
        }

        public static string GetPassword()
        {
            return password;
        }

        public static void ReadUserPass()
        {
            try
            {
                string SourceFile = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\trellouserpass.txt";

                string line = System.IO.File.ReadAllText(@SourceFile);

                string[] lines = line.Split('\t');

                username = lines[0];

                password = lines[1];
            }
            catch (Exception e)
            {
                string errorMessage = string.Format("Could not read username and password from file");

                TestHelper.HandleException(errorMessage, e);
            }
        }
    }
}
