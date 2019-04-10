using OpenQA.Selenium;
using training.automation.common.Page;
using training.automation.common.Selenium.Elements;

namespace training.automation.selenium.Application.Pages
{
    public class SpecificBoardsPage : Page
    {
        public Button AddACard;
        public Button AddAnotherList;
        public Button AddAList;
        public Button AddCard;
        public Button AddCardCancel;
        public Button AddListButton;
        public Button CloseBoard;
        public Button CloseBoardConfirmation;
        public InputBox EnterCardTitle;
        public InputBox EnterListTitle;
        public Button MoreSideMenuButton;
        public Link PermDeleteBoard;
        public Button PermDeleteBoardConfirm;

        public SpecificBoardsPage() : base("Specific Boards Page") { BuildPage(); }

        private void BuildPage()
        {
            AddACard = new Button(By.XPath("//span[@class='js-add-a-card']"), "Add a card", name);
            AddAnotherList = new Button(By.XPath("//span[text()='Add another list']"), "Add another list (used for adding any list after the first one)", name);
            AddAList = new Button(By.XPath("//span[text()='Add a list']"), "Add a list", name);
            AddCard = new Button(By.XPath("//input[@class='primary confirm mod-compact js-add-card'][@type='submit']"), "Add Card Button", name);
            AddCardCancel = new Button(By.XPath("//a[@class='icon-lg icon-close dark-hover js-cancel']"), "Add a card cancel", name);
            AddListButton = new Button(By.XPath("//input[@class='primary mod-list-add-button js-save-edit']"), "Add List Confirmation Button", name);
            CloseBoard = new Button(By.XPath("//a[@class='board-menu-navigation-item-link js-close-board']"), "Close Board...", name);
            CloseBoardConfirmation = new Button(By.XPath("//input[@class='js-confirm full negate']"), "Confirm Close Board", name);
            EnterCardTitle = new InputBox(By.XPath("//textarea[@class='list-card-composer-textarea js-card-title']"), "Entering card title", name);
            EnterListTitle = new InputBox(By.XPath("//input[@class='list-name-input']"), "Entering the list title", name);
            MoreSideMenuButton = new Button(By.XPath("//a[@class='board-menu-navigation-item-link js-open-more']"), "More Button in Side Menu", name);
            PermDeleteBoard = new Link(By.XPath("//a[@class='quiet js-delete']"), "Permanently Delete Board...", name);
            PermDeleteBoardConfirm = new Button(By.XPath("//input[@class='js-confirm full negate']"), "Yes, Permanently Delete Board.", name);
        }
    }
}
