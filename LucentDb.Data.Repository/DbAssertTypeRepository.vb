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
    <DataObject(true)>
    Public Class DbAssertTypeRepository
        Implements IAssertTypeRepository
        Implements IDisposable

        Private ReadOnly _dbAssertTypeCommandProvider As IDbAssertTypeCommandProvider
        Private _dbConnHolder As DbConnectionHolder = Nothing

        Public Sub New(dbAssertTypeCommandProvider As IDbAssertTypeCommandProvider)
            _dbAssertTypeCommandProvider = dbAssertTypeCommandProvider
            _dbConnHolder = _dbAssertTypeCommandProvider.AssertTypeDbConnectionHolder
        End Sub


        ''' <summary>
        '''     Selects one or more records from the AssertType table
        ''' </summary>
        ''' '''
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Select, true)>
        Public Function GetData() as ICollection(Of AssertType) Implements IAssertTypeRepository.GetData
            Dim command As IDbCommand = _dbAssertTypeCommandProvider.GetGetDataDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList as new Collection(Of AssertType)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim tempEntity As New AssertType(reader.GetInt32("Id"), reader.GetString("Name"))
                entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
        End Function

        ''' <summary>
        '''     Updates one or more records from the AssertType table
        ''' </summary>
        ''' <param name="Name"></param>
        ''' <param name="Id"></param>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Update, true)>
        Public Sub Update(name As String, id As Int32) Implements IAssertTypeRepository.Update
            Dim command As IDbCommand = _dbAssertTypeCommandProvider.GetUpdateDbCommand(Name, Id)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Command.ExecuteNonQuery
            _dbConnHolder.Close()
        End Sub

        ''' <summary>
        '''     Updates one or more records from the AssertType table
        ''' </summary>
        ''' <param name="AssertType"></param>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Update, False)>
        Public Sub Update(assertType as AssertType) Implements IAssertTypeRepository.Update
            With AssertType
                Update(.Name, CInt(.Id))
            End With
        End Sub

        ''' <summary>
        '''     Deletes one or more records from the AssertType table
        ''' </summary>
        ''' <param name="Id"></param>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Delete, true)>
        Public Sub Delete(id As Int32) Implements IAssertTypeRepository.Delete
            Dim command As IDbCommand = _dbAssertTypeCommandProvider.GetDeleteDbCommand(Id)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Command.ExecuteNonQuery
            _dbConnHolder.Close()
        End Sub

        ''' <summary>
        '''     Deletes one or more records from the AssertType table
        ''' </summary>
        ''' <param name="AssertType"></param>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Delete, False)>
        Public Sub Delete(assertType as AssertType) Implements IAssertTypeRepository.Delete
            With AssertType
                Delete(CInt(.Id))
            End With
        End Sub

        ''' <summary>
        '''     Inserts an entity of AssertType into the database.
        ''' </summary>
        ''' <param name="Name"></param>
        ''' '''
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Insert, true)>
        Public Function Insert(name As String) as Int32 Implements IAssertTypeRepository.Insert
            Dim command As IDbCommand = _dbAssertTypeCommandProvider.GetInsertDbCommand(Name)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue
        End Function

        ''' <summary>
        '''     Inserts an entity of AssertType into the database.
        ''' </summary>
        ''' <param name="AssertType"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Insert, False)>
        Public Function Insert(assertType as AssertType) as Int32 Implements IAssertTypeRepository.Insert
            With AssertType
                Return Insert(.Name)
            End With
        End Function

        ''' <summary>
        '''     Function GetDataPageable returns a IDataReader populated with a subset of data from AssertType
        ''' </summary>
        ''' <param name="sortExpression"></param>
        ''' <param name="page"></param>
        ''' <param name="pageSize"></param>
        ''' '''
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Select, false)>
        Public Function GetDataPageable(sortExpression As String, page As Int32, pageSize As Int32) _
            as ICollection(Of AssertType) Implements IAssertTypeRepository.GetDataPageable
            Dim command As IDbCommand = _dbAssertTypeCommandProvider.GetGetDataPageableDbCommand(sortExpression, page,
                                                                                                 pageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList as new Collection(Of AssertType)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim tempEntity As New AssertType(reader.GetInt32("Id"), reader.GetString("Name"))
                entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
        End Function

        ''' <summary>
        '''     Function GetRowCount returns the row count for AssertType
        ''' </summary>
        ''' '''
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Select, false)>
        Public Function GetRowCount() as Int32 Implements IAssertTypeRepository.GetRowCount
            Dim command As IDbCommand = _dbAssertTypeCommandProvider.GetGetRowCountDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue
        End Function

        ''' <summary>
        '''     Function  GetDataById returns a IDataReader for AssertType
        ''' </summary>
        ''' <param name="Id"></param>
        ''' '''
        ''' <returns></returns>
        ''' <remarks></remarks>
        <DataObjectMethod(DataObjectMethodType.Select, false)>
        Public Function GetDataById(id As Int32) as ICollection(Of AssertType) _
            Implements IAssertTypeRepository.GetDataById
            Dim command As IDbCommand = _dbAssertTypeCommandProvider.GetGetDataByIdDbCommand(Id)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList as new Collection(Of AssertType)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim tempEntity As New AssertType(reader.GetInt32("Id"), reader.GetString("Name"))
                entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
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
