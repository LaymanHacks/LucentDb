using LucentDb.Common;
using LucentDb.Data;
using LucentDb.Domain.Entities;
using LucentDb.Domain.Model;

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

        public SqlScriptValidator(): this(new SqlScriptRunner())
        {
           
        }

        public ValidationResponse Validate(Connection testConnection, Test test)
        {
            if (test == null) return null;
            _scriptResolver = new ScriptResolverFactory(test).GetScriptResolver();
            if (_scriptResolver == null) return null;
            var sqlScriptTest = new SqlScriptTest
            {
                TestDbConnection = DbConnectionFactory.GetConnection(testConnection),
                ScriptValue = _scriptResolver.GetSqlScript(),
                ExpectedResults = test.ExpectedResults.Clone()
            };

            RunTimer.Start();
            var response = _sqlScriptRunner.ValidateSqlScript(DbConnectionFactory.GetConnection(testConnection), _scriptResolver.GetSqlScript(), test.ExpectedResults.Clone());
            RunTimer.Stop();
            if (response != null)
            {
                response.Duration = RunTimer.Elapsed.TotalMilliseconds;
            }
            return response;
        }
    }
}