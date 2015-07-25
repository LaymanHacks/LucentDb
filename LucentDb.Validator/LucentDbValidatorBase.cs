using System;
using System.Diagnostics;
using LucentDb.Domain.Model;

namespace LucentDb.Validator
{
    public class LucentDbValidatorBase
    {
        protected readonly DbConnectionFactory DbConnectionFactory = new DbConnectionFactory();
        protected Stopwatch RunTimer = new Stopwatch();  
    }
}