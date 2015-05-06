//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Generated by Merlin Version: 1.0.0.0
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using LucentDb.Data.Repository;
using LucentDb.Domain.Entities;
using LucentDb.Web.UI.Controllers.Api;

namespace LucentDb.Web.UI.Test.Controllers.Api
{
    [TestClass()]
    public class TestApiControllerTests
    {
        
        private Mock<ITestRepository> _repository;

        private List<Test> _repositoryList = new List<Test>
        {
        //TODO Initialize test data
            new Test()
        };

        private TestApiController _target;
        
        [TestInitialize]
        public void Init()
        {
            _repository = new Mock<ITestRepository>();
            _target = new TestApiController(_repository.Object)
            {
                Request = new HttpRequestMessage { RequestUri = new Uri("http://localhost/api/Tests") }
            };

            var config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            config.EnsureInitialized();

            _target.Request.SetConfiguration(config);
        }
   
                [TestMethod()]
        public void GetDataTest() 
        {
            _repository
                 .Setup(it => it.GetData())
                     .Returns(_repositoryList);
                
            var result = _target.GetData().ToList();
             Assert.AreEqual(_repositoryList.ToList().Count, result.Count);
        }

        [TestMethod()]
        public void Update_Should_Update_A_Test() 
        {
            _repository
                 .Setup(it => it.Update(It.IsAny<Int32>(), It.IsAny<Int32>(), It.IsAny<String>(), It.IsAny<Boolean>(), It.IsAny<Int32>()))
                 .Callback<Int32, Int32, String, Boolean, Int32>((projectId, testTypeId, name, isActive, id) => 
            { 
                 var tTest = _repositoryList.Find(x => x.Id==id);
                 tTest.ProjectId = projectId; 
                 tTest.TestTypeId = testTypeId; 
                 tTest.Name = name; 
                 tTest.IsActive = isActive; 
            });
            var tempTest = _repositoryList.Find(x => x.Id==id);
            var testTest = new Test {
                 Id = tempTest.Id, 
                 ProjectId = tempTest.ProjectId, 
                 TestTypeId = tempTest.TestTypeId, 
                 Name = tempTest.Name, 
                 IsActive = tempTest.IsActive};
            
            //TODO change something on testTest
            //testTest.oldValue = newValue; 
            _target.Update(testTest);
            //Assert.AreEqual(newValue, _repositoryList.Find(x => x.Id==1).oldValue);
            //TODO fail until we update the test above
            Assert.Fail();
        }

