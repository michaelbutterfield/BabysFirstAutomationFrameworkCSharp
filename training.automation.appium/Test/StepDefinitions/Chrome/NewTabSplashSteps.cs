using TechTalk.SpecFlow;
using training.automation.appium.Application;
using training.automation.common.Utilities;

namespace training.automation.appium.Test.StepDefinitions.Chrome
{
    [Binding]
    class NewTabSplashSteps
    {
        [Given(@"I am on the New Tab Splash Page")]
        public void IAmOnTheNewTabSplashPage()
        {
            MobileApp.NewTabSplashPage.Search.AssertExists();
        }

        [When(@"I search for (.*)")]
        public void ISearchFor(string p0)
        {
            MobileApp.NewTabSplashPage.Search.Click();
            MobileApp.NewTabSplashPage.UrlAddressBar.SendKeys(p0);
            AppiumHelper.GetDriver().na
        }

        [Given(@"I set up the chrome environment")]
        public void GivenISetUpTheChromeEnvironment()
        {
            WelcomeToChromeSteps.IAmOnTheWelcomeToChromePage();
            WelcomeToChromeSteps.IClickTheUsageAndCrashReportsTextbox();
            WelcomeToChromeSteps.IClickTheAcceptContinueButton();
            AccountLogInSteps.IWillBeOnTheAccountLoginPage();
        }


    }
}
