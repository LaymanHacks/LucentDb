Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Data
Imports LucentDb.Data.DbCommandProvider
Imports LucentDb.Domain.Entities


Namespace LucentDb.Data.Repository
    <DataObject(true)>
    Public Class DbConnectionRepository
        Implements IConnectionRepository
        Implements IDisposable

        Private ReadOnly _dbConnectionCommandProvider As IDbConnectionCommandProvider
        Private _dbConnHolder As DbConnectionHolder = Nothing

        Public Sub New(dbConnectionCommandProvider As IDbConnectionCommandProvider)
            _dbConnectionCommandProvider = dbConnectionCommandProvider
            _dbConnHolder = _dbConnectionCommandProvider.ConnectionDbConnectionHolder
        End Sub

        Public Function GetData() as ICollection(Of Connection) Implements IConnectionRepository.GetData
            Dim command As IDbCommand = _dbConnectionCommandProvider.GetGetDataDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList as new Collection(Of Connection)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Connection(reader.GetInt32("ConnectionId"), reader.GetInt32("ProjectId"),
                                       reader.GetInt32("ConnectionProviderId"), reader.GetString("Name"),
                                       reader.GetString("ConnectionString"), reader.GetBoolean("IsDefault"),
                                       reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
        End Function

        Public Sub Update(projectId As Int32, connectionProviderId As Int32, name As String, connectionString As String,
                          isDefault As Boolean, isActive As Boolean, connectionId As Int32) _
            Implements IConnectionRepository.Update
            Dim command As IDbCommand = _dbConnectionCommandProvider.GetUpdateDbCommand(projectId, connectionProviderId,
                                                                                        name, connectionString,
                                                                                        isDefault, isActive,
                                                                                        connectionId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            command.ExecuteNonQuery()
            _dbConnHolder.Close()
        End Sub

        Public Sub Update(connection as Connection) Implements IConnectionRepository.Update
            With Connection
                Update(.ProjectId(), CInt(.ConnectionProviderId), .Name, .ConnectionString, CBool(.IsDefault),
                       CBool(.IsActive), CInt(.ConnectionId))
            End With
        End Sub

        Public Sub Delete(connectionId As Int32) Implements IConnectionRepository.Delete
            Dim command As IDbCommand = _dbConnectionCommandProvider.GetDeleteDbCommand(ConnectionId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Command.ExecuteNonQuery
            _dbConnHolder.Close()
        End Sub

        Public Sub Delete(connection as Connection) Implements IConnectionRepository.Delete
            With Connection
                Delete(CInt(.ConnectionId))
            End With
        End Sub

        Public Function Insert(projectId As Nullable(Of Int32), connectionProviderId As Int32, name As String,
                               connectionString As String, isDefault As Boolean, isActive As Boolean) as Int32 _
            Implements IConnectionRepository.Insert
            Dim command As IDbCommand = _dbConnectionCommandProvider.GetInsertDbCommand(ProjectId, ConnectionProviderId,
                                                                                        Name, ConnectionString,
                                                                                        IsDefault, IsActive)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue
        End Function

        Public Function Insert(connection as Connection) as Int32 Implements IConnectionRepository.Insert
            With Connection
                Return _
                    Insert(.ProjectId(), CInt(.ConnectionProviderId), .Name, .ConnectionString, CBool(.IsDefault),
                           CBool(.IsActive))
            End With
        End Function

        Public Function GetDataPageable(sortExpression As String, page As Int32, pageSize As Int32) _
            as PagedResult(Of Connection) Implements IConnectionRepository.GetDataPageable
            Dim command As IDbCommand = _dbConnectionCommandProvider.GetGetDataPageableDbCommand(sortExpression, page,
                                                                                                 pageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList as new Collection(Of Connection)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Connection(reader.GetInt32("ConnectionId"), reader.GetInt32("ProjectId"),
                                       reader.GetInt32("ConnectionProviderId"), reader.GetString("Name"),
                                       reader.GetString("ConnectionString"), reader.GetBoolean("IsDefault"),
                                       reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Dim totalCount As Int64 = GetRowCount()
            Dim pagedResults As PagedResult(Of Connection) = New PagedResult(Of Connection)(page, pageSize, totalCount,
                                                                                            entList)
            Return pagedResults
        End Function

        Public Function GetRowCount() As Int32
            Dim command As IDbCommand = _dbConnectionCommandProvider.GetGetRowCountDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue
        End Function

        Public Function GetDataByConnectionId(connectionId As Int32) As ICollection(Of Connection) _
            Implements IConnectionRepository.GetDataByConnectionId
            Dim command As IDbCommand = _dbConnectionCommandProvider.GetGetDataByConnectionIdDbCommand(ConnectionId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Connection)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Connection(reader.GetInt32("ConnectionId"), reader.GetInt32("ProjectId"),
                                       reader.GetInt32("ConnectionProviderId"), reader.GetString("Name"),
                                       reader.GetString("ConnectionString"), reader.GetBoolean("IsDefault"),
                                       reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList
        End Function

        Public Function GetActiveData() As ICollection(Of Connection) Implements IConnectionRepository.GetActiveData
            Dim command As IDbCommand = _dbConnectionCommandProvider.GetGetActiveDataDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Connection)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Connection(reader.GetInt32("ConnectionId"), reader.GetInt32("ProjectId"),
                                       reader.GetInt32("ConnectionProviderId"), reader.GetString("Name"),
                                       reader.GetString("ConnectionString"), reader.GetBoolean("IsDefault"),
                                       reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList
        End Function

        Public Function GetActiveDataPageable(sortExpression As String, page As Int32, pageSize As Int32) _
            As PagedResult(Of Connection) Implements IConnectionRepository.GetActiveDataPageable
            Dim command As IDbCommand = _dbConnectionCommandProvider.GetGetActiveDataPageableDbCommand(sortExpression,
                                                                                                       page, PageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Connection)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Connection(reader.GetInt32("ConnectionId"), reader.GetInt32("ProjectId"),
                                       reader.GetInt32("ConnectionProviderId"), reader.GetString("Name"),
                                       reader.GetString("ConnectionString"), reader.GetBoolean("IsDefault"),
                                       reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Dim totalCount As Int64 = GetActiveDataRowCount()
            Dim pagedResults As PagedResult(Of Connection) = New PagedResult(Of Connection)(page, pageSize, totalCount,
                                                                                            entList)
            Return pagedResults
        End Function

        Public Function GetActiveDataRowCount() As Int32
            Dim command As IDbCommand = _dbConnectionCommandProvider.GetGetActiveDataRowCountDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue
        End Function

        Public Function GetDataByConnectionProviderId(connectionProviderId As Int32) As ICollection(Of Connection) _
            Implements IConnectionRepository.GetDataByConnectionProviderId
            Dim command As IDbCommand =
                    _dbConnectionCommandProvider.GetGetDataByConnectionProviderIdDbCommand(ConnectionProviderId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Connection)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Connection(reader.GetInt32("ConnectionId"), reader.GetInt32("ProjectId"),
                                       reader.GetInt32("ConnectionProviderId"), reader.GetString("Name"),
                                       reader.GetString("ConnectionString"), reader.GetBoolean("IsDefault"),
                                       reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList
        End Function

        Public Function GetDataByConnectionProviderIdPageable(connectionProviderId As Int32, sortExpression As String,
                                                              page As Int32, pageSize As Int32) _
            As PagedResult(Of Connection) Implements IConnectionRepository.GetDataByConnectionProviderIdPageable
            Dim command As IDbCommand =
                    _dbConnectionCommandProvider.GetGetDataByConnectionProviderIdPageableDbCommand(ConnectionProviderId,
                                                                                                   sortExpression, page,
                                                                                                   pageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Connection)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Connection(reader.GetInt32("ConnectionId"), reader.GetInt32("ProjectId"),
                                       reader.GetInt32("ConnectionProviderId"), reader.GetString("Name"),
                                       reader.GetString("ConnectionString"), reader.GetBoolean("IsDefault"),
                                       reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Dim totalCount As Int64 = GetDataByConnectionProviderIdRowCount(connectionProviderId)
            Dim pagedResults As PagedResult(Of Connection) = New PagedResult(Of Connection)(page, pageSize, totalCount,
                                                                                            entList)
            Return pagedResults
        End Function

        Public Function GetDataByConnectionProviderIdRowCount(connectionProviderId As Int32) As Int32
            Dim command As IDbCommand =
                    _dbConnectionCommandProvider.GetGetDataByConnectionProviderIdRowCountDbCommand(ConnectionProviderId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue
        End Function

        Public Function GetActiveDataByConnectionProviderId(connectionProviderId As Int32) As ICollection(Of Connection) _
            Implements IConnectionRepository.GetActiveDataByConnectionProviderId
            Dim command As IDbCommand =
                    _dbConnectionCommandProvider.GetGetActiveDataByConnectionProviderIdDbCommand(ConnectionProviderId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Connection)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Connection(reader.GetInt32("ConnectionId"), reader.GetInt32("ProjectId"),
                                       reader.GetInt32("ConnectionProviderId"), reader.GetString("Name"),
                                       reader.GetString("ConnectionString"), reader.GetBoolean("IsDefault"),
                                       reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList
        End Function

        Public Function GetActiveDataByConnectionProviderIdPageable(connectionProviderId As Int32,
                                                                    sortExpression As String, page As Int32,
                                                                    pageSize As Int32) As PagedResult(Of Connection) _
            Implements IConnectionRepository.GetActiveDataByConnectionProviderIdPageable
            Dim command As IDbCommand =
                    _dbConnectionCommandProvider.GetGetActiveDataByConnectionProviderIdPageableDbCommand(
                        ConnectionProviderId, sortExpression, page, PageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Connection)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Connection(reader.GetInt32("ConnectionId"), reader.GetInt32("ProjectId"),
                                       reader.GetInt32("ConnectionProviderId"), reader.GetString("Name"),
                                       reader.GetString("ConnectionString"), reader.GetBoolean("IsDefault"),
                                       reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Dim totalCount As Int64 = GetActiveDataByConnectionProviderIdRowCount(connectionProviderId)
            Dim pagedResults As PagedResult(Of Connection) = New PagedResult(Of Connection)(page, pageSize, totalCount,
                                                                                            entList)
            Return pagedResults
        End Function

        Public Function GetActiveDataByConnectionProviderIdRowCount(connectionProviderId As Int32) As Int32
            Dim command As IDbCommand =
                    _dbConnectionCommandProvider.GetGetActiveDataByConnectionProviderIdRowCountDbCommand(
                        ConnectionProviderId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue
        End Function

        Public Function GetDataByProjectId(projectId As Int32) As ICollection(Of Connection) _
            Implements IConnectionRepository.GetDataByProjectId
            Dim command As IDbCommand = _dbConnectionCommandProvider.GetGetDataByProjectIdDbCommand(ProjectId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Connection)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Connection(reader.GetInt32("ConnectionId"), reader.GetInt32("ProjectId"),
                                       reader.GetInt32("ConnectionProviderId"), reader.GetString("Name"),
                                       reader.GetString("ConnectionString"), reader.GetBoolean("IsDefault"),
                                       reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList
        End Function

        Public Function GetDataByProjectIdPageable(projectId As Int32, sortExpression As String, page As Int32,
                                                   pageSize As Int32) As PagedResult(Of Connection) _
            Implements IConnectionRepository.GetDataByProjectIdPageable
            Dim command As IDbCommand = _dbConnectionCommandProvider.GetGetDataByProjectIdPageableDbCommand(ProjectId,
                                                                                                            sortExpression,
                                                                                                            page,
                                                                                                            pageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Connection)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Connection(reader.GetInt32("ConnectionId"), reader.GetInt32("ProjectId"),
                                       reader.GetInt32("ConnectionProviderId"), reader.GetString("Name"),
                                       reader.GetString("ConnectionString"), reader.GetBoolean("IsDefault"),
                                       reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Dim totalCount As Int64 = GetDataByProjectIdRowCount(projectId)
            Dim pagedResults As PagedResult(Of Connection) = New PagedResult(Of Connection)(page, pageSize, totalCount,
                                                                                            entList)
            Return pagedResults
        End Function

        Public Function GetDataByProjectIdRowCount(projectId As Int32) As Int32
            Dim command As IDbCommand = _dbConnectionCommandProvider.GetGetDataByProjectIdRowCountDbCommand(ProjectId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue
        End Function

        Public Function GetActiveDataByProjectId(projectId As Int32) As ICollection(Of Connection) _
            Implements IConnectionRepository.GetActiveDataByProjectId
            Dim command As IDbCommand = _dbConnectionCommandProvider.GetGetActiveDataByProjectIdDbCommand(ProjectId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Connection)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Connection(reader.GetInt32("ConnectionId"), reader.GetInt32("ProjectId"),
                                       reader.GetInt32("ConnectionProviderId"), reader.GetString("Name"),
                                       reader.GetString("ConnectionString"), reader.GetBoolean("IsDefault"),
                                       reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList
        End Function

        Public Function GetActiveDataByProjectIdPageable(projectId As Int32, sortExpression As String, page As Int32,
                                                         pageSize As Int32) As PagedResult(Of Connection) _
            Implements IConnectionRepository.GetActiveDataByProjectIdPageable
            Dim command As IDbCommand =
                    _dbConnectionCommandProvider.GetGetActiveDataByProjectIdPageableDbCommand(ProjectId, sortExpression,
                                                                                              page, PageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Connection)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Connection(reader.GetInt32("ConnectionId"), reader.GetInt32("ProjectId"),
                                       reader.GetInt32("ConnectionProviderId"), reader.GetString("Name"),
                                       reader.GetString("ConnectionString"), reader.GetBoolean("IsDefault"),
                                       reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Dim totalCount As Int64 = GetActiveDataByProjectIdRowCount(projectId)
            Dim pagedResults As PagedResult(Of Connection) = New PagedResult(Of Connection)(page, pageSize, totalCount,
                                                                                            entList)
            Return pagedResults
        End Function

        Public Function GetActiveDataByProjectIdRowCount(projectId As Int32) as Int32
            Dim command As IDbCommand =
                    _dbConnectionCommandProvider.GetGetActiveDataByProjectIdRowCountDbCommand(ProjectId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue
        End Function


#Region "IDisposable Support"

        Private disposedValue As Boolean

        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    Select Case _dbConnHolder.Connection.State
                        Case ConnectionState.Open
                            _dbConnHolder.Close()
                    End Select
                    _dbConnHolder = Nothing
                End If

            End If
            Me.disposedValue = True
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub

#End Region
    End Class
End NameSpace
