-------------------------------------------------------------------------------------------------

IF  EXISTS 
(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CodegenTestDatasetNotRecordset2]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CodegenTestDatasetNotRecordset2]
GO

-------------------------------------------------------------------------------------------------

create PROCEDURE [dbo].[CodegenTestDatasetNotRecordset2]
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
		into	#t
		from	dbo.Orders
		where	orderid = @orderid 
		order by 1, 2
		
		select * from #t	
	'
	
	select @params = N' @orderid int'
	exec sp_executesql @sql, @params, @orderID = @orderid

	select @sql = 
	N'
		select distinct CustomerID, EmployeeID
		into	#t
		from	dbo.Orders
		where	EmployeeID = 
		(
			select	EmployeeID 
			from	dbo.Orders
			where	OrderID = @orderid
		)
		order by 1
		
		select * from #t	
	'
	
	select @params = N' @orderid int'
	exec sp_executesql @sql, @params, @orderID = @orderid

end
go
-------------------------------------------------------------------------------------------------

--set fmtonly on
exec [dbo].[CodegenTestDatasetNotRecordset2] 10253
--set fmtonly off

-------------------------------------------------------------------------------------------------
