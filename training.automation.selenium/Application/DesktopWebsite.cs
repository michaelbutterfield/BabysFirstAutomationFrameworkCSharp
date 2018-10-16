using System;
using training.automation.selenium.Application.Pages;
using training.automation.selenium.Application.Sections;

namespace training.automation.selenium.Application
{
    public sealed class DesktopWebsite
    {
        public static BoardsPage boardsPage;
        public static CreateBoardPage createBoardPage;
        public static Header header;
        public static LogInPage logInPage;
        public static SpecificBoardsPage specificBoardsPage;
        public static SplashPage splashPage;

        static DesktopWebsite()
        {
            BuildPages();
            BuildSections();
        }

        private static void BuildPages()
        {
            boardsPage = new BoardsPage();
            createBoardPage = new CreateBoardPage();
            logInPage = new LogInPage();
            specificBoardsPage = new SpecificBoardsPage();
            splashPage = new SplashPage();
        }

        private static void BuildSections()
        {
            header = new Header();
        }
    }
}
