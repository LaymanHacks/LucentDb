
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')     
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')     
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
     [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive]
FROM [Connection]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Connection_Select]

  AS
   SET NOCOUNT ON;
   SELECT 
     [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive]
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
@ProjectId int, 
@ConnectionProviderId int, 
@Name varchar(50), 
@ConnectionString varchar(500), 
@IsDefault bit, 
@IsActive bit, 
@ConnectionId int
  )

  AS
   SET NOCOUNT ON;
UPDATE [Connection] SET [ProjectId]=@ProjectId
     , [ConnectionProviderId]=@ConnectionProviderId
     , [Name]=@Name
     , [ConnectionString]=@ConnectionString
     , [IsDefault]=@IsDefault
     , [IsActive]=@IsActive
WHERE [ConnectionId]=@ConnectionId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Connection_Update]
(
@ProjectId int, 
@ConnectionProviderId int, 
@Name varchar(50), 
@ConnectionString varchar(500), 
@IsDefault bit, 
@IsActive bit, 
@ConnectionId int
  )

  AS
   SET NOCOUNT ON;
   UPDATE [Connection] SET [ProjectId]=@ProjectId
     , [ConnectionProviderId]=@ConnectionProviderId
     , [Name]=@Name
     , [ConnectionString]=@ConnectionString
     , [IsDefault]=@IsDefault
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
@ProjectId int, 
@ConnectionProviderId int, 
@Name varchar(50), 
@ConnectionString varchar(500), 
@IsDefault bit, 
@IsActive bit
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [Connection] ([ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive]) VALUES (@ProjectId, @ConnectionProviderId, @Name, @ConnectionString, @IsDefault, @IsActive);SELECT SCOPE_IDENTITY();'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Connection_Insert]
(
@ProjectId int, 
@ConnectionProviderId int, 
@Name varchar(50), 
@ConnectionString varchar(500), 
@IsDefault bit, 
@IsActive bit
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [Connection] ([ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive]) VALUES (@ProjectId, @ConnectionProviderId, @Name, @ConnectionString, @IsDefault, @IsActive);SELECT SCOPE_IDENTITY();'
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ConnectionId'')     
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive] FROM (
    SELECT [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive],
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ConnectionId'')     
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive] FROM (
    SELECT [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive],
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
     [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive]
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
     [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive]
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
     [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive]
FROM [Connection] WHERE (IsActive = 1)'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Connection_GetActiveData]

  AS
   SET NOCOUNT ON;
   SELECT 
     [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive]
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ConnectionId'')  
  SET @startRowIndex = (@page -1) * @pageSize + 1  
 SET @sql = ''SELECT [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive] FROM ( 
       SELECT [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive],
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ConnectionId'')  
  SET @startRowIndex = (@page -1) * @pageSize + 1  
 SET @sql = ''SELECT [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive] FROM ( 
       SELECT [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive],
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Connection_GetDataByConnectionProviderId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Connection_GetDataByConnectionProviderId]
(
@ConnectionProviderId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive]
FROM [Connection]
WHERE [ConnectionProviderId]=@ConnectionProviderId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Connection_GetDataByConnectionProviderId]
(
@ConnectionProviderId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive]
FROM [Connection]
WHERE [ConnectionProviderId]=@ConnectionProviderId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Connection_GetDataByConnectionProviderIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Connection_GetDataByConnectionProviderIdPageable]
(
@ConnectionProviderId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000),  @startRowIndex int 
IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ConnectionProviderId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive] FROM (
		   SELECT [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM Connection WHERE ConnectionProviderId = @INConnectionProviderId) AS PagedResults 
 		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1'' 
-- Execute the SQL query 
EXEC sp_executesql @sql, N''@INConnectionProviderId int,@inStartRowIndex Int,@inPageSize Int'', @INConnectionProviderId = @ConnectionProviderId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Connection_GetDataByConnectionProviderIdPageable]
(
@ConnectionProviderId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000),  @startRowIndex int 
IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ConnectionProviderId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive] FROM (
		   SELECT [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM Connection WHERE ConnectionProviderId = @INConnectionProviderId) AS PagedResults 
 		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1'' 
-- Execute the SQL query 
EXEC sp_executesql @sql, N''@INConnectionProviderId int,@inStartRowIndex Int,@inPageSize Int'', @INConnectionProviderId = @ConnectionProviderId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Connection_GetDataByConnectionProviderIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Connection_GetDataByConnectionProviderIdRowCount]
(
@ConnectionProviderId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Connection
WHERE [ConnectionProviderId]=@ConnectionProviderId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Connection_GetDataByConnectionProviderIdRowCount]
(
@ConnectionProviderId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Connection
WHERE [ConnectionProviderId]=@ConnectionProviderId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Connection_GetActiveDataByConnectionProviderId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Connection_GetActiveDataByConnectionProviderId]
(
@ConnectionProviderId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive]
FROM [Connection] WHERE [IsActive] = 1 and [ConnectionProviderId] = @ConnectionProviderId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Connection_GetActiveDataByConnectionProviderId]
(
@ConnectionProviderId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive]
FROM [Connection] WHERE [IsActive] = 1 and [ConnectionProviderId] = @ConnectionProviderId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Connection_GetActiveDataByConnectionProviderIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Connection_GetActiveDataByConnectionProviderIdPageable]
(
@ConnectionProviderId int, 
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
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ConnectionProviderId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive] FROM (
     SELECT [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive], 
      ROW_NUMBER() OVER (ORDER BY  '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM Connection WHERE (IsActive = 1) and ConnectionProviderId = @INConnectionProviderId ) AS PagedResults  WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1'' 
 -- Execute the SQL query 
EXEC sp_executesql @sql, N''@INConnectionProviderId int,@inStartRowIndex Int,@inPageSize Int'', @ConnectionProviderId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Connection_GetActiveDataByConnectionProviderIdPageable]
(
@ConnectionProviderId int, 
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
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ConnectionProviderId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive] FROM (
     SELECT [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive], 
      ROW_NUMBER() OVER (ORDER BY  '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM Connection WHERE (IsActive = 1) and ConnectionProviderId = @INConnectionProviderId ) AS PagedResults  WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1'' 
 -- Execute the SQL query 
EXEC sp_executesql @sql, N''@INConnectionProviderId int,@inStartRowIndex Int,@inPageSize Int'', @ConnectionProviderId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Connection_GetActiveDataByConnectionProviderIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Connection_GetActiveDataByConnectionProviderIdRowCount]
(
@ConnectionProviderId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Connection WHERE (IsActive = 1) and ConnectionProviderId = @ConnectionProviderId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Connection_GetActiveDataByConnectionProviderIdRowCount]
(
@ConnectionProviderId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Connection WHERE (IsActive = 1) and ConnectionProviderId = @ConnectionProviderId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Connection_GetDataByProjectId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Connection_GetDataByProjectId]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive]
FROM [Connection]
WHERE [ProjectId]=@ProjectId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Connection_GetDataByProjectId]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive]
FROM [Connection]
WHERE [ProjectId]=@ProjectId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Connection_GetDataByProjectIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Connection_GetDataByProjectIdPageable]
(
@ProjectId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000),  @startRowIndex int 
IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ProjectId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive] FROM (
		   SELECT [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM Connection WHERE ProjectId = @INProjectId) AS PagedResults 
 		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1'' 
-- Execute the SQL query 
EXEC sp_executesql @sql, N''@INProjectId int,@inStartRowIndex Int,@inPageSize Int'', @INProjectId = @ProjectId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Connection_GetDataByProjectIdPageable]
(
@ProjectId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000),  @startRowIndex int 
IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ProjectId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive] FROM (
		   SELECT [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM Connection WHERE ProjectId = @INProjectId) AS PagedResults 
 		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1'' 
-- Execute the SQL query 
EXEC sp_executesql @sql, N''@INProjectId int,@inStartRowIndex Int,@inPageSize Int'', @INProjectId = @ProjectId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Connection_GetDataByProjectIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Connection_GetDataByProjectIdRowCount]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Connection
WHERE [ProjectId]=@ProjectId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Connection_GetDataByProjectIdRowCount]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Connection
WHERE [ProjectId]=@ProjectId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Connection_GetActiveDataByProjectId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Connection_GetActiveDataByProjectId]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive]
FROM [Connection] WHERE [IsActive] = 1 and [ProjectId] = @ProjectId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Connection_GetActiveDataByProjectId]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive]
FROM [Connection] WHERE [IsActive] = 1 and [ProjectId] = @ProjectId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Connection_GetActiveDataByProjectIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Connection_GetActiveDataByProjectIdPageable]
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
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ProjectId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive] FROM (
     SELECT [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive], 
      ROW_NUMBER() OVER (ORDER BY  '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM Connection WHERE (IsActive = 1) and ProjectId = @INProjectId ) AS PagedResults  WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1'' 
 -- Execute the SQL query 
EXEC sp_executesql @sql, N''@INProjectId int,@inStartRowIndex Int,@inPageSize Int'', @ProjectId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Connection_GetActiveDataByProjectIdPageable]
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
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ProjectId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive] FROM (
     SELECT [ConnectionId], [ProjectId], [ConnectionProviderId], [Name], [ConnectionString], [IsDefault], [IsActive], 
      ROW_NUMBER() OVER (ORDER BY  '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM Connection WHERE (IsActive = 1) and ProjectId = @INProjectId ) AS PagedResults  WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1'' 
 -- Execute the SQL query 
EXEC sp_executesql @sql, N''@INProjectId int,@inStartRowIndex Int,@inPageSize Int'', @ProjectId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Connection_GetActiveDataByProjectIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Connection_GetActiveDataByProjectIdRowCount]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Connection WHERE (IsActive = 1) and ProjectId = @ProjectId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Connection_GetActiveDataByProjectIdRowCount]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Connection WHERE (IsActive = 1) and ProjectId = @ProjectId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ConnectionProvider_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ConnectionProvider_Select]

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [Name], [Value]
FROM [ConnectionProvider]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ConnectionProvider_Select]

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [Name], [Value]
FROM [ConnectionProvider]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ConnectionProvider_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ConnectionProvider_Update]
(
@Name varchar(50), 
@Value varchar(50), 
@Id int
  )

  AS
   SET NOCOUNT ON;
