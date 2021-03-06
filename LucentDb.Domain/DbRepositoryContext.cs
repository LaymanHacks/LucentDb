﻿using LucentDb.Data.Repository;
using LucentDb.Data.SqlDbCommandProvider;

namespace LucentDb.Domain
{
    public class DbRepositoryContext : ILucentDbRepositoryContext
    {
        public DbRepositoryContext()
        {
            ConnectionRepository = new DbConnectionRepository(new SqlDbConnectionCommandProvider());
            ExpectedResultRepository = new DbExpectedResultRepository(new SqlDbExpectedResultCommandProvider());
            ProjectRepository = new DbProjectRepository(new SqlDbProjectCommandProvider());

            RunHistoryRepository = new DbRunHistoryRepository(new SqlDbRunHistoryCommandProvider());
            TestRepository = new DbTestRepository(new SqlDbTestCommandProvider());
            TestTypeRepository = new DbTestTypeRepository(new SqlDbTestTypeCommandProvider());
            TestValueTypeRepository = new DbTestValueTypeRepository(new SqlDbTestValueTypeCommandProvider());
            AssertTypeRepository = new DbAssertTypeRepository(new SqlDbAssertTypeCommandProvider());
            ConnectionProviderRepository =
                new DbConnectionProviderRepository(new SqlDbConnectionProviderCommandProvider());
            TestGroupRepository = new DbTestGroupRepository(new SqlDbTestGroupCommandProvider());
            RunHistoryDetailRepository = new DbRunHistoryDetailRepository(new SqlDbRunHistoryDetailCommandProvider());
        }

        public IAssertTypeRepository AssertTypeRepository { get; set; }
        public ITestTypeRepository TestTypeRepository { get; set; }
        public ITestRepository TestRepository { get; set; }
        public IRunHistoryRepository RunHistoryRepository { get; set; }
        public IProjectRepository ProjectRepository { get; set; }
        public IExpectedResultRepository ExpectedResultRepository { get; set; }
        public IConnectionRepository ConnectionRepository { get; set; }
        public IConnectionProviderRepository ConnectionProviderRepository { get; set; }
        public ITestGroupRepository TestGroupRepository { get; set; }
        public IRunHistoryDetailRepository RunHistoryDetailRepository { get; set; }
        public ITestValueTypeRepository TestValueTypeRepository { get; set; }
    }
}