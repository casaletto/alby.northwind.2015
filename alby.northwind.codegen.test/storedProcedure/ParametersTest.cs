using System;
using System.Collections.Generic;
using System.Text;
using System.Data ;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Transactions ;
using Microsoft.SqlServer.Types;

using NUnit.Framework ;
using ACR = alby.codegen.runtime ;
using NW = alby.northwind.codegen  ;

namespace alby.northwind.codegen.test.storedProcedure
{	
	[TestFixture]
	public class ParametersTest : NW.test.TransactionScopeTestBase
	{
		public ParametersTest()
		{
			_connectionString = Settings.ConnectionString();
			ACR.CodeGenEtc.DebugSql = true ;
		}

		[Test]
		public void TestParametersNotNull()
		{
			var factory = new NW.storedProcedure.StoredProcedureFactory() ;

			long?				my_in_bigint			= 123456789L ;
			byte[]				my_in_binary			= new byte[] { 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77, 0x88, 0x99 } ;
			bool?				my_in_bit				= true ;
			string				my_in_char				= "Aabcdefghihjkl" ;
			DateTime?			my_in_date				= new DateTime( 2000, 1, 1, 1, 2, 3 ) ;
			DateTime?			my_in_datetime			= new DateTime( 2000, 2, 2, 1, 2, 3 ) ;
			DateTime?			my_in_datetime2			= new DateTime( 2000, 3, 3, 1, 2, 3 ) ;
			DateTimeOffset?		my_in_datetimeoffset	= new DateTimeOffset( 2000, 4, 4, 1, 2, 3, new TimeSpan(  1, 1, 0 ) ) ;
			decimal?			my_in_decimal			= 21234567.12345678901234567m ;
			double?				my_in_float				= 31234567.12345678901234567 ;
			SqlGeography		my_in_geography			= SqlGeography.Parse( "LINESTRING( 0.0 0.0, 1.0 1.0, 0.0 2.0 )" ) ;
			SqlGeometry			my_in_geometry			= SqlGeometry.Parse(  "LINESTRING( 0.0 0.0, 2.0 2.0, 0.0 3.0 )" ) ;
			SqlHierarchyId?		my_in_hierarchyid		= SqlHierarchyId.Parse( "/1/2/" )   ;
			byte[]				my_in_image				= new byte[] { 0xAA, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77, 0x88, 0x99 } ;
			int?				my_in_int				= 31234567 ;
			decimal?			my_in_money				= 41234567.12345678901234567m ;
			string				my_in_nchar				= "Babcdefghihjkl" ;
			string				my_in_ntext				= "Cabcdefghihjkl" ;
			decimal?			my_in_numeric			= 51234567.12345678901234567m ;
			string				my_in_nvarchar			= "Dabcdefghihjkl" ;
			float?				my_in_real				= 61234567.12345678901234567f ;
			byte[]				my_in_rowversion		= new byte[] { 0xBB, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77 } ; 
			DateTime?			my_in_smalldatetime		= new DateTime( 2000, 4, 4, 1, 2, 3 ) ;
			short?				my_in_smallint			= 6123 ;
			decimal?			my_in_smallmoney		= 12345.12345678901234567m ;
			object				my_in_sql_variant		= 81234567.12345678901234567m ;
			string				my_in_text				= "Eabcdefghihjkl" ;
			TimeSpan?			my_in_time				= new TimeSpan(  2, 1, 1 ) ;
			byte[]				my_in_timestamp			= new byte[] { 0xCC, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77 } ; 
			byte?				my_in_tinyint			= 123 ;
			Guid?				my_in_uniqueidentifier	= Guid.NewGuid() ;
			byte[]				my_in_varbinary			= new byte[] { 0xDD, 0x11, 0x22, 0x33, 0x44, 0x55, 0x66, 0x77, 0x88, 0x99 } ;
			string				my_in_varchar			= "Fabcdefghihjkl" ;
			string				my_in_xml				= "<root>hi</root>" ;
			long?				my_out_bigint			= null ;
			byte[]				my_out_binary			= null ;
			bool?				my_out_bit				= null ;
			string				my_out_char				= null ;
			DateTime?			my_out_date				= null ;
			DateTime?			my_out_datetime			= null ;
			DateTime?			my_out_datetime2		= null ;
			DateTimeOffset?		my_out_datetimeoffset	= null ;
			decimal?			my_out_decimal			= null ;
			double?				my_out_float			= null ;
			SqlGeography		my_out_geography		= null ;
			SqlGeometry			my_out_geometry			= null ;
			SqlHierarchyId?		my_out_hierarchyid		= null ;
			byte[]				my_out_image			= null ;
			int?				my_out_int				= null ;
			decimal?			my_out_money			= null ;
			string				my_out_nchar			= null ;
			string				my_out_ntext			= null ;
			decimal?			my_out_numeric			= null ;
			string				my_out_nvarchar			= null ;
			float?				my_out_real				= null ;
			byte[]				my_out_rowversion		= null ;
			DateTime?			my_out_smalldatetime	= null ;
			short?				my_out_smallint			= null ;
			decimal?			my_out_smallmoney		= null ;
			object				my_out_sql_variant		= null ;
			string				my_out_text				= null ;
			TimeSpan?			my_out_time				= null ;
			byte[]				my_out_timestamp		= null ;
			byte?				my_out_tinyint			= null ;
			Guid?				my_out_uniqueidentifier = null ;
			byte[]				my_out_varbinary		= null ;
			string				my_out_varchar			= null ;
			string				my_out_xml				= null ;
			long?				my_inout_bigint			= 223456789L ;

			int rc = factory.CodegenTestParameters( 
				this._connection,
				my_in_bigint,
				my_in_binary,
				my_in_bit,
				my_in_char,
				my_in_date,
				my_in_datetime,
				my_in_datetime2,
				my_in_datetimeoffset,
				my_in_decimal,
				my_in_float,
				my_in_geography,
				my_in_geometry,
				my_in_hierarchyid,
				my_in_image,
				my_in_int,
				my_in_money,
				my_in_nchar,
				my_in_ntext,
				my_in_numeric,
				my_in_nvarchar,
				my_in_real,
				my_in_rowversion,
				my_in_smalldatetime,
				my_in_smallint,
				my_in_smallmoney,
				my_in_sql_variant,
				my_in_text,
				my_in_time,
				my_in_timestamp,
				my_in_tinyint,
				my_in_uniqueidentifier,
				my_in_varbinary,
				my_in_varchar,
				my_in_xml,
				ref my_out_bigint,
				ref my_out_binary,
				ref my_out_bit,
				ref my_out_char,
				ref my_out_date,
				ref my_out_datetime,
				ref my_out_datetime2,
				ref my_out_datetimeoffset,
				ref my_out_decimal,
				ref my_out_float,
				ref my_out_geography,
				ref my_out_geometry,
				ref my_out_hierarchyid,
				ref my_out_image,
				ref my_out_int,
				ref my_out_money,
				ref my_out_nchar,
				ref my_out_ntext,
				ref my_out_numeric,
				ref my_out_nvarchar,
				ref my_out_real,
				ref my_out_rowversion,
				ref my_out_smalldatetime,
				ref my_out_smallint,
				ref my_out_smallmoney,
				ref my_out_sql_variant,
				ref my_out_text,
				ref my_out_time,
				ref my_out_timestamp,
				ref my_out_tinyint,
				ref my_out_uniqueidentifier,
				ref my_out_varbinary,
				ref my_out_varchar,
				ref my_out_xml,
				ref my_inout_bigint			) ;

			Console.WriteLine( "rc = [{0}]",						   rc ) ;
			Console.WriteLine( "my_inout_bigint = [{0}]",			   my_inout_bigint ) ;
			Console.WriteLine( "my_out_bigint = [{0}]", 			   my_out_bigint ) ;
			Console.WriteLine( "my_out_binary = [{0}]",                my_out_binary.Length ) ;
			Console.WriteLine( "my_out_bit = [{0}]",                   my_out_bit ) ;
			Console.WriteLine( "my_out_char = [{0}]",                  my_out_char ) ;
			Console.WriteLine( "my_out_date = [{0}]",                  my_out_date ) ;
			Console.WriteLine( "my_out_datetime = [{0}]",              my_out_datetime ) ;
			Console.WriteLine( "my_out_datetime2 = [{0}]",             my_out_datetime2 ) ;
			Console.WriteLine( "my_out_datetimeoffset = [{0}]",        my_out_datetimeoffset ) ;
			Console.WriteLine( "my_out_decimal = [{0}]",               my_out_decimal ) ;
			Console.WriteLine( "my_out_float = [{0}]",                 my_out_float ) ;
			Console.WriteLine( "my_out_geography = [{0}]",             my_out_geography ) ;
			Console.WriteLine( "my_out_geometry = [{0}]",              my_out_geometry ) ;
			Console.WriteLine( "my_out_hierarchyid = [{0}]",           my_out_hierarchyid ) ;
			Console.WriteLine( "my_out_image = [{0}]",                 my_out_image.Length ) ;
			Console.WriteLine( "my_out_int = [{0}]",                   my_out_int ) ;
			Console.WriteLine( "my_out_money = [{0}]",                 my_out_money ) ;
			Console.WriteLine( "my_out_nchar = [{0}]",                 my_out_nchar ) ;
			Console.WriteLine( "my_out_ntext = [{0}]",                 my_out_ntext ) ;
			Console.WriteLine( "my_out_numeric = [{0}]",               my_out_numeric ) ;
			Console.WriteLine( "my_out_nvarchar = [{0}]",              my_out_nvarchar ) ;
			Console.WriteLine( "my_out_real = [{0}]",                  my_out_real ) ;
			Console.WriteLine( "my_out_rowversion = [{0}]",            my_out_rowversion ) ;
			Console.WriteLine( "my_out_smalldatetime = [{0}]",         my_out_smalldatetime ) ;
			Console.WriteLine( "my_out_smallint = [{0}]",              my_out_smallint ) ;
			Console.WriteLine( "my_out_smallmoney = [{0}]",            my_out_smallmoney ) ;
			Console.WriteLine( "my_out_sql_variant = [{0}]",           my_out_sql_variant ) ;
			Console.WriteLine( "my_out_text = [{0}]",                  my_out_text ) ;
			Console.WriteLine( "my_out_time = [{0}]",                  my_out_time ) ;
			Console.WriteLine( "my_out_timestamp = [{0}]",             my_out_timestamp.Length ) ;
			Console.WriteLine( "my_out_tinyint = [{0}]",               my_out_tinyint ) ;
			Console.WriteLine( "my_out_uniqueidentifier = [{0}]",      my_out_uniqueidentifier ) ;
			Console.WriteLine( "my_out_varbinary = [{0}]",             my_out_varbinary.Length ) ;
			Console.WriteLine( "my_out_varchar = [{0}]",               my_out_varchar ) ;
			Console.WriteLine( "my_out_xml = [{0}]",                   my_out_xml ) ;

			Assert.IsNotNull( my_out_bigint ) ;
			Assert.IsNotNull( my_out_binary ) ;
			Assert.IsNotNull( my_out_bit ) ;
			Assert.IsNotNull( my_out_char ) ;
			Assert.IsNotNull( my_out_date ) ;
			Assert.IsNotNull( my_out_datetime ) ;
			Assert.IsNotNull( my_out_datetime2 ) ;
			Assert.IsNotNull( my_out_datetimeoffset ) ;
			Assert.IsNotNull( my_out_decimal ) ;
			Assert.IsNotNull( my_out_float ) ;
			Assert.IsNotNull( my_out_geography ) ;
			Assert.IsNotNull( my_out_geometry ) ;
			Assert.IsNotNull( my_out_hierarchyid ) ;
			Assert.IsNotNull( my_out_image ) ;
			Assert.IsNotNull( my_out_int ) ;
			Assert.IsNotNull( my_out_money ) ;
			Assert.IsNotNull( my_out_nchar ) ;
			Assert.IsNotNull( my_out_ntext ) ;
			Assert.IsNotNull( my_out_numeric ) ;
			Assert.IsNotNull( my_out_nvarchar ) ;
			Assert.IsNotNull( my_out_real ) ;
			Assert.IsNotNull( my_out_rowversion ) ;
			Assert.IsNotNull( my_out_smalldatetime ) ;
			Assert.IsNotNull( my_out_smallint ) ;
			Assert.IsNotNull( my_out_smallmoney ) ;
			Assert.IsNotNull( my_out_sql_variant ) ;
			Assert.IsNotNull( my_out_text ) ;
			Assert.IsNotNull( my_out_time ) ;
			Assert.IsNotNull( my_out_timestamp ) ;
			Assert.IsNotNull( my_out_tinyint ) ;
			Assert.IsNotNull( my_out_uniqueidentifier ) ;
			Assert.IsNotNull( my_out_varbinary ) ;
			Assert.IsNotNull( my_out_varchar ) ;
			Assert.IsNotNull( my_out_xml ) ;
			Assert.IsNotNull( my_inout_bigint ) ;

			Assert.AreEqual( 42																		, rc ) ;
			Assert.AreEqual( my_in_bigint + 223456789L												, my_inout_bigint ) ;
			Assert.AreEqual( my_in_bigint 															, my_out_bigint ) ;
			byte[] my_in_binary2 = new byte[3] ;
			Array.Copy( my_in_binary, my_in_binary2, my_in_binary2.Length ) ;
			Assert.AreEqual( my_in_binary2															, my_out_binary ) ;
			Assert.AreEqual( my_in_bit																, my_out_bit ) ;
			Assert.AreEqual( my_in_char.Substring( 0, 3 )											, my_out_char ) ;
			Assert.AreEqual( my_in_date.Value.Date													, my_out_date ) ;
			Assert.AreEqual( my_in_datetime															, my_out_datetime ) ;
			Assert.AreEqual( my_in_datetime2														, my_out_datetime2 ) ;
			Assert.AreEqual( my_in_datetimeoffset													, my_out_datetimeoffset ) ; 
			Assert.AreEqual( Math.Round( my_in_decimal.Value, 12,  MidpointRounding.ToEven )		, my_out_decimal ) ; 
			Assert.AreEqual( my_in_float															, my_out_float ) ; 
			Assert.AreEqual( my_in_geography.ToString()												, my_out_geography.ToString() ) ; 
			Assert.AreEqual( my_in_geometry.ToString()												, my_out_geometry.ToString() ) ; 
			Assert.AreEqual( my_in_hierarchyid														, my_out_hierarchyid ) ; 
			Assert.AreEqual( my_in_image															, my_out_image ) ;
			Assert.AreEqual( my_in_int																, my_out_int ) ;
			Assert.AreEqual( Math.Round( my_in_money.Value, 4, MidpointRounding.ToEven )			, my_out_money ) ;
			Assert.AreEqual( my_in_nchar.Substring( 0, 3 )											, my_out_nchar ) ;
			Assert.AreEqual( my_in_ntext															, my_out_ntext ) ;
			Assert.AreEqual( Math.Round( my_in_numeric.Value , 12,  MidpointRounding.ToEven )		, my_out_numeric ) ;
			Assert.AreEqual( my_in_nvarchar.Substring( 0, 3 )										, my_out_nvarchar ) ;
			Assert.AreEqual( my_in_real																, my_out_real ) ;
			Assert.AreEqual( my_in_rowversion														, my_out_rowversion ) ;
			Assert.AreEqual( my_in_smalldatetime.Value.Subtract( new TimeSpan( 0,0,3) )				, my_out_smalldatetime ) ;
			Assert.AreEqual( my_in_smallint															, my_out_smallint ) ;
			Assert.AreEqual( Math.Round( my_in_smallmoney.Value, 4, MidpointRounding.ToEven )		, my_out_smallmoney ) ;
			Assert.AreEqual( my_in_sql_variant														, my_out_sql_variant ) ;
			Assert.AreEqual( my_in_text																, my_out_text ) ;
			Assert.AreEqual( my_in_time																, my_out_time ) ;
			Assert.AreEqual( my_in_timestamp														, my_out_timestamp ) ;
			Assert.AreEqual( my_in_tinyint															, my_out_tinyint ) ;
			Assert.AreEqual( my_in_uniqueidentifier													, my_out_uniqueidentifier ) ;
			byte[] my_in_varbinary2 = new byte[3] ;
			Array.Copy( my_in_varbinary, my_in_varbinary2, my_in_varbinary2.Length ) ;
			Assert.AreEqual( my_in_varbinary2														, my_out_varbinary ) ;
			Assert.AreEqual( my_in_varchar.Substring( 0, 3 )										, my_out_varchar ) ;
			Assert.AreEqual( my_in_xml																, my_out_xml ) ;

		} // end TestParametersNotNull

