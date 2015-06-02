set nocount on

DECLARE @RC int
DECLARE @my_in_bigint bigint
DECLARE @my_in_binary binary(3)
DECLARE @my_in_bit bit
DECLARE @my_in_char char(3)
DECLARE @my_in_date date
DECLARE @my_in_datetime datetime
DECLARE @my_in_datetime2 datetime2
DECLARE @my_in_datetimeoffset datetimeoffset
DECLARE @my_in_decimal decimal(28,12)
DECLARE @my_in_float float
DECLARE @my_in_geography geography
DECLARE @my_in_geometry geometry
DECLARE @my_in_hierarchyid hierarchyid
DECLARE @my_in_image varbinary(max)
DECLARE @my_in_int int
DECLARE @my_in_money money
DECLARE @my_in_nchar nchar(3)
DECLARE @my_in_ntext nvarchar(max)
DECLARE @my_in_numeric numeric(28,12)
DECLARE @my_in_nvarchar nvarchar(3)
DECLARE @my_in_real real
DECLARE @my_in_rowversion timestamp
DECLARE @my_in_smalldatetime smalldatetime
DECLARE @my_in_smallint smallint
DECLARE @my_in_smallmoney smallmoney
DECLARE @my_in_sql_variant sql_variant
DECLARE @my_in_text varchar(max)
DECLARE @my_in_time time
DECLARE @my_in_timestamp timestamp
DECLARE @my_in_tinyint tinyint
DECLARE @my_in_uniqueidentifier uniqueidentifier
DECLARE @my_in_varbinary varbinary(3)
DECLARE @my_in_varchar varchar(3)
DECLARE @my_in_xml xml

DECLARE @my_out_bigint bigint
DECLARE @my_out_binary binary(3)
DECLARE @my_out_bit bit
DECLARE @my_out_char char(3)
DECLARE @my_out_date date
DECLARE @my_out_datetime datetime
DECLARE @my_out_datetime2 datetime2
DECLARE @my_out_datetimeoffset datetimeoffset
DECLARE @my_out_decimal decimal(28,12)
DECLARE @my_out_float float
DECLARE @my_out_geography geography
DECLARE @my_out_geometry geometry
DECLARE @my_out_hierarchyid hierarchyid
DECLARE @my_out_image varbinary(max)
DECLARE @my_out_int int
DECLARE @my_out_money money
DECLARE @my_out_nchar nchar(3)
DECLARE @my_out_ntext nvarchar(max)
DECLARE @my_out_numeric numeric(28,12)
DECLARE @my_out_nvarchar nvarchar(3)
DECLARE @my_out_real real
DECLARE @my_out_rowversion timestamp
DECLARE @my_out_smalldatetime smalldatetime
DECLARE @my_out_smallint smallint
DECLARE @my_out_smallmoney smallmoney
DECLARE @my_out_sql_variant sql_variant
DECLARE @my_out_text varchar(max)
DECLARE @my_out_time time
DECLARE @my_out_timestamp timestamp
DECLARE @my_out_tinyint tinyint
DECLARE @my_out_uniqueidentifier uniqueidentifier
DECLARE @my_out_varbinary varbinary(3)
DECLARE @my_out_varchar varchar(3)
DECLARE @my_out_xml xml
DECLARE @my_inout_bigint bigint

--------------------------------------------------------------------------------------------

select @my_in_bigint			= 111
select @my_inout_bigint			= 222
select @my_in_binary			= 0x112233445566
select @my_in_bit				= 1
select @my_in_char				= 'abcdefghijklmnopq'
select @my_in_date				= '20010101 01:02:03'
select @my_in_datetime			= '20010102 01:02:03'
select @my_in_datetime2			= '20010103 01:02:03'
select @my_in_datetimeoffset	= '20010106 01:02:03'
select @my_in_decimal			= 123.456789
select @my_in_float				= 124.456789
select @my_in_geography			= 'LINESTRING( 0.0 0.0, 121.0 33.0, 0.0 89.0 )'
select @my_in_geometry			= 'LINESTRING( 0.0 0.0, 1.0 1.0, 0.0 2.0 )'
select @my_in_hierarchyid		= '/1/2/'
select @my_in_image				= 0x22112233445566
select @my_in_int				= 333
select @my_in_money				= 125.456789
select @my_in_nchar				= N'bcdefghijklmnopq'
select @my_in_ntext				= N'cdefghijklmnopqrstuv'
select @my_in_numeric			= 126.456789
select @my_in_nvarchar			= N'defghijklmnopqrst'
select @my_in_real				= 127.456789
select @my_in_rowversion		= 0x3322112233445566778899AA
select @my_in_smalldatetime		= '20010104 01:02:03'
select @my_in_smallint			= 333
select @my_in_smallmoney		= 128.456789
select @my_in_sql_variant		= 129.456789
select @my_in_text				= 'efghijklmnopqrst'
select @my_in_time				= '20010105 01:02:03'
select @my_in_timestamp			= 0x443322112233445566778899AA
select @my_in_tinyint			= 123
select @my_in_uniqueidentifier	= NEWID()
select @my_in_varbinary			= 0x5522112233445566778899AA
select @my_in_varchar			= 'fghijklmnopqrst'
select @my_in_xml				= N'<root>hello world</root>'

--------------------------------------------------------------------------------------------

