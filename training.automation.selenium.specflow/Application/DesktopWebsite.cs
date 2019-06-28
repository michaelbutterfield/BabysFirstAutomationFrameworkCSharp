namespace training.automation.specflow.Application
{
    using Pages;

    class DesktopWebsite
    {
        public static BoardsPage BoardsPage { get; private set; }
        public static CreateBoardPage CreateBoardPage { get; private set; }
        public static LogInPage LogInPage { get; private set; }
        public static SpecificBoardsPage SpecificBoardsPage { get; private set; }
        public static SplashPage SplashPage { get; private set; }

        static DesktopWebsite()
        {
            BuildPages();
        }

        private static void BuildPages()
        {
            BoardsPage = new BoardsPage();
            CreateBoardPage = new CreateBoardPage();
            LogInPage = new LogInPage();
            SpecificBoardsPage = new SpecificBoardsPage();
            SplashPage = new SplashPage();
        }
    }
}
