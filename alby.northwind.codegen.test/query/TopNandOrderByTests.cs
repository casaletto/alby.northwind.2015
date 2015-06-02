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

namespace alby.northwind.codegen.test.query
{
	[TestFixture]
	public class TopNandOrderByTests : NW.test.TransactionScopeTestBase
	{
		public TopNandOrderByTests()
		{
			_connectionString = Settings.ConnectionString();
		}
		
		[Test]
		public void CustomerOrderLoadAll()
		{
			ACR.CodeGenEtc.DebugSql = false ;

			// get top 2
			Console.WriteLine("--- LoadAll, top 2 only");
			var factory = new NW.query.CustomerOrderFactory();
			var rowset = factory.Load( _connection, 2 );
			Console.WriteLine("[{0}]", ACR.CodeGenEtc.Sql);
			Assert.AreEqual( 2, rowset.Count ) ;

			// get the lot
			Console.WriteLine("--- LoadAll");
			factory = new NW.query.CustomerOrderFactory();
			rowset = factory.Load(_connection);
			Console.WriteLine( "[{0}]", ACR.CodeGenEtc.Sql );
			Assert.Greater( rowset.Count, 2 ); // should get some rows back

			// get the lot, order by Address asc
			Console.WriteLine("--- LoadAll, order by Address");
	
			var orderBy = new List<ACR.CodeGenOrderBy>();
			orderBy.Add( new ACR.CodeGenOrderBy( NW.query.CustomerOrder.column٠Address ) ) ;
	
			rowset = factory.Load( _connection, null,  orderBy ) ;
			Console.WriteLine("[{0}]", ACR.CodeGenEtc.Sql);

				// dump first one
				Console.WriteLine("--- First one");
				NW.query.CustomerOrder coFirst0 = rowset[0];
				Console.WriteLine( coFirst0.CustomerID ) ; 
				Console.WriteLine( coFirst0.OrderID );
				Console.WriteLine( coFirst0.ContactName ) ; 
				Console.WriteLine( coFirst0.Address ) ; 

				// dump last one
				Console.WriteLine("--- Last one");
				NW.query.CustomerOrder coLast0 = rowset[rowset.Count - 1];
				Console.WriteLine( coLast0.CustomerID);
				Console.WriteLine( coLast0.OrderID);
				Console.WriteLine( coLast0.ContactName);
				Console.WriteLine( coLast0.Address); 

				Assert.AreNotEqual( coFirst0.Address, coLast0.Address ) ;

			// get the lot, order by Address desc
			Console.WriteLine("--- LoadAll, order by Address desc");
			
			orderBy = new List<ACR.CodeGenOrderBy>();
			orderBy.Add( new ACR.CodeGenOrderBy( NW.query.CustomerOrder.column٠Address, ACR.CodeGenSort.Desc ) );
			
			rowset = factory.Load( _connection, null, orderBy );
			Console.WriteLine("[{0}]", ACR.CodeGenEtc.Sql);

				// dump first one
				Console.WriteLine("--- First one");
				var coFirst1 = rowset[0];
				Console.WriteLine(coFirst1.CustomerID );
				Console.WriteLine(coFirst1.OrderID );
				Console.WriteLine(coFirst1.ContactName );
				Console.WriteLine(coFirst1.Address );

				// dump last one
				Console.WriteLine("--- Last one");
				var coLast1 = rowset[rowset.Count - 1];
				Console.WriteLine( coLast1.CustomerID );
				Console.WriteLine( coLast1.OrderID );
				Console.WriteLine( coLast1.ContactName );
				Console.WriteLine( coLast1.Address ); 

				Assert.AreEqual( coFirst1.Address, coLast0.Address ) ;
				Assert.AreEqual( coLast1.Address , coFirst0.Address ) ;

			// get 1, order by Address asc
			Console.WriteLine("--- Load 1, order by Address");
			
			orderBy = new List<ACR.CodeGenOrderBy>();
			orderBy.Add(new ACR.CodeGenOrderBy(NW.query.CustomerOrder.column٠Address));
			
			rowset = factory.Load( _connection, 1, orderBy);
			Console.WriteLine("[{0}]", ACR.CodeGenEtc.Sql);
			Assert.AreEqual( 1, rowset.Count);
			Assert.AreEqual( coFirst0.Address, rowset[0].Address ) ;

			// get 1, order by Address desc
			Console.WriteLine("--- Load 1, order by Address desc");
			
			orderBy = new List<ACR.CodeGenOrderBy>();
			orderBy.Add(new ACR.CodeGenOrderBy( NW.query.CustomerOrder.column٠Address, ACR.CodeGenSort.Desc ));
			
			rowset = factory.Load(_connection, 1, orderBy);
			Console.WriteLine("[{0}]", ACR.CodeGenEtc.Sql);
			Assert.AreEqual( 1, rowset.Count );
			Assert.AreEqual( coLast0.Address, rowset[0].Address);

			// get all, order by orderdate, customerid
			Console.WriteLine("--- Load all, order by OrderDate, CustomerId");
			var customersFactory = new NW.table.CustomersFactory() ;

			orderBy = new List<ACR.CodeGenOrderBy>();
			orderBy.Add( new ACR.CodeGenOrderBy( NW.query.CustomerOrder.column٠OrderDate ));
			orderBy.Add( new ACR.CodeGenOrderBy( "c", NW.query.CustomerOrder.column٠CustomerID ));

			rowset = factory.Load( _connection, null, orderBy ) ;
			Console.WriteLine("[{0}]", ACR.CodeGenEtc.Sql);
			Assert.Greater(rowset.Count, 2); // should get some rows back

				Console.WriteLine("--- First one");
				coFirst0 = rowset[0];
				Console.WriteLine( coFirst0.OrderDate );
				Console.WriteLine( coFirst0.CustomerID );

				Console.WriteLine("--- Last one");
				coLast0 = rowset[ rowset.Count - 1 ] ;
				Console.WriteLine( coLast0.OrderDate);
				Console.WriteLine( coLast0.CustomerID);

				Assert.Less( coFirst0.OrderDate.ToString() + "#" + coFirst0.CustomerID.ToString(), coLast0.OrderDate.ToString() + "#" + coLast0.CustomerID.ToString() ) ;

			// get all, order by 2 fields desc
			orderBy = new List<ACR.CodeGenOrderBy>();
			orderBy.Add( new ACR.CodeGenOrderBy( NW.query.CustomerOrder.column٠OrderDate, ACR.CodeGenSort.Desc  ));
			orderBy.Add( new ACR.CodeGenOrderBy( "c", NW.query.CustomerOrder.column٠CustomerID, ACR.CodeGenSort.Desc ));

			rowset = factory.Load( _connection, null, orderBy ) ;
			Console.WriteLine("[{0}]", ACR.CodeGenEtc.Sql);
			Assert.Greater(rowset.Count, 2); // should get some rows back

				Console.WriteLine("--- First one");
				coFirst1 = rowset[0];
				Console.WriteLine( coFirst1.OrderDate );
				Console.WriteLine( coFirst1.CustomerID );

				Console.WriteLine("--- Last one");
				coLast1 = rowset[ rowset.Count - 1 ] ;
				Console.WriteLine( coLast1.OrderDate);
				Console.WriteLine( coLast1.CustomerID);

				Assert.AreEqual( coFirst1.OrderDate, coLast0.OrderDate   ) ;
				Assert.AreEqual( coLast1.CustomerID, coFirst0.CustomerID ) ;

			// get 1, order by 2 fields
			Console.WriteLine("--- Load 1 , order by OrderDate, CustomerId");

			orderBy = new List<ACR.CodeGenOrderBy>();
			orderBy.Add( new ACR.CodeGenOrderBy( NW.query.CustomerOrder.column٠OrderDate ));
			orderBy.Add( new ACR.CodeGenOrderBy( "c", NW.query.CustomerOrder.column٠CustomerID ));

			rowset = factory.Load( _connection, 1, orderBy ) ;
			Console.WriteLine("[{0}]", ACR.CodeGenEtc.Sql);
			Assert.AreEqual( 1, rowset.Count ) ;

			Assert.AreEqual( coFirst0.OrderDate, rowset[0].OrderDate ) ;
			Assert.AreEqual( coFirst0.CustomerID, rowset[0].CustomerID ) ;

			// get 1, order by 2 fields desc
			Console.WriteLine("--- Load 1 , order by OrderDate desc, CustomerId desc");

			orderBy = new List<ACR.CodeGenOrderBy>();
			orderBy.Add( new ACR.CodeGenOrderBy( NW.query.CustomerOrder.column٠OrderDate, ACR.CodeGenSort.Desc ));
			orderBy.Add( new ACR.CodeGenOrderBy( "c", NW.query.CustomerOrder.column٠CustomerID, ACR.CodeGenSort.Desc ));

			rowset = factory.Load( _connection, 1, orderBy ) ;
			Console.WriteLine("[{0}]", ACR.CodeGenEtc.Sql);
			Assert.AreEqual( 1, rowset.Count ) ;

			Assert.AreEqual( coLast0.OrderDate,  rowset[0].OrderDate ) ;
			Assert.AreEqual( coLast0.CustomerID, rowset[0].CustomerID ) ;
		}

