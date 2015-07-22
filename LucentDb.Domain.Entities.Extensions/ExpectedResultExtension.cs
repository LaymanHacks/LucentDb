
using LucentDb.Data.Repository;
using System.Linq;
  
namespace LucentDb.Domain.Entities.Extensions 
{
  public static class ExpectedResultExtensions
  {
   
     
      public static ExpectedResult IncludeAssertType(this ExpectedResult expectedResult, IAssertTypeRepository assertTypeRepository) 
      {
         if (expectedResult.AssertType != null) return  expectedResult;   
               expectedResult.AssertType = assertTypeRepository.GetDataById((int) expectedResult.AssertTypeId).ToList().First();
         return  expectedResult;      
      }
  
     
      public static ExpectedResult IncludeExpectedResultType(this ExpectedResult expectedResult, IExpectedResultTypeRepository expectedResultTypeRepository) 
      {
         if (expectedResult.ExpectedResultType != null) return  expectedResult;   
               expectedResult.ExpectedResultType = expectedResultTypeRepository.GetDataById((int) expectedResult.ExpectedResultTypeId).ToList().First();
         return  expectedResult;      
      }
  
     
      public static ExpectedResult IncludeTest(this ExpectedResult expectedResult, ITestRepository testRepository) 
      {
         if (expectedResult.Test != null) return  expectedResult;   
               expectedResult.Test = testRepository.GetDataById(expectedResult.TestId).ToList().First();
         return  expectedResult;      
      }
     
  }    
}    
