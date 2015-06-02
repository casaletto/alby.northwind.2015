using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Transactions ;

using NUnit.Framework ;

using NW = alby.northwind.codegen  ;

namespace alby.northwind.codegen.test.table
{	
	[TestFixture]
	public class Orders : NW.test.TransactionScopeTestBase
	{
		public Orders()
		{
			_connectionString = Settings.ConnectionString();
		}

		[Test]
		public void TestCustomerOrders()
		{
			NW.table.OrdersFactory factory = new NW.table.OrdersFactory();

			int? orderId = 10289 ;
			string customerId = "BSBEV";
			
			// get an order
			NW.table.Orders order = factory.LoadByPrimaryKeyˡ(_connection, orderId);
			Assert.IsNotNull(order);
			Assert.AreEqual(order.CustomerID, customerId ) ; 

			// get its customer
			NW.table.Customers customer = order.parent٠Customers٠By٠CustomerID(_connection);
			Assert.IsNotNull(customer);
			Assert.AreEqual(customer.CustomerID, customerId); 
			
			// get all this customer's orders and the details, and back track up to customer
			List<NW.table.Orders> orderList = customer.children٠Orders٠By٠CustomerID(_connection);
			Assert.AreEqual(orderList.Count, 10); 
			
			foreach( NW.table.Orders anOrder in orderList )
			{
				Assert.AreEqual(anOrder.CustomerID, customerId); 
				
				List<NW.table.Order_Details> orderDetailsList = anOrder.children٠Order_Details٠By٠OrderID( _connection ) ;
				Assert.Greater( orderDetailsList.Count, 0 ) ;  
				
				foreach( NW.table.Order_Details orderDetail in orderDetailsList )
					Assert.AreEqual(orderDetail.parent٠Orders٠By٠OrderID(_connection).parent٠Customers٠By٠CustomerID(_connection).CustomerID, customerId);	
			}			
		}
		
		[Test]
		public void TestInsertAndUpdate()
		{
			NW.table.OrdersFactory factory = new NW.table.OrdersFactory();

			int count1 = factory.GetRowCountˡ( _connection ) ;

			NW.table.Orders order = new NW.table.Orders() ;
			
			NW.table.Orders order2 = factory.Saveˡ( _connection, order ) ;
			Assert.IsNotNull(order2);
			Assert.AreNotEqual( order, order2 );

			int count2 = factory.GetRowCountˡ(_connection);
			Assert.AreEqual( count2, count1 + 1 ) ;

			// dump object
			foreach (string key in order2.Dictionaryˡ.Keys)
				Console.WriteLine("order2 [{0}] [{1}]", key, order2.Dictionaryˡ[key]);

			// test normal update
			order2.OrderDate = DateTime.Now ;
			NW.table.Orders order3 = factory.Saveˡ( _connection, order2 );
			Assert.IsNotNull(order3);
			Assert.AreNotEqual(order2, order3);
			Assert.AreEqual(order2.OrderID, order3.OrderID);

			int count3 = factory.GetRowCountˡ(_connection);
			Assert.AreEqual(count2, count3);

			// dump object
			foreach (string key in order3.Dictionaryˡ.Keys)
				Console.WriteLine("order3 [{0}] [{1}]", key, order3.Dictionaryˡ[key]);
			
			// update primary key
			// no way - cant update identity field !
		}




	}
} 