using System;
using System.Collections.Generic;
using System.IO ;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Transactions ;

using NUnit.Framework ;

using NW = alby.northwind.codegen  ;

namespace alby.northwind.codegen.test.table
{	
	[TestFixture]
	public class TestTable4 : NW.test.TransactionScopeTestBase
	{
		public TestTable4()
		{
			_connectionString = Settings.ConnectionString();
		}
		
		[Test]
		public void TestInsertAndUpdateNulls()
		{
			NW.table.TestTable4Factory factory = new NW.table.TestTable4Factory();

			int count1 = factory.GetRowCountˡ(_connection);

			// insert row with nulls
			NW.table.TestTable4 obj1 = new NW.table.TestTable4();
			obj1.ID = Guid.NewGuid() ;
			//DumpObject( "obj1", obj1 ) ;
			
			NW.table.TestTable4 obj2 = factory.Saveˡ( _connection, obj1 );
			Assert.IsNotNull(obj2);
			//DumpObject("obj2", obj2);
			Assert.AreNotSame(obj1, obj2);
			Assert.AreEqual(obj1.ID, obj2.ID);

			int count2 = factory.GetRowCountˡ(_connection);
			Assert.AreEqual(count2, count1+1);
			
			// do update
			obj2.IsDirtyˡ = true ;
			NW.table.TestTable4 obj3 = factory.Saveˡ( _connection, obj2 );
			Assert.IsNotNull(obj3);
			//DumpObject("obj3", obj3);
			Assert.AreNotSame(obj3, obj2);
			Assert.AreEqual(obj3.ID, obj2.ID);

			int count3 = factory.GetRowCountˡ(_connection);
			Assert.AreEqual(count2, count3);

			// change guid pk and save
			obj3.ID = Guid.NewGuid() ;
			NW.table.TestTable4 obj4 = factory.Saveˡ( _connection, obj3 );
			Assert.IsNotNull(obj4);
			//DumpObject("obj4", obj4);
			Assert.AreNotSame(obj4, obj3);
			Assert.AreEqual(obj4.ID, obj3.ID);
			Assert.AreNotEqual(obj3.ID, obj2.ID);

			int count4 = factory.GetRowCountˡ(_connection);
			Assert.AreEqual(count4, count3);
		}


