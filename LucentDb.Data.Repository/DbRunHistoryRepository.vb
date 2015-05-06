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
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Data
Imports LucentDb.Data.DbCommandProvider
Imports LucentDb.Domain.Entities


Namespace LucentDb.Data.Repository
    <DataObject(True)>
    Public Class DbRunHistoryRepository
        Implements IRunHistoryRepository
        Implements IDisposable

        Private ReadOnly _dbRunHistoryCommandProvider As IDbRunHistoryCommandProvider
        Private _dbConnHolder As DbConnectionHolder = Nothing

        Public Sub New(dbRunHistoryCommandProvider As IDbRunHistoryCommandProvider)
            _dbRunHistoryCommandProvider = dbRunHistoryCommandProvider
            _dbConnHolder = _dbRunHistoryCommandProvider.RunHistoryDbConnectionHolder
        End Sub


        ''' <summary>
        '''     Selects one or more records from the RunHistory table
        ''' </summary>
        ''' '''
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Select, True)>
        Public Function GetData() As ICollection(Of RunHistory) Implements IRunHistoryRepository.GetData
            Dim command As IDbCommand = _dbRunHistoryCommandProvider.GetGetDataDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of RunHistory)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New RunHistory(reader.GetInt64("Id"), reader.GetInt32("ScriptId"),
                                       reader.GetDateTime("RunDateTime"), reader.GetBoolean("IsPass"),
                                       reader.GetString("ResultString"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList
        End Function

        ''' <summary>
        '''     Updates one or more records from the RunHistory table
        ''' </summary>
        ''' <param name="Id"></param>
        ''' <param name="ScriptId"></param>
        ''' <param name="RunDateTime"></param>
        ''' <param name="IsPass"></param>
        ''' <param name="ResultString"></param>
        ''' <param name="Original_Id"></param>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Update, True)>
        Public Sub Update(id As Int64, scriptId As Int32, runDateTime As DateTime, isPass As Boolean,
                          resultString As String, original_Id As Int64) Implements IRunHistoryRepository.Update
            Dim command As IDbCommand = _dbRunHistoryCommandProvider.GetUpdateDbCommand(Id, ScriptId, RunDateTime,
                                                                                        IsPass, ResultString,
                                                                                        Original_Id)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Command.ExecuteNonQuery()
            _dbConnHolder.Close()
        End Sub

        ''' <summary>
        '''     Updates one or more records from the RunHistory table
        ''' </summary>
        ''' <param name="RunHistory"></param>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Update, False)>
        Public Sub Update(runHistory As RunHistory, original_Id As Int64) Implements IRunHistoryRepository.Update
            With RunHistory
                Update(CLng(.Id), CInt(.ScriptId), CDate(.RunDateTime), CBool(.IsPass), .ResultString, CLng(Original_Id))
            End With
        End Sub

        ''' <summary>
        '''     Deletes one or more records from the RunHistory table
        ''' </summary>
        ''' <param name="Id"></param>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Delete, True)>
        Public Sub Delete(id As Int64) Implements IRunHistoryRepository.Delete
            Dim command As IDbCommand = _dbRunHistoryCommandProvider.GetDeleteDbCommand(Id)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Command.ExecuteNonQuery()
            _dbConnHolder.Close()
        End Sub

        ''' <summary>
        '''     Deletes one or more records from the RunHistory table
        ''' </summary>
        ''' <param name="RunHistory"></param>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Delete, False)>
        Public Sub Delete(runHistory As RunHistory) Implements IRunHistoryRepository.Delete
            With RunHistory
                Delete(CLng(.Id))
            End With
        End Sub

        ''' <summary>
        '''     Inserts an entity of RunHistory into the database.
        ''' </summary>
        ''' <param name="Id"></param>
        ''' <param name="ScriptId"></param>
        ''' <param name="RunDateTime"></param>
        ''' <param name="IsPass"></param>
        ''' <param name="ResultString"></param>
        ''' '''
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Insert, True)>
        Public Function Insert(id As Int64, scriptId As Int32, runDateTime As DateTime, isPass As Boolean,
                               resultString As String) As Int64 Implements IRunHistoryRepository.Insert
            Dim command As IDbCommand = _dbRunHistoryCommandProvider.GetInsertDbCommand(Id, ScriptId, RunDateTime,
                                                                                        IsPass, ResultString)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int64 = Convert.ToInt64(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue
        End Function

        ''' <summary>
        '''     Inserts an entity of RunHistory into the database.
        ''' </summary>
        ''' <param name="RunHistory"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Insert, False)>
        Public Function Insert(runHistory As RunHistory) As Int64 Implements IRunHistoryRepository.Insert
            With RunHistory
                Return Insert(CLng(.Id), CInt(.ScriptId), CDate(.RunDateTime), CBool(.IsPass), .ResultString)
            End With
        End Function

        ''' <summary>
        '''     Function GetDataPageable returns a IDataReader populated with a subset of data from RunHistory
        ''' </summary>
        ''' <param name="sortExpression"></param>
        ''' <param name="page"></param>
        ''' <param name="pageSize"></param>
        ''' '''
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Select, False)>
        Public Function GetDataPageable(sortExpression As String, page As Int32, pageSize As Int32) _
            As ICollection(Of RunHistory) Implements IRunHistoryRepository.GetDataPageable
            Dim command As IDbCommand = _dbRunHistoryCommandProvider.GetGetDataPageableDbCommand(sortExpression, page,
                                                                                                 pageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of RunHistory)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New RunHistory(reader.GetInt64("Id"), reader.GetInt32("ScriptId"),
                                       reader.GetDateTime("RunDateTime"), reader.GetBoolean("IsPass"),
                                       reader.GetString("ResultString"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList
        End Function

        ''' <summary>
        '''     Function GetRowCount returns the row count for RunHistory
        ''' </summary>
        ''' '''
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Select, False)>
        Public Function GetRowCount() As Int32 Implements IRunHistoryRepository.GetRowCount
            Dim command As IDbCommand = _dbRunHistoryCommandProvider.GetGetRowCountDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue
        End Function

        ''' <summary>
        '''     Function  GetDataById returns a IDataReader for RunHistory
        ''' </summary>
        ''' <param name="Id"></param>
        ''' '''
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Select, False)>
        Public Function GetDataById(id As Int64) As ICollection(Of RunHistory) _
            Implements IRunHistoryRepository.GetDataById
            Dim command As IDbCommand = _dbRunHistoryCommandProvider.GetGetDataByIdDbCommand(Id)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of RunHistory)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New RunHistory(reader.GetInt64("Id"), reader.GetInt32("ScriptId"),
                                       reader.GetDateTime("RunDateTime"), reader.GetBoolean("IsPass"),
                                       reader.GetString("ResultString"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList
        End Function

        ''' <summary>
        '''     Function GetDataByScriptId returns a IDataReader for RunHistory
        ''' </summary>
        ''' <param name="ScriptId"></param>
        ''' '''
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Select, False)>
        Public Function GetDataByScriptId(scriptId As Int32) As ICollection(Of RunHistory) _
            Implements IRunHistoryRepository.GetDataByScriptId
            Dim command As IDbCommand = _dbRunHistoryCommandProvider.GetGetDataByScriptIdDbCommand(ScriptId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of RunHistory)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New RunHistory(reader.GetInt64("Id"), reader.GetInt32("ScriptId"),
                                       reader.GetDateTime("RunDateTime"), reader.GetBoolean("IsPass"),
                                       reader.GetString("ResultString"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList
        End Function

        ''' <summary>
        '''     Function GetDataByScriptIdPageable returns a IDataReader populated with a subset of data from RunHistory
        ''' </summary>
        ''' <param name="ScriptId"></param>
        ''' <param name="sortExpression"></param>
        ''' <param name="page"></param>
        ''' <param name="pageSize"></param>
        ''' '''
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Select, False)>
        Public Function GetDataByScriptIdPageable(scriptId As Int32, sortExpression As String, page As Int32,
                                                  pageSize As Int32) As ICollection(Of RunHistory) _
            Implements IRunHistoryRepository.GetDataByScriptIdPageable
            Dim command As IDbCommand = _dbRunHistoryCommandProvider.GetGetDataByScriptIdPageableDbCommand(ScriptId,
                                                                                                           sortExpression,
                                                                                                           page,
                                                                                                           pageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of RunHistory)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New RunHistory(reader.GetInt64("Id"), reader.GetInt32("ScriptId"),
                                       reader.GetDateTime("RunDateTime"), reader.GetBoolean("IsPass"),
                                       reader.GetString("ResultString"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList
        End Function

        ''' <summary>
        '''     Function GetRowCount returns the row count for RunHistory
        ''' </summary>
        ''' <param name="ScriptId"></param>
        ''' '''
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Select, False)>
        Public Function GetDataByScriptIdRowCount(scriptId As Int32) As Int32 _
            Implements IRunHistoryRepository.GetDataByScriptIdRowCount
            Dim command As IDbCommand = _dbRunHistoryCommandProvider.GetGetDataByScriptIdRowCountDbCommand(ScriptId)
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
End Namespace
