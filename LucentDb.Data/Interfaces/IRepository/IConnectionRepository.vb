
Imports System
Imports System.Collections.Generic
Imports LucentDb.Domain.Entities


Namespace LucentDb.Data.Repository
    Public Interface IConnectionRepository
        Function GetData() as ICollection(Of Connection)

        Sub Update(projectId As Int32, connectionProviderId As Int32, name As String, connectionString As String,
                   isDefault As Boolean, isActive As Boolean, connectionId As Int32)

        Sub Update(connection as Connection)
        Sub Delete(connectionId As Int32)
        Sub Delete(connection as Connection)

        Function Insert(projectId As Nullable(Of Int32), connectionProviderId As Int32, name As String,
                        connectionString As String, isDefault As Boolean, isActive As Boolean) as Int32

        Function Insert(connection as Connection) as Int32

        Function GetDataPageable(sortExpression As String, page As Int32, pageSize As Int32) _
            as PagedResult(Of Connection)

        Function GetDataByConnectionId(connectionId As Int32) as ICollection(Of Connection)
        Function GetActiveData() as ICollection(Of Connection)

        Function GetActiveDataPageable(sortExpression As String, page As Int32, pageSize As Int32) _
            as PagedResult(Of Connection)

        Function GetDataByConnectionProviderId(connectionProviderId As Int32) as ICollection(Of Connection)

        Function GetDataByConnectionProviderIdPageable(connectionProviderId As Int32, sortExpression As String,
                                                       page As Int32, pageSize As Int32) as PagedResult(Of Connection)

        Function GetActiveDataByConnectionProviderId(connectionProviderId As Int32) as ICollection(Of Connection)

        Function GetActiveDataByConnectionProviderIdPageable(connectionProviderId As Int32, sortExpression As String,
                                                             page As Int32, pageSize As Int32) _
            as PagedResult(Of Connection)

        Function GetDataByProjectId(projectId As Int32) as ICollection(Of Connection)

        Function GetDataByProjectIdPageable(projectId As Int32, sortExpression As String, page As Int32,
                                            pageSize As Int32) as PagedResult(Of Connection)

        Function GetActiveDataByProjectId(projectId As Int32) as ICollection(Of Connection)

        Function GetActiveDataByProjectIdPageable(projectId As Int32, sortExpression As String, page As Int32,
                                                  pageSize As Int32) as PagedResult(Of Connection)
    End Interface
End NameSpace
