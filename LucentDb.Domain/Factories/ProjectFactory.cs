using System;
using System.Collections.ObjectModel;
using System.Linq;
using LucentDb.Data.Repository;
using LucentDb.Domain.Entities;

namespace LucentDb.Domain.Factories
{
    public class ProjectFactory
    {
        private readonly IProjectRepository _projectRepository;
        private readonly TestFactory _testFactory;
        private readonly ITestRepository _testRepository;

        public ProjectFactory(IProjectRepository projectRepository, ITestRepository testRepository,
            TestFactory testFactory)
        {
            _projectRepository = projectRepository;
            _testRepository = testRepository;
            _testFactory = testFactory;
        }

        public Project CreateProject(int projectId)
        {
            var project = _projectRepository.GetDataByProjectId(projectId).FirstOrDefault();
            if (project == null) throw new Exception("Project not found.");
            project.Tests = new Collection<Test>();
            foreach (var test in _testRepository.GetActiveDataByProjectId(projectId))
            {
                project.Tests.Add(_testFactory.CreateTest(test.Id));
            }
            return  project;
        }
    }
}