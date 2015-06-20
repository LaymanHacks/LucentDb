using System.Collections.ObjectModel;
using LucentDb.Domain.Entities;

namespace LucentDb.Validator
{
    internal sealed class SqlScriptTest
    {
        public string ConnectionString { get; set; }
        public string ScriptValue { get; set; }
        public Collection<ExpectedResult> ExpectedResults { get; set; }
    }
}