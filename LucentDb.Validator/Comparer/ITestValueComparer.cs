namespace LucentDb.Validator.Comparer
{
    public interface ITestValueComparer
    {
        bool Compare(object x, object y);
    }
}