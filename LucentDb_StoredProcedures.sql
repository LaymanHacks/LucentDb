
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AssertType_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[AssertType_Select]

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [Name]
FROM [AssertType]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[AssertType_Select]

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [Name]
FROM [AssertType]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AssertType_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[AssertType_Update]
(
@Name varchar(50), 
@Id int
  )

  AS
   SET NOCOUNT ON;
UPDATE [AssertType] SET [Name]=@Name
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[AssertType_Update]
(
@Name varchar(50), 
@Id int
  )

  AS
   SET NOCOUNT ON;
   UPDATE [AssertType] SET [Name]=@Name
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AssertType_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[AssertType_Delete]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
DELETE 
FROM [AssertType]
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[AssertType_Delete]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
   DELETE 
FROM [AssertType]
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AssertType_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[AssertType_Insert]
(
@Name varchar(50)
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [AssertType] ([Name]) VALUES (@Name);SELECT SCOPE_IDENTITY();'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[AssertType_Insert]
(
@Name varchar(50)
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [AssertType] ([Name]) VALUES (@Name);SELECT SCOPE_IDENTITY();'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AssertType_GetDataPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[AssertType_GetDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''Id'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [Name] FROM (
    SELECT [Id], [Name],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM AssertType) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[AssertType_GetDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''Id'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [Name] FROM (
    SELECT [Id], [Name],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM AssertType) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AssertType_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[AssertType_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM AssertType'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[AssertType_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM AssertType'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AssertType_GetDataById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[AssertType_GetDataById]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [Name]
FROM [AssertType]
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[AssertType_GetDataById]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [Name]
FROM [AssertType]
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Connection_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Connection_Select]

  AS
   SET NOCOUNT ON;
SELECT 
     [ConnectionId], [Name], [ConnectionString], [IsActive]
FROM [Connection]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Connection_Select]

  AS
   SET NOCOUNT ON;
   SELECT 
     [ConnectionId], [Name], [ConnectionString], [IsActive]
FROM [Connection]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Connection_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Connection_Update]
(
@Name varchar(50), 
@ConnectionString varchar(500), 
@IsActive bit, 
@ConnectionId int
  )

  AS
   SET NOCOUNT ON;
UPDATE [Connection] SET [Name]=@Name
     , [ConnectionString]=@ConnectionString
     , [IsActive]=@IsActive
WHERE [ConnectionId]=@ConnectionId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Connection_Update]
(
@Name varchar(50), 
@ConnectionString varchar(500), 
@IsActive bit, 
@ConnectionId int
  )

  AS
   SET NOCOUNT ON;
   UPDATE [Connection] SET [Name]=@Name
     , [ConnectionString]=@ConnectionString
     , [IsActive]=@IsActive
WHERE [ConnectionId]=@ConnectionId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Connection_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Connection_Delete]
(
@ConnectionId int
  )

  AS
   SET NOCOUNT ON;
DELETE 
FROM [Connection]
WHERE [ConnectionId]=@ConnectionId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Connection_Delete]
(
@ConnectionId int
  )

  AS
   SET NOCOUNT ON;
   DELETE 
FROM [Connection]
WHERE [ConnectionId]=@ConnectionId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Connection_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Connection_Insert]
(
@Name varchar(50), 
@ConnectionString varchar(500), 
@IsActive bit
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [Connection] ([Name], [ConnectionString], [IsActive]) VALUES (@Name, @ConnectionString, @IsActive);SELECT SCOPE_IDENTITY();'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Connection_Insert]
(
@Name varchar(50), 
@ConnectionString varchar(500), 
@IsActive bit
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [Connection] ([Name], [ConnectionString], [IsActive]) VALUES (@Name, @ConnectionString, @IsActive);SELECT SCOPE_IDENTITY();'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Connection_GetDataPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Connection_GetDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''ConnectionId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [ConnectionId], [Name], [ConnectionString], [IsActive] FROM (
    SELECT [ConnectionId], [Name], [ConnectionString], [IsActive],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM Connection) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Connection_GetDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''ConnectionId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [ConnectionId], [Name], [ConnectionString], [IsActive] FROM (
    SELECT [ConnectionId], [Name], [ConnectionString], [IsActive],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM Connection) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Connection_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Connection_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Connection'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Connection_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Connection'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Connection_GetDataByConnectionId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Connection_GetDataByConnectionId]
(
@ConnectionId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [ConnectionId], [Name], [ConnectionString], [IsActive]
FROM [Connection]
WHERE [ConnectionId]=@ConnectionId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Connection_GetDataByConnectionId]
(
@ConnectionId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [ConnectionId], [Name], [ConnectionString], [IsActive]
FROM [Connection]
WHERE [ConnectionId]=@ConnectionId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Connection_GetActiveData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Connection_GetActiveData]

  AS
   SET NOCOUNT ON;
SELECT 
     [ConnectionId], [Name], [ConnectionString], [IsActive]
FROM [Connection] WHERE (IsActive = 1)'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Connection_GetActiveData]

  AS
   SET NOCOUNT ON;
   SELECT 
     [ConnectionId], [Name], [ConnectionString], [IsActive]
FROM [Connection] WHERE (IsActive = 1)'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Connection_GetActiveDataPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Connection_GetActiveDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@PageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000),  
 @startRowIndex int 

IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''ConnectionId''  
 SET @startRowIndex = (@page -1) * @pageSize + 1  
 SET @sql = ''SELECT [ConnectionId], [Name], [ConnectionString], [IsActive] FROM ( 
       SELECT [ConnectionId], [Name], [ConnectionString], [IsActive],
        ROW_NUMBER() OVER (ORDER BY  '' + @SortExpression + '') AS ResultSetRowNumber 
       FROM Connection WHERE (IsActive = 1)) AS PagedResults 
     WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1'' 
 -- Execute the SQL query 
EXEC sp_executesql @sql, N'',@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex = @startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Connection_GetActiveDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@PageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000),  
 @startRowIndex int 

IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''ConnectionId''  
 SET @startRowIndex = (@page -1) * @pageSize + 1  
 SET @sql = ''SELECT [ConnectionId], [Name], [ConnectionString], [IsActive] FROM ( 
       SELECT [ConnectionId], [Name], [ConnectionString], [IsActive],
        ROW_NUMBER() OVER (ORDER BY  '' + @SortExpression + '') AS ResultSetRowNumber 
       FROM Connection WHERE (IsActive = 1)) AS PagedResults 
     WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1'' 
 -- Execute the SQL query 
EXEC sp_executesql @sql, N'',@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex = @startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Connection_GetActiveDataRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Connection_GetActiveDataRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Connection WHERE (IsActive = 1)'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Connection_GetActiveDataRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Connection WHERE (IsActive = 1)'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Connection_GetConnectionsForProjectByProjectId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Connection_GetConnectionsForProjectByProjectId]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
Connection.[ConnectionId], 
Connection.[Name], 
Connection.[ConnectionString], 
Connection.[IsActive]
FROM [Connection] INNER JOIN Project_Connection ON Connection.[ConnectionId] = Project_Connection.[ConnectionId]
WHERE Project_Connection.[ProjectId] = @ProjectId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Connection_GetConnectionsForProjectByProjectId]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
Connection.[ConnectionId], 
Connection.[Name], 
Connection.[ConnectionString], 
Connection.[IsActive]
FROM [Connection] INNER JOIN Project_Connection ON Connection.[ConnectionId] = Project_Connection.[ConnectionId]
WHERE Project_Connection.[ProjectId] = @ProjectId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Connection_GetConnectionsForProjectByProjectIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Connection_GetConnectionsForProjectByProjectIdPageable]
(
@ProjectId int, 
@sortExpression varchar(125), 
@page Int, 
@PageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''ConnectionId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT 
[ConnectionId], 
[Name], 
[ConnectionString], 
[IsActive] FROM (
		   SELECT 
Connection.[ConnectionId], 
Connection.[Name], 
Connection.[ConnectionString], 
Connection.[IsActive], 
			  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '') AS ResultSetRowNumber
		   FROM [Connection] INNER JOIN Project_Connection ON Connection.[ConnectionId] = Project_Connection.[ConnectionId]          WHERE Project_Connection.[ProjectId] = @INProjectId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INProjectId int,@inStartRowIndex Int,@inPageSize Int'', @INProjectId= @ProjectId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Connection_GetConnectionsForProjectByProjectIdPageable]
(
@ProjectId int, 
@sortExpression varchar(125), 
@page Int, 
@PageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''ConnectionId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT 
[ConnectionId], 
[Name], 
[ConnectionString], 
[IsActive] FROM (
		   SELECT 
Connection.[ConnectionId], 
Connection.[Name], 
Connection.[ConnectionString], 
Connection.[IsActive], 
			  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '') AS ResultSetRowNumber
		   FROM [Connection] INNER JOIN Project_Connection ON Connection.[ConnectionId] = Project_Connection.[ConnectionId]          WHERE Project_Connection.[ProjectId] = @INProjectId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INProjectId int,@inStartRowIndex Int,@inPageSize Int'', @INProjectId= @ProjectId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Connection_GetConnectionsForProjectByProjectIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Connection_GetConnectionsForProjectByProjectIdRowCount]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(Connection.[ConnectionId]) 
 FROM [Connection] INNER JOIN 
Project_Connection ON Connection
.[ConnectionId] = Project_Connection.[ConnectionId]
WHERE Project_Connection.[ProjectId] = @ProjectId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Connection_GetConnectionsForProjectByProjectIdRowCount]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(Connection.[ConnectionId]) 
 FROM [Connection] INNER JOIN 
