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
  public static class ScriptExtensions
  {
   
     
      public static Script IncludeRunHistoriesScript(this Script script, IRunHistoryRepository runHistoryRepository) 
      {
         if (script.RunHistoriesScript != null) return  script;   
               script.RunHistoriesScript = (RunHistoryList)runHistoryRepository.GetDataByScriptId(script.ScriptId);
         return  script;      
      }
  
     
      public static Script IncludeScript_ExpectedResultScript(this Script script, IScript_ExpectedResultRepository script_ExpectedResultRepository) 
      {
         if (script.Script_ExpectedResultScript != null) return  script;   
               script.Script_ExpectedResultScript = (Script_ExpectedResultList)script_ExpectedResultRepository.GetDataByScriptId(script.ScriptId);
         return  script;      
      }
  
     
      public static Script IncludeTest_ScriptScript(this Script script, ITest_ScriptRepository test_ScriptRepository) 
      {
         if (script.Test_ScriptScript != null) return  script;   
               script.Test_ScriptScript = (Test_ScriptList)test_ScriptRepository.GetDataByScriptId(script.ScriptId);
         return  script;      
      }
  
     
      public static Script IncludeScriptTypeScriptType(this Script script, IScriptTypeRepository scriptTypeRepository) 
      {
         if (script.ScriptTypeScriptType != null) return  script;   
               script.ScriptTypeScriptType = scriptTypeRepository.GetDataById(script.ScriptTypeId).ToList().First();
         return  script;      
      }
     
  }    
}    
