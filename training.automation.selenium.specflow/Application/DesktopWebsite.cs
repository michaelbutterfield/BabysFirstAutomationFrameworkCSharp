using training.automation.selenium.specflow.Application.Pages;
using training.automation.selenium.specflow.Application.Pop_ups;
using training.automation.specflow.Application.Pages;
using training.automation.specflow.Application.Sections;

namespace training.automation.specflow.Application
{
    class DesktopWebsite
    {
        public static BoardsPage BoardsPage;
        public static CardPage CardPage;
        public static CreateBoardPage CreateBoardPage;
        public static Header Header;
        public static LogInPage LogInPage;
        public static SpecificBoardsPage SpecificBoardsPage;
        public static SplashPage SplashPage;

        static DesktopWebsite()
        {
            BuildPages();
            BuildSections();
        }

        private static void BuildPages()
        {
            BoardsPage = new BoardsPage();
            CardPage = new CardPage();
            CreateBoardPage = new CreateBoardPage();
            LogInPage = new LogInPage();
            SpecificBoardsPage = new SpecificBoardsPage();
            SplashPage = new SplashPage();
        }

        private static void BuildSections()
        {
            Header = new Header();
        }
    }
}
