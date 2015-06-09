using LucentDb.Data.Repository;
using LucentDb.Data.SqlDbCommandProvider;

namespace LucentDb.Domain
{
    public class DataRepository
    {
        public DataRepository()
        {
            ConnectionRepository = new DbConnectionRepository(new SqlDbConnectionCommandProvider());
            ExpectedResultRepository = new DbExpectedResultRepository(new SqlDbExpectedResultCommandProvider());
            ProjectRepository = new DbProjectRepository(new SqlDbProjectCommandProvider());
            ProjectConnectionRepository =
                new DbProject_ConnectionRepository(new SqlDbProject_ConnectionCommandProvider());
            RunHistoryRepository = new DbRunHistoryRepository(new SqlDbRunHistoryCommandProvider());
            //ScriptRepository = new DbScriptRepository(new SqlDbScriptCommandProvider());
            //ScriptTypeRepository = new DbScriptTypeRepository(new SqlDbScriptTypeCommandProvider());
            TestRepository = new DbTestRepository(new SqlDbTestCommandProvider());
            TestTypeRepository = new DbTestTypeRepository(new SqlDbTestTypeCommandProvider());
            //TestScriptRepository = new DbTest_ScriptRepository(new SqlDbTest_ScriptCommandProvider());
            AssertTypeRepository = new DbAssertTypeRepository(new SqlDbAssertTypeCommandProvider());
          //  ScriptExpectedResultRepository = new DbScript_ExpectedResultRepository(new SqlDbScript_ExpectedResultCommandProvider());
        }

     //   public IScript_ExpectedResultRepository ScriptExpectedResultRepository { get; set; }
        public IAssertTypeRepository AssertTypeRepository { get; set; }
     //   public ITest_ScriptRepository TestScriptRepository { get; set; }
        public ITestTypeRepository TestTypeRepository { get; set; }
        public ITestRepository TestRepository { get; set; }
     //   public IScriptTypeRepository ScriptTypeRepository { get; set; }
     //   public IScriptRepository ScriptRepository { get; set; }
        public IRunHistoryRepository RunHistoryRepository { get; set; }
        public IProject_ConnectionRepository ProjectConnectionRepository { get; set; }
        public IProjectRepository ProjectRepository { get; set; }
        public IExpectedResultRepository ExpectedResultRepository { get; set; }
        public IConnectionRepository ConnectionRepository { get; set; }
    }
}