UPDATE [ConnectionProvider] SET [Name]=@Name
     , [Value]=@Value
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ConnectionProvider_Update]
(
@Name varchar(50), 
@Value varchar(50), 
@Id int
  )

  AS
   SET NOCOUNT ON;
   UPDATE [ConnectionProvider] SET [Name]=@Name
     , [Value]=@Value
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ConnectionProvider_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ConnectionProvider_Delete]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
DELETE 
FROM [ConnectionProvider]
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ConnectionProvider_Delete]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
   DELETE 
FROM [ConnectionProvider]
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ConnectionProvider_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ConnectionProvider_Insert]
(
@Name varchar(50), 
@Value varchar(50)
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [ConnectionProvider] ([Name], [Value]) VALUES (@Name, @Value);SELECT SCOPE_IDENTITY();'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ConnectionProvider_Insert]
(
@Name varchar(50), 
@Value varchar(50)
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [ConnectionProvider] ([Name], [Value]) VALUES (@Name, @Value);SELECT SCOPE_IDENTITY();'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ConnectionProvider_GetDataPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ConnectionProvider_GetDataPageable]
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')     
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [Name], [Value] FROM (
    SELECT [Id], [Name], [Value],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM ConnectionProvider) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ConnectionProvider_GetDataPageable]
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')     
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [Name], [Value] FROM (
    SELECT [Id], [Name], [Value],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM ConnectionProvider) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ConnectionProvider_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ConnectionProvider_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM ConnectionProvider'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ConnectionProvider_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM ConnectionProvider'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ConnectionProvider_GetDataById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ConnectionProvider_GetDataById]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [Name], [Value]
FROM [ConnectionProvider]
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ConnectionProvider_GetDataById]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [Name], [Value]
FROM [ConnectionProvider]
WHERE [Id]=@Id'
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
     [Id], [TestId], [ExpectedResultTypeId], [AssertTypeId], [ExpectedValue], [ResultIndex]
FROM [ExpectedResult]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ExpectedResult_Select]

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [TestId], [ExpectedResultTypeId], [AssertTypeId], [ExpectedValue], [ResultIndex]
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
@TestId int, 
@ExpectedResultTypeId int, 
@AssertTypeId int, 
@ExpectedValue varchar(50), 
@ResultIndex int, 
@Id int
  )

  AS
   SET NOCOUNT ON;
