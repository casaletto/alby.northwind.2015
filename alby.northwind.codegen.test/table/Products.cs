using System;
using System.Collections.Generic;
using System.Text;
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
	public class TestProducts : NW.test.TransactionScopeTestBase
	{
		public TestProducts()
		{
			_connectionString = Settings.ConnectionString();
		}
		
		[Test]
		public void TestLoadAll()
		{
			Console.WriteLine("LoadAll");
			//_commitTransaction = true ;

			NW.table.ProductsFactory factory = new NW.table.ProductsFactory();
			List<NW.table.Products> rowset = factory.Loadˡ(_connection);
			
			Console.WriteLine( rowset.Count ) ;
			Assert.Greater( rowset.Count, 0 ) ; // should get some rows back
			
			// test fields of first row
			NW.table.Products p = rowset[0];

			Assert.AreEqual(p.ProductID , 1);
			Assert.AreEqual(p.ProductName , "Chai");
		}

		[Test]
		public void TestLoadByDiscontinued()
		{
			Console.WriteLine("LoadByDiscontinued");

			NW.table.ProductsFactory factory = new NW.table.ProductsFactory();
			
			bool discontinued = true ;
			List<NW.table.Products> rowset = factory.LoadByDiscontinued(_connection, discontinued);
			
			Console.WriteLine(rowset.Count);
			Assert.Greater(rowset.Count, 0); // should get some rows back

			// test fields of first row
			NW.table.Products p = rowset[0];
			Assert.AreEqual(p.Discontinued, true);			
		}

		[Test]
		public void TestLoadByProductId()
		{
			Console.WriteLine("LoadByProductId");

			NW.table.ProductsFactory factory = new NW.table.ProductsFactory();

			int productId = 17;
			List<NW.table.Products> rowset = factory.LoadByProductID(_connection, productId );

			Console.WriteLine(rowset.Count);
			Assert.Greater(rowset.Count, 0); // should get some rows back

			// test fields of first row
			NW.table.Products p = rowset[0];
			Assert.AreEqual(p.ProductID, productId );
	
			// check primary keys ok			
			int? pk = p.PrimaryKeyDictionaryˡ[NW.table.Products.column٠ProductID] as int?;
			Assert.AreEqual( pk, productId ) ;
			
			// chage value, check primary key again
			int productId2 = 1000;
			p.ProductID = productId2 ;
			pk = p.PrimaryKeyDictionaryˡ[NW.table.Products.column٠ProductID] as int?;
			Assert.AreEqual(pk, productId);			
		}

		[Test]
		public void TestLoadByPrimaryKey()
		{
			Console.WriteLine("LoadByPrimary");

			NW.table.ProductsFactory factory = new NW.table.ProductsFactory();

			int productId = 17;
			NW.table.Products pr = factory.LoadByPrimaryKeyˡ( _connection, productId ) ;
			Assert.IsTrue( pr != null ) ; // should get 1 back

			// test fields of first row
			Assert.AreEqual(pr.ProductID, productId);

			// check primary keys ok			
			int? pk = pr.PrimaryKeyDictionaryˡ[NW.table.Products.column٠ProductID] as int?;
			Assert.AreEqual(pk, productId);

			// chage value, check primary key again
			int productId2 = 1000;
			pr.ProductID = productId2;
			pk = pr.PrimaryKeyDictionaryˡ[NW.table.Products.column٠ProductID] as int?;
			Assert.AreEqual(pk, productId);

			// concurrency flags
			Assert.AreEqual(pr.ConcurrencyColumnˡ, "");
			Assert.IsNull(pr.ConcurrencyTimestampˡ ); 
		}

		[Test]
		public void TestNewProductsObject()
		{
			Console.WriteLine("NewProductsObject");
			
			NW.table.Products pr = new NW.table.Products() ;
			
			// check status flags
			Assert.AreEqual(pr.IsDeletedˡ,		false ) ;
			Assert.AreEqual(pr.IsDirtyˡ,			true  ) ;
			Assert.AreEqual(pr.IsFromDatabaseˡ,	false ) ;
			Assert.AreEqual(pr.MarkForDeletionˡ, false ) ;

			// concurrency flags
			Assert.AreEqual( pr.ConcurrencyColumnˡ, "" ) ;
			Assert.IsNull( pr.ConcurrencyTimestampˡ ) ; 

			// check any field
			Assert.AreEqual( pr.ProductID, null ) ;
			
			// check primary key 			
			int? pk = pr.PrimaryKeyDictionaryˡ[NW.table.Products.column٠ProductID] as int?;
			Assert.AreEqual( pk, null ) ;			
		}

		[Test]
		public void TestProducts_TopN_OrderBy()
		{
			var factory = new NW.table.ProductsFactory() ;

			// load all - ordering
			var rowset = factory.Loadˡ( _connection ) ;
			Assert.Greater( rowset.Count, 1 ); 

			rowset = factory.Loadˡ( _connection, 1 ) ;
			Assert.AreEqual( rowset.Count, 1 ); 

			var orderBy = new List<ACR.CodeGenOrderBy>() ;
			orderBy.Add( new ACR.CodeGenOrderBy( NW.table.Products.column٠ProductName, ACR.CodeGenSort.Asc ) ) ;
			 
			rowset = factory.Loadˡ( _connection, 1, orderBy ) ;
			Assert.AreEqual( rowset.Count, 1 ); 
			var productName0 = rowset[0].ProductName ;
			
			orderBy = new List<ACR.CodeGenOrderBy>() ;
			orderBy.Add( new ACR.CodeGenOrderBy( NW.table.Products.column٠ProductName, ACR.CodeGenSort.Desc ) ) ;
			 
			rowset = factory.Loadˡ( _connection, 1, orderBy ) ;
			Assert.AreEqual( rowset.Count, 1 ); 
			var productName1 = rowset[0].ProductName ;
			 
			Assert.Less( productName0, productName1 ) ;

			// load by custom method
			bool discontinued = false ;
			rowset = factory.LoadByDiscontinued( _connection, discontinued ) ; 
			Assert.Greater( rowset.Count, 1 ); 

			rowset = factory.Loadˡ( _connection, 1 ) ;
			Assert.AreEqual( rowset.Count, 1 ); 

			orderBy = new List<ACR.CodeGenOrderBy>() ;
			orderBy.Add( new ACR.CodeGenOrderBy( NW.table.Products.column٠ProductName, ACR.CodeGenSort.Asc ) ) ;
			 
			rowset = factory.LoadByDiscontinued( _connection, discontinued, 1, orderBy ) ;
			Assert.AreEqual( rowset.Count, 1 ); 
			productName0 = rowset[0].ProductName ;
			
			orderBy = new List<ACR.CodeGenOrderBy>() ;
			orderBy.Add( new ACR.CodeGenOrderBy( NW.table.Products.column٠ProductName, ACR.CodeGenSort.Desc ) ) ;
			 
			rowset = factory.LoadByDiscontinued( _connection, discontinued, 1, orderBy ) ;
			Assert.AreEqual( rowset.Count, 1 ); 
			productName1 = rowset[0].ProductName ;

			Assert.Less( productName0, productName1 ) ;

			// load by child method
			int productId = 1 ;
			var product = factory.LoadByPrimaryKeyˡ( _connection, productId ) ;
			Assert.IsNotNull( product ) ;
			
			var orders = product.children٠Order_Details٠By٠ProductID( _connection ) ;
			Assert.Greater( orders.Count, 1 ); 
			 
			orders = product.children٠Order_Details٠By٠ProductID( _connection, 1 ) ;
			Assert.AreEqual( orders.Count, 1 ); 

			orderBy = new List<ACR.CodeGenOrderBy>() ;
			orderBy.Add( new ACR.CodeGenOrderBy( NW.table.Order_Details.column٠Quantity, ACR.CodeGenSort.Asc ) ) ;

			orders = product.children٠Order_Details٠By٠ProductID( _connection, 1, orderBy ) ;
			Assert.AreEqual( orders.Count, 1 ); 
			var quantity0 = orders[0].Quantity ;

			orderBy = new List<ACR.CodeGenOrderBy>() ;
			orderBy.Add( new ACR.CodeGenOrderBy( NW.table.Order_Details.column٠Quantity, ACR.CodeGenSort.Desc ) ) ;

			orders = product.children٠Order_Details٠By٠ProductID( _connection, 1, orderBy ) ;
			Assert.AreEqual( orders.Count, 1 ); 
			var quantity1 = orders[0].Quantity ;

			Assert.Less( quantity0, quantity1 ) ;

		}

	}
} 