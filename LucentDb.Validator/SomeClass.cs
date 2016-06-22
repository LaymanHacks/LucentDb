using System;

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