UPDATE [ExpectedResult] SET [TestId]=@TestId
     , [ExpectedResultTypeId]=@ExpectedResultTypeId
     , [AssertTypeId]=@AssertTypeId
     , [ExpectedValue]=@ExpectedValue
     , [ResultIndex]=@ResultIndex
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ExpectedResult_Update]
(
@TestId int, 
@ExpectedResultTypeId int, 
@AssertTypeId int, 
@ExpectedValue varchar(50), 
@ResultIndex int, 
@Id int
  )

  AS
   SET NOCOUNT ON;
   UPDATE [ExpectedResult] SET [TestId]=@TestId
     , [ExpectedResultTypeId]=@ExpectedResultTypeId
     , [AssertTypeId]=@AssertTypeId
     , [ExpectedValue]=@ExpectedValue
     , [ResultIndex]=@ResultIndex
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
@TestId int, 
@ExpectedResultTypeId int, 
@AssertTypeId int, 
@ExpectedValue varchar(50), 
@ResultIndex int
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [ExpectedResult] ([TestId], [ExpectedResultTypeId], [AssertTypeId], [ExpectedValue], [ResultIndex]) VALUES (@TestId, @ExpectedResultTypeId, @AssertTypeId, @ExpectedValue, @ResultIndex);SELECT SCOPE_IDENTITY();'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ExpectedResult_Insert]
(
@TestId int, 
@ExpectedResultTypeId int, 
@AssertTypeId int, 
@ExpectedValue varchar(50), 
@ResultIndex int
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [ExpectedResult] ([TestId], [ExpectedResultTypeId], [AssertTypeId], [ExpectedValue], [ResultIndex]) VALUES (@TestId, @ExpectedResultTypeId, @AssertTypeId, @ExpectedValue, @ResultIndex);SELECT SCOPE_IDENTITY();'
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')     
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [TestId], [ExpectedResultTypeId], [AssertTypeId], [ExpectedValue], [ResultIndex] FROM (
    SELECT [Id], [TestId], [ExpectedResultTypeId], [AssertTypeId], [ExpectedValue], [ResultIndex],
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')     
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [TestId], [ExpectedResultTypeId], [AssertTypeId], [ExpectedValue], [ResultIndex] FROM (
    SELECT [Id], [TestId], [ExpectedResultTypeId], [AssertTypeId], [ExpectedValue], [ResultIndex],
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
     [Id], [TestId], [ExpectedResultTypeId], [AssertTypeId], [ExpectedValue], [ResultIndex]
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
     [Id], [TestId], [ExpectedResultTypeId], [AssertTypeId], [ExpectedValue], [ResultIndex]
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
     [Id], [TestId], [ExpectedResultTypeId], [AssertTypeId], [ExpectedValue], [ResultIndex]
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
     [Id], [TestId], [ExpectedResultTypeId], [AssertTypeId], [ExpectedValue], [ResultIndex]
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
DECLARE @sql nvarchar(4000),  @startRowIndex int 
IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''AssertTypeId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [TestId], [ExpectedResultTypeId], [AssertTypeId], [ExpectedValue], [ResultIndex] FROM (
		   SELECT [Id], [TestId], [ExpectedResultTypeId], [AssertTypeId], [ExpectedValue], [ResultIndex],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
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
   DECLARE @sql nvarchar(4000),  @startRowIndex int 
IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''AssertTypeId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [TestId], [ExpectedResultTypeId], [AssertTypeId], [ExpectedValue], [ResultIndex] FROM (
		   SELECT [Id], [TestId], [ExpectedResultTypeId], [AssertTypeId], [ExpectedValue], [ResultIndex],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpectedResult_GetDataByExpectedResultTypeId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ExpectedResult_GetDataByExpectedResultTypeId]
(
@ExpectedResultTypeId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [TestId], [ExpectedResultTypeId], [AssertTypeId], [ExpectedValue], [ResultIndex]
FROM [ExpectedResult]
WHERE [ExpectedResultTypeId]=@ExpectedResultTypeId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ExpectedResult_GetDataByExpectedResultTypeId]
(
@ExpectedResultTypeId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [TestId], [ExpectedResultTypeId], [AssertTypeId], [ExpectedValue], [ResultIndex]
FROM [ExpectedResult]
WHERE [ExpectedResultTypeId]=@ExpectedResultTypeId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpectedResult_GetDataByExpectedResultTypeIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ExpectedResult_GetDataByExpectedResultTypeIdPageable]
(
@ExpectedResultTypeId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000),  @startRowIndex int 
IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ExpectedResultTypeId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [TestId], [ExpectedResultTypeId], [AssertTypeId], [ExpectedValue], [ResultIndex] FROM (
		   SELECT [Id], [TestId], [ExpectedResultTypeId], [AssertTypeId], [ExpectedValue], [ResultIndex],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM ExpectedResult WHERE ExpectedResultTypeId = @INExpectedResultTypeId) AS PagedResults 
 		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1'' 
-- Execute the SQL query 
EXEC sp_executesql @sql, N''@INExpectedResultTypeId int,@inStartRowIndex Int,@inPageSize Int'', @INExpectedResultTypeId = @ExpectedResultTypeId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ExpectedResult_GetDataByExpectedResultTypeIdPageable]
(
@ExpectedResultTypeId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000),  @startRowIndex int 
IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ExpectedResultTypeId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [TestId], [ExpectedResultTypeId], [AssertTypeId], [ExpectedValue], [ResultIndex] FROM (
		   SELECT [Id], [TestId], [ExpectedResultTypeId], [AssertTypeId], [ExpectedValue], [ResultIndex],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM ExpectedResult WHERE ExpectedResultTypeId = @INExpectedResultTypeId) AS PagedResults 
 		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1'' 
-- Execute the SQL query 
EXEC sp_executesql @sql, N''@INExpectedResultTypeId int,@inStartRowIndex Int,@inPageSize Int'', @INExpectedResultTypeId = @ExpectedResultTypeId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpectedResult_GetDataByExpectedResultTypeIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ExpectedResult_GetDataByExpectedResultTypeIdRowCount]
(
@ExpectedResultTypeId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM ExpectedResult
WHERE [ExpectedResultTypeId]=@ExpectedResultTypeId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ExpectedResult_GetDataByExpectedResultTypeIdRowCount]
(
@ExpectedResultTypeId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM ExpectedResult
WHERE [ExpectedResultTypeId]=@ExpectedResultTypeId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpectedResult_GetDataByTestId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ExpectedResult_GetDataByTestId]
(
@TestId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [TestId], [ExpectedResultTypeId], [AssertTypeId], [ExpectedValue], [ResultIndex]
FROM [ExpectedResult]
WHERE [TestId]=@TestId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ExpectedResult_GetDataByTestId]
(
@TestId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [TestId], [ExpectedResultTypeId], [AssertTypeId], [ExpectedValue], [ResultIndex]
FROM [ExpectedResult]
WHERE [TestId]=@TestId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpectedResult_GetDataByTestIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ExpectedResult_GetDataByTestIdPageable]
(
@TestId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000),  @startRowIndex int 
IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''TestId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [TestId], [ExpectedResultTypeId], [AssertTypeId], [ExpectedValue], [ResultIndex] FROM (
		   SELECT [Id], [TestId], [ExpectedResultTypeId], [AssertTypeId], [ExpectedValue], [ResultIndex],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM ExpectedResult WHERE TestId = @INTestId) AS PagedResults 
 		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1'' 
-- Execute the SQL query 
EXEC sp_executesql @sql, N''@INTestId int,@inStartRowIndex Int,@inPageSize Int'', @INTestId = @TestId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ExpectedResult_GetDataByTestIdPageable]
(
@TestId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000),  @startRowIndex int 
IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''TestId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [TestId], [ExpectedResultTypeId], [AssertTypeId], [ExpectedValue], [ResultIndex] FROM (
		   SELECT [Id], [TestId], [ExpectedResultTypeId], [AssertTypeId], [ExpectedValue], [ResultIndex],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM ExpectedResult WHERE TestId = @INTestId) AS PagedResults 
 		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1'' 
-- Execute the SQL query 
EXEC sp_executesql @sql, N''@INTestId int,@inStartRowIndex Int,@inPageSize Int'', @INTestId = @TestId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpectedResult_GetDataByTestIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ExpectedResult_GetDataByTestIdRowCount]
(
@TestId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM ExpectedResult
WHERE [TestId]=@TestId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ExpectedResult_GetDataByTestIdRowCount]
(
@TestId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM ExpectedResult
WHERE [TestId]=@TestId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpectedResultType_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ExpectedResultType_Select]

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [Name]
FROM [ExpectedResultType]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ExpectedResultType_Select]

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [Name]
FROM [ExpectedResultType]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpectedResultType_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ExpectedResultType_Update]
(
@Name varchar(50), 
@Id int
  )

  AS
   SET NOCOUNT ON;
