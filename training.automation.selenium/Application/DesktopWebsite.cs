using System;
using training.automation.selenium.Application.Pages;
using training.automation.selenium.Application.Sections;

namespace training.automation.selenium.Application
{
    public sealed class DesktopWebsite
    {
        public static HomePage homePage;
        public static LogInPage logInPage;
        public static BoardsPage boardsPage;
        public static SpecificBoardsPage specificBoardsPage;
        public static Header header;

        static DesktopWebsite()
        {
            BuildPages();
            BuildSections();
        }

        private static void BuildPages()
        {
            homePage = new HomePage();
            logInPage = new LogInPage();
            boardsPage = new BoardsPage();
            specificBoardsPage = new SpecificBoardsPage();
        }

        private static void BuildSections()
        {
            header = new Header();
        }
    }
}
