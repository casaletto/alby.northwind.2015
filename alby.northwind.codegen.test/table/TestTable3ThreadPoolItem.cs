using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Xml.Schema;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Transactions;

using ATP = alby.core.threadpool;
using CGR = alby.codegen.runtime;
using NW = alby.northwind.codegen;

//
// TestTable3 has a int primary key
//
namespace alby.northwind.codegen.test.table
{
	public class TestTable3ThreadPoolItem : ATP.MyThreadPoolItemBase
	{
		protected IsolationLevel _isolationLevel;
		protected string _connectionString;

		public TestTable3ThreadPoolItem(string connectionstring, IsolationLevel isolationLevel)
			: base()
		{
			_connectionString = connectionstring;
			_isolationLevel = isolationLevel;
		}

		public override void Run()
		{
			int tid   = Thread.CurrentThread.ManagedThreadId;

			try
			{
				//ATP.Helper.MtWriteLine("### TestTable3ThreadPoolItem [{0}] TID [{1}] started", this.ID, tid );
				
				if (ThreadPoolManager.IsShutdown)
					return;

				InsertRows( 1, _isolationLevel);
			}
			catch (CGR.CodeGenSaveException ex)
			{
				TestTable3Multithreaded.__OK = false;
				ATP.Helper.MtWriteLine("### TestTable3ThreadPoolItem [{0}] TID [{1}] EXCEPTION:\n{2} ", this.ID, tid, ex.ToString());
			}
			catch (Exception ex)
			{
				TestTable3Multithreaded.__OK = false;
				ATP.Helper.MtWriteLine("### TestTable3ThreadPoolItem [{0}] TID [{1}] EXCEPTION:\n{2} ", this.ID, tid, ex.ToString());
			}
			finally
			{
				//ATP.Helper.MtWriteLine("### TestTable3ThreadPoolItem [{0}] TID [{1}] finished: ok=[{2}], rowid inserted=[{3}], shutdown=[{4}]", 
				//	this.ID, tid, rowid >= 0, rowid, ThreadPoolManager.IsShutdown);
			}
		}

		public void  InsertRows(int rows, IsolationLevel isolationLevel)
		{
			NW.table.TestTable3Factory factory = new NW.table.TestTable3Factory();

			TransactionOptions transactionOptions = new TransactionOptions();
			transactionOptions.IsolationLevel = isolationLevel;

			using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.RequiresNew, transactionOptions))
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					connection.Open();

					for ( int i = 1; i <= rows ; i++ )
					{
						// insert a row 
						NW.table.TestTable3 obj = new NW.table.TestTable3();

						int? id = (int)factory.GetNextIdˡ(connection, NW.table.TestTable3.column٠ID, true);

						// folowing line causes sql error
						//
						// Violation of PRIMARY KEY constraint 'PK_TestTable3'. Cannot insert duplicate key in object 'dbo.TestTable3
						//
						//int? id = (int)factory.GetNextId(connection, NW.table.TestTable3.column٠ID, false); 

						obj.ID = id;
						obj.A = id;
						obj.update_date = DateTime.Now;

						NW.table.TestTable3 objSaved = factory.Saveˡ( connection, obj );

						if (objSaved.ID != obj.ID)
							throw new Exception("Got back the wrong record dude"); // sanity check

						//return obj.ID.Value;
					}

					transaction.Complete(); // commit
				}
			}
		}


	} // end class

} // end namespace
