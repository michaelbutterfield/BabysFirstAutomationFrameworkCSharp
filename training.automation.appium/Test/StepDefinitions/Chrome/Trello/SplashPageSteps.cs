using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using training.automation.appium.Application;
using training.automation.common.Utilities;

namespace training.automation.appium.Test.StepDefinitions.Chrome.Trello
{
    [Binding]
    class SplashPageSteps
    {
        [Given(@"I am on the splash page")]
        public void IAmOnTheSplashPage()
        {
            AppiumHelper.GoToUrl("http://trello.com");
            MobileApp.TrelloSplashPage.Home.WaitUntilExists();
        }

        [When(@"I click the log in button")]
        public void IClickTheLogInButton()
        {
            MobileApp.TrelloSplashPage.LogIn.Click();
        }

    }
}
