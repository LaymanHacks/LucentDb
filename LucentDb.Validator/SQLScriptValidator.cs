using System;
using System.Data.Common;
using System.Text;
using LucentDb.Common;
using LucentDb.Domain.Entities;
using LucentDb.Validator.Comparer;
using LucentDb.Validator.Model;

namespace LucentDb.Validator
{
    public class SqlScriptValidator : LucentDbValidatorBase, IValidator
    {
        private readonly SqlScriptRunner _sqlScriptRunner;
        private ITestValueResolver _scriptResolver;

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
            _scriptResolver = new TestValueResolverFactory(test).GetScriptResolver();
            if (_scriptResolver == null) return null;
            var scriptValue = _scriptResolver.GetTestValue();
            var runLog = new StringBuilder();
            var resultMessage = new StringBuilder();
            var valResponse = new ValidationResponse
            {
                RunDateTime = DateTime.Now,
                TestId = test.Id,
                TestName = test.Name,
                TestValue = test.TestValue
            };
            RunTimer.Reset();
            RunTimer.Start();

            try
            {
                using (var dbConnection = (DbConnection) DbConnectionFactory.GetConnection(testConnection))
                {
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

                                if (valResponse.IsValid)
                                {
                                    resultMessage.Append("Is Valid!");
                                    continue;
                                }
                                resultMessage.AppendFormat("expected: {0} \n but was: {1}",
                                    expResult.ExpectedValue, actual);
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                runLog.AppendFormat("Exception caught: {0}", exception.Message);
                valResponse.IsValid = false;
                resultMessage.AppendFormat("Error occurred while trying to run validation {0}. \n \n {1} : {2}",
                    scriptValue,
                    exception.Message,
                    exception.StackTrace);
            }
            finally
            {
                RunTimer.Stop();
                valResponse.Duration = (decimal) RunTimer.Elapsed.TotalMilliseconds;
                valResponse.RunLog = runLog.ToString();
                valResponse.ResultMessage = resultMessage.ToString();
            }
            return valResponse;
        }
    }
}