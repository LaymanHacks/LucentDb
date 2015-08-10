using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LucentDb.Domain.Model;
using LucentDb.Web.UI.Controllers.API;
using Newtonsoft.Json;
using NUnit.Framework;

namespace LucentDb.Web.UI.Tests.Api
{
    [TestFixture]
    public class ValidateApiTest
    {
        private ValidateApiController _target;

        [TestFixtureSetUp]
        public void Init()
        {
            _target = new ValidateApiController
            {
                Request = new HttpRequestMessage {RequestUri = new Uri("http://localhost/api/validate")}
            };

            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            config.EnsureInitialized();

            _target.Request.SetConfiguration(config);
        }

        [Test]
        public void ValidateTest_Should_Return_True_When_Provided_A_Valid_Test_And_Connection()
        {
            var result = _target.ValidateTest(1, 1);
            var validationResponse = JsonConvert.DeserializeObject<ValidationResponse>(result.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            Assert.AreEqual(true, validationResponse.IsValid);
        }

        [Test]
        public void ValidateTest_Should_Throw_Exception_When_Invalid_Connection_Is_Supplied()
        {
            //connection does not exist
            Assert.That(() => _target.ValidateTest(1, -1),
                Throws.TypeOf<Exception>()
                    .With.Message.EqualTo("Not a valid connection"));
            //connection exists but is tied to another project
            Assert.That(() => _target.ValidateTest(1, 2),
                Throws.TypeOf<Exception>()
                    .With.Message.EqualTo("Not a valid Connection for this test."));
        }
    }
}