using TechTalk.SpecFlow;
using training.automation.common.utilities;
using training.automation.specflow.Application;
using System;
using training.automation.api.Utilities;
using OpenQA.Selenium;
using Random = training.automation.common.Utilities.Random;
using training.automation.common.Utilities;

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
                TestHelper.SleepInSeconds(1);

                if (DesktopWebsite.SpecificBoardsPage.AddACard.Exists())
                {
                    DesktopWebsite.SpecificBoardsPage.AddACard.Click();
                }

                DesktopWebsite.SpecificBoardsPage.EnterCardTitle.SendKeys(Random.RandomAlphanumericString(8));
                DesktopWebsite.SpecificBoardsPage.AddCard.Click();
            }
        }

        [Given]
        public void Given_I_add_P0_lists_and_P1_cards_to_each_list(int p0, int p1)
        {
            DesktopWebsite.BoardsPage.AssignUserBoard(RuntimeTestData.GetAsString("BoardName"));
            DesktopWebsite.BoardsPage.UserBoard.Click();
            TrelloAPIHelper.CreateLists(TrelloAPIHelper.GetTrelloBoardId(RuntimeTestData.GetAsString("BoardName")), p0);
            TrelloAPIHelper.CreateCards(p1, 1);
            TrelloAPIHelper.CreateCards(p1, 2);
            TrelloAPIHelper.CreateCards(p1, 3);
        }


        [When(@"I click and drag two cards from Done to Doing")]
        public void IClickAndDragTwoCardsFromDoneToDoing()
        {
            SeleniumHelper.DragAndDropAction(By.XPath("//*[@id=\"board\"]/div[3]/div/div[2]/a[2]/div[3]/span"), By.XPath("//*[@id=\"board\"]/div[2]/div/div[1]/div[1]"));
            SeleniumHelper.DragAndDropAction(By.XPath("//*[@id=\"board\"]/div[3]/div/div[2]/a[2]/div[3]/span"), By.XPath("//*[@id=\"board\"]/div[2]/div/div[1]/div[1]"));
        }

        [When(@"I click and drag two cards from To Do to Doing")]
        public void IClickAndDragTwoCardsFromToDoToDoing()
        {
            SeleniumHelper.DragAndDropAction(By.XPath("//*[@id=\"board\"]/div[1]/div/div[2]/a[1]/div[3]/span"), By.XPath("//*[@id=\"board\"]/div[2]/div/div[1]/div[1]"));
            SeleniumHelper.DragAndDropAction(By.XPath("//*[@id=\"board\"]/div[1]/div/div[2]/a[1]/div[3]/span"), By.XPath("//*[@id=\"board\"]/div[2]/div/div[1]/div[1]"));
        }

        [When(@"I create a new list called (.*)")]
        public void ICreateANewListCalled(string p0)
        {
            DesktopWebsite.SpecificBoardsPage.MoreSideMenu.WaitUntilExists();

            if (DesktopWebsite.SpecificBoardsPage.AddAList.Exists())
            {
                DesktopWebsite.SpecificBoardsPage.AddAList.Click();
            }

            DesktopWebsite.SpecificBoardsPage.EnterListTitle.SendKeys(p0);
            DesktopWebsite.SpecificBoardsPage.AddList.Click();
        }

            
        [Then(@"the three boards lists will be created")]
        public void TheThreeBoardsListsWillBeCreated()
        {
            int listLength = TrelloAPIHelper.GetListLength(TrelloAPIHelper.GetTrelloBoardId(RuntimeTestData.GetAsString("BoardName")));

            if (!listLength.Equals(3))
            {
                throw new Exception("The list length returned is not equal to 3. The three lists have not been created successfully.");
            }
        }

        [Then(@"the three lists will contain five cards each")]
        public void TheThreeListsWillContainFiveCardsEach()
        {
            int cardAmount = TrelloAPIHelper.GetNumOfCards(TrelloAPIHelper.GetTrelloBoardId(RuntimeTestData.GetAsString("BoardName")));

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
