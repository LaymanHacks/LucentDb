using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
            _dbRepository.Update(connection.ConnectionProviderId, connection.Name, connection.ConnectionString,
                connection.IsActive, connection.ConnectionId);
        }

        [Route("api/connections", Name = "ConnectionsDeleteRoute")]
        [HttpDelete]
        public HttpResponseMessage Delete(int connectionId)
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
        public int Insert(Connection connection)
        {
            return _dbRepository.Insert(connection.ConnectionProviderId, connection.Name, connection.ConnectionString,
                connection.IsActive);
        }

        [Route("api/connections", Name = "ConnectionsGetDataPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataPageable(string sortExpression, int page, int pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetDataPageable(sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/connections/{connectionId}", Name = "ConnectionsGetDataByConnectionIdRoute")]
        [HttpGet]
        public IQueryable<Connection> GetDataByConnectionId(int connectionId)
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
        public HttpResponseMessage GetActiveDataPageable(string sortExpression, int page, int pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetActiveDataPageable(sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/projects/{projectId}/connections/all", Name = "ConnectionsGetConnectionsForProjectByProjectIdRoute")
        ]
        [HttpGet]
        public IQueryable<Connection> GetConnectionsForProjectByProjectId(int projectId)
        {
            return _dbRepository.GetConnectionsForProjectByProjectId(projectId).AsQueryable();
        }

        [Route("api/projects/{projectId}/connections",
            Name = "ConnectionsGetConnectionsForProjectByProjectIdPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetConnectionsForProjectByProjectIdPageable(int projectId, string sortExpression,
            int page, int pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetConnectionsForProjectByProjectIdPageable(projectId, sortExpression, page,
                pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/connectionProviders/{connectionProviderId}/connections/all",
            Name = "ConnectionsGetDataByConnectionProviderIdRoute")]
        [HttpGet]
        public IQueryable<Connection> GetDataByConnectionProviderId(int connectionProviderId)
        {
            return _dbRepository.GetDataByConnectionProviderId(connectionProviderId).AsQueryable();
        }

        [Route("api/connectionProviders/{connectionProviderId}/connections",
            Name = "ConnectionsGetDataByConnectionProviderIdPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataByConnectionProviderIdPageable(int connectionProviderId, string sortExpression,
            int page, int pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetDataByConnectionProviderIdPageable(connectionProviderId, sortExpression, page,
                pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/connectionProviders/{connectionProviderId}/connections/all/active",
            Name = "ConnectionsGetActiveDataByConnectionProviderIdRoute")]
        [HttpGet]
        public IQueryable<Connection> GetActiveDataByConnectionProviderId(int connectionProviderId)
        {
            return _dbRepository.GetActiveDataByConnectionProviderId(connectionProviderId).AsQueryable();
        }

        [Route("api/connectionProviders/{connectionProviderId}/connections/active",
            Name = "ConnectionsGetActiveDataByConnectionProviderIdPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetActiveDataByConnectionProviderIdPageable(int connectionProviderId,
            string sortExpression, int page, int pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetActiveDataByConnectionProviderIdPageable(connectionProviderId, sortExpression,
                page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }
    }
}