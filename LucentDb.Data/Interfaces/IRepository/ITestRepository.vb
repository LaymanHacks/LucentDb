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
Imports System.Threading.Tasks
Imports LucentDb.Data
Imports LucentDb.Domain.Entities


Namespace LucentDb.Data.Repository
    Public Interface ITestRepository
        Function GetData() As ICollection(Of Test)
        Sub Update(ByVal testTypeId As Int32, ByVal projectId As Nullable(Of Int32), ByVal groupId As Nullable(Of Int32), ByVal name As String, ByVal testValue As String, ByVal isActive As Boolean, ByVal id As Int32)
        Sub Update(ByVal test As Test)
        Sub Delete(ByVal id As Int32)
        Sub Delete(ByVal test As Test)
        Function Insert(ByVal testTypeId As Int32, ByVal projectId As Nullable(Of Int32), ByVal groupId As Nullable(Of Int32), ByVal name As String, ByVal testValue As String, ByVal isActive As Boolean) As Int32
        Function Insert(ByVal test As Test) As Int32
        Function GetDataPageable(ByVal sortExpression As String, ByVal page As Int32, ByVal pageSize As Int32) As ICollection(Of Test)
        Function GetRowCount() As Int32
        Function GetDataById(ByVal id As Int32) As ICollection(Of Test)
        Function GetActiveData() As ICollection(Of Test)
        Function GetActiveDataPageable(ByVal sortExpression As String, ByVal page As Int32, ByVal pageSize As Int32) As ICollection(Of Test)
        Function GetActiveDataRowCount() As Int32
        Function GetDataByProjectId(ByVal projectId As Int32) As ICollection(Of Test)
        Function GetDataByProjectIdPageable(ByVal projectId As Int32, ByVal sortExpression As String, ByVal page As Int32, ByVal pageSize As Int32) As ICollection(Of Test)
        Function GetDataByProjectIdRowCount(ByVal projectId As Int32) As Int32
        Function GetActiveDataByProjectId(ByVal projectId As Int32) As ICollection(Of Test)
        Function GetActiveDataByProjectIdPageable(ByVal projectId As Int32, ByVal sortExpression As String, ByVal page As Int32, ByVal pageSize As Int32) As ICollection(Of Test)
        Function GetActiveDataByProjectIdRowCount(ByVal projectId As Int32) As Int32
        Function GetDataByGroupId(ByVal groupId As Int32) As ICollection(Of Test)
        Function GetDataByGroupIdPageable(ByVal groupId As Int32, ByVal sortExpression As String, ByVal page As Int32, ByVal pageSize As Int32) As ICollection(Of Test)
        Function GetDataByGroupIdRowCount(ByVal groupId As Int32) As Int32
        Function GetActiveDataByGroupId(ByVal groupId As Int32) As ICollection(Of Test)
        Function GetActiveDataByGroupIdPageable(ByVal groupId As Int32, ByVal sortExpression As String, ByVal page As Int32, ByVal pageSize As Int32) As ICollection(Of Test)
        Function GetActiveDataByGroupIdRowCount(ByVal groupId As Int32) As Int32
        Function GetDataByTestTypeId(ByVal testTypeId As Int32) As ICollection(Of Test)
        Function GetDataByTestTypeIdPageable(ByVal testTypeId As Int32, ByVal sortExpression As String, ByVal page As Int32, ByVal pageSize As Int32) As ICollection(Of Test)
        Function GetDataByTestTypeIdRowCount(ByVal testTypeId As Int32) As Int32
        Function GetActiveDataByTestTypeId(ByVal testTypeId As Int32) As ICollection(Of Test)
        Function GetActiveDataByTestTypeIdPageable(ByVal testTypeId As Int32, ByVal sortExpression As String, ByVal page As Int32, ByVal pageSize As Int32) As ICollection(Of Test)
        Function GetActiveDataByTestTypeIdRowCount(ByVal testTypeId As Int32) As Int32
    End Interface
End Namespace
  