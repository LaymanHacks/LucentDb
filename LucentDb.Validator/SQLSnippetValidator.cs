using System;
using System.Data;
using System.Data.Common;
using System.Linq;
using LucentDb.Domain.Entities;

namespace LucentDb.Validator
{
    public class SqlSnippetValidator : IValidator
    {
        private readonly DbConnectionFactory _dbConnectionFactory = new DbConnectionFactory();
        public string ErrorMessage { get; set; }
        public bool IsValid { get; set; }
       public void Validate(string connectionString, Test test)
        {
            var actual = "NULL";
            IsValid = false;
            try
            {
                using (var conn = _dbConnectionFactory.GetConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = testCondition.SqlSnippet;
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
                IsValid = (ExpectedResult.ExpectedValue == actual);
                if (!IsValid) ErrorMessage = string.Format("expected: {0} \n but was: {1}", ExpectedResult.ExpectedValue, actual);
            }
            catch (Exception e)
            {
                IsValid = false;
                ErrorMessage = string.Format("Error occurred while trying to run check {0} : {1}", e.Message, e.StackTrace);
            }
        }

    }
}