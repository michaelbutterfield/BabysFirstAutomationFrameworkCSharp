using TechTalk.SpecFlow;
using training.automation.appium.Application;
using training.automation.common.Utilities;

namespace training.automation.appium.Test.StepDefinitions.Chrome
{
    [Binding]
    class YouTubeSteps
    {
        [Given(@"I navigate to the YouTube website")]
        public void INavigateToTheYouTubeWebsite()
        {
            AppiumHelper.GoToUrl("www.youtube.com");
        }

        [Given(@"the search button is clickable")]
        public void TheSearchButtonIsClickable()
        {
            MobileApp.YTHomePage.Header.Search.AssertExists();
        }

        [When(@"I search '(.*)'")]
        public void ISearch(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"all of the responses will contain '(.*)'")]
        public void AllOfTheResponsesWillContain(string p0)
        {
            ScenarioContext.Current.Pending();
        }


    }
}
