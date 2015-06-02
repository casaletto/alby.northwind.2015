use northwind ;

--delete from testtable4
sp_help testtable4

select datalength(f_image), * from testtable4





select c.name, c.* 
from sys.syscolumns c, sys.tables t, sys.schemas s
where t.schema_id = s.schema_id
and c.id = t.object_id
and t.name = 'TestTable4'
and s.name = 'dbo'
order by 1

select column_name 
from information_schema.columns
where data_type = 'timestamp'
and table_schema = 'dbo'
and table_name = 'TestTable4'
order by 1



sp_help 'orders'

--columnproperty(id, name , 'IsIdentity' ) = 1

select c.name 
from sys.syscolumns c, sys.tables t, sys.schemas s
where t.schema_id = s.schema_id
and c.id = t.object_id
and columnproperty( c.id, c.name , 'IsIdentity' ) = 1
--and t.name = 'TestTable3'
--and s.name = 'dbo'
order by 1


dbo
TestTable3


select c.name 
from sys.syscolumns c, sys.tables t, sys.schemas s
where t.schema_id = s.schema_id
and c.id = t.object_id
and c.IsComputed = 1
and t.name = 'TestTable3'
and s.name = 'dbo'
order by 1






select c.name, * 
from sys.syscolumns c
where id = 882102183
and IsComputed = 1

select * from sysobjects

select * from sys.tables
select * from sys.schemas



select * from information_schema.tables




select object_name(id) as objectName, name as ColumnName
from sys.syscolumns 
where columnproperty(id, name , 'IsComputed' ) = 1
order by 1 ,2 



-------------------------------------------------------------------------------------------------


select * from testtable3

begin tran
--delete from testtable3
select distinct( isnull(max([id]),0) + 1 ) from testtable3
rollback




select * from  testtable2b

--
delete from testtable2b where person = 'luka' ;

-------------------------------------------------------------------------------------------------


select reportsto,* from Employees

select * from orders
order by 2 


--GetForeignKeyConstraints() ;
select table_schema, table_name, constraint_name 
from INFORMATION_SCHEMA.table_constraints tc
where constraint_type = 'FOREIGN KEY'
and tc.table_schema = 'dbo'
and tc.table_name = 'Orders'
order by constraint_name




select tc2.table_schema, tc2.table_name, tc2.constraint_name, 
tc.table_schema as fk_table_schema, tc.table_name as fk_table, tc.constraint_name as fk_constraint_name 
from 
INFORMATION_SCHEMA.table_constraints tc, 
INFORMATION_SCHEMA.referential_constraints rc, 
INFORMATION_SCHEMA.table_constraints tc2 
where tc.constraint_name = rc.constraint_name 
and rc.unique_constraint_name = tc2.constraint_name 
and tc.constraint_type = 'FOREIGN KEY' 
and tc2.constraint_type = 'PRIMARY KEY'
and tc2.table_schema = 'dbo' 
and tc2.table_name = 'shippers' 
order by fk_table, fk_constraint_name




select tc.constraint_name as fk_constraint_name, tc2.table_schema, tc2.table_name, tc2.constraint_name
from 
INFORMATION_SCHEMA.table_constraints tc, 
INFORMATION_SCHEMA.referential_constraints rc,
INFORMATION_SCHEMA.table_constraints tc2
where tc.constraint_name = rc.constraint_name
and rc.unique_constraint_name = tc2.constraint_name
and tc.constraint_type = 'FOREIGN KEY'
and tc2.constraint_type = 'PRIMARY KEY'
and tc.table_schema = 'dbo'
--and tc.table_name = 'orders'
and tc.table_name = 'orders'
order by tc2.table_name, tc.constraint_name


select * from INFORMATION_SCHEMA.referential_constraints rc

--GetForeignKeyTables()

-- back pointers
select 
tc2.table_schema, tc2.table_name, tc2.constraint_name, 
tc.table_schema as fk_table_schema, tc.table_name as fk_table, tc.constraint_name as fk_constraint_name
from 
INFORMATION_SCHEMA.table_constraints tc, 
INFORMATION_SCHEMA.referential_constraints rc,
INFORMATION_SCHEMA.table_constraints tc2
where tc.constraint_name = rc.constraint_name
and rc.unique_constraint_name = tc2.constraint_name
and tc.constraint_type = 'FOREIGN KEY'
and tc2.constraint_type = 'PRIMARY KEY'
and tc2.table_schema = 'dbo'
and tc2.table_name = 'customers'
order by tc2.table_name, tc.table_name

--GetForeignKeyColumns()
-- fields for forign key table [orders]
select table_schema, table_name, constraint_name, column_name
from INFORMATION_SCHEMA.key_column_usage
where table_name = 'orders'
and table_schema = 'dbo'
and constraint_name = 'FK_Orders_Customers'
order by ordinal_position

--GetPrimaryKeyColumns()
-- fields for primary key table [customers]
select table_schema, table_name, constraint_name, column_name
from INFORMATION_SCHEMA.key_column_usage
where table_name = 'customers'
and table_schema = 'dbo'
and constraint_name = 'PK_Customers'
order by ordinal_position




/*

public class Customers()
{
	// 1 to many releationships - FK_Orders_Customers
	// 1 customer has many orders
										^^^ fields of order table
	public List<Orders> childOrdersByCustomerId( conn ) 
	{
		OrdersFactory f = new Factory() ;
										
		return f.LoadByCustomerId( conn,			this.CustomerId ) ;		
					^^^ fields of order table			^^^ fields of customer table - types not required
	}

}
*/
-----------------------------------------------------------------------------------
-- need to get columns for both the current table and the child table






