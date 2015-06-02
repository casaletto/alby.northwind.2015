-------------------------------------------------------------------------------------------------

IF  EXISTS 
(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CodegenTestMathParameters]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CodegenTestMathParameters]
GO

-------------------------------------------------------------------------------------------------

create PROCEDURE [dbo].[CodegenTestMathParameters]
(
	@a				bigint,
	@b				bigint,
	@difference		bigint out,
	@product		bigint out,
	@quotient		bigint out
) 
AS
begin
	set ansi_warnings on
	
	select @difference 	= @a - @b
	select @product 	= @a * @b
	select @quotient 	= @a / @b
	
	return @a + @b
end
go

-------------------------------------------------------------------------------------------------
