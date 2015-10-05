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
  public static class RunHistoryExtensions
  {
   
     
      public static RunHistory IncludeRunHistoryDetail(this RunHistory runHistory, IRunHistoryDetailRepository RunHistoryDetailRepository) 
      {
         if (runHistory.RunHistoryDetail != null) return  runHistory;   
               runHistory.RunHistoryDetail = (RunHistoryDetailList)RunHistoryDetailRepository.GetDataByRunHistoryId(runHistory.Id);
         return  runHistory;      
      }
  
     
      public static RunHistory IncludeTest(this RunHistory runHistory, ITestRepository testRepository) 
      {
         if (runHistory.Test != null) return  runHistory;
          if (runHistory.TestId != null)
              runHistory.Test = testRepository.GetDataById((int) runHistory.TestId).ToList().First();
          return  runHistory;      
      }
     
  }    
}    
