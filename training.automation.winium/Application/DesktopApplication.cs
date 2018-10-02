using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using training.automation.winium.Application.Pages.Calculator;
using training.automation.winium.Application.Sections.Calculator;

namespace training.automation.winium.Application
{
    class DesktopApplication
    {
        public static MainPage mainPage;
        public static NavigationPane navigationPane;

        static DesktopApplication()
        {
            BuildPages();
            BuildSections();
        }

        private static void BuildPages()
        {
            mainPage = new MainPage();
        }

        private static void BuildSections()
        {
            navigationPane = new NavigationPane();
        }

    }
}
