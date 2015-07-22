
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LucentDb.Data.DbCommandProvider;
using LucentDb.Data.Repository;
using LucentDb.Domain.Entities;

namespace LucentDb.Web.UI.Controllers.Api
{
    public class TestGroupApiController : ApiController
    {
        private readonly ITestGroupRepository _dbRepository;

        public TestGroupApiController(ITestGroupRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
   
        [Route("api/testGroups/all", Name = "TestGroupsGetDataRoute")]
        [HttpGet]
        public IQueryable<TestGroup> GetData() 
        {
            return _dbRepository.GetData().AsQueryable();
        }

        [Route("api/testGroups", Name = "TestGroupsUpdateRoute")]
        [HttpPut]
        public void Update(TestGroup testGroup)
        {
            _dbRepository.Update( (Int32)testGroup.ProjectId,  (string)testGroup.Name,  (bool)testGroup.IsActive,  (Int32)testGroup.Id);
          }

        [Route("api/testGroups", Name = "TestGroupsDeleteRoute")]
        [HttpDelete]
        public HttpResponseMessage Delete(Int32 id)
        {
            try
            {
                 _dbRepository.Delete(id);
                 return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                 return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("api/testGroups", Name = "TestGroupsInsertRoute")]
        [HttpPost]
        public Int32 Insert(TestGroup testGroup)
        {
             return _dbRepository.Insert( (Int32)testGroup.ProjectId,  (string)testGroup.Name,  (bool)testGroup.IsActive);
          }

        [Route("api/testGroups", Name = "TestGroupsGetDataPageableRoute")]
        [HttpGet]
        public  HttpResponseMessage  GetDataPageable(String sortExpression, Int32 page, Int32 pageSize) 
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results =_dbRepository.GetDataPageable(sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/testGroups/{id}", Name = "TestGroupsGetDataByIdRoute")]
        [HttpGet]
        public IQueryable<TestGroup> GetDataById(Int32 id) 
        {
            return _dbRepository.GetDataById(id).AsQueryable();
        }

        [Route("api/testGroups/all/active", Name = "TestGroupsGetActiveDataRoute")]
        [HttpGet]
        public IQueryable<TestGroup> GetActiveData() 
        {
            return _dbRepository.GetActiveData().AsQueryable();
        }

        [Route("api/testGroups/active", Name = "TestGroupsGetActiveDataPageableRoute")]
        [HttpGet]
        public  HttpResponseMessage  GetActiveDataPageable(String sortExpression, Int32 page, Int32 pageSize) 
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results =_dbRepository.GetActiveDataPageable(sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/projects/{projectId}/testGroups/all", Name = "TestGroupsGetDataByProjectIdRoute")]
        [HttpGet]
        public IQueryable<TestGroup> GetDataByProjectId(Int32 projectId) 
        {
            return _dbRepository.GetDataByProjectId(projectId).AsQueryable();
        }

        [Route("api/projects/{projectId}/testGroups", Name = "TestGroupsGetDataByProjectIdPageableRoute")]
        [HttpGet]
        public  HttpResponseMessage  GetDataByProjectIdPageable(Int32 projectId, String sortExpression, Int32 page, Int32 pageSize) 
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results =_dbRepository.GetDataByProjectIdPageable(projectId, sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/projects/{projectId}/testGroups/all/active", Name = "TestGroupsGetActiveDataByProjectIdRoute")]
        [HttpGet]
        public IQueryable<TestGroup> GetActiveDataByProjectId(Int32 projectId) 
        {
            return _dbRepository.GetActiveDataByProjectId(projectId).AsQueryable();
        }

        [Route("api/projects/{projectId}/testGroups/active", Name = "TestGroupsGetActiveDataByProjectIdPageableRoute")]
        [HttpGet]
        public  HttpResponseMessage  GetActiveDataByProjectIdPageable(Int32 projectId, String sortExpression, Int32 page, Int32 pageSize) 
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results =_dbRepository.GetActiveDataByProjectIdPageable(projectId, sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }


    }
}
