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
            DesktopWebsite.SplashPage.LogIn.WaitUntilExists();
            DesktopWebsite.SplashPage.LogIn.AssertElementIsDisplayed();
        }
    }
}
