Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports LucentDb.Data.DbCommandProvider

Namespace LucentDb.Data.SqlDbCommandProvider
    Public Class SqlDbProjectCommandProvider
        Implements IDbProjectCommandProvider

        ReadOnly _dbConnHolder As DbConnectionHolder

        Public Sub New()
            _dbConnHolder = New DbConnectionHolder(DbConnectionName)
        End Sub

        Public ReadOnly Property DbConnectionName As String Implements IDbProjectCommandProvider.DbConnectionName
            Get
                Return "LucentDbConnection"
            End Get
        End Property

        Public ReadOnly Property ProjectDbConnectionHolder As DbConnectionHolder _
            Implements IDbProjectCommandProvider.ProjectDbConnectionHolder
            Get
                Return _dbConnHolder
            End Get
        End Property


        ''' <summary>
        '''     Selects one or more records from the Project table
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetGetDataDbCommand() As IDbCommand Implements IDbProjectCommandProvider.GetGetDataDbCommand

            Dim command As New SqlCommand("Project_Select")
            command.CommandType = CommandType.StoredProcedure

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        '''     Updates one or more records from the Project table
        ''' </summary>
        ''' <param name="name" />
        ''' <param name="isActive" />
        ''' <param name="projectId" />
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetUpdateDbCommand(name As String, isActive As Boolean, projectId As Int32) As IDbCommand _
            Implements IDbProjectCommandProvider.GetUpdateDbCommand

            Dim command As New SqlCommand("Project_Update")
            command.CommandType = CommandType.StoredProcedure

            If (Not name Is Nothing) Then
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.varchar, name))
            Else
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.varchar, DBNull.Value))
            End If
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@IsActive", SqlDbType.bit, isActive))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ProjectId", SqlDbType.int, projectId))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        '''     Deletes one or more records from the Project table
        ''' </summary>
        ''' <param name="projectId" />
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetDeleteDbCommand(projectId As Int32) As IDbCommand _
            Implements IDbProjectCommandProvider.GetDeleteDbCommand

            Dim command As New SqlCommand("Project_Delete")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ProjectId", SqlDbType.int, projectId))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        '''     Inserts a record into the Project table on the database.
        ''' </summary>
        ''' <param name="name" />
        ''' <param name="isActive" />
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetInsertDbCommand(name As String, isActive As Boolean) As IDbCommand _
            Implements IDbProjectCommandProvider.GetInsertDbCommand

            Dim command As New SqlCommand("Project_Insert")
            command.CommandType = CommandType.StoredProcedure

            If (Not name Is Nothing) Then
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.varchar, name))
            Else
                command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@Name", SqlDbType.varchar, DBNull.Value))
            End If
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@IsActive", SqlDbType.bit, isActive))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        '''     Function GetDataPageable returns a IDataReader populated with a subset of data from Project
        ''' </summary>
        ''' <param name="sortExpression" />
        ''' <param name="page" />
        ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetGetDataPageableDbCommand(sortExpression As String, page As Int32, pageSize As Int32) _
            As IDbCommand Implements IDbProjectCommandProvider.GetGetDataPageableDbCommand

            Dim command As New SqlCommand("Project_GetDataPageable")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar,
                                                                            sortExpression))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@pageSize", SqlDbType.Int, pageSize))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        '''     Function GetRowCount returns the row count for Project
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetGetRowCountDbCommand() As IDbCommand _
            Implements IDbProjectCommandProvider.GetGetRowCountDbCommand

            Dim command As New SqlCommand("Project_GetRowCount")
            command.CommandType = CommandType.StoredProcedure

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        '''     Function  GetDataByProjectId returns a IDataReader for Project
        ''' </summary>
        ''' <param name="projectId" />
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetGetDataByProjectIdDbCommand(projectId As Int32) As IDbCommand _
            Implements IDbProjectCommandProvider.GetGetDataByProjectIdDbCommand

            Dim command As New SqlCommand("Project_GetDataByProjectId")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@ProjectId", SqlDbType.int, projectId))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        '''     Function GetActiveData returns a IDataReader for Project with records that are marked as active
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetGetActiveDataDbCommand() As IDbCommand _
            Implements IDbProjectCommandProvider.GetGetActiveDataDbCommand

            Dim command As New SqlCommand("Project_GetActiveData")
            command.CommandType = CommandType.StoredProcedure

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        '''     Function GetActiveDataPageable returns a IDataReader populated with paged active records from Project
        ''' </summary>
        ''' <param name="sortExpression" />
        ''' <param name="page" />
        ''' <param name="pageSize" />
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetGetActiveDataPageableDbCommand(sortExpression As String, page As Int32, pageSize As Int32) _
            As IDbCommand Implements IDbProjectCommandProvider.GetGetActiveDataPageableDbCommand

            Dim command As New SqlCommand("Project_GetActiveDataPageable")
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@sortExpression", SqlDbType.varchar,
                                                                            sortExpression))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@page", SqlDbType.Int, page))
            command.Parameters.Add(SqlParameterFactory.CreateInputParameter("@PageSize", SqlDbType.Int, pageSize))

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function


        ''' <summary>
        '''     Function GetActiveDataRowCount returns the row count for Project
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetGetActiveDataRowCountDbCommand() As IDbCommand _
            Implements IDbProjectCommandProvider.GetGetActiveDataRowCountDbCommand

            Dim command As New SqlCommand("Project_GetActiveDataRowCount")
            command.CommandType = CommandType.StoredProcedure

            command.Connection = CType(_dbConnHolder.Connection, SqlConnection)
            Return command
        End Function
    End Class
End Namespace
