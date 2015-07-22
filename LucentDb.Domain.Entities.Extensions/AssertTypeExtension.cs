
using LucentDb.Data.Repository;
using System.Linq;
  
namespace LucentDb.Domain.Entities.Extensions 
{
  public static class AssertTypeExtensions
  {
   
     
      public static AssertType IncludeExpectedResults(this AssertType assertType, IExpectedResultRepository expectedResultRepository) 
      {
         if (assertType.ExpectedResults != null) return  assertType;   
               assertType.ExpectedResults = (ExpectedResultList)expectedResultRepository.GetDataByAssertTypeId(assertType.Id);
         return  assertType;      
      }
     
  }    
}    
