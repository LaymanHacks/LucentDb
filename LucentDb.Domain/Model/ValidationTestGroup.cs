using System.Collections.ObjectModel;
using System.Linq;
using LucentDb.Domain.Entities;
using LucentDb.Validator.Model;

namespace LucentDb.Domain.Model
{
    public class ValidationTestGroup
    {
        public ValidationTestGroup(Connection connection, TestGroup testGroup)
        {
            TestGroupId = testGroup.Id;
            Name = testGroup.Name;
            ValidationTests = new Collection<ValidationTest>();
            foreach (var test in testGroup.Tests)
            {
                ValidationTests.Add(new ValidationTest(connection, test));
            }
        }

        public bool IsValid { get; private set; }
        public string Name { get; private set; }
        public int TestGroupId { get; private set; }
        public Collection<ValidationTest> ValidationTests { get; private set; }

        public Collection<ValidationResponse> Validate()
        {
            var validationResponses = new Collection<ValidationResponse>();
            var isValid = true;
            foreach (var valResponse in ValidationTests.Select(vTest => vTest.Validate()))
            {
                isValid = valResponse.IsValid && isValid;
                validationResponses.Add(valResponse);
            }
            IsValid = isValid;
            return validationResponses;
        }
    }
}