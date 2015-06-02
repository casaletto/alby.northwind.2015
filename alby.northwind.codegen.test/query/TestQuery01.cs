using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Transactions ;

using NUnit.Framework ;

using NW = alby.northwind.codegen  ;

namespace alby.northwind.codegen.test.query
{	
	[TestFixture]
	public class TestTestQuery01 : NW.test.TransactionScopeTestBase
	{
		public TestTestQuery01()
		{
			_connectionString = Settings.ConnectionString();
		}
		
		[Test]
		public void TestLoadByTheKey()
		{
			Console.WriteLine("LoadByTheKey");

			NW.query.TestQuery01Factory factory = new NW.query.TestQuery01Factory();
			
			int theKey = 1 ;
			List<NW.query.TestQuery01> rowset = factory.LoadByTheKey( _connection, theKey ) ;
			
			Console.WriteLine(rowset.Count);
			Assert.Greater(rowset.Count, 0); // should get some rows back

			// test fields of first row
			NW.query.TestQuery01 tq = rowset[0];

			Assert.AreEqual(tq.The_Key, theKey);
			Assert.AreEqual(tq.The_Value, "test value 1");
		}



	}
}
