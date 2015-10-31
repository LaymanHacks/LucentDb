using System.Runtime.Serialization;
using LucentDb.Domain.Entities;
using LucentDb.Validator;
using LucentDb.Validator.Model;

namespace LucentDb.Domain.Model
{
    [DataContract]
    public class ValidationTest
    {
        public ValidationTest(Connection connection, Test test)
        {
            Connection = connection;
            Test = test;
        }

        public Connection Connection { get; private set; }
        public Test Test { get; private set; }

        [DataMember]
        public ValidationResponse Response { get; private set; }

        public ValidationResponse Validate()
        {
            var scriptVal = new SqlScriptValidator();
            Response = scriptVal.Validate(Connection, Test);
            return Response;
        }
    }
}