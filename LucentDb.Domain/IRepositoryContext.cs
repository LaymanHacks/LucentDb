using LucentDb.Data.Repository;

namespace LucentDb.Domain
{
    public interface IRepositoryContext
    {
        IAssertTypeRepository AssertTypeRepository { get; set; }
        ITestTypeRepository TestTypeRepository { get; set; }
        ITestRepository TestRepository { get; set; }
        IRunHistoryRepository RunHistoryRepository { get; set; }
        IProject_ConnectionRepository ProjectConnectionRepository { get; set; }
        IProjectRepository ProjectRepository { get; set; }
        IExpectedResultRepository ExpectedResultRepository { get; set; }
        IConnectionRepository ConnectionRepository { get; set; }
        IConnectionProviderRepository ConnectionProviderRepository { get; set; }
        ITestGroupRepository TestGroupRepository { get; set; }
    }
}