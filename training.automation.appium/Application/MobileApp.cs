using training.automation.appium.Application.Pages;
using training.automation.appium.Application.Sections;
using training.automation.common.Page;

namespace training.automation.appium.Application
{
    public class MobileApp : Page
    {
        public static MainCalendarPage MainCalendarPage;
        public static NewCalendarEventPage NewCalendarEventPage;
        public static TopCalendarNavigationBar TopCalendarNavigationBar;

        public MobileApp() : base("Mobile App") { BuildPages(); BuildSections(); }

        private void BuildPages()
        {
            MainCalendarPage = new MainCalendarPage();
            NewCalendarEventPage = new NewCalendarEventPage();
        }

        private void BuildSections()
        {
            TopCalendarNavigationBar = new TopCalendarNavigationBar();
        }

    }
}
