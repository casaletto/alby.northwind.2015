-------------------------------------------------------------------------------------------------

IF OBJECT_ID( '[dbo].[CodegenTestStoredProcTableType]' ) IS NOT NULL
DROP PROCEDURE [dbo].[CodegenTestStoredProcTableType]
GO

IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id 
			WHERE st.name = N'NameAddressTableType' AND ss.name = N'dbo')
DROP TYPE [dbo].[NameAddressTableType]
GO

-------------------------------------------------------------------------------------------------------

CREATE TYPE [dbo].[NameAddressTableType] AS TABLE
(
	[Name]      [varchar](50) NULL,
	[Address]	[varchar](50) NULL,
	[State]		[varchar](50) NULL
)
GO
-------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].CodegenTestStoredProcTableType
(
    @dt [NameAddressTableType] READONLY
)
AS
BEGIN

    SELECT   *
    FROM     @dt
    ORDER BY [Address] DESC

END
GO

-------------------------------------------------------------------------------------------------------
/*

DECLARE @table1 [dbo].[NameAddressTableType]

INSERT @table
VALUES
( 'a', 'aaaaaa', 'nsw' ),
( 'b', 'bbbbbb', 'qld' ),
( 'c', 'cccccc', 'vic' )

EXEC [dbo].[CodegenTestStoredProcTableType] @table

declare @a table
(
	x int
)
EXEC [dbo].[CodegenTestStoredProcTableType] @a



*/
-------------------------------------------------------------------------------------------------------
