using OpenQA.Selenium;
using training.automation.common.Appium.Elements;
using training.automation.common.Page;

namespace training.automation.appium.Application.Pages
{
    public class NewCalendarEventPage : Page
    {
        public Button Add;
        public InputBox NotesInput; //used to actually send keys to the notes input box
        public InputBox Location;
        public InputBox LocationSpecific;
        public Button Starts;
        public InputBox Title;
        public Button Repeats;
        public Button RepeatEveryWeek;

        public NewCalendarEventPage() : base("New Calendar Event") { BuildPages(); }

        private void BuildPages()
        {
            Add = new Button(By.Name("add"), "Add Button", name);
            NotesInput = new InputBox(By.Name("Notes"), "Notes Send Keys Input", name);
            Location = new InputBox(By.Name("Location"), "Location Button", name);
            LocationSpecific = new InputBox(By.Name("Preston, England"), "Location Input Box - Preston, England", name);
            Repeats = new Button(By.Name("Repeat"), "Repeats Button", name);
            RepeatEveryWeek = new Button(By.Name("Every Week"), "Repeat Every Week", name);
            Title = new InputBox(By.Name("Title"), "Title Input Box", name);
        }
    }
}
