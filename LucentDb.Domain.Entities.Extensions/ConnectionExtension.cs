using LucentDb.Data.Repository;

namespace LucentDb.Domain.Entities.Extensions
{
    public static class ConnectionExtensions
    {
        public static Connection IncludeProjects(this Connection connection, IProjectRepository projectRepository)
        {
            if (connection.Projects != null) return connection;
            connection.Projects =
                (ProjectList) projectRepository.GetProjectsForConnectionByConnectionId(connection.ConnectionId);
            return connection;
        }
    }
}