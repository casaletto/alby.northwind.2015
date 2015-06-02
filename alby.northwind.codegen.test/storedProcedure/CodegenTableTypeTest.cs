using System;
using System.Collections.Generic;
using System.Text;
using System.Data ;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Transactions ;
using System.Linq ;
using Microsoft.SqlServer.Types;

using NUnit.Framework ;
using ACR = alby.codegen.runtime ;
using NW = alby.northwind.codegen  ;

namespace alby.northwind.codegen.test.storedProcedure
{
	[TestFixture]
	public class CodegenTableTypeTest : NW.test.TransactionScopeTestBase
	{
		public CodegenTableTypeTest()
		{
			_connectionString = Settings.ConnectionString();
		}

		[Test]
		public void NameAddressTableTypeSomeRows()
		{
			// input records
			List<NW.storedProcedure.NameAddressTableType٠tt> listIn = new List< NW.storedProcedure.NameAddressTableType٠tt >() ;

			// make it more than 50 chars
			string address = "1" + new string( 'a', 50 ) + "2" ;
	
			listIn.Add( new NW.storedProcedure.NameAddressTableType٠tt() { Address = address, Name = "name1", State = "state1" } ) ;
			listIn.Add( new NW.storedProcedure.NameAddressTableType٠tt() { Address = "address2", Name = "name2", State = "state2" } ) ;
			listIn.Add( new NW.storedProcedure.NameAddressTableType٠tt() { Address = "address3", Name = "name3", State = "state3" } ) ;

			listIn.ForEach( tt => Console.WriteLine( "IN:  {0} / {1} / {2}", tt.Name, tt.Address, tt.State ) ) ;

			// call it
			List<NW.storedProcedure.CodegenTestStoredProcTableType٠rs1> listOut = null ;
			var factory = new NW.storedProcedure.StoredProcedureFactory() ;
			factory.CodegenTestStoredProcTableType( _connection, listIn, out listOut ) ;

			// dump
			Assert.IsNotNull( listOut ) ;
			listOut.ForEach( tt => Console.WriteLine( "OUT: {0} / {1} / {2}", tt.Name, tt.Address, tt.State ) ) ;
	
			// asserts
			Console.WriteLine( listOut.Count ) ;		
			Assert.AreEqual( 3, listIn.Count ) ;
			Assert.AreEqual( 3, listOut.Count ) ;

			// stored proc reurns in reverse order
			Assert.AreEqual( listIn[0].Address.Substring( 0, 50 ), listOut[2].Address.Substring( 0, 50 ) ) ;
		}

		[Test]
		public void NameAddressTableTypeSomeRowsWithNullDataAndEmptyStrings()
		{
			// input records
			List<NW.storedProcedure.NameAddressTableType٠tt> listIn = new List< NW.storedProcedure.NameAddressTableType٠tt >() ;

			listIn.Add( new NW.storedProcedure.NameAddressTableType٠tt() { Address = "address3", /*Name = "name3"*,*/ State = "" } ) ;

			listIn.ForEach( tt => Console.WriteLine( "IN:  [{0}] / [{1}] / [{2}]", Null2String( tt.Name ), Null2String( tt.Address ), Null2String( tt.State ) ) ) ;

			// call it
			List<NW.storedProcedure.CodegenTestStoredProcTableType٠rs1> listOut = null ;
			var factory = new NW.storedProcedure.StoredProcedureFactory() ;
			factory.CodegenTestStoredProcTableType( _connection, listIn, out listOut ) ;

			// dump
			Assert.IsNotNull( listOut ) ;
			listOut.ForEach( tt => Console.WriteLine( "OUT: [{0}] / [{1}] / [{2}]", Null2String( tt.Name ), Null2String( tt.Address ), Null2String( tt.State ) ) ) ;

			// asserts
			Assert.AreEqual( 1, listIn.Count ) ;
			Assert.AreEqual( 1, listOut.Count ) ;

			Assert.IsNull( listIn [0].Name ) ;
			Assert.IsNull( listOut[0].Name ) ;

			Assert.IsEmpty( listIn [0].State ) ;
			Assert.IsEmpty( listOut[0].State ) ;
		}

		protected string Null2String( string str ) 
		{
			if ( str == null ) return "<NULL>" ;
			return str ;
		}

		protected object Null2Object( object o ) 
		{
			if ( o == null ) return "<NULL>" ;
			return o ;
		}

		[Test]
		public void NameAddressTableTypeNoRows()
		{
			// input records
			List<NW.storedProcedure.NameAddressTableType٠tt> listIn = new List< NW.storedProcedure.NameAddressTableType٠tt >() ;

			// call it
			List<NW.storedProcedure.CodegenTestStoredProcTableType٠rs1> listOut = null ;
			var factory = new NW.storedProcedure.StoredProcedureFactory() ;
			factory.CodegenTestStoredProcTableType( _connection, listIn, out listOut ) ;

			// asserts
			Assert.IsNotNull( listOut ) ;
			Assert.AreEqual( 0, listOut.Count ) ;
		}

