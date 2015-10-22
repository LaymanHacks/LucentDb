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

  
Public Class SqlDbTestValueTypeCommandProvider
      Implements IDbTestValueTypeCommandProvider
    
      ReadOnly _dbConnHolder As DbConnectionHolder

      Public Sub New()
          _dbConnHolder = New DbConnectionHolder(DbConnectionName)
      End Sub

      Public ReadOnly Property DbConnectionName() As String Implements IDbTestValueTypeCommandProvider.DbConnectionName
          Get
              Return "LucentDbConnection"
          End Get
      End Property

      Public ReadOnly Property TestValueTypeDbConnectionHolder() As DbConnectionHolder Implements IDbTestValueTypeCommandProvider.TestValueTypeDbConnectionHolder
          Get
              Return _dbConnHolder
          End Get
      End Property
      
    
        ''' <summary>
        ''' Selects one or more records from the TestValueType table 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataDbCommand() As IDbCommand Implements IDbTestValueTypeCommandProvider.GetGetDataDbCommand
            
            Dim command As New SqlCommand("TestValueType_Select")
            command.CommandType = CommandType.StoredProcedure
    
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Updates one or more records from the TestValueType table 
        ''' </summary>
      ''' <param name="testTypeId" />
      ''' <param name="name" />
      ''' <param name="isActive" />
      ''' <param name="id" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetUpdateDbCommand( ByVal testTypeId As Int32,  ByVal name As String,  ByVal isActive As Boolean,  ByVal id As Int32) As IDbCommand Implements IDbTestValueTypeCommandProvider.GetUpdateDbCommand
            
            Dim command As New SqlCommand("TestValueType_Update")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@TestTypeId", SqlDbType.int, testTypeId))
      
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
        ''' Deletes one or more records from the TestValueType table 
        ''' </summary>
      ''' <param name="id" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetDeleteDbCommand( ByVal id As Int32) As IDbCommand Implements IDbTestValueTypeCommandProvider.GetDeleteDbCommand
            
            Dim command As New SqlCommand("TestValueType_Delete")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Id", SqlDbType.int, id))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Inserts a record into the TestValueType table on the database.
        ''' </summary>
      ''' <param name="testTypeId" />
      ''' <param name="name" />
      ''' <param name="isActive" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetInsertDbCommand( ByVal testTypeId As Int32,  ByVal name As String,  ByVal isActive As Boolean) As IDbCommand Implements IDbTestValueTypeCommandProvider.GetInsertDbCommand
            
            Dim command As New SqlCommand("TestValueType_Insert")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@TestTypeId", SqlDbType.int, testTypeId))
      
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
        ''' Function GetDataPageable returns a IDataReader populated with a subset of data from TestValueType
        ''' </summary>
      ''' <param name="sortExpression" />
      ''' <param name="page" />
      ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataPageableDbCommand( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand Implements IDbTestValueTypeCommandProvider.GetGetDataPageableDbCommand
            
            Dim command As New SqlCommand("TestValueType_GetDataPageable")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar, sortExpression))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@pageSize", SqlDbType.Int, pageSize))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetRowCount returns the row count for TestValueType
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetRowCountDbCommand() As IDbCommand Implements IDbTestValueTypeCommandProvider.GetGetRowCountDbCommand
            
            Dim command As New SqlCommand("TestValueType_GetRowCount")
            command.CommandType = CommandType.StoredProcedure
    
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function  GetDataById returns a IDataReader for TestValueType
        ''' </summary>
      ''' <param name="id" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByIdDbCommand( ByVal id As Int32) As IDbCommand Implements IDbTestValueTypeCommandProvider.GetGetDataByIdDbCommand
            
            Dim command As New SqlCommand("TestValueType_GetDataById")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Id", SqlDbType.int, id))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetActiveData returns a IDataReader for TestValueType with records that are marked as active
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetActiveDataDbCommand() As IDbCommand Implements IDbTestValueTypeCommandProvider.GetGetActiveDataDbCommand
            
            Dim command As New SqlCommand("TestValueType_GetActiveData")
            command.CommandType = CommandType.StoredProcedure
    
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetActiveDataPageable returns a IDataReader populated with paged active records from TestValueType
        ''' </summary>
      ''' <param name="sortExpression" />
      ''' <param name="page" />
      ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetActiveDataPageableDbCommand( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand Implements IDbTestValueTypeCommandProvider.GetGetActiveDataPageableDbCommand
            
            Dim command As New SqlCommand("TestValueType_GetActiveDataPageable")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar, sortExpression))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@PageSize", SqlDbType.Int, pageSize))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetActiveDataRowCount returns the row count for TestValueType
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetActiveDataRowCountDbCommand() As IDbCommand Implements IDbTestValueTypeCommandProvider.GetGetActiveDataRowCountDbCommand
            
            Dim command As New SqlCommand("TestValueType_GetActiveDataRowCount")
            command.CommandType = CommandType.StoredProcedure
    
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetDataByTestTypeId returns a IDataReader for TestValueType
        ''' </summary>
      ''' <param name="testTypeId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByTestTypeIdDbCommand( ByVal testTypeId As Int32) As IDbCommand Implements IDbTestValueTypeCommandProvider.GetGetDataByTestTypeIdDbCommand
            
            Dim command As New SqlCommand("TestValueType_GetDataByTestTypeId")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@TestTypeId", SqlDbType.int, testTypeId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetDataByTestTypeIdPageable returns a IDataReader populated with a subset of data from TestValueType
        ''' </summary>
      ''' <param name="testTypeId" />
      ''' <param name="sortExpression" />
      ''' <param name="page" />
      ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByTestTypeIdPageableDbCommand( ByVal testTypeId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand Implements IDbTestValueTypeCommandProvider.GetGetDataByTestTypeIdPageableDbCommand
            
            Dim command As New SqlCommand("TestValueType_GetDataByTestTypeIdPageable")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@TestTypeId", SqlDbType.int, testTypeId))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar, sortExpression))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@pageSize", SqlDbType.Int, pageSize))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetRowCount returns the row count for TestValueType
        ''' </summary>
      ''' <param name="testTypeId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByTestTypeIdRowCountDbCommand( ByVal testTypeId As Int32) As IDbCommand Implements IDbTestValueTypeCommandProvider.GetGetDataByTestTypeIdRowCountDbCommand
            
            Dim command As New SqlCommand("TestValueType_GetDataByTestTypeIdRowCount")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@TestTypeId", SqlDbType.int, testTypeId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetActiveDataByTestTypeId returns a IDataReader for TestValueType
        ''' </summary>
      ''' <param name="testTypeId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetActiveDataByTestTypeIdDbCommand( ByVal testTypeId As Int32) As IDbCommand Implements IDbTestValueTypeCommandProvider.GetGetActiveDataByTestTypeIdDbCommand
            
            Dim command As New SqlCommand("TestValueType_GetActiveDataByTestTypeId")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@TestTypeId", SqlDbType.int, testTypeId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetActiveDataByTestTypeIdPageable returns a IDataReader populated with a subset of data from TestValueType
        ''' </summary>
      ''' <param name="testTypeId" />
      ''' <param name="sortExpression" />
      ''' <param name="page" />
      ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetActiveDataByTestTypeIdPageableDbCommand( ByVal testTypeId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand Implements IDbTestValueTypeCommandProvider.GetGetActiveDataByTestTypeIdPageableDbCommand
            
            Dim command As New SqlCommand("TestValueType_GetActiveDataByTestTypeIdPageable")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@TestTypeId", SqlDbType.int, testTypeId))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar, sortExpression))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@PageSize", SqlDbType.Int, pageSize))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetRowCount returns the row count for TestValueType
        ''' </summary>
      ''' <param name="testTypeId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetActiveDataByTestTypeIdRowCountDbCommand( ByVal testTypeId As Int32) As IDbCommand Implements IDbTestValueTypeCommandProvider.GetGetActiveDataByTestTypeIdRowCountDbCommand
            
            Dim command As New SqlCommand("TestValueType_GetActiveDataByTestTypeIdRowCount")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@TestTypeId", SqlDbType.int, testTypeId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
  End Class
 End Namespace
  