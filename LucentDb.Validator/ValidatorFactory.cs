using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Text;

namespace LucentDb.Validator
{
    public class ValidatorFactory
    {
        public IValidator GetDbValidator(string assemblyFile, string typeName)
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
