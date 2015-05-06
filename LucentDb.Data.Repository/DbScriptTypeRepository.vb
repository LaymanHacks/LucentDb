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
    Public Class DbScriptTypeRepository
        Implements IScriptTypeRepository
        Implements IDisposable

        Private ReadOnly _dbScriptTypeCommandProvider As IDbScriptTypeCommandProvider
        Private _dbConnHolder As DbConnectionHolder = Nothing

        Public Sub New(dbScriptTypeCommandProvider As IDbScriptTypeCommandProvider)
            _dbScriptTypeCommandProvider = dbScriptTypeCommandProvider
            _dbConnHolder = _dbScriptTypeCommandProvider.ScriptTypeDbConnectionHolder
        End Sub


        ''' <summary>
        '''     Selects one or more records from the ScriptType table
        ''' </summary>
        ''' '''
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Select, True)>
        Public Function GetData() As ICollection(Of ScriptType) Implements IScriptTypeRepository.GetData
            Dim command As IDbCommand = _dbScriptTypeCommandProvider.GetGetDataDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of ScriptType)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New ScriptType(reader.GetInt32("Id"), reader.GetString("Name"), reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList
        End Function

        ''' <summary>
        '''     Updates one or more records from the ScriptType table
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <param name="IsActive"></param>
        ''' <param name="Id"></param>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Update, True)>
        Public Sub Update(name As String, isActive As Boolean, id As Int32) Implements IScriptTypeRepository.Update
            Dim command As IDbCommand = _dbScriptTypeCommandProvider.GetUpdateDbCommand(Name, IsActive, Id)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Command.ExecuteNonQuery()
            _dbConnHolder.Close()
        End Sub

        ''' <summary>
        '''     Updates one or more records from the ScriptType table
        ''' </summary>
        ''' <param name="ScriptType"></param>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Update, False)>
        Public Sub Update(scriptType As ScriptType) Implements IScriptTypeRepository.Update
            With ScriptType
                Update(.Name, CBool(.IsActive), CInt(.Id))
            End With
        End Sub

        ''' <summary>
        '''     Deletes one or more records from the ScriptType table
        ''' </summary>
        ''' <param name="Id"></param>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Delete, True)>
        Public Sub Delete(id As Int32) Implements IScriptTypeRepository.Delete
            Dim command As IDbCommand = _dbScriptTypeCommandProvider.GetDeleteDbCommand(Id)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Command.ExecuteNonQuery()
            _dbConnHolder.Close()
        End Sub

        ''' <summary>
        '''     Deletes one or more records from the ScriptType table
        ''' </summary>
        ''' <param name="ScriptType"></param>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Delete, False)>
        Public Sub Delete(scriptType As ScriptType) Implements IScriptTypeRepository.Delete
            With ScriptType
                Delete(CInt(.Id))
            End With
        End Sub

        ''' <summary>
        '''     Inserts an entity of ScriptType into the database.
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <param name="IsActive"></param>
        ''' '''
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Insert, True)>
        Public Function Insert(name As String, isActive As Boolean) As Int32 Implements IScriptTypeRepository.Insert
            Dim command As IDbCommand = _dbScriptTypeCommandProvider.GetInsertDbCommand(Name, IsActive)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue
        End Function

        ''' <summary>
        '''     Inserts an entity of ScriptType into the database.
        ''' </summary>
        ''' <param name="ScriptType"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Insert, False)>
        Public Function Insert(scriptType As ScriptType) As Int32 Implements IScriptTypeRepository.Insert
            With ScriptType
                Return Insert(.Name, CBool(.IsActive))
            End With
        End Function

        ''' <summary>
        '''     Function GetDataPageable returns a IDataReader populated with a subset of data from ScriptType
        ''' </summary>
        ''' <param name="sortExpression"></param>
        ''' <param name="page"></param>
        ''' <param name="pageSize"></param>
        ''' '''
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Select, False)>
        Public Function GetDataPageable(sortExpression As String, page As Int32, pageSize As Int32) _
            As ICollection(Of ScriptType) Implements IScriptTypeRepository.GetDataPageable
            Dim command As IDbCommand = _dbScriptTypeCommandProvider.GetGetDataPageableDbCommand(sortExpression, page,
                                                                                                 pageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of ScriptType)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New ScriptType(reader.GetInt32("Id"), reader.GetString("Name"), reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList
        End Function

        ''' <summary>
        '''     Function GetRowCount returns the row count for ScriptType
        ''' </summary>
        ''' '''
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Select, False)>
        Public Function GetRowCount() As Int32 Implements IScriptTypeRepository.GetRowCount
            Dim command As IDbCommand = _dbScriptTypeCommandProvider.GetGetRowCountDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue
        End Function

        ''' <summary>
        '''     Function  GetDataById returns a IDataReader for ScriptType
        ''' </summary>
        ''' <param name="Id"></param>
        ''' '''
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Select, False)>
        Public Function GetDataById(id As Int32) As ICollection(Of ScriptType) _
            Implements IScriptTypeRepository.GetDataById
            Dim command As IDbCommand = _dbScriptTypeCommandProvider.GetGetDataByIdDbCommand(Id)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of ScriptType)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New ScriptType(reader.GetInt32("Id"), reader.GetString("Name"), reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList
        End Function

        ''' <summary>
        '''     Function GetActiveData returns a ScriptTypeList for ScriptType with records that are marked as active
        ''' </summary>
        ''' '''
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Select, True)>
        Public Function GetActiveData() As ICollection(Of ScriptType) Implements IScriptTypeRepository.GetActiveData
            Dim command As IDbCommand = _dbScriptTypeCommandProvider.GetGetActiveDataDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of ScriptType)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New ScriptType(reader.GetInt32("Id"), reader.GetString("Name"), reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList
        End Function

        ''' <summary>
        '''     Function GetActiveDataPageable returns a ScriptTypeList populated with paged active records from ScriptType
        ''' </summary>
        ''' <param name="sortExpression"></param>
        ''' <param name="page"></param>
        ''' <param name="PageSize"></param>
        ''' '''
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Select, False)>
        Public Function GetActiveDataPageable(sortExpression As String, page As Int32, pageSize As Int32) _
            As ICollection(Of ScriptType) Implements IScriptTypeRepository.GetActiveDataPageable
            Dim command As IDbCommand = _dbScriptTypeCommandProvider.GetGetActiveDataPageableDbCommand(sortExpression,
                                                                                                       page, PageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of ScriptType)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New ScriptType(reader.GetInt32("Id"), reader.GetString("Name"), reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList
        End Function

        ''' <summary>
        '''     Function GetActiveDataRowCount returns the row count for ScriptType
        ''' </summary>
        ''' '''
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Select, False)>
        Public Function GetActiveDataRowCount() As Int32 Implements IScriptTypeRepository.GetActiveDataRowCount
            Dim command As IDbCommand = _dbScriptTypeCommandProvider.GetGetActiveDataRowCountDbCommand()
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
