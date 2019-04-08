using OpenQA.Selenium;
using training.automation.common.Pages;
using training.automation.common.Selenium.Elements;
using training.automation.specflow.Application.Sections;

namespace training.automation.specflow.Application.Pages
{
    public class BoardsPage : Page
    {
        //Elements
        public Label BoardNotFound;
        public Button CreateNewBoard;
        public Text PersonalBoards;
        public Button Unstarred;
        public Button UserBoard;
        public Button Starred;

        //Headers
        public Header Header;

        public BoardsPage() : base("Boards") { BuildPage(); }

        private void BuildHeader()
        {
            Header = new Header();
        }

        private void BuildPage()
        {
            BoardNotFound = new Label(By.XPath("//h1[contains(text(),'Board not found.')]"), "Board not found. message", name);
            CreateNewBoard = new Button(By.XPath("//a[@class=\"js-new-board\"]"), "Create Board... Button", name);
            PersonalBoards = new Text(By.XPath("//h3[text()='Personal Boards']"), "Personal Boards", name);
            Starred = new Button(By.XPath("//span[@class='icon-sm icon-star is-starred board-tile-options-star-icon']"), "Starred Board Button", name);
        }

        public void AssignUserBoard(string BoardName)
        {
            UserBoard = new Button(By.XPath(string.Format("//div[@title='{0}']", BoardName)), "UserBoard", name);
        }

        public void AssignBoardToStar(string BoardName)
        {
            string xpath = string.Format("//div[@title='{0}']/..//span[@class='icon-sm icon-star board-tile-options-star-icon']", BoardName);
            Unstarred = new Button(By.XPath(xpath), "Unstarred Board Button", name);
        }
    }
}
