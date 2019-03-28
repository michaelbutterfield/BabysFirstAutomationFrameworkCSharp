using OpenQA.Selenium;
using training.automation.common.Selenium.Elements;

namespace training.automation.selenium.specflow.Application.Pop_ups
{
    public class AddChecklist : common.Pop_up.Pop_up
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
