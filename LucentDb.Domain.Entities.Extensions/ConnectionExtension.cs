
using System.Linq;
using LucentDb.Data.Repository;

namespace LucentDb.Domain.Entities.Extensions
{
    public static class ConnectionExtensions
    {
        public static Connection IncludeConnectionProvider(this Connection connection,
            IConnectionProviderRepository connectionProviderRepository)
        {
            if (connection.ConnectionProvider != null) return connection;
            connection.ConnectionProvider =
                connectionProviderRepository.GetDataById(connection.ConnectionProviderId).ToList().First();
            return connection;
        }

        public static Connection IncludeProject(this Connection connection, IProjectRepository projectRepository)
        {
            if (connection.Project != null) return connection;
            connection.Project = projectRepository.GetDataByProjectId(connection.ProjectId).ToList().First();
            return connection;
        }
    }
}