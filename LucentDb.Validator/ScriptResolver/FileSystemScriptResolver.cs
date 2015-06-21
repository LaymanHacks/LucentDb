using System.IO;

namespace LucentDb.Validator
{
    public class FileSystemScriptResolver : IScriptResolver
    {
        private readonly string _testValue;

        public FileSystemScriptResolver(string testValue)
        {
            _testValue = testValue;
        }

        public string GetSqlScript()
        {
            if (string.IsNullOrEmpty(_testValue)) return null;
            var fInfo = new FileInfo(_testValue);
            return fInfo.OpenText().ReadToEnd();
        }
    }
}