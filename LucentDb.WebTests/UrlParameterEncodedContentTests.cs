using System.Collections.Generic;
using NUnit.Framework;

namespace LucentDb.Web.UI.Tests
{
    [TestFixture]
    public class UrlParameterEncodedContentTests
    {
        [Test]
        public void Should_Return_Empty_When_ToString_Is_Called_With_Null_Or_EmptyKeys_Or_Values()
        {
            var urlDict = new Dictionary<string, string> {{"", "value1"}, {"Key2", ""}, {"key4", null}};
            var urlContent = new UrlParameterEncodedContent(urlDict);
            Assert.IsEmpty(urlContent.ToString());
        }

        [Test]
        public void ToStringTest()
        {
            const string expectedValue = "?key1=value1";
            var urlDict = new Dictionary<string, string> {{"key1", "value1"}};
            var urlContent = new UrlParameterEncodedContent(urlDict);
            Assert.AreEqual(expectedValue, urlContent.ToString());
        }
    }
}