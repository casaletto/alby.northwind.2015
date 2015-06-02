-------------------------------------------------------------------------------------------------

--use northwind
--go

-------------------------------------------------------------------------------------------------

drop table dbo.TestTable3
go

-------------------------------------------------------------------------------------------------

create table dbo.TestTable3
(
	[ID]			int not null,
	[A]				int,
	[B]				int,
	[C]				int default 42,
	[TheSum]		as [A] + [B],
	[TheProduct]	as [A] * [B],

	update_date datetime		not null,	
	constraint PK_TestTable3 primary key( [ID] )
)
go

sp_help TestTable3

--insert into dbo.TestTable3 
--( ID, A, B, C, TheSum, TheProduct, update_date )
--values 
--( 1, 10, 20, 100, default, default, getdate() );

--insert into dbo.TestTable3 
--( ID, A, B, C, update_date )
--values 
--( 1, 10, 20, -100, getdate() );

insert into dbo.TestTable3 
( ID, A, update_date )
values 
( 2, 10, getdate() );

go

-------------------------------------------------------------------------------------------------

--select * from dbo.TestTable3
--go

-------------------------------------------------------------------------------------------------
