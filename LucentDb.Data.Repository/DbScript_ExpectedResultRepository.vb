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
Imports System.Collections.Generic
Imports LucentDb.Data
Imports LucentDb.Domain.Entities
Imports LucentDb.Data.DbCommandProvider
Imports System.Collections.ObjectModel

  
Namespace LucentDb.Data.Repository    
    
    <Global.System.ComponentModel.DataObjectAttribute(true)>  _
    Public Class DbScript_ExpectedResultRepository
        Implements IScript_ExpectedResultRepository
        Implements IDisposable

        Private ReadOnly _dbScript_ExpectedResultCommandProvider As IDbScript_ExpectedResultCommandProvider
        Private _dbConnHolder As DbConnectionHolder = Nothing

        Public Sub New(ByVal dbScript_ExpectedResultCommandProvider As IDbScript_ExpectedResultCommandProvider)
            _dbScript_ExpectedResultCommandProvider = dbScript_ExpectedResultCommandProvider
            _dbConnHolder =_dbScript_ExpectedResultCommandProvider.Script_ExpectedResultDbConnectionHolder
        End Sub

      
    ''' <summary>
    ''' Selects one or more records from the Script_ExpectedResult table 
    ''' </summary>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, true)> _ 
    Public Function GetData()  as ICollection(Of Script_ExpectedResult) Implements IScript_ExpectedResultRepository.GetData
        Dim command As IDbCommand = _dbScript_ExpectedResultCommandProvider.GetGetDataDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Script_ExpectedResult)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Script_ExpectedResult( reader.GetInt32("ScriptId"),  reader.GetInt32("ExpectedResultId"),  reader.GetInt32("ResultIndex"))
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Updates one or more records from the Script_ExpectedResult table 
    ''' </summary>
   ''' <param name="ScriptId"></param>
   ''' <param name="ExpectedResultId"></param>
   ''' <param name="ResultIndex"></param>
   ''' <param name="Original_ScriptId"></param>
   ''' <param name="Original_ExpectedResultId"></param>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Update, true)> _ 
    Public Sub Update( ByVal scriptId As Int32,  ByVal expectedResultId As Int32,  ByVal resultIndex As Int32,  ByVal original_ScriptId As Int32,  ByVal original_ExpectedResultId As Int32)  Implements IScript_ExpectedResultRepository.Update
        Dim command As IDbCommand = _dbScript_ExpectedResultCommandProvider.GetUpdateDbCommand(ScriptId, ExpectedResultId, ResultIndex, Original_ScriptId, Original_ExpectedResultId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
          Command.ExecuteNonQuery
            _dbConnHolder.Close()
    End Sub
  
    ''' <summary>
    ''' Updates one or more records from the Script_ExpectedResult table 
    ''' </summary>
    ''' <param name="Script_ExpectedResult"></param>
    ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Update, False)> _ 
    Public Sub Update(ByVal script_ExpectedResult as Script_ExpectedResult,  ByVal original_ScriptId As Int32,  ByVal original_ExpectedResultId As Int32)  Implements IScript_ExpectedResultRepository.Update
             With Script_ExpectedResult
Update( CInt(.ScriptId),  CInt(.ExpectedResultId),  CInt(.ResultIndex),  CInt(Original_ScriptId),  CInt(Original_ExpectedResultId))
       End With

    End Sub
  
    ''' <summary>
    ''' Deletes one or more records from the Script_ExpectedResult table 
    ''' </summary>
   ''' <param name="ScriptId"></param>
   ''' <param name="ExpectedResultId"></param>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Delete, true)> _ 
    Public Sub Delete( ByVal scriptId As Int32,  ByVal expectedResultId As Int32)  Implements IScript_ExpectedResultRepository.Delete
        Dim command As IDbCommand = _dbScript_ExpectedResultCommandProvider.GetDeleteDbCommand(ScriptId, ExpectedResultId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
          Command.ExecuteNonQuery
            _dbConnHolder.Close()
    End Sub
  
    ''' <summary>
    ''' Deletes one or more records from the Script_ExpectedResult table 
    ''' </summary>
    ''' <param name="Script_ExpectedResult"></param>
    ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Delete, False)> _ 
    Public Sub Delete(ByVal script_ExpectedResult as Script_ExpectedResult)  Implements IScript_ExpectedResultRepository.Delete
             With Script_ExpectedResult
