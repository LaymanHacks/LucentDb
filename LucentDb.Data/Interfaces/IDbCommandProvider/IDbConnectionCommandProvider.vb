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
Imports System.Data

Namespace LucentDb.Data.DbCommandProvider
    Public Interface IDbConnectionCommandProvider
        ReadOnly Property ConnectionDbConnectionHolder As DbConnectionHolder
        ReadOnly Property DbConnectionName As String
        Function GetGetDataDbCommand() As IDbCommand

        Function GetUpdateDbCommand(connectionProviderId As Nullable(Of Int32), name As String,
                                    connectionString As String, isActive As Boolean, connectionId As Int32) _
            As IDbCommand

        Function GetDeleteDbCommand(connectionId As Int32) As IDbCommand

        Function GetInsertDbCommand(connectionProviderId As Nullable(Of Int32), name As String,
                                    connectionString As String, isActive As Boolean) As IDbCommand

        Function GetGetDataPageableDbCommand(sortExpression As String, page As Int32, pageSize As Int32) As IDbCommand
        Function GetGetRowCountDbCommand() As IDbCommand
        Function GetGetDataByConnectionIdDbCommand(connectionId As Int32) As IDbCommand
        Function GetGetActiveDataDbCommand() As IDbCommand

        Function GetGetActiveDataPageableDbCommand(sortExpression As String, page As Int32, pageSize As Int32) _
            As IDbCommand

        Function GetGetActiveDataRowCountDbCommand() As IDbCommand
        Function GetGetConnectionsForProjectByProjectIdDbCommand(projectId As Int32) As IDbCommand

        Function GetGetConnectionsForProjectByProjectIdPageableDbCommand(projectId As Int32, sortExpression As String,
                                                                         page As Int32, pageSize As Int32) As IDbCommand

        Function GetGetConnectionsForProjectByProjectIdRowCountDbCommand(projectId As Int32) As IDbCommand
        Function GetGetDataByConnectionProviderIdDbCommand(connectionProviderId As Int32) As IDbCommand

        Function GetGetDataByConnectionProviderIdPageableDbCommand(connectionProviderId As Int32,
                                                                   sortExpression As String, page As Int32,
                                                                   pageSize As Int32) As IDbCommand

        Function GetGetDataByConnectionProviderIdRowCountDbCommand(connectionProviderId As Int32) As IDbCommand
        Function GetGetActiveDataByConnectionProviderIdDbCommand(connectionProviderId As Int32) As IDbCommand

        Function GetGetActiveDataByConnectionProviderIdPageableDbCommand(connectionProviderId As Int32,
                                                                         sortExpression As String, page As Int32,
                                                                         pageSize As Int32) As IDbCommand

        Function GetGetActiveDataByConnectionProviderIdRowCountDbCommand(connectionProviderId As Int32) As IDbCommand
    End Interface
End Namespace