UPDATE [ExpectedResultType] SET [Name]=@Name
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ExpectedResultType_Update]
(
@Name varchar(50), 
@Id int
  )

  AS
   SET NOCOUNT ON;
   UPDATE [ExpectedResultType] SET [Name]=@Name
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpectedResultType_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ExpectedResultType_Delete]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
DELETE 
FROM [ExpectedResultType]
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ExpectedResultType_Delete]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
   DELETE 
FROM [ExpectedResultType]
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpectedResultType_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ExpectedResultType_Insert]
(
@Name varchar(50)
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [ExpectedResultType] ([Name]) VALUES (@Name);SELECT SCOPE_IDENTITY();'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ExpectedResultType_Insert]
(
@Name varchar(50)
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [ExpectedResultType] ([Name]) VALUES (@Name);SELECT SCOPE_IDENTITY();'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpectedResultType_GetDataPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ExpectedResultType_GetDataPageable]
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')     
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [Name] FROM (
    SELECT [Id], [Name],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM ExpectedResultType) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ExpectedResultType_GetDataPageable]
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')     
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [Name] FROM (
    SELECT [Id], [Name],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM ExpectedResultType) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpectedResultType_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ExpectedResultType_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM ExpectedResultType'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ExpectedResultType_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM ExpectedResultType'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpectedResultType_GetDataById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ExpectedResultType_GetDataById]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [Name]
FROM [ExpectedResultType]
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ExpectedResultType_GetDataById]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [Name]
FROM [ExpectedResultType]
WHERE [Id]=@Id'
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ProjectId'')     
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ProjectId'')     
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ProjectId'')  
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ProjectId'')  
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RunHistory_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[RunHistory_Select]

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [TestId], [ProjectId], [GroupId], [RunDateTime], [IsValid], [RunLog]
FROM [RunHistory]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[RunHistory_Select]

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [TestId], [ProjectId], [GroupId], [RunDateTime], [IsValid], [RunLog]
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
@TestId int, 
@ProjectId int, 
@GroupId int, 
@RunDateTime datetime, 
@IsValid bit, 
@RunLog text, 
@Id bigint
  )

  AS
   SET NOCOUNT ON;
