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
Imports LucentDb.Data
Imports LucentDb.Domain.Entities

  
 Namespace LucentDb.Data.Repository     
    Public Interface ITestTypeRepository
        Function GetData()  as ICollection(Of TestType)
        Sub Update( ByVal name As String,  ByVal testValidatorType As String,  ByVal isActive As Boolean,  ByVal id As Int32) 
        Sub Update(ByVal testType as TestType) 
        Sub Delete( ByVal id As Int32) 
        Sub Delete(ByVal testType as TestType) 
        Function Insert( ByVal name As String,  ByVal testValidatorType As String,  ByVal isActive As Boolean)  as Int32
        Function Insert(ByVal testType as TestType)  as Int32
        Function GetDataPageable( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as ICollection(Of TestType)
        Function GetRowCount()  as Int32
        Function GetDataById( ByVal id As Int32)  as ICollection(Of TestType)
        Function GetActiveData()  as ICollection(Of TestType)
        Function GetActiveDataPageable( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as ICollection(Of TestType)
        Function GetActiveDataRowCount()  as Int32
    End Interface 
End NameSpace
  