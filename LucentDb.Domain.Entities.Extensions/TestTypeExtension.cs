
using LucentDb.Data.Repository;
using System.Linq;
  
namespace LucentDb.Domain.Entities.Extensions 
{
  public static class TestTypeExtensions
  {
   
     
      public static TestType IncludeTests(this TestType testType, ITestRepository testRepository) 
      {
         if (testType.Tests != null) return  testType;   
               testType.Tests = (TestList)testRepository.GetDataByTestTypeId(testType.Id);
         return  testType;      
      }
     
  }    
}    
