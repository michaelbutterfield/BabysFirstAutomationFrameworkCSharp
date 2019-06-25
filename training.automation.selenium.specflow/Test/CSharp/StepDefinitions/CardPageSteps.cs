using TechTalk.SpecFlow;
using training.automation.common.Utilities;


namespace training.automation.selenium.specflow.Test.CSharp.StepDefinitions
{
    using training.automation.specflow.Application;
    
    [Binding]
    public class CardPageSteps
    {
        [When]
        public void I_add_P0_cards(int p0)
        {
            TrelloAPIHelper.CreateList(TrelloAPIHelper.GetTrelloBoardId(RuntimeTestData.GetAsString("BoardName")));
            TrelloAPIHelper.CreateCards(p0, 1);
        }


        [When]
        public void I_add_a_checklist()
        {
            DesktopWebsite.SpecificBoardsPage.CardPage.Checklist.Click();
            DesktopWebsite.SpecificBoardsPage.CardPage.AddChecklist.ChecklistTitle.WaitUntilExists();

            string ChecklistTitle = RandomGen.RandomAlphabetString(10);
            RuntimeTestData.Add("ChecklistTitle", ChecklistTitle);

            DesktopWebsite.SpecificBoardsPage.CardPage.AddChecklist.ChecklistTitle.SendKeys(ChecklistTitle);
            DesktopWebsite.SpecificBoardsPage.CardPage.AddChecklist.Add.Click();
        }

        [When]
        public void I_add_a_checklist_item()
        {
            DesktopWebsite.SpecificBoardsPage.CardPage.ChecklistItemTitle.WaitUntilExists();

            string ChecklistItemTitle = RandomGen.RandomAlphabetString(5);
            RuntimeTestData.Add("ChecklistItemTitle", ChecklistItemTitle);
            DesktopWebsite.SpecificBoardsPage.CardPage.ChecklistItemTitle.SendKeys(ChecklistItemTitle);
            DesktopWebsite.SpecificBoardsPage.CardPage.ChecklistItemAdd.Click();
        }

        [Then]
        public void the_checklist_will_be_added()
        {
            DesktopWebsite.SpecificBoardsPage.CardPage.CreateChecklistHeader(RuntimeTestData.GetAsString("ChecklistTitle"));
            DesktopWebsite.SpecificBoardsPage.CardPage.ChecklistHeader.AssertExists();
            DesktopWebsite.SpecificBoardsPage.CardPage.CreateChecklistItem(RuntimeTestData.GetAsString("ChecklistItemTitle"));
            DesktopWebsite.SpecificBoardsPage.CardPage.ChecklistItem.AssertExists();
        }
    }
}
