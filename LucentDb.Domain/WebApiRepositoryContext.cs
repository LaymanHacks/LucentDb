using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LucentDb.Data.Repository;
using LucentDb.Data.WebApiRepository;


namespace LucentDb.Domain
{
    class WebApiRepositoryContext: IRepositoryContext
    {
        public WebApiRepositoryContext()
        {
            ConnectionRepository = new WebApiConnectionRepository("");
            ExpectedResultRepository = new WebApiExpectedResultRepository("");
            ProjectRepository = new WebApiProjectRepository("");
            //ProjectConnectionRepository =
            //    new DbProject_ConnectionRepository(new SqlDbProject_ConnectionCommandProvider());
            RunHistoryRepository = new WebApiRunHistoryRepository("");
            TestRepository = new WebApiTestRepository("");
            TestTypeRepository = new WebApiTestTypeRepository("");
            AssertTypeRepository = new WebApiAssertTypeRepository("");
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
