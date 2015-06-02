--use northwind ;
--exec sp_help Orders

begin tran

INSERT INTO [dbo].[Orders] DEFAULT VALUES ; select scope_identity()

/*
INSERT INTO [dbo].[Orders]
           ([CustomerID]
           ,[EmployeeID]
           ,[OrderDate]
           ,[RequiredDate]
           ,[ShippedDate]
           ,[ShipVia]
           ,[Freight]
           ,[ShipName]
           ,[ShipAddress]
           ,[ShipCity]
           ,[ShipRegion]
           ,[ShipPostalCode]
           ,[ShipCountry])
     VALUES
           (<CustomerID, nchar(5),>
           ,<EmployeeID, int,>
           ,<OrderDate, datetime,>
           ,<RequiredDate, datetime,>
           ,<ShippedDate, datetime,>
           ,<ShipVia, int,>
           ,<Freight, money,>
           ,<ShipName, nvarchar(40),>
           ,<ShipAddress, nvarchar(60),>
           ,<ShipCity, nvarchar(15),>
           ,<ShipRegion, nvarchar(15),>
           ,<ShipPostalCode, nvarchar(10),>
           ,<ShipCountry, nvarchar(15),>)
*/

--declare @id int
--select @id = scope_identity() ; 
--select * from [dbo].[Orders] where orderid = @id ;

rollback