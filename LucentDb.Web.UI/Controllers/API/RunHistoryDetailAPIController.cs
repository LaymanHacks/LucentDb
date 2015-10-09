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
    public class RunHistoryDetailApiController : ApiController
    {
        private readonly IRunHistoryDetailRepository _dbRepository;

        public RunHistoryDetailApiController(IRunHistoryDetailRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
   
        [Route("api/RunHistoryDetail/all", Name = "RunHistoryDetailGetDataRoute")]
        [HttpGet]
        public IQueryable<RunHistoryDetail> GetData() 
        {
            return _dbRepository.GetData().AsQueryable();
        }

        [Route("api/RunHistoryDetail", Name = "RunHistoryDetailUpdateRoute")]
        [HttpPut]
        public void Update(RunHistoryDetail runHistoryDetail)
        {
            _dbRepository.Update(runHistoryDetail.RunHistoryId,  (Int32)runHistoryDetail.TestId,  (DateTime)runHistoryDetail.RunDateTime,  (bool)runHistoryDetail.IsValid, runHistoryDetail.ResultString, runHistoryDetail.Id);
          }

        [Route("api/RunHistoryDetail", Name = "RunHistoryDetailDeleteRoute")]
        [HttpDelete]
        public HttpResponseMessage Delete(Int64 id)
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

        [Route("api/RunHistoryDetail", Name = "RunHistoryDetailInsertRoute")]
        [HttpPost]
        public Int64 Insert(RunHistoryDetail runHistoryDetail)
        {
             return _dbRepository.Insert(runHistoryDetail.RunHistoryId,  (Int32)runHistoryDetail.TestId,  (DateTime)runHistoryDetail.RunDateTime,  (bool)runHistoryDetail.IsValid, runHistoryDetail.ResultString);
          }

        [Route("api/RunHistoryDetail", Name = "RunHistoryDetailGetDataPageableRoute")]
        [HttpGet]
        public  HttpResponseMessage  GetDataPageable(String sortExpression, Int32 page, Int32 pageSize) 
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results =_dbRepository.GetDataPageable(sortExpression, page, pageSize);

            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/RunHistoryDetail/all", Name = "RunHistoryDetailGetDataByIdRoute")]
        [HttpGet]
        public IQueryable<RunHistoryDetail> GetDataById(Int64 id) 
        {
            return _dbRepository.GetDataById(id).AsQueryable();
        }

        [Route("api/RunHistoryDetail/all", Name = "RunHistoryDetailGetDataByRunHistoryIdRoute")]
        [HttpGet]
        public IQueryable<RunHistoryDetail> GetDataByRunHistoryId(Int64 runHistoryId) 
        {
            return _dbRepository.GetDataByRunHistoryId(runHistoryId).AsQueryable();
        }

        [Route("api/RunHistoryDetail", Name = "RunHistoryDetailGetDataByRunHistoryIdPageableRoute")]
        [HttpGet]
        public  HttpResponseMessage  GetDataByRunHistoryIdPageable(Int64 runHistoryId, String sortExpression, Int32 page, Int32 pageSize) 
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results =_dbRepository.GetDataByRunHistoryIdPageable(runHistoryId, sortExpression, page, pageSize);

            return Request.CreateResponse(HttpStatusCode.OK, results);
        }


    }
}