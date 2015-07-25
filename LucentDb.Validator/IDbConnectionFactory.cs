using System.Data;
using LucentDb.Domain.Entities;

namespace LucentDb.Validator
{
    public interface IDbConnectionFactory
    {
        IDbConnection GetConnection(Connection testConnection);
    }
}