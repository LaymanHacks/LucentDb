using System;
using System.Collections.ObjectModel;
using System.Linq;
using LucentDb.Data.Repository;
using LucentDb.Domain.Entities;

namespace LucentDb.Domain
{
    public class TestGroupFactory
    {
        private readonly TestFactory _testFactory;
        private readonly ITestRepository _testRepository;
        private readonly ITestGroupRepository _testGroupRepository;


        public TestGroupFactory(ITestRepository testRepository, ITestGroupRepository testGroupRepository, TestFactory testFactory)
        {
            _testRepository = testRepository;
            _testGroupRepository = testGroupRepository;
            _testFactory = testFactory;
        }

        public TestGroup CreateTestGroup(int groupId)
        {
            var testGroup = _testGroupRepository.GetDataById(groupId).FirstOrDefault();
            if (testGroup == null) throw new Exception("Test Group not found.");
            
            testGroup.Tests = new Collection<Test>();
            foreach (var test in _testRepository.GetActiveDataByGroupId(groupId))
            {
                testGroup.Tests.Add(_testFactory.CreateTest(test.Id));
            }

            return testGroup;
            
        }
    }
}