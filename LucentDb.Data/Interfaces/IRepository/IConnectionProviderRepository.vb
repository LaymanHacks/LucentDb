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
    Public Interface IConnectionProviderRepository
        Function GetData()  as ICollection(Of ConnectionProvider)
        Sub Update( ByVal name As String,  ByVal value As String,  ByVal id As Int32) 
        Sub Update(ByVal connectionProvider as ConnectionProvider) 
        Sub Delete( ByVal id As Int32) 
        Sub Delete(ByVal connectionProvider as ConnectionProvider) 
        Function Insert( ByVal name As String,  ByVal value As String)  as Int32
        Function Insert(ByVal connectionProvider as ConnectionProvider)  as Int32
        Function GetDataPageable( ByVal sortExpression As String,  ByVal page As Int32,  ByVal pageSize As Int32)  as ICollection(Of ConnectionProvider)
        Function GetRowCount()  as Int32
        Function GetDataById( ByVal id As Int32)  as ICollection(Of ConnectionProvider)
    End Interface 
End NameSpace
  