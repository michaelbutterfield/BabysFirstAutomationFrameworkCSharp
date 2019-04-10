using OpenQA.Selenium;
using training.automation.common.Appium.Elements;
using training.automation.common.Sections;

namespace training.automation.appium.Application.Sections
{
    public class TopCalendarNavigationBar : Section
    {
        public TopCalendarNavigationBar() : base("Main Calendar Page") { BuildSection(); }

        public Button Add;
        public Button Day;
        public Button Month;
        public Button Search;
        public Button Week;
        public Button Year;


        private void BuildSection()
        {
            Add = new Button(By.Name("Add"), "Add Button", name);
            Day = new Button(By.Name("Day"), "Day Button", name);
            Month = new Button(By.Name("Month"), "Month Button", name);
            Search = new Button(By.Name("Search"), "Search Button", name);
            Week = new Button(By.Name("Week"), "Week Button", name);
            Year = new Button(By.Name("Year"), "Year Button", name);
        }
    }
}
