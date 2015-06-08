namespace LucentDb.Validator
{
    public interface IValidator
    {
        string ErrorMessage { get; set; }
        bool IsValid { get; set; }
        void Validate(string connectionString, TestCondition testCondition);
    }
}