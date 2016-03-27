using System;
using System.Net;
using System.Net.Http;
using LucentDb.Data.WebApiClientTests;
using NUnit.Framework;

namespace LucentDb.Validator.Tests
{
    [TestFixture]
    public class HttpScriptResolverTests
    {
        [Test]
        public void GetSqlScriptTest()
        {
            var scriptValue = "Select 1 from SomeTable";
            var rMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(scriptValue)
            };
            var fakeResponseHandler = new FakeResponseHandler();
            fakeResponseHandler.AddFakeResponse(new Uri("http://LucentDb.com/test.sql"), rMessage);

            var httpScriptResolver = new HttpScriptResolver("http://LucentDb.com/test.sql", fakeResponseHandler);
            var response = httpScriptResolver.GetTestValue();

            Assert.AreEqual(scriptValue, response);
        }
    }
}