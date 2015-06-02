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
using ACR = alby.codegen.runtime ;
using NW = alby.northwind.codegen;

//
// TestTable3 has a int primary key - needs more locking here
//
namespace alby.northwind.codegen.test.table
{
	[TestFixture  ]
	public class TestTable3Multithreaded
	{
		protected string _connectionString;

		protected int _rowsToInsert = 50;
		protected int _maxParallelInserts = 20 ;

		public static bool __OK;

		[Test]
		public void MultithreadedInsertSerializable()
		{
			InsertLotsOfRowsInParallelTransactions(IsolationLevel.Serializable);
		}

		[Test]
		public void MultithreadedInsertReadCommitted()
		{
			InsertLotsOfRowsInParallelTransactions(IsolationLevel.ReadCommitted);
		}

		[Test]
		public void MultithreadedInsertRepeatableRead()
		{
			InsertLotsOfRowsInParallelTransactions(IsolationLevel.RepeatableRead);
		}

		[Test]
		public void SinglethreadedInsertSerializable()
		{
			InsertLotsOfRowsInOneTransaction(IsolationLevel.Serializable);
		}

		[Test]
		public void SinglethreadedInsertReadCommitted()
		{
			InsertLotsOfRowsInOneTransaction(IsolationLevel.ReadCommitted);
		}

		[Test]
		public void SinglethreadedInsertRepeatableRead()
		{
			InsertLotsOfRowsInOneTransaction(IsolationLevel.RepeatableRead);
		}

		public TestTable3Multithreaded()
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
			NW.table.TestTable3Factory factory = new NW.table.TestTable3Factory();

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

		protected void InsertLotsOfRowsInParallelTransactions(IsolationLevel isolationLevel)
		{
			__OK = true;
			DateTime start = DateTime.Now;
			ATP.Helper.MtWriteLine("InsertLotsOfRowInParallel [{0}] - started, inserting {1} rows using [{2}] threads.", isolationLevel, _rowsToInsert, _maxParallelInserts);

			using (ATP.MyThreadPoolManager tpm = new ATP.MyThreadPoolManager(_maxParallelInserts, _rowsToInsert))
			{
				for (int i = 1; i <= _rowsToInsert; i++)
					tpm.Queue(new TestTable3ThreadPoolItem(_connectionString, isolationLevel));

				tpm.WaitUntilAllStarted();
			}

			DateTime finish = DateTime.Now;
			TimeSpan ts = finish - start;

			ATP.Helper.MtWriteLine("InsertLotsOfRowInParallel [{0}]- finished - time [{1}] sec", isolationLevel, ts.TotalSeconds);

			if (!__OK)
				Assert.Fail("Test failed in one of the threads.");
		}


		protected void InsertLotsOfRowsInOneTransaction(IsolationLevel isolationLevel)
		{
			__OK = true;
			DateTime start = DateTime.Now;
			ATP.Helper.MtWriteLine("InsertLotsOfRowsInOneTransaction [{0}] - started, inserting {1} rows using [{2}] threads.", isolationLevel, _rowsToInsert, 1);
			
			TestTable3ThreadPoolItem tpi = new TestTable3ThreadPoolItem( _connectionString, isolationLevel ) ;
			tpi.InsertRows( _rowsToInsert, isolationLevel ) ;

			DateTime finish = DateTime.Now;
			TimeSpan ts = finish - start;

			ATP.Helper.MtWriteLine("InsertLotsOfRowsInOneTransaction [{0}]- finished - time [{1}] sec", isolationLevel, ts.TotalSeconds);

			if (!__OK)
				Assert.Fail("Test failed in one of the threads.");
		}
		

	}
}