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
    Public Interface ITestTypeRepository
        Function GetData() as ICollection(Of TestType)
        Sub Update(name As String, testValidatorType As String, isActive As Boolean, id As Int32)
        Sub Update(testType as TestType)
        Sub Delete(id As Int32)
        Sub Delete(testType as TestType)
        Function Insert(name As String, testValidatorType As String, isActive As Boolean) as Int32
        Function Insert(testType as TestType) as Int32
        Function GetDataPageable(sortExpression As String, page As Int32, pageSize As Int32) as PagedResult(Of TestType)
        Function GetDataById(id As Int32) as ICollection(Of TestType)
        Function GetActiveData() as ICollection(Of TestType)

        Function GetActiveDataPageable(sortExpression As String, page As Int32, pageSize As Int32) _
            as PagedResult(Of TestType)
    End Interface
End NameSpace
