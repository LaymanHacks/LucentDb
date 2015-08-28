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
    Public Interface IConnectionRepository
        Function GetData() as ICollection(Of Connection)

        Sub Update(connectionProviderId As Int32, name As String, connectionString As String, isActive As Boolean,
                   connectionId As Int32)

        Sub Update(connection as Connection)
        Sub Delete(connectionId As Int32)
        Sub Delete(connection as Connection)

        Function Insert(connectionProviderId As Int32, name As String, connectionString As String, isActive As Boolean) _
            As Int32

        Function Insert(connection as Connection) as Int32

        Function GetDataPageable(sortExpression As String, page As Int32, pageSize As Int32) _
            as PagedResult(Of Connection)

        Function GetDataByConnectionId(connectionId As Int32) as ICollection(Of Connection)
        Function GetActiveData() as ICollection(Of Connection)

        Function GetActiveDataPageable(sortExpression As String, page As Int32, pageSize As Int32) _
            as PagedResult(Of Connection)

        Function GetConnectionsForProjectByProjectId(projectId As Int32) as ICollection(Of Connection)

        Function GetConnectionsForProjectByProjectIdPageable(projectId As Int32, sortExpression As String, page As Int32,
                                                             pageSize As Int32) as PagedResult(Of Connection)

        Function GetDataByConnectionProviderId(connectionProviderId As Int32) as ICollection(Of Connection)

        Function GetDataByConnectionProviderIdPageable(connectionProviderId As Int32, sortExpression As String,
                                                       page As Int32, pageSize As Int32) as PagedResult(Of Connection)

        Function GetActiveDataByConnectionProviderId(connectionProviderId As Int32) as ICollection(Of Connection)

        Function GetActiveDataByConnectionProviderIdPageable(connectionProviderId As Int32, sortExpression As String,
                                                             page As Int32, pageSize As Int32) _
            as PagedResult(Of Connection)
    End Interface
End NameSpace
