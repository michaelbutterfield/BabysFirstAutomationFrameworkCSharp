using OpenQA.Selenium;

namespace training.automation.specflow.Application.Popups
{
    using common.Page;
    using common.Selenium.Elements;

    public class AddChecklist : Popup
    {
        public InputBox ChecklistTitle { get; private set; }
        public Button Add { get; private set; }

    public AddChecklist() : base("Add Checklist") { BuildPage(); }

        private void BuildPage()
        {
            ChecklistTitle = new InputBox(By.XPath("//input[@id='id-checklist' and @type='text']"), "Checklist Title", name);
            Add = new Button(By.XPath("//input[@value='Add' and @type='submit']"), "Add", name);
        }
    }
}
