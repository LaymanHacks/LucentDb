using LucentDb.Common;
using LucentDb.Data;
using LucentDb.Domain;
using LucentDb.Domain.Entities;

namespace LucentDb.Validator
{
    public class SqlScriptValidator : SqlScriptValidatorBase, IValidator
    {
        private readonly SqlScriptRunner _sqlScriptRunner;
        private IScriptResolver _scriptResolver;

        public SqlScriptValidator()
        {
            _sqlScriptRunner = new SqlScriptRunner();
        }

        public ValidationResponse Validate(string connectionString, Test test)
        {
            _scriptResolver = new ScriptResolverFactory(test).GetScriptResolver();

            var sqlScriptTest = new SqlScriptTest
            {
                DbConnectionHolder = new DbConnectionHolder(DbConnectionFactory.GetConnection(connectionString)),
                ScriptValue = _scriptResolver.GetSqlScript(),
                ExpectedResults = test.ExpectedResults.Clone()
            };
            
            RunTimer.Start();
            var response = _sqlScriptRunner.ValidateSqlScript(ValResponse, sqlScriptTest);
            RunTimer.Stop();
            ValResponse.Duration = RunTimer.Elapsed.TotalMilliseconds;

            return response;
        }
    }
}

