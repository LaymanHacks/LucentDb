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
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Data
Imports LucentDb.Data.DbCommandProvider
Imports LucentDb.Domain.Entities


Namespace LucentDb.Data.Repository
    <DataObject(True)>
    Public Class DbTestRepository
        Implements ITestRepository
        Implements IDisposable

        Private ReadOnly _dbTestCommandProvider As IDbTestCommandProvider
        Private _dbConnHolder As DbConnectionHolder = Nothing

        Public Sub New(dbTestCommandProvider As IDbTestCommandProvider)
            _dbTestCommandProvider = dbTestCommandProvider
            _dbConnHolder = _dbTestCommandProvider.TestDbConnectionHolder
        End Sub

        Public Function GetData() As ICollection(Of Test) Implements ITestRepository.GetData
            Dim command As IDbCommand = _dbTestCommandProvider.GetGetDataDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Test(reader.GetInt32("Id"), reader.GetInt32("TestTypeId"),
                                 reader.GetInt32("TestValueTypeId"), reader.GetInt32("ProjectId"),
                                 reader.GetNullableInt32("GroupId"), reader.GetString("Name"),
                                 reader.GetString("TestValue"), reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList
        End Function

        Public Sub Update(testTypeId As Int32, testValueTypeId As Int32, projectId As Int32,
                          groupId As Nullable(Of Int32), name As String, testValue As String, isActive As Boolean,
                          id As Int32) Implements ITestRepository.Update
            Dim command As IDbCommand = _dbTestCommandProvider.GetUpdateDbCommand(TestTypeId, TestValueTypeId, ProjectId,
                                                                                  GroupId, Name, TestValue, IsActive, Id)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Command.ExecuteNonQuery()
            _dbConnHolder.Close()
        End Sub

        Public Sub Update(test As Test) Implements ITestRepository.Update
            With Test
                Update(CInt(.TestTypeId), CInt(.TestValueTypeId), CInt(.ProjectId), .GroupId, .Name, .TestValue,
                       CBool(.IsActive), CInt(.Id))
            End With
        End Sub

        Public Sub Delete(id As Int32) Implements ITestRepository.Delete
            Dim command As IDbCommand = _dbTestCommandProvider.GetDeleteDbCommand(Id)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Command.ExecuteNonQuery()
            _dbConnHolder.Close()
        End Sub

        Public Sub Delete(test As Test) Implements ITestRepository.Delete
            With Test
                Delete(CInt(.Id))
            End With
        End Sub

        Public Function Insert(testTypeId As Int32, testValueTypeId As Int32, projectId As Int32,
                               groupId As Nullable(Of Int32), name As String, testValue As String, isActive As Boolean) _
            As Int32 Implements ITestRepository.Insert
            Dim command As IDbCommand = _dbTestCommandProvider.GetInsertDbCommand(TestTypeId, TestValueTypeId, ProjectId,
                                                                                  GroupId, Name, TestValue, IsActive)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue
        End Function

        Public Function Insert(test As Test) As Int32 Implements ITestRepository.Insert
            With Test
                Return _
                    Insert(CInt(.TestTypeId), CInt(.TestValueTypeId), CInt(.ProjectId), .GroupId, .Name, .TestValue,
                           CBool(.IsActive))
            End With
        End Function

        Public Function GetDataPageable(sortExpression As String, page As Int32, pageSize As Int32) _
            As PagedResult(Of Test) Implements ITestRepository.GetDataPageable
            Dim command As IDbCommand = _dbTestCommandProvider.GetGetDataPageableDbCommand(sortExpression, page,
                                                                                           pageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Test(reader.GetInt32("Id"), reader.GetInt32("TestTypeId"),
                                 reader.GetInt32("TestValueTypeId"), reader.GetInt32("ProjectId"),
                                 reader.GetNullableInt32("GroupId"), reader.GetString("Name"),
                                 reader.GetString("TestValue"), reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Dim totalCount As Int64 = GetRowCount()
            Dim pagedResults As PagedResult(Of Test) = New PagedResult(Of Test)(page, pageSize, totalCount, entList)
            Return pagedResults
        End Function

        Public Function GetRowCount() As Int32
            Dim command As IDbCommand = _dbTestCommandProvider.GetGetRowCountDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue
        End Function

        Public Function GetDataById(id As Int32) As ICollection(Of Test) Implements ITestRepository.GetDataById
            Dim command As IDbCommand = _dbTestCommandProvider.GetGetDataByIdDbCommand(Id)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Test(reader.GetInt32("Id"), reader.GetInt32("TestTypeId"),
                                 reader.GetInt32("TestValueTypeId"), reader.GetInt32("ProjectId"),
                                 reader.GetNullableInt32("GroupId"), reader.GetString("Name"),
                                 reader.GetString("TestValue"), reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList
        End Function

        Public Function GetActiveData() As ICollection(Of Test) Implements ITestRepository.GetActiveData
            Dim command As IDbCommand = _dbTestCommandProvider.GetGetActiveDataDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Test(reader.GetInt32("Id"), reader.GetInt32("TestTypeId"),
                                 reader.GetInt32("TestValueTypeId"), reader.GetInt32("ProjectId"),
                                 reader.GetNullableInt32("GroupId"), reader.GetString("Name"),
                                 reader.GetString("TestValue"), reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList
        End Function

        Public Function GetActiveDataPageable(sortExpression As String, page As Int32, pageSize As Int32) _
            As PagedResult(Of Test) Implements ITestRepository.GetActiveDataPageable
            Dim command As IDbCommand = _dbTestCommandProvider.GetGetActiveDataPageableDbCommand(sortExpression, page,
                                                                                                 PageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Test(reader.GetInt32("Id"), reader.GetInt32("TestTypeId"),
                                 reader.GetInt32("TestValueTypeId"), reader.GetInt32("ProjectId"),
                                 reader.GetNullableInt32("GroupId"), reader.GetString("Name"),
                                 reader.GetString("TestValue"), reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Dim totalCount As Int64 = GetActiveDataRowCount()
            Dim pagedResults As PagedResult(Of Test) = New PagedResult(Of Test)(page, pageSize, totalCount, entList)
            Return pagedResults
        End Function

        Public Function GetActiveDataRowCount() As Int32
            Dim command As IDbCommand = _dbTestCommandProvider.GetGetActiveDataRowCountDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue
        End Function

        Public Function GetDataByProjectId(projectId As Int32) As ICollection(Of Test) _
            Implements ITestRepository.GetDataByProjectId
            Dim command As IDbCommand = _dbTestCommandProvider.GetGetDataByProjectIdDbCommand(ProjectId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Test(reader.GetInt32("Id"), reader.GetInt32("TestTypeId"),
                                 reader.GetInt32("TestValueTypeId"), reader.GetInt32("ProjectId"),
                                 reader.GetNullableInt32("GroupId"), reader.GetString("Name"),
                                 reader.GetString("TestValue"), reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList
        End Function

        Public Function GetDataByProjectIdPageable(projectId As Int32, sortExpression As String, page As Int32,
                                                   pageSize As Int32) As PagedResult(Of Test) _
            Implements ITestRepository.GetDataByProjectIdPageable
            Dim command As IDbCommand = _dbTestCommandProvider.GetGetDataByProjectIdPageableDbCommand(ProjectId,
                                                                                                      sortExpression,
                                                                                                      page, pageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Test(reader.GetInt32("Id"), reader.GetInt32("TestTypeId"),
                                 reader.GetInt32("TestValueTypeId"), reader.GetInt32("ProjectId"),
                                 reader.GetNullableInt32("GroupId"), reader.GetString("Name"),
                                 reader.GetString("TestValue"), reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Dim totalCount As Int64 = GetDataByProjectIdRowCount(projectId)
            Dim pagedResults As PagedResult(Of Test) = New PagedResult(Of Test)(page, pageSize, totalCount, entList)
            Return pagedResults
        End Function

        Public Function GetDataByProjectIdRowCount(projectId As Int32) As Int32
            Dim command As IDbCommand = _dbTestCommandProvider.GetGetDataByProjectIdRowCountDbCommand(ProjectId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue
        End Function

        Public Function GetActiveDataByProjectId(projectId As Int32) As ICollection(Of Test) _
            Implements ITestRepository.GetActiveDataByProjectId
            Dim command As IDbCommand = _dbTestCommandProvider.GetGetActiveDataByProjectIdDbCommand(ProjectId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Test(reader.GetInt32("Id"), reader.GetInt32("TestTypeId"),
                                 reader.GetInt32("TestValueTypeId"), reader.GetInt32("ProjectId"),
                                 reader.GetNullableInt32("GroupId"), reader.GetString("Name"),
                                 reader.GetString("TestValue"), reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList
        End Function

        Public Function GetActiveDataByProjectIdPageable(projectId As Int32, sortExpression As String, page As Int32,
                                                         pageSize As Int32) As PagedResult(Of Test) _
            Implements ITestRepository.GetActiveDataByProjectIdPageable
            Dim command As IDbCommand = _dbTestCommandProvider.GetGetActiveDataByProjectIdPageableDbCommand(ProjectId,
                                                                                                            sortExpression,
                                                                                                            page,
                                                                                                            PageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Test(reader.GetInt32("Id"), reader.GetInt32("TestTypeId"),
                                 reader.GetInt32("TestValueTypeId"), reader.GetInt32("ProjectId"),
                                 reader.GetNullableInt32("GroupId"), reader.GetString("Name"),
                                 reader.GetString("TestValue"), reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Dim totalCount As Int64 = GetActiveDataByProjectIdRowCount(projectId)
            Dim pagedResults As PagedResult(Of Test) = New PagedResult(Of Test)(page, pageSize, totalCount, entList)
            Return pagedResults
        End Function

        Public Function GetActiveDataByProjectIdRowCount(projectId As Int32) As Int32
            Dim command As IDbCommand = _dbTestCommandProvider.GetGetActiveDataByProjectIdRowCountDbCommand(ProjectId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue
        End Function

        Public Function GetDataByGroupId(groupId As Int32) As ICollection(Of Test) _
            Implements ITestRepository.GetDataByGroupId
            Dim command As IDbCommand = _dbTestCommandProvider.GetGetDataByGroupIdDbCommand(GroupId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Test(reader.GetInt32("Id"), reader.GetInt32("TestTypeId"),
                                 reader.GetInt32("TestValueTypeId"), reader.GetInt32("ProjectId"),
                                 reader.GetNullableInt32("GroupId"), reader.GetString("Name"),
                                 reader.GetString("TestValue"), reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList
        End Function

        Public Function GetDataByGroupIdPageable(groupId As Int32, sortExpression As String, page As Int32,
                                                 pageSize As Int32) As PagedResult(Of Test) _
            Implements ITestRepository.GetDataByGroupIdPageable
            Dim command As IDbCommand = _dbTestCommandProvider.GetGetDataByGroupIdPageableDbCommand(GroupId,
                                                                                                    sortExpression, page,
                                                                                                    pageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Test(reader.GetInt32("Id"), reader.GetInt32("TestTypeId"),
                                 reader.GetInt32("TestValueTypeId"), reader.GetInt32("ProjectId"),
                                 reader.GetNullableInt32("GroupId"), reader.GetString("Name"),
                                 reader.GetString("TestValue"), reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Dim totalCount As Int64 = GetDataByGroupIdRowCount(groupId)
            Dim pagedResults As PagedResult(Of Test) = New PagedResult(Of Test)(page, pageSize, totalCount, entList)
            Return pagedResults
        End Function

        Public Function GetDataByGroupIdRowCount(groupId As Int32) As Int32
            Dim command As IDbCommand = _dbTestCommandProvider.GetGetDataByGroupIdRowCountDbCommand(GroupId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue
        End Function

        Public Function GetActiveDataByGroupId(groupId As Int32) As ICollection(Of Test) _
            Implements ITestRepository.GetActiveDataByGroupId
            Dim command As IDbCommand = _dbTestCommandProvider.GetGetActiveDataByGroupIdDbCommand(GroupId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Test(reader.GetInt32("Id"), reader.GetInt32("TestTypeId"),
                                 reader.GetInt32("TestValueTypeId"), reader.GetInt32("ProjectId"),
                                 reader.GetNullableInt32("GroupId"), reader.GetString("Name"),
                                 reader.GetString("TestValue"), reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList
        End Function

        Public Function GetActiveDataByGroupIdPageable(groupId As Int32, sortExpression As String, page As Int32,
                                                       pageSize As Int32) As PagedResult(Of Test) _
            Implements ITestRepository.GetActiveDataByGroupIdPageable
            Dim command As IDbCommand = _dbTestCommandProvider.GetGetActiveDataByGroupIdPageableDbCommand(GroupId,
                                                                                                          sortExpression,
                                                                                                          page, PageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Test(reader.GetInt32("Id"), reader.GetInt32("TestTypeId"),
                                 reader.GetInt32("TestValueTypeId"), reader.GetInt32("ProjectId"),
                                 reader.GetNullableInt32("GroupId"), reader.GetString("Name"),
                                 reader.GetString("TestValue"), reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Dim totalCount As Int64 = GetActiveDataByGroupIdRowCount(groupId)
            Dim pagedResults As PagedResult(Of Test) = New PagedResult(Of Test)(page, pageSize, totalCount, entList)
            Return pagedResults
        End Function

        Public Function GetActiveDataByGroupIdRowCount(groupId As Int32) As Int32
            Dim command As IDbCommand = _dbTestCommandProvider.GetGetActiveDataByGroupIdRowCountDbCommand(GroupId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue
        End Function

        Public Function GetDataByTestTypeId(testTypeId As Int32) As ICollection(Of Test) _
            Implements ITestRepository.GetDataByTestTypeId
            Dim command As IDbCommand = _dbTestCommandProvider.GetGetDataByTestTypeIdDbCommand(TestTypeId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Test(reader.GetInt32("Id"), reader.GetInt32("TestTypeId"),
                                 reader.GetInt32("TestValueTypeId"), reader.GetInt32("ProjectId"),
                                 reader.GetNullableInt32("GroupId"), reader.GetString("Name"),
                                 reader.GetString("TestValue"), reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList
        End Function

        Public Function GetDataByTestTypeIdPageable(testTypeId As Int32, sortExpression As String, page As Int32,
                                                    pageSize As Int32) As PagedResult(Of Test) _
            Implements ITestRepository.GetDataByTestTypeIdPageable
            Dim command As IDbCommand = _dbTestCommandProvider.GetGetDataByTestTypeIdPageableDbCommand(TestTypeId,
                                                                                                       sortExpression,
                                                                                                       page, pageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Test(reader.GetInt32("Id"), reader.GetInt32("TestTypeId"),
                                 reader.GetInt32("TestValueTypeId"), reader.GetInt32("ProjectId"),
                                 reader.GetNullableInt32("GroupId"), reader.GetString("Name"),
                                 reader.GetString("TestValue"), reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Dim totalCount As Int64 = GetDataByTestTypeIdRowCount(testTypeId)
            Dim pagedResults As PagedResult(Of Test) = New PagedResult(Of Test)(page, pageSize, totalCount, entList)
            Return pagedResults
        End Function

        Public Function GetDataByTestTypeIdRowCount(testTypeId As Int32) As Int32
            Dim command As IDbCommand = _dbTestCommandProvider.GetGetDataByTestTypeIdRowCountDbCommand(TestTypeId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue
        End Function

        Public Function GetActiveDataByTestTypeId(testTypeId As Int32) As ICollection(Of Test) _
            Implements ITestRepository.GetActiveDataByTestTypeId
            Dim command As IDbCommand = _dbTestCommandProvider.GetGetActiveDataByTestTypeIdDbCommand(TestTypeId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Test(reader.GetInt32("Id"), reader.GetInt32("TestTypeId"),
                                 reader.GetInt32("TestValueTypeId"), reader.GetInt32("ProjectId"),
                                 reader.GetNullableInt32("GroupId"), reader.GetString("Name"),
                                 reader.GetString("TestValue"), reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList
        End Function

        Public Function GetActiveDataByTestTypeIdPageable(testTypeId As Int32, sortExpression As String, page As Int32,
                                                          pageSize As Int32) As PagedResult(Of Test) _
            Implements ITestRepository.GetActiveDataByTestTypeIdPageable
            Dim command As IDbCommand = _dbTestCommandProvider.GetGetActiveDataByTestTypeIdPageableDbCommand(TestTypeId,
                                                                                                             sortExpression,
                                                                                                             page,
                                                                                                             PageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Test(reader.GetInt32("Id"), reader.GetInt32("TestTypeId"),
                                 reader.GetInt32("TestValueTypeId"), reader.GetInt32("ProjectId"),
                                 reader.GetNullableInt32("GroupId"), reader.GetString("Name"),
                                 reader.GetString("TestValue"), reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Dim totalCount As Int64 = GetActiveDataByTestTypeIdRowCount(testTypeId)
            Dim pagedResults As PagedResult(Of Test) = New PagedResult(Of Test)(page, pageSize, totalCount, entList)
            Return pagedResults
        End Function

        Public Function GetActiveDataByTestTypeIdRowCount(testTypeId As Int32) As Int32
            Dim command As IDbCommand = _dbTestCommandProvider.GetGetActiveDataByTestTypeIdRowCountDbCommand(TestTypeId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue
        End Function

        Public Function GetDataByTestValueTypeId(testValueTypeId As Int32) As ICollection(Of Test) _
            Implements ITestRepository.GetDataByTestValueTypeId
            Dim command As IDbCommand = _dbTestCommandProvider.GetGetDataByTestValueTypeIdDbCommand(TestValueTypeId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Test(reader.GetInt32("Id"), reader.GetInt32("TestTypeId"),
                                 reader.GetInt32("TestValueTypeId"), reader.GetInt32("ProjectId"),
                                 reader.GetNullableInt32("GroupId"), reader.GetString("Name"),
                                 reader.GetString("TestValue"), reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList
        End Function

        Public Function GetDataByTestValueTypeIdPageable(testValueTypeId As Int32, sortExpression As String,
                                                         page As Int32, pageSize As Int32) As PagedResult(Of Test) _
            Implements ITestRepository.GetDataByTestValueTypeIdPageable
            Dim command As IDbCommand =
                    _dbTestCommandProvider.GetGetDataByTestValueTypeIdPageableDbCommand(TestValueTypeId, sortExpression,
                                                                                        page, pageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Test(reader.GetInt32("Id"), reader.GetInt32("TestTypeId"),
                                 reader.GetInt32("TestValueTypeId"), reader.GetInt32("ProjectId"),
                                 reader.GetNullableInt32("GroupId"), reader.GetString("Name"),
                                 reader.GetString("TestValue"), reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Dim totalCount As Int64 = GetDataByTestValueTypeIdRowCount(testValueTypeId)
            Dim pagedResults As PagedResult(Of Test) = New PagedResult(Of Test)(page, pageSize, totalCount, entList)
            Return pagedResults
        End Function

        Public Function GetDataByTestValueTypeIdRowCount(testValueTypeId As Int32) As Int32
            Dim command As IDbCommand =
                    _dbTestCommandProvider.GetGetDataByTestValueTypeIdRowCountDbCommand(TestValueTypeId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue
        End Function

        Public Function GetActiveDataByTestValueTypeId(testValueTypeId As Int32) As ICollection(Of Test) _
            Implements ITestRepository.GetActiveDataByTestValueTypeId
            Dim command As IDbCommand =
                    _dbTestCommandProvider.GetGetActiveDataByTestValueTypeIdDbCommand(TestValueTypeId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Test(reader.GetInt32("Id"), reader.GetInt32("TestTypeId"),
                                 reader.GetInt32("TestValueTypeId"), reader.GetInt32("ProjectId"),
                                 reader.GetNullableInt32("GroupId"), reader.GetString("Name"),
                                 reader.GetString("TestValue"), reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Return entList
        End Function

        Public Function GetActiveDataByTestValueTypeIdPageable(testValueTypeId As Int32, sortExpression As String,
                                                               page As Int32, pageSize As Int32) As PagedResult(Of Test) _
            Implements ITestRepository.GetActiveDataByTestValueTypeIdPageable
            Dim command As IDbCommand =
                    _dbTestCommandProvider.GetGetActiveDataByTestValueTypeIdPageableDbCommand(TestValueTypeId,
                                                                                              sortExpression, page,
                                                                                              PageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim entList As New Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                Dim _
                    tempEntity As _
                        New Test(reader.GetInt32("Id"), reader.GetInt32("TestTypeId"),
                                 reader.GetInt32("TestValueTypeId"), reader.GetInt32("ProjectId"),
                                 reader.GetNullableInt32("GroupId"), reader.GetString("Name"),
                                 reader.GetString("TestValue"), reader.GetBoolean("IsActive"))
                entList.Add(tempEntity)
            Loop
            reader.Close()
            Dim totalCount As Int64 = GetActiveDataByTestValueTypeIdRowCount(testValueTypeId)
            Dim pagedResults As PagedResult(Of Test) = New PagedResult(Of Test)(page, pageSize, totalCount, entList)
            Return pagedResults
        End Function

        Public Function GetActiveDataByTestValueTypeIdRowCount(testValueTypeId As Int32) As Int32
            Dim command As IDbCommand =
                    _dbTestCommandProvider.GetGetActiveDataByTestValueTypeIdRowCountDbCommand(TestValueTypeId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
            Dim returnValue As Int32 = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue
        End Function


#Region "IDisposable Support"

        Private disposedValue As Boolean

        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    Select Case _dbConnHolder.Connection.State
                        Case ConnectionState.Open
                            _dbConnHolder.Close()
                    End Select
                    _dbConnHolder = Nothing
                End If

            End If
            Me.disposedValue = True
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub

#End Region
    End Class
End Namespace
