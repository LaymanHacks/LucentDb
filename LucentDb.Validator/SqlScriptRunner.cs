using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Text;
using LucentDb.Common;
using LucentDb.Domain.Entities;
using LucentDb.Domain.Model;
using LucentDb.Validator.Comparer;

namespace LucentDb.Validator
{
    public class SqlScriptRunner
    {
        private DbConnection _dbConnection;
        
        internal ValidationResponse ValidateSqlScript(DbConnection dbConnection, string scriptValue, Collection<ExpectedResult> expectedResults)
        {
            var valResponse = new ValidationResponse { RunDateTime = DateTime.Now };
            var runLog = new StringBuilder();
            var resultMessage = new StringBuilder();
            _dbConnection = dbConnection;
            try
            {
                using (var conn = _dbConnection)
                {
                    runLog.AppendLine("Opening Connection: " + _dbConnection.ConnectionString);
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = scriptValue;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 600;
                        runLog.AppendLine("Executing Script: " + scriptValue);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                foreach (var expResult in expectedResults)
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
                    runLog.AppendLine("Close Connection: " + _dbConnection.ConnectionString);
                }
            }
            catch (Exception e)
            {
                runLog.AppendFormat("Exception caught: {0}", e.InnerException);
                valResponse.IsValid = false;
                resultMessage.AppendFormat("Error occurred while trying to run validation {0}. \n \n {1} : {2}",
                    scriptValue,
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