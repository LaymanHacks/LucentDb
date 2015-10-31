using LucentDb.Domain.Entities;
using LucentDb.Validator.Model;

namespace LucentDb.Validator
{
    public interface IValidator
    {
        ValidationResponse Validate(Connection testConnection, Test test);
    }
}