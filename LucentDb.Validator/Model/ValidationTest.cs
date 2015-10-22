using LucentDb.Domain.Entities;

namespace LucentDb.Validator.Model
{
    public class ValidationTest
    {
        public Connection Connection { get; private set; }
        public Test Test { get; private set; }

        public ValidationTest(Connection connection, Test test)
        {
            Connection = connection;
            Test = test;

        }

        public  ValidationResponse Validate()
        {
            var scriptVal = new SqlScriptValidator();
           return scriptVal.Validate(Connection, Test);
            
        }
    }
}
