using RestSharp;
using TechTalk.SpecFlow;
using training.automation.api.Data;

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
        public string I_send_a_search_request()
        {
            var client = new RestClient("http://api.trello.com");

            var request = new RestRequest("/1/search?query={query}&key={key}&token={token}", Method.GET);
            request.AddUrlSegment("query", "permboard");
            request.AddUrlSegment("key", TrelloApiData.GetApiKey());
            request.AddUrlSegment("token", TrelloApiData.GetApiToken());

            var response = client.Execute<TrelloQueryResponseData.RootObject>(request);

            return response.StatusCode.ToString();
        }

        [When]
        public string I_send_a_bad_search_request()
        {
            var client = new RestClient("http://api.trello.com");

            var request = new RestRequest("/1/search?query={query}&key={key}&token={token}", Method.GET);
            request.AddUrlSegment("query", "boardnotthere");
            request.AddUrlSegment("key", TrelloApiData.GetApiKey());
            request.AddUrlSegment("token", TrelloApiData.GetApiToken());

            var response = client.Execute<TrelloQueryResponseData.RootObject>(request);

            return response.StatusCode.ToString();
        }


        [Then]
        public void I_will_recieve_a_P0_response(int p0)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
