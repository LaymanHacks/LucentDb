using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LucentDb.Data.Repository;
using LucentDb.Domain.Entities;

namespace LucentDb.Web.UI.Controllers.Api
{
    public class Project_ConnectionApiController : ApiController
    {
        private readonly IProject_ConnectionRepository _dbRepository;

        public Project_ConnectionApiController(IProject_ConnectionRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        [Route("api/project_Connection/all", Name = "Project_ConnectionGetDataRoute")]
        [HttpGet]
        public IQueryable<Project_Connection> GetData()
        {
            return _dbRepository.GetData().AsQueryable();
        }

        [Route("api/project_Connection", Name = "Project_ConnectionUpdateRoute")]
        [HttpPut]
        public void Update(Project_Connection project_Connection, int original_ProjectId, int original_ConnectionId)
        {
            _dbRepository.Update(project_Connection.ProjectId, project_Connection.ConnectionId, original_ProjectId,
                original_ConnectionId);
        }

        [Route("api/project_Connection", Name = "Project_ConnectionDeleteRoute")]
        [HttpDelete]
        public HttpResponseMessage Delete(int projectId, int connectionId)
        {
            try
            {
                _dbRepository.Delete(projectId, connectionId);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("api/project_Connection", Name = "Project_ConnectionInsertRoute")]
        [HttpPost]
        public Project_Connection Insert(Project_Connection project_Connection)
        {
            return _dbRepository.Insert(project_Connection.ProjectId, project_Connection.ConnectionId).FirstOrDefault();
        }

        [Route("api/project_Connection", Name = "Project_ConnectionGetDataPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataPageable(string sortExpression, int page, int pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetDataPageable(sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/project_Connection/all", Name = "Project_ConnectionGetDataByProjectIdConnectionIdRoute")]
        [HttpGet]
        public IQueryable<Project_Connection> GetDataByProjectIdConnectionId(int projectId, int connectionId)
        {
            return _dbRepository.GetDataByProjectIdConnectionId(projectId, connectionId).AsQueryable();
        }

        [Route("api/2connections/2{connectionId}/project_Connection/all",
            Name = "Project_ConnectionGetDataByConnectionIdRoute")]
        [HttpGet]
        public IQueryable<Project_Connection> GetDataByConnectionId(int connectionId)
        {
            return _dbRepository.GetDataByConnectionId(connectionId).AsQueryable();
        }

        [Route("api/2connections/2{connectionId}/project_Connection",
            Name = "Project_ConnectionGetDataByConnectionIdPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataByConnectionIdPageable(int connectionId, string sortExpression, int page,
            int pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetDataByConnectionIdPageable(connectionId, sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/2projects/2{projectId}/project_Connection/all", Name = "Project_ConnectionGetDataByProjectIdRoute")]
        [HttpGet]
        public IQueryable<Project_Connection> GetDataByProjectId(int projectId)
        {
            return _dbRepository.GetDataByProjectId(projectId).AsQueryable();
        }

        [Route("api/2projects/2{projectId}/project_Connection",
            Name = "Project_ConnectionGetDataByProjectIdPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataByProjectIdPageable(int projectId, string sortExpression, int page,
            int pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetDataByProjectIdPageable(projectId, sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }
    }
}