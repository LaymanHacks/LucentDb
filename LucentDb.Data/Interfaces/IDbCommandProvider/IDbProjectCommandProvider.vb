
Imports System
Imports System.Data

Namespace LucentDb.Data.DbCommandProvider
    Public Interface IDbProjectCommandProvider
        ReadOnly Property ProjectDbConnectionHolder As DbConnectionHolder
        ReadOnly Property DbConnectionName As String
        Function GetGetDataDbCommand() As IDbCommand
        Function GetUpdateDbCommand(name As String, isActive As Boolean, projectId As Int32) As IDbCommand
        Function GetDeleteDbCommand(projectId As Int32) As IDbCommand
        Function GetInsertDbCommand(name As String, isActive As Boolean) As IDbCommand
        Function GetGetDataPageableDbCommand(sortExpression As String, page As Int32, pageSize As Int32) As IDbCommand
        Function GetGetRowCountDbCommand() As IDbCommand
        Function GetGetDataByProjectIdDbCommand(projectId As Int32) As IDbCommand
        Function GetGetActiveDataDbCommand() As IDbCommand

        Function GetGetActiveDataPageableDbCommand(sortExpression As String, page As Int32, pageSize As Int32) _
            As IDbCommand

        Function GetGetActiveDataRowCountDbCommand() As IDbCommand
    End Interface
End Namespace
