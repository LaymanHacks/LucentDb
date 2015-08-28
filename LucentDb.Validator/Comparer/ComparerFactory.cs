namespace LucentDb.Validator.Comparer
{
    internal class ComparerFactory
    {
        public ITestValueComparer GetComparer(string comparerType)
        {
            switch (comparerType)
            {
                case "AreNotEqual":
                    return new AreNotEqualComparer();
                default:
                    return new AreEqualComparer();
            }
        }
    }
}