UPDATE [RunHistory] SET [TestId]=@TestId
     , [ProjectId]=@ProjectId
     , [GroupId]=@GroupId
     , [RunDateTime]=@RunDateTime
     , [IsValid]=@IsValid
     , [RunLog]=@RunLog
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[RunHistory_Update]
(
@TestId int, 
@ProjectId int, 
@GroupId int, 
@RunDateTime datetime, 
@IsValid bit, 
@RunLog text, 
@Id bigint
  )

  AS
   SET NOCOUNT ON;
   UPDATE [RunHistory] SET [TestId]=@TestId
     , [ProjectId]=@ProjectId
     , [GroupId]=@GroupId
     , [RunDateTime]=@RunDateTime
     , [IsValid]=@IsValid
     , [RunLog]=@RunLog
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
@TestId int, 
@ProjectId int, 
@GroupId int, 
@RunDateTime datetime, 
@IsValid bit, 
@RunLog text
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [RunHistory] ([TestId], [ProjectId], [GroupId], [RunDateTime], [IsValid], [RunLog]) VALUES (@TestId, @ProjectId, @GroupId, @RunDateTime, @IsValid, @RunLog);SELECT SCOPE_IDENTITY();'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[RunHistory_Insert]
(
@TestId int, 
@ProjectId int, 
@GroupId int, 
@RunDateTime datetime, 
@IsValid bit, 
@RunLog text
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [RunHistory] ([TestId], [ProjectId], [GroupId], [RunDateTime], [IsValid], [RunLog]) VALUES (@TestId, @ProjectId, @GroupId, @RunDateTime, @IsValid, @RunLog);SELECT SCOPE_IDENTITY();'
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')     
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [TestId], [ProjectId], [GroupId], [RunDateTime], [IsValid], [RunLog] FROM (
    SELECT [Id], [TestId], [ProjectId], [GroupId], [RunDateTime], [IsValid], [RunLog],
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')     
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [TestId], [ProjectId], [GroupId], [RunDateTime], [IsValid], [RunLog] FROM (
    SELECT [Id], [TestId], [ProjectId], [GroupId], [RunDateTime], [IsValid], [RunLog],
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
     [Id], [TestId], [ProjectId], [GroupId], [RunDateTime], [IsValid], [RunLog]
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
     [Id], [TestId], [ProjectId], [GroupId], [RunDateTime], [IsValid], [RunLog]
FROM [RunHistory]
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RunHistory_GetDataByTestId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[RunHistory_GetDataByTestId]
(
@TestId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [TestId], [ProjectId], [GroupId], [RunDateTime], [IsValid], [RunLog]
FROM [RunHistory]
WHERE [TestId]=@TestId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[RunHistory_GetDataByTestId]
(
@TestId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [TestId], [ProjectId], [GroupId], [RunDateTime], [IsValid], [RunLog]
FROM [RunHistory]
WHERE [TestId]=@TestId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RunHistory_GetDataByTestIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[RunHistory_GetDataByTestIdPageable]
(
@TestId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000),  @startRowIndex int 
IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''TestId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [TestId], [ProjectId], [GroupId], [RunDateTime], [IsValid], [RunLog] FROM (
		   SELECT [Id], [TestId], [ProjectId], [GroupId], [RunDateTime], [IsValid], [RunLog],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM RunHistory WHERE TestId = @INTestId) AS PagedResults 
 		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1'' 
-- Execute the SQL query 
EXEC sp_executesql @sql, N''@INTestId int,@inStartRowIndex Int,@inPageSize Int'', @INTestId = @TestId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[RunHistory_GetDataByTestIdPageable]
(
@TestId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000),  @startRowIndex int 
IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''TestId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [TestId], [ProjectId], [GroupId], [RunDateTime], [IsValid], [RunLog] FROM (
		   SELECT [Id], [TestId], [ProjectId], [GroupId], [RunDateTime], [IsValid], [RunLog],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM RunHistory WHERE TestId = @INTestId) AS PagedResults 
 		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1'' 
-- Execute the SQL query 
EXEC sp_executesql @sql, N''@INTestId int,@inStartRowIndex Int,@inPageSize Int'', @INTestId = @TestId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RunHistory_GetDataByTestIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[RunHistory_GetDataByTestIdRowCount]
(
@TestId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM RunHistory
WHERE [TestId]=@TestId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[RunHistory_GetDataByTestIdRowCount]
(
@TestId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM RunHistory
WHERE [TestId]=@TestId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RunHistoryDetail_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[RunHistoryDetail_Select]

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [RunHistoryId], [TestId], [RunDateTime], [IsValid], [ResultString]
FROM [RunHistoryDetail]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[RunHistoryDetail_Select]

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [RunHistoryId], [TestId], [RunDateTime], [IsValid], [ResultString]
FROM [RunHistoryDetail]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RunHistoryDetail_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[RunHistoryDetail_Update]
(
@RunHistoryId bigint, 
@TestId int, 
@RunDateTime datetime, 
@IsValid bit, 
@ResultString varchar(1000), 
@Id bigint
  )

  AS
   SET NOCOUNT ON;
UPDATE [RunHistoryDetail] SET [RunHistoryId]=@RunHistoryId
     , [TestId]=@TestId
     , [RunDateTime]=@RunDateTime
     , [IsValid]=@IsValid
     , [ResultString]=@ResultString
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[RunHistoryDetail_Update]
(
@RunHistoryId bigint, 
@TestId int, 
@RunDateTime datetime, 
@IsValid bit, 
@ResultString varchar(1000), 
@Id bigint
  )

  AS
   SET NOCOUNT ON;
   UPDATE [RunHistoryDetail] SET [RunHistoryId]=@RunHistoryId
     , [TestId]=@TestId
     , [RunDateTime]=@RunDateTime
     , [IsValid]=@IsValid
     , [ResultString]=@ResultString
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RunHistoryDetail_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[RunHistoryDetail_Delete]
(
@Id bigint
  )

  AS
   SET NOCOUNT ON;
DELETE 
FROM [RunHistoryDetail]
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[RunHistoryDetail_Delete]
(
@Id bigint
  )

  AS
   SET NOCOUNT ON;
   DELETE 
FROM [RunHistoryDetail]
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RunHistoryDetail_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[RunHistoryDetail_Insert]
(
@RunHistoryId bigint, 
@TestId int, 
@RunDateTime datetime, 
@IsValid bit, 
@ResultString varchar(1000)
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [RunHistoryDetail] ([RunHistoryId], [TestId], [RunDateTime], [IsValid], [ResultString]) VALUES (@RunHistoryId, @TestId, @RunDateTime, @IsValid, @ResultString);SELECT SCOPE_IDENTITY();'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[RunHistoryDetail_Insert]
(
@RunHistoryId bigint, 
@TestId int, 
@RunDateTime datetime, 
@IsValid bit, 
@ResultString varchar(1000)
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [RunHistoryDetail] ([RunHistoryId], [TestId], [RunDateTime], [IsValid], [ResultString]) VALUES (@RunHistoryId, @TestId, @RunDateTime, @IsValid, @ResultString);SELECT SCOPE_IDENTITY();'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RunHistoryDetail_GetDataPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[RunHistoryDetail_GetDataPageable]
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')     
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [RunHistoryId], [TestId], [RunDateTime], [IsValid], [ResultString] FROM (
    SELECT [Id], [RunHistoryId], [TestId], [RunDateTime], [IsValid], [ResultString],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM RunHistoryDetail) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[RunHistoryDetail_GetDataPageable]
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')     
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [RunHistoryId], [TestId], [RunDateTime], [IsValid], [ResultString] FROM (
    SELECT [Id], [RunHistoryId], [TestId], [RunDateTime], [IsValid], [ResultString],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM RunHistoryDetail) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RunHistoryDetail_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[RunHistoryDetail_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM RunHistoryDetail'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[RunHistoryDetail_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM RunHistoryDetail'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RunHistoryDetail_GetDataById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[RunHistoryDetail_GetDataById]
(
@Id bigint
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [RunHistoryId], [TestId], [RunDateTime], [IsValid], [ResultString]
FROM [RunHistoryDetail]
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[RunHistoryDetail_GetDataById]
(
@Id bigint
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [RunHistoryId], [TestId], [RunDateTime], [IsValid], [ResultString]
FROM [RunHistoryDetail]
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RunHistoryDetail_GetDataByRunHistoryId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[RunHistoryDetail_GetDataByRunHistoryId]
(
@RunHistoryId bigint
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [RunHistoryId], [TestId], [RunDateTime], [IsValid], [ResultString]
FROM [RunHistoryDetail]
WHERE [RunHistoryId]=@RunHistoryId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[RunHistoryDetail_GetDataByRunHistoryId]
(
@RunHistoryId bigint
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [RunHistoryId], [TestId], [RunDateTime], [IsValid], [ResultString]
FROM [RunHistoryDetail]
WHERE [RunHistoryId]=@RunHistoryId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RunHistoryDetail_GetDataByRunHistoryIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[RunHistoryDetail_GetDataByRunHistoryIdPageable]
(
@RunHistoryId bigint, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000),  @startRowIndex int 
IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''RunHistoryId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [RunHistoryId], [TestId], [RunDateTime], [IsValid], [ResultString] FROM (
		   SELECT [Id], [RunHistoryId], [TestId], [RunDateTime], [IsValid], [ResultString],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM RunHistoryDetail WHERE RunHistoryId = @INRunHistoryId) AS PagedResults 
 		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1'' 
-- Execute the SQL query 
EXEC sp_executesql @sql, N''@INRunHistoryId bigint,@inStartRowIndex Int,@inPageSize Int'', @INRunHistoryId = @RunHistoryId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[RunHistoryDetail_GetDataByRunHistoryIdPageable]
(
@RunHistoryId bigint, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000),  @startRowIndex int 
IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''RunHistoryId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [RunHistoryId], [TestId], [RunDateTime], [IsValid], [ResultString] FROM (
		   SELECT [Id], [RunHistoryId], [TestId], [RunDateTime], [IsValid], [ResultString],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM RunHistoryDetail WHERE RunHistoryId = @INRunHistoryId) AS PagedResults 
 		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1'' 
-- Execute the SQL query 
EXEC sp_executesql @sql, N''@INRunHistoryId bigint,@inStartRowIndex Int,@inPageSize Int'', @INRunHistoryId = @RunHistoryId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RunHistoryDetail_GetDataByRunHistoryIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[RunHistoryDetail_GetDataByRunHistoryIdRowCount]
(
@RunHistoryId bigint
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM RunHistoryDetail
WHERE [RunHistoryId]=@RunHistoryId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[RunHistoryDetail_GetDataByRunHistoryIdRowCount]
(
@RunHistoryId bigint
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM RunHistoryDetail
WHERE [RunHistoryId]=@RunHistoryId'
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
     [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive]
FROM [Test]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_Select]

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive]
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
@TestTypeId int, 
@ProjectId int, 
@GroupId int, 
@Name varchar(50), 
@TestValue text, 
@IsActive bit, 
@Id int
  )

  AS
   SET NOCOUNT ON;
UPDATE [Test] SET [TestTypeId]=@TestTypeId
     , [ProjectId]=@ProjectId
     , [GroupId]=@GroupId
     , [Name]=@Name
     , [TestValue]=@TestValue
     , [IsActive]=@IsActive
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_Update]
(
@TestTypeId int, 
@ProjectId int, 
@GroupId int, 
@Name varchar(50), 
@TestValue text, 
@IsActive bit, 
@Id int
  )

  AS
   SET NOCOUNT ON;
   UPDATE [Test] SET [TestTypeId]=@TestTypeId
     , [ProjectId]=@ProjectId
     , [GroupId]=@GroupId
     , [Name]=@Name
     , [TestValue]=@TestValue
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
@TestTypeId int, 
@ProjectId int, 
@GroupId int, 
@Name varchar(50), 
@TestValue text, 
@IsActive bit
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [Test] ([TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive]) VALUES (@TestTypeId, @ProjectId, @GroupId, @Name, @TestValue, @IsActive);SELECT SCOPE_IDENTITY();'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_Insert]
(
@TestTypeId int, 
@ProjectId int, 
@GroupId int, 
@Name varchar(50), 
@TestValue text, 
@IsActive bit
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [Test] ([TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive]) VALUES (@TestTypeId, @ProjectId, @GroupId, @Name, @TestValue, @IsActive);SELECT SCOPE_IDENTITY();'
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')     
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive] FROM (
    SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive],
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')     
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive] FROM (
    SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive],
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
     [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive]
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
     [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive]
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
     [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive]
FROM [Test] WHERE (IsActive = 1)'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_GetActiveData]

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive]
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')  
  SET @startRowIndex = (@page -1) * @pageSize + 1  
 SET @sql = ''SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive] FROM ( 
       SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive],
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')  
  SET @startRowIndex = (@page -1) * @pageSize + 1  
 SET @sql = ''SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive] FROM ( 
       SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive],
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_GetDataByProjectId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_GetDataByProjectId]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive]
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
     [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive]
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
DECLARE @sql nvarchar(4000),  @startRowIndex int 
IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ProjectId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive] FROM (
		   SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
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
   DECLARE @sql nvarchar(4000),  @startRowIndex int 
IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ProjectId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive] FROM (
		   SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
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
     [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive]
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
     [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive]
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
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ProjectId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive] FROM (
     SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive], 
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
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ProjectId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive] FROM (
     SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive], 
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_GetDataByGroupId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_GetDataByGroupId]
(
@GroupId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive]
FROM [Test]
WHERE [GroupId]=@GroupId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_GetDataByGroupId]
(
@GroupId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive]
FROM [Test]
WHERE [GroupId]=@GroupId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_GetDataByGroupIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_GetDataByGroupIdPageable]
(
@GroupId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000),  @startRowIndex int 
IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''GroupId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive] FROM (
		   SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM Test WHERE GroupId = @INGroupId) AS PagedResults 
 		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1'' 
