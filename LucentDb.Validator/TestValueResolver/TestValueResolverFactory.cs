using LucentDb.Domain.Entities;

namespace LucentDb.Validator
{
    public class TestValueResolverFactory
    {
        private readonly Test _test;

        public TestValueResolverFactory(Test test)
        {
            _test = test;
        }

        public ITestValueResolver GetScriptResolver()
        {
            if (_test.TestValueType == null) return null;
            switch (_test.TestValueType.Name.ToLower())
            {
                case "filesystem":
                    return new FileSystemScriptResolver(_test.TestValue);
                case "httpfile":
                    return new HttpScriptResolver(_test.TestValue);
                case "sqlsnippet":
                    return new SqlSnippetResolver(_test.TestValue);
                default:
                    return new SqlSnippetResolver(_test.TestValue);
            }
        }
    }
}