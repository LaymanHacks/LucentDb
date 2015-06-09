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
    public class ConnectionApiControllerTests
    {
        
        private Mock<IConnectionRepository> _repository;

        private List<Connection> _repositoryList = new List<Connection>
        {
        //TODO Initialize test data
            new Connection()
        };

        private ConnectionApiController _target;
        
        [TestInitialize]
        public void Init()
        {
            _repository = new Mock<IConnectionRepository>();
            _target = new ConnectionApiController(_repository.Object)
            {
                Request = new HttpRequestMessage { RequestUri = new Uri("http://localhost/api/Connections") }
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
        public void Update_Should_Update_A_Connection() 
        {
            _repository
                 .Setup(it => it.Update(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<Boolean>(), It.IsAny<Int32>()))
                 .Callback<String, String, Boolean, Int32>((name, connectionString, isActive, connectionId) => 
            { 
                 var tConnection = _repositoryList.Find(x => x.ConnectionId==connectionId);
                 tConnection.Name = name; 
                 tConnection.ConnectionString = connectionString; 
                 tConnection.IsActive = isActive; 
            });
            var tempConnection = _repositoryList.Find(x => x.ConnectionId==connectionId);
            var testConnection = new Connection {
                 ConnectionId = tempConnection.ConnectionId, 
                 Name = tempConnection.Name, 
                 ConnectionString = tempConnection.ConnectionString, 
                 IsActive = tempConnection.IsActive};
            
            //TODO change something on testConnection
            //testConnection.oldValue = newValue; 
            _target.Update(testConnection);
            //Assert.AreEqual(newValue, _repositoryList.Find(x => x.ConnectionId==1).oldValue);
            //TODO fail until we update the test above
            Assert.Fail();
        }

        [TestMethod()]
        public void Delete_Should_Delete_A_Connection() 
        {
            _repository
                 .Setup(it => it.Delete(It.IsAny<Int32>()))  
                 .Callback<Int32>((connectionId) => 
                 { 
                      var i = _repositoryList.FindIndex(q => q.ConnectionId==connectionId);
                      _repositoryList.RemoveAt(i);
                 });
            var iniCount = _repositoryList.Count();
            HttpResponseMessage result = _target.Delete(1);
            Assert.AreEqual(iniCount - 1, _repositoryList.Count());
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [TestMethod()]
        public void Insert_Should_Insert_A_Connection() 
        {
            _repository
                 .Setup(it => it.Insert(It.IsAny<String>(), It.IsAny<String>(), It.IsAny<Boolean>()))
                 .Returns<String, String, Boolean>((name, connectionString, isActive) => 
            { 
                 _repositoryList.Add(new  Connection (name, connectionString, isActive));
            });
            
            //TODO insert values 
            _target.Insert(new Connection (name, connectionString, isActive));
            //Assert.AreEqual(11, _repositoryList.Count());
            //TODO fail until we update the test above
            Assert.Fail();
        }

        [TestMethod()]
        public void GetDataPageableTest()
        {
            PagedResult<Connection> expectedResult;

            _repository
                 .Setup(it => it.GetDataPageable(It.IsAny<String>(), It.IsAny<Int32>(), It.IsAny<Int32>()))
                 .Returns<String, Int32, Int32>((sortExpression, page, pageSize) => 
                 { 
                      var query = _repositoryList;
                      switch (sortExpression)
                      {
                          case  "ConnectionId":
                              query = new List<Connection>(query.OrderBy(q => q.ConnectionId));
                              break;
                          case  "Name":
                              query = new List<Connection>(query.OrderBy(q => q.Name));
                              break;
                          case  "ConnectionString":
                              query = new List<Connection>(query.OrderBy(q => q.ConnectionString));
                              break;
                          case  "IsActive":
                              query = new List<Connection>(query.OrderBy(q => q.IsActive));
                              break;                      }
                      return query.Take(pageSize).Skip((page-1)*pageSize).ToList();
                 });

            _repository
                 .Setup(it => it.GetRowCount())
                 .Returns(_repositoryList.Count);

            var result = _target.GetDataPageable("ConnectionId", 1, 2);
            Assert.IsTrue(result.TryGetContentValue(out expectedResult));
            Assert.AreEqual(_repositoryList.Take(2).ToList().Count, expectedResult.Results.Count);
            Assert.AreEqual(_repositoryList.OrderBy(q => q.ConnectionId).FirstOrDefault().ConnectionId, expectedResult.Results.FirstOrDefault().ConnectionId);
        }

        [TestMethod()]
        public void GetDataByConnectionIdTest() 
        {
            _repository
                 .Setup(it => it.GetDataByConnectionId(It.IsAny<Int32>()))
                     .Returns<Int32>((connectionId) => 
                 { 
                      return _repositoryList.Where(x => x.ConnectionId==connectionId).ToList();
                 });
                
            var result = _target.GetDataByConnectionId(connectionIdValue).ToList();
             Assert.AreEqual(_repositoryList.Where(x => x.ConnectionId==connectionIdValue).ToList().Count, result.Count);
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
            PagedResult<Connection> expectedResult;

            _repository
                 .Setup(it => it.GetActiveDataPageable(It.IsAny<String>(), It.IsAny<Int32>(), It.IsAny<Int32>()))
                 .Returns<String, Int32, Int32>((sortExpression, page, pageSize) => 
                 { 
                      var query = _repositoryList;
                      switch (sortExpression)
                      {
                          case  "ConnectionId":
                              query = new List<Connection>(query.OrderBy(q => q.ConnectionId));
                              break;
                          case  "Name":
                              query = new List<Connection>(query.OrderBy(q => q.Name));
                              break;
                          case  "ConnectionString":
                              query = new List<Connection>(query.OrderBy(q => q.ConnectionString));
                              break;
                          case  "IsActive":
                              query = new List<Connection>(query.OrderBy(q => q.IsActive));
                              break;                      }
                      return query.Take(pageSize).Skip((page-1)*pageSize).ToList();
                 });

            _repository
                 .Setup(it => it.GetActiveDataRowCount())
                 .Returns(_repositoryList.Count);

            var result = _target.GetActiveDataPageable("ConnectionId", 1, PageSizeValue);
            Assert.IsTrue(result.TryGetContentValue(out expectedResult));
            Assert.AreEqual(_repositoryList.Take(2).ToList().Count, expectedResult.Results.Count);
            Assert.AreEqual(_repositoryList.OrderBy(q => q.ConnectionId).FirstOrDefault().ConnectionId, expectedResult.Results.FirstOrDefault().ConnectionId);
        }

        [TestMethod()]
        public void GetConnectionsForProjectByProjectIdTest() 
        {
            _repository
                 .Setup(it => it.GetConnectionsForProjectByProjectId(It.IsAny<Int32>()))
                     .Returns<Int32>((projectId) => 
                 { 
                      return _repositoryList.Where(x => x.ProjectId==projectId).ToList();
                 });
                
            var result = _target.GetConnectionsForProjectByProjectId(projectIdValue).ToList();
             Assert.AreEqual(_repositoryList.Where(x => x.ProjectId==projectIdValue).ToList().Count, result.Count);
        }

        [TestMethod()]
        public void GetConnectionsForProjectByProjectIdPageableTest()
        {
            PagedResult<Connection> expectedResult;

            _repository
                 .Setup(it => it.GetConnectionsForProjectByProjectIdPageable(It.IsAny<Int32>(), It.IsAny<String>(), It.IsAny<Int32>(), It.IsAny<Int32>()))
                 .Returns<Int32, String, Int32, Int32>((projectId, sortExpression, page, pageSize) => 
                 { 
                      var query = _repositoryList;
                      switch (sortExpression)
                      {
                          case  "ConnectionId":
                              query = new List<Connection>(query.OrderBy(q => q.ConnectionId));
                              break;
                          case  "Name":
                              query = new List<Connection>(query.OrderBy(q => q.Name));
                              break;
                          case  "ConnectionString":
                              query = new List<Connection>(query.OrderBy(q => q.ConnectionString));
                              break;
                          case  "IsActive":
                              query = new List<Connection>(query.OrderBy(q => q.IsActive));
                              break;                      }
                      return query.Take(pageSize).Skip((page-1)*pageSize).ToList();
                 });

            _repository
                 .Setup(it => it.GetConnectionsForProjectByProjectIdRowCount(projectId))
                 .Returns(_repositoryList.Count);

            var result = _target.GetConnectionsForProjectByProjectIdPageable(ProjectIdValue, "ConnectionId", 1, PageSizeValue);
            Assert.IsTrue(result.TryGetContentValue(out expectedResult));
            Assert.AreEqual(_repositoryList.Take(2).ToList().Count, expectedResult.Results.Count);
            Assert.AreEqual(_repositoryList.OrderBy(q => q.ConnectionId).FirstOrDefault().ConnectionId, expectedResult.Results.FirstOrDefault().ConnectionId);
        }


    }
}
