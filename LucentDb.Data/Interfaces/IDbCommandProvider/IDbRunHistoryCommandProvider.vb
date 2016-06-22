
Imports System
Imports System.Data

Namespace LucentDb.Data.DbCommandProvider
    Public Interface IDbRunHistoryCommandProvider
        ReadOnly Property RunHistoryDbConnectionHolder As DbConnectionHolder
        ReadOnly Property DbConnectionName As String
        Function GetGetDataDbCommand() As IDbCommand

        Function GetUpdateDbCommand(testId As Nullable(Of Int32), projectId As Nullable(Of Int32),
                                    groupId As Nullable(Of Int32), connectionId As Nullable(Of Int32),
                                    runDateTime As DateTime, totalDuration As Nullable(Of Decimal), isValid As Boolean,
                                    runLog As String, id As Int64) As IDbCommand

        Function GetDeleteDbCommand(id As Int64) As IDbCommand

        Function GetInsertDbCommand(testId As Nullable(Of Int32), projectId As Nullable(Of Int32),
                                    groupId As Nullable(Of Int32), connectionId As Nullable(Of Int32),
                                    runDateTime As DateTime, totalDuration As Nullable(Of Decimal), isValid As Boolean,
                                    runLog As String) As IDbCommand

        Function GetGetDataPageableDbCommand(sortExpression As String, page As Int32, pageSize As Int32) As IDbCommand
        Function GetGetRowCountDbCommand() As IDbCommand
        Function GetGetDataByIdDbCommand(id As Int64) As IDbCommand
        Function GetGetDataByProjectIdDbCommand(projectId As Int32) As IDbCommand

        Function GetGetDataByProjectIdPageableDbCommand(projectId As Int32, sortExpression As String, page As Int32,
                                                        pageSize As Int32) As IDbCommand

        Function GetGetDataByProjectIdRowCountDbCommand(projectId As Int32) As IDbCommand
        Function GetGetDataByTestIdDbCommand(testId As Int32) As IDbCommand

        Function GetGetDataByTestIdPageableDbCommand(testId As Int32, sortExpression As String, page As Int32,
                                                     pageSize As Int32) As IDbCommand

        Function GetGetDataByTestIdRowCountDbCommand(testId As Int32) As IDbCommand
        Function GetGetDataByGroupIdDbCommand(groupId As Int32) As IDbCommand

        Function GetGetDataByGroupIdPageableDbCommand(groupId As Int32, sortExpression As String, page As Int32,
                                                      pageSize As Int32) As IDbCommand

        Function GetGetDataByGroupIdRowCountDbCommand(groupId As Int32) As IDbCommand
    End Interface
End Namespace
