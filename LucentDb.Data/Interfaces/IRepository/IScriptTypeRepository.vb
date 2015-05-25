'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Generated by Merlin Version: 1.0.0.0
'
'     Changes to this file may cause incorrect behavior and will be lost if 
'     the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------
Imports System
Imports System.Collections.Generic
Imports LucentDb.Domain.Entities


Namespace LucentDb.Data.Repository
    Public Interface IScriptTypeRepository
        Function GetData() as ICollection(Of ScriptType)
        Sub Update(name As String, isActive As Boolean, id As Int32)
        Sub Update(scriptType as ScriptType)
        Sub Delete(id As Int32)
        Sub Delete(scriptType as ScriptType)
        Function Insert(name As String, isActive As Boolean) as Int32
        Function Insert(scriptType as ScriptType) as Int32

        Function GetDataPageable(sortExpression As String, page As Int32, pageSize As Int32) _
            as ICollection(Of ScriptType)

        Function GetRowCount() as Int32
        Function GetDataById(id As Int32) as ICollection(Of ScriptType)
        Function GetActiveData() as ICollection(Of ScriptType)

        Function GetActiveDataPageable(sortExpression As String, page As Int32, pageSize As Int32) _
            as ICollection(Of ScriptType)

        Function GetActiveDataRowCount() as Int32
    End Interface
End NameSpace
