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
using LucentDb.Data.DbCommandProvider;
using LucentDb.Data.Repository;
using LucentDb.Domain.Entities;

namespace LucentDb.Web.UI.Controllers.Api
{
    public class ConnectionApiController : ApiController
    {
        private readonly IConnectionRepository _dbRepository;

        public ConnectionApiController(IConnectionRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
   
        [Route("api/connections/all", Name = "ConnectionsGetDataRoute")]
        [HttpGet]
        public IQueryable<Connection> GetData() 
        {
            return _dbRepository.GetData().AsQueryable();
        }

        [Route("api/connections", Name = "ConnectionsUpdateRoute")]
        [HttpPut]
        public void Update(Connection connection)
        {
            _dbRepository.Update(connection.ConnectionProviderId, connection.Name, connection.ConnectionString,  (bool)connection.IsActive,  (Int32)connection.ConnectionId);
          }

        [Route("api/connections", Name = "ConnectionsDeleteRoute")]
        [HttpDelete]
        public HttpResponseMessage Delete(Int32 connectionId)
        {
            try
            {
                 _dbRepository.Delete(connectionId);
                 return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                 return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("api/connections", Name = "ConnectionsInsertRoute")]
        [HttpPost]
        public Int32 Insert(Connection connection)
        {
             return _dbRepository.Insert(connection.ConnectionProviderId, connection.Name, connection.ConnectionString,  (bool)connection.IsActive);
          }

        [Route("api/connections", Name = "ConnectionsGetDataPageableRoute")]
        [HttpGet]
        public  HttpResponseMessage  GetDataPageable(String sortExpression, Int32 page, Int32 pageSize) 
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results =_dbRepository.GetDataPageable(sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/connections/{connectionId}", Name = "ConnectionsGetDataByConnectionIdRoute")]
        [HttpGet]
        public IQueryable<Connection> GetDataByConnectionId(Int32 connectionId) 
        {
            return _dbRepository.GetDataByConnectionId(connectionId).AsQueryable();
        }

        [Route("api/connections/all/active", Name = "ConnectionsGetActiveDataRoute")]
        [HttpGet]
        public IQueryable<Connection> GetActiveData() 
        {
            return _dbRepository.GetActiveData().AsQueryable();
        }

        [Route("api/connections/active", Name = "ConnectionsGetActiveDataPageableRoute")]
        [HttpGet]
        public  HttpResponseMessage  GetActiveDataPageable(String sortExpression, Int32 page, Int32 pageSize) 
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results =_dbRepository.GetActiveDataPageable(sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/projects/{projectId}/connections/all", Name = "ConnectionsGetConnectionsForProjectByProjectIdRoute")]
        [HttpGet]
        public IQueryable<Connection> GetConnectionsForProjectByProjectId(Int32 projectId) 
        {
            return _dbRepository.GetConnectionsForProjectByProjectId(projectId).AsQueryable();
        }

        [Route("api/projects/{projectId}/connections", Name = "ConnectionsGetConnectionsForProjectByProjectIdPageableRoute")]
        [HttpGet]
        public  HttpResponseMessage  GetConnectionsForProjectByProjectIdPageable(Int32 projectId, String sortExpression, Int32 page, Int32 pageSize) 
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results =_dbRepository.GetConnectionsForProjectByProjectIdPageable(projectId, sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }


    }
}
