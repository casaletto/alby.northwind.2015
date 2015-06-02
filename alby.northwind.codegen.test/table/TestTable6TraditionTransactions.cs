using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Transactions ;
using NUnit.Framework ;

using alby.codegen.runtime ; 
using t = alby.northwind.codegen.table  ;

namespace alby.northwind.codegen.test.table
{
	[TestFixture]
	public class TestTraditionalTransactions
	{
		protected string _connectionString;

		public TestTraditionalTransactions()
		{
			CodeGenEtc.DebugSql = true ;
			_connectionString = Settings.ConnectionString();
		}

		[Test]
		public void SaveWithCommit()
		{
			t.TestTable6aFactory factory = new t.TestTable6aFactory();
			
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				using (SqlTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.Serializable))
				{
					Console.WriteLine("Begin transaction");

					// get row count
					int count = factory.GetRowCountˡ(connection, null, transaction );
					Console.WriteLine("count = {0}", count);

					// delete all rows
					factory.DeleteAllˡ( connection, null, transaction ); 
					Console.WriteLine("deleted all rows");

					// get row count
					count = factory.GetRowCountˡ( connection, null, transaction );
					Console.WriteLine("count = {0}", count);
					Assert.AreEqual(0, count); // no rows expected

					// insert a row
					t.TestTable6a table6a = new t.TestTable6a();
					table6a.ID = (int)factory.GetNextIdˡ( connection, t.TestTable6a.column٠ID, true, transaction );
					table6a.Name = "luka";
					table6a.Age = 8;
					table6a.update_date = DateTime.Now;

					// save the row
					t.TestTable6a table6aReloaded = factory.Saveˡ( connection, table6a, CodeGenSaveStrategy.Normal, false, transaction ); // insert 1 row

					// get row count
					count = factory.GetRowCountˡ(connection, null, transaction );
					Console.WriteLine("count = {0}", count);
					Assert.AreEqual(1, count); // 1 row expected

					// commit transaction
					Console.WriteLine("Commit transaction");
					transaction.Commit();

				} // end tran

			} // end conn

			// see if TestTable6a has exactly 1 row
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				int count = factory.GetRowCountˡ(connection);
				Console.WriteLine("after: count = {0}", count);
				Assert.AreEqual(1, count); // 1 row expected
			}
			
		} // end test


		[Test]
		public void SaveWithRollback()
		{
			t.TestTable6aFactory factory = new t.TestTable6aFactory();

			// insert 1 row
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				using (SqlTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.Serializable))
				{
					Console.WriteLine("Begin transaction");

					// get row count
					int count = factory.GetRowCountˡ(connection, null, transaction );
					Console.WriteLine("count = {0}", count);

					// delete all rows
					factory.DeleteAllˡ(connection, null, transaction);
					Console.WriteLine("deleted all rows");

					// get row count
					count = factory.GetRowCountˡ(connection, null, transaction );
					Console.WriteLine("count = {0}", count);
					Assert.AreEqual(0, count); // no rows expected

					// insert a row
					t.TestTable6a table6a = new t.TestTable6a();
					table6a.ID = (int)factory.GetNextIdˡ(connection, t.TestTable6a.column٠ID, true, transaction);
					table6a.Name = "luka";
					table6a.Age = 8;
					table6a.update_date = DateTime.Now;

					// save the row
					t.TestTable6a table6aReloaded = factory.Saveˡ( connection, table6a, CodeGenSaveStrategy.Normal, false, transaction ); // insert 1 row

					// get row count
					count = factory.GetRowCountˡ(connection, null, transaction);
					Console.WriteLine("count = {0}", count);
					Assert.AreEqual(1, count); // 1 row expected

					// commit transaction
					Console.WriteLine("Commit transaction");
					transaction.Commit();

				} // end tran

			} // end conn

			// see if TestTable6a has exactly 1 row
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				int count = factory.GetRowCountˡ(connection);
				Console.WriteLine("after commit: count = {0}", count);
				Assert.AreEqual(1, count); // 1 row expected
			}
			
			// delete all rows with rollback
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();
				using (SqlTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.Serializable))
				{
					Console.WriteLine("Begin transaction");

					// delete all rows
					factory.DeleteAllˡ(connection, null, transaction);
					Console.WriteLine("deleted all rows");

					// get row count
					int count = factory.GetRowCountˡ(connection, null, transaction);
					Console.WriteLine("count = {0}", count);
					Assert.AreEqual(0, count); // 0 rows expected

					// commit transaction
					Console.WriteLine("Rollback transaction");
					transaction.Rollback();
				}
			}

			// see if TestTable6a still has exactly 1 row
			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				int count = factory.GetRowCountˡ(connection);
				Console.WriteLine("after rollback: count = {0}", count);
				Assert.AreEqual(1, count); // 1 row expected
			}
			
		}

		//[Test, ExpectedException( typeof(CodeGenSaveException), 
		//						  ExpectedMessage = "The transaction is either not associated with the current connection or has been completed." )
		//]
		[Test]
		public void SaveWithMismatchedConnections()
		{
			bool passed = false ;

			t.TestTable6aFactory factory6a = new t.TestTable6aFactory(); 
			t.TestTable5Factory  factory5  = new t.TestTable5Factory();	
		
			try
			{
				using (SqlConnection connection1 = new SqlConnection(_connectionString))
				{
					connection1.Open();
					using (SqlTransaction transaction1 = connection1.BeginTransaction(System.Data.IsolationLevel.Serializable))
					{
						Console.WriteLine("Begin transaction 1");

						using (SqlConnection connection2 = new SqlConnection(_connectionString))
						{
							connection2.Open();
							using (SqlTransaction transaction2 = connection2.BeginTransaction(System.Data.IsolationLevel.Serializable))
							{
								Console.WriteLine("Begin transaction 2");

								// add row to connection1 transaction1
								t.TestTable6a table6a = new t.TestTable6a();
								table6a.ID = (int) factory6a.GetNextIdˡ(connection1, t.TestTable6a.column٠ID, true, transaction1);
								table6a.Name = "yogi";
								table6a.Age = 100;
								table6a.update_date = DateTime.Now;
								factory6a.Saveˡ( connection1, table6a, CodeGenSaveStrategy.Normal, false, transaction1 ); 

								// add row to connection2 transaction2
								t.TestTable5 table5 = new t.TestTable5();
								table5.f_nvarchar = DateTime.Now.ToString("HHmmss");
								table5.update_date = DateTime.Now;
								factory5.Saveˡ( connection2, table5, CodeGenSaveStrategy.Normal, false, transaction2 );

								// add another row to connection2 transaction2
								table5 = new t.TestTable5();
								table5.f_nvarchar = DateTime.Now.ToString("HHmmss");
								table5.update_date = DateTime.Now;
								factory5.Saveˡ( connection2, table5, CodeGenSaveStrategy.Normal, false, transaction2 );

								// add row to connection1 transaction2 - should error here
								table5 = new t.TestTable5();
								table5.f_nvarchar = DateTime.Now.ToString("HHmmss");
								table5.update_date = DateTime.Now;
								factory5.Saveˡ( connection1, table5, CodeGenSaveStrategy.Normal, false, transaction2 );
							}
						}	
				
					}
				}	
			}
			catch ( CodeGenSaveException ex )
			{
				Console.WriteLine( ex.ToString() ) ;
				string msg = "The transaction is either not associated with the current connection or has been completed." ;
				Assert.IsTrue( ex.Message.Contains( msg ), "right exception, wrong message" ) ;
				passed = true ;
			}

			Assert.IsTrue( passed, "wheres the exception dude?" ) ;
					
		} // end test
			
	} // end class
}