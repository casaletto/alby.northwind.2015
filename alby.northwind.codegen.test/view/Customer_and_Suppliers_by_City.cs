using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Transactions;

using NUnit.Framework;
using ACR = alby.codegen.runtime ;
using NW = alby.northwind.codegen;

namespace alby.northwind.codegen.test.view
{
	[TestFixture]
	public class Customer_and_Suppliers_by_City : NW.test.TransactionScopeTestBase
	{

		public Customer_and_Suppliers_by_City()
		{
			_connectionString = Settings.ConnectionString() ; 
		}
		
		[Test]
		public void TestLoadAll()
		{
			Console.WriteLine("Load");

			NW.view.Customer_and_Suppliers_by_CityFactory factory = new NW.view.Customer_and_Suppliers_by_CityFactory();
			List<NW.view.Customer_and_Suppliers_by_City> rowset = factory.Loadˡ(_connection);

			Console.WriteLine(rowset.Count);
			Assert.Greater(rowset.Count, 0); // should get some rows back

			// test fields of first row
			NW.view.Customer_and_Suppliers_by_City cs = rowset[0];
			Assert.AreEqual(cs.City, "Aachen");
			Assert.AreEqual(cs.Relationship, "Customers") ;
			Assert.AreEqual(cs.IsDirtyˡ, false ) ;
		}

		[Test]
		public void TestCreateNewObject()
		{
			NW.view.Customer_and_Suppliers_by_City cs = new alby.northwind.codegen.view.Customer_and_Suppliers_by_City() ;
						
			// test IsDirty flag
			Assert.AreEqual(cs.IsDirtyˡ, true);
			
			// test IsFromDatabase flag
			Assert.AreEqual(cs.IsFromDatabaseˡ, false);		
		}	

		[Test]
		public void TestLoadByCity()
		{
			Console.WriteLine("LoadByCity");

			NW.view.Customer_and_Suppliers_by_CityFactory factory = new NW.view.Customer_and_Suppliers_by_CityFactory();

			string city = "Köln";
			List<NW.view.Customer_and_Suppliers_by_City> rowset = factory.LoadByCity(_connection, city);

			Console.WriteLine(rowset.Count);
			Assert.Greater(rowset.Count, 0); // should get some rows back

			// test fields of first row
			NW.view.Customer_and_Suppliers_by_City cs = rowset[0];
			Assert.AreEqual(cs.City, city);
			Assert.AreEqual(cs.Relationship, "Customers");
			Assert.AreEqual(cs.IsDirtyˡ, false);

			// test IsDirty flag
			Assert.AreEqual(cs.IsDirtyˡ, false);

			// test IsFromDatabase flag
			Assert.AreEqual(cs.IsFromDatabaseˡ, true);
		}

		[Test]
		public void TestLoadByCity_TopN_OrderBy()
		{
			var factory = new NW.view.Customer_and_Suppliers_by_CityFactory();

			var city = "London";
			var rowset = factory.LoadByCity( _connection, city ) ;
			Assert.Greater( rowset.Count, 1 ); // should get some rows back

			// top n
			rowset = factory.LoadByCity( _connection, city, 1 ) ;
			Assert.AreEqual( rowset.Count, 1 ); 

			// order by desc
			var orderBy = new List<ACR.CodeGenOrderBy>() ;
			orderBy.Add( new ACR.CodeGenOrderBy( NW.view.Customer_and_Suppliers_by_City.column٠ContactName, ACR.CodeGenSort.Desc ) ) ;
			rowset = factory.LoadByCity( _connection, city, 1, orderBy ) ;
			Assert.AreEqual( rowset.Count, 1 ); 
			Assert.AreEqual( "Victoria Ashworth", rowset[0].ContactName ); 

			// order by asc
			orderBy = new List<ACR.CodeGenOrderBy>() ;
			orderBy.Add( new ACR.CodeGenOrderBy( NW.view.Customer_and_Suppliers_by_City.column٠ContactName ) ) ;
			rowset = factory.LoadByCity( _connection, city, 1, orderBy ) ;
			Assert.AreEqual( rowset.Count, 1 ); 
			Assert.AreEqual( "Ann Devon", rowset[0].ContactName ); 
		}	
	
	}
}
