using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LucentDb.Data.Repository;
using LucentDb.Domain.Entities;

namespace LucentDb.Web.UI.Controllers.Api
{
    public class ConnectionProviderApiController : ApiController
    {
        private readonly IConnectionProviderRepository _dbRepository;

        public ConnectionProviderApiController(IConnectionProviderRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        [Route("api/connectionProviders/all", Name = "ConnectionProvidersGetDataRoute")]
        [HttpGet]
        public IQueryable<ConnectionProvider> GetData()
        {
            return _dbRepository.GetData().AsQueryable();
        }

        [Route("api/connectionProviders", Name = "ConnectionProvidersUpdateRoute")]
        [HttpPut]
        public void Update(ConnectionProvider connectionProvider)
        {
            _dbRepository.Update(connectionProvider.Name, connectionProvider.Value, connectionProvider.Id);
        }

        [Route("api/connectionProviders", Name = "ConnectionProvidersDeleteRoute")]
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

        [Route("api/connectionProviders", Name = "ConnectionProvidersInsertRoute")]
        [HttpPost]
        public int Insert(ConnectionProvider connectionProvider)
        {
            return _dbRepository.Insert(connectionProvider.Name, connectionProvider.Value);
        }

        [Route("api/connectionProviders", Name = "ConnectionProvidersGetDataPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataPageable(string sortExpression, int page, int pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetDataPageable(sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/connectionProviders/{id}", Name = "ConnectionProvidersGetDataByIdRoute")]
        [HttpGet]
        public IQueryable<ConnectionProvider> GetDataById(int id)
        {
            return _dbRepository.GetDataById(id).AsQueryable();
        }
    }
}