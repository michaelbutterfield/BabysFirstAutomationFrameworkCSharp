using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using training.automation.common.utilities;
using training.automation.selenium.Application;
using NUnit.Framework;
using System;
using training.automation.selenium.Application.Data;
using Is = NHamcrest.Is;

namespace training.automation.selenium
{
    [TestClass]
    public class Tests
    {
        //**************************
        [OneTimeSetUp]
        public void Initialise()
        {
            //I set up the environment with password and email
            TrelloWebData.ReadUserPass();
            SeleniumHelper.Initialise("chrome");
            SeleniumHelper.GoToUrl("http://www.trello.com/login");
            DesktopWebsite.logInPage.createAnAccount.AssertElementIsDisplayed();
            DesktopWebsite.logInPage.emailAddress.InputText(TrelloWebData.getUsername());
            DesktopWebsite.logInPage.password.InputText(TrelloWebData.getPassword());
            DesktopWebsite.logInPage.logInButton.Click();
            DesktopWebsite.boardsPage.addButton.WaitForElementToBeClickable();

            string stepDescription = String.Format("Asserting actual: {0} is equal to expected {1}", SeleniumHelper.GetWebDriver().Title, "Boards | Trello");
            string expected = "Boards | Trello";
            TestHelper.AssertThat(SeleniumHelper.GetWebDriver().Title, Is.EqualTo(expected), stepDescription);

            //Click the add button in the top right
            DesktopWebsite.boardsPage.addButton.Click();

            //Click the create board option
            DesktopWebsite.boardsPage.createNewBoardButton.Click();

            //Create a new board with name and background
            DesktopWebsite.boardsPage.nameInput.InputText("TestBoard");
            DesktopWebsite.boardsPage.backgroundSelectionButton.Click();
            DesktopWebsite.boardsPage.createBoardButton.Click();

            //I Click back to home button
            Thread.Sleep(2000);
            DesktopWebsite.header.backToHome.JsClick();

            //I confirm the board is created
            Thread.Sleep(2000);
            DesktopWebsite.boardsPage.userBoardButton.AssertElementIsDisplayed();
        }

        //******************************
        [Test, Order(1)]
        public void FavouriteABoard()
        {
            //I am on the boards page
            if (!SeleniumHelper.GetWebDriver().Title.Equals("Boards | Trello"))
            {
                DesktopWebsite.header.backToHome.Click();
            }

            //I Click the favourite board star
            IWebElement userBoard = SeleniumHelper.GetWebDriver().FindElement(By.XPath("//div[(@title=\"TestBoard\")]"));
            Actions action = new Actions(SeleniumHelper.GetWebDriver());
            action.MoveToElement(userBoard).Perform();
            DesktopWebsite.boardsPage.favouriteButton.Click();
            TestHelper.WriteToConsole("Successfully hovered over the user board and Clicked favourite");
            Thread.Sleep(3000);

            //The board will be favourited
            Thread.Sleep(2000);

            String boardIsStarred = SeleniumHelper.GetWebDriver().FindElement(By.XPath("//*[@id=\"content\"]/div/div[2]/div/div/div/div/div[2]/div/div/div[1]/div/ul/li/a/div/div[2]/span/span")).GetAttribute("class");

            TestHelper.AssertThat(boardIsStarred, Is.EqualTo("icon-sm icon-star is-starred board-tile-options-star-icon"), "Assert that the board has been hovered over and the star clicked - making it a favourite board");
        }

        //*******************************
        [Test]
        public void AddingListsAndCards()
        {
            //i Click on the user created board
            DesktopWebsite.boardsPage.userBoardButton.Click();

            //I create three new lists
            DesktopWebsite.specificBoardsPage.addAList.Click();
            DesktopWebsite.specificBoardsPage.enterListTitle.InputText("To Do");
            DesktopWebsite.specificBoardsPage.addListButton.Click();
            DesktopWebsite.specificBoardsPage.addACard.Click();

            for (int i = 0; i < 5; i++)
            {
                String testText = String.Format("Test Text Placeholder {0}", i);
                DesktopWebsite.specificBoardsPage.enterCardTitle.InputText(testText);
                DesktopWebsite.specificBoardsPage.addCardButton.Click();
            }

            Console.WriteLine("Successfully created To Do and tasks 0-4");

            //Doing
            DesktopWebsite.specificBoardsPage.enterListTitle.InputText("Doing");
            DesktopWebsite.specificBoardsPage.addListButton.Click();
            DesktopWebsite.specificBoardsPage.addCardSecondCol.Click();

            Thread.Sleep(1000);

            for (int i = 5; i < 10; i++)
            {
                String testText = String.Format("Test Text Placeholder {0}", i);
                DesktopWebsite.specificBoardsPage.enterCardTitle.InputText(testText);
                DesktopWebsite.specificBoardsPage.addCardButton.Click();
            }

            Console.WriteLine("Successfully created 'Doing' and tasks 5-9");

            //Done
            DesktopWebsite.specificBoardsPage.enterListTitle.InputText("Done");
            DesktopWebsite.specificBoardsPage.addListButton.Click();
            DesktopWebsite.specificBoardsPage.addCardThirdCol.Click();

            Thread.Sleep(1000);

            for (int i = 10; i < 15; i++)
            {
                String testText = String.Format("Test Text Placeholder {0}", i);
                DesktopWebsite.specificBoardsPage.enterCardTitle.InputText(testText);
                DesktopWebsite.specificBoardsPage.addCardButton.Click();
            }

            Console.WriteLine("Successfully created Done and tasks 10-14");

            //I click the back to home button
            Thread.Sleep(2000);
            DesktopWebsite.header.backToHome.Click();
        }

