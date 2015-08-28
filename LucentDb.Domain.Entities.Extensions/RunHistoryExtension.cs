using System.Linq;
using LucentDb.Data.Repository;

namespace LucentDb.Domain.Entities.Extensions
{
    public static class RunHistoryExtensions
    {
        public static RunHistory IncludeTest(this RunHistory runHistory, ITestRepository testRepository)
        {
            if (runHistory.Test != null) return runHistory;
            runHistory.Test = testRepository.GetDataById(runHistory.TestId).ToList().First();
            return runHistory;
        }
    }
}