
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using LucentDb.Data.Repository;
//using LucentDb.Domain.Entities;
//using LucentDb.Web.UI.Controllers.Api;
//using Moq;
//using NUnit.Framework;

//namespace LucentDb.Web.UI.Test.Controllers.Api
//{
//    [TestFixture()]
//    public class AssertTypeApiControllerTests
//    {
        
//        private Mock<IAssertTypeRepository> _repository;

//        private List<AssertType> _repositoryList = new List<AssertType>
//        {
//        TODO Initialize test data
//            new AssertType()
//        };

//        private AssertTypeApiController _target;
        
//        [TestFixtureSetUp]
//        public void Init()
//        {
//            _repository = new Mock<IAssertTypeRepository>();
//            _target = new AssertTypeApiController(_repository.Object)
//            {
//                Request = new HttpRequestMessage { RequestUri = new Uri("http://localhost/api/AssertTypes") }
//            };

//            var config = new HttpConfiguration();

//            config.MapHttpAttributeRoutes();
//            config.EnsureInitialized();

//            _target.Request.SetConfiguration(config);
//        }
   
//                [Test()]
//        public void GetDataTest() 
//        {
//            _repository
//                 .Setup(it => it.GetData())
//                     .Returns(_repositoryList);
                
//            var result = _target.GetData().ToList();
//             Assert.AreEqual(_repositoryList.ToList().Count, result.Count);
//        }

//        [Test()]
//        public void Update_Should_Update_An_AssertType() 
//        {
//            _repository
//                 .Setup(it => it.Update(It.IsAny<String>(), It.IsAny<Int32>()))
//                 .Callback<String, Int32>((name, id) => 
//            { 
//                 var tAssertType = _repositoryList.Find(x => x.Id==id);
//                 tAssertType.Name = name; 
//            });
//            var tempAssertType = _repositoryList.Find(x => x.Id==id);
//            var testAssertType = new AssertType {
//                 Id = tempAssertType.Id, 
//                 Name = tempAssertType.Name};
            
//            TODO change something on testAssertType
//            testAssertType.oldValue = newValue; 
//            _target.Update(testAssertType);
//            Assert.AreEqual(newValue, _repositoryList.Find(x => x.Id==1).oldValue);
//            TODO fail until we update the test above
//            Assert.Fail();
//        }

//        [Test()]
//        public void Delete_Should_Delete_A_AssertType() 
//        {
//            _repository
//                 .Setup(it => it.Delete(It.IsAny<Int32>()))  
//                 .Callback<Int32>((id) => 
//                 { 
//                      var i = _repositoryList.FindIndex(q => q.Id==id);
//                      _repositoryList.RemoveAt(i);
//                 });
//            var iniCount = _repositoryList.Count();
//            HttpResponseMessage result = _target.Delete(1);
//            Assert.AreEqual(iniCount - 1, _repositoryList.Count());
//            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
//        }

//        [Test()]
//        public void Insert_Should_Insert_A_AssertType() 
//        {
           
//            _repository
//                 .Setup(it => it.Insert(It.IsAny<String>()))
//                 .Returns<int>((name) =>
//                 {
//                     _repositoryList.Add(new  AssertType (name));
//                     return -1;
//                 });
            
//            TODO insert values 
//            _target.Insert(new AssertType (name));
//            Assert.AreEqual(11, _repositoryList.Count());
//            TODO fail until we update the test above
//            Assert.Fail();
//        }

//        [Test()]
//        public void GetDataPageableTest()
//        {
//            PagedResult<AssertType> expectedResult;

//            _repository
//                 .Setup(it => it.GetDataPageable(It.IsAny<String>(), It.IsAny<Int32>(), It.IsAny<Int32>()))
//                 .Returns<String, Int32, Int32>((sortExpression, page, pageSize) => 
//                 { 
//                      var query = _repositoryList;
//                      switch (sortExpression)
//                      {
//                          case  "Id":
//                              query = new List<AssertType>(query.OrderBy(q => q.Id));
//                              break;
//                          case  "Name":
//                              query = new List<AssertType>(query.OrderBy(q => q.Name));
//                              break;                      }
//                      return query.Take(pageSize).Skip((page-1)*pageSize).ToList();
//                 });

//            _repository
//                 .Setup(it => it.GetRowCount())
//                 .Returns(_repositoryList.Count);

//            var result = _target.GetDataPageable("Id", 1, 2);
//            Assert.IsTrue(result.TryGetContentValue(out expectedResult));
//            Assert.AreEqual(_repositoryList.Take(2).ToList().Count, expectedResult.Results.Count);
//            Assert.AreEqual(_repositoryList.OrderBy(q => q.Id).FirstOrDefault().Id, expectedResult.Results.FirstOrDefault().Id);
//        }

//        [Test()]
//        public void GetDataByIdTest() 
//        {
//            _repository
//                 .Setup(it => it.GetDataById(It.IsAny<Int32>()))
//                     .Returns<Int32>((id) => 
//                 { 
//                      return _repositoryList.Where(x => x.Id==id).ToList();
//                 });

//            int idValue;
//            var result = _target.GetDataById(idValue).ToList();
//             Assert.AreEqual(_repositoryList.Where(x => x.Id==idValue).ToList().Count, result.Count);
//        }


//    }
//}
