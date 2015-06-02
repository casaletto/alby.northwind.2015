using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Transactions ;
using NUnit.Framework ;

using ACR = alby.codegen.runtime;
using t = alby.northwind.codegen.table  ;

namespace alby.northwind.codegen.test.table
{
	[TestFixture]
	public class TestNoTransactions
	{
		protected string _connectionString;

		public TestNoTransactions()
		{
			ACR.CodeGenEtc.DebugSql = true ;
			_connectionString = Settings.ConnectionString();
		}

		[Test]
		public void SaveWithNoTransaction()
		{
			t.TestTable6aFactory factory = new t.TestTable6aFactory();

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				factory.DeleteAllˡ(connection); // delete all rows				
				Assert.AreEqual(0, factory.GetRowCountˡ(connection)); // should have 0 rows

				t.TestTable6a table6a = new t.TestTable6a();
				table6a.ID = (int)factory.GetNextIdˡ(connection, t.TestTable6a.column٠ID, true);
				table6a.Name = "luka";
				table6a.Age = 8;
				table6a.update_date = DateTime.Now;

				t.TestTable6a table6a_reloaded = factory.Saveˡ( connection, table6a ); // insert 1 row
				Assert.AreEqual(1, factory.GetRowCountˡ(connection)); // should have 1 row

				Assert.IsNotNull( table6a_reloaded );
				Assert.AreEqual( table6a.Name, "luka" ) ;

			} // end conn

		} // end test



	}
}