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
   
     
      public static RunHistory IncludeScript(this RunHistory runHistory, IScriptRepository scriptRepository) 
      {
         if (runHistory.Script != null) return  runHistory;   
               runHistory.Script = scriptRepository.GetDataById(runHistory.ScriptId).ToList().First();
         return  runHistory;      
      }
     
  }    
}    
