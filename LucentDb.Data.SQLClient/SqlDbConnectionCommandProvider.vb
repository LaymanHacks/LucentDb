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

  
Public Class SqlDbConnectionCommandProvider
      Implements IDbConnectionCommandProvider
    
      ReadOnly _dbConnHolder As DbConnectionHolder

      Public Sub New()
          _dbConnHolder = New DbConnectionHolder(DbConnectionName)
      End Sub

      Public ReadOnly Property DbConnectionName() As String Implements IDbConnectionCommandProvider.DbConnectionName
          Get
              Return "LucentDbConnection"
          End Get
      End Property

      Public ReadOnly Property ConnectionDbConnectionHolder() As DbConnectionHolder Implements IDbConnectionCommandProvider.ConnectionDbConnectionHolder
          Get
              Return _dbConnHolder
          End Get
      End Property
      
    
        ''' <summary>
        ''' Selects one or more records from the Connection table 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataDbCommand() As IDbCommand Implements IDbConnectionCommandProvider.GetGetDataDbCommand
            
            Dim command As New SqlCommand("Connection_Select")
            command.CommandType = CommandType.StoredProcedure
    
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Updates one or more records from the Connection table 
        ''' </summary>
      ''' <param name="connectionProviderId" />
      ''' <param name="name" />
      ''' <param name="connectionString" />
      ''' <param name="isActive" />
      ''' <param name="connectionId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetUpdateDbCommand( ByVal connectionProviderId As  Nullable(Of Int32) ,  ByVal name As String,  ByVal connectionString As String,  ByVal isActive As Boolean,  ByVal connectionId As Int32) As IDbCommand Implements IDbConnectionCommandProvider.GetUpdateDbCommand
            
            Dim command As New SqlCommand("Connection_Update")
            command.CommandType = CommandType.StoredProcedure
    
            If (ConnectionProviderId.HasValue = true ) Then
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionProviderId", SqlDbType.int, connectionProviderId))
      Else
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionProviderId", SqlDbType.int, global.System.DBNull.Value))
      End If
        
            If (Not name  Is Nothing ) Then
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.varchar, name))
      Else
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.varchar, global.System.DBNull.Value))
      End If
        
            If (Not connectionString  Is Nothing ) Then
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionString", SqlDbType.varchar, connectionString))
      Else
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionString", SqlDbType.varchar, global.System.DBNull.Value))
      End If
                    command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@IsActive", SqlDbType.bit, isActive))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionId", SqlDbType.int, connectionId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Deletes one or more records from the Connection table 
        ''' </summary>
      ''' <param name="connectionId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetDeleteDbCommand( ByVal connectionId As Int32) As IDbCommand Implements IDbConnectionCommandProvider.GetDeleteDbCommand
            
            Dim command As New SqlCommand("Connection_Delete")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionId", SqlDbType.int, connectionId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Inserts a record into the Connection table on the database.
        ''' </summary>
      ''' <param name="connectionProviderId" />
      ''' <param name="name" />
      ''' <param name="connectionString" />
      ''' <param name="isActive" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetInsertDbCommand( ByVal connectionProviderId As  Nullable(Of Int32) ,  ByVal name As String,  ByVal connectionString As String,  ByVal isActive As Boolean) As IDbCommand Implements IDbConnectionCommandProvider.GetInsertDbCommand
            
            Dim command As New SqlCommand("Connection_Insert")
            command.CommandType = CommandType.StoredProcedure
    
            If (ConnectionProviderId.HasValue = true ) Then
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionProviderId", SqlDbType.int, connectionProviderId))
      Else
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionProviderId", SqlDbType.int, global.System.DBNull.Value))
      End If
        
            If (Not name  Is Nothing ) Then
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.varchar, name))
      Else
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.varchar, global.System.DBNull.Value))
      End If
        
            If (Not connectionString  Is Nothing ) Then
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionString", SqlDbType.varchar, connectionString))
      Else
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionString", SqlDbType.varchar, global.System.DBNull.Value))
      End If
                    command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@IsActive", SqlDbType.bit, isActive))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetDataPageable returns a IDataReader populated with a subset of data from Connection
        ''' </summary>
      ''' <param name="sortExpression" />
      ''' <param name="page" />
      ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataPageableDbCommand( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand Implements IDbConnectionCommandProvider.GetGetDataPageableDbCommand
            
            Dim command As New SqlCommand("Connection_GetDataPageable")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar, sortExpression))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@pageSize", SqlDbType.Int, pageSize))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetRowCount returns the row count for Connection
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetRowCountDbCommand() As IDbCommand Implements IDbConnectionCommandProvider.GetGetRowCountDbCommand
            
            Dim command As New SqlCommand("Connection_GetRowCount")
            command.CommandType = CommandType.StoredProcedure
    
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function  GetDataByConnectionId returns a IDataReader for Connection
        ''' </summary>
      ''' <param name="connectionId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByConnectionIdDbCommand( ByVal connectionId As Int32) As IDbCommand Implements IDbConnectionCommandProvider.GetGetDataByConnectionIdDbCommand
            
            Dim command As New SqlCommand("Connection_GetDataByConnectionId")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionId", SqlDbType.int, connectionId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetActiveData returns a IDataReader for Connection with records that are marked as active
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetActiveDataDbCommand() As IDbCommand Implements IDbConnectionCommandProvider.GetGetActiveDataDbCommand
            
            Dim command As New SqlCommand("Connection_GetActiveData")
            command.CommandType = CommandType.StoredProcedure
    
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetActiveDataPageable returns a IDataReader populated with paged active records from Connection
        ''' </summary>
      ''' <param name="sortExpression" />
      ''' <param name="page" />
      ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetActiveDataPageableDbCommand( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand Implements IDbConnectionCommandProvider.GetGetActiveDataPageableDbCommand
            
            Dim command As New SqlCommand("Connection_GetActiveDataPageable")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar, sortExpression))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@PageSize", SqlDbType.Int, pageSize))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetActiveDataRowCount returns the row count for Connection
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetActiveDataRowCountDbCommand() As IDbCommand Implements IDbConnectionCommandProvider.GetGetActiveDataRowCountDbCommand
            
            Dim command As New SqlCommand("Connection_GetActiveDataRowCount")
            command.CommandType = CommandType.StoredProcedure
    
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetConnectionsForProjectByProjectId returns a IDataReader for Connection
        ''' </summary>
      ''' <param name="projectId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetConnectionsForProjectByProjectIdDbCommand( ByVal projectId As Int32) As IDbCommand Implements IDbConnectionCommandProvider.GetGetConnectionsForProjectByProjectIdDbCommand
            
            Dim command As New SqlCommand("Connection_GetConnectionsForProjectByProjectId")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ProjectId", SqlDbType.int, projectId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetConnectionsForProjectByProjectId returns a IDataReader for Connection
        ''' </summary>
      ''' <param name="projectId" />
      ''' <param name="sortExpression" />
      ''' <param name="page" />
      ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetConnectionsForProjectByProjectIdPageableDbCommand( ByVal projectId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand Implements IDbConnectionCommandProvider.GetGetConnectionsForProjectByProjectIdPageableDbCommand
            
            Dim command As New SqlCommand("Connection_GetConnectionsForProjectByProjectIdPageable")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ProjectId", SqlDbType.int, projectId))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar, sortExpression))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@PageSize", SqlDbType.Int, pageSize))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetConnectionsForProjectByProjectIdRowCount returns the row count for Connection
        ''' </summary>
      ''' <param name="projectId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetConnectionsForProjectByProjectIdRowCountDbCommand( ByVal projectId As Int32) As IDbCommand Implements IDbConnectionCommandProvider.GetGetConnectionsForProjectByProjectIdRowCountDbCommand
            
            Dim command As New SqlCommand("Connection_GetConnectionsForProjectByProjectIdRowCount")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ProjectId", SqlDbType.int, projectId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
  End Class
 End Namespace
  