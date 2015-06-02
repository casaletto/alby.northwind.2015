-------------------------------------------------------------------------------------------------

--use northwind
go

-------------------------------------------------------------------------------------------------

drop table dbo.TestTable4
go

-------------------------------------------------------------------------------------------------

create table dbo.TestTable4
(
	[ID]			uniqueidentifier  not null,
	f_guid			uniqueidentifier,
	f_bigint		bigint,
	f_int			int,
	f_smallint		smallint,
	f_bit			bit,
	f_decimal		decimal(28,12),
    f_numeric		numeric(28,12),
	f_money			money,
	f_smallmoney	smallmoney,
	f_float			float,
	f_real			real,
	f_datetime		datetime,
	f_smalldatetime smalldatetime,
	f_char			char(10),
	f_varchar		varchar(10),
	f_text			text,
	f_nchar			nchar(10),
	f_nvarchar		nvarchar(10),
	f_ntext			ntext,
	f_binary		binary(10),
	f_varbinary		varbinary(10),
	f_image			image,
	f_xml			xml,
	f_timestamp		timestamp,

	constraint PK_TestTable4 primary key( [ID] )
)
go

--sp_help TestTable4
go

-------------------------------------------------------------------------------------------------

--select * from dbo.TestTable4
go

-------------------------------------------------------------------------------------------------
