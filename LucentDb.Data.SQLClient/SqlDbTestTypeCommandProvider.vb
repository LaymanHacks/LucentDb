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

  
Public Class SqlDbTestTypeCommandProvider
      Implements IDbTestTypeCommandProvider
    
      ReadOnly _dbConnHolder As DbConnectionHolder

      Public Sub New()
          _dbConnHolder = New DbConnectionHolder(DbConnectionName)
      End Sub

      Public ReadOnly Property DbConnectionName() As String Implements IDbTestTypeCommandProvider.DbConnectionName
          Get
              Return "LucentDbConnection"
          End Get
      End Property

      Public ReadOnly Property TestTypeDbConnectionHolder() As DbConnectionHolder Implements IDbTestTypeCommandProvider.TestTypeDbConnectionHolder
          Get
              Return _dbConnHolder
          End Get
      End Property
      
    
        ''' <summary>
        ''' Selects one or more records from the TestType table 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataDbCommand() As IDbCommand Implements IDbTestTypeCommandProvider.GetGetDataDbCommand
            
            Dim command As New SqlCommand("TestType_Select")
            command.CommandType = CommandType.StoredProcedure
    
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Updates one or more records from the TestType table 
        ''' </summary>
      ''' <param name="name" />
      ''' <param name="isActive" />
      ''' <param name="id" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetUpdateDbCommand( ByVal name As String,  ByVal isActive As Boolean,  ByVal id As Int32) As IDbCommand Implements IDbTestTypeCommandProvider.GetUpdateDbCommand
            
            Dim command As New SqlCommand("TestType_Update")
            command.CommandType = CommandType.StoredProcedure
    
            If (Not name  Is Nothing ) Then
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.varchar, name))
      Else
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.varchar, global.System.DBNull.Value))
      End If
                    command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@IsActive", SqlDbType.bit, isActive))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Id", SqlDbType.int, id))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Deletes one or more records from the TestType table 
        ''' </summary>
      ''' <param name="id" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetDeleteDbCommand( ByVal id As Int32) As IDbCommand Implements IDbTestTypeCommandProvider.GetDeleteDbCommand
            
            Dim command As New SqlCommand("TestType_Delete")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Id", SqlDbType.int, id))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Inserts a record into the TestType table on the database.
        ''' </summary>
      ''' <param name="name" />
      ''' <param name="isActive" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetInsertDbCommand( ByVal name As String,  ByVal isActive As Boolean) As IDbCommand Implements IDbTestTypeCommandProvider.GetInsertDbCommand
            
            Dim command As New SqlCommand("TestType_Insert")
            command.CommandType = CommandType.StoredProcedure
    
            If (Not name  Is Nothing ) Then
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.varchar, name))
      Else
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.varchar, global.System.DBNull.Value))
      End If
                    command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@IsActive", SqlDbType.bit, isActive))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetDataPageable returns a IDataReader populated with a subset of data from TestType
        ''' </summary>
      ''' <param name="sortExpression" />
      ''' <param name="page" />
      ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataPageableDbCommand( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand Implements IDbTestTypeCommandProvider.GetGetDataPageableDbCommand
            
            Dim command As New SqlCommand("TestType_GetDataPageable")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar, sortExpression))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@pageSize", SqlDbType.Int, pageSize))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetRowCount returns the row count for TestType
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetRowCountDbCommand() As IDbCommand Implements IDbTestTypeCommandProvider.GetGetRowCountDbCommand
            
            Dim command As New SqlCommand("TestType_GetRowCount")
            command.CommandType = CommandType.StoredProcedure
    
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function  GetDataById returns a IDataReader for TestType
        ''' </summary>
      ''' <param name="id" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByIdDbCommand( ByVal id As Int32) As IDbCommand Implements IDbTestTypeCommandProvider.GetGetDataByIdDbCommand
            
            Dim command As New SqlCommand("TestType_GetDataById")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Id", SqlDbType.int, id))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetActiveData returns a IDataReader for TestType with records that are marked as active
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetActiveDataDbCommand() As IDbCommand Implements IDbTestTypeCommandProvider.GetGetActiveDataDbCommand
            
            Dim command As New SqlCommand("TestType_GetActiveData")
            command.CommandType = CommandType.StoredProcedure
    
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetActiveDataPageable returns a IDataReader populated with paged active records from TestType
        ''' </summary>
      ''' <param name="sortExpression" />
      ''' <param name="page" />
      ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetActiveDataPageableDbCommand( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand Implements IDbTestTypeCommandProvider.GetGetActiveDataPageableDbCommand
            
            Dim command As New SqlCommand("TestType_GetActiveDataPageable")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar, sortExpression))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@PageSize", SqlDbType.Int, pageSize))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetActiveDataRowCount returns the row count for TestType
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetActiveDataRowCountDbCommand() As IDbCommand Implements IDbTestTypeCommandProvider.GetGetActiveDataRowCountDbCommand
            
            Dim command As New SqlCommand("TestType_GetActiveDataRowCount")
            command.CommandType = CommandType.StoredProcedure
    
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
  End Class
 End Namespace
  