using TechTalk.SpecFlow;
using training.automation.common.utilities;
using training.automation.specflow.Application;
using training.automation.common.Utilities;
using System;
using training.automation.specflow.Application.Data;
using training.automation.api.Utilities;

namespace training.automation.specflow.Test.CSharp.StepDefinitions
{
    [Binding]
    public sealed class SpecificBoardsPageSteps
    {
        [When(@"I add five cards to the new list")]
        public void IAddFiveCardsToTheNewList()
        {
            for (int i = 0; i < 5; i++)
            {
                if (DesktopWebsite.SpecificBoardsPage.AddACard.Exists())
                {
                    DesktopWebsite.SpecificBoardsPage.AddACard.Click();
                    DesktopWebsite.SpecificBoardsPage.EnterCardTitle.InputText(RandomGen.RandomString(8));
                    DesktopWebsite.SpecificBoardsPage.AddCard.Click();
                }
                else
                {
                    DesktopWebsite.SpecificBoardsPage.EnterCardTitle.InputText(RandomGen.RandomString(8));
                    DesktopWebsite.SpecificBoardsPage.AddCard.Click();
                }
            }
        }

        [When(@"I click and drag two cards from Done to Doing")]
        public void IClickAndDragTwoCardsFromDoneToDoing()
        {
            SeleniumHelper.BuildAndPerformAction("donedoing");
            SeleniumHelper.BuildAndPerformAction("donedoing");
        }

        [When(@"I click and drag two cards from To Do to Doing")]
        public void IClickAndDragTwoCardsFromToDoToDoing()
        {
            SeleniumHelper.BuildAndPerformAction("tododoing");
            SeleniumHelper.BuildAndPerformAction("tododoing");
        }

        [When(@"I create a new list called (.*)")]
        public void ICreateANewListCalled(string p0)
        {
            if (DesktopWebsite.SpecificBoardsPage.AddAList.Exists())
            {
                DesktopWebsite.SpecificBoardsPage.AddAList.Click();
                DesktopWebsite.SpecificBoardsPage.EnterListTitle.InputText(p0);
                DesktopWebsite.SpecificBoardsPage.AddList.Click();
            }
            else
            {
                DesktopWebsite.SpecificBoardsPage.EnterListTitle.InputText(p0);
                DesktopWebsite.SpecificBoardsPage.AddList.Click();
            }
        }

            
        [Then(@"the three boards lists will be created")]
        public void TheThreeBoardsListsWillBeCreated()
        {
            int listLength = TrelloHelper.GetListLength(TrelloHelper.GetTrelloBoardId("TestBoard"));

            if (!listLength.Equals(3))
            {
                throw new Exception("The list length returned is not equal to 3. The three lists have not been created successfully.");
            }
        }

        [Then(@"the three lists will contain five cards each")]
        public void TheThreeListsWillContainFiveCardsEach()
        {
            int cardAmount = TrelloHelper.GetNumOfCards(TrelloHelper.GetTrelloBoardId("TestBoard"));

            if (!cardAmount.Equals(15))
            {
                throw new Exception("The amount of cards returned is not equal to 15. The 5 cards in each list have not been created correctly.");
            }
        }
        
        [Then(@"the '(.*)' cards are in '(.*)'")]
        public void TheCardsAreIn(string p0, string p1)
        {

        }
    }
}