		[Test]
		public void NameAddressTableTypeNullObject()
		{
			// call it
			List<NW.storedProcedure.CodegenTestStoredProcTableType٠rs1> listOut = null ;
			var factory = new NW.storedProcedure.StoredProcedureFactory() ;
			factory.CodegenTestStoredProcTableType( _connection, null, out listOut ) ;

			// asserts
			Assert.IsNotNull( listOut ) ;
			Assert.AreEqual( 0, listOut.Count ) ;
		}

		[Test]
		public void UdtTest()
		{
			// input records
			List<NW.storedProcedure.MyUdtTableType٠tt> list1 = new List< NW.storedProcedure.MyUdtTableType٠tt >() ;
			List<NW.storedProcedure.MyUdtTableType٠tt> list2 = new List< NW.storedProcedure.MyUdtTableType٠tt >() ;

			// make it more than 50 chars
			string name1 = "#1" + new string( '.', 70 ) + "#1" ;
			string name2 = "#2" + new string( '.', 70 ) + "#2" ;
			string name3 = null ;

			SqlGeography geography1 = SqlGeography.Parse( "POINT(10 10)" ) ;
			SqlGeography geography2 = SqlGeography.Parse( "POINT(20 20)" ) ;
			SqlGeography geography3 = null ;
		
			SqlGeometry geometry1 = SqlGeometry.Parse( "POINT(11 11)" ) ;
			SqlGeometry geometry2 = SqlGeometry.Parse( "POINT(21 21)" ) ;
			SqlGeometry geometry3 = null ;

			SqlHierarchyId hier1 = SqlHierarchyId.Parse( "/1/2/" ) ;
			SqlHierarchyId hier2 = SqlHierarchyId.Parse( "/1/2/3/" ) ;

			list1.Add( new NW.storedProcedure.MyUdtTableType٠tt() { Name = name1, MyGeography = geography1, MyGeometry = geometry1, MyHierarchyid = hier1 } ) ;
			list2.Add( new NW.storedProcedure.MyUdtTableType٠tt() { Name = name2, MyGeography = geography2, MyGeometry = geometry2, MyHierarchyid = hier2 } ) ;
			list2.Add( new NW.storedProcedure.MyUdtTableType٠tt() { Name = name3, MyGeography = geography3, MyGeometry = geometry3, MyHierarchyid = null } ) ;

			list1.ForEach( tt => Console.WriteLine( "IN 1: [{0}] / [{1}] / [{2}] / [{3}]", tt.Name, tt.MyGeography, tt.MyGeometry, tt.MyHierarchyid ) ) ;
			list2.ForEach( tt => Console.WriteLine( "IN 2: [{0}] / [{1}] / [{2}] / [{3}]", tt.Name, tt.MyGeography, tt.MyGeometry, tt.MyHierarchyid ) ) ;

			// call it
			List<NW.storedProcedure.CodegenTestStoredProcUdtTableType٠rs1> rs = null ;
			var factory = new NW.storedProcedure.StoredProcedureFactory() ;
			factory.CodegenTestStoredProcUdtTableType( _connection, list1, list2, out rs ) ;

			// dump
			Assert.IsNotNull( rs ) ;
			rs.ForEach( tt => Console.WriteLine( "OUT : [{0}] / [{1}] / [{2}] / [{3}]", Null2Object( tt.Name ), 
																						Null2Object( tt.MyGeography ), 
																						Null2Object( tt.MyGeometry ), 
																						Null2Object( tt.MyHierarchyid ) ) ) ;	
			// asserts
			Console.WriteLine( rs.Count ) ;		
			Assert.AreEqual( 3, rs.Count ) ;

			Assert.AreEqual( rs[0].Name.Substring( 0, 50 ),  list1[0].Name.Substring( 0, 50 ) ) ;
			Assert.AreEqual( rs[0].MyGeography.ToString(),   "POINT (10 10)" ) ;
			Assert.AreEqual( rs[0].MyGeometry.ToString(),    "POINT (11 11)" ) ;
			Assert.AreEqual( rs[0].MyHierarchyid.ToString(), "/1/2/" ) ;

			Assert.AreEqual( rs[1].Name.Substring( 0, 50 ),  list2[0].Name.Substring( 0, 50 ) ) ;
			Assert.AreEqual( rs[1].MyGeography.ToString(),   "POINT (20 20)" ) ;
			Assert.AreEqual( rs[1].MyGeometry.ToString(),    "POINT (21 21)" ) ;
			Assert.AreEqual( rs[1].MyHierarchyid.ToString(), "/1/2/3/" ) ;

			Assert.IsNull( rs[2].Name ) ;
			Assert.IsNull( rs[2].MyGeography ) ;
			Assert.IsNull( rs[2].MyGeometry ) ;
			Assert.IsNull( rs[2].MyHierarchyid ) ;
		}

