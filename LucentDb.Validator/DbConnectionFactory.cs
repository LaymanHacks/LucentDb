using System.Data.Common;
using LucentDb.Domain.Entities;

namespace LucentDb.Validator
{
    public class DbConnectionFactory
    {
        public DbConnection GetConnection(Connection testConnection)
        {
            var providerName = "";
            var csb = new DbConnectionStringBuilder {ConnectionString = testConnection.ConnectionString};

            //if (!csb.ContainsKey("provider")) throw new Exception("ConnectionString does not contain a provider");

            //providerName = csb["provider"].ToString();

            //var providerExists = DbProviderFactories
            //    .GetFactoryClasses()
            //    .Rows.Cast<DataRow>()
            //    .Any(r => r[2].Equals(providerName));
            //if (!providerExists) return null;

            var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            var dbConnection = factory.CreateConnection();

            if (dbConnection == null) return null;
            dbConnection.ConnectionString = testConnection.ConnectionString;
            return dbConnection;
        }
    }
}