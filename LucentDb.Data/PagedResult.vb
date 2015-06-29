Imports System
Imports System.Collections.Generic

Public Class PagedResult (Of T)

    Public Sub New(requestedPage As Integer, requestedPageSize As Integer, recordCount As Int64, data As ICollection(Of T))
        Dim totalPages As Int32 = CInt(Math.Ceiling(CDbl(recordCount) / requestedPageSize))
        TotalCount = recordCount
        PageCount = totalPages
        PageSize = requestedPageSize
        CurrentPage = requestedPage
        Results = data
    End Sub

    Public Property Results As ICollection(Of T)
    Public Property CurrentPage As Integer
    Public Property PageCount As Integer
    Public Property PageSize As Integer
    Public Property TotalCount As Int64
End Class