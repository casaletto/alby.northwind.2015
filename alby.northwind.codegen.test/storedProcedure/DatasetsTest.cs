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
	public class DatasetsTest : NW.test.TransactionScopeTestBase
	{
		public DatasetsTest()
		{
			_connectionString = Settings.ConnectionString();
		}

		[Test]
		public void OneRecordset()
		{
			var factory = new NW.storedProcedure.StoredProcedureFactory() ;

			List<NW.storedProcedure.Sales_by_Year٠rs1> rs1 ;

			int rc = factory.Sales_by_Year( _connection, new DateTime(1996,7,1), new DateTime(1996,8,1), out rs1 ) ;
			Console.WriteLine( rc ) ;
			Assert.AreEqual( 0, rc ) ;

			Assert.IsNotNull( rs1 ) ;
			Console.WriteLine( rs1.Count ) ;
			Assert.GreaterOrEqual( rs1.Count, 1 ) ;

			rs1.ForEach( i =>
			{ 
				Console.WriteLine( "year:{0}, order:{1}, subtotal:{2}", i.Year, i.OrderID, i.Subtotal ) ;
			} ) ;  
		}

		[Test]
		public void FourRecordsets()
		{
			var factory = new NW.storedProcedure.StoredProcedureFactory() ;

			List<NW.storedProcedure.CodegenTestFourResultSets٠rs1> rs1 ;
			List<NW.storedProcedure.CodegenTestFourResultSets٠rs2> rs2 ;
			List<NW.storedProcedure.CodegenTestFourResultSets٠rs3> rs3 ;
			List<NW.storedProcedure.CodegenTestFourResultSets٠rs4> rs4 ;

			int    orderId    = 10253 ;
			int    employeeId = 3 ;
			string customerId = "HANAR" ;
			string address    = "Rua do Paço, 67" ;

			factory.CodegenTestFourResultSets( _connection, orderId, out rs1, out rs2, out rs3, out rs4 ) ;

				Assert.IsNotNull( rs1 ) ;
				Assert.IsNotNull( rs2 ) ;
				Assert.IsNotNull( rs3 ) ;
				Assert.IsNotNull( rs4 ) ;

				Assert.AreEqual( 1, rs1.Count ) ;
				Assert.AreEqual( 1, rs2.Count ) ;
				Assert.AreEqual( 1, rs3.Count ) ;
				Assert.Greater( rs4.Count, 1 ) ;

			NW.storedProcedure.CodegenTestFourResultSets٠rs1 order = rs1[0] ;
			NW.storedProcedure.CodegenTestFourResultSets٠rs2 customer = rs2[0] ;
			NW.storedProcedure.CodegenTestFourResultSets٠rs3 employee = rs3[0] ;
			List<NW.storedProcedure.CodegenTestFourResultSets٠rs4> employeeOrders = rs4 ;
			
				// check order details
				Assert.AreEqual( orderId, order.OrderID ) ;
				Assert.AreEqual( customerId, order.CustomerID ) ; 
				Assert.AreEqual( employeeId, order.EmployeeID ) ;
				Assert.AreEqual( address, order.ShipAddress ) ; 

				// check customer details
				Assert.AreEqual( customerId, customer.CustomerID ) ; 
				Assert.AreEqual( address, customer.Address ) ; 
			
				// check employee details
				Assert.AreEqual( employeeId, employee.EmployeeID ) ;
				Assert.AreEqual( "Leverling", employee.LastName ) ;		

			// orders for this employee must have all EmployeeId = 3
			employeeOrders.TrueForAll( p => p.EmployeeID.HasValue && p.EmployeeID == employeeId ) ;

			// employe must have order 10253
			employeeOrders.Exists( p => p.OrderID.HasValue && p.OrderID == orderId ) ;
		}	

		[Test]
		public void DatasetNotRecordset1() // one bad recordset
		{
			var factory = new NW.storedProcedure.StoredProcedureFactory() ;

			int? orderID = 10253 ; 
			DataSet ds ;

			factory.CodegenTestDatasetNotRecordset1( _connection, orderID, out ds ) ;

			Assert.IsNotNull( ds ) ;
			Assert.IsNotNull( ds.Tables ) ;
			Assert.AreEqual( 1, ds.Tables.Count ) ;
			Assert.IsNotNull( ds.Tables[0].Rows ) ;
			Assert.AreEqual( 1, ds.Tables[0].Rows.Count ) ;
			Assert.AreEqual( 5, ds.Tables[0].Columns.Count ) ;

			DataTable dt = ds.Tables[0] ;
			DataRow	dr = dt.Rows[0] ;
			
			Assert.AreEqual( "OrderID",		dt.Columns[0].ColumnName ) ; 
			Assert.AreEqual( "CustomerID",	dt.Columns[1].ColumnName ) ; 
			Assert.AreEqual( "EmployeeID",	dt.Columns[2].ColumnName ) ; 
			Assert.AreEqual( "ShipAddress", dt.Columns[3].ColumnName ) ; 
			Assert.AreEqual( "ShipCity",	dt.Columns[4].ColumnName ) ; 

			Assert.AreEqual( orderID,			dr["OrderID"]		) ; 
			Assert.AreEqual( "HANAR",			dr["CustomerID"]	) ; 
			Assert.AreEqual( 3,					dr["EmployeeID"]	) ; 
			Assert.AreEqual( "Rua do Paço, 67",	dr["ShipAddress"]	) ; 
			Assert.AreEqual( "Rio de Janeiro",	dr["ShipCity"]		) ; 
		}	

		[Test]
		public void DatasetNotRecordset2() // two bad recordsets
		{
			var factory = new NW.storedProcedure.StoredProcedureFactory() ;

			int? orderID = 10253 ; 
			DataSet ds ;

			factory.CodegenTestDatasetNotRecordset2( _connection, orderID, out ds ) ;

			Assert.IsNotNull( ds ) ;
			Assert.IsNotNull( ds.Tables ) ;
			Assert.AreEqual( 2, ds.Tables.Count ) ;

			Assert.IsNotNull( ds.Tables[0].Rows ) ;
			Assert.AreEqual( 1, ds.Tables[0].Rows.Count ) ;
			Assert.AreEqual( 5, ds.Tables[0].Columns.Count ) ;

			Assert.IsNotNull( ds.Tables[1].Rows ) ;
			Assert.AreEqual( 63, ds.Tables[1].Rows.Count ) ;
			Assert.AreEqual( 2, ds.Tables[1].Columns.Count ) ;

			DataTable dt = ds.Tables[0] ;
			DataRow	dr = dt.Rows[0] ;
			
			Assert.AreEqual( "OrderID",		dt.Columns[0].ColumnName ) ; 
			Assert.AreEqual( "CustomerID",	dt.Columns[1].ColumnName ) ; 
			Assert.AreEqual( "EmployeeID",	dt.Columns[2].ColumnName ) ; 
			Assert.AreEqual( "ShipAddress", dt.Columns[3].ColumnName ) ; 
			Assert.AreEqual( "ShipCity",	dt.Columns[4].ColumnName ) ; 

			Assert.AreEqual( orderID,			dr["OrderID"]		) ; 
			Assert.AreEqual( "HANAR",			dr["CustomerID"]	) ; 
			Assert.AreEqual( 3,					dr["EmployeeID"]	) ; 
			Assert.AreEqual( "Rua do Paço, 67",	dr["ShipAddress"]	) ; 
			Assert.AreEqual( "Rio de Janeiro",	dr["ShipCity"]		) ; 

			dt = ds.Tables[1] ;
			Assert.AreEqual( "CustomerID",	dt.Columns[0].ColumnName ) ; 
			Assert.AreEqual( "EmployeeID",	dt.Columns[1].ColumnName ) ; 

			foreach( DataRow drr in dt.Rows )
			{
				Assert.IsFalse( drr.IsNull("CustomerId") ) ;
				Assert.IsTrue( drr["CustomerId"].ToString().Length >= 5 ) ;
				Assert.AreEqual( 3,	drr["EmployeeID"]	) ;
			}			
		}	

		[Test]
		public void DatasetNotRecordset3() // one good recordset, one bad recordset
		{
			var factory = new NW.storedProcedure.StoredProcedureFactory() ;

			int? orderID = 10253 ; 
			DataSet ds ;

			factory.CodegenTestDatasetNotRecordset3( _connection, orderID, out ds ) ;

			Assert.IsNotNull( ds ) ;
			Assert.IsNotNull( ds.Tables ) ;
			Assert.AreEqual( 2, ds.Tables.Count ) ;

			Assert.IsNotNull( ds.Tables[0].Rows ) ;
			Assert.AreEqual( 1, ds.Tables[0].Rows.Count ) ;
			Assert.AreEqual( 5, ds.Tables[0].Columns.Count ) ;

			Assert.IsNotNull( ds.Tables[1].Rows ) ;
			Assert.AreEqual( 63, ds.Tables[1].Rows.Count ) ;
			Assert.AreEqual( 2, ds.Tables[1].Columns.Count ) ;

			DataTable dt = ds.Tables[0] ;
			DataRow	dr = dt.Rows[0] ;
			
			Assert.AreEqual( "OrderID",		dt.Columns[0].ColumnName ) ; 
			Assert.AreEqual( "CustomerID",	dt.Columns[1].ColumnName ) ; 
			Assert.AreEqual( "EmployeeID",	dt.Columns[2].ColumnName ) ; 
			Assert.AreEqual( "ShipAddress", dt.Columns[3].ColumnName ) ; 
			Assert.AreEqual( "ShipCity",	dt.Columns[4].ColumnName ) ; 

			Assert.AreEqual( orderID,			dr["OrderID"]		) ; 
			Assert.AreEqual( "HANAR",			dr["CustomerID"]	) ; 
			Assert.AreEqual( 3,					dr["EmployeeID"]	) ; 
			Assert.AreEqual( "Rua do Paço, 67",	dr["ShipAddress"]	) ; 
			Assert.AreEqual( "Rio de Janeiro",	dr["ShipCity"]		) ; 

			dt = ds.Tables[1] ;
			Assert.AreEqual( "CustomerID",	dt.Columns[0].ColumnName ) ; 
			Assert.AreEqual( "EmployeeID",	dt.Columns[1].ColumnName ) ; 

			foreach( DataRow drr in dt.Rows )
			{
				Assert.IsFalse( drr.IsNull("CustomerId") ) ;
				Assert.IsTrue( drr["CustomerId"].ToString().Length >= 5 ) ;
				Assert.AreEqual( 3,	drr["EmployeeID"]	) ;
			}			

		}	

		[Test]
		public void AllDataTypesNull()
		{
			List<NW.storedProcedure.CodegenTestResultSetTypesAllNull٠rs1> rs1 ;
			var factory = new NW.storedProcedure.StoredProcedureFactory() ;

			int rc = factory.CodegenTestResultSetTypesAllNull( _connection, out rs1 ) ;
			Assert.AreEqual( 0, rc ) ;
			Assert.IsNotNull( rs1 ) ;
			Console.WriteLine( rs1.Count ) ;
			Assert.AreEqual( 1, rs1.Count ) ;

			NW.storedProcedure.CodegenTestResultSetTypesAllNull٠rs1 row = rs1[0] ;
			Assert.IsNull( row.my_bigint ) ;				
			Assert.IsNull( row.my_binary ) ; 				
			Assert.IsNull( row.my_bit ) ; 					
			Assert.IsNull( row.my_char  ) ;					
			Assert.IsNull( row.my_date  ) ;					
			Assert.IsNull( row.my_datetime ) ;				
			Assert.IsNull( row.my_datetime2 ) ;			
			Assert.IsNull( row.my_datetimeoffset ) ;		
			Assert.IsNull( row.my_decimal ) ;				
			Assert.IsNull( row.my_float ) ;				
			Assert.IsNull( row.my_geography ) ;			
			Assert.IsNull( row.my_geometry ) ;			 	
			Assert.IsNull( row.my_hierarchyid ) ;			
			Assert.IsNull( row.my_image ) ;				
			Assert.IsNull( row.my_int ) ;					
			Assert.IsNull( row.my_money ) ;				
			Assert.IsNull( row.my_nchar ) ;				
			Assert.IsNull( row.my_ntext ) ;				
			Assert.IsNull( row.my_numeric ) ;				
			Assert.IsNull( row.my_nvarchar ) ;			 	
			Assert.IsNull( row.my_real ) ;				 	
			Assert.IsNull( row.my_smalldatetime ) ;		
			Assert.IsNull( row.my_smallint ) ;			 	
			Assert.IsNull( row.my_smallmoney ) ;			
			Assert.IsNull( row.my_sql_variant ) ;			
			Assert.IsNull( row.my_text ) ;				 	
			Assert.IsNull( row.my_time ) ;				 	
			Assert.IsNull( row.my_tinyint ) ;				
			Assert.IsNull( row.my_uniqueidentifier ) ;	 	
			Assert.IsNull( row.my_varbinary ) ;			
			Assert.IsNull( row.my_varchar ) ;				
			Assert.IsNull( row.my_xml ) ;	
							
			// WTF - for timestamps, null not returned, but 0 length array
			byte[] emptyByteArray = new byte[0] ;
			Assert.AreEqual( row.my_rowversion, emptyByteArray ) ;
			Assert.AreEqual( row.my_timestamp,  emptyByteArray ) ;
		}	

		[Test]
		public void AllDataTypesNotNull()
		{
			List<NW.storedProcedure.CodegenTestResultSetTypesAllNotNull٠rs1> rs1 ;
			var factory = new NW.storedProcedure.StoredProcedureFactory() ;

			int rc = factory.CodegenTestResultSetTypesAllNotNull( _connection, out rs1 ) ;
			Assert.AreEqual( 0, rc ) ;
			Assert.IsNotNull( rs1 ) ;
			Console.WriteLine( rs1.Count ) ;
			Assert.AreEqual( 1, rs1.Count ) ;

			NW.storedProcedure.CodegenTestResultSetTypesAllNotNull٠rs1 row = rs1[0] ;
			Assert.IsNotNull( row.my_bigint ) ;				
			Assert.IsNotNull( row.my_binary ) ; 				
			Assert.IsNotNull( row.my_bit ) ; 					
			Assert.IsNotNull( row.my_char  ) ;					
			Assert.IsNotNull( row.my_date  ) ;					
			Assert.IsNotNull( row.my_datetime ) ;				
			Assert.IsNotNull( row.my_datetime2 ) ;			
			Assert.IsNotNull( row.my_datetimeoffset ) ;		
			Assert.IsNotNull( row.my_decimal ) ;				
			Assert.IsNotNull( row.my_float ) ;				
			Assert.IsNotNull( row.my_geography ) ;			
			Assert.IsNotNull( row.my_geometry ) ;			 	
			Assert.IsNotNull( row.my_hierarchyid ) ;			
			Assert.IsNotNull( row.my_image ) ;				
			Assert.IsNotNull( row.my_int ) ;					
			Assert.IsNotNull( row.my_money ) ;				
			Assert.IsNotNull( row.my_nchar ) ;				
			Assert.IsNotNull( row.my_ntext ) ;				
			Assert.IsNotNull( row.my_numeric ) ;				
			Assert.IsNotNull( row.my_nvarchar ) ;			 	
			Assert.IsNotNull( row.my_real ) ;				 	
			Assert.IsNotNull( row.my_smalldatetime ) ;		
			Assert.IsNotNull( row.my_smallint ) ;			 	
			Assert.IsNotNull( row.my_smallmoney ) ;			
			Assert.IsNotNull( row.my_sql_variant ) ;			
			Assert.IsNotNull( row.my_text ) ;				 	
			Assert.IsNotNull( row.my_time ) ;				 	
			Assert.IsNotNull( row.my_tinyint ) ;				
			Assert.IsNotNull( row.my_uniqueidentifier ) ;	 	
			Assert.IsNotNull( row.my_varbinary ) ;			
			Assert.IsNotNull( row.my_varchar ) ;				
			Assert.IsNotNull( row.my_xml ) ;	
			Assert.IsNotNull( row.my_rowversion ) ;
			Assert.IsNotNull( row.my_timestamp ) ;

			Console.WriteLine( "my_bigint = [{0}]", 			   row.my_bigint ) ;
			Console.WriteLine( "my_binary = [{0}]",                row.my_binary.Length ) ;
			Console.WriteLine( "my_bit = [{0}]",                   row.my_bit ) ;
			Console.WriteLine( "my_char = [{0}]",                  row.my_char ) ;
			Console.WriteLine( "my_date = [{0}]",                  row.my_date ) ;
			Console.WriteLine( "my_datetime = [{0}]",              row.my_datetime ) ;
			Console.WriteLine( "my_datetime2 = [{0}]",             row.my_datetime2 ) ;
			Console.WriteLine( "my_datetimeoffset = [{0}]",        row.my_datetimeoffset ) ;
			Console.WriteLine( "my_decimal = [{0}]",               row.my_decimal ) ;
			Console.WriteLine( "my_float = [{0}]",                 row.my_float ) ;
			Console.WriteLine( "my_geography = [{0}]",             row.my_geography ) ;
			Console.WriteLine( "my_geometry = [{0}]",              row.my_geometry ) ;
			Console.WriteLine( "my_hierarchyid = [{0}]",           row.my_hierarchyid ) ;
			Console.WriteLine( "my_image = [{0}]",                 row.my_image.Length ) ;
			Console.WriteLine( "my_int = [{0}]",                   row.my_int ) ;
			Console.WriteLine( "my_money = [{0}]",                 row.my_money ) ;
			Console.WriteLine( "my_nchar = [{0}]",                 row.my_nchar ) ;
			Console.WriteLine( "my_ntext = [{0}]",                 row.my_ntext ) ;
			Console.WriteLine( "my_numeric = [{0}]",               row.my_numeric ) ;
			Console.WriteLine( "my_nvarchar = [{0}]",              row.my_nvarchar ) ;
			Console.WriteLine( "my_real = [{0}]",                  row.my_real ) ;			
			Console.WriteLine( "my_rowversion = [{0}]",            row.my_rowversion ) ;
			Console.WriteLine( "my_smalldatetime = [{0}]",         row.my_smalldatetime ) ;
			Console.WriteLine( "my_smallint = [{0}]",              row.my_smallint ) ;
			Console.WriteLine( "my_smallmoney = [{0}]",            row.my_smallmoney ) ;
			Console.WriteLine( "my_sql_variant = [{0}]",           row.my_sql_variant ) ;
			Console.WriteLine( "my_text = [{0}]",                  row.my_text ) ;
			Console.WriteLine( "my_time = [{0}]",                  row.my_time ) ;
			Console.WriteLine( "my_timestamp = [{0}]",             row.my_timestamp.Length ) ;
			Console.WriteLine( "my_tinyint = [{0}]",               row.my_tinyint ) ;
			Console.WriteLine( "my_uniqueidentifier = [{0}]",      row.my_uniqueidentifier ) ;
			Console.WriteLine( "my_varbinary = [{0}]",             row.my_varbinary.Length ) ;
			Console.WriteLine( "my_varchar = [{0}]",               row.my_varchar ) ;
			Console.WriteLine( "my_xml = [{0}]",                   row.my_xml ) ;

			// asserts
			Assert.AreEqual( 42, row.my_bigint.Value ) ;

			byte[] bytes = new byte[] { 0x12, 0x34, 0x56, 0, 0, 0, 0, 0, 0, 0 } ;
			Assert.AreEqual( bytes, row.my_binary ) ;

			Assert.AreEqual( true, row.my_bit.Value ) ;

			Assert.AreEqual( "A         ", row.my_char ) ;
			
			string date = "1969-01-31" ; 
			string fmt  = "yyyy-MM-dd" ;
			Assert.AreEqual( DateTime.ParseExact( date, fmt, null), row.my_date.Value  ) ;

			date = "1969-01-31 01:02:03.457" ;
			fmt  = "yyyy-MM-dd HH:mm:ss.FFF" ;
			Assert.AreEqual( DateTime.ParseExact( date, fmt, null), row.my_datetime.Value ) ;

			date = "1969-01-31 01:02:03.4560000" ;
			fmt  = "yyyy-MM-dd HH:mm:ss.FFFFFFF" ;
			Assert.AreEqual( DateTime.ParseExact( date, fmt, null), row.my_datetime2.Value ) ;

			date = "1969-01-31 01:02:03 -07:12" ;
			fmt  = "yyyy-MM-dd HH:mm:ss zzz" ;
			Assert.AreEqual( date, row.my_datetimeoffset.Value.ToString( fmt )  ) ;

			Assert.AreEqual( 3.123456789000m, row.my_decimal.Value ) ;
			Assert.AreEqual( 2.123456789, row.my_float.Value ) ;

			string str = SqlGeography.Parse( "POINT(1 2)" ).ToString() ;
			Assert.AreEqual( str, row.my_geography.ToString() ) ;

			str = SqlGeometry.Parse( "POINT(3 4)" ).ToString() ;
			Assert.AreEqual( str, row.my_geometry.ToString() ) ;

			str = SqlHierarchyId.Parse( "/1/2/3/").ToString() ;
			Assert.AreEqual( str, row.my_hierarchyid.ToString() ) ;

			bytes = new byte[] { 0x98, 0x76, 0x54, 0x32, 0x10 } ;
			Assert.AreEqual( bytes, row.my_image ) ;

			Assert.AreEqual( 43,                 row.my_int.Value ) ;
			Assert.AreEqual( 1234.1235m,         row.my_money.Value ) ;
			Assert.AreEqual( "B         ",       row.my_nchar ) ;
			Assert.AreEqual( "abcdefghijklmnop", row.my_ntext ) ;
			Assert.AreEqual( 987654321m,         row.my_numeric.Value ) ;
			Assert.AreEqual( "1234567890",       row.my_nvarchar ) ;
			Assert.AreEqual( -123456792.0f,      row.my_real.Value ) ;
			
			bytes = new byte[] { 0x12, 0x34, 0x56, 0x78, 0x0, 0x0, 0x0, 0x0 } ;
			Assert.AreEqual( bytes, row.my_rowversion ) ;

			date = "1969-01-31 01:02:00" ;
			fmt  = "yyyy-MM-dd HH:mm:ss" ;
			Assert.AreEqual( date, row.my_smalldatetime.Value.ToString( fmt ) ) ;

			Assert.AreEqual( 44,                 row.my_smallint.Value  ) ;
			Assert.AreEqual( 314.1235m,          row.my_smallmoney.Value ) ;
			Assert.AreEqual( "variant",          row.my_sql_variant ) ;
			Assert.AreEqual( "zxcvbnmasdfghjkl", row.my_text ) ;

			date = "17:15:10" ;
			fmt  = @"hh\:mm\:ss" ;
			Assert.AreEqual( date, row.my_time.Value.ToString( fmt ) ) ;

			bytes = new byte[] { 0x22, 0x34, 0x56, 0x78, 0x0, 0x0, 0x0, 0x0 } ;
			Assert.AreEqual( bytes, row.my_timestamp ) ;
			
			Assert.AreEqual( 10, row.my_tinyint.Value ) ;
			Assert.AreEqual( new Guid( "9C507CC2-5D11-4273-A794-3CCCB843F89F"), row.my_uniqueidentifier.Value ) ;

			bytes = new byte[] { 0x33, 0x34, 0x56, 0x78 } ;
			Assert.AreEqual( bytes, row.my_varbinary ) ;
	
			Assert.AreEqual( "martika",	row.my_varchar ) ;

			Assert.AreEqual( "<root>hellow world</root>", row.my_xml ) ;
		}	

		[Test]
		public void IsDirtyTest()
		{
			List<NW.storedProcedure.CodegenTestResultSetTypesAllNotNull٠rs1> rs1 ;
			var factory = new NW.storedProcedure.StoredProcedureFactory() ;

			int rc = factory.CodegenTestResultSetTypesAllNotNull( _connection, out rs1 ) ;
			Assert.AreEqual( 0, rc ) ;
			Assert.IsNotNull( rs1 ) ;
			Assert.AreEqual( 1, rs1.Count ) ;

			NW.storedProcedure.CodegenTestResultSetTypesAllNotNull٠rs1 row = rs1[0] ;

			// check row state flags
			Assert.IsTrue ( row.IsSavedˡ        ) ;
			Assert.IsTrue ( row.IsFromDatabaseˡ ) ;
			Assert.IsFalse( row.IsDeletedˡ      ) ;
			Assert.IsFalse( row.IsDirtyˡ        ) ;
			 
			// now check the dirty flag on each type, 
			// when i set each field with its own current value
			// field should stay NOT dirty

			row.IsDirtyˡ = false ;
			Assert.IsFalse( row.IsDirtyˡ ) ;
			var a = row.my_bigint ;
			row.my_bigint = long.Parse( a.Value.ToString() ) ;
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var b = row.my_binary ;
			row.my_binary = b ; 				
			Assert.IsFalse( row.IsDirtyˡ ) ;
			byte[] c = new byte[ b.Length ] ;
			b.CopyTo( c, 0 ) ;
			row.my_binary = c ; 				
			Assert.IsFalse( row.IsDirtyˡ ) ; // OUCH - this is a different array

			var d = row.my_bit ;
			row.my_bit = bool.Parse( d.Value.ToString() ) ; 					
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var e = row.my_char ;
			row.my_char = new string( e.ToCharArray() ) ;					
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var f = row.my_date ;
			row.my_date = new DateTime( f.Value.Ticks ) ;					
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var g = row.my_datetime ;
			row.my_datetime = new DateTime( g.Value.Ticks ) ;				
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var h = row.my_datetime2 ;	
			row.my_datetime2 = new DateTime( h.Value.Ticks ) ;		
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var i = row.my_datetimeoffset ;	
			row.my_datetimeoffset = new DateTimeOffset( i.Value.Ticks, i.Value.Offset ) ;	
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var j = row.my_decimal ;
			row.my_decimal = decimal.Parse( j.Value.ToString() ) ;				
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var k = row.my_float ;
			row.my_float = k.Value ;		
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var l = row.my_geography ;		
			row.my_geography = SqlGeography.Parse( l.ToString() ) ;	
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var m = row.my_geometry ;			 	
			row.my_geometry = SqlGeometry.Parse( m.ToString() ) ;	
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var n = row.my_hierarchyid ;			
			row.my_hierarchyid = SqlHierarchyId.Parse( n.ToString() ) ;	
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var o = row.my_image ;
			byte[] oa = new byte[ o.Length ] ;
			oa.CopyTo( o, 0 ) ;
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var p = row.my_int ;
			row.my_int = int.Parse( p.Value.ToString() ) ;					
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var q = row.my_money ;			
			row.my_money = decimal.Parse( q.Value.ToString() ) ;	
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var r = row.my_nchar ;				
			row.my_nchar = new string( r.ToCharArray() ) ;					
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var s = row.my_ntext ;				
			row.my_ntext = new string( s.ToCharArray() ) ;					
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var t = row.my_numeric ;
			row.my_numeric = decimal.Parse( t.Value.ToString() ) ;				
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var u = row.my_nvarchar ;			 	
			row.my_nvarchar = new string( u.ToCharArray() ) ;					
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var v = row.my_real ;
			row.my_real = v.Value ;				 	
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var w = row.my_smalldatetime ;		
			row.my_smalldatetime = new DateTime( w.Value.Ticks ) ;					
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var x = row.my_smallint ;
			row.my_smallint = short.Parse( x.Value.ToString() ) ;			 	
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var y = row.my_smallmoney ;	
			row.my_smallmoney = decimal.Parse( y.Value.ToString() ) ;		
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var z = row.my_sql_variant ;
			row.my_sql_variant = z.ToString() ;			
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var aa = row.my_text ;				 	
			row.my_text = new string( aa.ToCharArray() ) ;					
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var bb = row.my_time ;				 	
			row.my_time = new TimeSpan( bb.Value.Ticks ) ;					
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var cc = row.my_tinyint ;
			row.my_tinyint = byte.Parse( cc.Value.ToString() ) ;				
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var dd = row.my_uniqueidentifier ;
			row.my_uniqueidentifier = new Guid( dd.Value.ToString() ) ;	 	
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var ee = row.my_varbinary ;			
			byte[] eea = new byte[ ee.Length ] ;
			eea.CopyTo( ee, 0 ) ;
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var ff = row.my_varchar ;				
			row.my_varchar = new string( ff.ToCharArray() ) ;					
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var gg = row.my_xml ;	
			row.my_xml = new string( gg.ToCharArray() ) ;					
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var hh = row.my_rowversion ;
			byte[] hha = new byte[ hh.Length ] ;
			hha.CopyTo( hh, 0 ) ;
			Assert.IsFalse( row.IsDirtyˡ ) ;

			var ii = row.my_timestamp ;
			byte[] iia = new byte[ ii.Length ] ;
			iia.CopyTo( ii, 0 ) ;
			Assert.IsFalse( row.IsDirtyˡ ) ;
		}	

	} // end class

}