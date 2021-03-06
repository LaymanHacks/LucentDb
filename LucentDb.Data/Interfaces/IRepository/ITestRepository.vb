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
    Public Interface ITestRepository
        Function GetData() as ICollection(Of Test)

        Sub Update(testTypeId As Int32, testValueTypeId As Int32, projectId As Int32, groupId As Nullable(Of Int32),
                   name As String, testValue As String, isActive As Boolean, id As Int32)

        Sub Update(test as Test)
        Sub Delete(id As Int32)
        Sub Delete(test as Test)

        Function Insert(testTypeId As Int32, testValueTypeId As Int32, projectId As Int32, groupId As Nullable(Of Int32),
                        name As String, testValue As String, isActive As Boolean) as Int32

        Function Insert(test as Test) as Int32
        Function GetDataPageable(sortExpression As String, page As Int32, pageSize As Int32) as PagedResult(Of Test)
        Function GetDataById(id As Int32) as ICollection(Of Test)
        Function GetActiveData() as ICollection(Of Test)

        Function GetActiveDataPageable(sortExpression As String, page As Int32, pageSize As Int32) _
            as PagedResult(Of Test)

        Function GetDataByProjectId(projectId As Int32) as ICollection(Of Test)

        Function GetDataByProjectIdPageable(projectId As Int32, sortExpression As String, page As Int32,
                                            pageSize As Int32) as PagedResult(Of Test)

        Function GetActiveDataByProjectId(projectId As Int32) as ICollection(Of Test)

        Function GetActiveDataByProjectIdPageable(projectId As Int32, sortExpression As String, page As Int32,
                                                  pageSize As Int32) as PagedResult(Of Test)

        Function GetDataByGroupId(groupId As Int32) as ICollection(Of Test)

        Function GetDataByGroupIdPageable(groupId As Int32, sortExpression As String, page As Int32, pageSize As Int32) _
            as PagedResult(Of Test)

        Function GetActiveDataByGroupId(groupId As Int32) as ICollection(Of Test)

        Function GetActiveDataByGroupIdPageable(groupId As Int32, sortExpression As String, page As Int32,
                                                pageSize As Int32) as PagedResult(Of Test)

        Function GetDataByTestTypeId(testTypeId As Int32) as ICollection(Of Test)

        Function GetDataByTestTypeIdPageable(testTypeId As Int32, sortExpression As String, page As Int32,
                                             pageSize As Int32) as PagedResult(Of Test)

        Function GetActiveDataByTestTypeId(testTypeId As Int32) as ICollection(Of Test)

        Function GetActiveDataByTestTypeIdPageable(testTypeId As Int32, sortExpression As String, page As Int32,
                                                   pageSize As Int32) as PagedResult(Of Test)

        Function GetDataByTestValueTypeId(testValueTypeId As Int32) as ICollection(Of Test)

        Function GetDataByTestValueTypeIdPageable(testValueTypeId As Int32, sortExpression As String, page As Int32,
                                                  pageSize As Int32) as PagedResult(Of Test)

        Function GetActiveDataByTestValueTypeId(testValueTypeId As Int32) as ICollection(Of Test)

        Function GetActiveDataByTestValueTypeIdPageable(testValueTypeId As Int32, sortExpression As String,
                                                        page As Int32, pageSize As Int32) as PagedResult(Of Test)
    End Interface
End NameSpace
