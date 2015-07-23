using System.Collections.ObjectModel;
using System.Data.Common;
using LucentDb.Data;
using LucentDb.Domain.Entities;

namespace LucentDb.Validator
{
    internal sealed class SqlScriptTest
    {
        public string ScriptValue { get; set; }
        public Collection<ExpectedResult> ExpectedResults { get; set; }
        public DbConnection TestDbConnection { get; set; }
    }
}