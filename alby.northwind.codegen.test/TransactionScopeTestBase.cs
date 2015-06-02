using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Transactions;

using NUnit.Framework;
using alby.codegen.runtime ;

namespace alby.northwind.codegen.test
{
	public class TransactionScopeTestBase
	{
		protected string			_connectionString;
		protected bool				_commitTransaction;

		protected TransactionScope	_transaction;
		protected SqlConnection		_connection;

		protected void CloseConnection()
		{
			// close connection
			if (_connection != null)
			{
				_connection.Close();
				_connection.Dispose();
			}

			Console.WriteLine("[{0} transaction [{1}] ]", _commitTransaction ? "Commit" : "Rollback", Transaction.Current.TransactionInformation.LocalIdentifier );

			// close transaction
			if (_transaction != null)
			{
				if (_commitTransaction)
					_transaction.Complete();

				_transaction.Dispose();
			}
		}

		protected void OpenConnection()
		{
			TransactionOptions t = new TransactionOptions();
			t.IsolationLevel = IsolationLevel.Serializable;

			// new transaction
			_transaction = new TransactionScope(TransactionScopeOption.RequiresNew, t);
			Console.WriteLine("[Begin transaction [{0}] ]", Transaction.Current.TransactionInformation.LocalIdentifier);

			// new connection
			_connection = new SqlConnection(_connectionString);
			_connection.Open();
		}

		//--------------------------------------------------------
		
		[TearDown]
		public virtual void TearDown()
		{
			CloseConnection() ;						
		}

		[SetUp]
		public virtual void Setup()
		{
			_commitTransaction = false ;

			CodeGenEtc.DebugSql = true ;
			
			OpenConnection() ;
		}

		//--------------------------------------------------------


	}
	
	
}
