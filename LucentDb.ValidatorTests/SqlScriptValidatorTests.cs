using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LucentDb.Domain.Entities;
using LucentDb.Validator;
using NUnit.Framework;
namespace LucentDb.Validator.Tests
{
    [TestFixture()]
    public class SqlScriptValidatorTests
    {
        [Test()]
        public void Given_Select_1_With_Result_1_Should_Be_Valid()
        {
            var test = new Test
            {
                Name = "someTest",
                TestValue = "Select 1",
                ExpectedResults = new ExpectedResultList {new ExpectedResult(1, 1, "1", 1, 0)},
                TestType = new TestType(1, "sqlsnippet", "", true)
            };
            var sqlVal = new SqlScriptValidator();
            var valResult = sqlVal.Validate(new Connection(1,"Chinook", @"Data Source=.\sqlexpress;Initial Catalog=Chinook;Integrated Security=True;", true), test);
           Assert.IsTrue(valResult.IsValid);
           Console.WriteLine(valResult.ResultMessage);
        }

        [Test()]
        public void Given_Select_1_With_Result_0_Should_Not_Be_Valid()
        {
            var test = new Test
            {
                Name = "someTest",
                TestValue = "Select 1",
                ExpectedResults = new ExpectedResultList { new ExpectedResult(1, 1, "0", 1, 0) },
                TestType = new TestType(1, "sqlsnippet", "", true)
            };
            var sqlVal = new SqlScriptValidator();
            var valResult = sqlVal.Validate(new Connection(1, "Chinook", @"Data Source=.\sqlexpress;Initial Catalog=Chinook;Integrated Security=True;", true), test);
            Assert.IsFalse(valResult.IsValid);
            Console.WriteLine(valResult.ResultMessage);
        }

        [Test()]
        public void Given_Invalid_TestValue_With_Result_0_Should_Not_Be_Valid()
        {
            var test = new Test
            {
                Name = "someTest",
                TestValue = "Gibberish",
                ExpectedResults = new ExpectedResultList { new ExpectedResult(1, 1, "0", 1, 0) },
                TestType = new TestType(1, "sqlsnippet", "", true)
            };
            var sqlVal = new SqlScriptValidator();
            var valResult = sqlVal.Validate(new Connection(1, "Chinook", @"Data Source=.\sqlexpress;Initial Catalog=Chinook;Integrated Security=True;", true), test);
            Assert.IsFalse(valResult.IsValid);
            Console.WriteLine(valResult.ResultMessage);
        }
    }
}