-- Execute the SQL query 
EXEC sp_executesql @sql, N''@INGroupId int,@inStartRowIndex Int,@inPageSize Int'', @INGroupId = @GroupId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_GetDataByGroupIdPageable]
(
@GroupId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000),  @startRowIndex int 
IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''GroupId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive] FROM (
		   SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM Test WHERE GroupId = @INGroupId) AS PagedResults 
 		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1'' 
-- Execute the SQL query 
EXEC sp_executesql @sql, N''@INGroupId int,@inStartRowIndex Int,@inPageSize Int'', @INGroupId = @GroupId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_GetDataByGroupIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_GetDataByGroupIdRowCount]
(
@GroupId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Test
WHERE [GroupId]=@GroupId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_GetDataByGroupIdRowCount]
(
@GroupId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Test
WHERE [GroupId]=@GroupId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_GetActiveDataByGroupId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_GetActiveDataByGroupId]
(
@GroupId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive]
FROM [Test] WHERE [IsActive] = 1 and [GroupId] = @GroupId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_GetActiveDataByGroupId]
(
@GroupId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive]
FROM [Test] WHERE [IsActive] = 1 and [GroupId] = @GroupId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_GetActiveDataByGroupIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_GetActiveDataByGroupIdPageable]
(
@GroupId int, 
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
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''GroupId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive] FROM (
     SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive], 
      ROW_NUMBER() OVER (ORDER BY  '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM Test WHERE (IsActive = 1) and GroupId = @INGroupId ) AS PagedResults  WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1'' 
 -- Execute the SQL query 
EXEC sp_executesql @sql, N''@INGroupId int,@inStartRowIndex Int,@inPageSize Int'', @GroupId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_GetActiveDataByGroupIdPageable]
(
@GroupId int, 
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
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''GroupId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive] FROM (
     SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive], 
      ROW_NUMBER() OVER (ORDER BY  '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM Test WHERE (IsActive = 1) and GroupId = @INGroupId ) AS PagedResults  WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1'' 
 -- Execute the SQL query 
EXEC sp_executesql @sql, N''@INGroupId int,@inStartRowIndex Int,@inPageSize Int'', @GroupId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Test_GetActiveDataByGroupIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Test_GetActiveDataByGroupIdRowCount]
(
@GroupId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM Test WHERE (IsActive = 1) and GroupId = @GroupId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[Test_GetActiveDataByGroupIdRowCount]
(
@GroupId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM Test WHERE (IsActive = 1) and GroupId = @GroupId'
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
     [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive]
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
     [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive]
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
DECLARE @sql nvarchar(4000),  @startRowIndex int 
IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''TestTypeId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive] FROM (
		   SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
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
   DECLARE @sql nvarchar(4000),  @startRowIndex int 
IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''TestTypeId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive] FROM (
		   SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
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
     [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive]
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
     [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive]
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
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''TestTypeId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive] FROM (
     SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive], 
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
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''TestTypeId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive] FROM (
     SELECT [Id], [TestTypeId], [ProjectId], [GroupId], [Name], [TestValue], [IsActive], 
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
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestGroup_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[TestGroup_Select]

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [ProjectId], [Name], [IsActive]
FROM [TestGroup]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[TestGroup_Select]

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [ProjectId], [Name], [IsActive]
FROM [TestGroup]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestGroup_Update]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[TestGroup_Update]
(
@ProjectId int, 
@Name varchar(50), 
@IsActive bit, 
@Id int
  )

  AS
   SET NOCOUNT ON;
UPDATE [TestGroup] SET [ProjectId]=@ProjectId
     , [Name]=@Name
     , [IsActive]=@IsActive
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[TestGroup_Update]
(
@ProjectId int, 
@Name varchar(50), 
@IsActive bit, 
@Id int
  )

  AS
   SET NOCOUNT ON;
   UPDATE [TestGroup] SET [ProjectId]=@ProjectId
     , [Name]=@Name
     , [IsActive]=@IsActive
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestGroup_Delete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[TestGroup_Delete]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
DELETE 
FROM [TestGroup]
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[TestGroup_Delete]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
   DELETE 
