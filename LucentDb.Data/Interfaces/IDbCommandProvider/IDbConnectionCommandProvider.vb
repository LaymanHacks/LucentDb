
Imports System
Imports System.Data

Namespace LucentDb.Data.DbCommandProvider
    Public Interface IDbConnectionCommandProvider
        ReadOnly Property ConnectionDbConnectionHolder As DbConnectionHolder
        ReadOnly Property DbConnectionName As String
        Function GetGetDataDbCommand() As IDbCommand

        Function GetUpdateDbCommand(projectId As Nullable(Of Int32), connectionProviderId As Int32, name As String,
                                    connectionString As String, isDefault As Boolean, isActive As Boolean,
                                    connectionId As Int32) As IDbCommand

        Function GetDeleteDbCommand(connectionId As Int32) As IDbCommand

        Function GetInsertDbCommand(projectId As Nullable(Of Int32), connectionProviderId As Int32, name As String,
                                    connectionString As String, isDefault As Boolean, isActive As Boolean) As IDbCommand

        Function GetGetDataPageableDbCommand(sortExpression As String, page As Int32, pageSize As Int32) As IDbCommand
        Function GetGetRowCountDbCommand() As IDbCommand
        Function GetGetDataByConnectionIdDbCommand(connectionId As Int32) As IDbCommand
        Function GetGetActiveDataDbCommand() As IDbCommand

        Function GetGetActiveDataPageableDbCommand(sortExpression As String, page As Int32, pageSize As Int32) _
            As IDbCommand

        Function GetGetActiveDataRowCountDbCommand() As IDbCommand
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
        Function GetGetDataByProjectIdDbCommand(projectId As Int32) As IDbCommand

        Function GetGetDataByProjectIdPageableDbCommand(projectId As Int32, sortExpression As String, page As Int32,
                                                        pageSize As Int32) As IDbCommand

        Function GetGetDataByProjectIdRowCountDbCommand(projectId As Int32) As IDbCommand
        Function GetGetActiveDataByProjectIdDbCommand(projectId As Int32) As IDbCommand

        Function GetGetActiveDataByProjectIdPageableDbCommand(projectId As Int32, sortExpression As String,
                                                              page As Int32, pageSize As Int32) As IDbCommand

        Function GetGetActiveDataByProjectIdRowCountDbCommand(projectId As Int32) As IDbCommand
    End Interface
End Namespace