Project_Connection ON Connection
.[ConnectionId] = Project_Connection.[ConnectionId]
WHERE Project_Connection.[ProjectId] = @ProjectId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpectedResult_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ExpectedResult_Select]

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [ExpectedValue], [AssertTypeId]
FROM [ExpectedResult]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ExpectedResult_Select]

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [ExpectedValue], [AssertTypeId]
FROM [ExpectedResult]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpectedResult_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ExpectedResult_Update]
(
@ExpectedValue varchar(50), 
@AssertTypeId int, 
@Id int
  )

  AS
   SET NOCOUNT ON;
UPDATE [ExpectedResult] SET [ExpectedValue]=@ExpectedValue
     , [AssertTypeId]=@AssertTypeId
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ExpectedResult_Update]
(
@ExpectedValue varchar(50), 
@AssertTypeId int, 
@Id int
  )

  AS
   SET NOCOUNT ON;
   UPDATE [ExpectedResult] SET [ExpectedValue]=@ExpectedValue
     , [AssertTypeId]=@AssertTypeId
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpectedResult_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ExpectedResult_Delete]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
DELETE 
FROM [ExpectedResult]
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ExpectedResult_Delete]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
   DELETE 
FROM [ExpectedResult]
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpectedResult_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ExpectedResult_Insert]
(
@ExpectedValue varchar(50), 
@AssertTypeId int
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [ExpectedResult] ([ExpectedValue], [AssertTypeId]) VALUES (@ExpectedValue, @AssertTypeId);SELECT SCOPE_IDENTITY();'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ExpectedResult_Insert]
(
@ExpectedValue varchar(50), 
@AssertTypeId int
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [ExpectedResult] ([ExpectedValue], [AssertTypeId]) VALUES (@ExpectedValue, @AssertTypeId);SELECT SCOPE_IDENTITY();'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpectedResult_GetDataPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ExpectedResult_GetDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''Id'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [ExpectedValue], [AssertTypeId] FROM (
    SELECT [Id], [ExpectedValue], [AssertTypeId],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM ExpectedResult) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ExpectedResult_GetDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''Id'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [ExpectedValue], [AssertTypeId] FROM (
    SELECT [Id], [ExpectedValue], [AssertTypeId],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM ExpectedResult) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpectedResult_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ExpectedResult_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM ExpectedResult'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ExpectedResult_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM ExpectedResult'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpectedResult_GetDataById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ExpectedResult_GetDataById]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [ExpectedValue], [AssertTypeId]
FROM [ExpectedResult]
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ExpectedResult_GetDataById]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [ExpectedValue], [AssertTypeId]
FROM [ExpectedResult]
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpectedResult_GetDataByAssertTypeId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ExpectedResult_GetDataByAssertTypeId]
(
@AssertTypeId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [ExpectedValue], [AssertTypeId]
FROM [ExpectedResult]
WHERE [AssertTypeId]=@AssertTypeId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ExpectedResult_GetDataByAssertTypeId]
(
@AssertTypeId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [ExpectedValue], [AssertTypeId]
FROM [ExpectedResult]
WHERE [AssertTypeId]=@AssertTypeId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpectedResult_GetDataByAssertTypeIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ExpectedResult_GetDataByAssertTypeIdPageable]
(
@AssertTypeId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''AssertTypeId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [ExpectedValue], [AssertTypeId] FROM (
		   SELECT [Id], [ExpectedValue], [AssertTypeId],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM ExpectedResult WHERE AssertTypeId = @INAssertTypeId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INAssertTypeId int,@inStartRowIndex Int,@inPageSize Int'', @INAssertTypeId = @AssertTypeId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ExpectedResult_GetDataByAssertTypeIdPageable]
(
@AssertTypeId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''AssertTypeId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [ExpectedValue], [AssertTypeId] FROM (
		   SELECT [Id], [ExpectedValue], [AssertTypeId],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM ExpectedResult WHERE AssertTypeId = @INAssertTypeId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INAssertTypeId int,@inStartRowIndex Int,@inPageSize Int'', @INAssertTypeId = @AssertTypeId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpectedResult_GetDataByAssertTypeIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ExpectedResult_GetDataByAssertTypeIdRowCount]
(
@AssertTypeId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM ExpectedResult
WHERE [AssertTypeId]=@AssertTypeId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ExpectedResult_GetDataByAssertTypeIdRowCount]
(
@AssertTypeId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM ExpectedResult
WHERE [AssertTypeId]=@AssertTypeId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Project_Select]

  AS
   SET NOCOUNT ON;
SELECT 
     [ProjectId], [Name], [IsActive]
FROM [Project]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Project_Select]

  AS
   SET NOCOUNT ON;
   SELECT 
     [ProjectId], [Name], [IsActive]
FROM [Project]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Project_Update]
(
@Name varchar(50), 
@IsActive bit, 
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
UPDATE [Project] SET [Name]=@Name
     , [IsActive]=@IsActive
WHERE [ProjectId]=@ProjectId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Project_Update]
(
@Name varchar(50), 
@IsActive bit, 
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
   UPDATE [Project] SET [Name]=@Name
     , [IsActive]=@IsActive
WHERE [ProjectId]=@ProjectId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Project_Delete]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
DELETE 
FROM [Project]
WHERE [ProjectId]=@ProjectId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Project_Delete]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
   DELETE 
FROM [Project]
WHERE [ProjectId]=@ProjectId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Project_Insert]
(
@Name varchar(50), 
@IsActive bit
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [Project] ([Name], [IsActive]) VALUES (@Name, @IsActive);SELECT SCOPE_IDENTITY();'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Project_Insert]
(
@Name varchar(50), 
@IsActive bit
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [Project] ([Name], [IsActive]) VALUES (@Name, @IsActive);SELECT SCOPE_IDENTITY();'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project_GetDataPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Project_GetDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''ProjectId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [ProjectId], [Name], [IsActive] FROM (
    SELECT [ProjectId], [Name], [IsActive],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM Project) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Project_GetDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''ProjectId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [ProjectId], [Name], [IsActive] FROM (
    SELECT [ProjectId], [Name], [IsActive],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM Project) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Project_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Project'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Project_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Project'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project_GetDataByProjectId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Project_GetDataByProjectId]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [ProjectId], [Name], [IsActive]
FROM [Project]
WHERE [ProjectId]=@ProjectId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Project_GetDataByProjectId]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [ProjectId], [Name], [IsActive]
FROM [Project]
WHERE [ProjectId]=@ProjectId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project_GetActiveData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Project_GetActiveData]

  AS
   SET NOCOUNT ON;
SELECT 
     [ProjectId], [Name], [IsActive]
FROM [Project] WHERE (IsActive = 1)'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Project_GetActiveData]

  AS
   SET NOCOUNT ON;
   SELECT 
     [ProjectId], [Name], [IsActive]
FROM [Project] WHERE (IsActive = 1)'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project_GetActiveDataPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Project_GetActiveDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@PageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000),  
 @startRowIndex int 

IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''ProjectId''  
 SET @startRowIndex = (@page -1) * @pageSize + 1  
 SET @sql = ''SELECT [ProjectId], [Name], [IsActive] FROM ( 
       SELECT [ProjectId], [Name], [IsActive],
        ROW_NUMBER() OVER (ORDER BY  '' + @SortExpression + '') AS ResultSetRowNumber 
       FROM Project WHERE (IsActive = 1)) AS PagedResults 
     WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1'' 
 -- Execute the SQL query 
EXEC sp_executesql @sql, N'',@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex = @startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Project_GetActiveDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@PageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000),  
 @startRowIndex int 

IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''ProjectId''  
 SET @startRowIndex = (@page -1) * @pageSize + 1  
 SET @sql = ''SELECT [ProjectId], [Name], [IsActive] FROM ( 
       SELECT [ProjectId], [Name], [IsActive],
        ROW_NUMBER() OVER (ORDER BY  '' + @SortExpression + '') AS ResultSetRowNumber 
       FROM Project WHERE (IsActive = 1)) AS PagedResults 
     WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1'' 
 -- Execute the SQL query 
EXEC sp_executesql @sql, N'',@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex = @startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project_GetActiveDataRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Project_GetActiveDataRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Project WHERE (IsActive = 1)'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Project_GetActiveDataRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Project WHERE (IsActive = 1)'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project_GetProjectsForConnectionByConnectionId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Project_GetProjectsForConnectionByConnectionId]
(
@ConnectionId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
Project.[ProjectId], 
Project.[Name], 
Project.[IsActive]
FROM [Project] INNER JOIN Project_Connection ON Project.[ProjectId] = Project_Connection.[ProjectId]
WHERE Project_Connection.[ConnectionId] = @ConnectionId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Project_GetProjectsForConnectionByConnectionId]
(
@ConnectionId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
Project.[ProjectId], 
Project.[Name], 
Project.[IsActive]
FROM [Project] INNER JOIN Project_Connection ON Project.[ProjectId] = Project_Connection.[ProjectId]
WHERE Project_Connection.[ConnectionId] = @ConnectionId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project_GetProjectsForConnectionByConnectionIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Project_GetProjectsForConnectionByConnectionIdPageable]
(
@ConnectionId int, 
@sortExpression varchar(125), 
@page Int, 
@PageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''ProjectId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT 
[ProjectId], 
[Name], 
[IsActive] FROM (
		   SELECT 
Project.[ProjectId], 
Project.[Name], 
Project.[IsActive], 
			  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '') AS ResultSetRowNumber
		   FROM [Project] INNER JOIN Project_Connection ON Project.[ProjectId] = Project_Connection.[ProjectId]          WHERE Project_Connection.[ConnectionId] = @INConnectionId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INConnectionId int,@inStartRowIndex Int,@inPageSize Int'', @INConnectionId= @ConnectionId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Project_GetProjectsForConnectionByConnectionIdPageable]
