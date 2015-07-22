
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
    public class ProjectApiController : ApiController
    {
        private readonly IProjectRepository _dbRepository;

        public ProjectApiController(IProjectRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
   
        [Route("api/projects/all", Name = "ProjectsGetDataRoute")]
        [HttpGet]
        public IQueryable<Project> GetData() 
        {
            return _dbRepository.GetData().AsQueryable();
        }

        [Route("api/projects", Name = "ProjectsUpdateRoute")]
        [HttpPut]
        public void Update(Project project)
        {
            _dbRepository.Update(project.Name,  (bool)project.IsActive,  (Int32)project.ProjectId);
          }

        [Route("api/projects", Name = "ProjectsDeleteRoute")]
        [HttpDelete]
        public HttpResponseMessage Delete(Int32 projectId)
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

        [Route("api/projects", Name = "ProjectsInsertRoute")]
        [HttpPost]
        public Int32 Insert(Project project)
        {
             return _dbRepository.Insert(project.Name,  (bool)project.IsActive);
          }

        [Route("api/projects", Name = "ProjectsGetDataPageableRoute")]
        [HttpGet]
        public  HttpResponseMessage  GetDataPageable(String sortExpression, Int32 page, Int32 pageSize) 
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results =_dbRepository.GetDataPageable(sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/projects/{projectId}", Name = "ProjectsGetDataByProjectIdRoute")]
        [HttpGet]
        public IQueryable<Project> GetDataByProjectId(Int32 projectId) 
        {
            return _dbRepository.GetDataByProjectId(projectId).AsQueryable();
        }

        [Route("api/projects/all/active", Name = "ProjectsGetActiveDataRoute")]
        [HttpGet]
        public IQueryable<Project> GetActiveData() 
        {
            return _dbRepository.GetActiveData().AsQueryable();
        }

        [Route("api/projects/active", Name = "ProjectsGetActiveDataPageableRoute")]
        [HttpGet]
        public  HttpResponseMessage  GetActiveDataPageable(String sortExpression, Int32 page, Int32 pageSize) 
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results =_dbRepository.GetActiveDataPageable(sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/connections/{connectionId}/projects/all", Name = "ProjectsGetProjectsForConnectionByConnectionIdRoute")]
        [HttpGet]
        public IQueryable<Project> GetProjectsForConnectionByConnectionId(Int32 connectionId) 
        {
            return _dbRepository.GetProjectsForConnectionByConnectionId(connectionId).AsQueryable();
        }

        [Route("api/connections/{connectionId}/projects", Name = "ProjectsGetProjectsForConnectionByConnectionIdPageableRoute")]
        [HttpGet]
        public  HttpResponseMessage  GetProjectsForConnectionByConnectionIdPageable(Int32 connectionId, String sortExpression, Int32 page, Int32 pageSize) 
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results =_dbRepository.GetProjectsForConnectionByConnectionIdPageable(connectionId, sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }


    }
}
