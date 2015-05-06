Imports System
Imports System.Data
Imports System.Data.SqlClient

Public Class SqlParameterFactory
    Public Shared Function CreateInputParameter(paramName As String, dbType As SqlDbType, objValue As Object) _
        As SqlParameter
        Dim param As New SqlParameter(paramName, dbType)

        If objValue Is Nothing Then
            param.IsNullable = True
            param.Value = DBNull.Value
        Else
            param.Value = objValue
        End If

        Return param
    End Function
End Class
