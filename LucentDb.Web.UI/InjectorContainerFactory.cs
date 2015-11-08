using LucentDb.Data.DbCommandProvider;
using LucentDb.Data.Repository;
using LucentDb.Data.SqlDbCommandProvider;
using SimpleInjector;

namespace LucentDb.Web.UI
{
    public class InjectorContainerFactory
    {
        public static Container BuildSimpleInjectorContainer()
        {
            var container = new Container();


            container.Register<IDbAssertTypeCommandProvider, SqlDbAssertTypeCommandProvider>();
            container.Register<IAssertTypeRepository, DbAssertTypeRepository>();

            container.Register<IDbConnectionCommandProvider, SqlDbConnectionCommandProvider>();
            container.Register<IConnectionRepository, DbConnectionRepository>();

            container.Register<IDbConnectionProviderCommandProvider, SqlDbConnectionProviderCommandProvider>();
            container.Register<IConnectionProviderRepository, DbConnectionProviderRepository>();

            container.Register<IDbExpectedResultCommandProvider, SqlDbExpectedResultCommandProvider>();
            container.Register<IExpectedResultRepository, DbExpectedResultRepository>();

            container.Register<IDbProjectCommandProvider, SqlDbProjectCommandProvider>();
            container.Register<IProjectRepository, DbProjectRepository>();

            container.Register<IDbRunHistoryCommandProvider, SqlDbRunHistoryCommandProvider>();
            container.Register<IRunHistoryRepository, DbRunHistoryRepository>();

            container.Register<IDbTestCommandProvider, SqlDbTestCommandProvider>();
            container.Register<ITestRepository, DbTestRepository>();

            container.Register<IDbTestGroupCommandProvider, SqlDbTestGroupCommandProvider>();
            container.Register<ITestGroupRepository, DbTestGroupRepository>();

            container.Register<IDbTestTypeCommandProvider, SqlDbTestTypeCommandProvider>();
            container.Register<ITestTypeRepository, DbTestTypeRepository>();

            container.Register<IDbExpectedResultTypeCommandProvider, SqlDbExpectedResultTypeCommandProvider>();
            container.Register<IExpectedResultTypeRepository, DbExpectedResultTypeRepository>();

            container.Register<IDbProjectDetailsViewCommandProvider, SqlDbProjectDetailsViewCommandProvider>();
            container.Register<IProjectDetailsViewRepository, DbProjectDetailsViewRepository>();

            return container;
        }
    }
}