using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Http;
using LucentDb.Domain;
using LucentDb.Domain.Entities;
using LucentDb.Domain.Model;
using LucentDb.Validator;

namespace LucentDb.Web.UI.Controllers.API
{
    public class ValidateApiController : ApiController
    {
        private readonly IRepositoryContext _dataRepository;

        public ValidateApiController()
        {
            //TODO Initalize from constructor
            _dataRepository = new DbRepositoryContext();
        }

        [Route("api/ValidateTest/{testId}/{connectionId}", Name = "ValidateTestRoute")]
        [HttpGet]
        public ValidationResponse ValidateTest(int testId, int connectionId)
        {
            
            var connection = BuildConnection(connectionId);
            var test = BuildTest(testId, connectionId);

            var scriptVal = new SqlScriptValidator();
            var valResult = scriptVal.Validate(connection, test);


                _dataRepository.RunHistoryRepository.Insert(test.Id, valResult.RunDateTime, valResult.IsValid,
                    valResult.RunLog, valResult.ResultMessage);

                return valResult;
        }

        //TODO refactor
        private Test BuildTest(int testId, int connectionId)
        {
            var test = _dataRepository.TestRepository.GetDataById(testId).First();
            if (test != null)
            {
                if (test.ProjectId != null && _dataRepository.ProjectConnectionRepository
                    .GetDataByProjectId((int) test.ProjectId).Any(x => x.ConnectionId == connectionId))
                {
                    test.TestType = _dataRepository.TestTypeRepository.GetDataById(test.TestTypeId).FirstOrDefault();
                    test.ExpectedResults =
                        (Collection<ExpectedResult>) _dataRepository.ExpectedResultRepository.GetDataByTestId(test.Id);

                    foreach (var expResult in test.ExpectedResults)
                    {
                        if (expResult == null) continue;
                        if (expResult.AssertTypeId != null)
                            expResult.AssertType =
                                _dataRepository.AssertTypeRepository.GetDataById((int) expResult.AssertTypeId)
                                    .FirstOrDefault();
                    }
                }
                else
                {
                    throw new Exception("Not a valid Connection for this test.");
                }
            }
            return test;
        }

        //TODO refactor
        private Connection BuildConnection(int connectionId)
        {
            var connection =
                _dataRepository.ConnectionRepository.GetDataByConnectionId(connectionId).First();
            connection.ConnectionProvider =
                _dataRepository.ConnectionProviderRepository.GetDataById(connection.ConnectionProviderId)
                    .First();
            return connection;
        }
    }
}