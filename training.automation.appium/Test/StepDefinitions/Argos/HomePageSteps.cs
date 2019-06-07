using TechTalk.SpecFlow;
using training.automation.appium.Application;

namespace training.automation.appium.Test.StepDefinitions.Argos
{
    [Binding]
    public class HomePageSteps
    {
        [Given]
        public void I_try_and_click_the_search_button()
        {
            MobileApp.HomePage.Header.Search.Click();
        }

    }
}
