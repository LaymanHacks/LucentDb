using LucentDb.Common;
using LucentDb.Data;
using LucentDb.Domain;
using LucentDb.Domain.Entities;
using LucentDb.Domain.Model;

namespace LucentDb.Validator
{
    public class SqlScriptValidator : LucentDbValidatorBase, IValidator
    {
        private readonly SqlScriptRunner _sqlScriptRunner;
        private IScriptResolver _scriptResolver;

        public SqlScriptValidator()
        {
            _sqlScriptRunner = new SqlScriptRunner();
        }

        public ValidationResponse Validate(Connection testConnection, Test test)
        {
            if (test == null) return null;
            _scriptResolver = new ScriptResolverFactory(test).GetScriptResolver();
            if (_scriptResolver == null) return null;
            var sqlScriptTest = new SqlScriptTest
            {
                DbConnectionHolder = new DbConnectionHolder(DbConnectionFactory.GetConnection(testConnection)),
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

