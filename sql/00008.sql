--
-- testing unicode table and field names
--
-------------------------------------------------------------------------------------------------


--NOTRANSACTION--
begin try
	drop table dbo.[TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒˇˈˊⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏۝]
end try
begin catch
end catch
go

-------------------------------------------------------------------------------------------------

--NOTRANSACTION--
create table 
dbo.[TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒˇˈˊⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏۝]
(
	[ID_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒˇˈˊⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏۝]	
	int identity not null,

	CategoryID		int not null,
	CustomerID		nchar(5) not null,
	EmployeeID		int not null,
	OrderID			int not null,
	ProductID		int not null,
	RegionID		int not null,
	ShipperID		int not null,
	SupplierID		int not null,
	TerritoryID		nvarchar(20) not null,
	update_date		datetime not null,

	constraint 
	[PK_TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒˇˈˊⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏۝] 
	primary key
	( 
		[ID_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒˇˈˊⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏۝] 
	),
	
	constraint 
	[FK_TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒˇˈˊⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏۝_Categories] 
	foreign key 
	( CategoryID ) 
	references 
	dbo.Categories( CategoryID ),

	constraint 
	[FK_TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒˇˈˊⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏۝_Customers] 
	foreign key 
	( CustomerID ) 
	references 
	dbo.Customers( CustomerID ),

	constraint 
	[FK_TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒˇˈˊⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏۝_Employees] 
	foreign key 
	( EmployeeID ) 
	references 
	dbo.Employees( EmployeeID ),

	constraint 
	[FK_TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒˇˈˊⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏۝_Orders] 
	foreign key 
	( OrderID ) 
	references 
	dbo.Orders( OrderID ),

	constraint 
	[FK_TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒˇˈˊⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏۝_Products] 
	foreign key 
	( ProductID ) 
	references 
	dbo.Products( ProductID ),

	constraint 
	[FK_TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒˇˈˊⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏۝_Region] 
	foreign key 
	( RegionID ) 
	references 
	dbo.Region( RegionID ),

	constraint 
	[FK_TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒˇˈˊⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏۝_Shippers] 
	foreign key 
	( ShipperID ) 
	references 
	dbo.Shippers( ShipperID ),

	constraint 
	[FK_TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒˇˈˊⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏۝_Suppliers] 
	foreign key 
	( SupplierID ) 
	references 
	dbo.Suppliers( SupplierID ),

	constraint 
	[FK_TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒˇˈˊⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏۝_Territories] 
	foreign key 
	( TerritoryID ) 
	references 
	dbo.Territories( TerritoryID )

)
go

-------------------------------------------------------------------------------------------------
--exec sp_help N'dbo.[TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒˇˈˊⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏۝]'
--
--select * 
--from dbo.[TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒˇˈˊⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏۝]
-------------------------------------------------------------------------------------------------