(
@ConnectionId int, 
@sortExpression varchar(125), 
@page Int, 
@PageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''ProjectId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT 
[ProjectId], 
[Name], 
[IsActive] FROM (
		   SELECT 
Project.[ProjectId], 
Project.[Name], 
Project.[IsActive], 
			  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '') AS ResultSetRowNumber
		   FROM [Project] INNER JOIN Project_Connection ON Project.[ProjectId] = Project_Connection.[ProjectId]          WHERE Project_Connection.[ConnectionId] = @INConnectionId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INConnectionId int,@inStartRowIndex Int,@inPageSize Int'', @INConnectionId= @ConnectionId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project_GetProjectsForConnectionByConnectionIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Project_GetProjectsForConnectionByConnectionIdRowCount]
(
@ConnectionId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(Project.[ProjectId]) 
 FROM [Project] INNER JOIN 
Project_Connection ON Project
.[ProjectId] = Project_Connection.[ProjectId]
WHERE Project_Connection.[ConnectionId] = @ConnectionId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Project_GetProjectsForConnectionByConnectionIdRowCount]
(
@ConnectionId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(Project.[ProjectId]) 
 FROM [Project] INNER JOIN 
Project_Connection ON Project
.[ProjectId] = Project_Connection.[ProjectId]
WHERE Project_Connection.[ConnectionId] = @ConnectionId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project_Connection_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Project_Connection_Select]

  AS
   SET NOCOUNT ON;
SELECT 
     [ProjectId], [ConnectionId]
FROM [Project_Connection]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Project_Connection_Select]

  AS
   SET NOCOUNT ON;
   SELECT 
     [ProjectId], [ConnectionId]
FROM [Project_Connection]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project_Connection_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Project_Connection_Update]
(
@ProjectId int, 
@ConnectionId int, 
@Original_ProjectId int, 
@Original_ConnectionId int
  )

  AS
   SET NOCOUNT ON;
UPDATE [Project_Connection] SET [ProjectId]=@ProjectId
     , [ConnectionId]=@ConnectionId
WHERE [ProjectId]=@Original_ProjectId
  AND [ConnectionId]=@Original_ConnectionId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Project_Connection_Update]
(
@ProjectId int, 
@ConnectionId int, 
@Original_ProjectId int, 
@Original_ConnectionId int
  )

  AS
   SET NOCOUNT ON;
   UPDATE [Project_Connection] SET [ProjectId]=@ProjectId
     , [ConnectionId]=@ConnectionId
WHERE [ProjectId]=@Original_ProjectId
  AND [ConnectionId]=@Original_ConnectionId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project_Connection_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Project_Connection_Delete]
(
@ProjectId int, 
@ConnectionId int
  )

  AS
   SET NOCOUNT ON;
DELETE 
FROM [Project_Connection]
WHERE [ProjectId]=@ProjectId
  AND [ConnectionId]=@ConnectionId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Project_Connection_Delete]
(
@ProjectId int, 
@ConnectionId int
  )

  AS
   SET NOCOUNT ON;
   DELETE 
FROM [Project_Connection]
WHERE [ProjectId]=@ProjectId
  AND [ConnectionId]=@ConnectionId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project_Connection_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Project_Connection_Insert]
(
@ProjectId int, 
@ConnectionId int
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [Project_Connection] ([ProjectId], [ConnectionId]) VALUES (@ProjectId, @ConnectionId);SELECT 
     [ProjectId], [ConnectionId]
FROM [Project_Connection]
WHERE [ProjectId]=@ProjectId
  AND [ConnectionId]=@ConnectionId;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Project_Connection_Insert]
(
@ProjectId int, 
@ConnectionId int
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [Project_Connection] ([ProjectId], [ConnectionId]) VALUES (@ProjectId, @ConnectionId);SELECT 
     [ProjectId], [ConnectionId]
FROM [Project_Connection]
WHERE [ProjectId]=@ProjectId
  AND [ConnectionId]=@ConnectionId;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project_Connection_GetDataPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Project_Connection_GetDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''ProjectId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [ProjectId], [ConnectionId] FROM (
    SELECT [ProjectId], [ConnectionId],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM Project_Connection) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Project_Connection_GetDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''ProjectId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [ProjectId], [ConnectionId] FROM (
    SELECT [ProjectId], [ConnectionId],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM Project_Connection) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project_Connection_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Project_Connection_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Project_Connection'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Project_Connection_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Project_Connection'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project_Connection_GetDataByProjectIdConnectionId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Project_Connection_GetDataByProjectIdConnectionId]
(
@ProjectId int, 
@ConnectionId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [ProjectId], [ConnectionId]
FROM [Project_Connection]
WHERE [ProjectId]=@ProjectId
  AND [ConnectionId]=@ConnectionId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Project_Connection_GetDataByProjectIdConnectionId]
(
@ProjectId int, 
@ConnectionId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [ProjectId], [ConnectionId]
FROM [Project_Connection]
WHERE [ProjectId]=@ProjectId
  AND [ConnectionId]=@ConnectionId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project_Connection_GetDataByConnectionId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Project_Connection_GetDataByConnectionId]
