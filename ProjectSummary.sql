Select project.Name, count(test.id) over(partition by test.projectId) as TestCount, count(distinct test.groupid)  From project inner join test on test.ProjectId = Project.ProjectId left outer join TestGroup on  test.GroupId = TestGroup.Id
where project.IsActive = 1
 and test.IsActive = 1
 group by project.Name, test.projectId, test.id