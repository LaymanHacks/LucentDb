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
    Public Interface IDbProjectDetailsViewCommandProvider
        ReadOnly Property ProjectDetailsViewDbConnectionHolder() As DbConnectionHolder
        ReadOnly Property DbConnectionName As String
        Function GetGetDataDbCommand() As IDbCommand
        Function GetGetDataPageableDbCommand( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand
        Function GetGetRowCountDbCommand() As IDbCommand
        Function GetGetActiveDataDbCommand() As IDbCommand
        Function GetGetActiveDataPageableDbCommand( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand
        Function GetGetActiveDataRowCountDbCommand() As IDbCommand

    End Interface
End Namespace
