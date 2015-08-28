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
Imports System.Data.Common
Imports System.Data.SqlClient
Imports LucentDb.Data.DbCommandProvider

Namespace LucentDb.Data.SqlDbCommandProvider 

  
Public Class SqlDbRunHistoryCommandProvider
      Implements IDbRunHistoryCommandProvider
    
      ReadOnly _dbConnHolder As DbConnectionHolder

      Public Sub New()
          _dbConnHolder = New DbConnectionHolder(DbConnectionName)
      End Sub

      Public ReadOnly Property DbConnectionName() As String Implements IDbRunHistoryCommandProvider.DbConnectionName
          Get
              Return "LucentDbConnection"
          End Get
      End Property

      Public ReadOnly Property RunHistoryDbConnectionHolder() As DbConnectionHolder Implements IDbRunHistoryCommandProvider.RunHistoryDbConnectionHolder
          Get
              Return _dbConnHolder
          End Get
      End Property
      
    
        ''' <summary>
        ''' Selects one or more records from the RunHistory table 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataDbCommand() As IDbCommand Implements IDbRunHistoryCommandProvider.GetGetDataDbCommand
            
            Dim command As New SqlCommand("RunHistory_Select")
            command.CommandType = CommandType.StoredProcedure
    
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Updates one or more records from the RunHistory table 
        ''' </summary>
      ''' <param name="testId" />
      ''' <param name="runDateTime" />
      ''' <param name="isValid" />
      ''' <param name="runLog" />
      ''' <param name="resultString" />
      ''' <param name="id" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetUpdateDbCommand( ByVal testId As Int32,  ByVal runDateTime As DateTime,  ByVal isValid As Boolean,  ByVal runLog As String,  ByVal resultString As String,  ByVal id As Int64) As IDbCommand Implements IDbRunHistoryCommandProvider.GetUpdateDbCommand
            
            Dim command As New SqlCommand("RunHistory_Update")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@TestId", SqlDbType.int, testId))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@RunDateTime", SqlDbType.datetime, runDateTime))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@IsValid", SqlDbType.bit, isValid))
      
            If (Not runLog  Is Nothing ) Then
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@RunLog", SqlDbType.text, runLog))
      Else
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@RunLog", SqlDbType.text, global.System.DBNull.Value))
      End If
        
            If (Not resultString  Is Nothing ) Then
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ResultString", SqlDbType.varchar, resultString))
      Else
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ResultString", SqlDbType.varchar, global.System.DBNull.Value))
      End If
                    command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Id", SqlDbType.bigint, id))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Deletes one or more records from the RunHistory table 
        ''' </summary>
      ''' <param name="id" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetDeleteDbCommand( ByVal id As Int64) As IDbCommand Implements IDbRunHistoryCommandProvider.GetDeleteDbCommand
            
            Dim command As New SqlCommand("RunHistory_Delete")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Id", SqlDbType.bigint, id))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Inserts a record into the RunHistory table on the database.
        ''' </summary>
      ''' <param name="testId" />
      ''' <param name="runDateTime" />
      ''' <param name="isValid" />
      ''' <param name="runLog" />
      ''' <param name="resultString" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetInsertDbCommand( ByVal testId As Int32,  ByVal runDateTime As DateTime,  ByVal isValid As Boolean,  ByVal runLog As String,  ByVal resultString As String) As IDbCommand Implements IDbRunHistoryCommandProvider.GetInsertDbCommand
            
            Dim command As New SqlCommand("RunHistory_Insert")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@TestId", SqlDbType.int, testId))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@RunDateTime", SqlDbType.datetime, runDateTime))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@IsValid", SqlDbType.bit, isValid))
      
            If (Not runLog  Is Nothing ) Then
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@RunLog", SqlDbType.text, runLog))
      Else
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@RunLog", SqlDbType.text, global.System.DBNull.Value))
      End If
        
            If (Not resultString  Is Nothing ) Then
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ResultString", SqlDbType.varchar, resultString))
      Else
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ResultString", SqlDbType.varchar, global.System.DBNull.Value))
      End If
        
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetDataPageable returns a IDataReader populated with a subset of data from RunHistory
        ''' </summary>
      ''' <param name="sortExpression" />
      ''' <param name="page" />
      ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataPageableDbCommand( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand Implements IDbRunHistoryCommandProvider.GetGetDataPageableDbCommand
            
            Dim command As New SqlCommand("RunHistory_GetDataPageable")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar, sortExpression))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@pageSize", SqlDbType.Int, pageSize))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetRowCount returns the row count for RunHistory
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetRowCountDbCommand() As IDbCommand Implements IDbRunHistoryCommandProvider.GetGetRowCountDbCommand
            
            Dim command As New SqlCommand("RunHistory_GetRowCount")
            command.CommandType = CommandType.StoredProcedure
    
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function  GetDataById returns a IDataReader for RunHistory
        ''' </summary>
      ''' <param name="id" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByIdDbCommand( ByVal id As Int64) As IDbCommand Implements IDbRunHistoryCommandProvider.GetGetDataByIdDbCommand
            
            Dim command As New SqlCommand("RunHistory_GetDataById")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Id", SqlDbType.bigint, id))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetDataByTestId returns a IDataReader for RunHistory
        ''' </summary>
      ''' <param name="testId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByTestIdDbCommand( ByVal testId As Int32) As IDbCommand Implements IDbRunHistoryCommandProvider.GetGetDataByTestIdDbCommand
            
            Dim command As New SqlCommand("RunHistory_GetDataByTestId")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@TestId", SqlDbType.int, testId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetDataByTestIdPageable returns a IDataReader populated with a subset of data from RunHistory
        ''' </summary>
      ''' <param name="testId" />
      ''' <param name="sortExpression" />
      ''' <param name="page" />
      ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByTestIdPageableDbCommand( ByVal testId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand Implements IDbRunHistoryCommandProvider.GetGetDataByTestIdPageableDbCommand
            
            Dim command As New SqlCommand("RunHistory_GetDataByTestIdPageable")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@TestId", SqlDbType.int, testId))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar, sortExpression))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@pageSize", SqlDbType.Int, pageSize))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetRowCount returns the row count for RunHistory
        ''' </summary>
      ''' <param name="testId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByTestIdRowCountDbCommand( ByVal testId As Int32) As IDbCommand Implements IDbRunHistoryCommandProvider.GetGetDataByTestIdRowCountDbCommand
            
            Dim command As New SqlCommand("RunHistory_GetDataByTestIdRowCount")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@TestId", SqlDbType.int, testId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
  End Class
 End Namespace
  