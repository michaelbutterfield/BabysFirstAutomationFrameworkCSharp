using OpenQA.Selenium;
using training.automation.common.Pages;
using training.automation.common.Selenium.Elements;
using training.automation.selenium.specflow.Application.Pop_ups;

namespace training.automation.selenium.specflow.Application.Pages
{
    public class CardPage : Page
    {
        public CardPage() : base("Cards") { BuildPage(); BuildElements(); }

        public Button Checklist;
        public Text ChecklistHeader;
        public Text ChecklistItem;
        public InputBox ChecklistItemTitle;
        public Button ChecklistItemAdd;

        public AddChecklist AddChecklist;

        private void BuildPage()
        {
            AddChecklist = new AddChecklist();
        }

        private void BuildElements()
        {
            Checklist = new Button(By.XPath("//a[@title='Checklist']"), "Checklist", name);
            ChecklistItemTitle = new InputBox(By.XPath("//textarea[@class='edit field checklist-new-item-text js-new-checklist-item-input']"), "Checklist Item Title", name);
            ChecklistItemAdd = new Button(By.XPath("//input[@value='Add' and @type='submit']"), "Add", name);
        }

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



    }
}
