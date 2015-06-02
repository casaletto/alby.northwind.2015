-------------------------------------------------------------------------------------------------

IF  EXISTS 
(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CodegenTestResultSetTypesAllNull]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CodegenTestResultSetTypesAllNull]
GO

-------------------------------------------------------------------------------------------------

create PROCEDURE [dbo].[CodegenTestResultSetTypesAllNull]
AS
begin

	declare @my_bigint				 bigint				
	declare @my_binary				 binary				
	declare @my_bit					 bit					
	declare @my_char				 char				
	declare @my_date				 date				
	declare @my_datetime			 datetime			
	declare @my_datetime2			 datetime2			
	declare @my_datetimeoffset		 datetimeoffset		
	declare @my_decimal				 decimal				
	declare @my_float				 float				
	declare @my_geography			 geography			
	declare @my_geometry			 geometry			
	declare @my_hierarchyid			 hierarchyid			
	declare @my_image				 varbinary(max) --image				
	declare @my_int					 int					
	declare @my_money				 money				
	declare @my_nchar				 nchar				
	declare @my_ntext				 nvarchar(max)  --ntext				
	declare @my_numeric				 numeric				
	declare @my_nvarchar			 nvarchar			
	declare @my_real				 real				
	declare @my_rowversion			 rowversion			
	declare @my_smalldatetime		 smalldatetime		
	declare @my_smallint			 smallint			
	declare @my_smallmoney			 smallmoney			
	declare @my_sql_variant			 sql_variant			
	declare @my_text				 varchar(max) --text				
	declare @my_time				 time				
	declare @my_timestamp			 timestamp			
	declare @my_tinyint				 tinyint				
	declare @my_uniqueidentifier	 uniqueidentifier	
	declare @my_varbinary			 varbinary			
	declare @my_varchar				 varchar				
	declare @my_xml					 xml					

	select
		 @my_bigint				      as my_bigint				
		,@my_binary				      as my_binary				
		,@my_bit					  as my_bit					
		,@my_char				      as my_char				
		,@my_date				      as my_date				
		,@my_datetime			      as my_datetime			
		,@my_datetime2			      as my_datetime2			
		,@my_datetimeoffset		      as my_datetimeoffset		
		,@my_decimal				  as my_decimal				
		,@my_float				      as my_float				
		,@my_geography			      as my_geography			
		,@my_geometry			      as my_geometry			
		,@my_hierarchyid			  as my_hierarchyid			
		,cast( @my_image as image) 	  as my_image				
		,@my_int					  as my_int					
		,@my_money				      as my_money				
		,@my_nchar				      as my_nchar				
		,cast( @my_ntext as ntext )   as my_ntext				
		,@my_numeric				  as my_numeric				
		,@my_nvarchar			      as my_nvarchar			
		,@my_real				      as my_real				
		,@my_rowversion			      as my_rowversion			
		,@my_smalldatetime		      as my_smalldatetime		
		,@my_smallint			      as my_smallint			
		,@my_smallmoney			      as my_smallmoney			
		,@my_sql_variant			  as my_sql_variant			
		,cast( @my_text	as text )	  as my_text				
		,@my_time				      as my_time				
		,@my_timestamp			      as my_timestamp			
		,@my_tinyint				  as my_tinyint				
		,@my_uniqueidentifier	      as my_uniqueidentifier	
		,@my_varbinary			      as my_varbinary			
		,@my_varchar				  as my_varchar				
		,@my_xml					  as my_xml					

end
go

-------------------------------------------------------------------------------------------------
