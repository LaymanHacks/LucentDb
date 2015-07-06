using System.IO;

namespace LucentDb.Validator
{
    public interface IFileService
    {
        bool Exists();
        StreamReader OpenText();
    }
}