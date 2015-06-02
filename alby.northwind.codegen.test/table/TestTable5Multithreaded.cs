using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Transactions;
using NUnit.Framework;

using ATP = alby.core.threadpool;
using ACR = alby.codegen.runtime;
using NW = alby.northwind.codegen;

//
// TestTable5 has an identity primary key - works ok with below 3 isolation levels
//
namespace alby.northwind.codegen.test.table
{
	[TestFixture   ]
	public class TestTable5Multithreaded
	{
		protected string _connectionString;

		protected int _rowsToInsert			= 1000;
		protected int _maxParallelInserts	= 50;

		public static bool __OK ; 
		
		[Test]
		public void MultithreadedInsertSerializable()
		{
			InsertLotsOfRowInParallel(IsolationLevel.Serializable);
		}

		[Test]
		public void MultithreadedInsertReadCommitted()
		{
			InsertLotsOfRowInParallel(IsolationLevel.ReadCommitted);
		}

		[Test]
		public void MultithreadedInsertRepeatableRead()
		{
			InsertLotsOfRowInParallel(IsolationLevel.RepeatableRead);
		}

		public TestTable5Multithreaded()
		{
			_connectionString = Settings.ConnectionString();
		}

		[SetUp]
		public void Setup()
		{
			ACR.CodeGenEtc.DebugSql = false;
			DeleteAllRows();
		}

		[TearDown]
		public void TearDown()
		{
		}

		protected void DeleteAllRows()
		{
			NW.table.TestTable5Factory factory = new NW.table.TestTable5Factory();

			TransactionOptions transactionOptions = new TransactionOptions();
			transactionOptions.IsolationLevel = IsolationLevel.Serializable;

			using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.RequiresNew, transactionOptions))
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					connection.Open();
					factory.DeleteAllˡ(connection);
					transaction.Complete(); // commit

					ATP.Helper.MtWriteLine("Cleaned table" );
				}
			}
		}

		protected List<NW.table.TestTable5> GetAllRows(IsolationLevel isolationLevel)
		{
			NW.table.TestTable5Factory factory = new NW.table.TestTable5Factory();

			TransactionOptions transactionOptions = new TransactionOptions();
			transactionOptions.IsolationLevel = isolationLevel;

			using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.RequiresNew, transactionOptions))
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					connection.Open();
					List<NW.table.TestTable5> list = factory.Loadˡ( connection ) ;
					transaction.Complete(); // commit

					ATP.Helper.MtWriteLine("Read table, [{0}] rows", list.Count );
					return list ;
				}
			}
		}

		protected void InsertLotsOfRowInParallel(IsolationLevel isolationLevel)
		{
			__OK = true ;
			DateTime start = DateTime.Now ;

			using (ATP.MyThreadPoolManager tpm = new ATP.MyThreadPoolManager(_maxParallelInserts, _rowsToInsert))
			{
				// insert
				ATP.Helper.MtWriteLine("InsertLotsOfRowInParallel [{0}] - started inserting {1} rows using [{2}] threads.", isolationLevel, _rowsToInsert, _maxParallelInserts);

				for (int i = 1; i <= _rowsToInsert; i++)
					tpm.Queue( new TestTable5ThreadPoolItem("insert", _connectionString, isolationLevel, 0));

				tpm.WaitUntilAllStarted();
				tpm.WaitUntilAllFinished() ;
				tpm.CleanupFinishedThreadPoolItems() ;

				// update
				List<NW.table.TestTable5> list = GetAllRows(isolationLevel);
				ATP.Helper.MtWriteLine("InsertLotsOfRowInParallel [{0}] - started updating {1} rows using [{2}] threads.", isolationLevel, _rowsToInsert, _maxParallelInserts);

				foreach ( NW.table.TestTable5 row in list )
					tpm.Queue( new TestTable5ThreadPoolItem("update", _connectionString, isolationLevel, row.ID.Value ));

				tpm.WaitUntilAllStarted();
				tpm.WaitUntilAllFinished();
				tpm.CleanupFinishedThreadPoolItems();

				// delete
				list = GetAllRows(isolationLevel);
				ATP.Helper.MtWriteLine("InsertLotsOfRowInParallel [{0}] - started deleting {1} rows using [{2}] threads.", isolationLevel, _rowsToInsert, _maxParallelInserts);

				foreach (NW.table.TestTable5 row in list)
					tpm.Queue( new TestTable5ThreadPoolItem("delete", _connectionString, isolationLevel, row.ID.Value ));

				tpm.WaitUntilAllStarted();
				tpm.WaitUntilAllFinished();
				tpm.CleanupFinishedThreadPoolItems();

				// assert 0 rows 
				list = GetAllRows(isolationLevel);
				Assert.AreEqual( 0, list.Count ) ;

			}

			DateTime finish = DateTime.Now;
			TimeSpan ts = finish - start ;
			
			ATP.Helper.MtWriteLine("InsertLotsOfRowInParallel [{0}]- finished - time [{1}] sec", isolationLevel, ts.TotalSeconds );
			
			if ( ! __OK ) 
				Assert.Fail( "Test failed in one of the threads." ) ;
		}


	}
}