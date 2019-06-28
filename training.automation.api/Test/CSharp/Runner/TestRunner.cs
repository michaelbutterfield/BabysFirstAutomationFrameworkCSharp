using NUnit.Framework;
using NUnit.Framework.Interfaces;
using TechTalk.SpecFlow;

namespace training.automation.api.Test.CSharp.Runner
{
    using common.Tests;
    using common.Utilities;
    using common.Utilities.Data.Trello;
    using RestSharp;

    [Binding]
    public class TestRunner
    {
        [BeforeTestRun]
        static void BeforeTestRun()
        {
            TrelloApiData.ReadApiKeyToken();
            IRestClient client = new RestClient("http://api.trello.com");
        }

        [BeforeScenario]
        static void BeforeScenario()
        {
            string feature = FeatureContext.Current.FeatureInfo.Title;
            if (!RuntimeTestData.ContainsKey("FeatureName"))
            {
                RuntimeTestData.Add("FeatureName", feature);
            }

            TestLogger.Initialise();
            TestLogger.LogScenarioStart();
        }

        [AfterScenario]
        static void AfterScenario()
        {
            TestContext scenario = TestHelper.GetScenario();

            if (RuntimeTestData.ContainsKey("BoardName"))
            {
                TestHelper.SleepInSeconds(1);

                TrelloAPIHelper.DeleteBoard(TrelloAPIHelper.GetTrelloBoardId(RuntimeTestData.GetAsString("BoardName")));

                RuntimeTestData.Remove("BoardName");
            }

            RuntimeTestData.Destroy();
            TestLogger.LogScenarioEnd();
            TestLogger.Close();
        }
    }
}
