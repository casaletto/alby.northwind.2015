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
	public class TestCustomerOrder : NW.test.TransactionScopeTestBase
	{
		public TestCustomerOrder()
		{
			_connectionString = Settings.ConnectionString();
		}
		
		[Test]
		public void TestLoad()
		{
			Console.WriteLine("Load");
			//_commitTransaction = true ;

			NW.query.CustomerOrderFactory factory = new NW.query.CustomerOrderFactory();
			List<NW.query.CustomerOrder> rowset = factory.Load(_connection);
			
			Console.WriteLine( rowset.Count ) ;
			Assert.Greater( rowset.Count, 0 ) ; //should get some rows back
			
			// test fields of first row
			NW.query.CustomerOrder co = rowset[0];

			Assert.AreEqual(co.CustomerID, "ALFKI");
			Assert.AreEqual(co.CustomerID1, "ALFKI");
			Assert.AreEqual(co.CompanyName, "Alfreds Futterkiste" );
			Assert.AreEqual(co.Region, null ) ;
			Assert.AreEqual(co.OrderID, 10643);
			Assert.AreEqual(co.OrderDate, new DateTime( 1997,8,25) ) ;
			Assert.AreEqual(co.Freight, 29.46m) ;
		}

		[Test]
		public void TestLoadByCustomer()
		{
			Console.WriteLine("LoadByCustomer");

			NW.query.CustomerOrderFactory factory = new NW.query.CustomerOrderFactory();
			
			string customerId = "quick" ;
			List<NW.query.CustomerOrder> rowset = factory.LoadByCustomer( _connection, customerId ) ;
			
			Console.WriteLine(rowset.Count);
			Assert.Greater(rowset.Count, 0); // should get some rows back

			// test fields of first row
			NW.query.CustomerOrder co = rowset[0];

			Assert.AreEqual(co.CustomerID, "QUICK");
			Assert.AreEqual(co.CustomerID1, "QUICK");
			Assert.AreEqual(co.Address, "Taucherstraße 10" ) ;
		}

		[Test]
		public void TestLoadByRegion()
		{
			Console.WriteLine("LoadByRegion");

			NW.query.CustomerOrderFactory factory = new NW.query.CustomerOrderFactory();

			string region = "Québec";
			List<NW.query.CustomerOrder> rowset = factory.LoadByRegion(_connection, region );
			
			Console.WriteLine(rowset.Count);
			Assert.Greater(rowset.Count, 0); // should get some rows back

			// test fields of first row
			NW.query.CustomerOrder co = rowset[0];

			Assert.AreEqual(co.CustomerID, "MEREP");
			Assert.AreEqual(co.Region, region);
		}

		[Test]
		public void TestLoadByRegionNull()
		{
			Console.WriteLine("LoadByRegion");

			NW.query.CustomerOrderFactory factory = new NW.query.CustomerOrderFactory();

			string region = null ;
			List<NW.query.CustomerOrder> rowset = factory.LoadByRegion(_connection, region);

			Console.WriteLine(rowset.Count);
			Assert.Greater(rowset.Count, 0); // should get some rows back
		}

		[Test]
		public void TestLoadByCustomerIdEmployeeIdOrderDateFreight()
		{
			Console.WriteLine("LoadByCustomerIdEmployeeIdOrderDateFreight");

			NW.query.CustomerOrderFactory factory = new NW.query.CustomerOrderFactory();

			string		customerId	= "ANATR";
			int?		employeeId	= 3;
			DateTime?	orderDate	= new DateTime( 1997, 8, 8 );
			decimal?	freight		= 43.90m;

			List<NW.query.CustomerOrder> rowset = factory.LoadByCustomerIdEmployeeIdOrderDateFreight(
				_connection, customerId, employeeId, orderDate, freight ) ; 

			Console.WriteLine(rowset.Count);
			Assert.Greater(rowset.Count, 0); // should get some rows back

			// test fields of first row
			NW.query.CustomerOrder co = rowset[0];

			Assert.AreEqual(co.CustomerID, customerId );
			Assert.AreEqual(co.EmployeeID, employeeId );
			Assert.AreEqual(co.OrderDate, orderDate ) ;
			Assert.AreEqual(co.Freight, freight ) ;
		}

		[Test]
		public void TestLoadByShippedDateNull()
		{
			Console.WriteLine("LoadByShippedDateNull");

			NW.query.CustomerOrderFactory factory = new NW.query.CustomerOrderFactory();

			DateTime? shippedDate = null;
			
			List<NW.query.CustomerOrder> rowset = factory.LoadByShippedDate( _connection, shippedDate ) ;
			Console.WriteLine(rowset.Count);
			Assert.Greater(rowset.Count, 0); // should get some rows back

			// test fields of first row
			NW.query.CustomerOrder co = rowset[0];

			Assert.AreEqual(co.ShippedDate, null);
			Assert.AreEqual(co.ShippedDate, shippedDate);
		}

		[Test]
		public void TestLoadByShippedDateIsDirty()
		{
			Console.WriteLine("LoadByShippedDate");

			NW.query.CustomerOrderFactory factory = new NW.query.CustomerOrderFactory();

			DateTime? shippedDate = new DateTime( 1997, 10, 21 ) ;

			List<NW.query.CustomerOrder> rowset = factory.LoadByShippedDate(_connection, shippedDate);
			Console.WriteLine(rowset.Count);
			Assert.Greater(rowset.Count, 0); // should get some rows back

			// test fields of first row
			NW.query.CustomerOrder co = rowset[0];

			Assert.AreEqual(co.ShippedDate, shippedDate);
			
			// dirty testing
			Assert.AreEqual( co.IsDirtyˡ, false ) ; // straight up -should be clean here

			co.PostalCode = co.PostalCode ; 
			Assert.AreEqual( co.IsDirtyˡ, false ) ; // set to same value - should be clean here
			
			co.PostalCode = "2565" ;
			Assert.AreEqual(co.IsDirtyˡ, true); // set to different value - should be dirty here
			
			co.IsDirtyˡ = false ;
			Assert.AreEqual(co.IsDirtyˡ, false); // reset dirty - should be clean here

			co.IsDirtyˡ = true;
			Assert.AreEqual(co.IsDirtyˡ, true); // set dirty - should be dirty here

			co.IsDirtyˡ = false;
			Assert.AreEqual(co.IsDirtyˡ, false); // reset dirty - should be clean here
			
			co.PostalCode = null ;
			co.IsDirtyˡ = false ;
			Assert.AreEqual(co.IsDirtyˡ, false); // reset to null - should be clean here

			co.PostalCode = null;
			Assert.AreEqual(co.IsDirtyˡ, false); // set to same null value - should be clean here
		}


	}
}
