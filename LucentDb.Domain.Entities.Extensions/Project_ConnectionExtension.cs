using System.Linq;
using LucentDb.Data.Repository;

namespace LucentDb.Domain.Entities.Extensions
{
    public static class Project_ConnectionExtensions
    {
        public static Project_Connection IncludeConnection(this Project_Connection project_Connection,
            IConnectionRepository connectionRepository)
        {
            if (project_Connection.Connection != null) return project_Connection;
            project_Connection.Connection =
                connectionRepository.GetDataByConnectionId(project_Connection.ConnectionId).ToList().First();
            return project_Connection;
        }

        public static Project_Connection IncludeProject(this Project_Connection project_Connection,
            IProjectRepository projectRepository)
        {
            if (project_Connection.Project != null) return project_Connection;
            project_Connection.Project =
                projectRepository.GetDataByProjectId(project_Connection.ProjectId).ToList().First();
            return project_Connection;
        }
    }
}