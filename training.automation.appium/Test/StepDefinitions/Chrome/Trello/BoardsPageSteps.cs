using TechTalk.SpecFlow;
using training.automation.appium.Application;

namespace training.automation.appium.Test.StepDefinitions.Chrome.Trello
{
    [Binding]
    public class BoardsPageSteps
    {
        [Then]
        public void I_will_be_logged_in_successfully()
        {
            MobileApp.TrelloBoardsPage.PersonalBoards.WaitUntilExists();
        }
    }
}
