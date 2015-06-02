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
	public class TestTable2 : NW.test.TransactionScopeTestBase
	{
		public TestTable2()
		{
			_connectionString = Settings.ConnectionString();
		}

		[Test]
		public void TestAlbertsSuburbs()
		{
			NW.table.TestTable2bFactory factory = new NW.table.TestTable2bFactory();

			string person = "Albert" ;
			NW.table.TestTable2b alby = factory.LoadByPrimaryKeyˡ(_connection, person);

			Assert.IsNotNull(alby);
			Assert.AreEqual(alby.Person, person);

			// get alby's home suburb - ingleburn 
			Assert.AreEqual( alby.parent٠TestTable2a٠By٠HomeStateHomePostCode( _connection ).Suburb, "Ingleburn" ) ;

			// get everyone who lives in the same suburb as alby - alby and ana
			Assert.AreEqual( alby.parent٠TestTable2a٠By٠HomeStateHomePostCode(_connection).children٠TestTable2b٠By٠HomeStateHomePostCode(_connection).Count, 2); 

			// get alby's mail suburb
			Assert.AreEqual(alby.parent٠TestTable2a٠By٠MailStateMailPostCode(_connection).Suburb, "City");
		}

		[Test]
		public void TestConcurrencyBasic()
		{
			NW.table.TestTable2bFactory factory = new NW.table.TestTable2bFactory();

			// new object
			NW.table.TestTable2b obj = new NW.table.TestTable2b() ;
			
			Assert.AreEqual(obj.ConcurrencyColumnˡ, "update_date");
			Assert.IsNull(obj.ConcurrencyTimestampˡ );

			// loaded object
			string person = "Albert" ;
			NW.table.TestTable2b alby = factory.LoadByPrimaryKeyˡ(_connection, person);

			Assert.AreEqual(alby.ConcurrencyColumnˡ, "update_date");
			Assert.IsNotNull(alby.ConcurrencyTimestampˡ);
			
			Assert.AreEqual( alby.ConcurrencyTimestampˡ, alby.update_date ) ;
		}

		[Test]		
		public void TestSaveDelete()
		{
			// insert object
			NW.table.TestTable2bFactory factory = new NW.table.TestTable2bFactory();
			NW.table.TestTable2b obj1 = new NW.table.TestTable2b();

			obj1.Person = "Luka";
			obj1.MailPostCode = "2565";
			obj1.MailState = "NSW";
			obj1.HomePostCode = obj1.MailPostCode;
			obj1.HomeState = obj1.MailState;
			obj1.update_date = DateTime.Now;

				// test flags
				Assert.AreEqual(obj1.IsSavedˡ, false);
				Assert.AreEqual(obj1.IsDeletedˡ, false);
				Assert.AreEqual(obj1.IsDirtyˡ, true);
				Assert.AreEqual(obj1.IsFromDatabaseˡ, false);
				Assert.AreEqual(obj1.MarkForDeletionˡ, false);

			// delete new and unsaved object - expect exception
			try
			{
				obj1.MarkForDeletionˡ = true;
				factory.Saveˡ( _connection, obj1 );
				Assert.Fail("should have received save exception here");
			}
			catch (alby.codegen.runtime.CodeGenSaveException ex)
			{
				Console.WriteLine("Expected exception:\n\t\t" + ex.ToString());
				obj1.MarkForDeletionˡ = false;
			}
			
			// save it			
			NW.table.TestTable2b obj1a = factory.Saveˡ( _connection, obj1 );
			Assert.IsNotNull(obj1a);

				// test flags
				Assert.AreEqual(obj1.IsSavedˡ, true);
				Assert.AreEqual(obj1.IsDeletedˡ, false);
				Assert.AreEqual(obj1.IsDirtyˡ, false);
				Assert.AreEqual(obj1.IsFromDatabaseˡ, false);
				Assert.AreEqual(obj1.MarkForDeletionˡ, false);

				Assert.AreEqual(obj1a.IsSavedˡ, false);
				Assert.AreEqual(obj1a.IsDeletedˡ, false);
				Assert.AreEqual(obj1a.IsDirtyˡ, false);
				Assert.AreEqual(obj1a.IsFromDatabaseˡ, true);
				Assert.AreEqual(obj1a.MarkForDeletionˡ, false);

			// load it back - should be not null
			NW.table.TestTable2b obj1b = factory.LoadByPrimaryKeyˡ( _connection, obj1.Person);
			Assert.IsNotNull(obj1b);
			Assert.AreEqual( obj1a.Person, obj1b.Person ) ;
			Assert.AreNotSame( obj1a, obj1b ) ;

				// test flags
				Assert.AreEqual(obj1b.IsSavedˡ, false);
				Assert.AreEqual(obj1b.IsDeletedˡ, false);
				Assert.AreEqual(obj1b.IsDirtyˡ, false);
				Assert.AreEqual(obj1b.IsFromDatabaseˡ, true);
				Assert.AreEqual(obj1b.MarkForDeletionˡ, false);

			// save it again - expect exception
			try
			{
				obj1.IsDirtyˡ = true;
				factory.Saveˡ( _connection, obj1 );
				Assert.Fail("should have received save exception here");
			}
			catch (alby.codegen.runtime.CodeGenSaveException ex)
			{
				Console.WriteLine("Expected exception:\n\t\t" + ex.ToString());
				obj1.IsDirtyˡ = false;
			}
			
			// delete it
			obj1a.MarkForDeletionˡ = true ;
			NW.table.TestTable2b obj2 = factory.Saveˡ( _connection, obj1a );
			Assert.IsNull(obj2);

				// test flags
				Assert.AreEqual(obj1a.IsSavedˡ, true);
				Assert.AreEqual(obj1a.IsDeletedˡ, true);
				Assert.AreEqual(obj1a.IsDirtyˡ, false);
				Assert.AreEqual(obj1a.IsFromDatabaseˡ, true);
				Assert.AreEqual(obj1a.MarkForDeletionˡ, false);
					
			// load it back - should be null
			NW.table.TestTable2b obj4 = factory.LoadByPrimaryKeyˡ(_connection, obj1.Person);
			Assert.IsNull(obj4);

			// delete the same object again - expect exception 
			try
			{
				obj1a.MarkForDeletionˡ = true ;
				factory.Saveˡ( _connection, obj1a );
				Assert.Fail("should have received save exception here");
			}
			catch (alby.codegen.runtime.CodeGenSaveException ex)
			{
				Console.WriteLine("Expected exception:\n\t\t" + ex.ToString());
				obj1.MarkForDeletionˡ = false;
			}

			// delete a copy of the object - expect 0 rows deleted exception
			try
			{
				obj1b.MarkForDeletionˡ = true;
				factory.Saveˡ( _connection, obj1b );
				Assert.Fail("should have received save exception here");
			}
			catch (alby.codegen.runtime.CodeGenSaveException ex)
			{
				Console.WriteLine("Expected exception:\n\t\t" + ex.ToString());
				obj1b.MarkForDeletionˡ = false;
			}

			// re-insert the object
			obj1b.IsFromDatabaseˡ = false;
			obj1b.IsDirtyˡ = true;
			NW.table.TestTable2b obj5 = factory.Saveˡ( _connection, obj1b );

				// test flags
				Assert.AreEqual(obj1b.IsSavedˡ, true);
				Assert.AreEqual(obj1b.IsDeletedˡ, false);
				Assert.AreEqual(obj1b.IsDirtyˡ, false); 
				Assert.AreEqual(obj1b.IsFromDatabaseˡ, false);
				Assert.AreEqual(obj1b.MarkForDeletionˡ, false);

				Assert.AreEqual(obj5.IsSavedˡ, false);
				Assert.AreEqual(obj5.IsDeletedˡ, false);
				Assert.AreEqual(obj5.IsDirtyˡ, false);
				Assert.AreEqual(obj5.IsFromDatabaseˡ, true);
				Assert.AreEqual(obj5.MarkForDeletionˡ, false);

			// load it back - should be not null
			NW.table.TestTable2b obj6 = factory.LoadByPrimaryKeyˡ(_connection, obj5.Person);
			Assert.IsNotNull(obj6);
			Assert.AreEqual(obj5.Person, obj6.Person);
			Assert.AreNotSame(obj5, obj6);

				// test flags
				Assert.AreEqual(obj6.IsSavedˡ, false);
				Assert.AreEqual(obj6.IsDeletedˡ, false);
				Assert.AreEqual(obj6.IsDirtyˡ, false);
				Assert.AreEqual(obj6.IsFromDatabaseˡ, true);
				Assert.AreEqual(obj6.MarkForDeletionˡ, false);
		}
		
		[Test]		
		public void TestSaveInsert()
		{
			//base._commitTransaction = true ;
			DateTime dt ;
		
			NW.table.TestTable2bFactory factory = new NW.table.TestTable2bFactory();
			NW.table.TestTable2b obj1 = new NW.table.TestTable2b();

				// test flags
				Assert.AreEqual( obj1.IsSavedˡ, false);
				Assert.AreEqual( obj1.IsDeletedˡ, false); 
				Assert.AreEqual( obj1.IsDirtyˡ, true ) ;
				Assert.AreEqual( obj1.IsFromDatabaseˡ, false ) ;
				Assert.AreEqual( obj1.MarkForDeletionˡ, false ) ;
		
			obj1.Person = "Luka" ;
			obj1.MailPostCode = "2565" ;
			obj1.MailState = "NSW" ;
			
			obj1.HomePostCode = obj1.MailPostCode ;
			obj1.HomeState = obj1.MailState ;
			
			obj1.update_date = DateTime.Now ;
			
				// test flags
				Assert.AreEqual(obj1.IsSavedˡ, false);
				Assert.AreEqual(obj1.IsDeletedˡ, false);
				Assert.AreEqual(obj1.IsDirtyˡ, true);
				Assert.AreEqual(obj1.IsFromDatabaseˡ, false);
				Assert.AreEqual(obj1.MarkForDeletionˡ, false);

			// save it
			NW.table.TestTable2b obj1a = factory.Saveˡ( _connection, obj1 );
			Assert.IsNotNull(obj1a);
			dt = (DateTime) obj1a.ConcurrencyTimestampˡ;
			Console.WriteLine("obj1a Concurrency [{0}] [{1}]", obj1a.ConcurrencyColumnˡ, dt.ToString("HH.mm.ss.ffffff") ); 
		
				// test flags
				Assert.AreEqual(obj1.IsSavedˡ, true);
				Assert.AreEqual(obj1.IsDeletedˡ, false);
				Assert.AreEqual(obj1.IsDirtyˡ, false);
				Assert.AreEqual(obj1.IsFromDatabaseˡ, false);
				Assert.AreEqual(obj1.MarkForDeletionˡ, false);

				Assert.AreEqual(obj1a.IsSavedˡ, false);
				Assert.AreEqual(obj1a.IsDeletedˡ, false);
				Assert.AreEqual(obj1a.IsDirtyˡ, false);
				Assert.AreEqual(obj1a.IsFromDatabaseˡ, true);
				Assert.AreEqual(obj1a.MarkForDeletionˡ, false);
			
			// load it back
			NW.table.TestTable2b obj2 = factory.LoadByPrimaryKeyˡ( _connection, obj1.Person ) ;
			Assert.IsNotNull(obj2);

				// test flags
				Assert.AreEqual(obj2.IsSavedˡ, false);
				Assert.AreEqual(obj2.IsDeletedˡ, false);
				Assert.AreEqual(obj2.IsDirtyˡ, false);
				Assert.AreEqual(obj2.IsFromDatabaseˡ, true);
				Assert.AreEqual(obj2.MarkForDeletionˡ, false);
			
			Assert.AreEqual( obj1a.Person, obj2.Person ) ;

			// make dirty
			obj2.MailPostCode = "2000";

			System.Threading.Thread.Sleep(500);
			obj2.update_date = DateTime.Now;

				// test flags
				Assert.AreEqual(obj2.IsSavedˡ, false);
				Assert.AreEqual(obj2.IsDeletedˡ, false);
				Assert.AreEqual(obj2.IsDirtyˡ, true);
				Assert.AreEqual(obj2.IsFromDatabaseˡ, true);
				Assert.AreEqual(obj2.MarkForDeletionˡ, false);
			
			// save it back - tests update
			NW.table.TestTable2b obj2a = factory.Saveˡ( _connection, obj2 );
			Assert.IsNotNull(obj2a);
			dt = (DateTime) obj2a.ConcurrencyTimestampˡ ;
			Console.WriteLine("obj2a Concurrency [{0}] [{1}]", obj2a.ConcurrencyColumnˡ, dt.ToString("HH.mm.ss.ffffff") ); 

				// test flags
				Assert.AreEqual(obj2.IsSavedˡ, true);
				Assert.AreEqual(obj2.IsDeletedˡ, false);
				Assert.AreEqual(obj2.IsDirtyˡ, false);
				Assert.AreEqual(obj2.IsFromDatabaseˡ, true);
				Assert.AreEqual(obj2.MarkForDeletionˡ, false);

				Assert.AreEqual(obj2a.IsSavedˡ, false);
				Assert.AreEqual(obj2a.IsDeletedˡ, false);
				Assert.AreEqual(obj2a.IsDirtyˡ, false);
				Assert.AreEqual(obj2a.IsFromDatabaseˡ, true);
				Assert.AreEqual(obj2a.MarkForDeletionˡ, false);
			
			// try and save the same object 2 again - expect save error
			try
			{
				obj2.IsDirtyˡ = true ;
				factory.Saveˡ( _connection, obj2 );
				Assert.Fail("should have received save exception here");
			}
			catch (alby.codegen.runtime.CodeGenSaveException ex)
			{
				Console.WriteLine("Expected exception:\n\t\t" + ex.ToString());
			}

			// test concurrency - expect save error
			try
			{
				obj1a.IsDirtyˡ = true;
				factory.Saveˡ( _connection, obj1a );
				Assert.Fail("should have received save exception here");
			}
			catch (alby.codegen.runtime.CodeGenSaveException ex)
			{
				Console.WriteLine("Expected exception:\n\t\t" + ex.ToString());
				Console.WriteLine(ex.Sql);
				foreach (SqlParameter p in ex.Parameters)
					Console.WriteLine("obj1a Parameter [{0}] [{1}]", p.ParameterName, p.Value.ToString());

				foreach (string key in ex.RowBase.PrimaryKeyDictionaryˡ.Keys)
					Console.WriteLine("obj1a PK [{0}] [{1}]", key, ex.RowBase.PrimaryKeyDictionaryˡ[key]);

				dt = (DateTime)ex.RowBase.ConcurrencyTimestampˡ;
				Console.WriteLine("obj1a Concurrency [{0}] [{1}]", ex.RowBase.ConcurrencyColumnˡ, dt.ToString("HH.mm.ss.ffffff"));
			}
						
		}
		
		// test - upadte primary key
		
	}
}