using System;

namespace training.automation.common.Utilities.Data
{
    public class TestRailUser
    {
        private static string username;
        private static string password;

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
                string SourceFile = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\\testrailuser.txt";

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
