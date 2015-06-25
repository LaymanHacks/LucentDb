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

  
Public Class SqlDbExpectedResultCommandProvider
      Implements IDbExpectedResultCommandProvider
    
      ReadOnly _dbConnHolder As DbConnectionHolder

      Public Sub New()
          _dbConnHolder = New DbConnectionHolder(DbConnectionName)
      End Sub

      Public ReadOnly Property DbConnectionName() As String Implements IDbExpectedResultCommandProvider.DbConnectionName
          Get
              Return "LucentDbConnection"
          End Get
      End Property

      Public ReadOnly Property ExpectedResultDbConnectionHolder() As DbConnectionHolder Implements IDbExpectedResultCommandProvider.ExpectedResultDbConnectionHolder
          Get
              Return _dbConnHolder
          End Get
      End Property
      
    
        ''' <summary>
        ''' Selects one or more records from the ExpectedResult table 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataDbCommand() As IDbCommand Implements IDbExpectedResultCommandProvider.GetGetDataDbCommand
            
            Dim command As New SqlCommand("ExpectedResult_Select")
            command.CommandType = CommandType.StoredProcedure
    
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Updates one or more records from the ExpectedResult table 
        ''' </summary>
      ''' <param name="testId" />
      ''' <param name="expectedResultTypeId" />
      ''' <param name="assertTypeId" />
      ''' <param name="expectedValue" />
      ''' <param name="resultIndex" />
      ''' <param name="id" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetUpdateDbCommand( ByVal testId As Int32,  ByVal expectedResultTypeId As  Nullable(Of Int32) ,  ByVal assertTypeId As  Nullable(Of Int32) ,  ByVal expectedValue As String,  ByVal resultIndex As Int32,  ByVal id As Int32) As IDbCommand Implements IDbExpectedResultCommandProvider.GetUpdateDbCommand
            
            Dim command As New SqlCommand("ExpectedResult_Update")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@TestId", SqlDbType.int, testId))
      
            If (ExpectedResultTypeId.HasValue = true ) Then
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ExpectedResultTypeId", SqlDbType.int, expectedResultTypeId))
      Else
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ExpectedResultTypeId", SqlDbType.int, global.System.DBNull.Value))
      End If
        
            If (AssertTypeId.HasValue = true ) Then
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@AssertTypeId", SqlDbType.int, assertTypeId))
      Else
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@AssertTypeId", SqlDbType.int, global.System.DBNull.Value))
      End If
        
            If (Not expectedValue  Is Nothing ) Then
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ExpectedValue", SqlDbType.varchar, expectedValue))
      Else
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ExpectedValue", SqlDbType.varchar, global.System.DBNull.Value))
      End If
                    command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ResultIndex", SqlDbType.int, resultIndex))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Id", SqlDbType.int, id))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Deletes one or more records from the ExpectedResult table 
        ''' </summary>
      ''' <param name="id" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetDeleteDbCommand( ByVal id As Int32) As IDbCommand Implements IDbExpectedResultCommandProvider.GetDeleteDbCommand
            
            Dim command As New SqlCommand("ExpectedResult_Delete")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Id", SqlDbType.int, id))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Inserts a record into the ExpectedResult table on the database.
        ''' </summary>
      ''' <param name="testId" />
      ''' <param name="expectedResultTypeId" />
      ''' <param name="assertTypeId" />
      ''' <param name="expectedValue" />
      ''' <param name="resultIndex" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetInsertDbCommand( ByVal testId As Int32,  ByVal expectedResultTypeId As  Nullable(Of Int32) ,  ByVal assertTypeId As  Nullable(Of Int32) ,  ByVal expectedValue As String,  ByVal resultIndex As Int32) As IDbCommand Implements IDbExpectedResultCommandProvider.GetInsertDbCommand
            
            Dim command As New SqlCommand("ExpectedResult_Insert")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@TestId", SqlDbType.int, testId))
      
            If (ExpectedResultTypeId.HasValue = true ) Then
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ExpectedResultTypeId", SqlDbType.int, expectedResultTypeId))
      Else
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ExpectedResultTypeId", SqlDbType.int, global.System.DBNull.Value))
      End If
        
            If (AssertTypeId.HasValue = true ) Then
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@AssertTypeId", SqlDbType.int, assertTypeId))
      Else
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@AssertTypeId", SqlDbType.int, global.System.DBNull.Value))
      End If
        
            If (Not expectedValue  Is Nothing ) Then
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ExpectedValue", SqlDbType.varchar, expectedValue))
      Else
                            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ExpectedValue", SqlDbType.varchar, global.System.DBNull.Value))
      End If
                    command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ResultIndex", SqlDbType.int, resultIndex))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetDataPageable returns a IDataReader populated with a subset of data from ExpectedResult
        ''' </summary>
      ''' <param name="sortExpression" />
      ''' <param name="page" />
      ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataPageableDbCommand( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand Implements IDbExpectedResultCommandProvider.GetGetDataPageableDbCommand
            
            Dim command As New SqlCommand("ExpectedResult_GetDataPageable")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar, sortExpression))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@pageSize", SqlDbType.Int, pageSize))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetRowCount returns the row count for ExpectedResult
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetRowCountDbCommand() As IDbCommand Implements IDbExpectedResultCommandProvider.GetGetRowCountDbCommand
            
            Dim command As New SqlCommand("ExpectedResult_GetRowCount")
            command.CommandType = CommandType.StoredProcedure
    
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function  GetDataById returns a IDataReader for ExpectedResult
        ''' </summary>
      ''' <param name="id" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByIdDbCommand( ByVal id As Int32) As IDbCommand Implements IDbExpectedResultCommandProvider.GetGetDataByIdDbCommand
            
            Dim command As New SqlCommand("ExpectedResult_GetDataById")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Id", SqlDbType.int, id))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetDataByAssertTypeId returns a IDataReader for ExpectedResult
        ''' </summary>
      ''' <param name="assertTypeId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByAssertTypeIdDbCommand( ByVal assertTypeId As Int32) As IDbCommand Implements IDbExpectedResultCommandProvider.GetGetDataByAssertTypeIdDbCommand
            
            Dim command As New SqlCommand("ExpectedResult_GetDataByAssertTypeId")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@AssertTypeId", SqlDbType.int, assertTypeId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetDataByAssertTypeIdPageable returns a IDataReader populated with a subset of data from ExpectedResult
        ''' </summary>
      ''' <param name="assertTypeId" />
      ''' <param name="sortExpression" />
      ''' <param name="page" />
      ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByAssertTypeIdPageableDbCommand( ByVal assertTypeId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand Implements IDbExpectedResultCommandProvider.GetGetDataByAssertTypeIdPageableDbCommand
            
            Dim command As New SqlCommand("ExpectedResult_GetDataByAssertTypeIdPageable")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@AssertTypeId", SqlDbType.int, assertTypeId))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar, sortExpression))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@pageSize", SqlDbType.Int, pageSize))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetRowCount returns the row count for ExpectedResult
        ''' </summary>
      ''' <param name="assertTypeId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByAssertTypeIdRowCountDbCommand( ByVal assertTypeId As Int32) As IDbCommand Implements IDbExpectedResultCommandProvider.GetGetDataByAssertTypeIdRowCountDbCommand
            
            Dim command As New SqlCommand("ExpectedResult_GetDataByAssertTypeIdRowCount")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@AssertTypeId", SqlDbType.int, assertTypeId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetDataByExpectedResultTypeId returns a IDataReader for ExpectedResult
        ''' </summary>
      ''' <param name="expectedResultTypeId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByExpectedResultTypeIdDbCommand( ByVal expectedResultTypeId As Int32) As IDbCommand Implements IDbExpectedResultCommandProvider.GetGetDataByExpectedResultTypeIdDbCommand
            
            Dim command As New SqlCommand("ExpectedResult_GetDataByExpectedResultTypeId")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ExpectedResultTypeId", SqlDbType.int, expectedResultTypeId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetDataByExpectedResultTypeIdPageable returns a IDataReader populated with a subset of data from ExpectedResult
        ''' </summary>
      ''' <param name="expectedResultTypeId" />
      ''' <param name="sortExpression" />
      ''' <param name="page" />
      ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByExpectedResultTypeIdPageableDbCommand( ByVal expectedResultTypeId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand Implements IDbExpectedResultCommandProvider.GetGetDataByExpectedResultTypeIdPageableDbCommand
            
            Dim command As New SqlCommand("ExpectedResult_GetDataByExpectedResultTypeIdPageable")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ExpectedResultTypeId", SqlDbType.int, expectedResultTypeId))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar, sortExpression))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@pageSize", SqlDbType.Int, pageSize))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetRowCount returns the row count for ExpectedResult
        ''' </summary>
      ''' <param name="expectedResultTypeId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByExpectedResultTypeIdRowCountDbCommand( ByVal expectedResultTypeId As Int32) As IDbCommand Implements IDbExpectedResultCommandProvider.GetGetDataByExpectedResultTypeIdRowCountDbCommand
            
            Dim command As New SqlCommand("ExpectedResult_GetDataByExpectedResultTypeIdRowCount")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ExpectedResultTypeId", SqlDbType.int, expectedResultTypeId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetDataByTestId returns a IDataReader for ExpectedResult
        ''' </summary>
      ''' <param name="testId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByTestIdDbCommand( ByVal testId As Int32) As IDbCommand Implements IDbExpectedResultCommandProvider.GetGetDataByTestIdDbCommand
            
            Dim command As New SqlCommand("ExpectedResult_GetDataByTestId")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@TestId", SqlDbType.int, testId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetDataByTestIdPageable returns a IDataReader populated with a subset of data from ExpectedResult
        ''' </summary>
      ''' <param name="testId" />
      ''' <param name="sortExpression" />
      ''' <param name="page" />
      ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByTestIdPageableDbCommand( ByVal testId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32) As IDbCommand Implements IDbExpectedResultCommandProvider.GetGetDataByTestIdPageableDbCommand
            
            Dim command As New SqlCommand("ExpectedResult_GetDataByTestIdPageable")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@TestId", SqlDbType.int, testId))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar, sortExpression))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
                  command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@pageSize", SqlDbType.Int, pageSize))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
        ''' <summary>
        ''' Function GetRowCount returns the row count for ExpectedResult
        ''' </summary>
      ''' <param name="testId" />
        ''' <returns></returns>
        ''' <remarks></remarks> 
        Public Function GetGetDataByTestIdRowCountDbCommand( ByVal testId As Int32) As IDbCommand Implements IDbExpectedResultCommandProvider.GetGetDataByTestIdRowCountDbCommand
            
            Dim command As New SqlCommand("ExpectedResult_GetDataByTestIdRowCount")
            command.CommandType = CommandType.StoredProcedure
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@TestId", SqlDbType.int, testId))
      
            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
      End Function
         
            
  End Class
 End Namespace
  