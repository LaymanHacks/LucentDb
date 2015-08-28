using System.Diagnostics;

namespace LucentDb.Validator
{
    public class LucentDbValidatorBase
    {
        protected readonly DbConnectionFactory DbConnectionFactory = new DbConnectionFactory();
        protected Stopwatch RunTimer = new Stopwatch();
    }
}