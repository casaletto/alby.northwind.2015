using System;
using System.Collections.Generic;
using System.Text;
using System.Data ;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Transactions ;

using NUnit.Framework ;
using ACR = alby.codegen.runtime ;
using NW = alby.northwind.codegen  ;

namespace alby.northwind.codegen.test.table
{	
	[TestFixture]
	public class Customers : NW.test.TransactionScopeTestBase
	{
		public Customers()
		{
			_connectionString = Settings.ConnectionString();
		}

		[Test]
		public void TestLoadByWhere_Simple()
		{
			var factory = new NW.table.CustomersFactory() ;
			
			string where = "where t.address = 'Mataderos  2312' " ;
			var list = factory.LoadByWhereˡ( _connection, where ) ; 
			Assert.AreEqual( 1, list.Count ) ;
			Assert.AreEqual( list[0].CustomerID, "ANTON" ) ;
		}


		[Test]
		public void TestLoadByWhere_TopN()
		{
			var factory = new NW.table.CustomersFactory() ;
			
			string where = "where t.City = 'México D.F.'" ;
			var list = factory.LoadByWhereˡ( _connection, where ) ; 
			Assert.Greater( list.Count, 1 ) ;

			list = factory.LoadByWhereˡ( _connection, where, null, 1 ) ; 
			Assert.AreEqual( 1, list.Count ) ;
		}

		[Test]
		public void TestLoadByWhere_OrderBy1()
		{
			var factory = new NW.table.CustomersFactory() ;
			
			string where = "where t.City = 'México D.F.'" ;

			var orderBy = new List<ACR.CodeGenOrderBy>() ;
			orderBy.Add( new ACR.CodeGenOrderBy( NW.table.Customers.column٠CustomerID, ACR.CodeGenSort.Desc ) ) ;

			var list = factory.LoadByWhereˡ( _connection, where, null, null, orderBy ) ; 
			Assert.Greater( list.Count, 1 ) ;

			Assert.AreEqual( list[0].CustomerID, "TORTU" ) ;
		}

		[Test]
		public void TestLoadByWhere_OrderBy2()
		{
			var factory = new NW.table.CustomersFactory() ;
			
			string where = "where t.City = 'México D.F.' order by CUSTOMERID desc" ;

			var list = factory.LoadByWhereˡ( _connection, where ) ; 
			Assert.Greater( list.Count, 1 ) ;

			Assert.AreEqual( list[0].CustomerID, "TORTU" ) ;
		}

		[Test]
		public void TestLoadByWhere_Parameters()
		{
			var factory = new NW.table.CustomersFactory() ;
			
			string where = "where City = @city" ;
			string city = "México D.F." ;

			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add( new SqlParameter( "@city", city ) ) ;

			var list = factory.LoadByWhereˡ( _connection, where, parameters ) ; 
			Assert.Greater( list.Count, 1 ) ;
		}

		[Test]
		public void TestLoadByWhere_TheLot()
		{
			var factory = new NW.table.CustomersFactory() ;
			
			string where = "where City = @city" ;
			string city = "México D.F." ;

			var orderBy = new List<ACR.CodeGenOrderBy>() ;
			orderBy.Add( new ACR.CodeGenOrderBy( NW.table.Customers.column٠Address, ACR.CodeGenSort.Desc ) ) ;

			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add( new SqlParameter( "@city", city ) ) ;

			var list = factory.LoadByWhereˡ( _connection,  where, parameters, 1, orderBy ) ; 
			Assert.AreEqual( list.Count, 1 ) ;

			Assert.AreEqual( list[0].Address, "Sierras de Granada 9993" ) ;
		}

		[Test]
		public void TestLoadByWhere_ComplexWhere()
		{
			string where = @"
where not exists 
(
	select * 
	from orders
	where customerid = t.CustomerID 
)
or t.country = @country
" ;

			var factory = new NW.table.CustomersFactory() ;
			List<SqlParameter> parameters = new List<SqlParameter>();
			parameters.Add( new SqlParameter( "@country", "Mexico" ) ) ;

			var orderBy = new List<ACR.CodeGenOrderBy>() ;
			orderBy.Add( new ACR.CodeGenOrderBy( NW.table.Customers.column٠CompanyName, ACR.CodeGenSort.Desc ) ) ;

			var list = factory.LoadByWhereˡ( _connection, where, parameters, 1, orderBy ) ; 
			Assert.AreEqual( list.Count, 1 ) ;

			Assert.AreEqual( list[0].CompanyName, "Tortuga Restaurante" ) ;
		}

	}
} 