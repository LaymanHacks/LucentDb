using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using LucentDb.Validator;
using LucentDb.ValidatorTests;
using NUnit.Framework;
namespace LucentDb.Validator.Tests
{
    [TestFixture()]
    public class HttpScriptResolverTests
    {
       
        [Test()]
        public void GetSqlScriptTest()
        {
            var scriptValue = "Select 1 from SomeTable";
            var rMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(scriptValue)
            };
            var fakeResponseHandler = new FakeResponseHandler(rMessage);

            var httpScriptResolver = new HttpScriptResolver("http://LucentDb.com/test.sql", fakeResponseHandler);
            var response = httpScriptResolver.GetSqlScript();

            Assert.AreEqual(scriptValue, response);

        }
    }
}
