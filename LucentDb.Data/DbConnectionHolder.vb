Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.Common

Namespace LucentDb.Data
    Public NotInheritable Class DbConnectionHolder
        Private _dbConnection As DbConnection
        Private _opened As Boolean

        Public Property Connection As DbConnection
            Get
                Return _dbConnection
            End Get
            Set
                _dbConnection = value
            End Set
        End Property

        Public Sub New(dbConnection As DbConnection)
            If Not dbConnection Is Nothing Then
                _dbConnection = dbConnection
            End If
        End Sub

        Public Sub New(connectionName As String)
            If Not connectionName Is Nothing Then
                Try

                    Dim connSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings(connectionName)
                    Dim factory As DbProviderFactory = DbProviderFactories.GetFactory(connSettings.ProviderName)

                    _dbConnection = factory.CreateConnection()
                    Connection.ConnectionString = connSettings.ConnectionString
                Catch ex As Exception
                    If Not Connection Is Nothing Then
                        _dbConnection = Nothing
                    End If
                End Try
            End If
        End Sub

        Public Sub Open()
            If Connection.State = ConnectionState.Open Then
                _opened = True
                Return
            Else
                If Not Connection Is Nothing Then
                    Connection.Open()
                Else
                    Throw _
                        New Exception(
                            "Connection is nothing, check that connection information is set in the calling project.")
                End If

            End If
            _opened = True
        End Sub


        Public Sub Close()
            If Not Connection.State = ConnectionState.Closed Then
                Return
            End If
            Connection.Close()
            _opened = False
        End Sub
    End Class
End NameSpace