(
@ConnectionId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [ProjectId], [ConnectionId]
FROM [Project_Connection]
WHERE [ConnectionId]=@ConnectionId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Project_Connection_GetDataByConnectionId]
(
@ConnectionId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [ProjectId], [ConnectionId]
FROM [Project_Connection]
WHERE [ConnectionId]=@ConnectionId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project_Connection_GetDataByConnectionIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Project_Connection_GetDataByConnectionIdPageable]
(
@ConnectionId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''ConnectionId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [ProjectId], [ConnectionId] FROM (
		   SELECT [ProjectId], [ConnectionId],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM Project_Connection WHERE ConnectionId = @INConnectionId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INConnectionId int,@inStartRowIndex Int,@inPageSize Int'', @INConnectionId = @ConnectionId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Project_Connection_GetDataByConnectionIdPageable]
(
@ConnectionId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''ConnectionId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [ProjectId], [ConnectionId] FROM (
		   SELECT [ProjectId], [ConnectionId],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM Project_Connection WHERE ConnectionId = @INConnectionId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INConnectionId int,@inStartRowIndex Int,@inPageSize Int'', @INConnectionId = @ConnectionId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project_Connection_GetDataByConnectionIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Project_Connection_GetDataByConnectionIdRowCount]
(
@ConnectionId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Project_Connection
WHERE [ConnectionId]=@ConnectionId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Project_Connection_GetDataByConnectionIdRowCount]
(
@ConnectionId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Project_Connection
WHERE [ConnectionId]=@ConnectionId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project_Connection_GetDataByProjectId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Project_Connection_GetDataByProjectId]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [ProjectId], [ConnectionId]
FROM [Project_Connection]
WHERE [ProjectId]=@ProjectId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Project_Connection_GetDataByProjectId]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [ProjectId], [ConnectionId]
FROM [Project_Connection]
WHERE [ProjectId]=@ProjectId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project_Connection_GetDataByProjectIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Project_Connection_GetDataByProjectIdPageable]
(
@ProjectId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''ProjectId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [ProjectId], [ConnectionId] FROM (
		   SELECT [ProjectId], [ConnectionId],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM Project_Connection WHERE ProjectId = @INProjectId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INProjectId int,@inStartRowIndex Int,@inPageSize Int'', @INProjectId = @ProjectId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Project_Connection_GetDataByProjectIdPageable]
(
@ProjectId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''ProjectId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [ProjectId], [ConnectionId] FROM (
		   SELECT [ProjectId], [ConnectionId],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM Project_Connection WHERE ProjectId = @INProjectId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INProjectId int,@inStartRowIndex Int,@inPageSize Int'', @INProjectId = @ProjectId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Project_Connection_GetDataByProjectIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Project_Connection_GetDataByProjectIdRowCount]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Project_Connection
WHERE [ProjectId]=@ProjectId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Project_Connection_GetDataByProjectIdRowCount]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Project_Connection
WHERE [ProjectId]=@ProjectId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RunHistory_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[RunHistory_Select]

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [ScriptId], [RunDateTime], [IsPass], [ResultString]
FROM [RunHistory]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[RunHistory_Select]

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [ScriptId], [RunDateTime], [IsPass], [ResultString]
FROM [RunHistory]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RunHistory_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[RunHistory_Update]
(
@ScriptId int, 
@RunDateTime datetime, 
@IsPass bit, 
@ResultString varchar(1000), 
@Id bigint
  )

  AS
   SET NOCOUNT ON;
UPDATE [RunHistory] SET [ScriptId]=@ScriptId
     , [RunDateTime]=@RunDateTime
     , [IsPass]=@IsPass
     , [ResultString]=@ResultString
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[RunHistory_Update]
(
@ScriptId int, 
@RunDateTime datetime, 
@IsPass bit, 
@ResultString varchar(1000), 
@Id bigint
  )

  AS
   SET NOCOUNT ON;
   UPDATE [RunHistory] SET [ScriptId]=@ScriptId
     , [RunDateTime]=@RunDateTime
     , [IsPass]=@IsPass
     , [ResultString]=@ResultString
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RunHistory_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[RunHistory_Delete]
(
@Id bigint
  )

  AS
   SET NOCOUNT ON;
DELETE 
FROM [RunHistory]
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[RunHistory_Delete]
(
@Id bigint
  )

  AS
   SET NOCOUNT ON;
   DELETE 
FROM [RunHistory]
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RunHistory_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[RunHistory_Insert]
(
@ScriptId int, 
@RunDateTime datetime, 
@IsPass bit, 
@ResultString varchar(1000)
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [RunHistory] ([ScriptId], [RunDateTime], [IsPass], [ResultString]) VALUES (@ScriptId, @RunDateTime, @IsPass, @ResultString);SELECT SCOPE_IDENTITY();'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[RunHistory_Insert]
(
@ScriptId int, 
@RunDateTime datetime, 
@IsPass bit, 
@ResultString varchar(1000)
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [RunHistory] ([ScriptId], [RunDateTime], [IsPass], [ResultString]) VALUES (@ScriptId, @RunDateTime, @IsPass, @ResultString);SELECT SCOPE_IDENTITY();'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RunHistory_GetDataPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[RunHistory_GetDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''Id'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [ScriptId], [RunDateTime], [IsPass], [ResultString] FROM (
    SELECT [Id], [ScriptId], [RunDateTime], [IsPass], [ResultString],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM RunHistory) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[RunHistory_GetDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''Id'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [ScriptId], [RunDateTime], [IsPass], [ResultString] FROM (
    SELECT [Id], [ScriptId], [RunDateTime], [IsPass], [ResultString],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM RunHistory) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RunHistory_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[RunHistory_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM RunHistory'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[RunHistory_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM RunHistory'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RunHistory_GetDataById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[RunHistory_GetDataById]
(
@Id bigint
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [ScriptId], [RunDateTime], [IsPass], [ResultString]
FROM [RunHistory]
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[RunHistory_GetDataById]
(
@Id bigint
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [ScriptId], [RunDateTime], [IsPass], [ResultString]
FROM [RunHistory]
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RunHistory_GetDataByScriptId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[RunHistory_GetDataByScriptId]
(
@ScriptId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [ScriptId], [RunDateTime], [IsPass], [ResultString]
FROM [RunHistory]
WHERE [ScriptId]=@ScriptId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[RunHistory_GetDataByScriptId]
(
@ScriptId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [ScriptId], [RunDateTime], [IsPass], [ResultString]
FROM [RunHistory]
WHERE [ScriptId]=@ScriptId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RunHistory_GetDataByScriptIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[RunHistory_GetDataByScriptIdPageable]
(
@ScriptId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''ScriptId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [ScriptId], [RunDateTime], [IsPass], [ResultString] FROM (
		   SELECT [Id], [ScriptId], [RunDateTime], [IsPass], [ResultString],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM RunHistory WHERE ScriptId = @INScriptId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INScriptId int,@inStartRowIndex Int,@inPageSize Int'', @INScriptId = @ScriptId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[RunHistory_GetDataByScriptIdPageable]
(
@ScriptId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''ScriptId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [ScriptId], [RunDateTime], [IsPass], [ResultString] FROM (
		   SELECT [Id], [ScriptId], [RunDateTime], [IsPass], [ResultString],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM RunHistory WHERE ScriptId = @INScriptId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INScriptId int,@inStartRowIndex Int,@inPageSize Int'', @INScriptId = @ScriptId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RunHistory_GetDataByScriptIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[RunHistory_GetDataByScriptIdRowCount]
(
@ScriptId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM RunHistory
WHERE [ScriptId]=@ScriptId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[RunHistory_GetDataByScriptIdRowCount]
(
@ScriptId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM RunHistory
WHERE [ScriptId]=@ScriptId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Script_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Script_Select]

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [ScriptTypeId], [Name], [ScriptValue], [IsActive]
FROM [Script]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Script_Select]

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [ScriptTypeId], [Name], [ScriptValue], [IsActive]
FROM [Script]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Script_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Script_Update]
(
@ScriptTypeId int, 
@Name varchar(50), 
@ScriptValue text, 
@IsActive bit, 
@Id int
  )

  AS
   SET NOCOUNT ON;
UPDATE [Script] SET [ScriptTypeId]=@ScriptTypeId
     , [Name]=@Name
     , [ScriptValue]=@ScriptValue
     , [IsActive]=@IsActive
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Script_Update]
(
@ScriptTypeId int, 
@Name varchar(50), 
@ScriptValue text, 
@IsActive bit, 
@Id int
  )

  AS
   SET NOCOUNT ON;
   UPDATE [Script] SET [ScriptTypeId]=@ScriptTypeId
     , [Name]=@Name
     , [ScriptValue]=@ScriptValue
     , [IsActive]=@IsActive
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Script_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Script_Delete]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
DELETE 
FROM [Script]
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Script_Delete]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
   DELETE 
FROM [Script]
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Script_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Script_Insert]
(
@ScriptTypeId int, 
@Name varchar(50), 
@ScriptValue text, 
@IsActive bit
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [Script] ([ScriptTypeId], [Name], [ScriptValue], [IsActive]) VALUES (@ScriptTypeId, @Name, @ScriptValue, @IsActive);SELECT SCOPE_IDENTITY();'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Script_Insert]
(
@ScriptTypeId int, 
@Name varchar(50), 
@ScriptValue text, 
@IsActive bit
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [Script] ([ScriptTypeId], [Name], [ScriptValue], [IsActive]) VALUES (@ScriptTypeId, @Name, @ScriptValue, @IsActive);SELECT SCOPE_IDENTITY();'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Script_GetDataPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Script_GetDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''Id'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [ScriptTypeId], [Name], [ScriptValue], [IsActive] FROM (
    SELECT [Id], [ScriptTypeId], [Name], [ScriptValue], [IsActive],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM Script) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Script_GetDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''Id'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [ScriptTypeId], [Name], [ScriptValue], [IsActive] FROM (
    SELECT [Id], [ScriptTypeId], [Name], [ScriptValue], [IsActive],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM Script) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Script_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Script_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Script'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Script_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Script'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Script_GetDataById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Script_GetDataById]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [ScriptTypeId], [Name], [ScriptValue], [IsActive]
FROM [Script]
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Script_GetDataById]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [ScriptTypeId], [Name], [ScriptValue], [IsActive]
FROM [Script]
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Script_GetActiveData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Script_GetActiveData]

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [ScriptTypeId], [Name], [ScriptValue], [IsActive]
FROM [Script] WHERE (IsActive = 1)'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Script_GetActiveData]

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [ScriptTypeId], [Name], [ScriptValue], [IsActive]
FROM [Script] WHERE (IsActive = 1)'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Script_GetActiveDataPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Script_GetActiveDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@PageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000),  
 @startRowIndex int 

IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''Id''  
 SET @startRowIndex = (@page -1) * @pageSize + 1  
 SET @sql = ''SELECT [Id], [ScriptTypeId], [Name], [ScriptValue], [IsActive] FROM ( 
       SELECT [Id], [ScriptTypeId], [Name], [ScriptValue], [IsActive],
        ROW_NUMBER() OVER (ORDER BY  '' + @SortExpression + '') AS ResultSetRowNumber 
       FROM Script WHERE (IsActive = 1)) AS PagedResults 
     WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1'' 
 -- Execute the SQL query 
EXEC sp_executesql @sql, N'',@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex = @startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Script_GetActiveDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@PageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000),  
 @startRowIndex int 

IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''Id''  
 SET @startRowIndex = (@page -1) * @pageSize + 1  
 SET @sql = ''SELECT [Id], [ScriptTypeId], [Name], [ScriptValue], [IsActive] FROM ( 
       SELECT [Id], [ScriptTypeId], [Name], [ScriptValue], [IsActive],
        ROW_NUMBER() OVER (ORDER BY  '' + @SortExpression + '') AS ResultSetRowNumber 
       FROM Script WHERE (IsActive = 1)) AS PagedResults 
     WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1'' 
 -- Execute the SQL query 
EXEC sp_executesql @sql, N'',@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex = @startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Script_GetActiveDataRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Script_GetActiveDataRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Script WHERE (IsActive = 1)'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Script_GetActiveDataRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Script WHERE (IsActive = 1)'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Script_GetScriptsForTestByTestId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Script_GetScriptsForTestByTestId]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
SELECT 
Script.[Id], 
Script.[ScriptTypeId], 
Script.[Name], 
Script.[ScriptValue], 
Script.[IsActive]
FROM [Script] INNER JOIN Test_Script ON Script.[Id] = Test_Script.[ScriptId]
WHERE Test_Script.[TestId] = @Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Script_GetScriptsForTestByTestId]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
Script.[Id], 
Script.[ScriptTypeId], 
Script.[Name], 
Script.[ScriptValue], 
Script.[IsActive]
FROM [Script] INNER JOIN Test_Script ON Script.[Id] = Test_Script.[ScriptId]
WHERE Test_Script.[TestId] = @Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Script_GetDataByScriptTypeId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Script_GetDataByScriptTypeId]
(
@ScriptTypeId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [ScriptTypeId], [Name], [ScriptValue], [IsActive]
FROM [Script]
WHERE [ScriptTypeId]=@ScriptTypeId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Script_GetDataByScriptTypeId]
(
@ScriptTypeId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [ScriptTypeId], [Name], [ScriptValue], [IsActive]
FROM [Script]
WHERE [ScriptTypeId]=@ScriptTypeId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Script_GetDataByScriptTypeIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Script_GetDataByScriptTypeIdPageable]
(
@ScriptTypeId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''ScriptTypeId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [ScriptTypeId], [Name], [ScriptValue], [IsActive] FROM (
		   SELECT [Id], [ScriptTypeId], [Name], [ScriptValue], [IsActive],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM Script WHERE ScriptTypeId = @INScriptTypeId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INScriptTypeId int,@inStartRowIndex Int,@inPageSize Int'', @INScriptTypeId = @ScriptTypeId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Script_GetDataByScriptTypeIdPageable]
(
@ScriptTypeId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''ScriptTypeId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [ScriptTypeId], [Name], [ScriptValue], [IsActive] FROM (
		   SELECT [Id], [ScriptTypeId], [Name], [ScriptValue], [IsActive],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM Script WHERE ScriptTypeId = @INScriptTypeId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INScriptTypeId int,@inStartRowIndex Int,@inPageSize Int'', @INScriptTypeId = @ScriptTypeId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Script_GetDataByScriptTypeIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Script_GetDataByScriptTypeIdRowCount]
(
@ScriptTypeId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Script
WHERE [ScriptTypeId]=@ScriptTypeId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Script_GetDataByScriptTypeIdRowCount]
(
@ScriptTypeId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Script
WHERE [ScriptTypeId]=@ScriptTypeId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Script_GetActiveDataByScriptTypeId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Script_GetActiveDataByScriptTypeId]
(
@ScriptTypeId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [ScriptTypeId], [Name], [ScriptValue], [IsActive]
FROM [Script] WHERE [IsActive] = 1 and [ScriptTypeId] = @ScriptTypeId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Script_GetActiveDataByScriptTypeId]
(
@ScriptTypeId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [ScriptTypeId], [Name], [ScriptValue], [IsActive]
FROM [Script] WHERE [IsActive] = 1 and [ScriptTypeId] = @ScriptTypeId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Script_GetActiveDataByScriptTypeIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Script_GetActiveDataByScriptTypeIdPageable]
(
@ScriptTypeId int, 
@sortExpression varchar(125), 
@page Int, 
@PageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''ScriptTypeId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [ScriptTypeId], [Name], [ScriptValue], [IsActive] FROM (
     SELECT [Id], [ScriptTypeId], [Name], [ScriptValue], [IsActive], 
      ROW_NUMBER() OVER (ORDER BY  '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM Script WHERE (IsActive = 1) and ScriptTypeId = @INScriptTypeId ) AS PagedResults  WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1'' 
 -- Execute the SQL query 
EXEC sp_executesql @sql, N''@INScriptTypeId int,@inStartRowIndex Int,@inPageSize Int'', @ScriptTypeId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Script_GetActiveDataByScriptTypeIdPageable]
(
@ScriptTypeId int, 
@sortExpression varchar(125), 
@page Int, 
@PageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''ScriptTypeId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [ScriptTypeId], [Name], [ScriptValue], [IsActive] FROM (
     SELECT [Id], [ScriptTypeId], [Name], [ScriptValue], [IsActive], 
      ROW_NUMBER() OVER (ORDER BY  '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM Script WHERE (IsActive = 1) and ScriptTypeId = @INScriptTypeId ) AS PagedResults  WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1'' 
 -- Execute the SQL query 
EXEC sp_executesql @sql, N''@INScriptTypeId int,@inStartRowIndex Int,@inPageSize Int'', @ScriptTypeId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Script_GetActiveDataByScriptTypeIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Script_GetActiveDataByScriptTypeIdRowCount]
(
@ScriptTypeId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Script WHERE (IsActive = 1) and ScriptTypeId = @ScriptTypeId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Script_GetActiveDataByScriptTypeIdRowCount]
(
@ScriptTypeId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Script WHERE (IsActive = 1) and ScriptTypeId = @ScriptTypeId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Script_ExpectedResult_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Script_ExpectedResult_Select]

  AS
   SET NOCOUNT ON;
SELECT 
     [ScriptId], [ExpectedResultId], [ResultIndex]
FROM [Script_ExpectedResult]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Script_ExpectedResult_Select]

  AS
   SET NOCOUNT ON;
   SELECT 
     [ScriptId], [ExpectedResultId], [ResultIndex]
FROM [Script_ExpectedResult]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Script_ExpectedResult_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Script_ExpectedResult_Update]
(
@ScriptId int, 
@ExpectedResultId int, 
@ResultIndex int, 
@Original_ScriptId int, 
@Original_ExpectedResultId int
  )

  AS
   SET NOCOUNT ON;
UPDATE [Script_ExpectedResult] SET [ScriptId]=@ScriptId
     , [ExpectedResultId]=@ExpectedResultId
     , [ResultIndex]=@ResultIndex
WHERE [ScriptId]=@Original_ScriptId
  AND [ExpectedResultId]=@Original_ExpectedResultId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Script_ExpectedResult_Update]
(
@ScriptId int, 
@ExpectedResultId int, 
@ResultIndex int, 
@Original_ScriptId int, 
@Original_ExpectedResultId int
  )

  AS
   SET NOCOUNT ON;
   UPDATE [Script_ExpectedResult] SET [ScriptId]=@ScriptId
     , [ExpectedResultId]=@ExpectedResultId
     , [ResultIndex]=@ResultIndex
WHERE [ScriptId]=@Original_ScriptId
  AND [ExpectedResultId]=@Original_ExpectedResultId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Script_ExpectedResult_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Script_ExpectedResult_Delete]
(
@ScriptId int, 
@ExpectedResultId int
  )

  AS
   SET NOCOUNT ON;
DELETE 
FROM [Script_ExpectedResult]
WHERE [ScriptId]=@ScriptId
  AND [ExpectedResultId]=@ExpectedResultId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Script_ExpectedResult_Delete]
(
@ScriptId int, 
@ExpectedResultId int
  )

  AS
   SET NOCOUNT ON;
   DELETE 
FROM [Script_ExpectedResult]
WHERE [ScriptId]=@ScriptId
  AND [ExpectedResultId]=@ExpectedResultId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Script_ExpectedResult_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Script_ExpectedResult_Insert]
(
@ScriptId int, 
@ExpectedResultId int, 
@ResultIndex int
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [Script_ExpectedResult] ([ScriptId], [ExpectedResultId], [ResultIndex]) VALUES (@ScriptId, @ExpectedResultId, @ResultIndex);SELECT 
     [ScriptId], [ExpectedResultId], [ResultIndex]
FROM [Script_ExpectedResult]
WHERE [ScriptId]=@ScriptId
  AND [ExpectedResultId]=@ExpectedResultId;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Script_ExpectedResult_Insert]
(
@ScriptId int, 
@ExpectedResultId int, 
@ResultIndex int
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [Script_ExpectedResult] ([ScriptId], [ExpectedResultId], [ResultIndex]) VALUES (@ScriptId, @ExpectedResultId, @ResultIndex);SELECT 
     [ScriptId], [ExpectedResultId], [ResultIndex]
FROM [Script_ExpectedResult]
WHERE [ScriptId]=@ScriptId
  AND [ExpectedResultId]=@ExpectedResultId;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Script_ExpectedResult_GetDataPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Script_ExpectedResult_GetDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''ScriptId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [ScriptId], [ExpectedResultId], [ResultIndex] FROM (
    SELECT [ScriptId], [ExpectedResultId], [ResultIndex],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM Script_ExpectedResult) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Script_ExpectedResult_GetDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''ScriptId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [ScriptId], [ExpectedResultId], [ResultIndex] FROM (
    SELECT [ScriptId], [ExpectedResultId], [ResultIndex],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM Script_ExpectedResult) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Script_ExpectedResult_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Script_ExpectedResult_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Script_ExpectedResult'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Script_ExpectedResult_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Script_ExpectedResult'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Script_ExpectedResult_GetDataByScriptIdExpectedResultId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Script_ExpectedResult_GetDataByScriptIdExpectedResultId]
(
@ScriptId int, 
@ExpectedResultId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [ScriptId], [ExpectedResultId], [ResultIndex]
FROM [Script_ExpectedResult]
WHERE [ScriptId]=@ScriptId
  AND [ExpectedResultId]=@ExpectedResultId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Script_ExpectedResult_GetDataByScriptIdExpectedResultId]
(
@ScriptId int, 
@ExpectedResultId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [ScriptId], [ExpectedResultId], [ResultIndex]
FROM [Script_ExpectedResult]
WHERE [ScriptId]=@ScriptId
  AND [ExpectedResultId]=@ExpectedResultId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Script_ExpectedResult_GetDataByExpectedResultId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Script_ExpectedResult_GetDataByExpectedResultId]
(
@ExpectedResultId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [ScriptId], [ExpectedResultId], [ResultIndex]
FROM [Script_ExpectedResult]
WHERE [ExpectedResultId]=@ExpectedResultId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Script_ExpectedResult_GetDataByExpectedResultId]
(
@ExpectedResultId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [ScriptId], [ExpectedResultId], [ResultIndex]
FROM [Script_ExpectedResult]
WHERE [ExpectedResultId]=@ExpectedResultId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Script_ExpectedResult_GetDataByExpectedResultIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Script_ExpectedResult_GetDataByExpectedResultIdPageable]
(
@ExpectedResultId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''ExpectedResultId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [ScriptId], [ExpectedResultId], [ResultIndex] FROM (
		   SELECT [ScriptId], [ExpectedResultId], [ResultIndex],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM Script_ExpectedResult WHERE ExpectedResultId = @INExpectedResultId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INExpectedResultId int,@inStartRowIndex Int,@inPageSize Int'', @INExpectedResultId = @ExpectedResultId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Script_ExpectedResult_GetDataByExpectedResultIdPageable]
(
@ExpectedResultId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''ExpectedResultId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [ScriptId], [ExpectedResultId], [ResultIndex] FROM (
		   SELECT [ScriptId], [ExpectedResultId], [ResultIndex],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM Script_ExpectedResult WHERE ExpectedResultId = @INExpectedResultId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INExpectedResultId int,@inStartRowIndex Int,@inPageSize Int'', @INExpectedResultId = @ExpectedResultId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Script_ExpectedResult_GetDataByExpectedResultIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Script_ExpectedResult_GetDataByExpectedResultIdRowCount]
(
@ExpectedResultId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Script_ExpectedResult
WHERE [ExpectedResultId]=@ExpectedResultId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Script_ExpectedResult_GetDataByExpectedResultIdRowCount]
(
@ExpectedResultId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Script_ExpectedResult
WHERE [ExpectedResultId]=@ExpectedResultId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Script_ExpectedResult_GetDataByScriptId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Script_ExpectedResult_GetDataByScriptId]
(
@ScriptId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [ScriptId], [ExpectedResultId], [ResultIndex]
FROM [Script_ExpectedResult]
WHERE [ScriptId]=@ScriptId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Script_ExpectedResult_GetDataByScriptId]
(
@ScriptId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [ScriptId], [ExpectedResultId], [ResultIndex]
FROM [Script_ExpectedResult]
WHERE [ScriptId]=@ScriptId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Script_ExpectedResult_GetDataByScriptIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Script_ExpectedResult_GetDataByScriptIdPageable]
(
@ScriptId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''ScriptId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [ScriptId], [ExpectedResultId], [ResultIndex] FROM (
		   SELECT [ScriptId], [ExpectedResultId], [ResultIndex],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM Script_ExpectedResult WHERE ScriptId = @INScriptId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INScriptId int,@inStartRowIndex Int,@inPageSize Int'', @INScriptId = @ScriptId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Script_ExpectedResult_GetDataByScriptIdPageable]
(
@ScriptId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''ScriptId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [ScriptId], [ExpectedResultId], [ResultIndex] FROM (
		   SELECT [ScriptId], [ExpectedResultId], [ResultIndex],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM Script_ExpectedResult WHERE ScriptId = @INScriptId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INScriptId int,@inStartRowIndex Int,@inPageSize Int'', @INScriptId = @ScriptId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Script_ExpectedResult_GetDataByScriptIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Script_ExpectedResult_GetDataByScriptIdRowCount]
(
@ScriptId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Script_ExpectedResult
WHERE [ScriptId]=@ScriptId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Script_ExpectedResult_GetDataByScriptIdRowCount]
(
@ScriptId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Script_ExpectedResult
WHERE [ScriptId]=@ScriptId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ScriptType_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ScriptType_Select]

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [Name], [IsActive]
FROM [ScriptType]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ScriptType_Select]

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [Name], [IsActive]
FROM [ScriptType]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ScriptType_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ScriptType_Update]
(
@Name varchar(50), 
@IsActive bit, 
@Id int
  )

  AS
   SET NOCOUNT ON;
UPDATE [ScriptType] SET [Name]=@Name
     , [IsActive]=@IsActive
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ScriptType_Update]
(
@Name varchar(50), 
@IsActive bit, 
@Id int
  )

  AS
   SET NOCOUNT ON;
   UPDATE [ScriptType] SET [Name]=@Name
     , [IsActive]=@IsActive
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ScriptType_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ScriptType_Delete]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
DELETE 
FROM [ScriptType]
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ScriptType_Delete]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
   DELETE 
