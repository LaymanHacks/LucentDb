using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LucentDb.Data.Repository;
using LucentDb.Domain.Entities;

namespace LucentDb.Web.UI.Controllers.Api
{
    public class TestApiController : ApiController
    {
        private readonly ITestRepository _dbRepository;

        public TestApiController(ITestRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        [Route("api/tests/all", Name = "TestsGetDataRoute")]
        [HttpGet]
        public IQueryable<Test> GetData()
        {
            return _dbRepository.GetData().AsQueryable();
        }

        [Route("api/tests", Name = "TestsUpdateRoute")]
        [HttpPut]
        public void Update(Test test)
        {
            _dbRepository.Update(test.TestTypeId, test.TestValueTypeId, test.ProjectId, test.GroupId, test.Name,
                test.TestValue, test.IsActive,
                test.Id);
        }

        [Route("api/tests", Name = "TestsDeleteRoute")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
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

        [Route("api/tests", Name = "TestsInsertRoute")]
        [HttpPost]
        public int Insert(Test test)
        {
            return _dbRepository.Insert(test.TestTypeId, test.TestValueTypeId, test.ProjectId, test.GroupId, test.Name,
                test.TestValue,
                test.IsActive);
        }

        [Route("api/tests", Name = "TestsGetDataPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataPageable(string sortExpression, int page, int pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetDataPageable(sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/tests/{id}", Name = "TestsGetDataByIdRoute")]
        [HttpGet]
        public IQueryable<Test> GetDataById(int id)
        {
            return _dbRepository.GetDataById(id).AsQueryable();
        }

        [Route("api/tests/all/active", Name = "TestsGetActiveDataRoute")]
        [HttpGet]
        public IQueryable<Test> GetActiveData()
        {
            return _dbRepository.GetActiveData().AsQueryable();
        }

        [Route("api/tests/active", Name = "TestsGetActiveDataPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetActiveDataPageable(string sortExpression, int page, int pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetActiveDataPageable(sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/projects/{projectId}/tests/all", Name = "TestsGetDataByProjectIdRoute")]
        [HttpGet]
        public IQueryable<Test> GetDataByProjectId(int projectId)
        {
            return _dbRepository.GetDataByProjectId(projectId).AsQueryable();
        }

        [Route("api/projects/{projectId}/tests", Name = "TestsGetDataByProjectIdPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataByProjectIdPageable(int projectId, string sortExpression, int page,
            int pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetDataByProjectIdPageable(projectId, sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/projects/{projectId}/tests/all/active", Name = "TestsGetActiveDataByProjectIdRoute")]
        [HttpGet]
        public IQueryable<Test> GetActiveDataByProjectId(int projectId)
        {
            return _dbRepository.GetActiveDataByProjectId(projectId).AsQueryable();
        }

        [Route("api/projects/{projectId}/tests/active", Name = "TestsGetActiveDataByProjectIdPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetActiveDataByProjectIdPageable(int projectId, string sortExpression, int page,
            int pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetActiveDataByProjectIdPageable(projectId, sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/testGroups/{groupId}/tests/all", Name = "TestsGetDataByGroupIdRoute")]
        [HttpGet]
        public IQueryable<Test> GetDataByGroupId(int groupId)
        {
            return _dbRepository.GetDataByGroupId(groupId).AsQueryable();
        }

        [Route("api/testGroups/{groupId}/tests", Name = "TestsGetDataByGroupIdPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataByGroupIdPageable(int groupId, string sortExpression, int page, int pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetDataByGroupIdPageable(groupId, sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/testGroups/{groupId}/tests/all/active", Name = "TestsGetActiveDataByGroupIdRoute")]
        [HttpGet]
        public IQueryable<Test> GetActiveDataByGroupId(int groupId)
        {
            return _dbRepository.GetActiveDataByGroupId(groupId).AsQueryable();
        }

        [Route("api/testGroups/{groupId}/tests/active", Name = "TestsGetActiveDataByGroupIdPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetActiveDataByGroupIdPageable(int groupId, string sortExpression, int page,
            int pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetActiveDataByGroupIdPageable(groupId, sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/testTypes/{testTypeId}/tests/all", Name = "TestsGetDataByTestTypeIdRoute")]
        [HttpGet]
        public IQueryable<Test> GetDataByTestTypeId(int testTypeId)
        {
            return _dbRepository.GetDataByTestTypeId(testTypeId).AsQueryable();
        }

        [Route("api/testTypes/{testTypeId}/tests", Name = "TestsGetDataByTestTypeIdPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataByTestTypeIdPageable(int testTypeId, string sortExpression, int page,
            int pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetDataByTestTypeIdPageable(testTypeId, sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/testTypes/{testTypeId}/tests/all/active", Name = "TestsGetActiveDataByTestTypeIdRoute")]
        [HttpGet]
        public IQueryable<Test> GetActiveDataByTestTypeId(int testTypeId)
        {
            return _dbRepository.GetActiveDataByTestTypeId(testTypeId).AsQueryable();
        }

        [Route("api/testTypes/{testTypeId}/tests/active", Name = "TestsGetActiveDataByTestTypeIdPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetActiveDataByTestTypeIdPageable(int testTypeId, string sortExpression, int page,
            int pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetActiveDataByTestTypeIdPageable(testTypeId, sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }
    }
}