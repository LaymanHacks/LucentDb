using LucentDb.Domain.Entities;
using LucentDb.Domain.Model;
using LucentDb.Validator.Model;

namespace LucentDb.Validator
{
    public interface IValidator
    {
        ValidationResponse Validate(Connection testConnection, Test test);
    }
}