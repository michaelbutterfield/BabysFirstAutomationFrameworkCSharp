using System;
using training.automation.common.utilities;

namespace training.automation.specflow.Data
{
    class TrelloWebData
    {
        private static String username;
        private static String password;

        public TrelloWebData() { }

        public static String GetUsername()
        {
            return username;
        }

        public static String GetPassword()
        {
            return password;
        }

        public static void ReadUserPass()
        {
            try
            {
                //string sourceFile = "C:\\Users\\michael.butterfield\\Desktop\\trellouserpass.txt";
                string sourceFile = "C:\\Users\\M\\Desktop\\trellouserpass.txt";

                string line = System.IO.File.ReadAllText(@sourceFile);

                String[] lines = line.Split('\t');

                username = lines[0];

                password = lines[1];
            }
            catch (Exception e)
            {
                String errorMessage = String.Format("Could not read username and password from file");

                TestHelper.HandleException(errorMessage, e, false);
            }
        }
    }
}
