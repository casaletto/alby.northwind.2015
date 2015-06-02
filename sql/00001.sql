--use northwind
--go

drop table dbo.TestTable1
go

create table dbo.TestTable1
(
	[The Key] int not null primary key,
	[The Value] nvarchar(1000),
	update_date datetime not null
)
go



insert into dbo.TestTable1 values 
( 1, 'test value 1', getdate() );

insert into dbo.TestTable1 values 
( 2, 'test value 2', getdate() );
go




drop view dbo.TestView1
go

create view dbo.TestView1
as 
	select [The Key], [The Value] 
	from dbo.TestTable1
go

--select * from dbo.TestTable1
--select * from dbo.TestView1
--go




