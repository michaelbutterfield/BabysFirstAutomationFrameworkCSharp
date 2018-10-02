using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using training.automation.common.utilities;
using training.automation.selenium.Application;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;

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
            SeleniumDriverHelper.Initialise("chrome");
            SeleniumDriverHelper.GoToUrl("http://www.trello.com/login");
            DesktopWebsite.logInPage.createAnAccount.AssertElementIsDisplayed();
            DesktopWebsite.logInPage.emailAddress.InputText("michaelbutterf@gmail.com");
            DesktopWebsite.logInPage.password.InputText("automationtest23");
            DesktopWebsite.logInPage.logInButton.Click();
            DesktopWebsite.boardsPage.addButton.WaitForElementToBeClickable();
            NUnit.Framework.Assert.AreEqual(SeleniumDriverHelper.GetWebDriver().Title, "Boards | Trello", "Asserting {0} and {1} are same.",
                                            SeleniumDriverHelper.GetWebDriver().Title, "Boards | Trello");

            //Click the add button in the top right
            DesktopWebsite.boardsPage.addButton.Click();

            //Click the create board option
            DesktopWebsite.boardsPage.createNewBoardButton.Click();

            //Create a new board with name and background
            DesktopWebsite.boardsPage.nameInput.InputText("TestBoard");
            DesktopWebsite.boardsPage.backgroundSelectionButton.Click();
            DesktopWebsite.boardsPage.createBoardButton.Click();

            //I Click back to home button
            Thread.Sleep(3000);
            DesktopWebsite.header.backToHome.JsClick();
            
            //I confirm the board is created
            DesktopWebsite.boardsPage.userBoardButton.AssertElementIsDisplayed();
        }

        //******************************
        [Test, Order(1)]
        public void FavouriteABoard()
        {
            //I am on the boards page
            if (!SeleniumDriverHelper.GetWebDriver().Title.Equals("Boards | Trello"))
            {
                DesktopWebsite.header.backToHome.Click();
            }

            //I Click the favourite board star
            IWebElement userBoard = SeleniumDriverHelper.GetWebDriver().FindElement(By.XPath("//div[(@title=\"TestBoard\")]"));
            Actions action = new Actions(SeleniumDriverHelper.GetWebDriver());
            action.MoveToElement(userBoard).Perform();
            DesktopWebsite.boardsPage.favouriteButton.Click();
            NUnit.Framework.TestContext.Progress.WriteLine("Successfully hovered over the user board and Clicked favourite");
            Thread.Sleep(3000);

            //The board will be favourited
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

            //click and drag 3 cards
            //Move 0 to Doing
            IWebElement From = SeleniumDriverHelper.GetWebDriver().FindElement(By.XPath("//*[@id=\"board\"]/div[1]/div/div[2]/a[1]"));
            IWebElement To = SeleniumDriverHelper.GetWebDriver().FindElement(By.XPath("//*[@id=\"board\"]/div[2]/div/div[1]/div[1]"));
            Actions act = new Actions(SeleniumDriverHelper.GetWebDriver());
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

            //click and drag 3 cards
            //Move 0 to Doing
            IWebElement From = SeleniumDriverHelper.GetWebDriver().FindElement(By.XPath("//*[@id=\"board\"]/div[3]/div/div[2]/a[1]"));
            IWebElement To = SeleniumDriverHelper.GetWebDriver().FindElement(By.XPath("//*[@id=\"board\"]/div[2]/div/div[1]/div[1]"));
            Actions act = new Actions(SeleniumDriverHelper.GetWebDriver());
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
            DesktopWebsite.boardsPage.boardNotFound.AssertElementTextContains("Board not found.");
            DesktopWebsite.header.trelloLogoHome.Click();

            //driver clean up
            SeleniumDriverHelper.DestroyDriver();
        }
    }
}
