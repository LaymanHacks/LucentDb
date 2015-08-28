using System.Linq;
using LucentDb.Data.Repository;

namespace LucentDb.Domain.Entities.Extensions
{
    public static class TestExtensions
    {
        public static Test IncludeExpectedResults(this Test test, IExpectedResultRepository expectedResultRepository)
        {
            if (test.ExpectedResults != null) return test;
            test.ExpectedResults = (ExpectedResultList) expectedResultRepository.GetDataByTestId(test.Id);
            return test;
        }

        public static Test IncludeRunHistories(this Test test, IRunHistoryRepository runHistoryRepository)
        {
            if (test.RunHistories != null) return test;
            test.RunHistories = (RunHistoryList) runHistoryRepository.GetDataByTestId(test.Id);
            return test;
        }

        public static Test IncludeProject(this Test test, IProjectRepository projectRepository)
        {
            if (test.Project != null) return test;
            test.Project = projectRepository.GetDataByProjectId((int) test.ProjectId).ToList().First();
            return test;
        }

        public static Test IncludeTestGroup(this Test test, ITestGroupRepository testGroupRepository)
        {
            if (test.TestGroup != null) return test;
            test.TestGroup = testGroupRepository.GetDataById((int) test.GroupId).ToList().First();
            return test;
        }

        public static Test IncludeTestType(this Test test, ITestTypeRepository testTypeRepository)
        {
            if (test.TestType != null) return test;
            test.TestType = testTypeRepository.GetDataById(test.TestTypeId).ToList().First();
            return test;
        }
    }
}