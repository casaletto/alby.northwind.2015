-------------------------------------------------------------------------------------------------

IF OBJECT_ID( '[dbo].[CodegenTestStoredProcLoadTest]' ) IS NOT NULL
DROP PROCEDURE [dbo].CodegenTestStoredProcLoadTest
GO

-------------------------------------------------------------------------------------------------------

IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id 
			WHERE st.name = N'MyBigIntTableType' AND ss.name = N'dbo')
DROP TYPE [dbo].MyBigIntTableType
GO



-------------------------------------------------------------------------------------------------------

CREATE TYPE [dbo].MyBigIntTableType AS TABLE
(
	ID bigint PRIMARY KEY --identity,
)
GO

-------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].CodegenTestStoredProcLoadTest
(
    @list			dbo.MyBigIntTableType READONLY,
    @theCount		bigint OUTPUT,
    @theFirstOne	bigint OUTPUT,
    @theLastOne		bigint OUTPUT
)
AS
BEGIN

	SELECT @theCount = COUNT(1) FROM @list
	
	SELECT TOP 1 @theFirstOne = ID FROM @list ORDER BY ID ASC
	
	SELECT TOP 1 @theLastOne  = ID FROM @list ORDER BY ID DESC

END
GO

-------------------------------------------------------------------------------------------------------
