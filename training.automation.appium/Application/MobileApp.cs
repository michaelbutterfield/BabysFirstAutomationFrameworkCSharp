using training.automation.appium.Application.Pages.Calculator;
using training.automation.appium.Application.Pages.Chrome;
using training.automation.appium.Application.Pages.Chrome.Trello;

namespace training.automation.appium.Application
{
    public class MobileApp
    {
        //App
        public static CalculatorPage CalculatorPage;

        //Chrome
        public static AccountLogInPage AccountLogInPage;
        public static NewTabSplashPage NewTabSplashPage;
        public static TrelloBoardsPage TrelloBoardsPage;
        public static TrelloLogInPage TrelloLogInPage;
        public static TrelloSplashPage TrelloSplashPage;
        public static WelcomeToChromePage WelcomeToChromePage;

        static MobileApp()
        {
            BuildPages();
        }

        private static void BuildPages()
        {
            //App
            CalculatorPage = new CalculatorPage();

            //Chrome
            AccountLogInPage = new AccountLogInPage();
            NewTabSplashPage = new NewTabSplashPage();
            TrelloBoardsPage = new TrelloBoardsPage();
            TrelloLogInPage = new TrelloLogInPage();
            TrelloSplashPage = new TrelloSplashPage();
            WelcomeToChromePage = new WelcomeToChromePage();

        }
    }
}
