using LucentDb.Domain.Entities;

namespace LucentDb.Domain.Model
{
    public class ValidationTest
    {
        public Connection Connection { get; set; }
        public Test Test { get; set; }

        public ValidationTest(Connection connection, Test test)
        {
            Connection = connection;
            Test = test;

        }
    }
}
