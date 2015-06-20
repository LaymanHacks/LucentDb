using System;
using System.Data;
using System.Diagnostics;
using System.Text;
using LucentDb.Domain.Entities;

namespace LucentDb.Validator
{
    public class SqlScriptValidator : IValidator
    {
        private readonly DbConnectionFactory _dbConnectionFactory = new DbConnectionFactory();

        public ValidationResponse Validate(string connectionString, Test test)
        {
            var sqlScriptTest = new SqlScriptTest
            {
                ConnectionString = connectionString,
                ScriptValue = test.TestValue
            };

            

            var valResponse = new ValidationResponse {RunDateTime = DateTime.Now};
            var watch = new Stopwatch();
            watch.Start();
            var response = ValidateSqlScript(valResponse, sqlScriptTest);
            watch.Stop();
            valResponse.Duration = watch.Elapsed.TotalMilliseconds;

            return response;
        }

        private ValidationResponse ValidateSqlScript(ValidationResponse valResponse, SqlScriptTest sqlScriptTest)
        {
            var resultMessage = new StringBuilder();

            try
            {
                using (var conn = _dbConnectionFactory.GetConnection(sqlScriptTest.ConnectionString))
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