
using LucentDb.Data.Repository;
using System.Linq;
  
namespace LucentDb.Domain.Entities.Extensions 
{
  public static class ExpectedResultTypeExtensions
  {
   
     
      public static ExpectedResultType IncludeExpectedResults(this ExpectedResultType expectedResultType, IExpectedResultRepository expectedResultRepository) 
      {
         if (expectedResultType.ExpectedResults != null) return  expectedResultType;   
               expectedResultType.ExpectedResults = (ExpectedResultList)expectedResultRepository.GetDataByExpectedResultTypeId(expectedResultType.Id);
         return  expectedResultType;      
      }
     
  }    
}    
