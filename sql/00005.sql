-------------------------------------------------------------------------------------------------

--use northwind
--go

-------------------------------------------------------------------------------------------------

drop table dbo.TestTable5
go

-------------------------------------------------------------------------------------------------

create table dbo.TestTable5
(
	[ID]			int identity not null,
	[f_int]			int,
	[f_nvarchar]	nvarchar(1000),
	[update_date]	[datetime] NOT NULL,

	constraint PK_TestTable5 primary key( [ID] )
)
go

-------------------------------------------------------------------------------------------------

INSERT INTO [dbo].[TestTable5]
(
	[f_nvarchar], [update_date]
)
VALUES
(
	N'hello', getdate()
)

select * from dbo.TestTable5
go

-------------------------------------------------------------------------------------------------

raiserror( 'XXXXXXXXXXXXXXXXXXXXXXXXXXXX', 10, 1 )


INSERT INTO [dbo].[TestTable5]
(
	[f_nvarchar], [update_date]
)
VALUES
(
	N'hello', getdate()
)

raiserror( 'AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA', 10, 1 )
