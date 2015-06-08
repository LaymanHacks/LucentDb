using System;

namespace LucentDb.Validator
{
    public static class LucentExtensions
    {
        public static bool IsNullOrDbNull(this object obj)
        {
            return obj == null || obj == DBNull.Value;
        }
    }
}