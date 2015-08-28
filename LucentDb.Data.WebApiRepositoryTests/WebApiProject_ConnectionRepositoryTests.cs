using LucentDb.Data.WebApiRepository;
using LucentDb.Domain.Entities;
using NUnit.Framework;

namespace LucentDb.Data.Web.Tests
{
    [TestFixture]
    public class WebApiProject_ConnectionRepositoryTests
    {
        [Test]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [Test]
        public void DeleteTest1()
        {
            Assert.Fail();
        }

        [Test]
        public void DisposeTest()
        {
            Assert.Fail();
        }

        [Test]
        public void GetDataByConnectionIdPageableTest()
        {
            Assert.Fail();
        }

        [Test]
        public void GetDataByConnectionIdTest()
        {
            Assert.Fail();
        }

        [Test]
        public void GetDataByProjectIdConnectionIdTest()
        {
            Assert.Fail();
        }

        [Test]
        public void GetDataByProjectIdPageableTest()
        {
            Assert.Fail();
        }

        [Test]
        public void GetDataByProjectIdTest()
        {
            Assert.Fail();
        }

        [Test]
        public void GetDataPageableTest()
        {
            Assert.Fail();
        }

        [Test]
        public void GetDataTest()
        {
            var temp = new WebApiProject_ConnectionRepository("http://localhost:60205/");
            var result = temp.GetData();
            Assert.IsNotEmpty(result);
        }

        [Test]
        public void InsertTest()
        {
            Assert.Fail();
        }

        [Test]
        public void InsertTest1()
        {
            Assert.Fail();
        }

        [Test]
        public void UpdateTest()
        {
            var temp = new WebApiProject_ConnectionRepository("http://localhost:60205/");
            temp.Update(new Project_Connection {ConnectionId = 1, ProjectId = 2}, 1, 1);
        }

        [Test]
        public void WebApiProject_ConnectionRepositoryTest()
        {
            Assert.Fail();
        }
    }
}