FROM [TestGroup]
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestGroup_Insert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[TestGroup_Insert]
(
@ProjectId int, 
@Name varchar(50), 
@IsActive bit
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [TestGroup] ([ProjectId], [Name], [IsActive]) VALUES (@ProjectId, @Name, @IsActive);SELECT SCOPE_IDENTITY();'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[TestGroup_Insert]
(
@ProjectId int, 
@Name varchar(50), 
@IsActive bit
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [TestGroup] ([ProjectId], [Name], [IsActive]) VALUES (@ProjectId, @Name, @IsActive);SELECT SCOPE_IDENTITY();'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestGroup_GetDataPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[TestGroup_GetDataPageable]
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')     
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [ProjectId], [Name], [IsActive] FROM (
    SELECT [Id], [ProjectId], [Name], [IsActive],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM TestGroup) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[TestGroup_GetDataPageable]
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')     
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [ProjectId], [Name], [IsActive] FROM (
    SELECT [Id], [ProjectId], [Name], [IsActive],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM TestGroup) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestGroup_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[TestGroup_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM TestGroup'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[TestGroup_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM TestGroup'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestGroup_GetDataById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[TestGroup_GetDataById]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [ProjectId], [Name], [IsActive]
FROM [TestGroup]
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[TestGroup_GetDataById]
(
@Id int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [ProjectId], [Name], [IsActive]
FROM [TestGroup]
WHERE [Id]=@Id'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestGroup_GetActiveData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[TestGroup_GetActiveData]

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [ProjectId], [Name], [IsActive]
FROM [TestGroup] WHERE (IsActive = 1)'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[TestGroup_GetActiveData]

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [ProjectId], [Name], [IsActive]
FROM [TestGroup] WHERE (IsActive = 1)'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestGroup_GetActiveDataPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[TestGroup_GetActiveDataPageable]
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')  
  SET @startRowIndex = (@page -1) * @pageSize + 1  
 SET @sql = ''SELECT [Id], [ProjectId], [Name], [IsActive] FROM ( 
       SELECT [Id], [ProjectId], [Name], [IsActive],
        ROW_NUMBER() OVER (ORDER BY  '' + @SortExpression + '') AS ResultSetRowNumber 
       FROM TestGroup WHERE (IsActive = 1)) AS PagedResults 
     WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1'' 
 -- Execute the SQL query 
EXEC sp_executesql @sql, N'',@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex = @startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[TestGroup_GetActiveDataPageable]
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')  
  SET @startRowIndex = (@page -1) * @pageSize + 1  
 SET @sql = ''SELECT [Id], [ProjectId], [Name], [IsActive] FROM ( 
       SELECT [Id], [ProjectId], [Name], [IsActive],
        ROW_NUMBER() OVER (ORDER BY  '' + @SortExpression + '') AS ResultSetRowNumber 
       FROM TestGroup WHERE (IsActive = 1)) AS PagedResults 
     WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1'' 
 -- Execute the SQL query 
EXEC sp_executesql @sql, N'',@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex = @startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestGroup_GetActiveDataRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[TestGroup_GetActiveDataRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM TestGroup WHERE (IsActive = 1)'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[TestGroup_GetActiveDataRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM TestGroup WHERE (IsActive = 1)'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestGroup_GetDataByProjectId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[TestGroup_GetDataByProjectId]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [ProjectId], [Name], [IsActive]
FROM [TestGroup]
WHERE [ProjectId]=@ProjectId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[TestGroup_GetDataByProjectId]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [ProjectId], [Name], [IsActive]
FROM [TestGroup]
WHERE [ProjectId]=@ProjectId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestGroup_GetDataByProjectIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[TestGroup_GetDataByProjectIdPageable]
(
@ProjectId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
DECLARE @sql nvarchar(4000),  @startRowIndex int 
IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ProjectId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [ProjectId], [Name], [IsActive] FROM (
		   SELECT [Id], [ProjectId], [Name], [IsActive],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM TestGroup WHERE ProjectId = @INProjectId) AS PagedResults 
 		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1'' 
-- Execute the SQL query 
EXEC sp_executesql @sql, N''@INProjectId int,@inStartRowIndex Int,@inPageSize Int'', @INProjectId = @ProjectId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[TestGroup_GetDataByProjectIdPageable]
(
@ProjectId int, 
@sortExpression varchar(125), 
@page Int, 
@pageSize Int
  )

  AS
   SET NOCOUNT ON;
   DECLARE @sql nvarchar(4000),  @startRowIndex int 
IF @page < 1 SET @page = 1 
IF @pageSize < 1 SET @pageSize = 10 
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ProjectId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [ProjectId], [Name], [IsActive] FROM (
		   SELECT [Id], [ProjectId], [Name], [IsActive],  ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber
		   FROM TestGroup WHERE ProjectId = @INProjectId) AS PagedResults 
 		WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND ( @inStartRowIndex + @inPageSize) - 1'' 
-- Execute the SQL query 
EXEC sp_executesql @sql, N''@INProjectId int,@inStartRowIndex Int,@inPageSize Int'', @INProjectId = @ProjectId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestGroup_GetDataByProjectIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[TestGroup_GetDataByProjectIdRowCount]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM TestGroup
WHERE [ProjectId]=@ProjectId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[TestGroup_GetDataByProjectIdRowCount]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM TestGroup
WHERE [ProjectId]=@ProjectId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestGroup_GetActiveDataByProjectId]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[TestGroup_GetActiveDataByProjectId]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
SELECT 
     [Id], [ProjectId], [Name], [IsActive]
FROM [TestGroup] WHERE [IsActive] = 1 and [ProjectId] = @ProjectId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[TestGroup_GetActiveDataByProjectId]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [ProjectId], [Name], [IsActive]
FROM [TestGroup] WHERE [IsActive] = 1 and [ProjectId] = @ProjectId'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestGroup_GetActiveDataByProjectIdPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[TestGroup_GetActiveDataByProjectIdPageable]
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
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ProjectId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [ProjectId], [Name], [IsActive] FROM (
     SELECT [Id], [ProjectId], [Name], [IsActive], 
      ROW_NUMBER() OVER (ORDER BY  '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM TestGroup WHERE (IsActive = 1) and ProjectId = @INProjectId ) AS PagedResults  WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1'' 
 -- Execute the SQL query 
EXEC sp_executesql @sql, N''@INProjectId int,@inStartRowIndex Int,@inPageSize Int'', @ProjectId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[TestGroup_GetActiveDataByProjectIdPageable]
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
SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ProjectId'') 
SET @startRowIndex = (@page -1) * @pageSize + 1 
SET @sql = ''SELECT [Id], [ProjectId], [Name], [IsActive] FROM (
     SELECT [Id], [ProjectId], [Name], [IsActive], 
      ROW_NUMBER() OVER (ORDER BY  '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM TestGroup WHERE (IsActive = 1) and ProjectId = @INProjectId ) AS PagedResults  WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1'' 
 -- Execute the SQL query 
EXEC sp_executesql @sql, N''@INProjectId int,@inStartRowIndex Int,@inPageSize Int'', @ProjectId,@inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TestGroup_GetActiveDataByProjectIdRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[TestGroup_GetActiveDataByProjectIdRowCount]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM TestGroup WHERE (IsActive = 1) and ProjectId = @ProjectId'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[TestGroup_GetActiveDataByProjectIdRowCount]
(
@ProjectId int
  )

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM TestGroup WHERE (IsActive = 1) and ProjectId = @ProjectId'
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
     [Id], [Name], [TestValidatorType], [IsActive]
FROM [TestType]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[TestType_Select]

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [Name], [TestValidatorType], [IsActive]
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
@TestValidatorType varchar(150), 
@IsActive bit, 
@Id int
  )

  AS
   SET NOCOUNT ON;
UPDATE [TestType] SET [Name]=@Name
     , [TestValidatorType]=@TestValidatorType
     , [IsActive]=@IsActive
WHERE [Id]=@Id'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[TestType_Update]
(
@Name varchar(50), 
@TestValidatorType varchar(150), 
@IsActive bit, 
@Id int
  )

  AS
   SET NOCOUNT ON;
   UPDATE [TestType] SET [Name]=@Name
     , [TestValidatorType]=@TestValidatorType
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
@TestValidatorType varchar(150), 
@IsActive bit
  )

  AS
   SET NOCOUNT ON;
INSERT INTO [TestType] ([Name], [TestValidatorType], [IsActive]) VALUES (@Name, @TestValidatorType, @IsActive);SELECT SCOPE_IDENTITY();'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[TestType_Insert]
(
@Name varchar(50), 
@TestValidatorType varchar(150), 
@IsActive bit
  )

  AS
   SET NOCOUNT ON;
   INSERT INTO [TestType] ([Name], [TestValidatorType], [IsActive]) VALUES (@Name, @TestValidatorType, @IsActive);SELECT SCOPE_IDENTITY();'
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')     
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [Name], [TestValidatorType], [IsActive] FROM (
    SELECT [Id], [Name], [TestValidatorType], [IsActive],
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')     
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [Id], [Name], [TestValidatorType], [IsActive] FROM (
    SELECT [Id], [Name], [TestValidatorType], [IsActive],
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
     [Id], [Name], [TestValidatorType], [IsActive]
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
     [Id], [Name], [TestValidatorType], [IsActive]
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
     [Id], [Name], [TestValidatorType], [IsActive]
FROM [TestType] WHERE (IsActive = 1)'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[TestType_GetActiveData]

  AS
   SET NOCOUNT ON;
   SELECT 
     [Id], [Name], [TestValidatorType], [IsActive]
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')  
  SET @startRowIndex = (@page -1) * @pageSize + 1  
 SET @sql = ''SELECT [Id], [Name], [TestValidatorType], [IsActive] FROM ( 
       SELECT [Id], [Name], [TestValidatorType], [IsActive],
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''Id'')  
  SET @startRowIndex = (@page -1) * @pageSize + 1  
 SET @sql = ''SELECT [Id], [Name], [TestValidatorType], [IsActive] FROM ( 
       SELECT [Id], [Name], [TestValidatorType], [IsActive],
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

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProjectDetailsView_Select]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ProjectDetailsView_Select]

  AS
   SET NOCOUNT ON;
SELECT 
     [ProjectId], [Name], [IsActive], [GroupCount], [TestCount], [ActiveTestCount], [InactiveTestCount], [IsValid]
FROM [ProjectDetailsView]'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ProjectDetailsView_Select]

  AS
   SET NOCOUNT ON;
   SELECT 
     [ProjectId], [Name], [IsActive], [GroupCount], [TestCount], [ActiveTestCount], [InactiveTestCount], [IsValid]
FROM [ProjectDetailsView]'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProjectDetailsView_GetDataPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ProjectDetailsView_GetDataPageable]
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ProjectId'')     
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [ProjectId], [Name], [IsActive], [GroupCount], [TestCount], [ActiveTestCount], [InactiveTestCount], [IsValid] FROM (
    SELECT [ProjectId], [Name], [IsActive], [GroupCount], [TestCount], [ActiveTestCount], [InactiveTestCount], [IsValid],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM ProjectDetailsView) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ProjectDetailsView_GetDataPageable]
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ProjectId'')     
SET @startRowIndex = (@page -1) * @pageSize + 1 

SET @sql = ''SELECT [ProjectId], [Name], [IsActive], [GroupCount], [TestCount], [ActiveTestCount], [InactiveTestCount], [IsValid] FROM (
    SELECT [ProjectId], [Name], [IsActive], [GroupCount], [TestCount], [ActiveTestCount], [InactiveTestCount], [IsValid],
         ROW_NUMBER() OVER (ORDER BY '' + @SortExpression + '' ) AS ResultSetRowNumber 
      FROM ProjectDetailsView) AS PagedResults 
 WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex  +  @inPageSize) - 1'' 
 -- Execute the SQL query 
  EXEC sp_executesql @sql, N''@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex =@startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProjectDetailsView_GetRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ProjectDetailsView_GetRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM ProjectDetailsView'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ProjectDetailsView_GetRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM ProjectDetailsView'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProjectDetailsView_GetActiveData]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ProjectDetailsView_GetActiveData]

  AS
   SET NOCOUNT ON;
SELECT 
     [ProjectId], [Name], [IsActive], [GroupCount], [TestCount], [ActiveTestCount], [InactiveTestCount], [IsValid]
FROM [ProjectDetailsView] WHERE (IsActive = 1)'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ProjectDetailsView_GetActiveData]

  AS
   SET NOCOUNT ON;
   SELECT 
     [ProjectId], [Name], [IsActive], [GroupCount], [TestCount], [ActiveTestCount], [InactiveTestCount], [IsValid]
FROM [ProjectDetailsView] WHERE (IsActive = 1)'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProjectDetailsView_GetActiveDataPageable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ProjectDetailsView_GetActiveDataPageable]
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ProjectId'')  
  SET @startRowIndex = (@page -1) * @pageSize + 1  
 SET @sql = ''SELECT [ProjectId], [Name], [IsActive], [GroupCount], [TestCount], [ActiveTestCount], [InactiveTestCount], [IsValid] FROM ( 
       SELECT [ProjectId], [Name], [IsActive], [GroupCount], [TestCount], [ActiveTestCount], [InactiveTestCount], [IsValid],
        ROW_NUMBER() OVER (ORDER BY  '' + @SortExpression + '') AS ResultSetRowNumber 
       FROM ProjectDetailsView WHERE (IsActive = 1)) AS PagedResults 
     WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1'' 
 -- Execute the SQL query 
