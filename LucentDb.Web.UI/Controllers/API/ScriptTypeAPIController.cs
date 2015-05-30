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
    public class ScriptTypeApiController : ApiController
    {
        private readonly IScriptTypeRepository _dbRepository;

        public ScriptTypeApiController(IScriptTypeRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
   
        [Route("api/scriptTypes/all", Name = "ScriptTypesGetDataRoute")]
        [HttpGet]
        public IQueryable<ScriptType> GetData() 
        {
            return _dbRepository.GetData().AsQueryable();
        }

        [Route("api/scriptTypes", Name = "ScriptTypesUpdateRoute")]
        [HttpPut]
        public void Update(ScriptType scriptType)
        {
            _dbRepository.Update(scriptType.Name,  (bool)scriptType.IsActive,  (Int32)scriptType.Id);
          }

        [Route("api/scriptTypes", Name = "ScriptTypesDeleteRoute")]
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

        [Route("api/scriptTypes", Name = "ScriptTypesInsertRoute")]
        [HttpPost]
        public Int32 Insert(ScriptType scriptType)
        {
             return _dbRepository.Insert(scriptType.Name,  (bool)scriptType.IsActive);
          }

        [Route("api/scriptTypes", Name = "ScriptTypesGetDataPageableRoute")]
        [HttpGet]
        public  HttpResponseMessage  GetDataPageable(String sortExpression, Int32 page, Int32 pageSize) 
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results =_dbRepository.GetDataPageable(sortExpression, page, pageSize);
            var totalCount = _dbRepository.GetRowCount();
            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "ScriptTypesGetDataPageableRoute", page,
                pageSize, totalCount, results);
            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }

        [Route("api/scriptTypes/{id}/scriptTypes", Name = "ScriptTypesGetDataByIdRoute")]
        [HttpGet]
        public IQueryable<ScriptType> GetDataById(Int32 id) 
        {
            return _dbRepository.GetDataById(id).AsQueryable();
        }

        [Route("api/scriptTypes/all/active", Name = "ScriptTypesGetActiveDataRoute")]
        [HttpGet]
        public IQueryable<ScriptType> GetActiveData() 
        {
            return _dbRepository.GetActiveData().AsQueryable();
        }

        [Route("api/scriptTypes/active", Name = "ScriptTypesGetActiveDataPageableRoute")]
        [HttpGet]
        public  HttpResponseMessage  GetActiveDataPageable(String sortExpression, Int32 page, Int32 pageSize) 
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results =_dbRepository.GetActiveDataPageable(sortExpression, page, pageSize);
            var totalCount = _dbRepository.GetActiveDataRowCount();
            var pagedResults = PagedResultHelper.CreatePagedResult(Request, "ScriptTypesGetActiveDataPageableRoute", page,
                pageSize, totalCount, results);
            return Request.CreateResponse(HttpStatusCode.OK, pagedResults);
        }


    }
}
