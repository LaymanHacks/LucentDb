using LucentDb.Domain.Entities;

namespace LucentDb.Validator.Model
{
    public class ValidationTest
    {
        public ValidationTest(Connection connection, Test test)
        {
            Connection = connection;
            Test = test;
        }

        public Connection Connection { get; private set; }
        public Test Test { get; private set; }
        public ValidationResponse Response { get; private set; }

        public void Validate()
        {
            var scriptVal = new SqlScriptValidator();
            Response = scriptVal.Validate(Connection, Test);
        }
    }
}