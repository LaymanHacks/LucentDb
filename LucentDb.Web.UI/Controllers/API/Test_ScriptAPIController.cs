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
    public class Test_ScriptApiController : ApiController
    {
        private readonly ITest_ScriptRepository _dbRepository;

        public Test_ScriptApiController(ITest_ScriptRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        [Route("api/test_Script", Name = "Test_ScriptDeleteRoute")]
        [HttpDelete]
        public HttpResponseMessage Delete(int testId, int scriptId)
        {
            try
            {
                _dbRepository.Delete(testId, scriptId);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("api/test_Script/all", Name = "Test_ScriptGetDataRoute")]
        [HttpGet]
        public IQueryable<Test_Script> GetData()
        {
            return _dbRepository.GetData().AsQueryable();
        }

        [Route("api/scripts/{scriptId}/test_Script/all", Name = "Test_ScriptGetDataByScriptIdRoute")]
        [HttpGet]
        public IQueryable<Test_Script> GetDataByScriptId(int scriptId)
        {
            return _dbRepository.GetDataByScriptId(scriptId).AsQueryable();
        }

        [Route("api/scripts/{scriptId}/test_Script", Name = "Test_ScriptGetDataByScriptIdPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataByScriptIdPageable(int scriptId, string sortExpression, int page, int pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetDataByScriptIdPageable(scriptId, sortExpression, page, pageSize);
            var totalCount = _dbRepository.GetDataByScriptIdRowCount(scriptId);
            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "Test_ScriptGetDataByScriptIdPageableRoute",
                page,
                pageSize, totalCount, results);
            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }

        [Route("api/tests/{testId}/test_Script/all", Name = "Test_ScriptGetDataByTestIdRoute")]
        [HttpGet]
        public IQueryable<Test_Script> GetDataByTestId(int testId)
        {
            return _dbRepository.GetDataByTestId(testId).AsQueryable();
        }

        [Route("api/tests/{testId}/test_Script", Name = "Test_ScriptGetDataByTestIdPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataByTestIdPageable(int testId, string sortExpression, int page, int pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetDataByTestIdPageable(testId, sortExpression, page, pageSize);
            var totalCount = _dbRepository.GetDataByTestIdRowCount(testId);
            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "Test_ScriptGetDataByTestIdPageableRoute",
                page,
                pageSize, totalCount, results);
            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }

        [Route("api/test_Script", Name = "Test_ScriptGetDataPageableRoute")]
        [HttpGet]
        public HttpResponseMessage GetDataPageable(string sortExpression, int page, int pageSize)
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results = _dbRepository.GetDataPageable(sortExpression, page, pageSize);
            var totalCount = _dbRepository.GetRowCount();
            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "Test_ScriptGetDataPageableRoute", page,
                pageSize, totalCount, results);
            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }

        [Route("api/test_Script", Name = "Test_ScriptInsertRoute")]
        [HttpPost]
        public void Insert(Test_Script test_Script)
        {
            _dbRepository.Insert(test_Script.TestId, test_Script.ScriptId);
        }

        //[Route("api/test_Script", Name = "Test_ScriptUpdateRoute")]
        //[HttpPut]
        //public void Update(Test_Script test_Script)
        //{
        //    _dbRepository.Update(test_Script.TestId, test_Script.ScriptId, (int) test_Script.Original_TestId,
        //        (int) test_Script.Original_ScriptId);
        //}
    }
}