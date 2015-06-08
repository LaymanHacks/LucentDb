using System;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace LucentDb.Validator
{
    public class DbConnectionFactory
    {
        public DbConnection GetConnection(string connectionString)
        {
            var providerName = "";
            var csb = new DbConnectionStringBuilder {ConnectionString = connectionString};

            if (!csb.ContainsKey("provider")) throw new Exception("ConnectionString does not contain a provider");

            providerName = csb["provider"].ToString();

            var providerExists = DbProviderFactories
                .GetFactoryClasses()
                .Rows.Cast<DataRow>()
                .Any(r => r[2].Equals(providerName));
            if (!providerExists) return null;

            var factory = DbProviderFactories.GetFactory(providerName);
            var dbConnection = factory.CreateConnection();

            if (dbConnection == null) return null;
            dbConnection.ConnectionString = connectionString;
            return dbConnection;
        }
    }
}