select tc.table_schema, tc.table_name, tc.constraint_name
from INFORMATION_SCHEMA.table_constraints tc
--where tc.constraint_type = 'foreign key'
where tc.table_name = 'customers'
and tc.table_schema = 'dbo'
order by tc.table_name

select * 
from INFORMATION_SCHEMA.referential_constraints rc
where rc.table_name in ( 'orders', 'customers' )


-------------------------------------------------------------------------


-- get foreign key tables from current tables --
-- obj.CustomersFrom
select tc.table_schema, tc.table_name, tc2.table_schema, tc2.table_name as fk_table_name, tc.constraint_name
from INFORMATION_SCHEMA.table_constraints tc, INFORMATION_SCHEMA.referential_constraints rc, INFORMATION_SCHEMA.table_constraints tc2
where tc.constraint_name = rc.constraint_name
and tc2.constraint_type = 'primary key'
and tc2.constraint_name = rc.unique_constraint_name
and tc.constraint_type = 'foreign key'
and tc.table_name = 'orders'
and tc.table_schema = 'dbo'
order by tc.table_name, fk_table_name

--table_name	fk_table_name	constraint_name	unique_constraint_name
--Orders	Customers	FK_Orders_Customers	PK_Customers
--Orders	Employees	FK_Orders_Employees	PK_Employees
--Orders	Shippers	FK_Orders_Shippers	PK_Shippers

-- get columns of this table <== this one lokks good

select table_name, constraint_name, column_name 
from INFORMATION_SCHEMA.key_column_usage
where table_name = 'orders'
and constraint_name = 'FK_Orders_Customers'
order by table_name, constraint_name, ordinal_position






-- get columns of forign key table
select table_name, constraint_name, column_name 
from INFORMATION_SCHEMA.key_column_usage
where table_name = 'Customers'
and constraint_name = 'PK_Customers'
order by table_name, constraint_name, ordinal_position

-----------------------------------------------------------------------------------------------------------------









-- sql to get foreighn keys

select kcu.Table_name, kcu.constraint_name, kcu.Column_name, kcu.ordinal_position
--tc.*, kcu.*
from INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc, INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu
where tc.constraint_type = 'FOREIGN KEY'
and tc.table_schema = kcu.table_schema
and tc.table_name = kcu.table_name
and tc.constraint_name = kcu.constraint_name
--and tc.table_schema = 'dbo'
--and tc.table_name = 'Order Details'
order by kcu.Table_name, kcu.constraint_name, kcu.Column_name, kcu.ordinal_position





-------------------------------------------------------------------------

select * from INFORMATION_SCHEMA.KEY_COLUMN_USAGE



-- get primary keys

select kcu.Column_name 
from INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc, INFORMATION_SCHEMA.KEY_COLUMN_USAGE kcu
where tc.constraint_type = 'PRIMARY KEY'
and tc.table_schema = kcu.table_schema
and tc.table_name = kcu.table_name
and tc.constraint_name = kcu.constraint_name
and tc.table_schema = 'dbo'
and tc.table_name = 'Order Details'
order by kcu.ordinal_position


-------------------------------------------------------------------------

select reportsto, * from employees
where employeeid = 7

select * from employeeTerritories
select * from Territories
select * from Region




-------------------------------------------------------------------------

select * from products
where discontinued = 1
order by ProductName

select * from products
where ProductId= 17
order by ProductName


-------------------------------------------------------------------------

select table_schema, table_name, table_schema + '.' + table_name as TheTable
from information_schema.tables
where table_type = 'BASE TABLE'
order by table_name



-------------------------------------------------------------------------

select * from [Customer and Suppliers by City] --[Alphabetical list of products]
where city = 'Köln'
order by 1







-------------------------------------------------------------------------


select table_schema, table_name, table_schema + '.' + table_name as TheView
from information_schema.views
order by table_name



-------------------------------------------------------------------------
select top 1
* from 
customers c, orders o
where c.customerid = o.customerid
order by c.companyname, o.orderdate

-------------------------------------------------------------------------



select * from 
    customers c, orders o
     where 1 > 2




-- hello

declare @customerId nvarchar(500)
select @customerId = N'quick'

select * from 
customers c, orders o
where c.customerid = o.customerid
and c.customerid = @customerId
order by c.companyname, o.orderdate



'Taucherstraße 10'

--------------------------------------

declare @region nvarchar(500)
select @region = N'Québec'
select @region = null

select * from 
customers c, orders o

where c.customerid = o.customerid
and isnull(c.region, '') = isnull(@region, '')
order by c.companyname, o.orderdate


---------------------------
LoadByCustomerIdEmployeeIdOrderDateFreight

select * from 
customers c, orders o

where c.customerid = o.customerid
and c.customerid = 'anatr'
and o.employeeid = 3
and o.orderdate = '1997-08-08'
and o.freight = 43.90
order by c.companyname, o.orderdate



--------------------------
--declare @shippedDate datetime
declare @shippedDate nvarchar(100)
select @shippedDate = '1997-10-21'

select * from 
customers c, orders o
where c.customerid = o.customerid
and coalesce( o.shippeddate, '1900-01-01' ) = coalesce( @shippedDate, '1900-01-01' )
--------------------------


select * from []