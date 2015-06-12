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
Imports LucentDb.Data
Imports LucentDb.Domain.Entities

  
 Namespace LucentDb.Data.Repository     
    Public Interface ITestGroupRepository
        Function GetData()  as ICollection(Of TestGroup)
        Sub Update( ByVal projectId As Int32,  ByVal name As String,  ByVal isActive As Boolean,  ByVal id As Int32) 
        Sub Update(ByVal testGroup as TestGroup) 
        Sub Delete( ByVal id As Int32) 
        Sub Delete(ByVal testGroup as TestGroup) 
        Function Insert( ByVal projectId As Int32,  ByVal name As String,  ByVal isActive As Boolean)  as Int32
        Function Insert(ByVal testGroup as TestGroup)  as Int32
        Function GetDataPageable( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as ICollection(Of TestGroup)
        Function GetRowCount()  as Int32
        Function GetDataById( ByVal id As Int32)  as ICollection(Of TestGroup)
        Function GetActiveData()  as ICollection(Of TestGroup)
        Function GetActiveDataPageable( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as ICollection(Of TestGroup)
        Function GetActiveDataRowCount()  as Int32
        Function GetDataByProjectId( ByVal projectId As Int32)  as ICollection(Of TestGroup)
        Function GetDataByProjectIdPageable( ByVal projectId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as ICollection(Of TestGroup)
        Function GetDataByProjectIdRowCount( ByVal projectId As Int32)  as Int32
        Function GetActiveDataByProjectId( ByVal projectId As Int32)  as ICollection(Of TestGroup)
        Function GetActiveDataByProjectIdPageable( ByVal projectId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as ICollection(Of TestGroup)
        Function GetActiveDataByProjectIdRowCount( ByVal projectId As Int32)  as Int32
    End Interface 
End NameSpace
  