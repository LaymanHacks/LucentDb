using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LucentDb.ValidatorTests
{
    public class FakeResponseHandler : DelegatingHandler
    {

        private readonly HttpResponseMessage _response;

        public  FakeResponseHandler(HttpResponseMessage response)
        {
            if (response == null)
                throw new ArgumentNullException("response", "response is null.");
            _response = response;
        }

        protected  override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<HttpResponseMessage>();
            _response.RequestMessage = request;
            tcs.SetResult(_response);
            return tcs.Task;

        }
    }
}
