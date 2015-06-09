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

  
Public Class SqlDbProject_ConnectionCommandProvider
      Implements IDbProject_ConnectionCommandProvider
    
      ReadOnly _dbConnHolder As DbConnectionHolder

      Public Sub New()
          _dbConnHolder = New DbConnectionHolder(DbConnectionName)
      End Sub

      Public ReadOnly Property DbConnectionName() As String Implements IDbProject_ConnectionCommandProvider.DbConnectionName
          Get
              Return "LucentDbConnection"
          End Get
      End Property

      Public ReadOnly Property Project_ConnectionDbConnectionHolder() As DbConnectionHolder Implements IDbProject_ConnectionCommandProvider.Project_ConnectionDbConnectionHolder
          Get
              Return _dbConnHolder
          End Get
      End Property
      
    
        ''' <summary>
        ''' Selects one or more records from the Project_Connection table 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataDbCommand() As IDbCommand Implements IDbProject_ConnectionCommandProvider.GetGetDataDbCommand
            
            Dim command As New SqlCommand("Project_Connection_Select")
            command.CommandType = CommandType.StoredProcedure
    
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Updates one or more records from the Project_Connection table 
        ''' </summary>
      ''' <param name="projectId" />
      ''' <param name="connectionId" />
      ''' <param name="original_ProjectId" />
      ''' <param name="original_ConnectionId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetUpdateDbCommand( ByVal projectId As Int32,  ByVal connectionId As Int32,  ByVal original_ProjectId As Int32,  ByVal original_ConnectionId As Int32) As IDbCommand Implements IDbProject_ConnectionCommandProvider.GetUpdateDbCommand
            
            Dim command As New SqlCommand("Project_Connection_Update")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ProjectId", SqlDbType.int, projectId))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionId", SqlDbType.int, connectionId))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Original_ProjectId", SqlDbType.int, original_ProjectId))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Original_ConnectionId", SqlDbType.int, original_ConnectionId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Deletes one or more records from the Project_Connection table 
        ''' </summary>
      ''' <param name="projectId" />
      ''' <param name="connectionId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetDeleteDbCommand( ByVal projectId As Int32,  ByVal connectionId As Int32) As IDbCommand Implements IDbProject_ConnectionCommandProvider.GetDeleteDbCommand
            
            Dim command As New SqlCommand("Project_Connection_Delete")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ProjectId", SqlDbType.int, projectId))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionId", SqlDbType.int, connectionId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Inserts a record into the Project_Connection table on the database.
        ''' </summary>
      ''' <param name="projectId" />
      ''' <param name="connectionId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetInsertDbCommand( ByVal projectId As Int32,  ByVal connectionId As Int32) As IDbCommand Implements IDbProject_ConnectionCommandProvider.GetInsertDbCommand
            
            Dim command As New SqlCommand("Project_Connection_Insert")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ProjectId", SqlDbType.int, projectId))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionId", SqlDbType.int, connectionId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetDataPageable returns a IDataReader populated with a subset of data from Project_Connection
        ''' </summary>
      ''' <param name="sortExpression" />
      ''' <param name="page" />
      ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataPageableDbCommand( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand Implements IDbProject_ConnectionCommandProvider.GetGetDataPageableDbCommand
            
            Dim command As New SqlCommand("Project_Connection_GetDataPageable")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar, sortExpression))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@pageSize", SqlDbType.Int, pageSize))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetRowCount returns the row count for Project_Connection
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetRowCountDbCommand() As IDbCommand Implements IDbProject_ConnectionCommandProvider.GetGetRowCountDbCommand
            
            Dim command As New SqlCommand("Project_Connection_GetRowCount")
            command.CommandType = CommandType.StoredProcedure
    
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function  GetDataByProjectIdConnectionId returns a IDataReader for Project_Connection
        ''' </summary>
      ''' <param name="projectId" />
      ''' <param name="connectionId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByProjectIdConnectionIdDbCommand( ByVal projectId As Int32,  ByVal connectionId As Int32) As IDbCommand Implements IDbProject_ConnectionCommandProvider.GetGetDataByProjectIdConnectionIdDbCommand
            
            Dim command As New SqlCommand("Project_Connection_GetDataByProjectIdConnectionId")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ProjectId", SqlDbType.int, projectId))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionId", SqlDbType.int, connectionId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetDataByConnectionId returns a IDataReader for Project_Connection
        ''' </summary>
      ''' <param name="connectionId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByConnectionIdDbCommand( ByVal connectionId As Int32) As IDbCommand Implements IDbProject_ConnectionCommandProvider.GetGetDataByConnectionIdDbCommand
            
            Dim command As New SqlCommand("Project_Connection_GetDataByConnectionId")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionId", SqlDbType.int, connectionId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetDataByConnectionIdPageable returns a IDataReader populated with a subset of data from Project_Connection
        ''' </summary>
      ''' <param name="connectionId" />
      ''' <param name="sortExpression" />
      ''' <param name="page" />
      ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByConnectionIdPageableDbCommand( ByVal connectionId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand Implements IDbProject_ConnectionCommandProvider.GetGetDataByConnectionIdPageableDbCommand
            
            Dim command As New SqlCommand("Project_Connection_GetDataByConnectionIdPageable")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionId", SqlDbType.int, connectionId))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar, sortExpression))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@pageSize", SqlDbType.Int, pageSize))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetRowCount returns the row count for Project_Connection
        ''' </summary>
      ''' <param name="connectionId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByConnectionIdRowCountDbCommand( ByVal connectionId As Int32) As IDbCommand Implements IDbProject_ConnectionCommandProvider.GetGetDataByConnectionIdRowCountDbCommand
            
            Dim command As New SqlCommand("Project_Connection_GetDataByConnectionIdRowCount")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionId", SqlDbType.int, connectionId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetDataByProjectId returns a IDataReader for Project_Connection
        ''' </summary>
      ''' <param name="projectId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByProjectIdDbCommand( ByVal projectId As Int32) As IDbCommand Implements IDbProject_ConnectionCommandProvider.GetGetDataByProjectIdDbCommand
            
            Dim command As New SqlCommand("Project_Connection_GetDataByProjectId")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ProjectId", SqlDbType.int, projectId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetDataByProjectIdPageable returns a IDataReader populated with a subset of data from Project_Connection
        ''' </summary>
      ''' <param name="projectId" />
      ''' <param name="sortExpression" />
      ''' <param name="page" />
      ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByProjectIdPageableDbCommand( ByVal projectId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand Implements IDbProject_ConnectionCommandProvider.GetGetDataByProjectIdPageableDbCommand
            
            Dim command As New SqlCommand("Project_Connection_GetDataByProjectIdPageable")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ProjectId", SqlDbType.int, projectId))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar, sortExpression))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@pageSize", SqlDbType.Int, pageSize))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetRowCount returns the row count for Project_Connection
        ''' </summary>
      ''' <param name="projectId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByProjectIdRowCountDbCommand( ByVal projectId As Int32) As IDbCommand Implements IDbProject_ConnectionCommandProvider.GetGetDataByProjectIdRowCountDbCommand
            
            Dim command As New SqlCommand("Project_Connection_GetDataByProjectIdRowCount")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ProjectId", SqlDbType.int, projectId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
  End Class
 End Namespace
  