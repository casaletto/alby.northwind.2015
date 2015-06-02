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
	[Name]			[nvarchar](50),
	[MyGeography]	geography,
	[MyGeometry]	geometry,
	[MyHierarchyid]	hierarchyid
)
GO

-------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].CodegenTestStoredProcUdtTableType
(
    @myudt1 [MyUdtTableType] READONLY,
    @myudt2 [MyUdtTableType] READONLY    
)
AS
BEGIN

	select t.Name, t.[MyGeography], [MyGeometry], [MyHierarchyid] from @myudt1 t
	union all
	select t.Name, t.[MyGeography], [MyGeometry], [MyHierarchyid]  from @myudt2 t

END
GO

-------------------------------------------------------------------------------------------------------
/* test

declare @dt1 MyUdtTableType
insert  @dt1 values ( '#1', 'POINT(10 10)' )

declare @dt2 MyUdtTableType
insert  @dt2 values ( '#2', 'POINT(20 20)' )

exec [dbo].CodegenTestStoredProcUdtTableType @dt1, @dt2

*/
