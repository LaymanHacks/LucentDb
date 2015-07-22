
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
    public class ExpectedResultApiController : ApiController
    {
        private readonly IExpectedResultRepository _dbRepository;

        public ExpectedResultApiController(IExpectedResultRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
   
        [Route("api/expectedResults/all", Name = "ExpectedResultsGetDataRoute")]
        [HttpGet]
        public IQueryable<ExpectedResult> GetData() 
        {
            return _dbRepository.GetData().AsQueryable();
        }

        [Route("api/expectedResults", Name = "ExpectedResultsUpdateRoute")]
        [HttpPut]
        public void Update(ExpectedResult expectedResult)
        {
            _dbRepository.Update( (Int32)expectedResult.TestId, expectedResult.ExpectedResultTypeId, expectedResult.AssertTypeId, expectedResult.ExpectedValue,  (Int32)expectedResult.ResultIndex,  (Int32)expectedResult.Id);
          }

        [Route("api/expectedResults", Name = "ExpectedResultsDeleteRoute")]
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

        [Route("api/expectedResults", Name = "ExpectedResultsInsertRoute")]
        [HttpPost]
        public Int32 Insert(ExpectedResult expectedResult)
        {
             return _dbRepository.Insert( (Int32)expectedResult.TestId, expectedResult.ExpectedResultTypeId, expectedResult.AssertTypeId, expectedResult.ExpectedValue,  (Int32)expectedResult.ResultIndex);
          }

        [Route("api/expectedResults", Name = "ExpectedResultsGetDataPageableRoute")]
        [HttpGet]
        public  HttpResponseMessage  GetDataPageable(String sortExpression, Int32 page, Int32 pageSize) 
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results =_dbRepository.GetDataPageable(sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/expectedResults/all", Name = "ExpectedResultsGetDataByIdRoute")]
        [HttpGet]
        public IQueryable<ExpectedResult> GetDataById(Int32 id) 
        {
            return _dbRepository.GetDataById(id).AsQueryable();
        }

        [Route("api/assertTypes/{assertTypeId}/expectedResults/all", Name = "ExpectedResultsGetDataByAssertTypeIdRoute")]
        [HttpGet]
        public IQueryable<ExpectedResult> GetDataByAssertTypeId(Int32 assertTypeId) 
        {
            return _dbRepository.GetDataByAssertTypeId(assertTypeId).AsQueryable();
        }

        [Route("api/assertTypes/{assertTypeId}/expectedResults", Name = "ExpectedResultsGetDataByAssertTypeIdPageableRoute")]
        [HttpGet]
        public  HttpResponseMessage  GetDataByAssertTypeIdPageable(Int32 assertTypeId, String sortExpression, Int32 page, Int32 pageSize) 
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results =_dbRepository.GetDataByAssertTypeIdPageable(assertTypeId, sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/expectedResultTypes/{expectedResultTypeId}/expectedResults/all", Name = "ExpectedResultsGetDataByExpectedResultTypeIdRoute")]
        [HttpGet]
        public IQueryable<ExpectedResult> GetDataByExpectedResultTypeId(Int32 expectedResultTypeId) 
        {
            return _dbRepository.GetDataByExpectedResultTypeId(expectedResultTypeId).AsQueryable();
        }

        [Route("api/expectedResultTypes/{expectedResultTypeId}/expectedResults", Name = "ExpectedResultsGetDataByExpectedResultTypeIdPageableRoute")]
        [HttpGet]
        public  HttpResponseMessage  GetDataByExpectedResultTypeIdPageable(Int32 expectedResultTypeId, String sortExpression, Int32 page, Int32 pageSize) 
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results =_dbRepository.GetDataByExpectedResultTypeIdPageable(expectedResultTypeId, sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/tests/{testId}/expectedResults/all", Name = "ExpectedResultsGetDataByTestIdRoute")]
        [HttpGet]
        public IQueryable<ExpectedResult> GetDataByTestId(Int32 testId) 
        {
            return _dbRepository.GetDataByTestId(testId).AsQueryable();
        }

        [Route("api/tests/{testId}/expectedResults", Name = "ExpectedResultsGetDataByTestIdPageableRoute")]
        [HttpGet]
        public  HttpResponseMessage  GetDataByTestIdPageable(Int32 testId, String sortExpression, Int32 page, Int32 pageSize) 
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results =_dbRepository.GetDataByTestIdPageable(testId, sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }


    }
}
