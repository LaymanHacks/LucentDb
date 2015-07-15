using System;
using LucentDb.Domain.Entities;
using NUnit.Framework;

namespace LucentDb.Validator.Tests
{
    [TestFixture]
    public class SqlScriptValidatorTests
    {
        [Test]
        public void Given_Invalid_TestValue_With_Result_0_Should_Not_Be_Valid()
        {
            var test = new Test
            {
                Name = "someTest",
                TestValue = "Gibberish",
                ExpectedResults = new ExpectedResultList { new ExpectedResult(1, 1, 1, 1, "0", 0) { AssertType = new AssertType(1, "AreEqual") } },
                TestType = new TestType(1, "sqlsnippet", "", true)
            };
            var sqlVal = new SqlScriptValidator();
            var valResult =
                sqlVal.Validate(
                    new Connection(1, 1, "Chinook",
                        @"Data Source=.\sqlexpress;Initial Catalog=Chinook;Integrated Security=True;", true), test);
            Assert.IsFalse(valResult.IsValid);
            Console.WriteLine(valResult.ResultMessage);
        }

    

        [Test]
        public void Given_Select_1_With_Result_0_Should_Not_Be_Valid()
        {
            var test = new Test
            {
                Name = "someTest",
                TestValue = "Select 1",
                ExpectedResults = new ExpectedResultList { new ExpectedResult(1, 1, 1, 1, "0", 0) { AssertType = new AssertType(1, "AreEqual") } },
                TestType = new TestType(1, "sqlsnippet", "", true)
            };
            var sqlVal = new SqlScriptValidator();
            var valResult =
                sqlVal.Validate(
                    new Connection(1, 1, "Chinook",
                        @"Data Source=.\sqlexpress;Initial Catalog=Chinook;Integrated Security=True;", true), test);
            Assert.IsFalse(valResult.IsValid);
            Console.WriteLine(valResult.ResultMessage);
        }

        [Test]
        public void Given_Select_1_With_Result_0_Should_Be_Valid_With_AreNotEqual_AssertType()
        {
            var test = new Test
            {
                Name = "someTest",
                TestValue = "Select 1",
                ExpectedResults = new ExpectedResultList { new ExpectedResult(1, 1, 1, 1, "0", 0) { AssertType = new AssertType(2, "AreNotEqual") } },
                TestType = new TestType(1, "sqlsnippet", "", true)
            };
            var sqlVal = new SqlScriptValidator();
            var valResult =
                sqlVal.Validate(
                    new Connection(1, 1, "Chinook",
                        @"Data Source=.\sqlexpress;Initial Catalog=Chinook;Integrated Security=True;", true), test);
            Assert.IsTrue(valResult.IsValid);
            Console.WriteLine(valResult.ResultMessage);
        }

        [Test]
        public void Given_Select_62_With_Result_7_Should_Not_Be_Valid()
        {
            var test = new Test
            {
                Name = "someTest",
                TestValue = "Select 62",

                ExpectedResults = new ExpectedResultList { new ExpectedResult(1, 1, 1, 1, "7", 0) { AssertType = new AssertType(1, "AreEqual") } },
                TestType = new TestType(1, "sqlsnippet", "", true)
            };
            var sqlVal = new SqlScriptValidator();
            var valResult =
                sqlVal.Validate(
                    new Connection(1, 1, "Chinook",
                        @"Data Source=.\sqlexpress;Initial Catalog=Chinook;Integrated Security=True;", true), test);
            Assert.IsFalse(valResult.IsValid);
            Console.WriteLine(valResult.ResultMessage);
        }

        [Test]
        public void Given_Select_1_With_Result_1_Should_Be_Valid()
        {
            var test = new Test
            {
                Name = "someTest",
                TestValue = "Select 1",
                ExpectedResults = new ExpectedResultList { new ExpectedResult(1, 1, 1, 1, "1", 0) { AssertType = new AssertType(1,"AreEqual")} },
                TestType = new TestType(1, "sqlsnippet", "", true)
            };
            var sqlVal = new SqlScriptValidator();
            var valResult =
                sqlVal.Validate(
                    new Connection(1, 1, "Chinook",
                        @"Data Source=.\sqlexpress;Initial Catalog=Chinook;Integrated Security=True;", true), test);
            Assert.IsTrue(valResult.IsValid);
            Console.WriteLine(valResult.ResultMessage);
        }

        [Test]
        public void Given_Select_ABC_With_Result_ABC_Should_Be_Valid()
        {
            var test = new Test
            {
                Name = "someTest",
                TestValue = "Select 'ABC'",
                ExpectedResults = new ExpectedResultList { new ExpectedResult(1, 1, 1, 1, "ABC", 0) { AssertType = new AssertType(1, "AreEqual") } },
                TestType = new TestType(1, "sqlsnippet", "", true)
            };
            var sqlVal = new SqlScriptValidator();
            var valResult =
                sqlVal.Validate(
                    new Connection(1, 1, "Chinook",
                        @"Data Source=.\sqlexpress;Initial Catalog=Chinook;Integrated Security=True;", true), test);
            Assert.IsTrue(valResult.IsValid);
            Console.WriteLine(valResult.ResultMessage);
        }
    }
}