namespace LucentDb.Validator
{
    public interface IFileService
    {
        bool FileExists(string testValue);
       
        string OpenTextReadToEnd(string testValue);
    }
}