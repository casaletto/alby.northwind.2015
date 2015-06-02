-------------------------------------------------------------------------------------------------

IF OBJECT_ID( '[dbo].[CodegenTableTypePrecisionScaleTest]' ) IS NOT NULL
DROP PROCEDURE [dbo].CodegenTableTypePrecisionScaleTest
GO

-------------------------------------------------------------------------------------------------------

IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id 
			WHERE st.name = N'MyPrecisonScaleTableType' AND ss.name = N'dbo')
DROP TYPE [dbo].MyPrecisonScaleTableType
GO

-------------------------------------------------------------------------------------------------------
--
-- decimal		-10^38 +1 through 10^38 - 1
-- money		-922,337,203,685,477.5808 to 922,337,203,685,477.5807
-- smallmoney	-214,748.3648 to 214,748.3647
--

CREATE TYPE [dbo].MyPrecisonScaleTableType AS TABLE
(
	TheMoney		money,
	TheSmallMoney	smallmoney,
	
	TheDecimal0		decimal, --18, 0
	TheDecimal1		decimal(29, 28),
	TheDecimal2		decimal(38,  1),

	TheNumeric0		numeric,
	TheNumeric1		numeric(29, 28),
	TheNumeric2		numeric(38,  1)
)
GO

-------------------------------------------------------------------------------------------------------


CREATE PROCEDURE [dbo].CodegenTableTypePrecisionScaleTest
(
    @list dbo.MyPrecisonScaleTableType READONLY
)
AS
BEGIN

	select *
	from @list

END
GO

-------------------------------------------------------------------------------------------------------
