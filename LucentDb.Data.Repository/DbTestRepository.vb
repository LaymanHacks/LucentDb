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
Imports System.Collections.Generic
Imports LucentDb.Data
Imports LucentDb.Domain.Entities
Imports LucentDb.Data.DbCommandProvider
Imports System.Collections.ObjectModel

  
Namespace LucentDb.Data.Repository    
    
    <Global.System.ComponentModel.DataObjectAttribute(true)>  _
    Public Class DbTestRepository
        Implements ITestRepository
        Implements IDisposable

        Private ReadOnly _dbTestCommandProvider As IDbTestCommandProvider
        Private _dbConnHolder As DbConnectionHolder = Nothing

        Public Sub New(ByVal dbTestCommandProvider As IDbTestCommandProvider)
            _dbTestCommandProvider = dbTestCommandProvider
            _dbConnHolder =_dbTestCommandProvider.TestDbConnectionHolder
        End Sub

      
    ''' <summary>
    ''' Selects one or more records from the Test table 
    ''' </summary>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, true)> _ 
    Public Function GetData()  as ICollection(Of Test) Implements ITestRepository.GetData
        Dim command As IDbCommand = _dbTestCommandProvider.GetGetDataDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Test( reader.GetInt32("Id"),  reader.GetInt32("TestTypeId"),  reader.GetNullableInt32("ProjectId"),  reader.GetNullableInt32("GroupId"),  reader.GetString("Name") ,  reader.GetString("TestValue") ,  reader.GetBoolean("IsActive"))
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Updates one or more records from the Test table 
    ''' </summary>
   ''' <param name="TestTypeId"></param>
   ''' <param name="ProjectId"></param>
   ''' <param name="GroupId"></param>
   ''' <param name="Name"></param>
   ''' <param name="TestValue"></param>
   ''' <param name="IsActive"></param>
   ''' <param name="Id"></param>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Update, true)> _ 
    Public Sub Update( ByVal testTypeId As Int32,  ByVal projectId As  Nullable(Of Int32) ,  ByVal groupId As  Nullable(Of Int32) ,  ByVal name As String,  ByVal testValue As String,  ByVal isActive As Boolean,  ByVal id As Int32)  Implements ITestRepository.Update
        Dim command As IDbCommand = _dbTestCommandProvider.GetUpdateDbCommand(TestTypeId, ProjectId, GroupId, Name, TestValue, IsActive, Id)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
          Command.ExecuteNonQuery
            _dbConnHolder.Close()
    End Sub
  
    ''' <summary>
    ''' Updates one or more records from the Test table 
    ''' </summary>
    ''' <param name="Test"></param>
    ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Update, False)> _ 
    Public Sub Update(ByVal test as Test)  Implements ITestRepository.Update
             With Test
Update( CInt(.TestTypeId), .ProjectId, .GroupId, .Name, .TestValue,  CBool(.IsActive),  CInt(.Id))
       End With

    End Sub
  
    ''' <summary>
    ''' Deletes one or more records from the Test table 
    ''' </summary>
   ''' <param name="Id"></param>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Delete, true)> _ 
    Public Sub Delete( ByVal id As Int32)  Implements ITestRepository.Delete
        Dim command As IDbCommand = _dbTestCommandProvider.GetDeleteDbCommand(Id)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
          Command.ExecuteNonQuery
            _dbConnHolder.Close()
    End Sub
  
    ''' <summary>
    ''' Deletes one or more records from the Test table 
    ''' </summary>
    ''' <param name="Test"></param>
    ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Delete, False)> _ 
    Public Sub Delete(ByVal test as Test)  Implements ITestRepository.Delete
             With Test
Delete( CInt(.Id))
       End With

    End Sub
  
    ''' <summary>
    ''' Inserts an entity of Test into the database.
    ''' </summary>
   ''' <param name="TestTypeId"></param>
   ''' <param name="ProjectId"></param>
   ''' <param name="GroupId"></param>
   ''' <param name="Name"></param>
   ''' <param name="TestValue"></param>
   ''' <param name="IsActive"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Insert, true)> _ 
    Public Function Insert( ByVal testTypeId As Int32,  ByVal projectId As  Nullable(Of Int32) ,  ByVal groupId As  Nullable(Of Int32) ,  ByVal name As String,  ByVal testValue As String,  ByVal isActive As Boolean)  as Int32 Implements ITestRepository.Insert
        Dim command As IDbCommand = _dbTestCommandProvider.GetInsertDbCommand(TestTypeId, ProjectId, GroupId, Name, TestValue, IsActive)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim returnValue As Int32  = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue 

    End Function
  
    ''' <summary>
    ''' Inserts an entity of Test into the database.
    ''' </summary>
    ''' <param name="Test"></param>
    ''' <returns></returns>
    ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Insert, False)> _ 
    Public Function Insert(ByVal test as Test)  as Int32 Implements ITestRepository.Insert
             With Test
 Return Insert( CInt(.TestTypeId), .ProjectId, .GroupId, .Name, .TestValue,  CBool(.IsActive))
       End With

    End Function
  
    ''' <summary>
    ''' Function GetDataPageable returns a IDataReader populated with a subset of data from Test
    ''' </summary>
   ''' <param name="sortExpression"></param>
   ''' <param name="page"></param>
   ''' <param name="pageSize"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetDataPageable( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as ICollection(Of Test) Implements ITestRepository.GetDataPageable
        Dim command As IDbCommand = _dbTestCommandProvider.GetGetDataPageableDbCommand(sortExpression, page, pageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Test( reader.GetInt32("Id"),  reader.GetInt32("TestTypeId"),  reader.GetNullableInt32("ProjectId"),  reader.GetNullableInt32("GroupId"),  reader.GetString("Name") ,  reader.GetString("TestValue") ,  reader.GetBoolean("IsActive"))
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetRowCount returns the row count for Test
    ''' </summary>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetRowCount()  as Int32 Implements ITestRepository.GetRowCount
        Dim command As IDbCommand = _dbTestCommandProvider.GetGetRowCountDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim returnValue As Int32  = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue 

    End Function
  
    ''' <summary>
    ''' Function  GetDataById returns a IDataReader for Test
    ''' </summary>
   ''' <param name="Id"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetDataById( ByVal id As Int32)  as ICollection(Of Test) Implements ITestRepository.GetDataById
        Dim command As IDbCommand = _dbTestCommandProvider.GetGetDataByIdDbCommand(Id)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Test( reader.GetInt32("Id"),  reader.GetInt32("TestTypeId"),  reader.GetNullableInt32("ProjectId"),  reader.GetNullableInt32("GroupId"),  reader.GetString("Name") ,  reader.GetString("TestValue") ,  reader.GetBoolean("IsActive"))
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetActiveData returns a TestList for Test with records that are marked as active
    ''' </summary>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, true)> _ 
    Public Function GetActiveData()  as ICollection(Of Test) Implements ITestRepository.GetActiveData
        Dim command As IDbCommand = _dbTestCommandProvider.GetGetActiveDataDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Test( reader.GetInt32("Id"),  reader.GetInt32("TestTypeId"),  reader.GetNullableInt32("ProjectId"),  reader.GetNullableInt32("GroupId"),  reader.GetString("Name") ,  reader.GetString("TestValue") ,  reader.GetBoolean("IsActive"))
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetActiveDataPageable returns a TestList populated with paged active records from Test
    ''' </summary>
   ''' <param name="sortExpression"></param>
   ''' <param name="page"></param>
   ''' <param name="PageSize"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetActiveDataPageable( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as ICollection(Of Test) Implements ITestRepository.GetActiveDataPageable
        Dim command As IDbCommand = _dbTestCommandProvider.GetGetActiveDataPageableDbCommand(sortExpression, page, PageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Test( reader.GetInt32("Id"),  reader.GetInt32("TestTypeId"),  reader.GetNullableInt32("ProjectId"),  reader.GetNullableInt32("GroupId"),  reader.GetString("Name") ,  reader.GetString("TestValue") ,  reader.GetBoolean("IsActive"))
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetActiveDataRowCount returns the row count for Test
    ''' </summary>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetActiveDataRowCount()  as Int32 Implements ITestRepository.GetActiveDataRowCount
        Dim command As IDbCommand = _dbTestCommandProvider.GetGetActiveDataRowCountDbCommand()
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim returnValue As Int32  = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue 

    End Function
  
    ''' <summary>
    ''' Function GetDataByProjectId returns a IDataReader for Test
    ''' </summary>
   ''' <param name="ProjectId"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetDataByProjectId( ByVal projectId As Int32)  as ICollection(Of Test) Implements ITestRepository.GetDataByProjectId
        Dim command As IDbCommand = _dbTestCommandProvider.GetGetDataByProjectIdDbCommand(ProjectId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Test( reader.GetInt32("Id"),  reader.GetInt32("TestTypeId"),  reader.GetNullableInt32("ProjectId"),  reader.GetNullableInt32("GroupId"),  reader.GetString("Name") ,  reader.GetString("TestValue") ,  reader.GetBoolean("IsActive"))
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetDataByProjectIdPageable returns a IDataReader populated with a subset of data from Test
    ''' </summary>
   ''' <param name="ProjectId"></param>
   ''' <param name="sortExpression"></param>
   ''' <param name="page"></param>
   ''' <param name="pageSize"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetDataByProjectIdPageable( ByVal projectId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as ICollection(Of Test) Implements ITestRepository.GetDataByProjectIdPageable
        Dim command As IDbCommand = _dbTestCommandProvider.GetGetDataByProjectIdPageableDbCommand(ProjectId, sortExpression, page, pageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Test( reader.GetInt32("Id"),  reader.GetInt32("TestTypeId"),  reader.GetNullableInt32("ProjectId"),  reader.GetNullableInt32("GroupId"),  reader.GetString("Name") ,  reader.GetString("TestValue") ,  reader.GetBoolean("IsActive"))
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetRowCount returns the row count for Test
    ''' </summary>
   ''' <param name="ProjectId"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetDataByProjectIdRowCount( ByVal projectId As Int32)  as Int32 Implements ITestRepository.GetDataByProjectIdRowCount
        Dim command As IDbCommand = _dbTestCommandProvider.GetGetDataByProjectIdRowCountDbCommand(ProjectId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim returnValue As Int32  = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue 

    End Function
  
    ''' <summary>
    ''' Function GetActiveDataByProjectId returns a TestList for Test
    ''' </summary>
   ''' <param name="ProjectId"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetActiveDataByProjectId( ByVal projectId As Int32)  as ICollection(Of Test) Implements ITestRepository.GetActiveDataByProjectId
        Dim command As IDbCommand = _dbTestCommandProvider.GetGetActiveDataByProjectIdDbCommand(ProjectId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Test( reader.GetInt32("Id"),  reader.GetInt32("TestTypeId"),  reader.GetNullableInt32("ProjectId"),  reader.GetNullableInt32("GroupId"),  reader.GetString("Name") ,  reader.GetString("TestValue") ,  reader.GetBoolean("IsActive"))
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetActiveDataByProjectIdPageable returns a TestList populated with a subset of data from Test
    ''' </summary>
   ''' <param name="ProjectId"></param>
   ''' <param name="sortExpression"></param>
   ''' <param name="page"></param>
   ''' <param name="PageSize"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetActiveDataByProjectIdPageable( ByVal projectId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as ICollection(Of Test) Implements ITestRepository.GetActiveDataByProjectIdPageable
        Dim command As IDbCommand = _dbTestCommandProvider.GetGetActiveDataByProjectIdPageableDbCommand(ProjectId, sortExpression, page, PageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Test( reader.GetInt32("Id"),  reader.GetInt32("TestTypeId"),  reader.GetNullableInt32("ProjectId"),  reader.GetNullableInt32("GroupId"),  reader.GetString("Name") ,  reader.GetString("TestValue") ,  reader.GetBoolean("IsActive"))
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetRowCount returns the row count for Test
    ''' </summary>
   ''' <param name="ProjectId"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetActiveDataByProjectIdRowCount( ByVal projectId As Int32)  as Int32 Implements ITestRepository.GetActiveDataByProjectIdRowCount
        Dim command As IDbCommand = _dbTestCommandProvider.GetGetActiveDataByProjectIdRowCountDbCommand(ProjectId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim returnValue As Int32  = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue 

    End Function
  
    ''' <summary>
    ''' Function GetDataByGroupId returns a IDataReader for Test
    ''' </summary>
   ''' <param name="GroupId"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetDataByGroupId( ByVal groupId As Int32)  as ICollection(Of Test) Implements ITestRepository.GetDataByGroupId
        Dim command As IDbCommand = _dbTestCommandProvider.GetGetDataByGroupIdDbCommand(GroupId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Test( reader.GetInt32("Id"),  reader.GetInt32("TestTypeId"),  reader.GetNullableInt32("ProjectId"),  reader.GetNullableInt32("GroupId"),  reader.GetString("Name") ,  reader.GetString("TestValue") ,  reader.GetBoolean("IsActive"))
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetDataByGroupIdPageable returns a IDataReader populated with a subset of data from Test
    ''' </summary>
   ''' <param name="GroupId"></param>
   ''' <param name="sortExpression"></param>
   ''' <param name="page"></param>
   ''' <param name="pageSize"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetDataByGroupIdPageable( ByVal groupId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as ICollection(Of Test) Implements ITestRepository.GetDataByGroupIdPageable
        Dim command As IDbCommand = _dbTestCommandProvider.GetGetDataByGroupIdPageableDbCommand(GroupId, sortExpression, page, pageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Test( reader.GetInt32("Id"),  reader.GetInt32("TestTypeId"),  reader.GetNullableInt32("ProjectId"),  reader.GetNullableInt32("GroupId"),  reader.GetString("Name") ,  reader.GetString("TestValue") ,  reader.GetBoolean("IsActive"))
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetRowCount returns the row count for Test
    ''' </summary>
   ''' <param name="GroupId"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetDataByGroupIdRowCount( ByVal groupId As Int32)  as Int32 Implements ITestRepository.GetDataByGroupIdRowCount
        Dim command As IDbCommand = _dbTestCommandProvider.GetGetDataByGroupIdRowCountDbCommand(GroupId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim returnValue As Int32  = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue 

    End Function
  
    ''' <summary>
    ''' Function GetActiveDataByGroupId returns a TestList for Test
    ''' </summary>
   ''' <param name="GroupId"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetActiveDataByGroupId( ByVal groupId As Int32)  as ICollection(Of Test) Implements ITestRepository.GetActiveDataByGroupId
        Dim command As IDbCommand = _dbTestCommandProvider.GetGetActiveDataByGroupIdDbCommand(GroupId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Test( reader.GetInt32("Id"),  reader.GetInt32("TestTypeId"),  reader.GetNullableInt32("ProjectId"),  reader.GetNullableInt32("GroupId"),  reader.GetString("Name") ,  reader.GetString("TestValue") ,  reader.GetBoolean("IsActive"))
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetActiveDataByGroupIdPageable returns a TestList populated with a subset of data from Test
    ''' </summary>
   ''' <param name="GroupId"></param>
   ''' <param name="sortExpression"></param>
   ''' <param name="page"></param>
   ''' <param name="PageSize"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetActiveDataByGroupIdPageable( ByVal groupId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as ICollection(Of Test) Implements ITestRepository.GetActiveDataByGroupIdPageable
        Dim command As IDbCommand = _dbTestCommandProvider.GetGetActiveDataByGroupIdPageableDbCommand(GroupId, sortExpression, page, PageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Test( reader.GetInt32("Id"),  reader.GetInt32("TestTypeId"),  reader.GetNullableInt32("ProjectId"),  reader.GetNullableInt32("GroupId"),  reader.GetString("Name") ,  reader.GetString("TestValue") ,  reader.GetBoolean("IsActive"))
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetRowCount returns the row count for Test
    ''' </summary>
   ''' <param name="GroupId"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetActiveDataByGroupIdRowCount( ByVal groupId As Int32)  as Int32 Implements ITestRepository.GetActiveDataByGroupIdRowCount
        Dim command As IDbCommand = _dbTestCommandProvider.GetGetActiveDataByGroupIdRowCountDbCommand(GroupId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim returnValue As Int32  = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue 

    End Function
  
    ''' <summary>
    ''' Function GetDataByTestTypeId returns a IDataReader for Test
    ''' </summary>
   ''' <param name="TestTypeId"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetDataByTestTypeId( ByVal testTypeId As Int32)  as ICollection(Of Test) Implements ITestRepository.GetDataByTestTypeId
        Dim command As IDbCommand = _dbTestCommandProvider.GetGetDataByTestTypeIdDbCommand(TestTypeId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Test( reader.GetInt32("Id"),  reader.GetInt32("TestTypeId"),  reader.GetNullableInt32("ProjectId"),  reader.GetNullableInt32("GroupId"),  reader.GetString("Name") ,  reader.GetString("TestValue") ,  reader.GetBoolean("IsActive"))
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetDataByTestTypeIdPageable returns a IDataReader populated with a subset of data from Test
    ''' </summary>
   ''' <param name="TestTypeId"></param>
   ''' <param name="sortExpression"></param>
   ''' <param name="page"></param>
   ''' <param name="pageSize"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetDataByTestTypeIdPageable( ByVal testTypeId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as ICollection(Of Test) Implements ITestRepository.GetDataByTestTypeIdPageable
        Dim command As IDbCommand = _dbTestCommandProvider.GetGetDataByTestTypeIdPageableDbCommand(TestTypeId, sortExpression, page, pageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Test( reader.GetInt32("Id"),  reader.GetInt32("TestTypeId"),  reader.GetNullableInt32("ProjectId"),  reader.GetNullableInt32("GroupId"),  reader.GetString("Name") ,  reader.GetString("TestValue") ,  reader.GetBoolean("IsActive"))
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetRowCount returns the row count for Test
    ''' </summary>
   ''' <param name="TestTypeId"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetDataByTestTypeIdRowCount( ByVal testTypeId As Int32)  as Int32 Implements ITestRepository.GetDataByTestTypeIdRowCount
        Dim command As IDbCommand = _dbTestCommandProvider.GetGetDataByTestTypeIdRowCountDbCommand(TestTypeId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim returnValue As Int32  = Convert.ToInt32(Command.ExecuteScalar())
            _dbConnHolder.Close()
            Return returnValue 

    End Function
  
    ''' <summary>
    ''' Function GetActiveDataByTestTypeId returns a TestList for Test
    ''' </summary>
   ''' <param name="TestTypeId"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetActiveDataByTestTypeId( ByVal testTypeId As Int32)  as ICollection(Of Test) Implements ITestRepository.GetActiveDataByTestTypeId
        Dim command As IDbCommand = _dbTestCommandProvider.GetGetActiveDataByTestTypeIdDbCommand(TestTypeId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Test( reader.GetInt32("Id"),  reader.GetInt32("TestTypeId"),  reader.GetNullableInt32("ProjectId"),  reader.GetNullableInt32("GroupId"),  reader.GetString("Name") ,  reader.GetString("TestValue") ,  reader.GetBoolean("IsActive"))
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetActiveDataByTestTypeIdPageable returns a TestList populated with a subset of data from Test
    ''' </summary>
   ''' <param name="TestTypeId"></param>
   ''' <param name="sortExpression"></param>
   ''' <param name="page"></param>
   ''' <param name="PageSize"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetActiveDataByTestTypeIdPageable( ByVal testTypeId As Int32,  ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as ICollection(Of Test) Implements ITestRepository.GetActiveDataByTestTypeIdPageable
        Dim command As IDbCommand = _dbTestCommandProvider.GetGetActiveDataByTestTypeIdPageableDbCommand(TestTypeId, sortExpression, page, PageSize)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim entList as new Collection(Of Test)
            Dim reader As New SafeDataReader(command.ExecuteReader(CommandBehavior.CloseConnection))
            Do While (reader.Read())
                 Dim tempEntity As New Test( reader.GetInt32("Id"),  reader.GetInt32("TestTypeId"),  reader.GetNullableInt32("ProjectId"),  reader.GetNullableInt32("GroupId"),  reader.GetString("Name") ,  reader.GetString("TestValue") ,  reader.GetBoolean("IsActive"))
                 entList.Add(tempEntity)
            Loop
            reader.Close
            Return entList
    
    End Function
  
    ''' <summary>
    ''' Function GetRowCount returns the row count for Test
    ''' </summary>
   ''' <param name="TestTypeId"></param>''' <returns></returns>
   ''' <remarks></remarks> 
  <Global.System.ComponentModel.DataObjectMethodAttribute(Global.System.ComponentModel.DataObjectMethodType.Select, false)> _ 
    Public Function GetActiveDataByTestTypeIdRowCount( ByVal testTypeId As Int32)  as Int32 Implements ITestRepository.GetActiveDataByTestTypeIdRowCount
        Dim command As IDbCommand = _dbTestCommandProvider.GetGetActiveDataByTestTypeIdRowCountDbCommand(TestTypeId)
            command.Connection = _dbConnHolder.Connection
            _dbConnHolder.Open()
              Dim returnValue As Int32  = Convert.ToInt32(Command.ExecuteScalar())
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
End NameSpace
