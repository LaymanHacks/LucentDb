using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LucentDb.Data.Repository;
using LucentDb.Domain.Entities;

namespace LucentDb.Web.UI.Controllers.Api
{
    public class RunHistoryApiController : ApiController
    {
        private readonly IRunHistoryRepository _dbRepository;

        public RunHistoryApiController(IRunHistoryRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        [Route("api/runHistories/all", Name = "RunHistoriesGetDataRoute")]
        [HttpGet]
        public IQueryable<RunHistory> GetData()
        {
            return _dbRepository.GetData().AsQueryable();
        }

        [Route("api/runHistories", Name = "RunHistoriesUpdateRoute")]
        [HttpPut]
        public void Update(RunHistory runHistory)
        {
            _dbRepository.Update(runHistory.TestId, runHistory.ProjectId, runHistory.GroupId, runHistory.ConnectionId,
                runHistory.RunDateTime, runHistory.TotalDuration, runHistory.IsValid, runHistory.RunLog, runHistory.Id);
        }

        [Route("api/runHistories", Name = "RunHistoriesDeleteRoute")]
        [HttpDelete]
        public HttpResponseMessage Delete(long id)
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

        [Route("api/runHistories", Name = "RunHistoriesInsertRoute")]
        [HttpPost]
        public long Insert(RunHistory runHistory)
        {
            return _dbRepository.Insert(runHistory.TestId, runHistory.ProjectId, runHistory.GroupId,
                runHistory.ConnectionId, runHistory.RunDateTime, runHistory.TotalDuration, runHistory.IsValid,
                runHistory.RunLog);
        }

        [Route("api/runHistories", Name = "RunHistoriesGetDataPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataPageable(string sortExpression, int page, int pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetDataPageable(sortExpression, page, pageSize);

            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/runHistories/{id}", Name = "RunHistoriesGetDataByIdRoute")]
        [HttpGet]
        public IQueryable<RunHistory> GetDataById(long id)
        {
            return _dbRepository.GetDataById(id).AsQueryable();
        }

        [Route("api/projects/{projectId}/runHistories/all", Name = "RunHistoriesGetDataByProjectIdRoute")]
        [HttpGet]
        public IQueryable<RunHistory> GetDataByProjectId(int projectId)
        {
            return _dbRepository.GetDataByProjectId(projectId).AsQueryable();
        }

        [Route("api/projects/{projectId}/runHistories", Name = "RunHistoriesGetDataByProjectIdPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataByProjectIdPageable(int projectId, string sortExpression, int page,
            int pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetDataByProjectIdPageable(projectId, sortExpression, page, pageSize);

            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/tests/{testId}/runHistories/all", Name = "RunHistoriesGetDataByTestIdRoute")]
        [HttpGet]
        public IQueryable<RunHistory> GetDataByTestId(int testId)
        {
            return _dbRepository.GetDataByTestId(testId).AsQueryable();
        }

        [Route("api/tests/{testId}/runHistories", Name = "RunHistoriesGetDataByTestIdPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataByTestIdPageable(int testId, string sortExpression, int page, int pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetDataByTestIdPageable(testId, sortExpression, page, pageSize);

            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/testGroups/{groupId}/runHistories/all", Name = "RunHistoriesGetDataByGroupIdRoute")]
        [HttpGet]
        public IQueryable<RunHistory> GetDataByGroupId(int groupId)
        {
            return _dbRepository.GetDataByGroupId(groupId).AsQueryable();
        }

        [Route("api/testGroups/{groupId}/runHistories", Name = "RunHistoriesGetDataByGroupIdPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataByGroupIdPageable(int groupId, string sortExpression, int page, int pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetDataByGroupIdPageable(groupId, sortExpression, page, pageSize);

            return Request.CreateResponse(HttpStatusCode.OK, results);
        }
    }
}