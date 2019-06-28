using OpenQA.Selenium;

namespace training.automation.specflow.Application.Pages
{
    using common.Page;
    using common.Selenium.Elements;
    using specflow.Application.Popups;

    public class CardPage : Page
    {
        public CardPage() : base("Cards") { BuildPage(); BuildPopup(); }

        public Button Checklist { get; private set; }
        public Text ChecklistHeader { get; private set; }
        public Text ChecklistItem { get; private set; }
        public InputBox ChecklistItemTitle { get; private set; }
        public Button ChecklistItemAdd { get; private set; }

        public AddChecklist AddChecklist;


        public void CreateChecklistItem(string ChecklistItemName)
        {
            string xpath = string.Format("//span[@class='checklist-item-details-text markeddown js-checkitem-name' and text()='{0}']", ChecklistItemName);
            ChecklistItem = new Text(By.XPath(xpath), "Checklist Item", name);
        }

        public void CreateChecklistHeader(string ChecklistHeaderName)
        {
            string xpath = string.Format("//h3[text()='{0}']", ChecklistHeaderName);
            ChecklistHeader = new Text(By.XPath(xpath), "Checklist Header", name);
        }

        private void BuildPage()
        {
            Checklist = new Button(By.XPath("//a[@title='Checklist']"), "Checklist", name);
            ChecklistItemTitle = new InputBox(By.XPath("//textarea[@class='edit field checklist-new-item-text js-new-checklist-item-input']"), "Checklist Item Title", name);
            ChecklistItemAdd = new Button(By.XPath("//input[@value='Add' and @type='submit']"), "Add", name);
        }

        private void BuildPopup()
        {
            AddChecklist = new AddChecklist();
        }
    }
}
