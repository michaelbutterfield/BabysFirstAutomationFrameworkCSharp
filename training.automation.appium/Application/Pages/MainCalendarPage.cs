using OpenQA.Selenium;
using training.automation.common.Appium.Elements;
using training.automation.common.Page;

namespace training.automation.appium.Application.Pages
{
    public class MainCalendarPage : Page
    {
        public Button createdEvent;

        public MainCalendarPage() : base("Main Calendar") { BuildPages(); }

        private void BuildPages()
        {
            createdEvent = new Button(By.Name("test test 123"), "User Created Event", name);
        }
    }
}