		[Test]
		public void VarmaxUnicodeTestSmallData() 
		{
			int big = 100 ;

			string bigString = "a" + new string( 'b', big )  + "c" ; // 100 chars
			
			byte[] bigBytes  = new byte[ big + 2 ] ;
			bigBytes[0] = (byte) 'a'  ;
			bigBytes[ bigBytes.Length - 2 ] = (byte) 'c' ;

			string bigXml = "<small>" + bigString + "</small>" ;

			var udt1 = new NW.storedProcedure.MyVarmaxUnicodeTableType1٠tt() ;
			var udt2 = new NW.storedProcedure.MyVarmaxUnicodeTableType2٠tt() ;
			var udt3 = new NW.storedProcedure.MyVarmaxUnicodeTableType3٠tt() ;
			var udt4 = new NW.storedProcedure.MyVarmaxUnicodeTableType4٠tt() ;

			udt1.MyVarBinary	= bigBytes ;
			udt1.MyVarChar		= bigString ;
			udt1.MyNVarChar		= bigString ;
			udt1.MyText			= bigString ;
			udt1.MyNText		= bigString ;	
			udt1.MyImage		= bigBytes ;
			udt1.MyXml			= bigXml ;
			udt2.MyBinary		= bigBytes ;
			udt3.MyChar			= bigString ;
			udt4.MyNChar		= bigString ;	

			// populate it
			var list1 = new List< NW.storedProcedure.MyVarmaxUnicodeTableType1٠tt >() ;
			var list2 = new List< NW.storedProcedure.MyVarmaxUnicodeTableType2٠tt >() ;
			var list3 = new List< NW.storedProcedure.MyVarmaxUnicodeTableType3٠tt >() ;
			var list4 = new List< NW.storedProcedure.MyVarmaxUnicodeTableType4٠tt >() ;

			list1.Add( udt1 ) ;
			list2.Add( udt2 ) ;
			list3.Add( udt3 ) ;
			list4.Add( udt4 ) ;

			// call it
			List<NW.storedProcedure.CodegenTestStoredProcVarmaxUnicodeTest٠rs1> rs = null ;
			var factory = new NW.storedProcedure.StoredProcedureFactory() ;
			factory.CodegenTestStoredProcVarmaxUnicodeTest( _connection, list1, list2, list3, list4, out rs ) ;

			//check it
			Assert.IsNotNull( rs ) ;
			Assert.IsTrue( rs.Count > 0 ) ;

			Console.WriteLine( "LenMyBinary    [{0}]", rs[0].LenMyBinary    ) ;	
			Console.WriteLine( "LenMyVarBinary [{0}]", rs[0].LenMyVarBinary ) ;
			Console.WriteLine( "LenMyChar      [{0}]", rs[0].LenMyChar      ) ;		
			Console.WriteLine( "LenMyNChar     [{0}]", rs[0].LenMyNChar     ) ;		
			Console.WriteLine( "LenMyVarChar   [{0}]", rs[0].LenMyVarChar   ) ;
			Console.WriteLine( "LenMyNVarChar  [{0}]", rs[0].LenMyNVarChar  ) ;
			Console.WriteLine( "LenMyText      [{0}]", rs[0].LenMyText      ) ;		
			Console.WriteLine( "LenMyNText     [{0}]", rs[0].LenMyNText     ) ;		
			Console.WriteLine( "LenMyImage     [{0}]", rs[0].LenMyImage     ) ;		
			Console.WriteLine( "LenMyXml       [{0}]", rs[0].LenMyXml       ) ;	

			Assert.AreEqual( 8000,      rs[0].LenMyBinary    ) ;
			Assert.AreEqual( big+2,     rs[0].LenMyVarBinary ) ;
			Assert.AreEqual( big+2,     rs[0].LenMyChar      ) ;
			Assert.AreEqual( big+2,     rs[0].LenMyNChar     ) ;
			Assert.AreEqual( big+2,     rs[0].LenMyVarChar   ) ;
			Assert.AreEqual( big+2,     rs[0].LenMyNVarChar  ) ;
			Assert.AreEqual( big+2,     rs[0].LenMyText      ) ;
			Assert.AreEqual( (big+2)*2, rs[0].LenMyNText     ) ; 
			Assert.AreEqual( big+2,     rs[0].LenMyImage     ) ;
			Assert.AreEqual( big+17,    rs[0].LenMyXml       ) ;				
		}

