using LucentDb.Data.Repository;
using LucentDb.Data.WebApiRepository;

namespace LucentDb.Domain
{
    public class WebApiRepositoryContext: IRepositoryContext
    {
        public WebApiRepositoryContext(string baseWebApiAddress)
        {
            ConnectionProviderRepository = new WebApiConnectionProviderRepository(baseWebApiAddress);
            ConnectionRepository = new WebApiConnectionRepository(baseWebApiAddress);
            ExpectedResultRepository = new WebApiExpectedResultRepository(baseWebApiAddress);
            ProjectRepository = new WebApiProjectRepository(baseWebApiAddress);
            //ProjectConnectionRepository =
            //    new DbProject_ConnectionRepository(new SqlDbProject_ConnectionCommandProvider());
            RunHistoryRepository = new WebApiRunHistoryRepository(baseWebApiAddress);
            TestRepository = new WebApiTestRepository(baseWebApiAddress);
            TestTypeRepository = new WebApiTestTypeRepository(baseWebApiAddress);
            AssertTypeRepository = new WebApiAssertTypeRepository(baseWebApiAddress);
        }

        public IConnectionProviderRepository ConnectionProviderRepository { get; set; }

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
