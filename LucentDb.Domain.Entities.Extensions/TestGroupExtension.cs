using System.Linq;
using LucentDb.Data.Repository;

namespace LucentDb.Domain.Entities.Extensions
{
    public static class TestGroupExtensions
    {
        public static TestGroup IncludeTests(this TestGroup testGroup, ITestRepository testRepository)
        {
            if (testGroup.Tests != null) return testGroup;
            testGroup.Tests = (TestList) testRepository.GetDataByGroupId(testGroup.Id);
            return testGroup;
        }

        public static TestGroup IncludeProject(this TestGroup testGroup, IProjectRepository projectRepository)
        {
            if (testGroup.Project != null) return testGroup;
            testGroup.Project = projectRepository.GetDataByProjectId(testGroup.ProjectId).ToList().First();
            return testGroup;
        }
    }
}