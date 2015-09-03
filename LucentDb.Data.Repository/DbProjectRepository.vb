Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Data
Imports LucentDb.Data.DbCommandProvider
Imports LucentDb.Domain.Entities


Namespace LucentDb.Data.Repository
    <DataObject(true)>
    Public Class DbProjectRepository
        Implements IProjectRepository
        Implements IDisposable

        Private ReadOnly _dbProjectCommandProvider As IDbProjectCommandProvider
        Private _dbConnHolder As DbConnectionHolder = Nothing

        Public Sub New(dbProjectCommandProvider As IDbProjectCommandProvider)
            _dbProjectCommandProvider = dbProjectCommandProvider
            _dbConnHolder = _dbProjectCommandProvider.ProjectDbConnectionHolder
        End Sub

        Public Function GetData() as ICollection(Of Project) Implements IProjectRepository.GetData
            Dim command As IDbCommand = _dbProjectCommandProvider.GetGetDataDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList as new Collection(Of Project)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Project(reader.GetInt32("ProjectId"), reader.GetString("Name"),
                                    reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
        End Function

        Public Sub Update(name As String, isActive As Boolean, projectId As Int32) Implements IProjectRepository.Update
            Dim command As IDbCommand = _dbProjectCommandProvider.GetUpdateDbCommand(Name, IsActive, ProjectId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Command.ExecuteNonQuery
            _dbConnHolder.Close()
        End Sub

        Public Sub Update(project as Project) Implements IProjectRepository.Update
            With Project
                Update(.Name, CBool(.IsActive), CInt(.ProjectId))
            End With
        End Sub

        Public Sub Delete(projectId As Int32) Implements IProjectRepository.Delete
            Dim command As IDbCommand = _dbProjectCommandProvider.GetDeleteDbCommand(ProjectId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Command.ExecuteNonQuery
            _dbConnHolder.Close()
        End Sub

        Public Sub Delete(project as Project) Implements IProjectRepository.Delete
            With Project
                Delete(CInt(.ProjectId))
            End With
        End Sub

        Public Function Insert(name As String, isActive As Boolean) as Int32 Implements IProjectRepository.Insert
            Dim command As IDbCommand = _dbProjectCommandProvider.GetInsertDbCommand(Name, IsActive)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue
        End Function

        Public Function Insert(project as Project) as Int32 Implements IProjectRepository.Insert
            With Project
                Return Insert(.Name, CBool(.IsActive))
            End With
        End Function

        Public Function GetDataPageable(sortExpression As String, page As Int32, pageSize As Int32) _
            as PagedResult(Of Project) Implements IProjectRepository.GetDataPageable
            Dim command As IDbCommand = _dbProjectCommandProvider.GetGetDataPageableDbCommand(sortExpression, page,
                                                                                              pageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList as new Collection(Of Project)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Project(reader.GetInt32("ProjectId"), reader.GetString("Name"),
                                    reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close
            Dim totalCount as Int64 = GetRowCount()
            Dim pagedResults as PagedResult(Of Project) = New PagedResult(Of Project)(page, pageSize, totalCount,
                                                                                      entList)
            Return pagedResults
        End Function

        Public Function GetRowCount() as Int32
            Dim command As IDbCommand = _dbProjectCommandProvider.GetGetRowCountDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue
        End Function

        Public Function GetDataByProjectId(projectId As Int32) as ICollection(Of Project) _
            Implements IProjectRepository.GetDataByProjectId
            Dim command As IDbCommand = _dbProjectCommandProvider.GetGetDataByProjectIdDbCommand(ProjectId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList as new Collection(Of Project)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Project(reader.GetInt32("ProjectId"), reader.GetString("Name"),
                                    reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
        End Function

        Public Function GetActiveData() as ICollection(Of Project) Implements IProjectRepository.GetActiveData
            Dim command As IDbCommand = _dbProjectCommandProvider.GetGetActiveDataDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList as new Collection(Of Project)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Project(reader.GetInt32("ProjectId"), reader.GetString("Name"),
                                    reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
        End Function

        Public Function GetActiveDataPageable(sortExpression As String, page As Int32, pageSize As Int32) _
            as PagedResult(Of Project) Implements IProjectRepository.GetActiveDataPageable
            Dim command As IDbCommand = _dbProjectCommandProvider.GetGetActiveDataPageableDbCommand(sortExpression, page,
                                                                                                    PageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList as new Collection(Of Project)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Project(reader.GetInt32("ProjectId"), reader.GetString("Name"),
                                    reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close
            Dim totalCount as Int64 = GetActiveDataRowCount()
            Dim pagedResults as PagedResult(Of Project) = New PagedResult(Of Project)(page, pageSize, totalCount,
                                                                                      entList)
            Return pagedResults
        End Function

        Public Function GetActiveDataRowCount() as Int32
            Dim command As IDbCommand = _dbProjectCommandProvider.GetGetActiveDataRowCountDbCommand()
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
