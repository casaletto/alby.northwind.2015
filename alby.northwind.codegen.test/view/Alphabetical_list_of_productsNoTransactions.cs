using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Transactions;

using NUnit.Framework;

using NW = alby.northwind.codegen;

namespace alby.northwind.codegen.test.view
{
	[TestFixture]
	public class TestAlphabetical_list_of_productsNoTransactions 
	{
		string _connectionString ;

		public TestAlphabetical_list_of_productsNoTransactions()
		{
			_connectionString = Settings.ConnectionString() ; 
		}
		
		[Test]
		public void TestLoadAll()
		{
			Console.WriteLine("LoadAll");

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				NW.view.Alphabetical_list_of_productsFactory factory = new NW.view.Alphabetical_list_of_productsFactory();
				List<NW.view.Alphabetical_list_of_products> rowset = factory.Loadˡ(connection);

				Console.WriteLine(rowset.Count);
				Assert.Greater(rowset.Count, 0); // should get some rows back

				// test fields of first row
				NW.view.Alphabetical_list_of_products product = rowset[0];

				Assert.AreEqual(product.ProductID, 1);
				Assert.AreEqual(product.ProductName, "Chai");
				Assert.AreEqual(product.UnitPrice, 18.00m);
				Assert.AreEqual(product.Discontinued, false); 
			}
		}
		
		[Test]
		public void TestLoadByProductName()
		{
			Console.WriteLine("LoadByProductName");

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				NW.view.Alphabetical_list_of_productsFactory factory = new NW.view.Alphabetical_list_of_productsFactory();

				string productName = "NuNuCa Nuß-Nougat-Creme";
				List<NW.view.Alphabetical_list_of_products> rowset = factory.LoadByProductName( connection, productName ) ;

				Console.WriteLine(rowset.Count);
				Assert.Greater(rowset.Count, 0); // should get some rows back

				// test fields of first row
				NW.view.Alphabetical_list_of_products product = rowset[0];

				Assert.AreEqual(product.ProductID, 25);
				Assert.AreEqual(product.ProductName, productName);
				Assert.AreEqual(product.UnitPrice, 14.00m);
				Assert.AreEqual(product.Discontinued, false); 
			}
		}

		[Test]
		public void TestLoadByProductNameAndDiscontinued()
		{
			Console.WriteLine("LoadByProductNameAndDiscontinued");

			using (SqlConnection connection = new SqlConnection(_connectionString))
			{
				connection.Open();

				NW.view.Alphabetical_list_of_productsFactory factory = new NW.view.Alphabetical_list_of_productsFactory();

				string productName = "NuNuCa Nuß-Nougat-Creme";
				bool? discontinued = false ;
				
				List<NW.view.Alphabetical_list_of_products> rowset = factory.LoadByProductNameAndDiscontinued( connection, productName, discontinued ) ;
				Console.WriteLine(rowset.Count);
				Assert.Greater(rowset.Count, 0); // should get some rows back

				// test fields of first row
				NW.view.Alphabetical_list_of_products product = rowset[0];
				
				Assert.AreEqual(product.ProductID, 25) ; 
				Assert.AreEqual(product.ProductName, productName ) ;
				Assert.AreEqual(product.UnitPrice, 14.00m ) ;
				Assert.AreEqual(product.Discontinued, discontinued ) ; 
			}
		}		
	
	}
}
