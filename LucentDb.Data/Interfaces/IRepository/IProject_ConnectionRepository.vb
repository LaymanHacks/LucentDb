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
    Public Interface IProject_ConnectionRepository
        Function GetData() as ICollection(Of Project_Connection)

        Sub Update(projectId As Int32, connectionId As Int32, original_ProjectId As Int32,
                   original_ConnectionId As Int32)

        Sub Update(project_Connection as Project_Connection, original_ProjectId As Int32, original_ConnectionId As Int32)
        Sub Delete(projectId As Int32, connectionId As Int32)
        Sub Delete(project_Connection as Project_Connection)
        Function Insert(projectId As Int32, connectionId As Int32) as ICollection(Of Project_Connection)
        Function Insert(project_Connection as Project_Connection) as ICollection(Of Project_Connection)

        Function GetDataPageable(sortExpression As String, page As Int32, pageSize As Int32) _
            as PagedResult(Of Project_Connection)

        Function GetDataByProjectIdConnectionId(projectId As Int32, connectionId As Int32) _
            as ICollection(Of Project_Connection)

        Function GetDataByConnectionId(connectionId As Int32) as ICollection(Of Project_Connection)

        Function GetDataByConnectionIdPageable(connectionId As Int32, sortExpression As String, page As Int32,
                                               pageSize As Int32) as PagedResult(Of Project_Connection)

        Function GetDataByProjectId(projectId As Int32) as ICollection(Of Project_Connection)

        Function GetDataByProjectIdPageable(projectId As Int32, sortExpression As String, page As Int32,
                                            pageSize As Int32) as PagedResult(Of Project_Connection)
    End Interface
End NameSpace
