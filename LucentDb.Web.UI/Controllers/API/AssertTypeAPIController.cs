using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LucentDb.Data.Repository;
using LucentDb.Domain.Entities;

namespace LucentDb.Web.UI.Controllers.Api
{
    public class AssertTypeApiController : ApiController
    {
        private readonly IAssertTypeRepository _dbRepository;

        public AssertTypeApiController(IAssertTypeRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        [Route("api/assertTypes/all", Name = "AssertTypesGetDataRoute")]
        [HttpGet]
        public IQueryable<AssertType> GetData()
        {
            return _dbRepository.GetData().AsQueryable();
        }

        [Route("api/assertTypes", Name = "AssertTypesUpdateRoute")]
        [HttpPut]
        public void Update(AssertType assertType)
        {
            _dbRepository.Update(assertType.Name, assertType.Id);
        }

        [Route("api/assertTypes", Name = "AssertTypesDeleteRoute")]
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

        [Route("api/assertTypes", Name = "AssertTypesInsertRoute")]
        [HttpPost]
        public int Insert(AssertType assertType)
        {
            return _dbRepository.Insert(assertType.Name);
        }

        [Route("api/assertTypes", Name = "AssertTypesGetDataPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataPageable(string sortExpression, int page, int pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetDataPageable(sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/assertTypes/{id}", Name = "AssertTypesGetDataByIdRoute")]
        [HttpGet]
        public IQueryable<AssertType> GetDataById(int id)
        {
            return _dbRepository.GetDataById(id).AsQueryable();
        }
    }
}