        //***************************
        [Test]
        public void DragAndDropCardFromToDoToDoing()
        {
            //click the user board
            DesktopWebsite.boardsPage.userBoardButton.Click();

            //Move 0 to Doing
            IWebElement From = SeleniumHelper.GetWebDriver().FindElement(By.XPath("//*[@id=\"board\"]/div[1]/div/div[2]/a[1]/div[3]/span"));
            IWebElement To = SeleniumHelper.GetWebDriver().FindElement(By.XPath("//*[@id=\"board\"]/div[2]/div/div[1]/div[1]"));
            Actions act = new Actions(SeleniumHelper.GetWebDriver());
            act.DragAndDrop(From, To).Build().Perform();

            //Move 2 to Doing
            From = SeleniumHelper.GetWebDriver().FindElement(By.XPath("//*[@id=\"board\"]/div[1]/div/div[2]/a[2]/div[3]/span"));
            act.DragAndDrop(From, To).Build().Perform();

            From = SeleniumHelper.GetWebDriver().FindElement(By.XPath("//*[@id=\"board\"]/div[1]/div/div[2]/a[2]"));
            act.DragAndDrop(From, To).Build().Perform();

            //I click the back to home button
            Thread.Sleep(2000);
            DesktopWebsite.header.backToHome.Click();
        }

        //*****************************
        [Test]
        public void DragAndDropCardFromDoneToDoing()
        {
            //click the user board
            DesktopWebsite.boardsPage.userBoardButton.Click();

            //Move 0 to Doing
            IWebElement From = SeleniumHelper.GetWebDriver().FindElement(By.XPath("//*[@id=\"board\"]/div[3]/div/div[2]/a[2]/div[3]/span"));
            IWebElement To = SeleniumHelper.GetWebDriver().FindElement(By.XPath("//*[@id=\"board\"]/div[2]/div/div[1]/div[1]"));
            Actions act = new Actions(SeleniumHelper.GetWebDriver());
            act.DragAndDrop(From, To).Build().Perform();

            //Move 2 to Doing
            From = SeleniumHelper.GetWebDriver().FindElement(By.XPath("//*[@id=\"board\"]/div[3]/div/div[2]/a[2]/div[3]/span"));
            act.DragAndDrop(From, To).Build().Perform();

            From = SeleniumHelper.GetWebDriver().FindElement(By.XPath("//*[@id=\"board\"]/div[3]/div/div[2]/a[2]/div[3]/span"));
            act.DragAndDrop(From, To).Build().Perform();

            //I click the back to home button
            Thread.Sleep(2000);
            DesktopWebsite.header.backToHome.Click();
        }

        //**************************************
        [OneTimeTearDown]
        public void KillTests()
        {
            //delete the board

            //click home regardless of screen on
            DesktopWebsite.header.backToHome.JsClick();
            DesktopWebsite.boardsPage.userBoardButton.Click();
            DesktopWebsite.specificBoardsPage.moreSideMenuButton.Click();
            DesktopWebsite.specificBoardsPage.closeBoard.Click();
            DesktopWebsite.specificBoardsPage.closeBoardConfirmation.Click();
            DesktopWebsite.specificBoardsPage.permDeleteBoard.Click();
            DesktopWebsite.specificBoardsPage.permDeleteBoardConfirm.Click();
            DesktopWebsite.boardsPage.boardNotFound.AssertElementIsDisplayed();
            DesktopWebsite.header.trelloLogoHome.Click();

            //driver clean up
            SeleniumHelper.DestroyDriver();
        }
    }
}
