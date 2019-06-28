using OpenQA.Selenium;

namespace training.automation.specflow.Application.Pages
{
    using common.Page;
    using common.Selenium.Elements;
    using Sections;

    public class SpecificBoardsPage : Page
    {
        //Elements
        public Button AddACard { get; private set; }
        public Button AddAnotherList { get; private set; }
        public Button AddAList { get; private set; }
        public Button AddCard { get; private set; }
        public Button AddCardCancel { get; private set; }
        public Button AddList { get; private set; }
        public Text BoardNotFound { get; private set; }
        public Button CloseBoard { get; private set; }
        public Button CloseBoardConfirmation { get; private set; }
        public Label Doing { get; private set; }
        public Label Done { get; private set; }
        public InputBox EnterCardTitle { get; private set; }
        public InputBox EnterListTitle { get; private set; }
        public Button Invite { get; private set; }
        public Button MoreSideMenu { get; private set; }
        public Link PermDeleteBoard { get; private set; }
        public Button PermDeleteBoardConfirm { get; private set; }
        public Button ShowMenu { get; private set; }
        public Label ToDo { get; private set; }

        //Pages
        public CardPage CardPage { get; private set; }

        //Header
        public Header Header { get; private set; }

        public SpecificBoardsPage() : base("Specific Boards") { BuildPage(); BuildElements(); BuildHeader(); }

        private void BuildHeader()
        {
            Header = new Header();
        }

        private void BuildPage()
        {
            CardPage = new CardPage();
        }

        private void BuildElements()
        {
            AddACard = new Button(By.XPath("//span[@class='js-add-a-card']"), "Add a card", name);
            AddAnotherList = new Button(By.XPath("//span[text()='Add another list']"), "Add another list (used for adding any list after the first one)", name);
            AddAList = new Button(By.XPath("//span[text()='Add a list']"), "Add a list", name);
            AddCard = new Button(By.XPath("//input[@class='primary confirm mod-compact js-add-card'][@type='submit']"), "Add Card Button", name);
            AddCardCancel = new Button(By.XPath("//a[@class='icon-lg icon-close dark-hover js-cancel']"), "Add a card cancel", name);
            AddList = new Button(By.XPath("//input[@class='primary mod-list-add-button js-save-edit']"), "Add List Confirmation Button", name);
            BoardNotFound = new Text(By.XPath("//h1[text()=\"Board not found.\"]"), "Board not found.", name);
            CloseBoard = new Button(By.XPath("//a[@class='board-menu-navigation-item-link js-close-board']"), "Close Board...", name);
            CloseBoardConfirmation = new Button(By.XPath("//input[@class='js-confirm full negate']"), "Confirm Close Board", name);
            Doing = new Label(By.XPath("//textarea[@class='list-header-name mod-list-name js-list-name-input'][@aria-label='Doing']"), "Doing List", name);
            Done = new Label(By.XPath("//textarea[@class='list-header-name mod-list-name js-list-name-input'][@aria-label='Done']"), "Done List", name);
            EnterCardTitle = new InputBox(By.XPath("//textarea[@class='list-card-composer-textarea js-card-title']"), "Entering card title", name);
            EnterListTitle = new InputBox(By.XPath("//input[@class='list-name-input']"), "Entering the list title", name);
            Invite = new Button(By.XPath("//a[@title='Invite To Board']"), "Invite", name);
            MoreSideMenu = new Button(By.XPath("//a[@class='board-menu-navigation-item-link js-open-more']"), "More Button in Side Menu", name);
            PermDeleteBoard = new Link(By.XPath("//a[@class='quiet js-delete']"), "Permanently Delete Board...", name);
            PermDeleteBoardConfirm = new Button(By.XPath("//input[@class='js-confirm full negate']"), "Yes, Permanently Delete Board.", name);
            ShowMenu = new Button(By.XPath("//a[@class='board-header-btn mod-show-menu js-show-sidebar']"), "Show Menu", name);
            ToDo = new Label(By.XPath("//textarea[@class='list-header-name mod-list-name js-list-name-input'][@aria-label='To Do']"), "To Do List", name);
        }
    }
}
