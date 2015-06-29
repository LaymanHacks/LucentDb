using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LucentDb.Data.Repository.WebApi
{
    public class HttpJsonClient : HttpClient
    {
        public HttpJsonClient(string baseAddress, HttpMessageHandler httpMessageHandler)
        {
            BaseAddress = new Uri(baseAddress);
            DefaultRequestHeaders.Accept.Clear();
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpJsonClient(string baseAddress) : this(baseAddress, new HttpClientHandler())
        {
        }
    }
}