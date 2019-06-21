using OpenQA.Selenium;
using training.automation.common.Page;
using training.automation.common.Selenium.Elements;
using training.automation.common.Utilities;
using training.automation.specflow.Application.Sections;

namespace training.automation.specflow.Application.Pages
{
    public class BoardsPage : Page
    {
        //Elements
        public Label BoardNotFound { get; private set; }
        public Button CreateNewBoard { get; private set; }
        public Text PersonalBoards { get; private set; }
        public Button Unstarred { get; private set; }
        public Button Starred { get; private set; }

        //Headers
        public Header Header;

        public BoardsPage() : base("Boards")
        {
            BuildPage();
            BuildSections();
        }

        public void ClickTheUserBoard()
        {
            Button userBoard = CreateUserBoard();
            userBoard.Click();
        }

        public void AssertTheUserBoardExists()
        {
            Button userBoard = CreateUserBoard();
            userBoard.WaitUntilExists();
        }

        public void AssertTheUserBoardDoesNotExist()
        {
            Button userBoard = CreateUserBoard();
            userBoard.AssertDoesNotExist();
        }

        public void ClickBoardStar()
        {
            string BoardName = RuntimeTestData.GetAsString("BoardName");
            string xpath = $"//div[@title='{BoardName}']/..//span[@class='icon-sm icon-star board-tile-options-star-icon']";
            Button star = new Button(By.XPath(xpath), "Unstarred Board Button", name);
            star.HoverOverElement();
            star.Click();
        }

        private Button CreateUserBoard()
        {
            string BoardName = RuntimeTestData.GetAsString("BoardName");
            Button userBoard = new Button(By.XPath($"//div[@title='{BoardName}']"), "User Created Board", "Boards Page");
            return userBoard;
        }

        private void BuildSections()
        {
            Header = new Header();
        }

        private void BuildPage()
        {
            BoardNotFound = new Label(By.XPath("//h1[contains(text(),'Board not found.')]"), "Board not found. message", name);
            CreateNewBoard = new Button(By.XPath("//button[@data-test-id='header-create-board-button']"), "Create Board... Button", name);
            PersonalBoards = new Text(By.XPath("//h3[text()='Personal Boards']"), "Personal Boards", name);
            Starred = new Button(By.XPath("//span[@class='icon-sm icon-star is-starred board-tile-options-star-icon']"), "Starred Board Button", name);
        }

    }
}
