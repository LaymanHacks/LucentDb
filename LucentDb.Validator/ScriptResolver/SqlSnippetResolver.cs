namespace LucentDb.Validator
{
    public class SqlSnippetResolver : IScriptResolver
    {
        private readonly string _testValue;

        public SqlSnippetResolver(string testValue)
        {
            _testValue = testValue;
        }

        public string GetSqlScript()
        {
            return _testValue;
        }
    }
}