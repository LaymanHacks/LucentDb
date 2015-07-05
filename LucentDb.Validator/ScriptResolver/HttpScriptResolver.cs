using System.Net.Http;

namespace LucentDb.Validator
{
    public class HttpScriptResolver : IScriptResolver
    {
        private readonly string _testValue;

        public HttpScriptResolver(string testValue)
        {
            _testValue = testValue;
        }

        public string GetSqlScript()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(_testValue).Result;
                return !response.IsSuccessStatusCode ? null : response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}