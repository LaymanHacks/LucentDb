using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LucentDb.Data.Repository.WebApi
{
    public class HttpJsonClient : HttpClient
    {
        public HttpJsonClient(HttpMessageHandler messageHandler)
        {
            DefaultRequestHeaders.Accept.Clear();
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpJsonClient(string baseAddress, HttpMessageHandler httpMessageHandler)
            : this(httpMessageHandler)
        {
            BaseAddress = new Uri(baseAddress);
        }

        public HttpJsonClient(string baseAddress) : this(baseAddress, new HttpClientHandler())
        {
        }
    }
}