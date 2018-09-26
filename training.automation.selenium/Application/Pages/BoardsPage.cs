using OpenQA.Selenium;
using training.automation.common.Pages;
using training.automation.common.Selenium.Elements;

namespace training.automation.selenium.Application.Pages
{
    public class BoardsPage : Page
    {
        public Button boardsSideBarButton;
        public Button addButton;
        public Button createNewBoardButton;
        public InputBox nameInput;
        public Button backgroundSelectionButton;
        public Button createBoardButton;
        public Button userBoardButton;
        public Label boardNotFound;
        public Button favouriteButton;

        public BoardsPage() : base("BoardsPage") { BuildPage(); }

        private void BuildPage()
        {
            boardsSideBarButton = new Button(By.XPath("//*[@id=\"content\"]/div/div[2]/div/div/div/div/div/div[1]/nav/div[1]/ul/li[1]/a/span[2]"),
                                             "Boards Side Bar Button", name);

            addButton = new Button(By.XPath("//*[@id=\"header\"]/div[5]/a[1]/span"), "Add Button", name);

            createNewBoardButton = new Button(By.XPath("//*[@id=\"classic\"]/div[5]/div/div[2]/div/div/div/ul/li[1]/a"), "Create Board... Button", name);

            nameInput = new InputBox(By.XPath("//*[@id=\"classic\"]/div[4]/div/div/div/form/div/div/div[1]/input"), "Board Name Input Box", name);

            backgroundSelectionButton = new Button(By.XPath("//*[@id=\"classic\"]/div[4]/div/div/div/form/div/ul/li[2]/button"),
                                                   "Board Background Selection", name);

            createBoardButton = new Button(By.XPath("//*[@id=\"classic\"]/div[4]/div/div/div/form/button/span[2]"), "Create Board Button", name);

            userBoardButton = new Button(By.XPath("//div[contains(@title, 'TestBoard')]"), "User Created Board", name);

            boardNotFound = new Label(By.XPath("//h1[contains(text(),'Board not found.')]"), "Board not found. message", name);

            favouriteButton = new Button(By.XPath("//span[contains(@class, 'board-tile-options')]"), "Favourite Button", name);
        }

    }
}
