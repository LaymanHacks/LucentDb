using System.IO;

namespace LucentDb.Validator
{
    public class DefaultFileService : IFileService
    {
        private readonly FileInfo _fileInfo;

        public DefaultFileService(string fileFullPath)
        {
            _fileInfo = new FileInfo(fileFullPath);
        }

        public bool Exists()
        {
            return _fileInfo.Exists;
        }

        public StreamReader OpenText()
        {
            return _fileInfo.OpenText();
        }
    }
}