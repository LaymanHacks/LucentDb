using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucentDb.Validator
{


    public class DoSomething
    {
        public void something()
        {
            var sc = new SomeClass();
            sc.doSomethingCool();

        }
    }

    public class SomeClass
    {
        public void doSomethingCool()
        {
            throw new NotImplementedException();
        }
    }
}
