using training.automation.winium.Application.Pages.Calculator;
using training.automation.winium.Application.Sections.Calculator;

namespace training.automation.winium.Application
{
    class DesktopApplication
    {
        public static MainPage MainPage;
        public static NavigationPane NavigationPane;

        static DesktopApplication()
        {
            BuildPages();
            BuildSections();
        }

        private static void BuildPages()
        {
            MainPage = new MainPage();
        }

        private static void BuildSections()
        {
            NavigationPane = new NavigationPane();
        }

    }
}
