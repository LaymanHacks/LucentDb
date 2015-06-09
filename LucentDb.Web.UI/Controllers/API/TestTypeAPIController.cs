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
    public class TestTypeApiController : ApiController
    {
        private readonly ITestTypeRepository _dbRepository;

        public TestTypeApiController(ITestTypeRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
   
        [Route("api/testTypes/all", Name = "TestTypesGetDataRoute")]
        [HttpGet]
        public IQueryable<TestType> GetData() 
        {
            return _dbRepository.GetData().AsQueryable();
        }

        [Route("api/testTypes", Name = "TestTypesUpdateRoute")]
        [HttpPut]
        public void Update(TestType testType)
        {
            _dbRepository.Update(testType.Name, testType.TestValidatorType,  (bool)testType.IsActive,  (Int32)testType.Id);
          }

        [Route("api/testTypes", Name = "TestTypesDeleteRoute")]
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

        [Route("api/testTypes", Name = "TestTypesInsertRoute")]
        [HttpPost]
        public Int32 Insert(TestType testType)
        {
             return _dbRepository.Insert(testType.Name, testType.TestValidatorType,  (bool)testType.IsActive);
          }

        [Route("api/testTypes", Name = "TestTypesGetDataPageableRoute")]
        [HttpGet]
        public  HttpResponseMessage  GetDataPageable(String sortExpression, Int32 page, Int32 pageSize) 
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results =_dbRepository.GetDataPageable(sortExpression, page, pageSize);
            var totalCount = _dbRepository.GetRowCount();
            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "TestTypesGetDataPageableRoute", page,
                pageSize, totalCount, results);
            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }

        [Route("api/testTypes/{id}", Name = "TestTypesGetDataByIdRoute")]
        [HttpGet]
        public IQueryable<TestType> GetDataById(Int32 id) 
        {
            return _dbRepository.GetDataById(id).AsQueryable();
        }

        [Route("api/testTypes/all/active", Name = "TestTypesGetActiveDataRoute")]
        [HttpGet]
        public IQueryable<TestType> GetActiveData() 
        {
            return _dbRepository.GetActiveData().AsQueryable();
        }

        [Route("api/testTypes/active", Name = "TestTypesGetActiveDataPageableRoute")]
        [HttpGet]
        public  HttpResponseMessage  GetActiveDataPageable(String sortExpression, Int32 page, Int32 pageSize) 
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results =_dbRepository.GetActiveDataPageable(sortExpression, page, pageSize);
            var totalCount = _dbRepository.GetActiveDataRowCount();
            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "TestTypesGetActiveDataPageableRoute", page,
                pageSize, totalCount, results);
            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }


    }
}
