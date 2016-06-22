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
        private readonly ITestGroupRepository _testGroupRepository;
        private readonly ITestRepository _testRepository;

        public ProjectFactory(IProjectRepository projectRepository, ITestRepository testRepository,
            ITestGroupRepository testGroupRepository, TestFactory testFactory)
        {
            _projectRepository = projectRepository;
            _testRepository = testRepository;
            _testGroupRepository = testGroupRepository;
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

            project.TestGroups = new Collection<TestGroup>();
            foreach (var testGroup in _testGroupRepository.GetActiveDataByProjectId(projectId))
            {
                testGroup.Tests = new Collection<Test>();
                var dTests = new Collection<Test>();
                var group = testGroup;
                foreach (var test in project.Tests.Where(test => test.GroupId == group.Id))
                {
                    testGroup.Tests.Add(test);
                    dTests.Add(test);
                }

                foreach (var test in dTests)
                {
                    project.Tests.Remove(test);
                }

                project.TestGroups.Add(testGroup);
            }


            return project;
        }
    }
}