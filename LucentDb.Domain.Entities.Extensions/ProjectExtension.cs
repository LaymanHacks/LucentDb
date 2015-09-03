

using LucentDb.Data.Repository;

namespace LucentDb.Domain.Entities.Extensions
{
    public static class ProjectExtensions
    {
        public static Project IncludeConnections(this Project project, IConnectionRepository connectionRepository)
        {
            if (project.Connections != null) return project;
            project.Connections = (ConnectionList) connectionRepository.GetDataByProjectId(project.ProjectId);
            return project;
        }

        public static Project IncludeTests(this Project project, ITestRepository testRepository)
        {
            if (project.Tests != null) return project;
            project.Tests = (TestList) testRepository.GetDataByProjectId(project.ProjectId);
            return project;
        }

        public static Project IncludeTestGroups(this Project project, ITestGroupRepository testGroupRepository)
        {
            if (project.TestGroups != null) return project;
            project.TestGroups = (TestGroupList) testGroupRepository.GetDataByProjectId(project.ProjectId);
            return project;
        }
    }
}