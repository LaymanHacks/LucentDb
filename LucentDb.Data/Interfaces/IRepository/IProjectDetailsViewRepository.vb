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
Imports LucentDb.Domain.Entities


Namespace LucentDb.Data.Repository
    Public Interface IProjectDetailsViewRepository
        Function GetData() as ICollection(Of ProjectDetailsView)

        Function GetDataPageable(sortExpression As String, page As Int32, pageSize As Int32) _
            as PagedResult(Of ProjectDetailsView)

        Function GetActiveData() as ICollection(Of ProjectDetailsView)

        Function GetActiveDataPageable(sortExpression As String, page As Int32, pageSize As Int32) _
            as PagedResult(Of ProjectDetailsView)
    End Interface
End NameSpace
