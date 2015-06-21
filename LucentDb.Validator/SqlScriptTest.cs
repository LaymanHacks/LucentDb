using System.Collections.ObjectModel;
using LucentDb.Data;
using LucentDb.Domain.Entities;

namespace LucentDb.Validator
{
    internal sealed class SqlScriptTest
    {
       public string ScriptValue { get; set; }
        public Collection<ExpectedResult> ExpectedResults { get; set; }
        public DbConnectionHolder DbConnectionHolder { get; set; }
    }
}