using LucentDb.Domain;
using LucentDb.Domain.Entities;
using LucentDb.Domain.Model;

namespace LucentDb.Validator
{
    public interface IValidator
    {
        ValidationResponse Validate(Connection testConnection, Test test);
    }
}