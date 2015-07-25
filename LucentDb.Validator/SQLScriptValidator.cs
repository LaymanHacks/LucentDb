using System;
using System.Data.Common;
using System.Text;
using LucentDb.Common;
using LucentDb.Domain.Entities;
using LucentDb.Domain.Model;
using LucentDb.Validator.Comparer;

namespace LucentDb.Validator
{
    public class SqlScriptValidator : LucentDbValidatorBase, IValidator
    {
        private readonly SqlScriptRunner _sqlScriptRunner;
        private IScriptResolver _scriptResolver;

        public SqlScriptValidator(SqlScriptRunner sqlScriptRunner)
        {
            _sqlScriptRunner = sqlScriptRunner;
        }

        public SqlScriptValidator() : this(new SqlScriptRunner())
        {
        }

        public ValidationResponse Validate(Connection testConnection, Test test)
        {
            if (test == null) return null;
            _scriptResolver = new ScriptResolverFactory(test).GetScriptResolver();
            if (_scriptResolver == null) return null;
            var scriptValue = _scriptResolver.GetSqlScript();
            var runLog = new StringBuilder();
            var resultMessage = new StringBuilder();
            var valResponse = new ValidationResponse {RunDateTime = DateTime.Now};

            RunTimer.Start();
            try
            {
                var dbConnection = (DbConnection)DbConnectionFactory.GetConnection(testConnection);
                using (
                    var reader = _sqlScriptRunner.RunScript(dbConnection,
                        scriptValue))
                {
                    while (reader.Read())
                    {
                        foreach (var expResult in test.ExpectedResults.Clone())
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
                RunTimer.Stop();
                valResponse.Duration = RunTimer.Elapsed.TotalMilliseconds;
                valResponse.RunLog = runLog.ToString();
                valResponse.ResultMessage = resultMessage.ToString();
            }
            return valResponse;
        }
    }
}