FROM [ScriptType]
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ScriptType_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ScriptType_Insert]
(
@Name varchar(50), 
@IsActive bit
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [ScriptType] ([Name], [IsActive]) VALUES (@Name, @IsActive);SELECT SCOPE_IDENTITY();'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ScriptType_Insert]
(
@Name varchar(50), 
@IsActive bit
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [ScriptType] ([Name], [IsActive]) VALUES (@Name, @IsActive);SELECT SCOPE_IDENTITY();'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ScriptType_GetDataPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ScriptType_GetDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''Id'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [Name], [IsActive] FROM (
    SELECT [Id], [Name], [IsActive],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM ScriptType) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ScriptType_GetDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''Id'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [Name], [IsActive] FROM (
    SELECT [Id], [Name], [IsActive],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM ScriptType) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ScriptType_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ScriptType_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM ScriptType'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ScriptType_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM ScriptType'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ScriptType_GetDataById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ScriptType_GetDataById]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [Name], [IsActive]
FROM [ScriptType]
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ScriptType_GetDataById]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [Name], [IsActive]
FROM [ScriptType]
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ScriptType_GetActiveData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ScriptType_GetActiveData]

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [Name], [IsActive]
FROM [ScriptType] WHERE (IsActive = 1)'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ScriptType_GetActiveData]

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [Name], [IsActive]
FROM [ScriptType] WHERE (IsActive = 1)'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ScriptType_GetActiveDataPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ScriptType_GetActiveDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@PageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000),  
 @startRowIndex int 

IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''Id''  
 SET @startRowIndex = (@page -1) * @pageSize + 1  
 SET @sql = ''SELECT [Id], [Name], [IsActive] FROM ( 
       SELECT [Id], [Name], [IsActive],
        ROW_NUMBER() OVER (ORDER BY  '' + @SortExpression + '') AS ResultSetRowNumber 
       FROM ScriptType WHERE (IsActive = 1)) AS PagedResults 
     WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1'' 
 -- Execute the SQL query 
EXEC sp_executesql @sql, N'',@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex = @startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ScriptType_GetActiveDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@PageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000),  
 @startRowIndex int 

IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''Id''  
 SET @startRowIndex = (@page -1) * @pageSize + 1  
 SET @sql = ''SELECT [Id], [Name], [IsActive] FROM ( 
       SELECT [Id], [Name], [IsActive],
        ROW_NUMBER() OVER (ORDER BY  '' + @SortExpression + '') AS ResultSetRowNumber 
       FROM ScriptType WHERE (IsActive = 1)) AS PagedResults 
     WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1'' 
 -- Execute the SQL query 
EXEC sp_executesql @sql, N'',@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex = @startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ScriptType_GetActiveDataRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ScriptType_GetActiveDataRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM ScriptType WHERE (IsActive = 1)'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ScriptType_GetActiveDataRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM ScriptType WHERE (IsActive = 1)'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_Select]

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [ProjectId], [TestTypeId], [Name], [IsActive]
FROM [Test]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_Select]

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [ProjectId], [TestTypeId], [Name], [IsActive]
FROM [Test]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_Update]
(
@ProjectId int, 
@TestTypeId int, 
@Name varchar(50), 
@IsActive bit, 
@Id int
  )

  AS
   SET NOCOUNT ON;
UPDATE [Test] SET [ProjectId]=@ProjectId
     , [TestTypeId]=@TestTypeId
     , [Name]=@Name
     , [IsActive]=@IsActive
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_Update]
(
@ProjectId int, 
@TestTypeId int, 
@Name varchar(50), 
@IsActive bit, 
@Id int
  )

  AS
   SET NOCOUNT ON;
   UPDATE [Test] SET [ProjectId]=@ProjectId
     , [TestTypeId]=@TestTypeId
     , [Name]=@Name
     , [IsActive]=@IsActive
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_Delete]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
DELETE 
FROM [Test]
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_Delete]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
   DELETE 
FROM [Test]
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_Insert]
(
@ProjectId int, 
@TestTypeId int, 
@Name varchar(50), 
@IsActive bit
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [Test] ([ProjectId], [TestTypeId], [Name], [IsActive]) VALUES (@ProjectId, @TestTypeId, @Name, @IsActive);SELECT SCOPE_IDENTITY();'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_Insert]
(
@ProjectId int, 
@TestTypeId int, 
@Name varchar(50), 
@IsActive bit
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [Test] ([ProjectId], [TestTypeId], [Name], [IsActive]) VALUES (@ProjectId, @TestTypeId, @Name, @IsActive);SELECT SCOPE_IDENTITY();'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_GetDataPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_GetDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''Id'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [ProjectId], [TestTypeId], [Name], [IsActive] FROM (
    SELECT [Id], [ProjectId], [TestTypeId], [Name], [IsActive],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM Test) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_GetDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''Id'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [ProjectId], [TestTypeId], [Name], [IsActive] FROM (
    SELECT [Id], [ProjectId], [TestTypeId], [Name], [IsActive],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM Test) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Test'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Test'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_GetDataById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_GetDataById]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [ProjectId], [TestTypeId], [Name], [IsActive]
FROM [Test]
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_GetDataById]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [ProjectId], [TestTypeId], [Name], [IsActive]
FROM [Test]
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_GetActiveData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_GetActiveData]

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [ProjectId], [TestTypeId], [Name], [IsActive]
FROM [Test] WHERE (IsActive = 1)'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_GetActiveData]

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [ProjectId], [TestTypeId], [Name], [IsActive]
FROM [Test] WHERE (IsActive = 1)'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_GetActiveDataPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_GetActiveDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@PageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000),  
 @startRowIndex int 

IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''Id''  
 SET @startRowIndex = (@page -1) * @pageSize + 1  
 SET @sql = ''SELECT [Id], [ProjectId], [TestTypeId], [Name], [IsActive] FROM ( 
       SELECT [Id], [ProjectId], [TestTypeId], [Name], [IsActive],
        ROW_NUMBER() OVER (ORDER BY  '' + @SortExpression + '') AS ResultSetRowNumber 
       FROM Test WHERE (IsActive = 1)) AS PagedResults 
     WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1'' 
 -- Execute the SQL query 
EXEC sp_executesql @sql, N'',@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex = @startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_GetActiveDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@PageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000),  
 @startRowIndex int 

IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''Id''  
 SET @startRowIndex = (@page -1) * @pageSize + 1  
 SET @sql = ''SELECT [Id], [ProjectId], [TestTypeId], [Name], [IsActive] FROM ( 
       SELECT [Id], [ProjectId], [TestTypeId], [Name], [IsActive],
        ROW_NUMBER() OVER (ORDER BY  '' + @SortExpression + '') AS ResultSetRowNumber 
       FROM Test WHERE (IsActive = 1)) AS PagedResults 
     WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1'' 
 -- Execute the SQL query 
EXEC sp_executesql @sql, N'',@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex = @startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_GetActiveDataRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_GetActiveDataRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Test WHERE (IsActive = 1)'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_GetActiveDataRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Test WHERE (IsActive = 1)'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_GetTestsForScriptByScriptId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_GetTestsForScriptByScriptId]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
SELECT 
Test.[Id], 
Test.[ProjectId], 
Test.[TestTypeId], 
Test.[Name], 
Test.[IsActive]
FROM [Test] INNER JOIN Test_Script ON Test.[Id] = Test_Script.[TestId]
WHERE Test_Script.[ScriptId] = @Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_GetTestsForScriptByScriptId]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
Test.[Id], 
Test.[ProjectId], 
Test.[TestTypeId], 
Test.[Name], 
Test.[IsActive]
FROM [Test] INNER JOIN Test_Script ON Test.[Id] = Test_Script.[TestId]
WHERE Test_Script.[ScriptId] = @Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_GetDataByProjectId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_GetDataByProjectId]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [ProjectId], [TestTypeId], [Name], [IsActive]
FROM [Test]
WHERE [ProjectId]=@ProjectId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_GetDataByProjectId]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [ProjectId], [TestTypeId], [Name], [IsActive]
FROM [Test]
WHERE [ProjectId]=@ProjectId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_GetDataByProjectIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_GetDataByProjectIdPageable]
(
@ProjectId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''ProjectId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [ProjectId], [TestTypeId], [Name], [IsActive] FROM (
		   SELECT [Id], [ProjectId], [TestTypeId], [Name], [IsActive],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM Test WHERE ProjectId = @INProjectId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INProjectId int,@inStartRowIndex Int,@inPageSize Int'', @INProjectId = @ProjectId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_GetDataByProjectIdPageable]
(
@ProjectId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''ProjectId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [ProjectId], [TestTypeId], [Name], [IsActive] FROM (
		   SELECT [Id], [ProjectId], [TestTypeId], [Name], [IsActive],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM Test WHERE ProjectId = @INProjectId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INProjectId int,@inStartRowIndex Int,@inPageSize Int'', @INProjectId = @ProjectId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_GetDataByProjectIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_GetDataByProjectIdRowCount]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Test
WHERE [ProjectId]=@ProjectId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_GetDataByProjectIdRowCount]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Test
WHERE [ProjectId]=@ProjectId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_GetActiveDataByProjectId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_GetActiveDataByProjectId]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [ProjectId], [TestTypeId], [Name], [IsActive]
FROM [Test] WHERE [IsActive] = 1 and [ProjectId] = @ProjectId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_GetActiveDataByProjectId]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [ProjectId], [TestTypeId], [Name], [IsActive]
FROM [Test] WHERE [IsActive] = 1 and [ProjectId] = @ProjectId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_GetActiveDataByProjectIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_GetActiveDataByProjectIdPageable]
(
@ProjectId int, 
@sortExpression varchar(125), 
@page Int, 
@PageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''ProjectId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [ProjectId], [TestTypeId], [Name], [IsActive] FROM (
     SELECT [Id], [ProjectId], [TestTypeId], [Name], [IsActive], 
      ROW_NUMBER() OVER (ORDER BY  '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM Test WHERE (IsActive = 1) and ProjectId = @INProjectId ) AS PagedResults  WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1'' 
 -- Execute the SQL query 
EXEC sp_executesql @sql, N''@INProjectId int,@inStartRowIndex Int,@inPageSize Int'', @ProjectId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_GetActiveDataByProjectIdPageable]
(
@ProjectId int, 
@sortExpression varchar(125), 
@page Int, 
@PageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''ProjectId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [ProjectId], [TestTypeId], [Name], [IsActive] FROM (
     SELECT [Id], [ProjectId], [TestTypeId], [Name], [IsActive], 
      ROW_NUMBER() OVER (ORDER BY  '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM Test WHERE (IsActive = 1) and ProjectId = @INProjectId ) AS PagedResults  WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1'' 
 -- Execute the SQL query 
EXEC sp_executesql @sql, N''@INProjectId int,@inStartRowIndex Int,@inPageSize Int'', @ProjectId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_GetActiveDataByProjectIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_GetActiveDataByProjectIdRowCount]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Test WHERE (IsActive = 1) and ProjectId = @ProjectId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_GetActiveDataByProjectIdRowCount]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Test WHERE (IsActive = 1) and ProjectId = @ProjectId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_GetDataByTestTypeId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_GetDataByTestTypeId]
(
@TestTypeId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [ProjectId], [TestTypeId], [Name], [IsActive]
FROM [Test]
WHERE [TestTypeId]=@TestTypeId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_GetDataByTestTypeId]
(
@TestTypeId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [ProjectId], [TestTypeId], [Name], [IsActive]
FROM [Test]
WHERE [TestTypeId]=@TestTypeId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_GetDataByTestTypeIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_GetDataByTestTypeIdPageable]
(
@TestTypeId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''TestTypeId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [ProjectId], [TestTypeId], [Name], [IsActive] FROM (
		   SELECT [Id], [ProjectId], [TestTypeId], [Name], [IsActive],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM Test WHERE TestTypeId = @INTestTypeId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INTestTypeId int,@inStartRowIndex Int,@inPageSize Int'', @INTestTypeId = @TestTypeId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_GetDataByTestTypeIdPageable]
(
@TestTypeId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''TestTypeId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [ProjectId], [TestTypeId], [Name], [IsActive] FROM (
		   SELECT [Id], [ProjectId], [TestTypeId], [Name], [IsActive],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM Test WHERE TestTypeId = @INTestTypeId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INTestTypeId int,@inStartRowIndex Int,@inPageSize Int'', @INTestTypeId = @TestTypeId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_GetDataByTestTypeIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_GetDataByTestTypeIdRowCount]
(
@TestTypeId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Test
WHERE [TestTypeId]=@TestTypeId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_GetDataByTestTypeIdRowCount]
(
@TestTypeId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Test
WHERE [TestTypeId]=@TestTypeId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_GetActiveDataByTestTypeId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_GetActiveDataByTestTypeId]
(
@TestTypeId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [ProjectId], [TestTypeId], [Name], [IsActive]
FROM [Test] WHERE [IsActive] = 1 and [TestTypeId] = @TestTypeId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_GetActiveDataByTestTypeId]
(
@TestTypeId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [ProjectId], [TestTypeId], [Name], [IsActive]
FROM [Test] WHERE [IsActive] = 1 and [TestTypeId] = @TestTypeId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_GetActiveDataByTestTypeIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_GetActiveDataByTestTypeIdPageable]
(
@TestTypeId int, 
@sortExpression varchar(125), 
@page Int, 
@PageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''TestTypeId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [ProjectId], [TestTypeId], [Name], [IsActive] FROM (
     SELECT [Id], [ProjectId], [TestTypeId], [Name], [IsActive], 
      ROW_NUMBER() OVER (ORDER BY  '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM Test WHERE (IsActive = 1) and TestTypeId = @INTestTypeId ) AS PagedResults  WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1'' 
 -- Execute the SQL query 
EXEC sp_executesql @sql, N''@INTestTypeId int,@inStartRowIndex Int,@inPageSize Int'', @TestTypeId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_GetActiveDataByTestTypeIdPageable]
(
@TestTypeId int, 
@sortExpression varchar(125), 
@page Int, 
@PageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''TestTypeId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [ProjectId], [TestTypeId], [Name], [IsActive] FROM (
     SELECT [Id], [ProjectId], [TestTypeId], [Name], [IsActive], 
      ROW_NUMBER() OVER (ORDER BY  '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM Test WHERE (IsActive = 1) and TestTypeId = @INTestTypeId ) AS PagedResults  WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1'' 
 -- Execute the SQL query 
EXEC sp_executesql @sql, N''@INTestTypeId int,@inStartRowIndex Int,@inPageSize Int'', @TestTypeId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_GetActiveDataByTestTypeIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_GetActiveDataByTestTypeIdRowCount]
(
@TestTypeId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Test WHERE (IsActive = 1) and TestTypeId = @TestTypeId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_GetActiveDataByTestTypeIdRowCount]
(
@TestTypeId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Test WHERE (IsActive = 1) and TestTypeId = @TestTypeId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_Script_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_Script_Select]

  AS
   SET NOCOUNT ON;
SELECT 
     [TestId], [ScriptId]
FROM [Test_Script]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_Script_Select]

  AS
   SET NOCOUNT ON;
   SELECT 
     [TestId], [ScriptId]
FROM [Test_Script]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_Script_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_Script_Update]
(
@TestId int, 
@ScriptId int, 
@Original_TestId int, 
@Original_ScriptId int
  )

  AS
   SET NOCOUNT ON;
UPDATE [Test_Script] SET [TestId]=@TestId
     , [ScriptId]=@ScriptId
WHERE [TestId]=@Original_TestId
  AND [ScriptId]=@Original_ScriptId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_Script_Update]
(
@TestId int, 
@ScriptId int, 
@Original_TestId int, 
@Original_ScriptId int
  )

  AS
   SET NOCOUNT ON;
   UPDATE [Test_Script] SET [TestId]=@TestId
     , [ScriptId]=@ScriptId
WHERE [TestId]=@Original_TestId
  AND [ScriptId]=@Original_ScriptId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_Script_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_Script_Delete]
(
@TestId int, 
@ScriptId int
  )

  AS
   SET NOCOUNT ON;
DELETE 
FROM [Test_Script]
WHERE [TestId]=@TestId
  AND [ScriptId]=@ScriptId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_Script_Delete]
(
@TestId int, 
@ScriptId int
  )

  AS
   SET NOCOUNT ON;
   DELETE 
FROM [Test_Script]
WHERE [TestId]=@TestId
  AND [ScriptId]=@ScriptId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_Script_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_Script_Insert]
(
@TestId int, 
@ScriptId int
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [Test_Script] ([TestId], [ScriptId]) VALUES (@TestId, @ScriptId);SELECT 
     [TestId], [ScriptId]
FROM [Test_Script]
WHERE [TestId]=@TestId
  AND [ScriptId]=@ScriptId;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_Script_Insert]
(
@TestId int, 
@ScriptId int
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [Test_Script] ([TestId], [ScriptId]) VALUES (@TestId, @ScriptId);SELECT 
     [TestId], [ScriptId]
FROM [Test_Script]
WHERE [TestId]=@TestId
  AND [ScriptId]=@ScriptId;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_Script_GetDataPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_Script_GetDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''TestId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [TestId], [ScriptId] FROM (
    SELECT [TestId], [ScriptId],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM Test_Script) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_Script_GetDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''TestId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [TestId], [ScriptId] FROM (
    SELECT [TestId], [ScriptId],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM Test_Script) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_Script_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_Script_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Test_Script'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_Script_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Test_Script'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_Script_GetDataByTestIdScriptId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_Script_GetDataByTestIdScriptId]
(
@TestId int, 
@ScriptId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [TestId], [ScriptId]
FROM [Test_Script]
WHERE [TestId]=@TestId
  AND [ScriptId]=@ScriptId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_Script_GetDataByTestIdScriptId]
(
@TestId int, 
@ScriptId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [TestId], [ScriptId]
FROM [Test_Script]
WHERE [TestId]=@TestId
  AND [ScriptId]=@ScriptId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_Script_GetDataByScriptId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_Script_GetDataByScriptId]
(
@ScriptId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [TestId], [ScriptId]
FROM [Test_Script]
WHERE [ScriptId]=@ScriptId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_Script_GetDataByScriptId]
(
@ScriptId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [TestId], [ScriptId]
FROM [Test_Script]
WHERE [ScriptId]=@ScriptId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_Script_GetDataByScriptIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_Script_GetDataByScriptIdPageable]
(
@ScriptId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''ScriptId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [TestId], [ScriptId] FROM (
		   SELECT [TestId], [ScriptId],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM Test_Script WHERE ScriptId = @INScriptId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INScriptId int,@inStartRowIndex Int,@inPageSize Int'', @INScriptId = @ScriptId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_Script_GetDataByScriptIdPageable]
(
@ScriptId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''ScriptId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [TestId], [ScriptId] FROM (
		   SELECT [TestId], [ScriptId],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM Test_Script WHERE ScriptId = @INScriptId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INScriptId int,@inStartRowIndex Int,@inPageSize Int'', @INScriptId = @ScriptId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_Script_GetDataByScriptIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_Script_GetDataByScriptIdRowCount]
(
@ScriptId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Test_Script
WHERE [ScriptId]=@ScriptId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_Script_GetDataByScriptIdRowCount]
(
@ScriptId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Test_Script
WHERE [ScriptId]=@ScriptId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_Script_GetDataByTestId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_Script_GetDataByTestId]
(
@TestId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [TestId], [ScriptId]
FROM [Test_Script]
WHERE [TestId]=@TestId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_Script_GetDataByTestId]
(
@TestId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [TestId], [ScriptId]
FROM [Test_Script]
WHERE [TestId]=@TestId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_Script_GetDataByTestIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_Script_GetDataByTestIdPageable]
(
@TestId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''TestId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [TestId], [ScriptId] FROM (
		   SELECT [TestId], [ScriptId],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM Test_Script WHERE TestId = @INTestId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INTestId int,@inStartRowIndex Int,@inPageSize Int'', @INTestId = @TestId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_Script_GetDataByTestIdPageable]
(
@TestId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000), 
@startRowIndex int 

IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
IF LEN(@sortExpression) = 0 SET @sortExpression = ''TestId'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [TestId], [ScriptId] FROM (
		   SELECT [TestId], [ScriptId],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM Test_Script WHERE TestId = @INTestId) AS PagedResults
		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1''
-- Execute the SQL query
EXEC sp_executesql @sql, N''@INTestId int,@inStartRowIndex Int,@inPageSize Int'', @INTestId = @TestId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_Script_GetDataByTestIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_Script_GetDataByTestIdRowCount]
(
@TestId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Test_Script
WHERE [TestId]=@TestId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_Script_GetDataByTestIdRowCount]
(
@TestId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Test_Script
WHERE [TestId]=@TestId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestType_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[TestType_Select]

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [Name], [IsActive]
FROM [TestType]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[TestType_Select]

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [Name], [IsActive]
FROM [TestType]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestType_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[TestType_Update]
(
@Name varchar(50), 
@IsActive bit, 
@Id int
  )

  AS
   SET NOCOUNT ON;
UPDATE [TestType] SET [Name]=@Name
     , [IsActive]=@IsActive
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[TestType_Update]
(
@Name varchar(50), 
@IsActive bit, 
@Id int
  )

  AS
   SET NOCOUNT ON;
   UPDATE [TestType] SET [Name]=@Name
     , [IsActive]=@IsActive
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestType_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[TestType_Delete]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
DELETE 
FROM [TestType]
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[TestType_Delete]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
   DELETE 
FROM [TestType]
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestType_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[TestType_Insert]
(
@Name varchar(50), 
@IsActive bit
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [TestType] ([Name], [IsActive]) VALUES (@Name, @IsActive);SELECT SCOPE_IDENTITY();'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[TestType_Insert]
(
@Name varchar(50), 
@IsActive bit
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [TestType] ([Name], [IsActive]) VALUES (@Name, @IsActive);SELECT SCOPE_IDENTITY();'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestType_GetDataPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[TestType_GetDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''Id'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [Name], [IsActive] FROM (
    SELECT [Id], [Name], [IsActive],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM TestType) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[TestType_GetDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000),  
 @startRowIndex int 
IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''Id'' 
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [Name], [IsActive] FROM (
    SELECT [Id], [Name], [IsActive],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM TestType) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestType_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[TestType_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM TestType'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[TestType_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM TestType'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestType_GetDataById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[TestType_GetDataById]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [Name], [IsActive]
FROM [TestType]
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[TestType_GetDataById]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [Name], [IsActive]
FROM [TestType]
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestType_GetActiveData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[TestType_GetActiveData]

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [Name], [IsActive]
FROM [TestType] WHERE (IsActive = 1)'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[TestType_GetActiveData]

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [Name], [IsActive]
FROM [TestType] WHERE (IsActive = 1)'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestType_GetActiveDataPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[TestType_GetActiveDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@PageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000),  
 @startRowIndex int 

IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''Id''  
 SET @startRowIndex = (@page -1) * @pageSize + 1  
 SET @sql = ''SELECT [Id], [Name], [IsActive] FROM ( 
       SELECT [Id], [Name], [IsActive],
        ROW_NUMBER() OVER (ORDER BY  '' + @SortExpression + '') AS ResultSetRowNumber 
       FROM TestType WHERE (IsActive = 1)) AS PagedResults 
     WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1'' 
 -- Execute the SQL query 
EXEC sp_executesql @sql, N'',@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex = @startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[TestType_GetActiveDataPageable]
(
@sortExpression varchar(125), 
@page Int, 
@PageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000),  
 @startRowIndex int 

IF @page < 1 SET @page = 1  
 IF @pageSize < 1 SET @pageSize = 10  
 IF LEN(@sortExpression) = 0 SET @sortExpression = ''Id''  
 SET @startRowIndex = (@page -1) * @pageSize + 1  
 SET @sql = ''SELECT [Id], [Name], [IsActive] FROM ( 
       SELECT [Id], [Name], [IsActive],
        ROW_NUMBER() OVER (ORDER BY  '' + @SortExpression + '') AS ResultSetRowNumber 
       FROM TestType WHERE (IsActive = 1)) AS PagedResults 
     WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1'' 
 -- Execute the SQL query 
EXEC sp_executesql @sql, N'',@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex = @startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestType_GetActiveDataRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[TestType_GetActiveDataRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM TestType WHERE (IsActive = 1)'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[TestType_GetActiveDataRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM TestType WHERE (IsActive = 1)'
  END
GO
