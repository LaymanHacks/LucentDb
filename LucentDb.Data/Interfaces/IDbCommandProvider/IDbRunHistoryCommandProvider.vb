
Imports System
Imports System.Data

Namespace LucentDb.Data.DbCommandProvider
    Public Interface IDbRunHistoryCommandProvider
        ReadOnly Property RunHistoryDbConnectionHolder() As DbConnectionHolder
        ReadOnly Property DbConnectionName As String
        Function GetGetDataDbCommand() As IDbCommand
        Function GetUpdateDbCommand(ByVal testId As Nullable(Of Int32), ByVal projectId As Nullable(Of Int32), ByVal groupId As Nullable(Of Int32), ByVal connectionId As Nullable(Of Int32), ByVal runDateTime As DateTime, ByVal totalDuration As Nullable(Of Decimal), ByVal isValid As Boolean, ByVal runLog As String, ByVal id As Int64) As IDbCommand
        Function GetDeleteDbCommand(ByVal id As Int64) As IDbCommand
        Function GetInsertDbCommand(ByVal testId As Nullable(Of Int32), ByVal projectId As Nullable(Of Int32), ByVal groupId As Nullable(Of Int32), ByVal connectionId As Nullable(Of Int32), ByVal runDateTime As DateTime, ByVal totalDuration As Nullable(Of Decimal), ByVal isValid As Boolean, ByVal runLog As String) As IDbCommand
        Function GetGetDataPageableDbCommand(ByVal sortExpression As String, ByVal page As Int32, ByVal pageSize As Int32) As IDbCommand
        Function GetGetRowCountDbCommand() As IDbCommand
        Function GetGetDataByIdDbCommand(ByVal id As Int64) As IDbCommand
        Function GetGetDataByProjectIdDbCommand(ByVal projectId As Int32) As IDbCommand
        Function GetGetDataByProjectIdPageableDbCommand(ByVal projectId As Int32, ByVal sortExpression As String, ByVal page As Int32, ByVal pageSize As Int32) As IDbCommand
        Function GetGetDataByProjectIdRowCountDbCommand(ByVal projectId As Int32) As IDbCommand
        Function GetGetDataByTestIdDbCommand(ByVal testId As Int32) As IDbCommand
        Function GetGetDataByTestIdPageableDbCommand(ByVal testId As Int32, ByVal sortExpression As String, ByVal page As Int32, ByVal pageSize As Int32) As IDbCommand
        Function GetGetDataByTestIdRowCountDbCommand(ByVal testId As Int32) As IDbCommand
        Function GetGetDataByGroupIdDbCommand(ByVal groupId As Int32) As IDbCommand
        Function GetGetDataByGroupIdPageableDbCommand(ByVal groupId As Int32, ByVal sortExpression As String, ByVal page As Int32, ByVal pageSize As Int32) As IDbCommand
        Function GetGetDataByGroupIdRowCountDbCommand(ByVal groupId As Int32) As IDbCommand

    End Interface
End Namespace
