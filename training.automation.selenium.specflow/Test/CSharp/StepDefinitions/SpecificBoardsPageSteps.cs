using TechTalk.SpecFlow;
using System;
using OpenQA.Selenium;
using NHamcrest;

namespace training.automation.specflow.Test.CSharp.StepDefinitions
{
    using Application;
    using common.Utilities;
    using common.Selenium.Elements;

    [Binding]
    public sealed class SpecificBoardsPageSteps
    {
        [When]
        public void I_add_P0_cards_to_the_new_list(int p0)
        {
            for (int i = 0; i < p0; i++)
            {
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
            string BoardName = RuntimeTestData.GetAsString("BoardName");
            Button userBoard = new Button(By.XPath($"//div[@title='{BoardName}']"), "User Created Board", "Boards Page");
            userBoard.Click();
            TrelloAPIHelper.CreateLists(TrelloAPIHelper.GetTrelloBoardId(RuntimeTestData.GetAsString("BoardName")), p0);

            for (int i = 1; i <= p0; i++)
            {
                TrelloAPIHelper.CreateCards(p1, i);
            }
        }

        [When]
        public void I_click_and_drag_two_cards_from_Done_to_Doing()
        {
            By StartLocation = By.XPath("//*[@id=\"board\"]/div[3]/div/div[2]/a[2]/div[3]/span");
            By EndLocation = By.XPath("//*[@id=\"board\"]/div[2]/div/div[1]/div[1]");
            SeleniumHelper.DragAndDropAction(StartLocation, EndLocation);
            SeleniumHelper.DragAndDropAction(StartLocation, EndLocation);
        }

        [When]
        public void I_click_and_drag_two_cards_from_To_Do_to_Doing()
        {
            By StartLocation = By.XPath("//*[@id=\"board\"]/div[1]/div/div[2]/a[1]/div[3]/span");
            By EndLocation = By.XPath("//*[@id=\"board\"]/div[2]/div/div[1]/div[1]");
            SeleniumHelper.DragAndDropAction(StartLocation, EndLocation);
            SeleniumHelper.DragAndDropAction(StartLocation, EndLocation);
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

        [When]
        public void I_create_a_new_list_called_P0(string p0)
        {
            DesktopWebsite.SpecificBoardsPage.MoreSideMenu.WaitUntilExists();

            if (DesktopWebsite.SpecificBoardsPage.AddAList.Exists())
            {
                DesktopWebsite.SpecificBoardsPage.AddAList.Click();
            }

            DesktopWebsite.SpecificBoardsPage.EnterListTitle.SendKeys(p0);
            DesktopWebsite.SpecificBoardsPage.AddList.Click();
        }

        [Then]
        public void the_cards_are_moved_successfully()
        {
            TestHelper.SleepInSeconds(2);

            int cards = TrelloAPIHelper.GetNumOfCardsOnAList(2);

            string StepDesc = string.Format("Assert total cards: {0} on list is equal to actual: {1}", cards, 9);

            TestHelper.AssertThat(cards, Is.EqualTo(9), StepDesc);
        }

        [Then]
        public void the_list_will_contain_five_cards()
        {
            int cardAmount = TrelloAPIHelper.GetNumOfCards(TrelloAPIHelper.GetTrelloBoardId(RuntimeTestData.GetAsString("BoardName")));

            if (!cardAmount.Equals(5))
            {
                throw new Exception("The amount of cards returned is not equal to 15. The 5 cards in each list have not been created correctly.");
            }
        }

        [Then]
        public void the_three_boards_lists_will_be_created()
        {
            int listLength = TrelloAPIHelper.GetListLength(TrelloAPIHelper.GetTrelloBoardId(RuntimeTestData.GetAsString("BoardName")));

            if (!listLength.Equals(3))
            {
                throw new Exception("The list length returned is not equal to 3. The three lists have not been created successfully.");
            }
        }
    }
}
