using System;
using System.Collections.Generic;
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
	public class TestTable3 : NW.test.TransactionScopeTestBase
	{
		public TestTable3()
		{
			_connectionString = Settings.ConnectionString();
		}
		
		[Test]		
		public void TestDeleteAllAndComputedColumnsInsertUpdate()
		{
			NW.table.TestTable3Factory factory = new NW.table.TestTable3Factory();

			// load all test
			List<NW.table.TestTable3> list = factory.Loadˡ(_connection);
			int count = factory.GetRowCountˡ(_connection) ;
			Console.WriteLine( "count = {0}", count ) ;
			Assert.AreEqual( count, list.Count ) ;
			
			int max = int.Parse( factory.GetMaxValueˡ( _connection, NW.table.TestTable3.column٠ID ) ) ;
			Assert.AreEqual( count, max ) ;

			// delete all test
			factory.DeleteAllˡ(_connection);
			
			int count2 = factory.GetRowCountˡ(_connection) ;
			Assert.AreEqual(count2, 0);
			Assert.IsNull( factory.GetMaxValueˡ(_connection, NW.table.TestTable3.column٠ID ) ) ;

			// insert 1 row 
			NW.table.TestTable3 obj = new NW.table.TestTable3() ;
			
			string id = factory.GetMaxValueˡ( _connection, NW.table.TestTable3.column٠ID ) ;
			if ( id == null ) id = "0" ;
			
			obj.ID = int.Parse( id ) + 1  ;
			obj.update_date = DateTime.Now ;
			obj.A = 100 ;
			obj.B = 200 ;
			//obj.C  ; 
			//obj.TheProduct ;
			//obj.TheSum  ;

				// assert unset fields
				Assert.IsNull(obj.C);
				Assert.IsNull(obj.TheProduct);
				Assert.IsNull(obj.TheSum);

				// dump object
				foreach (string key in obj.Dictionaryˡ.Keys)
					Console.WriteLine("obj [{0}] [{1}]", key, obj.Dictionaryˡ[key]);
			
			// save it
			NW.table.TestTable3 obj1 = factory.Saveˡ( _connection, obj ) ;
			Assert.IsNotNull(obj1);
			Assert.AreNotSame(obj, obj1);

				// dump object
				foreach (string key in obj1.Dictionaryˡ.Keys)
					Console.WriteLine("obj1 [{0}] [{1}]", key, obj1.Dictionaryˡ[key]);

				//assert computed fields
				Assert.AreEqual(obj1.ID, 1);
				Assert.AreEqual(obj1.TheSum, 100 + 200 );
				Assert.AreEqual(obj1.TheProduct, 100 * 200);
				Assert.IsNull( obj1.C ) ;

			// do update
			obj1.A = 101 ;
			obj1.C = -1234 ;
			NW.table.TestTable3 obj2 = factory.Saveˡ( _connection, obj1 );
			Assert.IsNotNull(obj2);
			Assert.AreNotSame(obj1, obj2);

				// dump object
				foreach (string key in obj2.Dictionaryˡ.Keys)
					Console.WriteLine("obj2 [{0}] [{1}]", key, obj2.Dictionaryˡ[key]);

				//assert computed fields
				Assert.AreEqual(obj2.ID, 1);
				Assert.AreEqual(obj2.TheSum, 101 + 200);
				Assert.AreEqual(obj2.TheProduct, 101 * 200);

			// test only 1 row in table
			list = factory.Loadˡ(_connection);
			count = factory.GetRowCountˡ(_connection);
			Console.WriteLine("count = {0}", count);
			Assert.AreEqual(count, 1);
			Assert.AreEqual(count, list.Count);
			
			max = int.Parse( factory.GetMaxValueˡ(_connection, NW.table.TestTable3.column٠ID ));
			Assert.AreEqual(max, count);

			// read it back
			NW.table.TestTable3 obj3 = factory.LoadByPrimaryKeyˡ( _connection, obj1.ID );
			Assert.IsNotNull( obj3 ) ;
			Assert.AreEqual( obj3.ID, obj1.ID ) ;
			Assert.AreEqual( obj3.ID, 1 ) ;
			Assert.AreEqual( obj3.A, obj1.A);
			
				// dump object
				foreach (string key in obj3.Dictionaryˡ.Keys)
					Console.WriteLine("obj3 [{0}] [{1}]", key, obj3.Dictionaryˡ[key]);
		}

		[Test]
		public void TestInsertAndUpdate()
		{
			NW.table.TestTable3Factory factory = new NW.table.TestTable3Factory();

			int count1 = factory.GetRowCountˡ(_connection);

			// insert row
			NW.table.TestTable3 obj1 = new NW.table.TestTable3();
			obj1.ID = int.Parse( factory.GetMaxValueˡ(_connection, NW.table.TestTable3.column٠ID )) + 1  ;
			obj1.update_date = DateTime.Now ;
			obj1.A = obj1.ID ;
			obj1.B = obj1.ID;
			
			NW.table.TestTable3 obj2 = factory.Saveˡ( _connection, obj1 );
			Assert.IsNotNull(obj2);
			Assert.AreNotEqual(obj1, obj2);
			Assert.AreEqual(obj1.ID, obj2.ID);
			Assert.AreEqual(obj2.TheProduct, obj1.A * obj1.B);

			int count2 = factory.GetRowCountˡ(_connection);
			Assert.AreEqual(count2, count1 + 1);

			// dump object
			foreach (string key in obj2.Dictionaryˡ.Keys)
				Console.WriteLine("obj2 [{0}] [{1}]", key, obj2.Dictionaryˡ[key]);
			foreach (string key in obj2.PrimaryKeyDictionaryˡ.Keys)
				Console.WriteLine("obj2 pk [{0}] [{1}]", key, obj2.PrimaryKeyDictionaryˡ[key]);

			// test normal update
			obj2.A = 100 ;
			obj2.B = 100;
			obj2.update_date = DateTime.Now;
			NW.table.TestTable3 obj3 = factory.Saveˡ( _connection, obj2 );
			Assert.IsNotNull(obj3);
			Assert.AreNotEqual(obj2, obj3);
			Assert.AreEqual(obj3.ID, obj2.ID);
			Assert.AreEqual(obj3.TheProduct, 100*100);

			int count3 = factory.GetRowCountˡ(_connection);
			Assert.AreEqual(count3, count2);

			// dump object
			foreach (string key in obj3.Dictionaryˡ.Keys)
				Console.WriteLine("obj3 [{0}] [{1}]", key, obj3.Dictionaryˡ[key]);
			foreach (string key in obj3.PrimaryKeyDictionaryˡ.Keys)
				Console.WriteLine("obj3 pk [{0}] [{1}]", key, obj3.PrimaryKeyDictionaryˡ[key]);

			// update primary key
			obj3.ID = obj2.ID * 2 ;
			obj3.update_date = DateTime.Now;
			NW.table.TestTable3 obj4 = factory.Saveˡ( _connection, obj3 );
			Assert.IsNotNull(obj4);
			Assert.AreNotEqual(obj3, obj4);
			Assert.AreEqual(obj4.ID, obj3.ID);
			Assert.AreEqual(obj4.ID, obj2.ID*2);
			Assert.AreEqual(obj4.TheProduct, 100 * 100);

			// dump object
			foreach (string key in obj4.Dictionaryˡ.Keys)
				Console.WriteLine("obj4 [{0}] [{1}]", key, obj4.Dictionaryˡ[key]);
			foreach (string key in obj4.PrimaryKeyDictionaryˡ.Keys)
				Console.WriteLine("obj4 pk [{0}] [{1}]", key, obj4.PrimaryKeyDictionaryˡ[key]);

			// check that original ID is now not found
			NW.table.TestTable3 obj5 = factory.LoadByPrimaryKeyˡ( _connection, obj1.ID ) ;
			Assert.IsNull(obj5);

			int count4 = factory.GetRowCountˡ(_connection);
			Assert.AreEqual(count4, count2);
		}

	}
}