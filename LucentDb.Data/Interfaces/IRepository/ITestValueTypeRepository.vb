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
    Public Interface ITestValueTypeRepository
        Function GetData() as ICollection(Of TestValueType)
        Sub Update(testTypeId As Int32, name As String, isActive As Boolean, id As Int32)
        Sub Update(testValueType as TestValueType)
        Sub Delete(id As Int32)
        Sub Delete(testValueType as TestValueType)
        Function Insert(testTypeId As Int32, name As String, isActive As Boolean) as Int32
        Function Insert(testValueType as TestValueType) as Int32

        Function GetDataPageable(sortExpression As String, page As Int32, pageSize As Int32) _
            as PagedResult(Of TestValueType)

        Function GetDataById(id As Int32) as ICollection(Of TestValueType)
        Function GetActiveData() as ICollection(Of TestValueType)

        Function GetActiveDataPageable(sortExpression As String, page As Int32, pageSize As Int32) _
            as PagedResult(Of TestValueType)

        Function GetDataByTestTypeId(testTypeId As Int32) as ICollection(Of TestValueType)

        Function GetDataByTestTypeIdPageable(testTypeId As Int32, sortExpression As String, page As Int32,
                                             pageSize As Int32) as PagedResult(Of TestValueType)

        Function GetActiveDataByTestTypeId(testTypeId As Int32) as ICollection(Of TestValueType)

        Function GetActiveDataByTestTypeIdPageable(testTypeId As Int32, sortExpression As String, page As Int32,
                                                   pageSize As Int32) as PagedResult(Of TestValueType)
    End Interface
End NameSpace