		[Test]
		public void VarmaxUnicodeTestBigData() 
		{
			int big = 1000000 ;

			string bigString = "a" + new string( 'b', big )  + "c" ; // 1 million chars
			
			byte[] bigBytes  = new byte[ big + 2 ] ;
			bigBytes[0] = (byte) 'a'  ;
			bigBytes[ bigBytes.Length - 2 ] = (byte) 'c' ;

			string bigXml = "<big>" + bigString + "</big>" ;
		
			var udt1 = new NW.storedProcedure.MyVarmaxUnicodeTableType1٠tt() ;
			var udt2 = new NW.storedProcedure.MyVarmaxUnicodeTableType2٠tt() ;
			var udt3 = new NW.storedProcedure.MyVarmaxUnicodeTableType3٠tt() ;
			var udt4 = new NW.storedProcedure.MyVarmaxUnicodeTableType4٠tt() ;

			udt1.MyVarBinary	= bigBytes ;
			udt1.MyVarChar		= bigString ;
			udt1.MyNVarChar		= bigString ;
			udt1.MyText			= bigString ;
			udt1.MyNText		= bigString ;	
			udt1.MyImage		= bigBytes ;
			udt1.MyXml			= bigXml ;
			udt2.MyBinary		= bigBytes ;
			udt3.MyChar			= bigString ;
			udt4.MyNChar		= bigString ;	

			// populate it
			var list1 = new List< NW.storedProcedure.MyVarmaxUnicodeTableType1٠tt >() ;
			var list2 = new List< NW.storedProcedure.MyVarmaxUnicodeTableType2٠tt >() ;
			var list3 = new List< NW.storedProcedure.MyVarmaxUnicodeTableType3٠tt >() ;
			var list4 = new List< NW.storedProcedure.MyVarmaxUnicodeTableType4٠tt >() ;

			list1.Add( udt1 ) ;
			list2.Add( udt2 ) ;
			list3.Add( udt3 ) ;
			list4.Add( udt4 ) ;

			// call it
			List<NW.storedProcedure.CodegenTestStoredProcVarmaxUnicodeTest٠rs1> rs = null ;
			var factory = new NW.storedProcedure.StoredProcedureFactory() ;
			factory.CodegenTestStoredProcVarmaxUnicodeTest( _connection, list1, list2, list3, list4, out rs ) ;

			//check it
			Assert.IsNotNull( rs ) ;
			Assert.IsTrue( rs.Count > 0 ) ;

			Console.WriteLine( "LenMyBinary    [{0}]", rs[0].LenMyBinary    ) ;	
			Console.WriteLine( "LenMyVarBinary [{0}]", rs[0].LenMyVarBinary ) ;
			Console.WriteLine( "LenMyChar      [{0}]", rs[0].LenMyChar      ) ;		
			Console.WriteLine( "LenMyNChar     [{0}]", rs[0].LenMyNChar     ) ;		
			Console.WriteLine( "LenMyVarChar   [{0}]", rs[0].LenMyVarChar   ) ;
			Console.WriteLine( "LenMyNVarChar  [{0}]", rs[0].LenMyNVarChar  ) ;
			Console.WriteLine( "LenMyText      [{0}]", rs[0].LenMyText      ) ;		
			Console.WriteLine( "LenMyNText     [{0}]", rs[0].LenMyNText     ) ;		
			Console.WriteLine( "LenMyImage     [{0}]", rs[0].LenMyImage     ) ;		
			Console.WriteLine( "LenMyXml       [{0}]", rs[0].LenMyXml       ) ;		

			Assert.AreEqual( 8000,      rs[0].LenMyBinary    ) ;
			Assert.AreEqual( big+2,     rs[0].LenMyVarBinary ) ;
			Assert.AreEqual( 8000,      rs[0].LenMyChar      ) ;
			Assert.AreEqual( 4000,      rs[0].LenMyNChar     ) ;
			Assert.AreEqual( big+2,     rs[0].LenMyVarChar   ) ;
			Assert.AreEqual( big+2,     rs[0].LenMyNVarChar  ) ;
			Assert.AreEqual( big+2,     rs[0].LenMyText      ) ;
			Assert.AreEqual( (big+2)*2, rs[0].LenMyNText     ) ; 
			Assert.AreEqual( big+2,     rs[0].LenMyImage     ) ;
			Assert.AreEqual( big+13,    rs[0].LenMyXml       ) ;
		}

		[Test]
		public void BigLoadTest() 
		{
			long? theCount = 0 ;
			long? theFirstOne = 0 ;
			long? theLastOne = 0 ; 

			var list = new List< NW.storedProcedure.MyBigIntTableType٠tt >() ;

			// add 100 000 rows
			for ( int i = 10 ; i <= 1000000 ; i += 10 )
				list.Add( new NW.storedProcedure.MyBigIntTableType٠tt() { ID = i } ) ;

			// call it
			var factory = new NW.storedProcedure.StoredProcedureFactory() ;
			factory.CodegenTestStoredProcLoadTest( _connection, list, ref theCount, ref theFirstOne, ref theLastOne ) ;

			Console.WriteLine( theCount ) ;
			Console.WriteLine( theFirstOne ) ;
			Console.WriteLine( theLastOne ) ;

			Assert.AreEqual( 100000, theCount ) ;
			Assert.AreEqual( 10, theFirstOne ) ;
			Assert.AreEqual( 1000000, theLastOne ) ;
		}

