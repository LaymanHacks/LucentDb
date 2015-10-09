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

  
Public Class SqlDbRunHistoryDetailCommandProvider
      Implements IDbRunHistoryDetailCommandProvider
    
      ReadOnly _dbConnHolder As DbConnectionHolder

      Public Sub New()
          _dbConnHolder = New DbConnectionHolder(DbConnectionName)
      End Sub

      Public ReadOnly Property DbConnectionName() As String Implements IDbRunHistoryDetailCommandProvider.DbConnectionName
          Get
              Return "LucentDbConnection"
          End Get
      End Property

      Public ReadOnly Property RunHistoryDetailDbConnectionHolder() As DbConnectionHolder Implements IDbRunHistoryDetailCommandProvider.RunHistoryDetailDbConnectionHolder
          Get
              Return _dbConnHolder
          End Get
      End Property
      
    
        ''' <summary>
        ''' Selects one or more records from the RunHistoryDetail table 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataDbCommand() As IDbCommand Implements IDbRunHistoryDetailCommandProvider.GetGetDataDbCommand
            
            Dim command As New SqlCommand("RunHistoryDetail_Select")
            command.CommandType = CommandType.StoredProcedure
    
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Updates one or more records from the RunHistoryDetail table 
        ''' </summary>
      ''' <param name="runHistoryId" />
      ''' <param name="testId" />
      ''' <param name="runDateTime" />
      ''' <param name="isValid" />
      ''' <param name="resultString" />
      ''' <param name="id" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetUpdateDbCommand( ByVal runHistoryId As Int64,  ByVal testId As Int32,  ByVal runDateTime As DateTime,  ByVal isValid As Boolean,  ByVal resultString As String,  ByVal id As Int64) As IDbCommand Implements IDbRunHistoryDetailCommandProvider.GetUpdateDbCommand
            
            Dim command As New SqlCommand("RunHistoryDetail_Update")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@RunHistoryId", SqlDbType.bigint, runHistoryId))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@TestId", SqlDbType.int, testId))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@RunDateTime", SqlDbType.datetime, runDateTime))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@IsValid", SqlDbType.bit, isValid))
      
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
        ''' Deletes one or more records from the RunHistoryDetail table 
        ''' </summary>
      ''' <param name="id" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetDeleteDbCommand( ByVal id As Int64) As IDbCommand Implements IDbRunHistoryDetailCommandProvider.GetDeleteDbCommand
            
            Dim command As New SqlCommand("RunHistoryDetail_Delete")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Id", SqlDbType.bigint, id))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Inserts a record into the RunHistoryDetail table on the database.
        ''' </summary>
      ''' <param name="runHistoryId" />
      ''' <param name="testId" />
      ''' <param name="runDateTime" />
      ''' <param name="isValid" />
      ''' <param name="resultString" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetInsertDbCommand( ByVal runHistoryId As Int64,  ByVal testId As Int32,  ByVal runDateTime As DateTime,  ByVal isValid As Boolean,  ByVal resultString As String) As IDbCommand Implements IDbRunHistoryDetailCommandProvider.GetInsertDbCommand
            
            Dim command As New SqlCommand("RunHistoryDetail_Insert")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@RunHistoryId", SqlDbType.bigint, runHistoryId))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@TestId", SqlDbType.int, testId))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@RunDateTime", SqlDbType.datetime, runDateTime))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@IsValid", SqlDbType.bit, isValid))
      
            If (Not resultString  Is Nothing ) Then
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ResultString", SqlDbType.varchar, resultString))
      Else
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ResultString", SqlDbType.varchar, global.System.DBNull.Value))
      End If
        
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetDataPageable returns a IDataReader populated with a subset of data from RunHistoryDetail
        ''' </summary>
      ''' <param name="sortExpression" />
      ''' <param name="page" />
      ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataPageableDbCommand( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand Implements IDbRunHistoryDetailCommandProvider.GetGetDataPageableDbCommand
            
            Dim command As New SqlCommand("RunHistoryDetail_GetDataPageable")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar, sortExpression))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@pageSize", SqlDbType.Int, pageSize))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetRowCount returns the row count for RunHistoryDetail
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetRowCountDbCommand() As IDbCommand Implements IDbRunHistoryDetailCommandProvider.GetGetRowCountDbCommand
            
            Dim command As New SqlCommand("RunHistoryDetail_GetRowCount")
            command.CommandType = CommandType.StoredProcedure
    
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function  GetDataById returns a IDataReader for RunHistoryDetail
        ''' </summary>
      ''' <param name="id" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByIdDbCommand( ByVal id As Int64) As IDbCommand Implements IDbRunHistoryDetailCommandProvider.GetGetDataByIdDbCommand
            
            Dim command As New SqlCommand("RunHistoryDetail_GetDataById")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Id", SqlDbType.bigint, id))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetDataByRunHistoryId returns a IDataReader for RunHistoryDetail
        ''' </summary>
      ''' <param name="runHistoryId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByRunHistoryIdDbCommand( ByVal runHistoryId As Int64) As IDbCommand Implements IDbRunHistoryDetailCommandProvider.GetGetDataByRunHistoryIdDbCommand
            
            Dim command As New SqlCommand("RunHistoryDetail_GetDataByRunHistoryId")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@RunHistoryId", SqlDbType.bigint, runHistoryId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetDataByRunHistoryIdPageable returns a IDataReader populated with a subset of data from RunHistoryDetail
        ''' </summary>
      ''' <param name="runHistoryId" />
      ''' <param name="sortExpression" />
      ''' <param name="page" />
      ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByRunHistoryIdPageableDbCommand( ByVal runHistoryId As Int64,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand Implements IDbRunHistoryDetailCommandProvider.GetGetDataByRunHistoryIdPageableDbCommand
            
            Dim command As New SqlCommand("RunHistoryDetail_GetDataByRunHistoryIdPageable")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@RunHistoryId", SqlDbType.bigint, runHistoryId))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar, sortExpression))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@pageSize", SqlDbType.Int, pageSize))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetRowCount returns the row count for RunHistoryDetail
        ''' </summary>
      ''' <param name="runHistoryId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByRunHistoryIdRowCountDbCommand( ByVal runHistoryId As Int64) As IDbCommand Implements IDbRunHistoryDetailCommandProvider.GetGetDataByRunHistoryIdRowCountDbCommand
            
            Dim command As New SqlCommand("RunHistoryDetail_GetDataByRunHistoryIdRowCount")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@RunHistoryId", SqlDbType.bigint, runHistoryId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
  End Class
 End Namespace
  