		[Test]
		public void TestInsertAndUpdateNotNulls()
		{
			NW.table.TestTable4Factory factory = new NW.table.TestTable4Factory();

			int count1 = factory.GetRowCountˡ(_connection);
		
			string		testguid1	= "aafd046c-cc96-4618-bbf5-727af189f000" ;
			string		testguid1a	= "abfd046c-cc96-4618-bbf5-727af189f000" ;
			short		testint1	= -12 ;
			decimal		testdec1	= -12.34567m ;
			decimal		testmoney1	= -12.1234m ;
			float		testfloat1	= -3.14f ;
			DateTime	testdate1	= new DateTime( 1999, 12, 21, 9, 11, 23 ) ;
			string		teststring1 = "the fat cat sat on the mat and jack and jill went up the hill to fetch a pale of water." ;
			byte[]		testarray1  = GetByteArray( 10, 23 ) ;
			byte[]		testarray1a  = GetByteArray( 100, 42 ) ;

			string		testguid2	= "bbfd046c-cc96-4618-bbf5-727af189f000" ;
			string		testguid2a	= "bcfd046c-cc96-4618-bbf5-727af189f001" ;
			short		testint2	= -3 ;
			decimal		testdec2	= -3.34567m ;
			decimal		testmoney2	= -3.1234m ;
			float		testfloat2	= -1.14f ;
			DateTime	testdate2	= new DateTime( 1990, 12, 21, 9, 11, 23 ) ;
			string		teststring2 = "once upon a time there was a princess and her name was clare and she had a magic wand and used it throughout the land." ;
			byte[]		testarray2  = GetByteArray( 10, 46 ) ;
			byte[]		testarray2a  = GetByteArray( 100, 200 ) ;
			
			// insert row with not nulls 
			NW.table.TestTable4 obj1 = new NW.table.TestTable4();
			obj1.ID					= new Guid( testguid1 );
			obj1.f_guid				= new Guid( testguid1a );
			obj1.f_bigint			= testint1 ; 
			obj1.f_int				= testint1 ;
			obj1.f_smallint			= testint1 ;
			obj1.f_bit				= true ;
			obj1.f_decimal			= testdec1 ;
			obj1.f_numeric			= testdec1 ;
			obj1.f_money			= testmoney1 ;
			obj1.f_smallmoney		= testmoney1 ;
			obj1.f_float			= testfloat1 ;
			obj1.f_real				= testfloat1 ;
			obj1.f_datetime			= testdate1 ;
			obj1.f_smalldatetime	= testdate1 ;
			obj1.f_char				= teststring1.Substring(0, 10) ;
			obj1.f_varchar			= teststring1.Substring(0, 10);
			obj1.f_text				= teststring1 ;
			obj1.f_nchar			= teststring1.Substring(0, 10);
			obj1.f_nvarchar			= teststring1.Substring(0, 10);
			obj1.f_ntext			= teststring1 ;
			obj1.f_binary			= testarray1 ;
			obj1.f_varbinary		= testarray1 ;
			obj1.f_image			= testarray1a;
			obj1.f_xml				= teststring1 ;			
			DumpObject( "obj1", obj1 ) ;

			NW.table.TestTable4 obj2 = factory.Saveˡ( _connection, obj1 );  // insert
			Assert.IsNotNull(obj2);
			DumpObject("obj2.0", obj2);
			Assert.AreNotSame(obj1, obj2);
			Assert.AreEqual(obj1.ID, obj2.ID);

			// test returned fields
			Assert.AreEqual(obj2.ID.ToString(), testguid1.ToString());
			Assert.AreEqual(obj2.f_guid.ToString(), testguid1a.ToString());
			Assert.AreEqual(obj2.f_bigint,testint1);
			Assert.AreEqual(obj2.f_int, testint1);
			Assert.AreEqual(obj2.f_smallint, testint1);
			Assert.AreEqual(obj2.f_bit,true);
			Assert.AreEqual(obj2.f_decimal, testdec1);
			Assert.AreEqual(obj2.f_numeric, testdec1);
			Assert.AreEqual(obj2.f_money, testmoney1);
			Assert.AreEqual(obj2.f_smallmoney, testmoney1);
			Assert.AreEqual(obj2.f_float, testfloat1);
			Assert.AreEqual(obj2.f_real, testfloat1);
			Assert.AreEqual(obj2.f_datetime, testdate1);
			Assert.AreEqual(obj2.f_smalldatetime, new DateTime( testdate1.Year, testdate1.Month, testdate1.Day, testdate1.Hour, testdate1.Minute, 0 ));
			Assert.AreEqual(obj2.f_char, teststring1.Substring(0, 10));
			Assert.AreEqual(obj2.f_varchar, teststring1.Substring(0, 10));
			Assert.AreEqual(obj2.f_text, teststring1 );
			Assert.AreEqual(obj2.f_nchar, teststring1.Substring(0, 10));
			Assert.AreEqual(obj2.f_nvarchar, teststring1.Substring(0, 10));
			Assert.AreEqual(obj2.f_ntext, teststring1);
			Assert.AreEqual(Convert.ToBase64String(obj2.f_binary), Convert.ToBase64String(testarray1));
			Assert.AreEqual(Convert.ToBase64String(obj2.f_varbinary), Convert.ToBase64String(testarray1));
			Assert.AreEqual(Convert.ToBase64String(obj2.f_image), Convert.ToBase64String(testarray1a));
			Assert.AreEqual(obj2.f_xml, teststring1 );

			int count2 = factory.GetRowCountˡ(_connection);
			Assert.AreEqual(count2, count1 + 1);
			
			// do update			
			obj2.ID					= new Guid(testguid2);
			obj2.f_guid				= new Guid(testguid2a);
			obj2.f_bigint			= testint2;
			obj2.f_int				= testint2;
			obj2.f_smallint			= testint2;
			obj2.f_bit				= false ;
			obj2.f_decimal			= testdec2;
			obj2.f_numeric			= testdec2;
			obj2.f_money			= testmoney2;
			obj2.f_smallmoney		= testmoney2;
			obj2.f_float			= testfloat2;
			obj2.f_real				= testfloat2;
			obj2.f_datetime			= testdate2;
			obj2.f_smalldatetime	= testdate2;
			obj2.f_char				= teststring2.Substring(0, 10);
			obj2.f_varchar			= teststring2.Substring(0, 10);
			obj2.f_text				= teststring2;
			obj2.f_nchar			= teststring2.Substring(0, 10);
			obj2.f_nvarchar			= teststring2.Substring(0, 10);
			obj2.f_ntext			= teststring2;
			obj2.f_binary			= testarray2;
			obj2.f_varbinary		= testarray2;
			obj2.f_image			= testarray2a;
			obj2.f_xml				= teststring2;
			DumpObject("obj2.1", obj2);
			
			NW.table.TestTable4 obj3 = factory.Saveˡ( _connection, obj2 ); // update
			Assert.IsNotNull(obj3);
			DumpObject("obj3.0", obj3);
			Assert.AreNotSame(obj3, obj2);
			Assert.AreEqual(obj3.ID, obj2.ID);

			// test returned fields
			Assert.AreEqual(obj3.ID.ToString(), testguid2.ToString());
			Assert.AreEqual(obj3.f_guid.ToString(), testguid2a.ToString());
			Assert.AreEqual(obj3.f_bigint, testint2);
			Assert.AreEqual(obj3.f_int, testint2);
			Assert.AreEqual(obj3.f_smallint, testint2);
			Assert.AreEqual(obj3.f_bit, false);
			Assert.AreEqual(obj3.f_decimal, testdec2);
			Assert.AreEqual(obj3.f_numeric, testdec2);
			Assert.AreEqual(obj3.f_money, testmoney2);
			Assert.AreEqual(obj3.f_smallmoney, testmoney2);
			Assert.AreEqual(obj3.f_float, testfloat2);
			Assert.AreEqual(obj3.f_real, testfloat2);
			Assert.AreEqual(obj3.f_datetime, testdate2);
			Assert.AreEqual(obj3.f_smalldatetime, new DateTime(testdate2.Year, testdate2.Month, testdate2.Day, testdate2.Hour, testdate2.Minute, 0));
			Assert.AreEqual(obj3.f_char, teststring2.Substring(0, 10));
			Assert.AreEqual(obj3.f_varchar, teststring2.Substring(0, 10));
			Assert.AreEqual(obj3.f_text, teststring2);
			Assert.AreEqual(obj3.f_nchar, teststring2.Substring(0, 10));
			Assert.AreEqual(obj3.f_nvarchar, teststring2.Substring(0, 10));
			Assert.AreEqual(obj3.f_ntext, teststring2);
			Assert.AreEqual(Convert.ToBase64String(obj3.f_binary), Convert.ToBase64String(testarray2));
			Assert.AreEqual(Convert.ToBase64String(obj3.f_varbinary), Convert.ToBase64String(testarray2));
			Assert.AreEqual(Convert.ToBase64String(obj3.f_image), Convert.ToBase64String(testarray2a));
			Assert.AreEqual(obj3.f_xml, teststring2);

			int count3 = factory.GetRowCountˡ(_connection);
			Assert.AreEqual(count3, count2);

			// do update - set fields to null
			obj3.f_guid				= null;
			obj3.f_bigint			= null;
			obj3.f_int				= null;
			obj3.f_smallint			= null;
			obj3.f_bit				= null;
			obj3.f_decimal			= null;
			obj3.f_numeric			= null;
			obj3.f_money			= null;
			obj3.f_smallmoney		= null;
			obj3.f_float			= null;
			obj3.f_real				= null;
			obj3.f_datetime			= null;
			obj3.f_smalldatetime	= null;
			obj3.f_char				= null;
			obj3.f_varchar			= null;
			obj3.f_text				= null;
			obj3.f_nchar			= null;
			obj3.f_nvarchar			= null;
			obj3.f_ntext			= null;
			obj3.f_binary			= null;
			obj3.f_varbinary		= null;
			obj3.f_image			= null;
			obj3.f_xml				= null;
			DumpObject("obj3.1", obj3);

			NW.table.TestTable4 obj4 = factory.Saveˡ( _connection, obj3 ); // update
			Assert.IsNotNull(obj4);
			DumpObject("obj4", obj4);
			Assert.AreNotSame(obj4, obj3);
			Assert.AreEqual(obj4.ID, obj3.ID);

			// test returned fields
			Assert.IsNull(obj4.f_guid);
			Assert.IsNull(obj4.f_bigint);
			Assert.IsNull(obj4.f_int);
			Assert.IsNull(obj4.f_smallint);
			Assert.IsNull(obj4.f_bit);
			Assert.IsNull(obj4.f_decimal);
			Assert.IsNull(obj4.f_numeric);
			Assert.IsNull(obj4.f_money);
			Assert.IsNull(obj4.f_smallmoney);
			Assert.IsNull(obj4.f_float);
			Assert.IsNull(obj4.f_real);
			Assert.IsNull(obj4.f_datetime);
			Assert.IsNull(obj4.f_smalldatetime);
			Assert.IsNull(obj4.f_char);
			Assert.IsNull(obj4.f_varchar);
			Assert.IsNull(obj4.f_text);
			Assert.IsNull(obj4.f_nchar);
			Assert.IsNull(obj4.f_nvarchar);
			Assert.IsNull(obj4.f_ntext);
			Assert.IsNull(obj4.f_binary);
			Assert.IsNull(obj4.f_varbinary);
			Assert.IsNull(obj4.f_image);
			Assert.IsNull(obj4.f_xml);

			int count4 = factory.GetRowCountˡ(_connection);
			Assert.AreEqual(count4, count3);
		}	

		#region helpers

		protected void DumpObject( string header, NW.table.TestTable4 obj ) 
		{
			foreach (string key in obj.Dictionaryˡ.Keys)
			{
				string str = "<null>" ;
				object val = obj.Dictionaryˡ[key] ;
				
				if (val != null) 
				{
					if ( val is byte[] )
					{
						byte[] b = val as byte[] ; 
						str = b.Length + "-" + Convert.ToBase64String(b) ; 
					}
					else
						str = val.ToString() ;
				}
				Console.WriteLine("{0} [{1}] [{2}]", header, key, str );
			}
		}
		
		
		protected byte[] GetByteArray( int size, byte c )
		{
			byte[] b = new byte[ size ] ;
			
			for ( int i = 0 ; i < b.Length ; i++ )
				b[i] =c ;
		
			return b ;
		}

		#endregion
	}
}