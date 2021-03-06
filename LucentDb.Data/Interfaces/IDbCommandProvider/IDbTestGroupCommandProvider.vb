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
    Public Interface IDbTestGroupCommandProvider
        ReadOnly Property TestGroupDbConnectionHolder As DbConnectionHolder
        ReadOnly Property DbConnectionName As String
        Function GetGetDataDbCommand() As IDbCommand
        Function GetUpdateDbCommand(projectId As Int32, name As String, isActive As Boolean, id As Int32) As IDbCommand
        Function GetDeleteDbCommand(id As Int32) As IDbCommand
        Function GetInsertDbCommand(projectId As Int32, name As String, isActive As Boolean) As IDbCommand
        Function GetGetDataPageableDbCommand(sortExpression As String, page As Int32, pageSize As Int32) As IDbCommand
        Function GetGetRowCountDbCommand() As IDbCommand
        Function GetGetDataByIdDbCommand(id As Int32) As IDbCommand
        Function GetGetActiveDataDbCommand() As IDbCommand

        Function GetGetActiveDataPageableDbCommand(sortExpression As String, page As Int32, pageSize As Int32) _
            As IDbCommand

        Function GetGetActiveDataRowCountDbCommand() As IDbCommand
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
