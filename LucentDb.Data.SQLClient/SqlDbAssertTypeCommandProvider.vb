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

  
Public Class SqlDbAssertTypeCommandProvider
      Implements IDbAssertTypeCommandProvider
    
      ReadOnly _dbConnHolder As DbConnectionHolder

      Public Sub New()
          _dbConnHolder = New DbConnectionHolder(DbConnectionName)
      End Sub

      Public ReadOnly Property DbConnectionName() As String Implements IDbAssertTypeCommandProvider.DbConnectionName
          Get
              Return "LucentDbConnection"
          End Get
      End Property

      Public ReadOnly Property AssertTypeDbConnectionHolder() As DbConnectionHolder Implements IDbAssertTypeCommandProvider.AssertTypeDbConnectionHolder
          Get
              Return _dbConnHolder
          End Get
      End Property
      
    
        ''' <summary>
        ''' Selects one or more records from the AssertType table 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataDbCommand() As IDbCommand Implements IDbAssertTypeCommandProvider.GetGetDataDbCommand
            
            Dim command As New SqlCommand("AssertType_Select")
            command.CommandType = CommandType.StoredProcedure
    
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Updates one or more records from the AssertType table 
        ''' </summary>
      ''' <param name="name" />
      ''' <param name="id" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetUpdateDbCommand( ByVal name As String,  ByVal id As Int32) As IDbCommand Implements IDbAssertTypeCommandProvider.GetUpdateDbCommand
            
            Dim command As New SqlCommand("AssertType_Update")
            command.CommandType = CommandType.StoredProcedure
    
            If (Not name  Is Nothing ) Then
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.varchar, name))
      Else
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.varchar, global.System.DBNull.Value))
      End If
                    command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Id", SqlDbType.int, id))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Deletes one or more records from the AssertType table 
        ''' </summary>
      ''' <param name="id" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetDeleteDbCommand( ByVal id As Int32) As IDbCommand Implements IDbAssertTypeCommandProvider.GetDeleteDbCommand
            
            Dim command As New SqlCommand("AssertType_Delete")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Id", SqlDbType.int, id))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Inserts a record into the AssertType table on the database.
        ''' </summary>
      ''' <param name="name" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetInsertDbCommand( ByVal name As String) As IDbCommand Implements IDbAssertTypeCommandProvider.GetInsertDbCommand
            
            Dim command As New SqlCommand("AssertType_Insert")
            command.CommandType = CommandType.StoredProcedure
    
            If (Not name  Is Nothing ) Then
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.varchar, name))
      Else
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.varchar, global.System.DBNull.Value))
      End If
        
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetDataPageable returns a IDataReader populated with a subset of data from AssertType
        ''' </summary>
      ''' <param name="sortExpression" />
      ''' <param name="page" />
      ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataPageableDbCommand( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand Implements IDbAssertTypeCommandProvider.GetGetDataPageableDbCommand
            
            Dim command As New SqlCommand("AssertType_GetDataPageable")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar, sortExpression))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@pageSize", SqlDbType.Int, pageSize))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetRowCount returns the row count for AssertType
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetRowCountDbCommand() As IDbCommand Implements IDbAssertTypeCommandProvider.GetGetRowCountDbCommand
            
            Dim command As New SqlCommand("AssertType_GetRowCount")
            command.CommandType = CommandType.StoredProcedure
    
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function  GetDataById returns a IDataReader for AssertType
        ''' </summary>
      ''' <param name="id" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByIdDbCommand( ByVal id As Int32) As IDbCommand Implements IDbAssertTypeCommandProvider.GetGetDataByIdDbCommand
            
            Dim command As New SqlCommand("AssertType_GetDataById")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Id", SqlDbType.int, id))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
  End Class
 End Namespace
  