		[Test]
		public void TestParametersNull()
		{
			var factory = new NW.storedProcedure.StoredProcedureFactory() ;

			long?				my_in_bigint			= null ;
			byte[]				my_in_binary			= null ;
			bool?				my_in_bit				= null ;
			string				my_in_char				= null ;
			DateTime?			my_in_date				= null ;
			DateTime?			my_in_datetime			= null ;
			DateTime?			my_in_datetime2			= null ;
			DateTimeOffset?		my_in_datetimeoffset	= null ;
			decimal?			my_in_decimal			= null ;
			double?				my_in_float				= null ;
			SqlGeography		my_in_geography			= null ;
			SqlGeometry			my_in_geometry			= null ;
			SqlHierarchyId?		my_in_hierarchyid		= null ;
			byte[]				my_in_image				= null ;
			int?				my_in_int				= null ;
			decimal?			my_in_money				= null ;
			string				my_in_nchar				= null ;
			string				my_in_ntext				= null ;
			decimal?			my_in_numeric			= null ;
			string				my_in_nvarchar			= null ;
			float?				my_in_real				= null ;
			byte[]				my_in_rowversion		= null ;
			DateTime?			my_in_smalldatetime		= null ;
			short?				my_in_smallint			= null ;
			decimal?			my_in_smallmoney		= null ;
			object				my_in_sql_variant		= null ;
			string				my_in_text				= null ;
			TimeSpan?			my_in_time				= null ;
			byte[]				my_in_timestamp			= null ;
			byte?				my_in_tinyint			= null ;
			Guid?				my_in_uniqueidentifier	= null ;
			byte[]				my_in_varbinary			= null ;
			string				my_in_varchar			= null ;
			string				my_in_xml				= null ;
			long?				my_out_bigint			= null ;
			byte[]				my_out_binary			= null ;
			bool?				my_out_bit				= null ;
			string				my_out_char				= null ;
			DateTime?			my_out_date				= null ;
			DateTime?			my_out_datetime			= null ;
			DateTime?			my_out_datetime2		= null ;
			DateTimeOffset?		my_out_datetimeoffset	= null ;
			decimal?			my_out_decimal			= null ;
			double?				my_out_float			= null ;
			SqlGeography		my_out_geography		= null ;
			SqlGeometry			my_out_geometry			= null ;
			SqlHierarchyId?		my_out_hierarchyid		= null ;
			byte[]				my_out_image			= null ;
			int?				my_out_int				= null ;
			decimal?			my_out_money			= null ;
			string				my_out_nchar			= null ;
			string				my_out_ntext			= null ;
			decimal?			my_out_numeric			= null ;
			string				my_out_nvarchar			= null ;
			float?				my_out_real				= null ;
			byte[]				my_out_rowversion		= null ;
			DateTime?			my_out_smalldatetime	= null ;
			short?				my_out_smallint			= null ;
			decimal?			my_out_smallmoney		= null ;
			object				my_out_sql_variant		= null ;
			string				my_out_text				= null ;
			TimeSpan?			my_out_time				= null ;
			byte[]				my_out_timestamp		= null ;
			byte?				my_out_tinyint			= null ;
			Guid?				my_out_uniqueidentifier = null ;
			byte[]				my_out_varbinary		= null ;
			string				my_out_varchar			= null ;
			string				my_out_xml				= null ;
			long?				my_inout_bigint			= null ;
			
			int rc = factory.CodegenTestParameters( 
				this._connection,
				my_in_bigint,
				my_in_binary,
				my_in_bit,
				my_in_char,
				my_in_date,
				my_in_datetime,
				my_in_datetime2,
				my_in_datetimeoffset,
				my_in_decimal,
				my_in_float,
				my_in_geography,
				my_in_geometry,
				my_in_hierarchyid,
				my_in_image,
				my_in_int,
				my_in_money,
				my_in_nchar,
				my_in_ntext,
				my_in_numeric,
				my_in_nvarchar,
				my_in_real,
				my_in_rowversion,
				my_in_smalldatetime,
				my_in_smallint,
				my_in_smallmoney,
				my_in_sql_variant,
				my_in_text,
				my_in_time,
				my_in_timestamp,
				my_in_tinyint,
				my_in_uniqueidentifier,
				my_in_varbinary,
				my_in_varchar,
				my_in_xml,
				ref my_out_bigint,
				ref my_out_binary,
				ref my_out_bit,
				ref my_out_char,
				ref my_out_date,
				ref my_out_datetime,
				ref my_out_datetime2,
				ref my_out_datetimeoffset,
				ref my_out_decimal,
				ref my_out_float,
				ref my_out_geography,
				ref my_out_geometry,
				ref my_out_hierarchyid,
				ref my_out_image,
				ref my_out_int,
				ref my_out_money,
				ref my_out_nchar,
				ref my_out_ntext,
				ref my_out_numeric,
				ref my_out_nvarchar,
				ref my_out_real,
				ref my_out_rowversion,
				ref my_out_smalldatetime,
				ref my_out_smallint,
				ref my_out_smallmoney,
				ref my_out_sql_variant,
				ref my_out_text,
				ref my_out_time,
				ref my_out_timestamp,
				ref my_out_tinyint,
				ref my_out_uniqueidentifier,
				ref my_out_varbinary,
				ref my_out_varchar,
				ref my_out_xml,
				ref my_inout_bigint
			) ;

			Assert.AreEqual( 42, rc ) ;

			Assert.IsNull( my_out_bigint ) ;
			Assert.IsNull( my_out_binary ) ;
			Assert.IsNull( my_out_bit ) ;
			Assert.IsNull( my_out_char ) ;
			Assert.IsNull( my_out_date ) ;
			Assert.IsNull( my_out_datetime ) ;
			Assert.IsNull( my_out_datetime2 ) ;
			Assert.IsNull( my_out_datetimeoffset ) ;
			Assert.IsNull( my_out_decimal ) ;
			Assert.IsNull( my_out_float ) ;
			Assert.IsNull( my_out_geography ) ;
			Assert.IsNull( my_out_geometry ) ;
			Assert.IsNull( my_out_hierarchyid ) ;
			Assert.IsNull( my_out_image ) ;
			Assert.IsNull( my_out_int ) ;
			Assert.IsNull( my_out_money ) ;
			Assert.IsNull( my_out_nchar ) ;
			Assert.IsNull( my_out_ntext ) ;
			Assert.IsNull( my_out_numeric ) ;
			Assert.IsNull( my_out_nvarchar ) ;
			Assert.IsNull( my_out_real ) ;
			Assert.IsNull( my_out_rowversion ) ;
			Assert.IsNull( my_out_smalldatetime ) ;
			Assert.IsNull( my_out_smallint ) ;
			Assert.IsNull( my_out_smallmoney ) ;
			Assert.IsNull( my_out_sql_variant ) ;
			Assert.IsNull( my_out_text ) ;
			Assert.IsNull( my_out_time ) ;
			Assert.IsNull( my_out_timestamp ) ;
			Assert.IsNull( my_out_tinyint ) ;
			Assert.IsNull( my_out_uniqueidentifier ) ;
			Assert.IsNull( my_out_varbinary ) ;
			Assert.IsNull( my_out_varchar ) ;
			Assert.IsNull( my_out_xml ) ;
			Assert.IsNull( my_inout_bigint ) ;

		} // end TestParametersNull