EXECUTE @RC = [Northwind].[dbo].[CodegenTestParameters] 
   @my_in_bigint
  ,@my_in_binary
  ,@my_in_bit
  ,@my_in_char
  ,@my_in_date
  ,@my_in_datetime
  ,@my_in_datetime2
  ,@my_in_datetimeoffset
  ,@my_in_decimal
  ,@my_in_float
  ,@my_in_geography
  ,@my_in_geometry
  ,@my_in_hierarchyid
  ,@my_in_image
  ,@my_in_int
  ,@my_in_money
  ,@my_in_nchar
  ,@my_in_ntext
  ,@my_in_numeric
  ,@my_in_nvarchar
  ,@my_in_real
  ,@my_in_rowversion
  ,@my_in_smalldatetime
  ,@my_in_smallint
  ,@my_in_smallmoney
  ,@my_in_sql_variant
  ,@my_in_text
  ,@my_in_time
  ,@my_in_timestamp
  ,@my_in_tinyint
  ,@my_in_uniqueidentifier
  ,@my_in_varbinary
  ,@my_in_varchar
  ,@my_in_xml
  ,@my_out_bigint OUTPUT
  ,@my_out_binary OUTPUT
  ,@my_out_bit OUTPUT
  ,@my_out_char OUTPUT
  ,@my_out_date OUTPUT
  ,@my_out_datetime OUTPUT
  ,@my_out_datetime2 OUTPUT
  ,@my_out_datetimeoffset OUTPUT
  ,@my_out_decimal OUTPUT
  ,@my_out_float OUTPUT
  ,@my_out_geography OUTPUT
  ,@my_out_geometry OUTPUT
  ,@my_out_hierarchyid OUTPUT
  ,@my_out_image OUTPUT
  ,@my_out_int OUTPUT
  ,@my_out_money OUTPUT
  ,@my_out_nchar OUTPUT
  ,@my_out_ntext OUTPUT
  ,@my_out_numeric OUTPUT
  ,@my_out_nvarchar OUTPUT
  ,@my_out_real OUTPUT
  ,@my_out_rowversion OUTPUT
  ,@my_out_smalldatetime OUTPUT
  ,@my_out_smallint OUTPUT
  ,@my_out_smallmoney OUTPUT
  ,@my_out_sql_variant OUTPUT
  ,@my_out_text OUTPUT
  ,@my_out_time OUTPUT
  ,@my_out_timestamp OUTPUT
  ,@my_out_tinyint OUTPUT
  ,@my_out_uniqueidentifier OUTPUT
  ,@my_out_varbinary OUTPUT
  ,@my_out_varchar OUTPUT
  ,@my_out_xml OUTPUT
  ,@my_inout_bigint output
  
--------------------------------------------------------------------------------------------

select @RC as rc
select @my_in_bigint as my_in_bigint,						@my_out_bigint as my_out_bigint, @my_inout_bigint as my_inout_bigint
select @my_in_binary as my_in_binary,						@my_out_binary as my_out_binary
select @my_in_bit as my_in_bit,								@my_out_bit as my_out_bit
select @my_in_char as my_in_char,							@my_out_char as my_out_char
select @my_in_date as my_in_date,							@my_out_date as my_out_date
select @my_in_datetime as my_in_datetime,					@my_out_datetime as my_out_datetime
select @my_in_datetime2 as my_in_datetime2,					@my_out_datetime2 as my_out_datetime2
select @my_in_datetimeoffset as my_in_datetimeoffset,		@my_out_datetimeoffset as my_out_datetimeoffset
select @my_in_decimal as my_in_decimal,						@my_out_decimal as my_out_decimal
select @my_in_float as my_in_float,							@my_out_float as my_out_float
select @my_in_geography as my_in_geography,					@my_out_geography as my_out_geography
select @my_in_geometry as my_in_geometry,					@my_out_geometry as my_out_geometry
select @my_in_hierarchyid as my_in_hierarchyid,				@my_out_hierarchyid as my_out_hierarchyid
select @my_in_image as my_in_image,							@my_out_image as my_out_image
select @my_in_int as my_in_int,								@my_out_int as my_out_int
select @my_in_money as my_in_money,							@my_out_money as my_out_money
select @my_in_nchar as my_in_nchar,							@my_out_nchar as my_out_nchar
select @my_in_ntext as my_in_ntext,							@my_out_ntext as my_out_ntext
select @my_in_numeric as my_in_numeric,						@my_out_numeric as my_out_numeric
select @my_in_nvarchar as my_in_nvarchar,					@my_out_nvarchar as my_out_nvarchar
select @my_in_real as my_in_real,							@my_out_real as my_out_real
select @my_in_rowversion as my_in_rowversion,				@my_out_rowversion as my_out_rowversion
select @my_in_smalldatetime as my_in_smalldatetime,			@my_out_smalldatetime as my_out_smalldatetime
select @my_in_smallint as my_in_smallint,					@my_out_smallint as my_out_smallint
select @my_in_smallmoney as my_in_smallmoney,				@my_out_smallmoney as my_out_smallmoney
select @my_in_sql_variant as my_in_sql_variant,				@my_out_sql_variant as my_out_sql_variant
select @my_in_text as my_in_text,							@my_out_text as my_out_text
select @my_in_time as my_in_time,							@my_out_time as my_out_time
select @my_in_timestamp as my_in_timestamp,					@my_out_timestamp as my_out_timestamp
select @my_in_tinyint as my_in_tinyint,						@my_out_tinyint as my_out_tinyint
select @my_in_uniqueidentifier as my_in_uniqueidentifier,	@my_out_uniqueidentifier as my_out_uniqueidentifier
select @my_in_varbinary as my_in_varbinary,					@my_out_varbinary as my_out_varbinary
select @my_in_varchar as my_in_varchar,						@my_out_varchar as my_out_varchar
select @my_in_xml as my_in_xml,								@my_out_xml as my_out_xml
----------------------------------------------------------------------------------------------------------------------

