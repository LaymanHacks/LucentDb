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
    Public Interface ITestRepository
        Function GetData()  as ICollection(Of Test)
        Sub Update( ByVal testTypeId As Int32,  ByVal projectId As  Nullable(Of Int32) ,  ByVal groupId As  Nullable(Of Int32) ,  ByVal name As String,  ByVal testValue As String,  ByVal isActive As Boolean,  ByVal id As Int32) 
        Sub Update(ByVal test as Test) 
        Sub Delete( ByVal id As Int32) 
        Sub Delete(ByVal test as Test) 
        Function Insert( ByVal testTypeId As Int32,  ByVal projectId As  Nullable(Of Int32) ,  ByVal groupId As  Nullable(Of Int32) ,  ByVal name As String,  ByVal testValue As String,  ByVal isActive As Boolean)  as Int32
        Function Insert(ByVal test as Test)  as Int32
        Function GetDataPageable( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as PagedResult(Of Test)
        Function GetDataById( ByVal id As Int32)  as ICollection(Of Test)
        Function GetActiveData()  as ICollection(Of Test)
        Function GetActiveDataPageable( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as PagedResult(Of Test)
        Function GetDataByProjectId( ByVal projectId As Int32)  as ICollection(Of Test)
        Function GetDataByProjectIdPageable( ByVal projectId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as PagedResult(Of Test)
        Function GetActiveDataByProjectId( ByVal projectId As Int32)  as ICollection(Of Test)
        Function GetActiveDataByProjectIdPageable( ByVal projectId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as PagedResult(Of Test)
        Function GetDataByGroupId( ByVal groupId As Int32)  as ICollection(Of Test)
        Function GetDataByGroupIdPageable( ByVal groupId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as PagedResult(Of Test)
        Function GetActiveDataByGroupId( ByVal groupId As Int32)  as ICollection(Of Test)
        Function GetActiveDataByGroupIdPageable( ByVal groupId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as PagedResult(Of Test)
        Function GetDataByTestTypeId( ByVal testTypeId As Int32)  as ICollection(Of Test)
        Function GetDataByTestTypeIdPageable( ByVal testTypeId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as PagedResult(Of Test)
        Function GetActiveDataByTestTypeId( ByVal testTypeId As Int32)  as ICollection(Of Test)
        Function GetActiveDataByTestTypeIdPageable( ByVal testTypeId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as PagedResult(Of Test)
    End Interface 
End NameSpace
  