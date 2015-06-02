-------------------------------------------------------------------------------------------------

IF OBJECT_ID( '[dbo].[CodegenTestStoredProcUdtTableType]' ) IS NOT NULL
DROP PROCEDURE [dbo].[CodegenTestStoredProcUdtTableType]
GO

-------------------------------------------------------------------------------------------------------

IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id 
			WHERE st.name = N'MyUdtTableType' AND ss.name = N'dbo')
DROP TYPE [dbo].MyUdtTableType
GO

-------------------------------------------------------------------------------------------------------

CREATE TYPE [dbo].MyUdtTableType AS TABLE
(
	[Name]      [nvarchar](50),
	[Geo]		geography
)
GO

-------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].CodegenTestStoredProcUdtTableType
(
    @myudt [MyUdtTableType] READONLY
)
AS
BEGIN
	declare @dt dbo.MyUdtTableType

	insert @dt
	select * 
	from @myudt

	update	@dt
	set		geo = geo.STUnion( 'POINT(1 1)' )

	select	Name, geo.ToString() as geo
    FROM    @dt

END
GO

-------------------------------------------------------------------------------------------------------
/* test

declare @dt MyUdtTableType

insert @dt 
values ( '#1', 'POINT(10 10)' )

exec [dbo].CodegenTestStoredProcUdtTableType @dt

--MULTIPOINT ((10 10), (1 1))

*/
