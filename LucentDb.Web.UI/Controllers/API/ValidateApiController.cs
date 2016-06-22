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
using LucentDb.Domain.Factories;
using LucentDb.Domain.Model;
using LucentDb.Validator;
using LucentDb.Validator.Model;

namespace LucentDb.Web.UI.Controllers.API
{
    public class ValidateApiController : ApiController
    {
        private const string ConnectionNotValid = "Not a valid Connection";
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
                _dataRepository.TestValueTypeRepository,
                _dataRepository.ExpectedResultRepository, _dataRepository.AssertTypeRepository);
            _projectFactory = new ProjectFactory(_dataRepository.ProjectRepository, _dataRepository.TestRepository,
                _dataRepository.TestGroupRepository,
                _testFactory);
            _testGroupFactory = new TestGroupFactory(_dataRepository.TestRepository, _dataRepository.TestGroupRepository,
                _testFactory);
        }

        [Route("api/testgroups/{groupId}/validate")]
        [Route("api/testgroups/{groupId}/connections/{connectionId}/validate")]
        [HttpGet]
        public HttpResponseMessage ValidateGroup(int groupId, int connectionId = 0)
        {
            try
            {
                var testGroup = _testGroupFactory.CreateTestGroup(groupId);

                Connection connection;
                if (connectionId == 0)
                {
                    connection = GetDefaultConnectionByProjectId(testGroup.ProjectId);

                    connectionId = connection.ConnectionId;
                }
                else
                {
                    connection = _connectionFactory.CreateConnection(connectionId);
                }

                var proj = new ValidationProject(_dataRepository, testGroup.ProjectId);
                if (!proj.ValidateConnection(connectionId))
                    throw new Exception(ConnectionNotValid);

                var valTestGroup = new ValidationTestGroup(connection, testGroup);

                var valCollection = valTestGroup.Validate();
                PersistValidationResults(valCollection, connectionId, null, groupId, null);

                return Request.CreateResponse(HttpStatusCode.OK, valTestGroup);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new HttpError(ex.Message));
            }
        }

        [Route("api/projects/{projectId}/validate")]
        [Route("api/projects/{projectId}/connections/{connectionId}/validate")]
        [HttpGet]
        public HttpResponseMessage ValidateProject(int projectId, int connectionId = 0)
        {
            try
            {
                var project = _projectFactory.CreateProject(projectId);
                Connection connection;
                if (connectionId == 0)
                {
                    connection = GetDefaultConnectionByProjectId(projectId);
                    connectionId = connection.ConnectionId;
                }
                else
                {
                    connection = _connectionFactory.CreateConnection(connectionId);
                }

                var validationProject = new ValidationProject(_dataRepository, projectId);
                if (!validationProject.ValidateConnection(connectionId))
                    throw new Exception(ConnectionNotValid);

                foreach (var test in project.Tests)
                {
                    validationProject.ValidationTests.Add(new ValidationTest(connection, test));
                }
                foreach (var testGroup in project.TestGroups)
                {
                    validationProject.ValidationTestGroups.Add(new ValidationTestGroup(connection, testGroup));
                }


                var valCollection = validationProject.Validate();
                PersistValidationResults(valCollection, connectionId, null, null, projectId);
                return Request.CreateResponse(HttpStatusCode.OK, validationProject);
            }
            catch (Exception ex)
            {
                return
                    Request.CreateErrorResponse(
                        ex.Message == ConnectionNotValid
                            ? HttpStatusCode.BadRequest
                            : HttpStatusCode.InternalServerError, new HttpError(ex.Message));
            }
        }

        private Connection GetDefaultConnectionByProjectId(int projectId)
        {
            var connection = _dataRepository.ConnectionRepository
                .GetDataByProjectId(projectId)
                .FirstOrDefault(x => x.IsActive & x.IsDefault & x.ProjectId == projectId);
            if (connection != null)
            {
                connection.ConnectionProvider =
                    _dataRepository.ConnectionProviderRepository.GetDataById(connection.ConnectionProviderId)
                        .FirstOrDefault();
            }
            return connection;
        }

        //[Route("api/ValidateTest/{testId}/{connectionId}", Name = "ValidateTestRoute")]
        [Route("api/tests/{testId}/validate")]
        [Route("api/tests/{testId}/connections/{connectionId}/validate")]
        [HttpGet]
        public HttpResponseMessage ValidateTest(int testId, int connectionId = 0)
        {
            var test = _testFactory.CreateTest(testId);
            var valProject = new ValidationProject(_dataRepository, test.ProjectId);
            Connection connection;
            if (connectionId == 0)
            {
                connection = _dataRepository.ConnectionRepository
                    .GetDataByProjectId(test.ProjectId)
                    .FirstOrDefault(x => x.IsActive & x.IsDefault & x.ProjectId == test.ProjectId);
                if (connection != null)
                {
                    connection.ConnectionProvider =
                        _dataRepository.ConnectionProviderRepository.GetDataById(connection.ConnectionProviderId)
                            .FirstOrDefault();
                    connectionId = connection.ConnectionId;
                }
            }
            else
            {
                connection = _connectionFactory.CreateConnection(connectionId);
            }

            if (!valProject.ValidateConnection(connectionId))
                throw new Exception(ConnectionNotValid);

            var valTest = new ValidationTest(connection, test);

            var valResult = new Collection<ValidationResponse> {valTest.Validate()};
            PersistValidationResults(valResult, connectionId, testId, null, null);

            return Request.CreateResponse(HttpStatusCode.OK, valResult);
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

        private void PersistValidationResults(IEnumerable<ValidationResponse> valCollection, int connectionId,
            int? testId, int? groupId,
            int? projectId)
        {
            var rHistory = ProcessTestResults(valCollection, connectionId, testId, groupId, projectId);
            //need to make this a transaction
            var runHistoryId = _dataRepository.RunHistoryRepository.Insert(rHistory);
            foreach (var rHistoryDetails in rHistory.RunHistoryDetails)
            {
                rHistoryDetails.RunHistoryId = runHistoryId;
                _dataRepository.RunHistoryDetailRepository.Insert(rHistoryDetails);
            }
        }

        private static RunHistory ProcessTestResults(IEnumerable<ValidationResponse> valCollection, int connectionId,
            int? testId, int? groupId, int? projectId)
        {
            decimal totalDuration = 0;
            var isValid = true;
            var runHistoryLog = new StringBuilder();
            var runHistory = new RunHistory
            {
                TestId = testId,
                GroupId = groupId,
                ProjectId = projectId,
                RunDateTime = DateTime.Now,
                RunHistoryDetails = new Collection<RunHistoryDetail>()
            };
            foreach (var valResult in valCollection)
            {
                isValid = valResult.IsValid && isValid;
                totalDuration += valResult.Duration;
                var runHistoryDetail = new RunHistoryDetail
                {
                    TestId = valResult.TestId,
                    RunDateTime = valResult.RunDateTime,
                    IsValid = valResult.IsValid,
                    Duration = valResult.Duration,
                    ResultString = valResult.ResultMessage
                };

                runHistoryLog.AppendLine(valResult.TestName);
                runHistoryLog.AppendLine(valResult.ResultMessage);
                runHistoryLog.AppendLine(valResult.RunLog);
                runHistory.RunHistoryDetails.Add(runHistoryDetail);
            }
            runHistory.TotalDuration = totalDuration;
            runHistory.ConnectionId = connectionId;
            runHistory.IsValid = isValid;
            runHistory.RunLog = runHistoryLog.ToString();
            return runHistory;
        }
    }
}