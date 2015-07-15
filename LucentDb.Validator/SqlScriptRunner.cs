using System;
using System.Data;
using System.Text;
using LucentDb.Common;
using LucentDb.Data;
using LucentDb.Domain.Model;
using LucentDb.Validator.Comparer;

namespace LucentDb.Validator
{
    public class SqlScriptRunner
    {
        private DbConnectionHolder _dbConnHolder;

        internal ValidationResponse ValidateSqlScript(ValidationResponse valResponse, SqlScriptTest sqlScriptTest)
        {
            var runLog = new StringBuilder();
            var resultMessage = new StringBuilder();
            _dbConnHolder = sqlScriptTest.DbConnectionHolder;
            try
            {
                using (var conn = _dbConnHolder.Connection)
                {
                    runLog.AppendLine("Opening Connection: " + _dbConnHolder.Connection.ConnectionString);
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sqlScriptTest.ScriptValue;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 600;
                        runLog.AppendLine("Executing Script: " + sqlScriptTest.ScriptValue);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                foreach (var expResult in sqlScriptTest.ExpectedResults)
                                {
                                    if (reader[expResult.ResultIndex].IsNullOrDbNull()) continue;
                                    var actual = reader[expResult.ResultIndex].ToString();
                                    runLog.AppendFormat("Comparing results: Expected = {0} \n Response = {1} \n",
                                        expResult.ExpectedValue, actual);

                                    var comparerFactory = new ComparerFactory();
                                    var comparer = comparerFactory.GetComparer(expResult.AssertType.Name);
                                    valResponse.IsValid = comparer.Compare(expResult.ExpectedValue, actual);

                                    if (valResponse.IsValid) continue;
                                    resultMessage.AppendFormat("expected: {0} \n but was: {1}",
                                        expResult.ExpectedValue, actual);
                                    break;
                                }
                            }
                        }
                    }
                    runLog.AppendLine("Close Connection: " + _dbConnHolder.Connection.ConnectionString);
                }
            }
            catch (Exception e)
            {
                runLog.AppendFormat("Exception caught: {0}", e.InnerException);
                valResponse.IsValid = false;
                resultMessage.AppendFormat("Error occurred while trying to run validation {0}. \n \n {1} : {2}",
                    sqlScriptTest.ScriptValue,
                    e.Message,
                    e.StackTrace);
            }
            finally
            {
                valResponse.RunLog = runLog.ToString();
                valResponse.ResultMessage = resultMessage.ToString();
            }
            return valResponse;
        }
    }
}