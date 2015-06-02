
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Transactions ;
using NUnit.Framework ;
using alby.codegen.runtime ;

using alby.northwind.codegen.table ;


namespace ModelCodeGenUnitTestNamespace
{	
	[TestFixture]
	public partial class ModelCodeGenUnitTestClass : CodeGenUnitTestBase
	{

		public ModelCodeGenUnitTestClass()	: base()
		{
		}

		public override string ConnectionString
		{
			get
			{
				return "Data Source=.;Initial Catalog=northwind;Integrated Security=SSPI;";
			}
		}

		public override bool QuietMode
		{
			get
			{
				return false ;
			}
		}

		[Test]
		public void PositiveTestInsertUpdateDelete()
		{
				// create object factory
				TestTable2bFactory factory_TestTable2bFactory = new TestTable2bFactory();


			// create object
			TestTable2b obj0_TestTable2b = new TestTable2b();
			AssertFlagsObjectNew(obj0_TestTable2b);


				// populate fields for insert
				Populate_TestTable2b(obj0_TestTable2b, true );
				OverridePopulate_TestTable2b(obj0_TestTable2b, true );
			
			
			// insert the object
			Console.WriteLine("TestTable2b - insert");
			AssertFlagsBeforeInsert(obj0_TestTable2b);
			int rowcount0__TestTable2b = factory_TestTable2bFactory.GetRowCountˡ(_connection);
			TestTable2b obj1_TestTable2b = factory_TestTable2bFactory.Saveˡ( _connection, obj0_TestTable2b );
			int rowcount1__TestTable2b = factory_TestTable2bFactory.GetRowCountˡ( _connection );
			Assert.AreEqual(rowcount1__TestTable2b, rowcount0__TestTable2b+1);
			AssertFlagsAfterInsert( obj0_TestTable2b );


				// assert object retrieved succesfully
				Assert.IsNotNull(obj1_TestTable2b);
				AssertFlagsObjectLoaded(obj1_TestTable2b);
				Assert.AreEqual(obj1_TestTable2b.Person, obj0_TestTable2b.Person); // repeated rows here


			// populate fields for update 
			Populate_TestTable2b(obj1_TestTable2b, false );
			OverridePopulate_TestTable2b(obj1_TestTable2b, false );

			
				// update the object
				Console.WriteLine("TestTable2b - update");
				AssertFlagsBeforeUpdate(obj1_TestTable2b);
				TestTable2b obj2_TestTable2b = factory_TestTable2bFactory.Saveˡ( _connection, obj1_TestTable2b );
				int rowcount2__TestTable2b = factory_TestTable2bFactory.GetRowCountˡ(_connection);
				Assert.AreEqual(rowcount2__TestTable2b, rowcount1__TestTable2b);
				AssertFlagsAfterUpdate(obj1_TestTable2b);


			// assert object retrieved succesfully
			Assert.IsNotNull(obj2_TestTable2b);
			AssertFlagsObjectLoaded(obj2_TestTable2b);
			Assert.AreEqual(obj2_TestTable2b.Person, obj1_TestTable2b.Person); // repeated rows here
			
		
			
				// delete the object
				Console.WriteLine("TestTable2b - delete");
				obj2_TestTable2b.MarkForDeletionˡ = true;
				AssertFlagsBeforeDelete(obj2_TestTable2b);
				TestTable2b obj3_TestTable2b = factory_TestTable2bFactory.Saveˡ( _connection, obj2_TestTable2b );
				int rowcount3__TestTable2b = factory_TestTable2bFactory.GetRowCountˡ(_connection);
				Assert.AreEqual(rowcount3__TestTable2b, rowcount0__TestTable2b);
				AssertFlagsAfterDelete(obj2_TestTable2b);
				Assert.IsNull( obj3_TestTable2b ) ;

		}

		// seperate cs file per table
		protected void Populate_TestTable2b(TestTable2b obj, bool insert )
		{	
			if ( insert )
			{	
				obj.Person = "1"; 
				obj.MailPostCode = "2";
				obj.MailState = "3";
				obj.HomePostCode = "4";
				obj.HomeState = "5" ;
				obj.update_date = DateTime.Now;
			}
			else // update
			{
				obj.Person = "-1"; 
				obj.MailPostCode = "-2";
				obj.MailState = "-3";
				obj.HomePostCode = "-4";
				obj.HomeState = "-5";
				obj.update_date = DateTime.Now;
			}
		}
		
		// seperate file per table
		protected void OverridePopulate_TestTable2b( TestTable2b obj, bool insert ) 
		{
			if ( insert )
			{
				obj.Person = "Luka"; // pk
				obj.MailPostCode = "2565";
				obj.MailState = "NSW";
				obj.HomePostCode = "2565";
				obj.HomeState = "NSW";
				obj.update_date = DateTime.Now;
			}
			else // update
			{
				obj.Person = "Luka"; // pk
				obj.MailPostCode = "2565";
				obj.MailState = "NSW";
				obj.HomePostCode = "2565";
				obj.HomeState = "NSW";
				obj.update_date = DateTime.Now;
			}
		}



	}
} 