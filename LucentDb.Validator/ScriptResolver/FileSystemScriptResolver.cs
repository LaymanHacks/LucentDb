using System;
using System.IO;

namespace LucentDb.Validator
{
    public class FileSystemScriptResolver : IScriptResolver
    {
        private readonly IFileService _fileInfo;
        private readonly string _scriptFilePath;

        public FileSystemScriptResolver(string testValue)
            : this(testValue, new DefaultFileService(testValue))
        {
        }

        public FileSystemScriptResolver(string scriptFilePath, IFileService fileInfo)
        {
            if (string.IsNullOrEmpty(scriptFilePath)) throw new ArgumentNullException("scriptFilePath");
            _scriptFilePath = scriptFilePath;
            _fileInfo = fileInfo;
        }

        public string GetSqlScript()
        {
            if (!_fileInfo.Exists())
            {
                throw new FileNotFoundException("The file was not found.", _scriptFilePath);
            }
            return _fileInfo.OpenText().ReadToEnd();
        }
    }
}