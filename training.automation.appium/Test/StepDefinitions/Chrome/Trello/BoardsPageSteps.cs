using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using training.automation.appium.Application;

namespace training.automation.appium.Test.StepDefinitions.Chrome.Trello
{
    [Binding]
    public class BoardsPageSteps
    {
        [Then(@"I will be logged in successfully")]
        public void IWillBeLoggedInSuccessfully()
        {
            MobileApp.TrelloBoardsPage.PersonalBoards.WaitUntilExists();
        }

    }
}
