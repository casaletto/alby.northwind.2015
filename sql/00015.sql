-------------------------------------------------------------------------------------------------

IF  EXISTS 
(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CodegenTestDatasetNotRecordset1]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CodegenTestDatasetNotRecordset1]
GO

-------------------------------------------------------------------------------------------------

create PROCEDURE [dbo].[CodegenTestDatasetNotRecordset1]
(
	@orderID int
)
AS
begin

	set nocount on
	
	declare @sql nvarchar(max)
	declare @params nvarchar(max)

	select @sql = 
	N'
		select	OrderID, CustomerID, EmployeeID, ShipAddress, ShipCity 
		into #t
		from	dbo.Orders
		where	orderid = @orderid 
		order by 1, 2
		
		select * from #t	
	'
	
	select @params = N' @orderid int'
	exec sp_executesql @sql, @params, @orderID = @orderid

end
go
-------------------------------------------------------------------------------------------------

--set fmtonly on
exec [dbo].[CodegenTestDatasetNotRecordset1] 10253
--set fmtonly off

-------------------------------------------------------------------------------------------------
