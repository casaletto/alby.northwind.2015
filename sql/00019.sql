-------------------------------------------------------------------------------------------------

IF OBJECT_ID( '[dbo].[CodegenTestStoredProcTableType]' ) IS NOT NULL
DROP PROCEDURE [dbo].[CodegenTestStoredProcTableType]
GO

-------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].CodegenTestStoredProcTableType
(
    @dt [NameAddressTableType] READONLY
)
AS
BEGIN

    SELECT   Name, Address, State
    FROM     @dt
    ORDER BY [Address] DESC

END
GO

-------------------------------------------------------------------------------------------------------
