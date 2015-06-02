using System ;
using System.IO ;
using System.Text ;	
using System.Xml ;
using System.Xml.Xsl ;
using System.Xml.XPath ;
using System.Xml.Schema ;
using System.Collections ;
using System.Collections.Generic ;
using System.Reflection ;
using System.Threading ;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Transactions;

using ATP = alby.core.threadpool ;
using CGR = alby.codegen.runtime ;

using NW = alby.northwind.codegen;

//
// TestTable4 has a guid primary key
//
namespace alby.northwind.codegen.test.table
{
	public class TestTable4ThreadPoolItem : ATP.MyThreadPoolItemBase
	{
		protected IsolationLevel	_isolationLevel ;
		protected string			_connectionString ;
		
		public TestTable4ThreadPoolItem( string connectionstring, IsolationLevel isolationLevel ) : base()
		{
			_connectionString = connectionstring  ;
			_isolationLevel   = isolationLevel ;
		}		
		
		public override void Run() 
		{
			Guid rowid  = Guid.Empty ;
			int  tid    = Thread.CurrentThread.ManagedThreadId ;
			//bool ok     = false ;

			try
			{
				//ATP.Helper.MtWriteLine("### TestTable4ThreadPoolItem [{0}] TID [{1}] started", this.ID, tid );
				if (ThreadPoolManager.IsShutdown)
					return ;

				rowid = InsertOneRow( _isolationLevel );		
				//ok = true ;
			}
			catch( CGR.CodeGenSaveException ex )
			{
				TestTable4Multithreaded.__OK = false ;
				ATP.Helper.MtWriteLine("### TestTable4ThreadPoolItem [{0}] TID [{1}] EXCEPTION:\n{2} ", this.ID, tid, ex.ToString() );
			}
			catch( Exception ex )
			{
				TestTable4Multithreaded.__OK = false ;
				ATP.Helper.MtWriteLine("### TestTable4ThreadPoolItem [{0}] TID [{1}] EXCEPTION:\n{2} ", this.ID, tid, ex.ToString());
			}
			finally
			{
				//ATP.Helper.MtWriteLine("### TestTable4ThreadPoolItem [{0}] TID [{1}] finished: ok=[{2}], rowid inserted=[{3}], shutdown=[{4}]", 
				//	this.ID, tid, ok, rowid, ThreadPoolManager.IsShutdown);
			}
		}

		protected Guid InsertOneRow( IsolationLevel isolationLevel )
		{
			NW.table.TestTable4Factory factory = new NW.table.TestTable4Factory();

			TransactionOptions transactionOptions = new TransactionOptions();
			transactionOptions.IsolationLevel = isolationLevel;

			using ( TransactionScope transaction = new TransactionScope( TransactionScopeOption.RequiresNew, transactionOptions))
			{
				using ( SqlConnection connection = new SqlConnection(_connectionString) )
				{
					connection.Open();

					// insert 1 row 
					NW.table.TestTable4 obj = new NW.table.TestTable4();
					obj.ID = Guid.NewGuid() ;
					obj.f_guid = Guid.NewGuid() ;

					factory.Saveˡ( connection, obj );
					transaction.Complete(); // commit
					
					return obj.ID.Value ;
				}
			}
		}	
	
		
	} // end class

} // end namespace
