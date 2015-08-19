using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LucentDb.Data.Repository;
using LucentDb.Domain;
using LucentDb.Domain.Entities;
using LucentDb.Domain.Model;
using LucentDb.Validator;

namespace LucentDb.Web.UI.Controllers.API
{
    public class ValidateApiController : ApiController
    {
        private readonly IRepositoryContext _dataRepository;
        private readonly ConnectionFactory _connectionFactory;
        private readonly ProjectFactory _projectFactory;
        private readonly TestFactory _testFactory;
        private readonly TestGroupFactory _testGroupFactory;

        public ValidateApiController()
        {
            //TODO Initalize from constructor
            _dataRepository = new DbRepositoryContext();
            _connectionFactory = new ConnectionFactory(_dataRepository.ConnectionRepository,_dataRepository.ConnectionProviderRepository);
            _testFactory = new TestFactory(_dataRepository.TestRepository, _dataRepository.TestTypeRepository, _dataRepository.ExpectedResultRepository, _dataRepository.AssertTypeRepository);
           _projectFactory = new ProjectFactory(_dataRepository.ProjectRepository, _dataRepository.TestRepository, _testFactory);
            _testGroupFactory = new TestGroupFactory(_dataRepository.TestRepository, _dataRepository.TestGroupRepository, _testFactory);
        }

        //api/TestGroup/Validate/1/1 or api/connections/1/testgroups/1/validate
        [Route("api/ValidateTestGroup/{groupId}/{connectionId}", Name = "ValidateTestGroupRoute")]
        [HttpGet]
        public HttpResponseMessage ValidateGroup(int groupId, int connectionId)
        {
            try
            {
                var connection = _connectionFactory.CreateConnection(connectionId);
                var testGroup = _testGroupFactory.CreateTestGroup(groupId);
                if (!ValidateConnectionForProject(connectionId, testGroup.ProjectId))
                    throw new Exception("Not a valid Connection for this test group.");

                var scriptVal = new SqlScriptValidator();
                var valCollection = new Collection<ValidationResponse>();

                foreach (
                    var valResult in
                        testGroup.Tests.Select(test => scriptVal.Validate(connection, test))
                            .Where(valResult => valResult != null))
                {
                    valCollection.Add(valResult);
                    _dataRepository.RunHistoryRepository.Insert(testGroup.ProjectId, valResult.RunDateTime,
                        valResult.IsValid,
                        valResult.RunLog, valResult.ResultMessage);
                }
                return Request.CreateResponse(HttpStatusCode.OK, valCollection);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new HttpError(ex.Message));
            }
        }

        //api/Project/Validate/1/1 or api/connections/1/projects/1/validate
        [Route("api/ValidateProject/{projectId}/{connectionId}", Name = "ValidateProjectRoute")]
        [HttpGet]
        public HttpResponseMessage ValidateProject(int projectId, int connectionId)
        {
            var valCollection = new Collection<ValidationResponse>();
            try
            {
                if (!ValidateConnectionForProject(connectionId, projectId))
                    throw new Exception("Not a valid Connection for this project.");


                var connection = _connectionFactory.CreateConnection(connectionId);
                var project = _projectFactory.CreateProject(projectId);

                var scriptVal = new SqlScriptValidator();

                foreach (
                    var valResult in
                        project.Tests.Select(test => scriptVal.Validate(connection, test))
                            .Where(valResult => valResult != null))
                {
                    valCollection.Add(valResult);
                    _dataRepository.RunHistoryRepository.Insert(project.ProjectId, valResult.RunDateTime,
                        valResult.IsValid,
                        valResult.RunLog, valResult.ResultMessage);
                }
            }
            catch (Exception ex)
            {
                return
                    Request.CreateErrorResponse(
                        ex.Message == "Not a valid Connection for this project."
                            ? HttpStatusCode.BadRequest
                            : HttpStatusCode.InternalServerError, new HttpError(ex.Message));
            }
            return Request.CreateResponse(HttpStatusCode.OK, valCollection);
        }


        //[Route("api/ValidateTest/{testId}/{connectionId}", Name = "ValidateTestRoute")]
        [Route("api/connections/{connectionId}/tests/{testId}/validate")]
        [HttpGet]
        public HttpResponseMessage ValidateTest(int testId, int connectionId)
        {
            var connection = _connectionFactory.CreateConnection(connectionId);
            var test = _testFactory.CreateTest(testId);
            if (test.ProjectId != null && !ValidateConnectionForProject(connectionId, (int) test.ProjectId))
                throw new Exception("Not a valid Connection for this test.");

            var scriptVal = new SqlScriptValidator();
            var valResult = scriptVal.Validate(connection, test);


            _dataRepository.RunHistoryRepository.Insert(test.Id, valResult.RunDateTime, valResult.IsValid,
                valResult.RunLog, valResult.ResultMessage);

            return Request.CreateResponse(HttpStatusCode.OK, valResult);
        }

        private bool ValidateConnectionForProject(int connectionId, int projectId)
        {
            return _dataRepository.ProjectConnectionRepository
                .GetDataByProjectId(projectId).Any(x => x.ConnectionId == connectionId);
        }
    }
}