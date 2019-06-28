using TechTalk.SpecFlow;

namespace training.automation.specflow.Test.CSharp.StepDefinitions
{
    using Application;

    [Binding]
    public sealed class SplashPageSteps
    {
        [Given]
        public void I_am_on_the_splash_page()
        {
            DesktopWebsite.SplashPage.LogIn.WaitUntilExists();
        }

        [When]
        public void I_click_the_log_in_button()
        {
            DesktopWebsite.SplashPage.LogIn.Click();
        }
    }
}
