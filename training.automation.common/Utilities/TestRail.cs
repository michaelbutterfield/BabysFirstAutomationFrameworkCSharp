using Gurock.TestRail;
using Newtonsoft.Json.Linq;
using NUnit.Framework.Interfaces;
using System.Collections.Generic;

namespace training.automation.common.Utilities
{
    using common.Utilities.Data;

    public static class TestRail
    {
        public static void CreateTestRun()
        {
            APIClient client = new APIClient("https://michaelbutterfield.testrail.io/");
            client.User = TestRailUser.GetUsername();
            client.Password = TestRailUser.GetPassword();
            string dateTime = TestHelper.GetTodaysDateTime("dd.MM.yy HH.mm.ss");

            Dictionary<string, object> runData = new Dictionary<string, object>();
            runData.Add("name", $"Run: {dateTime}");
            runData.Add("description", "why are you reading this?");
            runData.Add("milestone_id", 1);
            runData.Add("assignedto_id", 1);
            runData.Add("include_all", true);

            JObject p = (JObject)client.SendPost("add_run/1", runData);

            int runId = (int)p.GetValue("id");
            RuntimeTestData.Add("TestRailRunId", runId);
        }

        public static void PostTestResults(TestStatus status)
        {
            APIClient client = new APIClient("https://michaelbutterfield.testrail.io/");
            client.User = TestRailUser.GetUsername();
            client.Password = TestRailUser.GetPassword();

            int testStatusId;

            if(status.Equals(TestStatus.Failed))
            {
                testStatusId = 5;
            }
            else
            {
                testStatusId = 1;
            }

            Dictionary<string, object> resultData = new Dictionary<string, object>();
            resultData.Add("status_id", testStatusId);
            resultData.Add("comment", TestHelper.GetScenario().Test.Name);
            resultData.Add("assignedto_id", 1);

            JObject p = (JObject)client.SendPost("add_result/12", resultData);

        }
    }
}
