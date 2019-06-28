using RestSharp;
using RestSharp.Deserializers;
using TechTalk.SpecFlow;
using Is = NHamcrest.Is;

namespace training.automation.api.Test.CSharp.StepDefinitions
{
    using common.Tests;
    using common.Utilities;
    using common.Utilities.Data.Trello;

    [Binding]
    public sealed class TrelloSearchSteps
    {
        private static IRestClient client = new RestClient("https://api.trello.com/");
        private static JsonDeserializer deserial = new JsonDeserializer();

        [Given]
        public void I_retrieve_the_API_credentials()
        {
            TrelloApiData.ReadApiKeyToken();
        }

        [When]
        public void I_send_a_bad_search_request()
        {
            RestRequest request = new RestRequest("/1/search?query=&key={key}&token={token}", Method.GET);
            request.AddUrlSegment("query", "boardnotthere");
            request.AddUrlSegment("key", TrelloApiData.GetApiKey());
            request.AddUrlSegment("token", TrelloApiData.GetApiToken());
            
            TestLogger.CreateTestStep($"Sending bad search request with URL: {client.BuildUri(request).ToString()}");

            IRestResponse response = client.Execute(request);

            RuntimeTestData.Add("ResponseCode", response.StatusCode.ToString());
        }

        [When]
        public void I_send_a_create_board_request()
        {
            string BoardName = RandomGen.RandomAlphabetString(8);
            RuntimeTestData.Add("BoardName", BoardName);

            IRestRequest request = new RestRequest("1/boards/?name={name}&desc={desc}&defaultLists=false&key={key}&token={token}", Method.POST, DataFormat.Json);
            request.AddUrlSegment("name", BoardName);
            request.AddUrlSegment("desc", "Lorem ipsum you son of a gun");
            request.AddUrlSegment("key", TrelloApiData.GetApiKey());
            request.AddUrlSegment("token", TrelloApiData.GetApiToken());
            request.AddHeader("content-type", "application/json; charset=utf-8");

            IRestResponse response = client.Execute(request);

            RuntimeTestData.Add("ResponseCode", response.StatusCode.ToString());
        }

        [When]
        public void I_send_a_create_board_request_with_no_key_or_token()
        {
            string BoardName = RandomGen.RandomAlphabetString(8);

            IRestRequest request = new RestRequest("1/boards/?name={name}&desc={desc}&defaultLists=false", Method.POST, DataFormat.Json);
            request.AddUrlSegment("name", BoardName);
            request.AddUrlSegment("desc", "Lorem ipsum you son of a gun");
            request.AddHeader("content-type", "application/json; charset=utf-8");

            IRestResponse response = client.Execute(request);

            RuntimeTestData.Add("ResponseCode", response.StatusCode.ToString());
        }

        [When]
        public void I_send_a_search_request()
        {
            IRestRequest request = new RestRequest("/1/search?query={query}&key={key}&token={token}", Method.GET);
            request.AddUrlSegment("query", "permboard");
            request.AddUrlSegment("key", TrelloApiData.GetApiKey());
            request.AddUrlSegment("token", TrelloApiData.GetApiToken());

            IRestResponse response = client.Execute(request);

            RuntimeTestData.Add("ResponseCode", response.StatusCode.ToString());
        }

        [Then]
        public void I_will_receive_a_P0_response(string p0)
        {
            string expected = p0;

            string actual = RuntimeTestData.GetAsString("ResponseCode");

            RuntimeTestData.Remove("ResponseCode");

            string stepDef = string.Format("Asserting that actual response code: {0} -- is equal to:-- {1}", actual, p0);

            TestHelper.AssertThat(actual, Is.EqualTo(expected), stepDef);
        }

    }
}