        [TestMethod()]
        public void Delete_Should_Delete_A_Test() 
        {
            _repository
                 .Setup(it => it.Delete(It.IsAny<Int32>()))  
                 .Callback<Int32>((id) => 
                 { 
                      var i = _repositoryList.FindIndex(q => q.Id==id);
                      _repositoryList.RemoveAt(i);
                 });
            var iniCount = _repositoryList.Count();
            HttpResponseMessage result = _target.Delete(1);
            Assert.AreEqual(iniCount - 1, _repositoryList.Count());
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [TestMethod()]
        public void Insert_Should_Insert_A_Test() 
        {
            _repository
                 .Setup(it => it.Insert(It.IsAny<Int32>(), It.IsAny<Int32>(), It.IsAny<String>(), It.IsAny<Boolean>()))
                 .Returns<Int32, Int32, String, Boolean>((projectId, testTypeId, name, isActive) => 
            { 
                 _repositoryList.Add(new  Test (projectId, testTypeId, name, isActive));
            });
            
            //TODO insert values 
            _target.Insert(new Test (projectId, testTypeId, name, isActive));
            //Assert.AreEqual(11, _repositoryList.Count());
            //TODO fail until we update the test above
            Assert.Fail();
        }

        [TestMethod()]
        public void GetDataPageableTest()
        {
            PagedResult<Test> expectedResult;

            _repository
                 .Setup(it => it.GetDataPageable(It.IsAny<String>(), It.IsAny<Int32>(), It.IsAny<Int32>()))
                 .Returns<String, Int32, Int32>((sortExpression, page, pageSize) => 
                 { 
                      var query = _repositoryList;
                      switch (sortExpression)
                      {
                          case  "Id":
                              query = new List<Test>(query.OrderBy(q => q.Id));
                              break;
                          case  "ProjectId":
                              query = new List<Test>(query.OrderBy(q => q.ProjectId));
                              break;
                          case  "TestTypeId":
                              query = new List<Test>(query.OrderBy(q => q.TestTypeId));
                              break;
                          case  "Name":
                              query = new List<Test>(query.OrderBy(q => q.Name));
                              break;
                          case  "IsActive":
                              query = new List<Test>(query.OrderBy(q => q.IsActive));
                              break;                      }
                      return query.Take(pageSize).Skip((page-1)*pageSize).ToList();
                 });

            _repository
                 .Setup(it => it.GetRowCount())
                 .Returns(_repositoryList.Count);

            var result = _target.GetDataPageable("Id", 1, 2);
            Assert.IsTrue(result.TryGetContentValue(out expectedResult));
            Assert.AreEqual(_repositoryList.Take(2).ToList().Count, expectedResult.Results.Count);
            Assert.AreEqual(_repositoryList.OrderBy(q => q.Id).FirstOrDefault().Id, expectedResult.Results.FirstOrDefault().Id);
        }

        [TestMethod()]
        public void GetDataByIdTest() 
        {
            _repository
                 .Setup(it => it.GetDataById(It.IsAny<Int32>()))
                     .Returns<Int32>((id) => 
                 { 
                      return _repositoryList.Where(x => x.Id==id).ToList();
                 });
                
            var result = _target.GetDataById(idValue).ToList();
             Assert.AreEqual(_repositoryList.Where(x => x.Id==idValue).ToList().Count, result.Count);
        }

        [TestMethod()]
        public void GetActiveDataTest() 
        {
            _repository
                 .Setup(it => it.GetActiveData())
                     .Returns(_repositoryList);
                
            var result = _target.GetActiveData().ToList();
             Assert.AreEqual(_repositoryList.ToList().Count, result.Count);
        }

        [TestMethod()]
        public void GetActiveDataPageableTest()
        {
            PagedResult<Test> expectedResult;

            _repository
                 .Setup(it => it.GetActiveDataPageable(It.IsAny<String>(), It.IsAny<Int32>(), It.IsAny<Int32>()))
                 .Returns<String, Int32, Int32>((sortExpression, page, pageSize) => 
                 { 
                      var query = _repositoryList;
                      switch (sortExpression)
                      {
                          case  "Id":
                              query = new List<Test>(query.OrderBy(q => q.Id));
                              break;
                          case  "ProjectId":
                              query = new List<Test>(query.OrderBy(q => q.ProjectId));
                              break;
                          case  "TestTypeId":
                              query = new List<Test>(query.OrderBy(q => q.TestTypeId));
                              break;
                          case  "Name":
                              query = new List<Test>(query.OrderBy(q => q.Name));
                              break;
                          case  "IsActive":
                              query = new List<Test>(query.OrderBy(q => q.IsActive));
                              break;                      }
                      return query.Take(pageSize).Skip((page-1)*pageSize).ToList();
                 });

            _repository
                 .Setup(it => it.GetActiveDataRowCount())
                 .Returns(_repositoryList.Count);

            var result = _target.GetActiveDataPageable("Id", 1, PageSizeValue);
            Assert.IsTrue(result.TryGetContentValue(out expectedResult));
            Assert.AreEqual(_repositoryList.Take(2).ToList().Count, expectedResult.Results.Count);
            Assert.AreEqual(_repositoryList.OrderBy(q => q.Id).FirstOrDefault().Id, expectedResult.Results.FirstOrDefault().Id);
        }

        [TestMethod()]
        public void GetDataByProjectIdTest() 
        {
            _repository
                 .Setup(it => it.GetDataByProjectId(It.IsAny<Int32>()))
                     .Returns<Int32>((projectId) => 
                 { 
                      return _repositoryList.Where(x => x.ProjectId==projectId).ToList();
                 });
                
            var result = _target.GetDataByProjectId(projectIdValue).ToList();
             Assert.AreEqual(_repositoryList.Where(x => x.ProjectId==projectIdValue).ToList().Count, result.Count);
        }

        [TestMethod()]
        public void GetDataByProjectIdPageableTest()
        {
            PagedResult<Test> expectedResult;

            _repository
                 .Setup(it => it.GetDataByProjectIdPageable(It.IsAny<Int32>(), It.IsAny<String>(), It.IsAny<Int32>(), It.IsAny<Int32>()))
                 .Returns<Int32, String, Int32, Int32>((projectId, sortExpression, page, pageSize) => 
                 { 
                      var query = _repositoryList.Where(x => x.ProjectId==projectId);
                      switch (sortExpression)
                      {
                          case  "Id":
                              query = new List<Test>(query.OrderBy(q => q.Id));
                              break;
                          case  "ProjectId":
                              query = new List<Test>(query.OrderBy(q => q.ProjectId));
                              break;
                          case  "TestTypeId":
                              query = new List<Test>(query.OrderBy(q => q.TestTypeId));
                              break;
                          case  "Name":
                              query = new List<Test>(query.OrderBy(q => q.Name));
                              break;
                          case  "IsActive":
                              query = new List<Test>(query.OrderBy(q => q.IsActive));
                              break;                      }
                      return query.Take(pageSize).Skip((page-1)*pageSize).ToList();
                 });

            _repository
                 .Setup(it => it.GetDataByProjectIdRowCount(projectId))
                 .Returns(_repositoryList.Count);

            var result = _target.GetDataByProjectIdPageable(ProjectIdValue, "Id", 1, 2);
            Assert.IsTrue(result.TryGetContentValue(out expectedResult));
            Assert.AreEqual(_repositoryList.Where(x => x.ProjectId==projectId).Take(2).ToList().Count, expectedResult.Results.Count);
            Assert.AreEqual(_repositoryList.Where(x => x.ProjectId==projectId).OrderBy(q => q.Id).FirstOrDefault().Id, expectedResult.Results.FirstOrDefault().Id);
        }

        [TestMethod()]
        public void GetActiveDataByProjectIdTest() 
        {
            _repository
                 .Setup(it => it.GetActiveDataByProjectId(It.IsAny<Int32>()))
                     .Returns<Int32>((projectId) => 
                 { 
                      return _repositoryList.Where(x => x.ProjectId==projectId).ToList();
                 });
                
            var result = _target.GetActiveDataByProjectId(projectIdValue).ToList();
             Assert.AreEqual(_repositoryList.Where(x => x.ProjectId==projectIdValue).ToList().Count, result.Count);
        }

        [TestMethod()]
        public void GetActiveDataByProjectIdPageableTest()
        {
            PagedResult<Test> expectedResult;

            _repository
                 .Setup(it => it.GetActiveDataByProjectIdPageable(It.IsAny<Int32>(), It.IsAny<String>(), It.IsAny<Int32>(), It.IsAny<Int32>()))
                 .Returns<Int32, String, Int32, Int32>((projectId, sortExpression, page, pageSize) => 
                 { 
                      var query = _repositoryList;
                      switch (sortExpression)
                      {
                          case  "Id":
                              query = new List<Test>(query.OrderBy(q => q.Id));
                              break;
                          case  "ProjectId":
                              query = new List<Test>(query.OrderBy(q => q.ProjectId));
                              break;
                          case  "TestTypeId":
                              query = new List<Test>(query.OrderBy(q => q.TestTypeId));
                              break;
                          case  "Name":
                              query = new List<Test>(query.OrderBy(q => q.Name));
                              break;
                          case  "IsActive":
                              query = new List<Test>(query.OrderBy(q => q.IsActive));
                              break;                      }
                      return query.Take(pageSize).Skip((page-1)*pageSize).ToList();
                 });

            _repository
                 .Setup(it => it.GetActiveDataByProjectIdRowCount(projectId))
                 .Returns(_repositoryList.Count);

            var result = _target.GetActiveDataByProjectIdPageable(ProjectIdValue, "Id", 1, PageSizeValue);
            Assert.IsTrue(result.TryGetContentValue(out expectedResult));
            Assert.AreEqual(_repositoryList.Take(2).ToList().Count, expectedResult.Results.Count);
            Assert.AreEqual(_repositoryList.OrderBy(q => q.Id).FirstOrDefault().Id, expectedResult.Results.FirstOrDefault().Id);
        }

        [TestMethod()]
        public void GetDataByTestTypeIdTest() 
        {
            _repository
                 .Setup(it => it.GetDataByTestTypeId(It.IsAny<Int32>()))
                     .Returns<Int32>((testTypeId) => 
                 { 
                      return _repositoryList.Where(x => x.TestTypeId==testTypeId).ToList();
                 });
                
            var result = _target.GetDataByTestTypeId(testTypeIdValue).ToList();
             Assert.AreEqual(_repositoryList.Where(x => x.TestTypeId==testTypeIdValue).ToList().Count, result.Count);
        }

        [TestMethod()]
        public void GetDataByTestTypeIdPageableTest()
        {
            PagedResult<Test> expectedResult;

            _repository
                 .Setup(it => it.GetDataByTestTypeIdPageable(It.IsAny<Int32>(), It.IsAny<String>(), It.IsAny<Int32>(), It.IsAny<Int32>()))
                 .Returns<Int32, String, Int32, Int32>((testTypeId, sortExpression, page, pageSize) => 
                 { 
                      var query = _repositoryList.Where(x => x.TestTypeId==testTypeId);
                      switch (sortExpression)
                      {
                          case  "Id":
                              query = new List<Test>(query.OrderBy(q => q.Id));
                              break;
                          case  "ProjectId":
                              query = new List<Test>(query.OrderBy(q => q.ProjectId));
                              break;
                          case  "TestTypeId":
                              query = new List<Test>(query.OrderBy(q => q.TestTypeId));
                              break;
                          case  "Name":
                              query = new List<Test>(query.OrderBy(q => q.Name));
                              break;
                          case  "IsActive":
                              query = new List<Test>(query.OrderBy(q => q.IsActive));
                              break;                      }
                      return query.Take(pageSize).Skip((page-1)*pageSize).ToList();
                 });

            _repository
                 .Setup(it => it.GetDataByTestTypeIdRowCount(testTypeId))
                 .Returns(_repositoryList.Count);

            var result = _target.GetDataByTestTypeIdPageable(TestTypeIdValue, "Id", 1, 2);
            Assert.IsTrue(result.TryGetContentValue(out expectedResult));
            Assert.AreEqual(_repositoryList.Where(x => x.TestTypeId==testTypeId).Take(2).ToList().Count, expectedResult.Results.Count);
            Assert.AreEqual(_repositoryList.Where(x => x.TestTypeId==testTypeId).OrderBy(q => q.Id).FirstOrDefault().Id, expectedResult.Results.FirstOrDefault().Id);
        }

        [TestMethod()]
        public void GetActiveDataByTestTypeIdTest() 
        {
            _repository
                 .Setup(it => it.GetActiveDataByTestTypeId(It.IsAny<Int32>()))
                     .Returns<Int32>((testTypeId) => 
                 { 
                      return _repositoryList.Where(x => x.TestTypeId==testTypeId).ToList();
                 });
                
            var result = _target.GetActiveDataByTestTypeId(testTypeIdValue).ToList();
             Assert.AreEqual(_repositoryList.Where(x => x.TestTypeId==testTypeIdValue).ToList().Count, result.Count);
        }

        [TestMethod()]
        public void GetActiveDataByTestTypeIdPageableTest()
        {
            PagedResult<Test> expectedResult;

            _repository
                 .Setup(it => it.GetActiveDataByTestTypeIdPageable(It.IsAny<Int32>(), It.IsAny<String>(), It.IsAny<Int32>(), It.IsAny<Int32>()))
                 .Returns<Int32, String, Int32, Int32>((testTypeId, sortExpression, page, pageSize) => 
                 { 
                      var query = _repositoryList;
                      switch (sortExpression)
                      {
                          case  "Id":
                              query = new List<Test>(query.OrderBy(q => q.Id));
                              break;
                          case  "ProjectId":
                              query = new List<Test>(query.OrderBy(q => q.ProjectId));
                              break;
                          case  "TestTypeId":
                              query = new List<Test>(query.OrderBy(q => q.TestTypeId));
                              break;
                          case  "Name":
                              query = new List<Test>(query.OrderBy(q => q.Name));
                              break;
                          case  "IsActive":
                              query = new List<Test>(query.OrderBy(q => q.IsActive));
                              break;                      }
                      return query.Take(pageSize).Skip((page-1)*pageSize).ToList();
                 });

            _repository
                 .Setup(it => it.GetActiveDataByTestTypeIdRowCount(testTypeId))
                 .Returns(_repositoryList.Count);

            var result = _target.GetActiveDataByTestTypeIdPageable(TestTypeIdValue, "Id", 1, PageSizeValue);
            Assert.IsTrue(result.TryGetContentValue(out expectedResult));
            Assert.AreEqual(_repositoryList.Take(2).ToList().Count, expectedResult.Results.Count);
            Assert.AreEqual(_repositoryList.OrderBy(q => q.Id).FirstOrDefault().Id, expectedResult.Results.FirstOrDefault().Id);
        }


    }
}
