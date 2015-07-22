using LucentDb.Data.WebApiRepository;
using NUnit.Framework;

namespace LucentDb.Data.Web.Tests
{
    [TestFixture()]
    public class WebApiTestRepositoryTests
    {
        [Test()]
        public void WebApiTestRepositoryTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void DisposeTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void GetDataTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void UpdateTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void UpdateTest1()
        {
            Assert.Fail();
        }

        [Test()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void DeleteTest1()
        {
            Assert.Fail();
        }

        [Test()]
        public void InsertTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void InsertTest1()
        {
            Assert.Fail();
        }

        [Test()]
        public void GetDataPageableTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void GetDataByIdTest()
        {
            var repo = new WebApiTestRepository("http://localhost:60205/");
          var tObject =  repo.GetDataById(1);
            
            Assert.AreNotEqual(0,tObject.Count);
        }

        [Test()]
        public void GetActiveDataTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void GetActiveDataPageableTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void GetDataByProjectIdTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void GetDataByProjectIdPageableTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void GetActiveDataByProjectIdTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void GetActiveDataByProjectIdPageableTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void GetDataByGroupIdTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void GetDataByGroupIdPageableTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void GetActiveDataByGroupIdTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void GetActiveDataByGroupIdPageableTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void GetDataByTestTypeIdTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void GetDataByTestTypeIdPageableTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void GetActiveDataByTestTypeIdTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void GetActiveDataByTestTypeIdPageableTest()
        {
            Assert.Fail();
        }
    }
}
