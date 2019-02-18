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
using training.automation.common.Tests;
using TestContext = NUnit.Framework.TestContext;

namespace training.automation.selenium
{
    [TestClass]
    public class Tests
    {
        //**************************
        [OneTimeSetUp]
        public void Initialise()
        {
            TestLogger.Initialise();

            TestLogger.LogSuiteSetupStart();

            //I set up the environment with password and email
            TrelloWebData.ReadUserPass();
            SeleniumHelper.Initialise("chrome");
            DesktopWebsite.splashPage.logIn.Click();
            //DesktopWebsite.logInPage.createAnAccount.AssertElementIsDisplayed();
            DesktopWebsite.logInPage.emailAddress.InputText(TrelloWebData.GetUsername());
            DesktopWebsite.logInPage.password.InputText(TrelloWebData.GetPassword());
            DesktopWebsite.logInPage.logIn.Click();
            DesktopWebsite.header.add.WaitForElementToBeClickable();

            string stepDescription = String.Format("Asserting actual: {0} is equal to expected {1}", SeleniumHelper.GetWebDriver().Title, "Boards | Trello");
            string expected = "Boards | Trello";
            TestHelper.AssertThat(SeleniumHelper.GetWebDriver().Title, Is.EqualTo(expected), stepDescription);

            //Click the add button in the top right
            DesktopWebsite.header.add.Click();

            //Click the create board option
            DesktopWebsite.boardsPage.createNewBoard.Click();

            //Create a new board with name and background
            DesktopWebsite.createBoardPage.nameInput.InputText("TestBoard");
            //DesktopWebsite.createBoardPage.backgroundSelectionButton.Click();
            DesktopWebsite.createBoardPage.createBoard.Click();

            //I Click back to home button
            Thread.Sleep(2000);
            DesktopWebsite.header.backToHome.JsClick();

            //I confirm the board is created
            Thread.Sleep(2000);
            DesktopWebsite.boardsPage.userBoard.AssertElementIsDisplayed();

            TestLogger.LogSuiteSetupEnd();
        }

        //******************************
        [Test, Order(1)]
        public void FavouriteABoard()
        {
            TestLogger.LogScenarioStart();

            //I am on the boards page
            if (!SeleniumHelper.GetWebDriver().Title.Equals("Boards | Trello"))
            {
                DesktopWebsite.header.backToHome.Click();
            }

            //I Click the favourite board star
            IWebElement userBoard = SeleniumHelper.GetWebDriver().FindElement(By.XPath("//div[(@title=\"TestBoard\")]"));
            Actions action = new Actions(SeleniumHelper.GetWebDriver());
            action.MoveToElement(userBoard).Perform();
            DesktopWebsite.boardsPage.favourite.Click();
            TestHelper.WriteToConsole("Successfully hovered over the user board and Clicked favourite");
            Thread.Sleep(3000);

            //The board will be favourited
            Thread.Sleep(2000);

            String boardIsStarred = SeleniumHelper.GetWebDriver().FindElement(By.XPath("//*[@id=\"content\"]//span[@class=\"icon-sm icon-star is-starred board-tile-options-star-icon\"]")).GetAttribute("class");

            TestHelper.AssertThat(boardIsStarred, Is.EqualTo("icon-sm icon-star is-starred board-tile-options-star-icon"), "Assert that the board has been hovered over and the star clicked - making it a favourite board");


            TestLogger.LogTestResult();
            TestLogger.LogScenarioEnd();
        }

        //*******************************
        [Test]
        public void AddingListsAndCards()
        {
            TestLogger.LogScenarioStart();

            //i Click on the user created board
            DesktopWebsite.boardsPage.userBoard.Click();

            //I create three new lists
            DesktopWebsite.specificBoardsPage.addAList.Click();
            DesktopWebsite.specificBoardsPage.enterListTitle.InputText("To Do");
            DesktopWebsite.specificBoardsPage.addListButton.Click();
            DesktopWebsite.specificBoardsPage.addACard.Click();

            for (int i = 0; i < 5; i++)
            {
                String testText = String.Format("Test Text Placeholder {0}", i);
                DesktopWebsite.specificBoardsPage.enterCardTitle.InputText(testText);
                DesktopWebsite.specificBoardsPage.addCard.Click();
            }

            Console.WriteLine("Successfully created To Do and tasks 0-4");

            //Doing
            DesktopWebsite.specificBoardsPage.enterListTitle.InputText("Doing");
            DesktopWebsite.specificBoardsPage.addListButton.Click();
            DesktopWebsite.specificBoardsPage.addACard.Click();

            Thread.Sleep(1000);

            for (int i = 5; i < 10; i++)
            {
                String testText = String.Format("Test Text Placeholder {0}", i);
                DesktopWebsite.specificBoardsPage.enterCardTitle.InputText(testText);
                DesktopWebsite.specificBoardsPage.addCard.Click();
            }

            Console.WriteLine("Successfully created 'Doing' and tasks 5-9");

            //Done
            DesktopWebsite.specificBoardsPage.enterListTitle.InputText("Done");
            DesktopWebsite.specificBoardsPage.addListButton.Click();
            DesktopWebsite.specificBoardsPage.addACard.Click();

            Thread.Sleep(1000);

            for (int i = 10; i < 15; i++)
            {
                String testText = String.Format("Test Text Placeholder {0}", i);
                DesktopWebsite.specificBoardsPage.enterCardTitle.InputText(testText);
                DesktopWebsite.specificBoardsPage.addCard.Click();
            }

            Console.WriteLine("Successfully created Done and tasks 10-14");

            //I click the back to home button
            Thread.Sleep(2000);
            DesktopWebsite.header.backToHome.Click();

            TestLogger.LogTestResult();
            TestLogger.LogScenarioEnd();
        }

        //***************************
        [Test]
        public void DragAndDropCardFromToDoToDoing()
        {
            TestLogger.LogScenarioStart();

            //click the user board
            DesktopWebsite.boardsPage.userBoard.Click();

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

            TestLogger.LogTestResult();
            TestLogger.LogScenarioEnd();
        }

        //*****************************
        [Test]
        public void DragAndDropCardFromDoneToDoing()
        {
            TestLogger.LogScenarioStart();

            //click the user board
            DesktopWebsite.boardsPage.userBoard.Click();
        
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

            TestLogger.LogTestResult();
            TestLogger.LogScenarioEnd();
        }

        //**************************************
        [OneTimeTearDown]
        public void KillTests()
        {
            TestLogger.LogSuiteTeardownStart();

            //delete the board

            //click home regardless of screen on
            DesktopWebsite.header.backToHome.JsClick();
            DesktopWebsite.boardsPage.userBoard.Click();
            DesktopWebsite.specificBoardsPage.moreSideMenuButton.Click();
            DesktopWebsite.specificBoardsPage.closeBoard.Click();
            DesktopWebsite.specificBoardsPage.closeBoardConfirmation.Click();
            DesktopWebsite.specificBoardsPage.permDeleteBoard.Click();
            DesktopWebsite.specificBoardsPage.permDeleteBoardConfirm.Click();
            //DesktopWebsite.boardsPage.boardNotFound.AssertElementTextContains("Board not found.");
            DesktopWebsite.header.trelloLogoHome.Click();

            //driver clean up
            SeleniumHelper.DestroyDriver();

            TestLogger.LogSuiteTeardownEnd();

            TestLogger.Close();
        }
    }
}
