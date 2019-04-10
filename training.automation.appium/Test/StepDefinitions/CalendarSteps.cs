using OpenQA.Selenium.Interactions;
using TechTalk.SpecFlow;
using training.automation.appium.Application;
using training.automation.common.Utilities;

namespace training.automation.appium.Test.StepDefinitions
{
    [Binding]
    public class CalendarSteps
    {
        [Given]
        public void I_am_in_the_calendar()
        {
            MobileApp.TopCalendarNavigationBar.Add.WaitUntilExists();
        }

        [When]
        public void I_click_the_new_event_button()
        {
            MobileApp.TopCalendarNavigationBar.Add.AssertExists();
            MobileApp.TopCalendarNavigationBar.Add.Click();
        }

        [When]
        public void I_enter_the_required_information()
        {
            MobileApp.NewCalendarEventPage.Title.AssertExists();
            MobileApp.NewCalendarEventPage.Title.SendKeys("test test 123");

            MobileApp.NewCalendarEventPage.Location.AssertExists();
            MobileApp.NewCalendarEventPage.Location.Click();
            MobileApp.NewCalendarEventPage.Location.SendKeys("Preston, England");
            MobileApp.NewCalendarEventPage.LocationSpecific.AssertExists();
            MobileApp.NewCalendarEventPage.LocationSpecific.Click();

            MobileApp.NewCalendarEventPage.Repeats.AssertExists();
            MobileApp.NewCalendarEventPage.Repeats.Click();
            MobileApp.NewCalendarEventPage.RepeatEveryWeek.AssertExists();
            MobileApp.NewCalendarEventPage.RepeatEveryWeek.Click();

            TouchActions ta = new TouchActions(AppiumHelper.GetDriver());
            ta.Down(422, 363).Move(422, 63).Release().Perform();
            MobileApp.NewCalendarEventPage.NotesInput.SendKeys("jack sucks lol");
            MobileApp.NewCalendarEventPage.Add.Click();
        }

        [Then]
        public void the_event_will_be_created()
        {
            MobileApp.MainCalendarPage.createdEvent.WaitUntilExists();
            MobileApp.MainCalendarPage.createdEvent.AssertExists();
        }
    }
}
