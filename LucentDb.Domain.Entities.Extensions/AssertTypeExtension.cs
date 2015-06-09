//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Generated by Merlin Version: 1.0.0.0
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </autogenerated>
//-----------------------------------------------------------------------------
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
