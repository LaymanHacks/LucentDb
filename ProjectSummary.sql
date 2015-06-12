Select distinct project.Name, project.IsActive, test.groupid, max( case when test.groupid IS NULL then 0 else 1 end ) over(partition by project.projectid), count(test.id) over(partition by test.projectId) as TestCount, sum( case when test.IsActive = 1 then 0 else 1 end ) over(partition by testgroup.id)  From project inner join test on test.ProjectId = Project.ProjectId left outer join TestGroup on  test.GroupId = TestGroup.Id





 Select TestGroup.Name, count(test.id) over(partition by testgroup.id) as TestCount , sum( case when test.IsActive = 1 then 0 else 1 end ) over(partition by testgroup.id) as InactiveCount  From   TestGroup left outer join test on  test.GroupId = TestGroup.Id
where  test.IsActive = 1
