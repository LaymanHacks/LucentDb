using System;
using System.IO;

namespace LucentDb.Validator
{
    public class FileSystemScriptResolver : IScriptResolver
    {
        private readonly string _testValue;
        private readonly IFileService _fileInfo;

        public FileSystemScriptResolver(string testValue) : this(testValue, new DefaultFileService())
        {
        }

        public FileSystemScriptResolver(string testValue, IFileService fileInfo)
        {
            if (string.IsNullOrEmpty(_testValue)) throw new ArgumentNullException("testValue");
            _testValue = testValue;
            _fileInfo = fileInfo;
        }

        public string GetSqlScript()
        {
            if (!_fileInfo.FileExists(_testValue))
            {
                throw new FileNotFoundException("The file was not found.", _testValue);
            }
            return _fileInfo.OpenTextReadToEnd(_testValue);
        }
    }
}