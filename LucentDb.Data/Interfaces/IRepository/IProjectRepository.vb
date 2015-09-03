Imports System
Imports System.Collections.Generic
Imports LucentDb.Domain.Entities


Namespace LucentDb.Data.Repository
    Public Interface IProjectRepository
        Function GetData() as ICollection(Of Project)
        Sub Update(name As String, isActive As Boolean, projectId As Int32)
        Sub Update(project as Project)
        Sub Delete(projectId As Int32)
        Sub Delete(project as Project)
        Function Insert(name As String, isActive As Boolean) as Int32
        Function Insert(project as Project) as Int32
        Function GetDataPageable(sortExpression As String, page As Int32, pageSize As Int32) as PagedResult(Of Project)
        Function GetDataByProjectId(projectId As Int32) as ICollection(Of Project)
        Function GetActiveData() as ICollection(Of Project)

        Function GetActiveDataPageable(sortExpression As String, page As Int32, pageSize As Int32) _
            as PagedResult(Of Project)
    End Interface
End NameSpace
