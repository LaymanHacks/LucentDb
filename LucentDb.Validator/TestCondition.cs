namespace LucentDb.Validator
{
    public class TestCondition
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsActive { get; set; }
        public string SqlSnippet { get; set; }
        public string ExpectedResult { get; set; }
    }
}