using LucentDb.Domain.Entities;

namespace LucentDb.Validator
{
    public class ScriptResolverFactory
    {
        private readonly Test _test;

        public ScriptResolverFactory(Test test)
        {
            _test = test;
        }

        public IScriptResolver GetScriptResolver()
        {
            switch (_test.TestType.Name.ToLower())
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