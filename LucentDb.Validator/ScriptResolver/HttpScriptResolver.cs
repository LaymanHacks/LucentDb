using System.Net.Http;

namespace LucentDb.Validator
{
    public class HttpScriptResolver : IScriptResolver
    {
        private readonly HttpMessageHandler _messageHandler;
        private readonly string _testValue;

        public HttpScriptResolver(string testValue, HttpMessageHandler messageHandler)
        {
            _testValue = testValue;
            _messageHandler = messageHandler;
        }

        public HttpScriptResolver(string testValue) : this(testValue, new HttpClientHandler())
        {
            _testValue = testValue;
        }

        public string GetSqlScript()
        {
            using (var client = new HttpClient(_messageHandler))
            {
                var response = client.GetAsync(_testValue).Result;
                return !response.IsSuccessStatusCode ? null : response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}