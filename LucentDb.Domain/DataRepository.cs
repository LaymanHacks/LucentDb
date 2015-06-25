using LucentDb.Data.Repository;
using LucentDb.Data.SqlDbCommandProvider;

namespace LucentDb.Domain
{
    public class RepositoryContext
    {
        public RepositoryContext()
        {
            ConnectionRepository = new DbConnectionRepository(new SqlDbConnectionCommandProvider());
            ExpectedResultRepository = new DbExpectedResultRepository(new SqlDbExpectedResultCommandProvider());
            ProjectRepository = new DbProjectRepository(new SqlDbProjectCommandProvider());
            ProjectConnectionRepository =
                new DbProject_ConnectionRepository(new SqlDbProject_ConnectionCommandProvider());
            RunHistoryRepository = new DbRunHistoryRepository(new SqlDbRunHistoryCommandProvider());
            TestRepository = new DbTestRepository(new SqlDbTestCommandProvider());
            TestTypeRepository = new DbTestTypeRepository(new SqlDbTestTypeCommandProvider());
            AssertTypeRepository = new DbAssertTypeRepository(new SqlDbAssertTypeCommandProvider());
        }

        public IAssertTypeRepository AssertTypeRepository { get; set; }
        public ITestTypeRepository TestTypeRepository { get; set; }
        public ITestRepository TestRepository { get; set; }
        public IRunHistoryRepository RunHistoryRepository { get; set; }
        public IProject_ConnectionRepository ProjectConnectionRepository { get; set; }
        public IProjectRepository ProjectRepository { get; set; }
        public IExpectedResultRepository ExpectedResultRepository { get; set; }
        public IConnectionRepository ConnectionRepository { get; set; }
    }
}