using System;
using System.Reflection;
using LucentDb.Domain.Entities;

namespace LucentDb.Validator
{
    public class ValidatorFactory
    {
        public IValidator GetDbValidator(string connectionString, Test test, string assemblyFile, string typeName)
        {
            var assembly = Assembly.LoadFrom(assemblyFile);
            dynamic tempType = assembly.GetType(typeName);

            IValidator validator = Activator.CreateInstance(tempType,
                new object[]
                {
                });
            return validator;
        }
    }
}