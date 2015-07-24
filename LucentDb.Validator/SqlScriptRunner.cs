using System;
using System.Data;
using System.Data.Common;

namespace LucentDb.Validator
{
    public class SqlScriptRunner
    {
        internal DbDataReader RunScript(DbConnection dbConnection, string scriptValue)
        {
            var conn = dbConnection;
            try
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = scriptValue;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 600;
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
            }
            catch (Exception)
            {
                conn.Dispose();
                throw;
            }
        }
    }
}