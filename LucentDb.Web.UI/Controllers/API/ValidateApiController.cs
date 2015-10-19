using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using LucentDb.Domain;
using LucentDb.Domain.Entities;
using LucentDb.Domain.Model;
using LucentDb.Validator;

namespace LucentDb.Web.UI.Controllers.API
{
    public class ValidateApiController : ApiController
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly ILucentDbRepositoryContext _dataRepository;
        private readonly ProjectFactory _projectFactory;
        private readonly TestFactory _testFactory;
        private readonly TestGroupFactory _testGroupFactory;

        public ValidateApiController()
        {
            //TODO Initalize from constructor
            _dataRepository = new DbRepositoryContext();
            _connectionFactory = new ConnectionFactory(_dataRepository.ConnectionRepository,
                _dataRepository.ConnectionProviderRepository);
            _testFactory = new TestFactory(_dataRepository.TestRepository, _dataRepository.TestTypeRepository,
                _dataRepository.ExpectedResultRepository, _dataRepository.AssertTypeRepository);
            _projectFactory = new ProjectFactory(_dataRepository.ProjectRepository, _dataRepository.TestRepository,
                _testFactory);
            _testGroupFactory = new TestGroupFactory(_dataRepository.TestRepository, _dataRepository.TestGroupRepository,
                _testFactory);
        }

        [Route("api/connections/{connectionId}/testgroups/{groupId}/validate")]
        [HttpGet]
        public HttpResponseMessage ValidateGroup(int groupId, int connectionId)
        {
            try
            {
                var connection = _connectionFactory.CreateConnection(connectionId);
                var testGroup = _testGroupFactory.CreateTestGroup(groupId);
                if (!ValidateConnectionForProject(connectionId, testGroup.ProjectId))
                    throw new Exception("Not a valid Connection for this test group.");

                var valCollection = ExecuteTests(testGroup.Tests, connection);

               var rHistory = ProcessTestResults(valCollection, DateTime.Now, groupId, null);

                PersistValidationResults(rHistory);
                return Request.CreateResponse(HttpStatusCode.OK, valCollection);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new HttpError(ex.Message));
            }
        }

        private void PersistValidationResults(RunHistory rHistory)
        {
            //need to make this a transaction
            var runHistoryId = _dataRepository.RunHistoryRepository.Insert(rHistory);
            foreach (var rHistoryDetails in rHistory.RunHistoryDetails)
            {
                rHistoryDetails.RunHistoryId = runHistoryId;
                _dataRepository.RunHistoryDetailRepository.Insert(rHistoryDetails);
            }
          
        }

        private static RunHistory ProcessTestResults(IEnumerable<ValidationResponse> valCollection, DateTime startDateTime, int? groupId, int? projectId)
        {
            var runHistoryLog = new StringBuilder();
            var runHistory = new RunHistory
            {
                GroupId = groupId,
                ProjectId = projectId,
                RunDateTime = startDateTime,
                RunHistoryDetails = new Collection<RunHistoryDetail>()
            };
            foreach (var valResult in valCollection)
            {
                var runHistoryDetail = new RunHistoryDetail
                {
                    TestId = valResult.TestId,
                    RunDateTime = valResult.RunDateTime,
                    IsValid = valResult.IsValid,
                    Duration = valResult.Duration,
                    ResultString =valResult.ResultMessage
                };
                runHistoryLog.AppendLine(valResult.TestName);
                runHistoryLog.AppendLine(valResult.ResultMessage);
                runHistoryLog.AppendLine(valResult.RunLog);
                runHistory.RunHistoryDetails.Add(runHistoryDetail);
            }
            runHistory.RunLog = runHistoryLog.ToString();
            return runHistory;
        }

        [Route("api/connections/{connectionId}/projects/{projectId}/validate")]
        [HttpGet]
        public HttpResponseMessage ValidateProject(int projectId, int connectionId)
        {
            try
            { 
                
                var project = _projectFactory.CreateProject(projectId);
                if (!project.ValidateConnection(connectionId))
                    throw new Exception("Not a valid Connection for this project.");
                
                var connection = _connectionFactory.CreateConnection(connectionId);
               

                var valCollection = ExecuteTests(project.Tests, connection);
                var rHistory = ProcessTestResults(valCollection, DateTime.Now,null, projectId);
                
                PersistValidationResults(rHistory);
                return Request.CreateResponse(HttpStatusCode.OK, valCollection);
                
            }
            catch (Exception ex)
            {
                return
                    Request.CreateErrorResponse(
                        ex.Message == "Not a valid Connection for this project."
                            ? HttpStatusCode.BadRequest
                            : HttpStatusCode.InternalServerError, new HttpError(ex.Message));
            }
        }

        private static Collection<ValidationResponse> ExecuteTests(IEnumerable<Test> tests, Connection connection)
        {
            var scriptVal = new SqlScriptValidator();
            var valResponse = new Collection<ValidationResponse>();
           
            foreach (var test in tests)
            {
                var valResult = scriptVal.Validate(connection, test);
                if (valResult == null) continue;
                valResponse.Add(valResult);
            }

            return valResponse;
        }

        //[Route("api/ValidateTest/{testId}/{connectionId}", Name = "ValidateTestRoute")]
        [Route("api/connections/{connectionId}/tests/{testId}/validate")]
        [HttpGet]
        public HttpResponseMessage ValidateTest(int testId, int connectionId)
        {
           
            var connection = _connectionFactory.CreateConnection(connectionId);
            var test = _testFactory.CreateTest(testId);
            var project = new Domain.Model.Project(_dataRepository) {ProjectId = (int) test.ProjectId};
            if (test.ProjectId != null && !project.ValidateConnection(connectionId))
                throw new Exception("Not a valid Connection for this test.");

            var scriptVal = new SqlScriptValidator();
            var valResult = scriptVal.Validate(connection, test);

           
           //_dataRepository.RunHistoryDetailsRepository.Insert();
            _dataRepository.RunHistoryRepository.Insert(test.Id, null, null, connectionId, valResult.RunDateTime, valResult.Duration, valResult.IsValid, 
                 valResult.RunLog);

            return Request.CreateResponse(HttpStatusCode.OK, valResult);
        }

       
    }

    
}