using System;

namespace LucentDb.Common
{
    public static class NullCheckExtension
    {
        public static bool IsNullOrDbNull(this object obj)
        {
            return obj == null || obj == DBNull.Value;
        }
    }
}