EXEC sp_executesql @sql, N'',@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex = @startRowIndex, @inPageSize = @PageSize;'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ProjectDetailsView_GetActiveDataPageable]
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
 SET  @sortExpression = coalesce(nullif(@sortExpression,''''), ''ProjectId'')  
  SET @startRowIndex = (@page -1) * @pageSize + 1  
 SET @sql = ''SELECT [ProjectId], [Name], [IsActive], [GroupCount], [TestCount], [ActiveTestCount], [InactiveTestCount], [IsValid] FROM ( 
       SELECT [ProjectId], [Name], [IsActive], [GroupCount], [TestCount], [ActiveTestCount], [InactiveTestCount], [IsValid],
        ROW_NUMBER() OVER (ORDER BY  '' + @SortExpression + '') AS ResultSetRowNumber 
       FROM ProjectDetailsView WHERE (IsActive = 1)) AS PagedResults 
     WHERE ResultSetRowNumber BETWEEN @inStartRowIndex AND (@inStartRowIndex + @inPageSize) - 1'' 
 -- Execute the SQL query 
EXEC sp_executesql @sql, N'',@inStartRowIndex Int,@inPageSize Int'', @inStartRowIndex = @startRowIndex, @inPageSize = @PageSize;'
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProjectDetailsView_GetActiveDataRowCount]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ProjectDetailsView_GetActiveDataRowCount]

  AS
   SET NOCOUNT ON;
SELECT COUNT(1) FROM ProjectDetailsView WHERE (IsActive = 1)'
    END
  ELSE
  BEGIN
  EXEC dbo.sp_executesql @statement = N'ALTER PROCEDURE [dbo].[ProjectDetailsView_GetActiveDataRowCount]

  AS
   SET NOCOUNT ON;
   SELECT COUNT(1) FROM ProjectDetailsView WHERE (IsActive = 1)'
  END
GO
