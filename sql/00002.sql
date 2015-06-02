-------------------------------------------------------------------------------------------------

--use northwind
--go

-------------------------------------------------------------------------------------------------

drop table dbo.TestTable2b
go


drop table dbo.TestTable2a
go

-------------------------------------------------------------------------------------------------

create table dbo.TestTable2a
(
	[State]		nvarchar(3)		not null,
	[PostCode]	nvarchar(4)		not null,
	[Suburb]	nvarchar(100)	not null,
	update_date datetime		not null,	
	constraint PK_TestTable2a primary key( [State], [PostCode] )
)
go

insert into dbo.TestTable2a values 
( 'NSW', '2018', 'Rosebery', getdate() );

insert into dbo.TestTable2a values 
( 'NSW', '2565', 'Ingleburn', getdate() );

insert into dbo.TestTable2a values 
( 'NSW', '2000', 'City', getdate() );

go

-------------------------------------------------------------------------------------------------

create table dbo.TestTable2b
(
	[Person]		nvarchar(20)	primary key not null,
	[MailPostCode]	nvarchar(4)		not null,
	[MailState]		nvarchar(3)		not null,
	[HomePostCode]	nvarchar(4)		not null,
	[HomeState]		nvarchar(3)		not null,
	update_date		datetime		not null,

	constraint FK_TestTable2b_TestTable2a_Mail foreign key( [MailState], [MailPostCode] ) references dbo.TestTable2a( [State], [PostCode] ),
	constraint FK_TestTable2b_TestTable2a_Home foreign key( [HomeState], [HomePostCode] ) references dbo.TestTable2a( [State], [PostCode] )
)
go

insert into dbo.TestTable2b values 
( 'Albert', '2000', 'NSW', '2565', 'NSW', getdate() );

insert into dbo.TestTable2b values 
( 'Ana', '2565', 'NSW', '2565', 'NSW', getdate() );

insert into dbo.TestTable2b values 
( 'Nannu', '2018', 'NSW', '2018', 'NSW', getdate() );

-------------------------------------------------------------------------------------------------

--select * from dbo.TestTable2a
--select * from dbo.TestTable2b
--go

-------------------------------------------------------------------------------------------------
