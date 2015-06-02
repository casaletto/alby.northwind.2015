-------------------------------------------------------------------------------------------------

IF OBJECT_ID( '[dbo].[CodegenAllTypesInATableTypeTest]' ) IS NOT NULL
DROP PROCEDURE [dbo].CodegenAllTypesInATableTypeTest
GO

-------------------------------------------------------------------------------------------------------

IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id 
			WHERE st.name = N'MyAllTypesInATableType' AND ss.name = N'dbo')
DROP TYPE [dbo].MyAllTypesInATableType
GO

-------------------------------------------------------------------------------------------------------

CREATE TYPE [dbo].MyAllTypesInATableType AS TABLE
(
	the_bigint				bigint,
	the_binary				binary(100),
	the_bit					bit,
	the_char				char(100),
	--the_cursor			cursor,
	the_date				date,
	the_datetime			datetime,
	the_datetime2			datetime2,
	the_datetimeoffset		datetimeoffset,
	the_decimal				decimal(28,12),
	the_float				float,
	the_geography			geography,
	the_geometry			geometry,
	the_hierarchyid			hierarchyid,
	the_image				image,
	the_int					int,
	the_money				money,
	the_nchar				nchar(100),
	the_ntext				ntext,
	the_numeric				numeric(28,12),
	the_nvarchar			nvarchar(100),
	the_real				real,
	-- the_rowversion		rowversion, -- only 1 ts col allowed
	the_smalldatetime		smalldatetime,
	the_smallint			smallint,
	the_smallmoney			smallmoney,
	the_sql_variant			sql_variant,
	--the_table				table,
	the_text				text,
	the_time				time,
	the_tinyint				tinyint,
	the_uniqueidentifier	uniqueidentifier,
	the_varbinary			varbinary(100),
	the_varchar				varchar(100),
	the_xml					xml,
	the_timestamp			timestamp
)
GO

-------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].CodegenAllTypesInATableTypeTest
(
    @list dbo.MyAllTypesInATableType READONLY
)
AS
BEGIN

	select *
	from @list

END
GO

-------------------------------------------------------------------------------------------------------
/* testing

declare @list dbo.MyAllTypesInATableType

insert @list ( the_bigint, the_timestamp )
values ( 1, null )

exec dbo.CodegenAllTypesInATableTypeTest @list

*/
-------------------------------------------------------------------------------------------------------
