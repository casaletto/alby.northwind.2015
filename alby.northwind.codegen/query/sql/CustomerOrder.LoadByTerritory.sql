where c.customerid = o.customerid
and 
o.EmployeeID in
(
	select	distinct EmployeeID 
	from	dbo.EmployeeTerritories  
	where	TerritoryId in
	(
		select	distinct TerritoryID 
		from	Territories 
		where	TerritoryDescription = @territoryDescription
	)
)
and 
year( o.orderdate ) = @orderYear