		[Test]
		public void PrecisionTest() 
		{
			List<NW.storedProcedure.CodegenTableTypePrecisionScaleTest٠rs1> rs = null ;

			var tt = new NW.storedProcedure.MyPrecisonScaleTableType٠tt() ;
			var list = new List< NW.storedProcedure.MyPrecisonScaleTableType٠tt >() ;
			list.Add( tt ) ;

			decimal theMoney				=          922337203685477.123456789012345678901234567890123456789012345678901234567890m ; // sql -922,337,203,685,477.5808 to 922,337,203,685,477.5807
			decimal theMoneyExpected		=          922337203685477.1235m ;

			decimal theSmallMoney			=                   214748.123456789012345678901234567890123456789012345678901234567890m ; // sql -214,748.3648 to 214,748.3647
			decimal theSmallMoneyExpected	=                   214748.1235m ;

			decimal theDecimal0         =           123456789012345678.123456789012345678901234567890123456789012345678901234567890m ; // sql 18.0   default sql precision
			decimal theDecimal0expected =           123456789012345678.0m ;

			decimal theDecimal1         =                            1.123456789012345678901234567890123456789012345678901234567890m ; // sql 29.28  (c# max precision = 28 )
			decimal theDecimal1expected =                            1.12345678901234567890123456790m;

			decimal theDecimal2         = 1234567890123456789012345678.123456789012345678901234567890123456789012345678901234567890m ; // sql 38.1   (c# max precision = 28 )
			decimal theDecimal2expected = 1234567890123456789012345678.10m ;

			tt.TheMoney      = theMoney ;
			tt.TheSmallMoney = theSmallMoney ;
			tt.TheDecimal0   = theDecimal0 ;
			tt.TheDecimal1   = theDecimal1 ;
			tt.TheDecimal2   = theDecimal2 ;
			tt.TheNumeric0   = theDecimal0 ; // sql numeric == decimal
			tt.TheNumeric1   = theDecimal1 ;
			tt.TheNumeric2   = theDecimal2 ;

			// call it
			var factory = new NW.storedProcedure.StoredProcedureFactory() ;
			factory.CodegenTableTypePrecisionScaleTest( _connection, list, out rs ) ;
			 
			// check it
			Assert.IsNotNull( rs ) ;
			Assert.IsTrue( rs.Count > 0 ) ;

			Console.WriteLine( "IN  money  : {0:000000000000000000000000000000000000.000000000000000000000000000000000000}",   theMoney  ) ;
			Console.WriteLine( "OUT money  : {0:000000000000000000000000000000000000.000000000000000000000000000000000000}\n", rs[0].TheMoney ) ;

			Console.WriteLine( "IN  smoney : {0:000000000000000000000000000000000000.000000000000000000000000000000000000}",   theSmallMoney  ) ;
			Console.WriteLine( "OUT smoney : {0:000000000000000000000000000000000000.000000000000000000000000000000000000}\n", rs[0].TheSmallMoney ) ;

			Console.WriteLine( "IN  dec0   : {0:000000000000000000000000000000000000.000000000000000000000000000000000000}",   theDecimal0 ) ;
			Console.WriteLine( "OUT dec0   : {0:000000000000000000000000000000000000.000000000000000000000000000000000000}\n", rs[0].TheDecimal0 ) ;

			Console.WriteLine( "IN  dec1   : {0:000000000000000000000000000000000000.000000000000000000000000000000000000}",   theDecimal1 ) ;
			Console.WriteLine( "OUT dec1   : {0:000000000000000000000000000000000000.000000000000000000000000000000000000}\n", rs[0].TheDecimal1 ) ;

			Console.WriteLine( "IN  dec2   : {0:000000000000000000000000000000000000.000000000000000000000000000000000000}",   theDecimal2 ) ;
			Console.WriteLine( "OUT dec2   : {0:000000000000000000000000000000000000.000000000000000000000000000000000000}\n", rs[0].TheDecimal2 ) ;

			Assert.AreEqual( theMoneyExpected,		rs[0].TheMoney ) ;
			Assert.AreEqual( theSmallMoneyExpected,	rs[0].TheSmallMoney ) ;
			Assert.AreEqual( theDecimal0expected,	rs[0].TheDecimal0 ) ;
			Assert.AreEqual( theDecimal1expected,	rs[0].TheDecimal1 ) ;
			Assert.AreEqual( theDecimal2expected,	rs[0].TheDecimal2 ) ;
			Assert.AreEqual( theDecimal0expected,	rs[0].TheNumeric0 ) ;
			Assert.AreEqual( theDecimal1expected,	rs[0].TheNumeric1 ) ;
			Assert.AreEqual( theDecimal2expected,	rs[0].TheNumeric2 ) ;
		}

