using RestSharp;
using TechTalk.SpecFlow;
using training.automation.api.Data;
using training.automation.common.Utilities;
using Is = NHamcrest.Is;

namespace training.automation.api.Test.CSharp.StepDefinitions
{
    [Binding]
    public sealed class TrelloSearchSteps
    {
        [Given]
        public void I_retrieve_the_API_credentials()
        {
            TrelloApiData.ReadApiKeyToken();
        }

        [When]
        public void I_send_a_search_request()
        {
            var client = new RestClient("http://api.trello.com");

            var request = new RestRequest("/1/search?query={query}&key={key}&token={token}", Method.GET);
            request.AddUrlSegment("query", "permboard");
            request.AddUrlSegment("key", TrelloApiData.GetApiKey());
            request.AddUrlSegment("token", TrelloApiData.GetApiToken());

            var response = client.Execute<TrelloQueryResponseData.RootObject>(request);

            RuntimeTestData.Add("ResponseCode", response.StatusCode.ToString());
        }

        [When]
        public void I_send_a_bad_search_request()
        {
            var client = new RestClient("http://api.trello.com");

            var request = new RestRequest("/1/search?query={query}&key={key}&token={token}", Method.GET);
            request.AddUrlSegment("query", "boardnotthere");
            request.AddUrlSegment("key", TrelloApiData.GetApiKey());
            request.AddUrlSegment("token", TrelloApiData.GetApiToken());

            var response = client.Execute<TrelloQueryResponseData.RootObject>(request);

            RuntimeTestData.Add("ResponseCode", response.StatusCode.ToString());
        }

        [When]
        public void I_send_a_create_board_request()
        {
            var client = new RestClient("https://api.trello.com/");

            string BoardName = "TestBoard";

            var request = new RestRequest("1/boards/?name={name}&desc={desc}&defaultLists=false&key={key}&token={token}", Method.POST, DataFormat.Json);
            request.AddUrlSegment("name", BoardName);
            request.AddUrlSegment("desc", "Lorem ipsum you son of a gun");
            request.AddUrlSegment("key", TrelloApiData.GetApiKey());
            request.AddUrlSegment("token", TrelloApiData.GetApiToken());
            request.AddHeader("content-type", "application/json; charset=utf-8");

            IRestResponse response = client.Execute(request);

            RuntimeTestData.Add("ResponseCode", response.StatusCode.ToString());
            RuntimeTestData.Add("BoardName", BoardName);
        }

        [When]
        public void I_send_a_create_board_request_with_no_key_or_token()
        {
            var client = new RestClient("https://api.trello.com/");

            string BoardName = "TestBoard";

            var request = new RestRequest("1/boards/?name={name}&desc={desc}&defaultLists=false", Method.POST, DataFormat.Json);
            request.AddUrlSegment("name", BoardName);
            request.AddUrlSegment("desc", "Lorem ipsum you son of a gun");
            request.AddHeader("content-type", "application/json; charset=utf-8");

            IRestResponse response = client.Execute(request);

            RuntimeTestData.Add("ResponseCode", response.StatusCode.ToString());
            RuntimeTestData.Add("BoardName", BoardName);
        }

        [Then]
        public void I_will_receive_a_P0_response(int p0)
        {
            string expected = p0.ToString();

            string actual = RuntimeTestData.GetAsString("ResponseCode");

            string stepDef = string.Format("Asserting that actual response code: {0} -- is equal to:-- {1}", actual, p0);

            TestHelper.AssertThat(actual, Is.EqualTo(expected), stepDef);
        }

    }
}
