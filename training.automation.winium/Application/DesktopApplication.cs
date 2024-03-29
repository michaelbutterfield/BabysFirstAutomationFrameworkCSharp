﻿namespace training.automation.winium.Application
{
    using Pages.Calculator;
    using Sections.Calculator;

    public class DesktopApplication
    {
        public static MainPage MainPage { get; private set; }
        public static NavigationPane NavigationPane { get; private set; }

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
