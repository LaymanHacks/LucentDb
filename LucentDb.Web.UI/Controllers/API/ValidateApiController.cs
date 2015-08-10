using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
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

        //TODO think about moving this under the Test path so 
        //api/Test/Validate/1/1
        [Route("api/ValidateTest/{testId}/{connectionId}", Name = "ValidateTestRoute")]
        [HttpGet]
        public HttpResponseMessage ValidateTest(int testId, int connectionId)
        {
            var connection = BuildConnection(connectionId);
            var test = BuildTest(testId);
            if (test.ProjectId != null && !ValidateConnectionForProject(connectionId, (int) test.ProjectId))
                throw new Exception("Not a valid Connection for this test.");

            var scriptVal = new SqlScriptValidator();
            var valResult = scriptVal.Validate(connection, test);


            _dataRepository.RunHistoryRepository.Insert(test.Id, valResult.RunDateTime, valResult.IsValid,
                valResult.RunLog, valResult.ResultMessage);

            return Request.CreateResponse(HttpStatusCode.OK, valResult);
        }

        [Route("api/ValidateProject/{projectId}/{connectionId}", Name = "ValidateProjectRoute")]
        [HttpGet]
        public HttpResponseMessage ValidateProject(int projectId, int connectionId)
        {
            var valCollection = new Collection<ValidationResponse>();
            var connection = BuildConnection(connectionId);
            var project = BuildProject(projectId, connectionId);

            var scriptVal = new SqlScriptValidator();

            foreach (
                var valResult in
                    project.Tests.Select(test => scriptVal.Validate(connection, test))
                        .Where(valResult => valResult != null))
            {
                valCollection.Add(valResult);
                _dataRepository.RunHistoryRepository.Insert(project.ProjectId, valResult.RunDateTime, valResult.IsValid,
                    valResult.RunLog, valResult.ResultMessage);
            }
            return Request.CreateResponse(HttpStatusCode.OK, valCollection);
        }

        private Project BuildProject(int projectId, int connectionId)
        {
            var project = _dataRepository.ProjectRepository.GetDataByProjectId(projectId).First();
            project.Tests = new Collection<Test>();
            foreach (var test in _dataRepository.TestRepository.GetActiveDataByProjectId(projectId))
            {
                project.Tests.Add(BuildTest(test.Id));
            }
            
            project.Connections = new Collection<Connection> {BuildConnection(connectionId)};
            project.TestGroups = (Collection<TestGroup>) _dataRepository.TestGroupRepository.GetActiveDataByProjectId(projectId);
            foreach (var testGroup in project.TestGroups)
            {
                testGroup.Tests = (Collection<Test>) _dataRepository.TestRepository.GetActiveDataByGroupId(testGroup.Id);
            }
            return project;
        }

        //TODO refactor
        private Test BuildTest(int testId)
        {
            var test = _dataRepository.TestRepository.GetDataById(testId).First();
            if (test.ProjectId == null) throw new Exception("No valid project for this test.");

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

            return test;
        }

        private bool ValidateConnectionForProject(int connectionId, int projectId)
        {
            return _dataRepository.ProjectConnectionRepository
                .GetDataByProjectId(projectId).Any(x => x.ConnectionId == connectionId);
        }

        //TODO refactor
        private Connection BuildConnection(int connectionId)
        {
            var connectionList = _dataRepository.ConnectionRepository.GetDataByConnectionId(connectionId);
            if (connectionList.Count == 0) throw new Exception("Not a valid connection");
            var connection = connectionList.First();
            connection.ConnectionProvider =
                _dataRepository.ConnectionProviderRepository.GetDataById(connection.ConnectionProviderId)
                    .First();
            return connection;
        }
    }
}