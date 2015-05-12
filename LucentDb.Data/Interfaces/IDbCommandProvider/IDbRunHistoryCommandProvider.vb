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
    Public Interface IDbRunHistoryCommandProvider
        ReadOnly Property RunHistoryDbConnectionHolder() As DbConnectionHolder
        ReadOnly Property DbConnectionName As String
        Function GetGetDataDbCommand() As IDbCommand
        Function GetUpdateDbCommand( ByVal scriptId As Int32,  ByVal runDateTime As DateTime,  ByVal isPass As Boolean,  ByVal resultString As String,  ByVal id As Int64) As IDbCommand
        Function GetDeleteDbCommand( ByVal id As Int64) As IDbCommand
        Function GetInsertDbCommand( ByVal scriptId As Int32,  ByVal runDateTime As DateTime,  ByVal isPass As Boolean,  ByVal resultString As String) As IDbCommand
        Function GetGetDataPageableDbCommand( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand
        Function GetGetRowCountDbCommand() As IDbCommand
        Function GetGetDataByIdDbCommand( ByVal id As Int64) As IDbCommand
        Function GetGetDataByScriptIdDbCommand( ByVal scriptId As Int32) As IDbCommand
        Function GetGetDataByScriptIdPageableDbCommand( ByVal scriptId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand
        Function GetGetDataByScriptIdRowCountDbCommand( ByVal scriptId As Int32) As IDbCommand

    End Interface
End Namespace
