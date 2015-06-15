using System;
using System.Data;
using System.Diagnostics;
using LucentDb.Domain.Entities;

namespace LucentDb.Validator
{
    public class SqlSnippetValidator : IValidator
    {
        private readonly DbConnectionFactory _dbConnectionFactory = new DbConnectionFactory();
        

        public ValidationResponse Validate(string connectionString, Test test)
        {
            var valResponse = new ValidationResponse();
            valResponse.RunDateTime = DateTime.Now;
            var watch = new Stopwatch();
            watch.Start();
            var actual = "NULL";
            
            try
            {
                using (var conn = _dbConnectionFactory.GetConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = test.TestValue;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 600;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (!reader[0].IsNullOrDbNull()) actual = reader[0].ToString();
                            }
                        }
                    }
                }
                valResponse.IsValid = (test.ExpectedResults[0].ExpectedValue == actual);
                if (!valResponse.IsValid)
                    valResponse.ResultMessage = string.Format("expected: {0} \n but was: {1}",
                        test.ExpectedResults[0].ExpectedValue, actual);
            }
            catch (Exception e)
            {
                valResponse.IsValid = false;
                valResponse.ResultMessage = string.Format("Error occurred while trying to run check {0} : {1}",
                    e.Message,
                    e.StackTrace);
            }
            finally
            {
                watch.Stop();
                valResponse.Duration = watch.Elapsed.TotalMilliseconds;
            }
            return valResponse;
        }
    }
}