


INSERT INTO [dbo].[TestTable5]
(
	[f_nvarchar], [update_date]
)
VALUES
(
	N'aaaaaaaa', getdate()
)

INSERT INTO [dbo].[TestTable5]
(
	[f_nvarchar], [update_date]
)
VALUES
(
	N'bbbbbbb', getdate()
)

insert into dbo.TestTable3 
( ID, A, B, C, update_date )
values 
( 1, 10, 20, -100, getdate() );


INSERT INTO [dbo].[TestTable5]
(
	[f_nvarchar], [update_date]
)
VALUES
(
	N'cccccccc', getdate()
)
