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
    Public Interface IDbTestValueTypeCommandProvider
        ReadOnly Property TestValueTypeDbConnectionHolder() As DbConnectionHolder
        ReadOnly Property DbConnectionName As String
        Function GetGetDataDbCommand() As IDbCommand
        Function GetUpdateDbCommand( ByVal testTypeId As Int32,  ByVal name As String,  ByVal isActive As Boolean,  ByVal id As Int32) As IDbCommand
        Function GetDeleteDbCommand( ByVal id As Int32) As IDbCommand
        Function GetInsertDbCommand( ByVal testTypeId As Int32,  ByVal name As String,  ByVal isActive As Boolean) As IDbCommand
        Function GetGetDataPageableDbCommand( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand
        Function GetGetRowCountDbCommand() As IDbCommand
        Function GetGetDataByIdDbCommand( ByVal id As Int32) As IDbCommand
        Function GetGetActiveDataDbCommand() As IDbCommand
        Function GetGetActiveDataPageableDbCommand( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand
        Function GetGetActiveDataRowCountDbCommand() As IDbCommand
        Function GetGetDataByTestTypeIdDbCommand( ByVal testTypeId As Int32) As IDbCommand
        Function GetGetDataByTestTypeIdPageableDbCommand( ByVal testTypeId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand
        Function GetGetDataByTestTypeIdRowCountDbCommand( ByVal testTypeId As Int32) As IDbCommand
        Function GetGetActiveDataByTestTypeIdDbCommand( ByVal testTypeId As Int32) As IDbCommand
        Function GetGetActiveDataByTestTypeIdPageableDbCommand( ByVal testTypeId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand
        Function GetGetActiveDataByTestTypeIdRowCountDbCommand( ByVal testTypeId As Int32) As IDbCommand

    End Interface
End Namespace