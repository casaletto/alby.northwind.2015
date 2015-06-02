-----------------------------------------------------------------------------
--
-- Japanese fruit table
--
-----------------------------------------------------------------------------

if  exists 
(
	select * 
	from sys.objects 
	where object_id = object_id( N'[dbo].[フルーツ]' ) 
	and type in ( N'U')
)
drop table [dbo].[フルーツ]
go

-----------------------------------------------------------------------------

create table [dbo].[フルーツ]
(
	[フルーツ]			nvarchar(50) not null,	-- japanese
	[fruit]				nvarchar(50),			-- english
	[פרי]				nvarchar(50),			-- hebrew
	[καρπός]			nvarchar(50),			-- greeek
	[update_date]		datetime not null,
	
	constraint [pk_フルーツ] primary key clustered 
	(
		[フルーツ] asc
	)
)
go

-----------------------------------------------------------------------------

--select * from [dbo].[フルーツ]
