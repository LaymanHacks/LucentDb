using System;
using System.Collections.ObjectModel;
using System.Linq;
using LucentDb.Data.Repository;
using LucentDb.Domain.Entities;

namespace LucentDb.Domain.Factories
{
    public class TestFactory
    {
        private readonly IAssertTypeRepository _assertTypeRepository;
        private readonly IExpectedResultRepository _expectedResultRepository;
        private readonly ITestRepository _testRepository;
        private readonly ITestTypeRepository _testTypeRepository;
        private readonly ITestValueTypeRepository _testValueTypeRepository;

        public TestFactory(ITestRepository testRepository, ITestTypeRepository testTypeRepository,ITestValueTypeRepository testValueTypeRepository,
            IExpectedResultRepository expectedResultRepository, IAssertTypeRepository assertTypeRepository)
        {
            _testRepository = testRepository;
            _testTypeRepository = testTypeRepository;
            _testValueTypeRepository = testValueTypeRepository;
            _expectedResultRepository = expectedResultRepository;
            _assertTypeRepository = assertTypeRepository;
        }

        public Test CreateTest(int testId)
        {
            var test = _testRepository.GetDataById(testId).FirstOrDefault();
            if (test == null) throw new Exception("Test not found.");

            test.TestType = _testTypeRepository.GetDataById(test.TestTypeId).FirstOrDefault();
            test.TestValueType = _testValueTypeRepository.GetDataById(test.TestValueTypeId).FirstOrDefault();

            test.ExpectedResults =
                (Collection<ExpectedResult>) _expectedResultRepository.GetDataByTestId(test.Id);

            foreach (var expResult in test.ExpectedResults)
            {
                if (expResult == null) continue;
                if (expResult.AssertTypeId != null)
                    expResult.AssertType = _assertTypeRepository.GetDataById((int) expResult.AssertTypeId)
                        .FirstOrDefault();
            }

            return test;
        }
    }
}