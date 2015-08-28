using LucentDb.Data.Repository;

namespace LucentDb.Domain.Entities.Extensions
{
    public static class TestTypeExtensions
    {
        public static TestType IncludeTests(this TestType testType, ITestRepository testRepository)
        {
            if (testType.Tests != null) return testType;
            testType.Tests = (TestList) testRepository.GetDataByTestTypeId(testType.Id);
            return testType;
        }
    }
}