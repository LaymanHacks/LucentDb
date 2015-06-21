using System;
using System.Data;
using System.Text;
using LucentDb.Common;
using LucentDb.Data;
using LucentDb.Domain;

namespace LucentDb.Validator
{
    public class SqlScriptRunner
    {
        private DbConnectionHolder _dbConnHolder = null;
        
        internal ValidationResponse ValidateSqlScript(ValidationResponse valResponse, SqlScriptTest sqlScriptTest)
        {
            var resultMessage = new StringBuilder();
            _dbConnHolder = sqlScriptTest.DbConnectionHolder;
            try
            {
                using (var conn = _dbConnHolder.Connection)
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sqlScriptTest.ScriptValue;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 600;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                foreach (var expResult in sqlScriptTest.ExpectedResults)
                                {
                                    if (reader[expResult.ResultIndex].IsNullOrDbNull()) continue;
                                    var actual = reader[expResult.ResultIndex].ToString();
                                    valResponse.IsValid = (expResult.ExpectedValue == actual);
                                    if (valResponse.IsValid) continue;
                                    resultMessage.AppendFormat("expected: {0} \n but was: {1}",
                                        expResult.ExpectedValue, actual);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                valResponse.IsValid = false;
                resultMessage.AppendFormat("Error occurred while trying to run check {0} : {1}",
                    e.Message,
                    e.StackTrace);
            }
            finally
            {
                valResponse.ResultMessage = resultMessage.ToString();
            }
            return valResponse;
        }
    }
}