		[Test]
		public void AllTypesInATableTypeTest() 
		{
			Guid			guid			= Guid.NewGuid();
			DateTime		now				= DateTime.Now ;
			DateTimeOffset	now2			= DateTimeOffset.Now ;
			TimeSpan		thetime			= TimeSpan.Parse( "12:44:33" ) ;
			DateTime		thedate			= new DateTime( 2001, 12, 31, 7, 53, 15 ) ;
			long			thebigint		= 1234567890 ;
			byte			thetinyint		= 3 ;
			decimal			thedecimal		= 3.14m ;
			double			thefloat		= 3.14 ;
			int				theint			= 3 ;
			decimal			themoney		= 3.14159m ;
			decimal			thesmallmoney	= 3.14159m ;
			decimal			thenumeric		= 3.14159m ;
			short			thesmallint		= 3;
			float			thereal			= 3.14f ;
			string			chars			= "a" + new string( 'b', 1000000 ) + "c" ;

			byte[] bytes = new byte[ 1000000 ] ;
			bytes[ 0 ] = 1 ;
			bytes[ bytes.Length-1 ] = 2 ;
			 
			List<NW.storedProcedure.CodegenAllTypesInATableTypeTest٠rs1> rs = null ;

			var tt = new NW.storedProcedure.MyAllTypesInATableType٠tt() ;
			var list = new List< NW.storedProcedure.MyAllTypesInATableType٠tt >() ;
			list.Add( tt ) ;

			tt.the_bigint			= thebigint ;			
			tt.the_binary			= bytes ;			
			tt.the_bit				= true ;				
			tt.the_char				= chars ;		
			tt.the_date				= now ;		
			tt.the_datetime			= now ;	
			tt.the_datetime2		= now ; 		
			tt.the_datetimeoffset	= now2 ; 	
			tt.the_decimal			= thedecimal ;			
			tt.the_float			= thefloat ;		
			tt.the_geography		= SqlGeography.Parse( "POINT (10 10)" ) ;		
			tt.the_geometry			= SqlGeometry.Parse( "POINT (20 20)" ) ;	
			tt.the_hierarchyid		= SqlHierarchyId.Parse( "/1/2/3/4/" ) ;
			tt.the_image			= bytes ;			
			tt.the_int				= theint ;				
			tt.the_money			= themoney ;			
			tt.the_nchar			= chars ;			
			tt.the_ntext			= chars ;			
			tt.the_numeric			= thenumeric ;		
			tt.the_nvarchar			= chars ;	
			tt.the_real				= thereal ;		
			tt.the_smalldatetime	= now ; 	
			tt.the_smallint			= thesmallint ;	
			tt.the_smallmoney		= thesmallmoney ; 		
			tt.the_sql_variant		= chars ;		
			tt.the_text				= chars ;			
			tt.the_time				= thetime ;		
			tt.the_tinyint			= thetinyint ;		
			tt.the_uniqueidentifier = guid ;
			tt.the_varbinary		= bytes ;	
			tt.the_varchar			= chars ;		
			tt.the_xml				= "<TheXml>" + chars + "</TheXml>" ;			
			tt.the_date				= thedate ;
			tt.the_timestamp	    = null ;	

			// call it
			var factory = new NW.storedProcedure.StoredProcedureFactory() ;
			factory.CodegenAllTypesInATableTypeTest( _connection, list, out rs ) ;

			// check it
			Assert.IsNotNull( rs ) ;
			Assert.IsTrue( rs.Count > 0 ) ;

			// nullness asserts
			var row = rs[0] ;
			Assert.IsNotNull( row.the_bigint			) ;		
			Assert.IsNotNull( row.the_binary			) ;			
			Assert.IsNotNull( row.the_bit				) ;				
			Assert.IsNotNull( row.the_char				) ;			
			Assert.IsNotNull( row.the_date				) ;			
			Assert.IsNotNull( row.the_datetime			) ;		
			Assert.IsNotNull( row.the_datetime2			) ;		
			Assert.IsNotNull( row.the_datetimeoffset	) ;	
			Assert.IsNotNull( row.the_decimal			) ;		
			Assert.IsNotNull( row.the_float				) ;			
			Assert.IsNotNull( row.the_geography			) ;		
			Assert.IsNotNull( row.the_geometry			) ;		
			Assert.IsNotNull( row.the_hierarchyid		) ;	
			Assert.IsNotNull( row.the_image				) ;			
			Assert.IsNotNull( row.the_int				) ;			
			Assert.IsNotNull( row.the_money				) ;			
			Assert.IsNotNull( row.the_nchar				) ;			
			Assert.IsNotNull( row.the_ntext				) ;			
			Assert.IsNotNull( row.the_numeric			) ;		
			Assert.IsNotNull( row.the_nvarchar			) ;		
			Assert.IsNotNull( row.the_real				) ;		
			Assert.IsNotNull( row.the_smalldatetime		) ;	
			Assert.IsNotNull( row.the_smallint			) ;		
			Assert.IsNotNull( row.the_smallmoney		) ;		
			Assert.IsNotNull( row.the_sql_variant		) ;	
			Assert.IsNotNull( row.the_text				) ;			
			Assert.IsNotNull( row.the_time				) ;			
			Assert.IsNotNull( row.the_tinyint			) ;		
			Assert.IsNotNull( row.the_uniqueidentifier	) ;
			Assert.IsNotNull( row.the_varbinary			) ;		
			Assert.IsNotNull( row.the_varchar			) ;		
			Assert.IsNotNull( row.the_xml				) ;		
			Assert.IsNotNull( row.the_timestamp			) ;

			// dump me
			Console.WriteLine( row.the_bigint ) ;		
			Console.WriteLine( "[{0}] {1}", row.the_binary.Length, GetSubArray( row.the_binary ) ) ;			
			Console.WriteLine( row.the_bit ) ;				
			Console.WriteLine( "[{0}] {1}", row.the_char.Length, GetSubString( row.the_char ) ) ;			
			Console.WriteLine( row.the_date	) ;			
			Console.WriteLine( row.the_datetime	) ;		
			Console.WriteLine( row.the_datetime2) ;		
			Console.WriteLine( row.the_datetimeoffset) ;	
			Console.WriteLine( row.the_decimal	) ;		
			Console.WriteLine( row.the_float) ;			
			Console.WriteLine( row.the_geography) ;		
			Console.WriteLine( row.the_geometry	) ;		
			Console.WriteLine( row.the_hierarchyid	) ;	
			Console.WriteLine( "[{0}] {1}", row.the_image.Length, GetSubArray( row.the_image ) ) ;			
			Console.WriteLine( row.the_int	) ;			
			Console.WriteLine( row.the_money) ;			
			Console.WriteLine( "[{0}] {1}", row.the_nchar.Length, GetSubString( row.the_nchar ) ) ;			
			Console.WriteLine( "[{0}] {1}", row.the_ntext.Length, GetSubString( row.the_ntext) ) ;			
			Console.WriteLine( row.the_numeric	) ;		
			Console.WriteLine( "[{0}] {1}", row.the_nvarchar.Length, GetSubString( row.the_nvarchar )	) ;		
			Console.WriteLine( row.the_real		) ;		
			Console.WriteLine( row.the_smalldatetime ) ;	
			Console.WriteLine( row.the_smallint	) ;		
			Console.WriteLine( row.the_smallmoney) ;		
			Console.WriteLine( "[{0}] {1}", row.the_sql_variant.ToString().Length, GetSubString( row.the_sql_variant.ToString() ) ) ;	
			Console.WriteLine( "[{0}] {1}", row.the_text.Length, GetSubString( row.the_text ) ) ;			
			Console.WriteLine( row.the_time	) ;			
			Console.WriteLine( row.the_tinyint	) ;		
			Console.WriteLine( row.the_uniqueidentifier ) ;
			Console.WriteLine( "[{0}] {1}", row.the_varbinary.Length, GetSubArray( row.the_varbinary ) ) ;		
			Console.WriteLine( "[{0}] {1}", row.the_varchar.Length, GetSubString( row.the_varchar ) ) ;		
			Console.WriteLine( "[{0}] {1}", row.the_xml.Length, GetSubString( row.the_xml ) ) ;			
			Console.WriteLine( "[{0}] {1}", row.the_timestamp.Length, GetSubArray( row.the_timestamp ) ) ;

			// content asserts
			Assert.AreEqual( thebigint, row.the_bigint ) ;		
			
			Assert.AreEqual( "1٠0٠0٠0٠0...0٠0٠0٠0٠0", GetSubArray( row.the_binary ) ) ;		
			Assert.AreEqual( 100, row.the_binary.Length ) ; // [the_binary] [binary](100)
			
			Assert.IsTrue( row.the_bit.Value ) ;				

			Assert.AreEqual( "abbbbbbbbb...bbbbbbbbbb", GetSubString( row.the_char ) ) ;
			Assert.AreEqual( 100, row.the_char.Length ) ; // [the_char] [char](100) NULL,
			
			Assert.AreEqual( thedate.Date, row.the_date	) ;			
			
			Assert.AreEqual( now.ToString( "yyyyMMddHHmmss" ), row.the_datetime.Value.ToString( "yyyyMMddHHmmss" ) ) ;		
			
			Assert.AreEqual( now.ToString( "yyyyMMddHHmmss" ), row.the_datetime2.Value.ToString( "yyyyMMddHHmmss" ) ) ;		
			
			Assert.AreEqual( now2.ToString( "yyyyMMddHHmmss K" ), row.the_datetimeoffset.Value.ToString( "yyyyMMddHHmmss K" ) ) ;	
			
			Assert.AreEqual( thedecimal, row.the_decimal	) ;		
			
			Assert.AreEqual( thefloat, row.the_float ) ;			
		
			Assert.AreEqual( "POINT (10 10)", row.the_geography.ToString() ) ;		
			
			Assert.AreEqual( "POINT (20 20)", row.the_geometry.ToString() ) ;		
			
			Assert.AreEqual( "/1/2/3/4/", row.the_hierarchyid.ToString() ) ;	
						
			Assert.AreEqual( "1٠0٠0٠0٠0...0٠0٠0٠0٠2", GetSubArray( row.the_image ) ) ;		
			Assert.AreEqual( 1000000, row.the_image.Length ) ; 
			
			Assert.AreEqual( theint, row.the_int ) ;			
			
			Assert.AreEqual( Math.Round( themoney, 4 ), row.the_money ) ;			
	
			Assert.AreEqual( "abbbbbbbbb...bbbbbbbbbb", GetSubString( row.the_nchar ) ) ;		
			Assert.AreEqual( 100, row.the_nchar.Length ) ; // [the_nchar] [nchar](100)
			
			Assert.AreEqual( "abbbbbbbbb...bbbbbbbbbc", GetSubString( row.the_ntext ) ) ;		
			Assert.AreEqual( 1000002, row.the_ntext.Length ) ; 
			
			Assert.AreEqual( thenumeric, row.the_numeric ) ;		
			
			Assert.AreEqual( "abbbbbbbbb...bbbbbbbbbb", GetSubString( row.the_nvarchar ) ) ;		
			Assert.AreEqual( 100, row.the_nvarchar.Length ) ; // [the_nvarchar] [nvarchar](100)
			
			Assert.AreEqual( thereal, row.the_real ) ;		
			
			Assert.AreEqual( now.ToString( "yyyyMMdd" ), row.the_smalldatetime.Value.ToString( "yyyyMMdd" ) ) ;	
			
			Assert.AreEqual( thesmallint, row.the_smallint) ;		
			
			Assert.AreEqual( Math.Round( thesmallmoney, 4 ), row.the_smallmoney ) ;		
			
			Assert.AreEqual( "abbbbbbbbb...bbbbbbbbbb", GetSubString( row.the_sql_variant.ToString() ) ) ;	
			Assert.AreEqual( 8000, row.the_sql_variant.ToString().Length )	; // sql variants are 8000 in length
		
			Assert.AreEqual( "abbbbbbbbb...bbbbbbbbbc", GetSubString( row.the_text ) ) ;		
			Assert.AreEqual( 1000002, row.the_text.Length ) ; 
			
			Assert.AreEqual( thetime, row.the_time ) ;			
			
			Assert.AreEqual( thetinyint, row.the_tinyint ) ;		
			
			Assert.AreEqual( guid, row.the_uniqueidentifier ) ;

			Assert.AreEqual( "1٠0٠0٠0٠0...0٠0٠0٠0٠0", GetSubArray( row.the_varbinary ) ) ;		
			Assert.AreEqual( 100, row.the_varbinary.Length ) ; // [the_varbinary] [varbinary](100)
			
			Assert.AreEqual( "abbbbbbbbb...bbbbbbbbbb", GetSubString( row.the_varchar ) ) ;		
			Assert.AreEqual( 100, row.the_varchar.Length ) ; // [the_varchar] [varchar](100)

			Assert.AreEqual( "<TheXml>ab...c</TheXml>", GetSubString( row.the_xml ) ) ;			
			Assert.AreEqual( 1000019, row.the_xml.Length ) ;
			
			Assert.IsNotNull( row.the_timestamp ) ;
			Assert.AreEqual( 8, row.the_timestamp.Length ) ;
		}

