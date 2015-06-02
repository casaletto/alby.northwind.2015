-------------------------------------------------------------------------------------------------

IF OBJECT_ID( '[dbo].[CodegenTestStoredProcVarmaxUnicodeTest]' ) IS NOT NULL
DROP PROCEDURE [dbo].[CodegenTestStoredProcVarmaxUnicodeTest]
GO

-------------------------------------------------------------------------------------------------------

IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id 
			WHERE st.name = N'MyVarmaxUnicodeTableType1' AND ss.name = N'dbo')
DROP TYPE [dbo].MyVarmaxUnicodeTableType1
GO

IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id 
			WHERE st.name = N'MyVarmaxUnicodeTableType2' AND ss.name = N'dbo')
DROP TYPE [dbo].MyVarmaxUnicodeTableType2
GO

IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id 
			WHERE st.name = N'MyVarmaxUnicodeTableType3' AND ss.name = N'dbo')
DROP TYPE [dbo].MyVarmaxUnicodeTableType3
GO

IF  EXISTS (SELECT * FROM sys.types st JOIN sys.schemas ss ON st.schema_id = ss.schema_id 
			WHERE st.name = N'MyVarmaxUnicodeTableType4' AND ss.name = N'dbo')
DROP TYPE [dbo].MyVarmaxUnicodeTableType4
GO

-------------------------------------------------------------------------------------------------------

CREATE TYPE [dbo].MyVarmaxUnicodeTableType1 AS TABLE
(
	MyVarBinary		varbinary(max),
	MyVarChar		varchar(max),
	MyNVarChar		nvarchar(max),
	MyText			text,
	MyNText			ntext,	
	MyImage			image,
	MyXml			xml
)
GO

CREATE TYPE [dbo].MyVarmaxUnicodeTableType2 AS TABLE
(
	MyBinary binary(8000)
)
GO

CREATE TYPE [dbo].MyVarmaxUnicodeTableType3 AS TABLE
(
	MyChar char(8000)
)
GO

CREATE TYPE [dbo].MyVarmaxUnicodeTableType4 AS TABLE
(
	MyNChar	nchar(4000)	
)
GO

-------------------------------------------------------------------------------------------------------

CREATE PROCEDURE [dbo].[CodegenTestStoredProcVarmaxUnicodeTest]
(
    @myudt1 MyVarmaxUnicodeTableType1 READONLY,
    @myudt2 MyVarmaxUnicodeTableType2 READONLY,
    @myudt3 MyVarmaxUnicodeTableType3 READONLY,
    @myudt4 MyVarmaxUnicodeTableType4 READONLY
)
AS
BEGIN

	select
		LEN(		 MyBinary     )				AS LenMyBinary,		
		LEN(		 MyVarBinary  )				AS LenMyVarBinary,		
		LEN(		 MyChar		  )				AS LenMyChar,		
		LEN(		 MyNChar	  )				AS LenMyNChar,			
		LEN(		 MyVarChar	  )				AS LenMyVarChar,	
		LEN(		 MyNVarChar	  )				AS LenMyNVarChar,	
		DATALENGTH ( MyText		  )				AS LenMyText,		
		DATALENGTH ( MyNText	  )				AS LenMyNText,			
		DATALENGTH ( MyImage	  )				AS LenMyImage,			
		LEN( cast(   MyXml as nvarchar(max) ) )	AS LenMyXml		
	from 
		@myudt1, 
		@myudt2, 
		@myudt3, 
		@myudt4

END
GO

-------------------------------------------------------------------------------------------------------
