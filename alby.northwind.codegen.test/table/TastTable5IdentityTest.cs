using System;
using System.Collections.Generic;
using System.IO ;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Transactions ;

using NUnit.Framework ;

using alby.codegen.runtime ;
using NW = alby.northwind.codegen  ;

namespace alby.northwind.codegen.test.table
{
	[TestFixture]
	public class TastTable5IdentityTest  : NW.test.TransactionScopeTestBase
	{
		public TastTable5IdentityTest()
		{
			_connectionString = Settings.ConnectionString();
		}

		[Test]
		public void InsertRow()
		{
			var factory = new NW.table.TestTable5Factory() ;
			
			var row = new NW.table.TestTable5() ;
			row.update_date = DateTime.Now ;
			row = factory.Saveˡ( _connection, row ) ; 
			Console.WriteLine( row.ID ) ;

			row = new NW.table.TestTable5() ;
			row.update_date = DateTime.Now ;
			row = factory.Saveˡ( _connection, row ) ; 
			Console.WriteLine( row.ID ) ;
		}

		[Test]
		public void SetIdentitySeedAndInsertRow()
		{
			var factory = new NW.table.TestTable5Factory() ;
			factory.SetIdentitySeedˡ( _connection, -1001 ) ;

			var row = new NW.table.TestTable5() ;
			row.update_date = DateTime.Now ;
			row = factory.Saveˡ( _connection, row ) ; 
			Console.WriteLine( row.ID ) ;
			Assert.AreEqual( -1000, row.ID ) ;

			row = new NW.table.TestTable5() ;
			row.update_date = DateTime.Now ;
			row = factory.Saveˡ( _connection, row ) ; 
			Console.WriteLine( row.ID ) ;
			Assert.AreEqual( -999, row.ID ) ;
		}

		[Test]
		public void InsertExplicitIdentity()
		{
			var factory = new NW.table.TestTable5Factory() ;

			var row = new NW.table.TestTable5() ;
			row.update_date = DateTime.Now ;
			row.ID = -900 ;

			factory.ManualIdentityInsertˡ( _connection, true ) ; 
			row = factory.Saveˡ( _connection, row, CodeGenSaveStrategy.ForceSaveTryUpdateFirstThenInsert, true ) ; 
			factory.ManualIdentityInsertˡ( _connection, false ) ; 

			Console.WriteLine( row.ID ) ;
			Assert.AreEqual( -900, row.ID ) ;
		}

		[Test]
		public void ForceInsertExplicitIdentity()
		{
			var factory = new NW.table.TestTable5Factory() ;

			var row = new NW.table.TestTable5() ;
			row.update_date = DateTime.Now ;
			row.ID = -900 ;

			factory.ManualIdentityInsertˡ( _connection, true ) ; 
			row = factory.Saveˡ( _connection, row, CodeGenSaveStrategy.ForceSaveTryUpdateFirstThenInsert, true ) ; 
			factory.ManualIdentityInsertˡ( _connection, false ) ; 

			Console.WriteLine( row.ID ) ;
			Assert.AreEqual( -900, row.ID ) ;
		}

	} // end class


}
