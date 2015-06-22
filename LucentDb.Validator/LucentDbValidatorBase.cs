using System;
using System.Diagnostics;
using LucentDb.Domain;

namespace LucentDb.Validator
{
    public class LucentDbValidatorBase
    {
        protected readonly DbConnectionFactory DbConnectionFactory = new DbConnectionFactory();
        protected ValidationResponse ValResponse = new ValidationResponse { RunDateTime = DateTime.Now };
        protected Stopwatch RunTimer = new Stopwatch();
    }
}