Delete( CInt(.ScriptId),  CInt(.ExpectedResultId))
       End With

    End Sub
  
    ''' <summary>
    ''' Inserts an entity of Script_ExpectedResult into the database.
    ''' </summary>
   ''' <param name="ScriptId"></param>
   ''' <param name="ExpectedResultId"></param>
   ''' <param name="ResultIndex"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Insert, true)> _ 
    Public Function Insert( ByVal scriptId As Int32,  ByVal expectedResultId As Int32,  ByVal resultIndex As Int32)  as ICollection(Of Script_ExpectedResult) Implements IScript_ExpectedResultRepository.Insert
        Dim command As IDbCommand = _dbScript_ExpectedResultCommandProvider.GetInsertDbCommand(ScriptId, ExpectedResultId, ResultIndex)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Script_ExpectedResult)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Script_ExpectedResult( reader.GetInt32("ScriptId"),  reader.GetInt32("ExpectedResultId"),  reader.GetInt32("ResultIndex"))
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Inserts an entity of Script_ExpectedResult into the database.
    ''' </summary>
    ''' <param name="Script_ExpectedResult"></param>
    ''' <returns></returns>
    ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Insert, False)> _ 
    Public Function Insert(ByVal script_ExpectedResult as Script_ExpectedResult)  as ICollection(Of Script_ExpectedResult) Implements IScript_ExpectedResultRepository.Insert
             With Script_ExpectedResult
 Return Insert( CInt(.ScriptId),  CInt(.ExpectedResultId),  CInt(.ResultIndex))
       End With

    End Function
  
    ''' <summary>
    ''' Function GetDataPageable returns a IDataReader populated with a subset of data from Script_ExpectedResult
    ''' </summary>
   ''' <param name="sortExpression"></param>
   ''' <param name="page"></param>
   ''' <param name="pageSize"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetDataPageable( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as ICollection(Of Script_ExpectedResult) Implements IScript_ExpectedResultRepository.GetDataPageable
        Dim command As IDbCommand = _dbScript_ExpectedResultCommandProvider.GetGetDataPageableDbCommand(sortExpression, page, pageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Script_ExpectedResult)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Script_ExpectedResult( reader.GetInt32("ScriptId"),  reader.GetInt32("ExpectedResultId"),  reader.GetInt32("ResultIndex"))
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetRowCount returns the row count for Script_ExpectedResult
    ''' </summary>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetRowCount()  as Int32 Implements IScript_ExpectedResultRepository.GetRowCount
        Dim command As IDbCommand = _dbScript_ExpectedResultCommandProvider.GetGetRowCountDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim returnValue As Int32  = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue 

    End Function
  
    ''' <summary>
    ''' Function  GetDataByScriptIdExpectedResultId returns a IDataReader for Script_ExpectedResult
    ''' </summary>
   ''' <param name="ScriptId"></param>
   ''' <param name="ExpectedResultId"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetDataByScriptIdExpectedResultId( ByVal scriptId As Int32,  ByVal expectedResultId As Int32)  as ICollection(Of Script_ExpectedResult) Implements IScript_ExpectedResultRepository.GetDataByScriptIdExpectedResultId
        Dim command As IDbCommand = _dbScript_ExpectedResultCommandProvider.GetGetDataByScriptIdExpectedResultIdDbCommand(ScriptId, ExpectedResultId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Script_ExpectedResult)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Script_ExpectedResult( reader.GetInt32("ScriptId"),  reader.GetInt32("ExpectedResultId"),  reader.GetInt32("ResultIndex"))
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetDataByExpectedResultId returns a IDataReader for Script_ExpectedResult
    ''' </summary>
   ''' <param name="ExpectedResultId"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetDataByExpectedResultId( ByVal expectedResultId As Int32)  as ICollection(Of Script_ExpectedResult) Implements IScript_ExpectedResultRepository.GetDataByExpectedResultId
        Dim command As IDbCommand = _dbScript_ExpectedResultCommandProvider.GetGetDataByExpectedResultIdDbCommand(ExpectedResultId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Script_ExpectedResult)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Script_ExpectedResult( reader.GetInt32("ScriptId"),  reader.GetInt32("ExpectedResultId"),  reader.GetInt32("ResultIndex"))
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetDataByExpectedResultIdPageable returns a IDataReader populated with a subset of data from Script_ExpectedResult
    ''' </summary>
   ''' <param name="ExpectedResultId"></param>
   ''' <param name="sortExpression"></param>
   ''' <param name="page"></param>
   ''' <param name="pageSize"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetDataByExpectedResultIdPageable( ByVal expectedResultId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as ICollection(Of Script_ExpectedResult) Implements IScript_ExpectedResultRepository.GetDataByExpectedResultIdPageable
        Dim command As IDbCommand = _dbScript_ExpectedResultCommandProvider.GetGetDataByExpectedResultIdPageableDbCommand(ExpectedResultId, sortExpression, page, pageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Script_ExpectedResult)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Script_ExpectedResult( reader.GetInt32("ScriptId"),  reader.GetInt32("ExpectedResultId"),  reader.GetInt32("ResultIndex"))
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetRowCount returns the row count for Script_ExpectedResult
    ''' </summary>
   ''' <param name="ExpectedResultId"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetDataByExpectedResultIdRowCount( ByVal expectedResultId As Int32)  as Int32 Implements IScript_ExpectedResultRepository.GetDataByExpectedResultIdRowCount
        Dim command As IDbCommand = _dbScript_ExpectedResultCommandProvider.GetGetDataByExpectedResultIdRowCountDbCommand(ExpectedResultId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim returnValue As Int32  = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue 

    End Function
  
    ''' <summary>
    ''' Function GetDataByScriptId returns a IDataReader for Script_ExpectedResult
    ''' </summary>
   ''' <param name="ScriptId"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetDataByScriptId( ByVal scriptId As Int32)  as ICollection(Of Script_ExpectedResult) Implements IScript_ExpectedResultRepository.GetDataByScriptId
        Dim command As IDbCommand = _dbScript_ExpectedResultCommandProvider.GetGetDataByScriptIdDbCommand(ScriptId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Script_ExpectedResult)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Script_ExpectedResult( reader.GetInt32("ScriptId"),  reader.GetInt32("ExpectedResultId"),  reader.GetInt32("ResultIndex"))
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetDataByScriptIdPageable returns a IDataReader populated with a subset of data from Script_ExpectedResult
    ''' </summary>
   ''' <param name="ScriptId"></param>
   ''' <param name="sortExpression"></param>
   ''' <param name="page"></param>
   ''' <param name="pageSize"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetDataByScriptIdPageable( ByVal scriptId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as ICollection(Of Script_ExpectedResult) Implements IScript_ExpectedResultRepository.GetDataByScriptIdPageable
        Dim command As IDbCommand = _dbScript_ExpectedResultCommandProvider.GetGetDataByScriptIdPageableDbCommand(ScriptId, sortExpression, page, pageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Script_ExpectedResult)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Script_ExpectedResult( reader.GetInt32("ScriptId"),  reader.GetInt32("ExpectedResultId"),  reader.GetInt32("ResultIndex"))
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetRowCount returns the row count for Script_ExpectedResult
    ''' </summary>
   ''' <param name="ScriptId"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetDataByScriptIdRowCount( ByVal scriptId As Int32)  as Int32 Implements IScript_ExpectedResultRepository.GetDataByScriptIdRowCount
        Dim command As IDbCommand = _dbScript_ExpectedResultCommandProvider.GetGetDataByScriptIdRowCountDbCommand(ScriptId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim returnValue As Int32  = Convert.ToInt32(Command.ExecuteScalar())
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
