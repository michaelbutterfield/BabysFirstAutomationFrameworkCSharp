using TechTalk.SpecFlow;
using training.automation.appium.Application;

namespace training.automation.appium.Test.StepDefinitions.Chrome
{
    [Binding]
    class NewTabSplashSteps
    {
        [Then(@"I will be on the new tab splash page")]
        public void IWillBeOnTheNewTabSplashPage()
        {
            MobileApp.NewTabSplashPage.Search.AssertExists();
        }



        [Given(@"I set up the chrome environment")]
        public void ISetUpTheChromeEnvironment()
        {
            WelcomeToChromeSteps.IAmOnTheWelcomeToChromePage();
            WelcomeToChromeSteps.IClickTheUsageAndCrashReportsTextbox();
            WelcomeToChromeSteps.IClickTheAcceptContinueButton();
            AccountLogInSteps.ICompleteTheAccountLoginPage();
            IWillBeOnTheNewTabSplashPage();
        }


    }
}
