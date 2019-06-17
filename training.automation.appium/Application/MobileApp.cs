using training.automation.appium.Application.Pages.Chrome;
using training.automation.appium.Application.Pages.Chrome.YouTube;

namespace training.automation.appium.Application
{
    public class MobileApp
    {
        public static AccountLogInPage AccountLogInPage;
        public static NewTabSplashPage NewTabSplashPage;
        public static WelcomeToChromePage WelcomeToChromePage;
        public static YTHomePage YTHomePage;


        static MobileApp()
        {
            BuildPages();
        }

        private static void BuildPages()
        {
            AccountLogInPage = new AccountLogInPage();
            NewTabSplashPage = new NewTabSplashPage();
            WelcomeToChromePage = new WelcomeToChromePage();
            YTHomePage = new YTHomePage();
        }
    }
}
