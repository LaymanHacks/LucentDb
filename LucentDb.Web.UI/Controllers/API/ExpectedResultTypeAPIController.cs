
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
    public class ExpectedResultTypeApiController : ApiController
    {
        private readonly IExpectedResultTypeRepository _dbRepository;

        public ExpectedResultTypeApiController(IExpectedResultTypeRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
   
        [Route("api/expectedResultTypes/all", Name = "ExpectedResultTypesGetDataRoute")]
        [HttpGet]
        public IQueryable<ExpectedResultType> GetData() 
        {
            return _dbRepository.GetData().AsQueryable();
        }

        [Route("api/expectedResultTypes", Name = "ExpectedResultTypesUpdateRoute")]
        [HttpPut]
        public void Update(ExpectedResultType expectedResultType)
        {
            _dbRepository.Update( (string)expectedResultType.Name,  (Int32)expectedResultType.Id);
          }

        [Route("api/expectedResultTypes", Name = "ExpectedResultTypesDeleteRoute")]
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

        [Route("api/expectedResultTypes", Name = "ExpectedResultTypesInsertRoute")]
        [HttpPost]
        public Int32 Insert(ExpectedResultType expectedResultType)
        {
             return _dbRepository.Insert( (string)expectedResultType.Name);
          }

        [Route("api/expectedResultTypes", Name = "ExpectedResultTypesGetDataPageableRoute")]
        [HttpGet]
        public  HttpResponseMessage  GetDataPageable(String sortExpression, Int32 page, Int32 pageSize) 
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results =_dbRepository.GetDataPageable(sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/expectedResultTypes/{id}", Name = "ExpectedResultTypesGetDataByIdRoute")]
        [HttpGet]
        public IQueryable<ExpectedResultType> GetDataById(Int32 id) 
        {
            return _dbRepository.GetDataById(id).AsQueryable();
        }


    }
}
