
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
    public class RunHistoryApiController : ApiController
    {
        private readonly IRunHistoryRepository _dbRepository;

        public RunHistoryApiController(IRunHistoryRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }
   
        [Route("api/runHistories/all", Name = "RunHistoriesGetDataRoute")]
        [HttpGet]
        public IQueryable<RunHistory> GetData() 
        {
            return _dbRepository.GetData().AsQueryable();
        }

        [Route("api/runHistories", Name = "RunHistoriesUpdateRoute")]
        [HttpPut]
        public void Update(RunHistory runHistory)
        {
            _dbRepository.Update( (Int32)runHistory.TestId,  (DateTime)runHistory.RunDateTime,  (bool)runHistory.IsValid, runHistory.RunLog, runHistory.ResultString, runHistory.Id);
          }

        [Route("api/runHistories", Name = "RunHistoriesDeleteRoute")]
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

        [Route("api/runHistories", Name = "RunHistoriesInsertRoute")]
        [HttpPost]
        public Int64 Insert(RunHistory runHistory)
        {
             return _dbRepository.Insert( (Int32)runHistory.TestId,  (DateTime)runHistory.RunDateTime,  (bool)runHistory.IsValid, runHistory.RunLog, runHistory.ResultString);
          }

        [Route("api/runHistories", Name = "RunHistoriesGetDataPageableRoute")]
        [HttpGet]
        public  HttpResponseMessage  GetDataPageable(String sortExpression, Int32 page, Int32 pageSize) 
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results =_dbRepository.GetDataPageable(sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }

        [Route("api/runHistories/all", Name = "RunHistoriesGetDataByIdRoute")]
        [HttpGet]
        public IQueryable<RunHistory> GetDataById(Int64 id) 
        {
            return _dbRepository.GetDataById(id).AsQueryable();
        }

        [Route("api/tests/{testId}/runHistories/all", Name = "RunHistoriesGetDataByTestIdRoute")]
        [HttpGet]
        public IQueryable<RunHistory> GetDataByTestId(Int32 testId) 
        {
            return _dbRepository.GetDataByTestId(testId).AsQueryable();
        }

        [Route("api/tests/{testId}/runHistories", Name = "RunHistoriesGetDataByTestIdPageableRoute")]
        [HttpGet]
        public  HttpResponseMessage  GetDataByTestIdPageable(Int32 testId, String sortExpression, Int32 page, Int32 pageSize) 
        {
            if (page < 1) return Request.CreateResponse(HttpStatusCode.BadRequest);
            var results =_dbRepository.GetDataByTestIdPageable(testId, sortExpression, page, pageSize);
            return Request.CreateResponse(HttpStatusCode.OK, results);
        }


    }
}
