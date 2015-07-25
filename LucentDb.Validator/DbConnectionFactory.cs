using System.Data;
using System.Data.Common;
using LucentDb.Domain.Entities;

namespace LucentDb.Validator
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        public IDbConnection GetConnection(Connection testConnection)
        {
            if (testConnection.ConnectionProvider == null) return null;
            var factory = DbProviderFactories.GetFactory(testConnection.ConnectionProvider.Value);
            var dbConnection = factory.CreateConnection();

            if (dbConnection == null) return null;
            dbConnection.ConnectionString = testConnection.ConnectionString;
            return dbConnection;
        }
    }
}