		protected string GetSubString( string str, int prefixlen = 10 )
		{
			return str.Substring(0, prefixlen ) + "..." + str.Substring( str.Length - prefixlen, prefixlen ) ;
		}

		protected string GetSubArray( byte[] bytes, int prefixlen = 5 )
		{
			int len = bytes.Length ;

			string str = "" ;

			for ( int i = 0 ; i < prefixlen ; i++ )
			{
				str += bytes[i].ToString() ; 
				if ( i < prefixlen - 1 )
					 str += "٠" ;
			}

			str += "..." ;

			for ( int i = len - prefixlen ; i < len ; i++ )
			{
				str += bytes[i].ToString() ; 
				if ( i < len - 1 )
					 str += "٠" ;
			}

			return str ;
		}

		[Test]
		public void AllTypesInATableTypeNullTest() 
		{
			List<NW.storedProcedure.CodegenAllTypesInATableTypeTest٠rs1> rs = null ;

			var tt = new NW.storedProcedure.MyAllTypesInATableType٠tt() ;
			var list = new List< NW.storedProcedure.MyAllTypesInATableType٠tt >() ;
			list.Add( tt ) ;

			// call it
			var factory = new NW.storedProcedure.StoredProcedureFactory() ;
			factory.CodegenAllTypesInATableTypeTest( _connection, list, out rs ) ;

			// check it
			Assert.IsNotNull( rs ) ;
			Assert.IsTrue( rs.Count > 0 ) ;
			var row = rs[0] ;

			Assert.IsNull	( row.the_bigint			) ;		
			Assert.IsNull	( row.the_binary			) ;			
			Assert.IsNull	( row.the_bit				) ;				
			Assert.IsNull	( row.the_char				) ;			
			Assert.IsNull	( row.the_date				) ;			
			Assert.IsNull	( row.the_datetime			) ;		
			Assert.IsNull	( row.the_datetime2			) ;		
			Assert.IsNull	( row.the_datetimeoffset	) ;	
			Assert.IsNull	( row.the_decimal			) ;		
			Assert.IsNull	( row.the_float				) ;			
			Assert.IsNull	( row.the_geography			) ;		
			Assert.IsNull	( row.the_geometry			) ;		
			Assert.IsNull	( row.the_hierarchyid		) ;	
			Assert.IsNull	( row.the_image				) ;			
			Assert.IsNull	( row.the_int				) ;			
			Assert.IsNull	( row.the_money				) ;			
			Assert.IsNull	( row.the_nchar				) ;			
			Assert.IsNull	( row.the_ntext				) ;			
			Assert.IsNull	( row.the_numeric			) ;		
			Assert.IsNull	( row.the_nvarchar			) ;		
			Assert.IsNull	( row.the_real				) ;		
			Assert.IsNull	( row.the_smalldatetime		) ;	
			Assert.IsNull	( row.the_smallint			) ;		
			Assert.IsNull	( row.the_smallmoney		) ;		
			Assert.IsNull	( row.the_sql_variant		) ;	
			Assert.IsNull	( row.the_text				) ;			
			Assert.IsNull	( row.the_time				) ;			
			Assert.IsNull	( row.the_tinyint			) ;		
			Assert.IsNull	( row.the_uniqueidentifier	) ;
			Assert.IsNull	( row.the_varbinary			) ;		
			Assert.IsNull	( row.the_varchar			) ;		
			Assert.IsNull	( row.the_xml				) ;		
			Assert.IsNotNull( row.the_timestamp			) ;
		}

	} // end class
}
