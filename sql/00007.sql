
-------------------------------------------------------------------------------------------------

--NOTRANSACTION--
begin try
	drop table dbo.TestTable6a
end try
begin catch
end catch
go

--NOTRANSACTION--
begin try
	drop table dbo.TestTable6b
end try
begin catch
end catch
go

-------------------------------------------------------------------------------------------------

--NOTRANSACTION--
create table dbo.TestTable6a
(
	[ID]			int not null,
	[Name]			nvarchar(1000),
	[Age]			int,
	[update_date]	[datetime] NOT NULL,

	constraint PK_TestTable6a primary key( [ID] )
)
go

-------------------------------------------------------------------------------------------------
