-------------------------------------------------------------------------------------------------

IF  EXISTS 
(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CodegenTestFourResultSets]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[CodegenTestFourResultSets]
GO

-------------------------------------------------------------------------------------------------

create PROCEDURE [dbo].[CodegenTestFourResultSets]
(
	@orderID int
)
AS
begin

	select	OrderID, CustomerID, EmployeeID, ShipAddress, ShipCity
	from	dbo.Orders
	where	orderid = @orderid 

		declare @CustomerID varchar(100)
		select	@CustomerID = CustomerID  
		from	dbo.Orders
		where	orderid = @orderid 

	select	CustomerID, CompanyName, Address 
	from	dbo.Customers 
	where	CustomerID = @CustomerID 

		declare @employeeID int
		select	@employeeID = EmployeeID   
		from	dbo.Orders
		where	orderid = @orderid 

	select	EmployeeID, LastName, FirstName, Address, City  
	from	dbo.Employees 
	where	employeeID = @employeeID 

	select		OrderID, CustomerID, EmployeeID  
	from		dbo.Orders
	where		EmployeeID = @employeeID 
	order by	OrderID

end
go
-------------------------------------------------------------------------------------------------

--exec [dbo].[CodegenTestFourResultSets] 10253

-------------------------------------------------------------------------------------------------

