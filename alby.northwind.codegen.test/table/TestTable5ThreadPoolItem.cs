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
// TestTable5 has an identity primary key.
//
namespace alby.northwind.codegen.test.table
{
	public class TestTable5ThreadPoolItem : ATP.MyThreadPoolItemBase
	{
		protected IsolationLevel	_isolationLevel ;
		protected string			_connectionString ;
		protected string			_action ;
		protected int				_pk ;
		
		public TestTable5ThreadPoolItem( string action, string connectionstring, IsolationLevel isolationLevel, int pk ) : base()
		{
			_action			  = action ;
			_pk				  = pk ;
			_connectionString = connectionstring  ;
			_isolationLevel   = isolationLevel ;
		}		
		
		public override void Run() 
		{
			int  rowid  = -1 ;
			int  tid    = Thread.CurrentThread.ManagedThreadId ;

			try
			{
				//ATP.Helper.MtWriteLine("### TestTable5ThreadPoolItem [{0}] TID [{1}] started", this.ID, tid );

				if (ThreadPoolManager.IsShutdown)
					return ;
				
				rowid = ProcessOneRow( _isolationLevel, _action, _pk );
			}
			catch( CGR.CodeGenSaveException ex )
			{
				TestTable5Multithreaded.__OK = false ;
				ATP.Helper.MtWriteLine("### TestTable5ThreadPoolItem [{0}] TID [{1}] EXCEPTION:\n{2} ", this.ID, tid, ex.ToString() );
			}
			catch( Exception ex )
			{
				TestTable5Multithreaded.__OK = false ;
				ATP.Helper.MtWriteLine("### TestTable5ThreadPoolItem [{0}] TID [{1}] EXCEPTION:\n{2} ", this.ID, tid, ex.ToString());
			}
			finally
			{
				//ATP.Helper.MtWriteLine("### TestTable5ThreadPoolItem [{0}] TID [{1}] finished: ok=[{2}], rowid inserted=[{3}], shutdown=[{4}]", 
				//	this.ID, tid, rowid > 0, rowid, ThreadPoolManager.IsShutdown);
			}
		}

		protected int ProcessOneRow( IsolationLevel isolationLevel, string action, int pk )
		{
			NW.table.TestTable5Factory factory = new NW.table.TestTable5Factory();
			NW.table.TestTable5 obj;
			NW.table.TestTable5 objSaved;
			int	rowid = -1;

			TransactionOptions transactionOptions = new TransactionOptions();
			transactionOptions.IsolationLevel = isolationLevel;

			using ( TransactionScope transaction = new TransactionScope( TransactionScopeOption.RequiresNew, transactionOptions))
			{
				using ( SqlConnection connection = new SqlConnection(_connectionString) )
				{
					connection.Open();
					
					if ( action == "insert" )
					{
						obj = new NW.table.TestTable5();
						obj.f_nvarchar = DateTime.Now.ToString("HHmmss");
						obj.update_date = DateTime.Now;

						objSaved = factory.Saveˡ( connection, obj );
						rowid = objSaved.ID.Value ;
					}
					else
					if ( action == "update" )
					{
						obj = factory.LoadByPrimaryKeyˡ( connection, pk ) ;
						obj.f_nvarchar = DateTime.Now.ToString("yyyyMMdd");
						obj.update_date = DateTime.Now;

						objSaved = factory.Saveˡ( connection, obj );
						rowid = objSaved.ID.Value;
					}
					else
					if (action == "delete")
					{
						obj = factory.LoadByPrimaryKeyˡ(connection, pk);
						obj.MarkForDeletionˡ = true;

						factory.Saveˡ( connection, obj );
						rowid = obj.ID.Value;
					}

					transaction.Complete(); // commit
					return rowid ;
				}
			}
		}	
	
		
	} // end class

} // end namespace
