Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports LucentDb.Data.DbCommandProvider

Namespace LucentDb.Data.SqlDbCommandProvider
    Public Class SqlDbConnectionCommandProvider
        Implements IDbConnectionCommandProvider

        ReadOnly _dbConnHolder As DbConnectionHolder

        Public Sub New()
            _dbConnHolder = New DbConnectionHolder(DbConnectionName)
        End Sub

        Public ReadOnly Property DbConnectionName As String Implements IDbConnectionCommandProvider.DbConnectionName
            Get
                Return "LucentDbConnection"
            End Get
        End Property

        Public ReadOnly Property ConnectionDbConnectionHolder As DbConnectionHolder _
            Implements IDbConnectionCommandProvider.ConnectionDbConnectionHolder
            Get
                Return _dbConnHolder
            End Get
        End Property


        ''' <summary>
        '''     Selects one or more records from the Connection table
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
        '''     Updates one or more records from the Connection table
        ''' </summary>
        ''' <param name="projectId" />
        ''' <param name="connectionProviderId" />
        ''' <param name="name" />
        ''' <param name="connectionString" />
        ''' <param name="isDefault" />
        ''' <param name="isActive" />
        ''' <param name="connectionId" />
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetUpdateDbCommand(projectId As Nullable(Of Int32), connectionProviderId As Int32,
                                           name As String, connectionString As String, isDefault As Boolean,
                                           isActive As Boolean, connectionId As Int32) As IDbCommand _
            Implements IDbConnectionCommandProvider.GetUpdateDbCommand

            Dim command As New SqlCommand("Connection_Update")
            command.CommandType = CommandType.StoredProcedure

            If (ProjectId.HasValue = true) Then
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ProjectId", SqlDbType.int, projectId))
            Else
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ProjectId", SqlDbType.int,
                                                                                DBNull.Value))
            End If
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionProviderId", SqlDbType.int,
                                                                            connectionProviderId))

            If (Not name Is Nothing) Then
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.varchar, name))
            Else
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.varchar, DBNull.Value))
            End If

            If (Not connectionString Is Nothing) Then
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionString", SqlDbType.varchar,
                                                                                connectionString))
            Else
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionString", SqlDbType.varchar,
                                                                                DBNull.Value))
            End If
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@IsDefault", SqlDbType.bit, isDefault))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@IsActive", SqlDbType.bit, isActive))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionId", SqlDbType.int, connectionId))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        '''     Deletes one or more records from the Connection table
        ''' </summary>
        ''' <param name="connectionId" />
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDeleteDbCommand(connectionId As Int32) As IDbCommand _
            Implements IDbConnectionCommandProvider.GetDeleteDbCommand

            Dim command As New SqlCommand("Connection_Delete")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionId", SqlDbType.int, connectionId))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        '''     Inserts a record into the Connection table on the database.
        ''' </summary>
        ''' <param name="projectId" />
        ''' <param name="connectionProviderId" />
        ''' <param name="name" />
        ''' <param name="connectionString" />
        ''' <param name="isDefault" />
        ''' <param name="isActive" />
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetInsertDbCommand(projectId As Nullable(Of Int32), connectionProviderId As Int32,
                                           name As String, connectionString As String, isDefault As Boolean,
                                           isActive As Boolean) As IDbCommand _
            Implements IDbConnectionCommandProvider.GetInsertDbCommand

            Dim command As New SqlCommand("Connection_Insert")
            command.CommandType = CommandType.StoredProcedure

            If (ProjectId.HasValue = true) Then
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ProjectId", SqlDbType.int, projectId))
            Else
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ProjectId", SqlDbType.int,
                                                                                DBNull.Value))
            End If
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionProviderId", SqlDbType.int,
                                                                            connectionProviderId))

            If (Not name Is Nothing) Then
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.varchar, name))
            Else
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.varchar, DBNull.Value))
            End If

            If (Not connectionString Is Nothing) Then
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionString", SqlDbType.varchar,
                                                                                connectionString))
            Else
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionString", SqlDbType.varchar,
                                                                                DBNull.Value))
            End If
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@IsDefault", SqlDbType.bit, isDefault))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@IsActive", SqlDbType.bit, isActive))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        '''     Function GetDataPageable returns a IDataReader populated with a subset of data from Connection
        ''' </summary>
        ''' <param name="sortExpression" />
        ''' <param name="page" />
        ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetGetDataPageableDbCommand(sortExpression As String, page As Int32, pageSize As Int32) _
            As IDbCommand Implements IDbConnectionCommandProvider.GetGetDataPageableDbCommand

            Dim command As New SqlCommand("Connection_GetDataPageable")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar,
                                                                            sortExpression))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@pageSize", SqlDbType.Int, pageSize))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        '''     Function GetRowCount returns the row count for Connection
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetGetRowCountDbCommand() As IDbCommand _
            Implements IDbConnectionCommandProvider.GetGetRowCountDbCommand

            Dim command As New SqlCommand("Connection_GetRowCount")
            command.CommandType = CommandType.StoredProcedure

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        '''     Function  GetDataByConnectionId returns a IDataReader for Connection
        ''' </summary>
        ''' <param name="connectionId" />
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetGetDataByConnectionIdDbCommand(connectionId As Int32) As IDbCommand _
            Implements IDbConnectionCommandProvider.GetGetDataByConnectionIdDbCommand

            Dim command As New SqlCommand("Connection_GetDataByConnectionId")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionId", SqlDbType.int, connectionId))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        '''     Function GetActiveData returns a IDataReader for Connection with records that are marked as active
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetGetActiveDataDbCommand() As IDbCommand _
            Implements IDbConnectionCommandProvider.GetGetActiveDataDbCommand

            Dim command As New SqlCommand("Connection_GetActiveData")
            command.CommandType = CommandType.StoredProcedure

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        '''     Function GetActiveDataPageable returns a IDataReader populated with paged active records from Connection
        ''' </summary>
        ''' <param name="sortExpression" />
        ''' <param name="page" />
        ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetGetActiveDataPageableDbCommand(sortExpression As String, page As Int32, pageSize As Int32) _
            As IDbCommand Implements IDbConnectionCommandProvider.GetGetActiveDataPageableDbCommand

            Dim command As New SqlCommand("Connection_GetActiveDataPageable")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar,
                                                                            sortExpression))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@PageSize", SqlDbType.Int, pageSize))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        '''     Function GetActiveDataRowCount returns the row count for Connection
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetGetActiveDataRowCountDbCommand() As IDbCommand _
            Implements IDbConnectionCommandProvider.GetGetActiveDataRowCountDbCommand

            Dim command As New SqlCommand("Connection_GetActiveDataRowCount")
            command.CommandType = CommandType.StoredProcedure

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        '''     Function GetDataByConnectionProviderId returns a IDataReader for Connection
        ''' </summary>
        ''' <param name="connectionProviderId" />
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetGetDataByConnectionProviderIdDbCommand(connectionProviderId As Int32) As IDbCommand _
            Implements IDbConnectionCommandProvider.GetGetDataByConnectionProviderIdDbCommand

            Dim command As New SqlCommand("Connection_GetDataByConnectionProviderId")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionProviderId", SqlDbType.int,
                                                                            connectionProviderId))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        '''     Function GetDataByConnectionProviderIdPageable returns a IDataReader populated with a subset of data from
        '''     Connection
        ''' </summary>
        ''' <param name="connectionProviderId" />
        ''' <param name="sortExpression" />
        ''' <param name="page" />
        ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetGetDataByConnectionProviderIdPageableDbCommand(connectionProviderId As Int32,
                                                                          sortExpression As String, page As Int32,
                                                                          pageSize As Int32) As IDbCommand _
            Implements IDbConnectionCommandProvider.GetGetDataByConnectionProviderIdPageableDbCommand

            Dim command As New SqlCommand("Connection_GetDataByConnectionProviderIdPageable")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionProviderId", SqlDbType.int,
                                                                            connectionProviderId))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar,
                                                                            sortExpression))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@pageSize", SqlDbType.Int, pageSize))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        '''     Function GetRowCount returns the row count for Connection
        ''' </summary>
        ''' <param name="connectionProviderId" />
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetGetDataByConnectionProviderIdRowCountDbCommand(connectionProviderId As Int32) As IDbCommand _
            Implements IDbConnectionCommandProvider.GetGetDataByConnectionProviderIdRowCountDbCommand

            Dim command As New SqlCommand("Connection_GetDataByConnectionProviderIdRowCount")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionProviderId", SqlDbType.int,
                                                                            connectionProviderId))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        '''     Function GetActiveDataByConnectionProviderId returns a IDataReader for Connection
        ''' </summary>
        ''' <param name="connectionProviderId" />
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetGetActiveDataByConnectionProviderIdDbCommand(connectionProviderId As Int32) As IDbCommand _
            Implements IDbConnectionCommandProvider.GetGetActiveDataByConnectionProviderIdDbCommand

            Dim command As New SqlCommand("Connection_GetActiveDataByConnectionProviderId")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionProviderId", SqlDbType.int,
                                                                            connectionProviderId))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        '''     Function GetActiveDataByConnectionProviderIdPageable returns a IDataReader populated with a subset of data from
        '''     Connection
        ''' </summary>
        ''' <param name="connectionProviderId" />
        ''' <param name="sortExpression" />
        ''' <param name="page" />
        ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetGetActiveDataByConnectionProviderIdPageableDbCommand(connectionProviderId As Int32,
                                                                                sortExpression As String, page As Int32,
                                                                                pageSize As Int32) As IDbCommand _
            Implements IDbConnectionCommandProvider.GetGetActiveDataByConnectionProviderIdPageableDbCommand

            Dim command As New SqlCommand("Connection_GetActiveDataByConnectionProviderIdPageable")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionProviderId", SqlDbType.int,
                                                                            connectionProviderId))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar,
                                                                            sortExpression))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@PageSize", SqlDbType.Int, pageSize))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        '''     Function GetRowCount returns the row count for Connection
        ''' </summary>
        ''' <param name="connectionProviderId" />
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetGetActiveDataByConnectionProviderIdRowCountDbCommand(connectionProviderId As Int32) _
            As IDbCommand _
            Implements IDbConnectionCommandProvider.GetGetActiveDataByConnectionProviderIdRowCountDbCommand

            Dim command As New SqlCommand("Connection_GetActiveDataByConnectionProviderIdRowCount")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ConnectionProviderId", SqlDbType.int,
                                                                            connectionProviderId))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        '''     Function GetDataByProjectId returns a IDataReader for Connection
        ''' </summary>
        ''' <param name="projectId" />
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetGetDataByProjectIdDbCommand(projectId As Int32) As IDbCommand _
            Implements IDbConnectionCommandProvider.GetGetDataByProjectIdDbCommand

            Dim command As New SqlCommand("Connection_GetDataByProjectId")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ProjectId", SqlDbType.int, projectId))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        '''     Function GetDataByProjectIdPageable returns a IDataReader populated with a subset of data from Connection
        ''' </summary>
        ''' <param name="projectId" />
        ''' <param name="sortExpression" />
        ''' <param name="page" />
        ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetGetDataByProjectIdPageableDbCommand(projectId As Int32, sortExpression As String,
                                                               page As Int32, pageSize As Int32) As IDbCommand _
            Implements IDbConnectionCommandProvider.GetGetDataByProjectIdPageableDbCommand

            Dim command As New SqlCommand("Connection_GetDataByProjectIdPageable")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ProjectId", SqlDbType.int, projectId))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar,
                                                                            sortExpression))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@pageSize", SqlDbType.Int, pageSize))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        '''     Function GetRowCount returns the row count for Connection
        ''' </summary>
        ''' <param name="projectId" />
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetGetDataByProjectIdRowCountDbCommand(projectId As Int32) As IDbCommand _
            Implements IDbConnectionCommandProvider.GetGetDataByProjectIdRowCountDbCommand

            Dim command As New SqlCommand("Connection_GetDataByProjectIdRowCount")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ProjectId", SqlDbType.int, projectId))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        '''     Function GetActiveDataByProjectId returns a IDataReader for Connection
        ''' </summary>
        ''' <param name="projectId" />
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetGetActiveDataByProjectIdDbCommand(projectId As Int32) As IDbCommand _
            Implements IDbConnectionCommandProvider.GetGetActiveDataByProjectIdDbCommand

            Dim command As New SqlCommand("Connection_GetActiveDataByProjectId")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ProjectId", SqlDbType.int, projectId))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        '''     Function GetActiveDataByProjectIdPageable returns a IDataReader populated with a subset of data from Connection
        ''' </summary>
        ''' <param name="projectId" />
        ''' <param name="sortExpression" />
        ''' <param name="page" />
        ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetGetActiveDataByProjectIdPageableDbCommand(projectId As Int32, sortExpression As String,
                                                                     page As Int32, pageSize As Int32) As IDbCommand _
            Implements IDbConnectionCommandProvider.GetGetActiveDataByProjectIdPageableDbCommand

            Dim command As New SqlCommand("Connection_GetActiveDataByProjectIdPageable")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ProjectId", SqlDbType.int, projectId))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar,
                                                                            sortExpression))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@PageSize", SqlDbType.Int, pageSize))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        '''     Function GetRowCount returns the row count for Connection
        ''' </summary>
        ''' <param name="projectId" />
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetGetActiveDataByProjectIdRowCountDbCommand(projectId As Int32) As IDbCommand _
            Implements IDbConnectionCommandProvider.GetGetActiveDataByProjectIdRowCountDbCommand

            Dim command As New SqlCommand("Connection_GetActiveDataByProjectIdRowCount")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ProjectId", SqlDbType.int, projectId))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function
    End Class
End Namespace
