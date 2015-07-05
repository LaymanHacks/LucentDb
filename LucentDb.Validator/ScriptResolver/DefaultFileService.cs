using System.IO;

namespace LucentDb.Validator
{
    public class DefaultFileService : IFileService
    {
        public bool FileExists(string fileFullPath)
        {
            var fileInfo = new FileInfo(fileFullPath);
            return fileInfo.Exists;
        }


        public string OpenTextReadToEnd(string fileFullPath)
        {
            var fileInfo = new FileInfo(fileFullPath);
            return fileInfo.OpenText().ReadToEnd();
        }
    }
}