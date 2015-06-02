-------------------------------------------------------------------------------------------------

IF  EXISTS 
(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CodegenTestParameters]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CodegenTestParameters]
GO

-------------------------------------------------------------------------------------------------

create PROCEDURE [dbo].[CodegenTestParameters]
(
	@my_in_bigint				bigint,
	@my_in_binary				binary(3),
	@my_in_bit					bit,
	@my_in_char					char(3),
	--@my_in_cursor				cursor,
	@my_in_date					date,
	@my_in_datetime				datetime,
	@my_in_datetime2			datetime2,
	@my_in_datetimeoffset		datetimeoffset,
	@my_in_decimal				decimal(28,12),
	@my_in_float				float,
	@my_in_geography			geography,
	@my_in_geometry				geometry,
	@my_in_hierarchyid			hierarchyid,
	@my_in_image				image,
	@my_in_int					int,
	@my_in_money				money,
	@my_in_nchar				nchar(3),
	@my_in_ntext				ntext,
	@my_in_numeric				numeric(28,12),
	@my_in_nvarchar				nvarchar(3),
	@my_in_real					real,
	@my_in_rowversion			rowversion,
	@my_in_smalldatetime		smalldatetime,
	@my_in_smallint				smallint,
	@my_in_smallmoney			smallmoney,
	@my_in_sql_variant			sql_variant,
	--@my_in_table				table,
	@my_in_text					text,
	@my_in_time					time,
	@my_in_timestamp			timestamp,
	@my_in_tinyint				tinyint,
	@my_in_uniqueidentifier		uniqueidentifier,
	@my_in_varbinary			varbinary(3),
	@my_in_varchar				varchar(3),
	@my_in_xml					xml,
	
	@my_out_bigint				bigint out,
	@my_out_binary				binary(3) out,
	@my_out_bit					bit out,
	@my_out_char				char(3) out,
	--@my_out_cursor			cursor out,
	@my_out_date				date out,
	@my_out_datetime			datetime out,
	@my_out_datetime2			datetime2 out,
	@my_out_datetimeoffset		datetimeoffset out,
	@my_out_decimal				decimal(28,12) out,
	@my_out_float				float out,
	@my_out_geography			geography out,
	@my_out_geometry			geometry out,
	@my_out_hierarchyid			hierarchyid out,
	@my_out_image				varbinary(max) out, --image out,
	@my_out_int					int out,
	@my_out_money				money out,
	@my_out_nchar				nchar(3) out,
	@my_out_ntext				nvarchar(max) out, --ntext out,
	@my_out_numeric				numeric(28,12) out,
	@my_out_nvarchar			nvarchar(3) out,
	@my_out_real				real out,
	@my_out_rowversion			rowversion out,
	@my_out_smalldatetime		smalldatetime out,
	@my_out_smallint			smallint out,
	@my_out_smallmoney			smallmoney out,
	@my_out_sql_variant			sql_variant out,
	--@my_out_table				table out,
	@my_out_text				varchar(max) out, --text out,
	@my_out_time				time out,
	@my_out_timestamp			timestamp out,
	@my_out_tinyint				tinyint out,
	@my_out_uniqueidentifier	uniqueidentifier out,
	@my_out_varbinary			varbinary(3) out,
	@my_out_varchar				varchar(3) out,
	@my_out_xml					xml out,
	
	@my_inout_bigint			bigint out
) 
AS
begin

	set nocount on
	
	select		@my_out_bigint				     = @my_in_bigint				
	select		@my_out_binary				     = @my_in_binary				
	select		@my_out_bit					     = @my_in_bit					
	select		@my_out_char				     = @my_in_char				
	select		@my_out_date				     = @my_in_date				
	select		@my_out_datetime			     = @my_in_datetime			
	select		@my_out_datetime2			     = @my_in_datetime2			
	select		@my_out_datetimeoffset		     = @my_in_datetimeoffset		
	select		@my_out_decimal				     = @my_in_decimal				
	select		@my_out_float				     = @my_in_float				
	select		@my_out_geography			     = @my_in_geography			
	select		@my_out_geometry			     = @my_in_geometry			
	select		@my_out_hierarchyid			     = @my_in_hierarchyid			
	select		@my_out_image				     = @my_in_image				
	select		@my_out_int					     = @my_in_int					
	select		@my_out_money				     = @my_in_money				
	select		@my_out_nchar				     = @my_in_nchar				
	select		@my_out_ntext				     = @my_in_ntext				
	select		@my_out_numeric				     = @my_in_numeric				
	select		@my_out_nvarchar			     = @my_in_nvarchar			
	select		@my_out_real				     = @my_in_real				
	select		@my_out_rowversion			     = @my_in_rowversion			
	select		@my_out_smalldatetime		     = @my_in_smalldatetime		
	select		@my_out_smallint			     = @my_in_smallint			
	select		@my_out_smallmoney			     = @my_in_smallmoney			
	select		@my_out_sql_variant			     = @my_in_sql_variant			
	select		@my_out_text				     = @my_in_text				
	select		@my_out_time				     = @my_in_time				
	select		@my_out_timestamp			     = @my_in_timestamp			
	select		@my_out_tinyint				     = @my_in_tinyint				
	select		@my_out_uniqueidentifier	     = @my_in_uniqueidentifier	
	select		@my_out_varbinary			     = @my_in_varbinary			
	select		@my_out_varchar				     = @my_in_varchar				
	select		@my_out_xml					     = @my_in_xml					
	
	select		@my_inout_bigint = @my_inout_bigint + @my_in_bigint
	return		42 

end
go

-------------------------------------------------------------------------------------------------
