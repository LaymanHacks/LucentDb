Select q1.Name, q1.IsActive  From (SELECT          project.NAME, 
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
AND             project.projectid = testgroup.projectid) as q1



Select COUNT(*)  From TESTGROUP where TESTGROUP.Id  

Select top 100 * From RunHistory where testid =4 order by runhistory.RunDateTime desc


 Select TestGroup.Name, count(test.id) over(partition by testgroup.id) as TestCount , sum( case when test.IsActive = 1 then 0 else 1 end ) over(partition by testgroup.id) as InactiveCount  From   TestGroup left outer join test on  test.GroupId = TestGroup.Id
where  test.IsActive = 1
