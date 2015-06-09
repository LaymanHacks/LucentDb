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
        ReadOnly Property ConnectionDbConnectionHolder() As DbConnectionHolder
        ReadOnly Property DbConnectionName As String
        Function GetGetDataDbCommand() As IDbCommand
        Function GetUpdateDbCommand( ByVal name As String,  ByVal connectionString As String,  ByVal isActive As Boolean,  ByVal connectionId As Int32) As IDbCommand
        Function GetDeleteDbCommand( ByVal connectionId As Int32) As IDbCommand
        Function GetInsertDbCommand( ByVal name As String,  ByVal connectionString As String,  ByVal isActive As Boolean) As IDbCommand
        Function GetGetDataPageableDbCommand( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand
        Function GetGetRowCountDbCommand() As IDbCommand
        Function GetGetDataByConnectionIdDbCommand( ByVal connectionId As Int32) As IDbCommand
        Function GetGetActiveDataDbCommand() As IDbCommand
        Function GetGetActiveDataPageableDbCommand( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand
        Function GetGetActiveDataRowCountDbCommand() As IDbCommand
        Function GetGetConnectionsForProjectByProjectIdDbCommand( ByVal projectId As Int32) As IDbCommand
        Function GetGetConnectionsForProjectByProjectIdPageableDbCommand( ByVal projectId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand
        Function GetGetConnectionsForProjectByProjectIdRowCountDbCommand( ByVal projectId As Int32) As IDbCommand

    End Interface
End Namespace
