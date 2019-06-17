using TechTalk.SpecFlow;
using training.automation.appium.Application;

namespace training.automation.appium.Test.StepDefinitions.Chrome
{
    [Binding]
    public class AccountLogInSteps
    {
        [Then(@"I will be on the account login page")]
        public static void IWillBeOnTheAccountLoginPage()
        {
            MobileApp.AccountLogInPage.NoThanks.WaitUntilExists();
            MobileApp.AccountLogInPage.NoThanks.Click();
        }
    }
}
