namespace LucentDb.Validator
{
    public class SqlSnippetResolver : ITestValueResolver
    {
        private readonly string _testValue;

        public SqlSnippetResolver(string testValue)
        {
            _testValue = testValue;
        }

        public string GetTestValue()
        {
            return _testValue;
        }
    }
}