		[Test]
		public void MathsTest()
		{
			var factory = new NW.storedProcedure.StoredProcedureFactory() ;

			long? a			 = 100 ;
			long? b			 = 20 ;
			long? difference = null ;
			long? product    = null ;
			long? quotient   = null ;

			int sum = factory.CodegenTestMathParameters( _connection, a, b, ref difference, ref product, ref quotient ) ;

			Assert.AreEqual( 80, difference ) ;
			Assert.AreEqual( 2000, product ) ;
			Assert.AreEqual( 5, quotient ) ;
			Assert.AreEqual( 120, sum ) ;
		}

		[Test, ExpectedException( ExpectedException = typeof( alby.codegen.runtime.CodeGenExecuteException ),
								  ExpectedMessage = "Divide by zero error encountered",
								  MatchType = MessageMatch.Contains ) ]
		public void MathsTestException()
		{
			var factory = new NW.storedProcedure.StoredProcedureFactory() ;

			long? a			 = 100  ;
			long? b			 = 0    ; // division by zero - throws an exception
			long? difference = null ;
			long? product    = null ;
			long? quotient   = null ;

			int sum = factory.CodegenTestMathParameters( _connection, a, b, ref difference, ref product, ref quotient) ;

			Assert.Fail( "should not get here" ) ;
		}

	} // end class
}
