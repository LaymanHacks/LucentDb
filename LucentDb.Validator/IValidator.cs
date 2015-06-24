using LucentDb.Domain;
using LucentDb.Domain.Entities;

namespace LucentDb.Validator
{
    public interface IValidator
    {
        ValidationResponse Validate(Connection testConnection, Test test);
    }
}