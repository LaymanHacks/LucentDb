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
    Public Interface IDbRunHistoryDetailCommandProvider
        ReadOnly Property RunHistoryDetailDbConnectionHolder As DbConnectionHolder
        ReadOnly Property DbConnectionName As String
        Function GetGetDataDbCommand() As IDbCommand

        Function GetUpdateDbCommand(runHistoryId As Int64, testId As Int32, runDateTime As DateTime,
                                    duration As Nullable(Of Decimal), isValid As Boolean, resultString As String,
                                    id As Int64) As IDbCommand

        Function GetDeleteDbCommand(id As Int64) As IDbCommand

        Function GetInsertDbCommand(runHistoryId As Int64, testId As Int32, runDateTime As DateTime,
                                    duration As Nullable(Of Decimal), isValid As Boolean, resultString As String) _
            As IDbCommand

        Function GetGetDataPageableDbCommand(sortExpression As String, page As Int32, pageSize As Int32) As IDbCommand
        Function GetGetRowCountDbCommand() As IDbCommand
        Function GetGetDataByIdDbCommand(id As Int64) As IDbCommand
        Function GetGetDataByRunHistoryIdDbCommand(runHistoryId As Int64) As IDbCommand

        Function GetGetDataByRunHistoryIdPageableDbCommand(runHistoryId As Int64, sortExpression As String,
                                                           page As Int32, pageSize As Int32) As IDbCommand

        Function GetGetDataByRunHistoryIdRowCountDbCommand(runHistoryId As Int64) As IDbCommand
    End Interface
End Namespace
