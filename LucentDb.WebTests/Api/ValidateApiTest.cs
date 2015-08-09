using System;
using System.Net.Http;
using System.Web.Http;
using LucentDb.Web.UI.Controllers.Api;
using LucentDb.Web.UI.Controllers.API;
using Moq;
using NUnit.Framework;

namespace LucentDb.Web.UI.Tests.Api
{
    [TestFixture()]
   public class ValidateApiTest
    {
        private ValidateApiController _target;

        [TestFixtureSetUp]
        public void Init()
        {
            
            _target = new ValidateApiController()
            {
                Request = new HttpRequestMessage { RequestUri = new Uri("http://localhost/api/validate") }
            };

            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            config.EnsureInitialized();

            _target.Request.SetConfiguration(config);
        }
   

         [Test()]
        public void ValidateTest_Should_Return_True_When_Provided_A_Valid_Test_And_Connection()
         {

             var result = _target.ValidateTest(testId: 1, connectionId: 1);
             Assert.AreEqual(true, result.IsValid);
        }


    }

}
