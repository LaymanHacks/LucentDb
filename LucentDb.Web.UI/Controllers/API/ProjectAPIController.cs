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
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LucentDb.Data.Repository;
using LucentDb.Domain.Entities;

namespace LucentDb.Web.UI.Controllers.Api
{
    public class ProjectApiController : ApiController
    {
        private readonly IProjectRepository _dbRepository;

        public ProjectApiController(IProjectRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        [Route("api/projects", Name = "ProjectsDeleteRoute")]
        [HttpDelete]
        public HttpResponseMessage Delete(int projectId)
        {
            try
            {
                _dbRepository.Delete(projectId);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("api/projects/all/active", Name = "ProjectsGetActiveDataRoute")]
        [HttpGet]
        public IQueryable<Project> GetActiveData()
        {
            return _dbRepository.GetActiveData().AsQueryable();
        }

        [Route("api/projects/active", Name = "ProjectsGetActiveDataPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetActiveDataPageable(string sortExpression, int page, int pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetActiveDataPageable(sortExpression, page, pageSize);
            var totalCount = _dbRepository.GetActiveDataRowCount();
            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "ProjectsGetActiveDataPageableRoute", page,
                pageSize, totalCount, results);
            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }

        [Route("api/projects/all", Name = "ProjectsGetDataRoute")]
        [HttpGet]
        public IQueryable<Project> GetData()
        {
            return _dbRepository.GetData().AsQueryable();
        }

        [Route("api/projects", Name = "ProjectsGetDataByProjectIdRoute")]
        [HttpGet]
        public IQueryable<Project> GetDataByProjectId(int projectId)
        {
            return _dbRepository.GetDataByProjectId(projectId).AsQueryable();
        }

        [Route("api/projects", Name = "ProjectsGetDataPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataPageable(string sortExpression, int page, int pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetDataPageable(sortExpression, page, pageSize);
            var totalCount = _dbRepository.GetRowCount();
            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "ProjectsGetDataPageableRoute", page,
                pageSize, totalCount, results);
            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }

        [Route("api/connections/{connectionId}/projects/all",
            Name = "ProjectsGetProjectsForConnectionByConnectionIdRoute")]
        [HttpGet]
        public IQueryable<Project> GetProjectsForConnectionByConnectionId(int connectionId)
        {
            return _dbRepository.GetProjectsForConnectionByConnectionId(connectionId).AsQueryable();
        }

        [Route("api/connections/{connectionId}/projects",
            Name = "ProjectsGetProjectsForConnectionByConnectionIdPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetProjectsForConnectionByConnectionIdPageable(int connectionId,
            string sortExpression, int page, int pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetProjectsForConnectionByConnectionIdPageable(connectionId, sortExpression,
                page, pageSize);
            var totalCount = _dbRepository.GetProjectsForConnectionByConnectionIdRowCount(connectionId);
            var pagedResults = PagedResultHelper.CreatePagedResult(Request,
                "ProjectsGetProjectsForConnectionByConnectionIdPageableRoute", page,
                pageSize, totalCount, results);
            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }

        [Route("api/projects", Name = "ProjectsInsertRoute")]
        [HttpPost]
        public int Insert(Project project)
        {
            return _dbRepository.Insert(project.Name, project.IsActive);
        }

        [Route("api/projects", Name = "ProjectsUpdateRoute")]
        [HttpPut]
        public void Update(Project project)
        {
            _dbRepository.Update(project.Name, project.IsActive, project.ProjectId);
        }
    }
}