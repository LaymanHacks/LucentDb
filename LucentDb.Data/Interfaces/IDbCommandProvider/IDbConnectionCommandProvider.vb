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
        Function GetUpdateDbCommand( ByVal projectId As  Nullable(Of Int32) ,  ByVal connectionProviderId As Int32,  ByVal name As String,  ByVal connectionString As String,  ByVal isDefault As Boolean,  ByVal isActive As Boolean,  ByVal connectionId As Int32) As IDbCommand
        Function GetDeleteDbCommand( ByVal connectionId As Int32) As IDbCommand
        Function GetInsertDbCommand( ByVal projectId As  Nullable(Of Int32) ,  ByVal connectionProviderId As Int32,  ByVal name As String,  ByVal connectionString As String,  ByVal isDefault As Boolean,  ByVal isActive As Boolean) As IDbCommand
        Function GetGetDataPageableDbCommand( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand
        Function GetGetRowCountDbCommand() As IDbCommand
        Function GetGetDataByConnectionIdDbCommand( ByVal connectionId As Int32) As IDbCommand
        Function GetGetActiveDataDbCommand() As IDbCommand
        Function GetGetActiveDataPageableDbCommand( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand
        Function GetGetActiveDataRowCountDbCommand() As IDbCommand
        Function GetGetDataByConnectionProviderIdDbCommand( ByVal connectionProviderId As Int32) As IDbCommand
        Function GetGetDataByConnectionProviderIdPageableDbCommand( ByVal connectionProviderId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand
        Function GetGetDataByConnectionProviderIdRowCountDbCommand( ByVal connectionProviderId As Int32) As IDbCommand
        Function GetGetActiveDataByConnectionProviderIdDbCommand( ByVal connectionProviderId As Int32) As IDbCommand
        Function GetGetActiveDataByConnectionProviderIdPageableDbCommand( ByVal connectionProviderId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand
        Function GetGetActiveDataByConnectionProviderIdRowCountDbCommand( ByVal connectionProviderId As Int32) As IDbCommand
        Function GetGetDataByProjectIdDbCommand( ByVal projectId As Int32) As IDbCommand
        Function GetGetDataByProjectIdPageableDbCommand( ByVal projectId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand
        Function GetGetDataByProjectIdRowCountDbCommand( ByVal projectId As Int32) As IDbCommand
        Function GetGetActiveDataByProjectIdDbCommand( ByVal projectId As Int32) As IDbCommand
        Function GetGetActiveDataByProjectIdPageableDbCommand( ByVal projectId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand
        Function GetGetActiveDataByProjectIdRowCountDbCommand( ByVal projectId As Int32) As IDbCommand

    End Interface
End Namespace
