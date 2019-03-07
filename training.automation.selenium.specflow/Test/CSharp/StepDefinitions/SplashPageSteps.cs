using TechTalk.SpecFlow;
using training.automation.common.utilities;
using training.automation.specflow.Application;
using training.automation.specflow.Data;

namespace training.automation.specflow.Test.CSharp.StepDefinitions
{
    [Binding]
    public sealed class SplashPageSteps
    {
        [Given(@"I am on the splash page")]
        public void IAmOnTheSplashPage()
        {
            SeleniumHelper.GetWebDriver().Navigate().GoToUrl("http://trello.com/");
            DesktopWebsite.SplashPage.LogIn.WaitUntilExists();
            DesktopWebsite.SplashPage.LogIn.AssertElementIsDisplayed();
        }

        [Given(@"I log in")]
        public void ILogIn()
        {
            DesktopWebsite.SplashPage.LogIn.Click();
            DesktopWebsite.LogInPage.ForgotPassword.WaitForElementToBeClickable();
            DesktopWebsite.LogInPage.EmailAddress.InputText(TrelloWebData.GetUsername());
            DesktopWebsite.LogInPage.Password.InputText(TrelloWebData.GetPassword());
            DesktopWebsite.LogInPage.LogIn.Click();
        }
    }
}
