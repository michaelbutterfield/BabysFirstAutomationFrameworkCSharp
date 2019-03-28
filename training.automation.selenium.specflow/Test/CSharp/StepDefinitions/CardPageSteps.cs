using TechTalk.SpecFlow;
using training.automation.api.Utilities;
using training.automation.common.Utilities;
using training.automation.specflow.Application;

namespace training.automation.selenium.specflow.Test.CSharp.StepDefinitions
{
    [Binding]
    public class CardPageSteps
    {
        [When]
        public void When_I_add_P0_cards(int p0)
        {
            TrelloAPIHelper.CreateList(TrelloAPIHelper.GetTrelloBoardId(RuntimeTestData.GetAsString("BoardName")));
            TrelloAPIHelper.CreateCards(p0, 1);
        }


        [When]
        public void I_add_a_checklist()
        {
            DesktopWebsite.CardPage.Checklist.Click();
            DesktopWebsite.AddChecklist.ChecklistTitle.WaitUntilExists();

            string ChecklistTitle = RandomGen.RandomAlphabetString(10);
            RuntimeTestData.Add("ChecklistTitle", ChecklistTitle);

            DesktopWebsite.AddChecklist.ChecklistTitle.SendKeys(ChecklistTitle);
            DesktopWebsite.AddChecklist.Add.Click();
        }

        [When]
        public void I_add_a_checklist_item()
        {
            DesktopWebsite.CardPage.ChecklistItemTitle.WaitUntilExists();

            string ChecklistItemTitle = RandomGen.RandomAlphabetString(5);
            RuntimeTestData.Add("ChecklistItemTitle", ChecklistItemTitle);
            DesktopWebsite.CardPage.ChecklistItemTitle.SendKeys(ChecklistItemTitle);
            DesktopWebsite.CardPage.ChecklistItemAdd.Click();
        }

        [Then]
        public void the_checklist_will_be_added()
        {
            DesktopWebsite.CardPage.CreateChecklistHeader(RuntimeTestData.GetAsString("ChecklistTitle"));
            DesktopWebsite.CardPage.ChecklistHeader.AssertExists();
            DesktopWebsite.CardPage.CreateChecklistItem(RuntimeTestData.GetAsString("ChecklistItemTitle"));
            DesktopWebsite.CardPage.ChecklistItem.AssertExists();
        }
    }
}
