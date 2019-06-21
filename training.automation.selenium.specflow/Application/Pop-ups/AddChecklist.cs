using OpenQA.Selenium;

namespace training.automation.selenium.specflow.Application.Pop_ups
{
    using common.Page;
    using common.Selenium.Elements;

    public class AddChecklist : Popup
    {
        public AddChecklist() : base("Add Checklist") { BuildPage(); }

        public InputBox ChecklistTitle;
        public Button Add;

        private void BuildPage()
        {
            ChecklistTitle = new InputBox(By.XPath("//input[@id='id-checklist' and @type='text']"), "Checklist Title", name);
            Add = new Button(By.XPath("//input[@value='Add' and @type='submit']"), "Add", name);
        }
    }
}
