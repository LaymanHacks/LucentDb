using LucentDb.Domain.Entities;

namespace LucentDb.Validator
{
    public interface IValidator
    {
       ValidationResponse Validate(string connectionString, Test test);
    }
}