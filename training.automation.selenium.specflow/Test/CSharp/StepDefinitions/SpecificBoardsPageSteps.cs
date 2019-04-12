using TechTalk.SpecFlow;
using training.automation.common.utilities;
using training.automation.specflow.Application;
using System;
using training.automation.api.Utilities;
using OpenQA.Selenium;
using RandomGen = training.automation.common.Utilities.RandomGen;
using training.automation.common.Utilities;
using training.automation.common.Selenium.Elements;
using NHamcrest;

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

                DesktopWebsite.SpecificBoardsPage.EnterCardTitle.SendKeys(RandomGen.RandomAlphanumericString(8));
                DesktopWebsite.SpecificBoardsPage.AddCard.Click();
            }
        }

        [Given]
        public void I_add_P0_lists_and_P1_cards_to_each_list(int p0, int p1)
        {
            DesktopWebsite.BoardsPage.AssignUserBoard(RuntimeTestData.GetAsString("BoardName"));
            DesktopWebsite.BoardsPage.UserBoard.Click();
            TrelloAPIHelper.CreateLists(TrelloAPIHelper.GetTrelloBoardId(RuntimeTestData.GetAsString("BoardName")), p0);

            for(int i = 1; i <= p0; i++)
            {
                TrelloAPIHelper.CreateCards(p1, i);
            }

            //TrelloAPIHelper.CreateCards(p1, 1);
            //TrelloAPIHelper.CreateCards(p1, 2);
            //TrelloAPIHelper.CreateCards(p1, 3);
        }


        [When(@"I click and drag two cards from Done to Doing")]
        public void IClickAndDragTwoCardsFromDoneToDoing()
        {
            By StartLocation = By.XPath("//*[@id=\"board\"]/div[3]/div/div[2]/a[2]/div[3]/span");
            By EndLocation = By.XPath("//*[@id=\"board\"]/div[2]/div/div[1]/div[1]");
            SeleniumHelper.DragAndDropAction(StartLocation, EndLocation);
            SeleniumHelper.DragAndDropAction(StartLocation, EndLocation);
        }

        [When(@"I click and drag two cards from To Do to Doing")]
        public void IClickAndDragTwoCardsFromToDoToDoing()
        {
            By StartLocation = By.XPath("//*[@id=\"board\"]/div[1]/div/div[2]/a[1]/div[3]/span");
            By EndLocation = By.XPath("//*[@id=\"board\"]/div[2]/div/div[1]/div[1]");
            SeleniumHelper.DragAndDropAction(StartLocation, EndLocation);
            SeleniumHelper.DragAndDropAction(StartLocation, EndLocation);
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

        [Then]
        public void the_cards_are_moved_successfully()
        {
            int cards = TrelloAPIHelper.GetNumOfCardsOnAList(2);

            string StepDesc = string.Format("Assert total cards: {0} on list is equal to actual: {1}", cards, 9);

            TestHelper.AssertThat(cards, Is.EqualTo(9), StepDesc);
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

        [Given]
        public void I_click_on_a_card()
        {
            DesktopWebsite.SpecificBoardsPage.MoreSideMenu.WaitUntilExists();
            string genericCardXpath = "//a[@class='list-card js-member-droppable ui-droppable']";
            int cardCount = SeleniumHelper.GetElements(By.XPath(genericCardXpath)).Count;
            string locator = string.Format(genericCardXpath + "[{0}]", RandomGen.RandomNumber(1, cardCount));
            SeleniumHelper.GetElement(By.XPath(locator)).Click();
        }
    }
}