		[Test]
		public void CustomerOrderLoadByRegion()
		{
			ACR.CodeGenEtc.DebugSql = false ;

			// get top 2 - desc date
			Console.WriteLine("--- LoadAll, top 2 only, desc");
			var factory = new NW.query.CustomerOrderFactory();

			var orderBy = new List<ACR.CodeGenOrderBy>();
			orderBy.Add( new ACR.CodeGenOrderBy( NW.query.CustomerOrder.column٠OrderDate, ACR.CodeGenSort.Desc ));

			var rowset = factory.LoadByRegion( _connection, "Québec", 2, orderBy ) ; 
			Console.WriteLine("[{0}]", ACR.CodeGenEtc.Sql);
			Assert.AreEqual( 2, rowset.Count ) ;

			Assert.Greater( rowset[0].OrderDate, rowset[1].OrderDate ) ;

			// get top 2 - asc date
			Console.WriteLine("--- LoadAll, top 2 only, asc");
			factory = new NW.query.CustomerOrderFactory();

			orderBy = new List<ACR.CodeGenOrderBy>();
			orderBy.Add( new ACR.CodeGenOrderBy( NW.query.CustomerOrder.column٠OrderDate, ACR.CodeGenSort.Asc ));

			rowset = factory.LoadByRegion( _connection, "Québec", 2, orderBy ) ; 
			Console.WriteLine("[{0}]", ACR.CodeGenEtc.Sql);
			Assert.AreEqual( 2, rowset.Count ) ;

			Assert.Less( rowset[0].OrderDate, rowset[1].OrderDate ) ;
		}

		[Test]
		public void CustomerOrderLoadByTerritory_Complex()
		{ 
			ACR.CodeGenEtc.DebugSql = false ;

			// get top 2 - desc date
			Console.WriteLine("--- LoadAll, order date desc");
			var factory = new NW.query.CustomerOrderFactory();

			var orderBy = new List<ACR.CodeGenOrderBy>();
			orderBy.Add( new ACR.CodeGenOrderBy( NW.query.CustomerOrder.column٠OrderDate, ACR.CodeGenSort.Desc ));

			var rowset = factory.LoadByTerritory( _connection, "chicago", 1997, 1000, orderBy ) ; 
			Console.WriteLine("[{0}]", ACR.CodeGenEtc.Sql);

			var orderDate0 = rowset[0].OrderDate ;
			var orderDate1 = rowset[1].OrderDate ;

			Console.WriteLine( orderDate0 ) ;
			Console.WriteLine( orderDate1 ) ;

			Assert.GreaterOrEqual( orderDate0, orderDate1 ) ;
			Assert.AreEqual( 1997, orderDate0.Value.Year ) ; 
			Assert.AreEqual( 1997, orderDate1.Value.Year ) ; 
		}


	}
}
