Select distinct ProjectId,Name, IsActive, (SELECT  count(Id) over(partition by ProjectId)
FROM            TestGroup
WHERE        (ProjectId = q1.ProjectId)) as GroupCount,  TestCount, ActiveTestCount, TestCount - ActiveTestCount as InactiveTestCount, COALESCE((Select top 1 min(CONVERT(int, RunHistory.IsValid)) over(partition by Project.ProjectId order by runhistory.RunDateTime desc) from RunHistory INNER JOIN
                         Test ON RunHistory.TestId = Test.Id INNER JOIN
                         Project ON Test.ProjectId = Project.ProjectId where Test.IsActive = 1  and Project.ProjectId = q1.ProjectId order by runhistory.RunDateTime desc),-1)  as IsValid  from (SELECT          project.Name, 
                project.IsActive, 
                project.ProjectId,
               (Select count( distinct TestGroup.Id)  from testgroup inner join test on test.GroupId = TestGroup.Id where test.ProjectId = project.ProjectId) as  GroupCount, 
                count(test.id) OVER(partition BY test.projectid) AS TestCount, 
                Sum(CASE 
                                WHEN test.isactive = 0 THEN 0 
                                ELSE 1 
                END) over (partition by project.Projectid) as ActiveTestCount
FROM            project 
LEFT OUTER JOIN test 
ON              test.projectid = project.projectid) as q1




Select top 1 RunHistory.testid, RunHistory.IsValid  From RunHistory where RunHistory.testid = 1 order by runhistory.RunDateTime desc

--Last test run  group by project
Select top 1 min(CONVERT(int, RunHistory.IsValid)) over(partition by Project.ProjectId order by runhistory.RunDateTime desc) from RunHistory INNER JOIN
                         Test ON RunHistory.TestId = Test.Id INNER JOIN
                         Project ON Test.ProjectId = Project.ProjectId where Test.IsActive = 1  and Project.ProjectId = 1 order by runhistory.RunDateTime desc



SELECT        TOP (5) RunHistory.TestId, RunHistory.IsValid
FROM            RunHistory INNER JOIN
                         Test ON RunHistory.TestId = Test.Id INNER JOIN
                         Project ON Test.ProjectId = Project.ProjectId
WHERE        (Project.ProjectId = 1)  order by runhistory.RunDateTime desc




SELECT          project.NAME, 
                project.isActive,
				project.ProjectId,  
               1 AS testcount, 
                CASE 
                                WHEN test.isactive = 0 THEN 0 
                                ELSE 1 
                END activetest,
				(Select top 1 RunHistory.IsValid  From RunHistory where RunHistory.testid = test.Id order by runhistory.RunDateTime desc) 
FROM            project 
LEFT OUTER JOIN test 
ON              test.projectid = project.projectid 
LEFT OUTER JOIN testgroup 
ON              test.groupid = testgroup.id 
AND             project.projectid = testgroup.projectid


 Select TestGroup.Name, count(test.id) over(partition by testgroup.id) as TestCount , sum( case when test.IsActive = 1 then 0 else 1 end ) over(partition by testgroup.id) as InactiveCount  From   TestGroup left outer join test on  test.GroupId = TestGroup.Id
where  test.IsActive = 1
