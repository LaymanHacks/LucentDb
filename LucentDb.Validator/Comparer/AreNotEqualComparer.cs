using System.Collections;

namespace LucentDb.Validator.Comparer
{
    public class AreNotEqualComparer : ITestValueComparer
   {
       public bool Compare(object x, object y)
       {
           return new CaseInsensitiveComparer().Compare(x, y) != 0;
       }
   }
}
