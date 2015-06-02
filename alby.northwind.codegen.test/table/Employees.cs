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
	public class TestEmployees : NW.test.TransactionScopeTestBase
	{
		public TestEmployees()
		{
			_connectionString = Settings.ConnectionString();
		}

		[Test]
		public void TestEmployeeOrgChart()
		{
			NW.table.EmployeesFactory factory = new NW.table.EmployeesFactory();

			// andy the big chesse
			int? employeeId = 2;
			NW.table.Employees andy = factory.LoadByPrimaryKeyˡ(_connection, employeeId);
			Assert.IsNotNull(andy);
			Assert.AreEqual(andy.FirstName, "Andrew");

			DumpReportChain(andy, 0);			
		}

		protected void DumpReportChain( NW.table.Employees manager, int tab )
		{
			string tabPrefix  = new string( '\t', tab   ) ;

			List<NW.table.Employees> team = manager.children٠Employees٠By٠ReportsTo(_connection);
			Console.WriteLine("{0} {1} has {2} people reporting to him/her:", tabPrefix, manager.FirstName, team.Count);

			foreach (NW.table.Employees emp in team)
			{
				Console.WriteLine("{0} --> {1} [id {2}] reports to {3} [id {4}]", tabPrefix, emp.FirstName, emp.EmployeeID, manager.FirstName, manager.EmployeeID );
				DumpReportChain( emp, tab+2 ) ;
			}
		}

		[Test]
		public void TestEmployeesReportsTo()
		{
			NW.table.EmployeesFactory factory = new NW.table.EmployeesFactory();

			// robert - the pleb
			int? employeeId = 7;
			NW.table.Employees robert = factory.LoadByPrimaryKeyˡ(_connection, employeeId);
			Assert.IsNotNull( robert ) ;
			Assert.AreEqual( robert.FirstName, "Robert" ) ;
			Assert.AreEqual( robert.LastName, "King");
		
			// robert reports to Steven
			NW.table.Employees steven = robert.parent٠Employees٠By٠ReportsTo( _connection ) ;
			Assert.IsNotNull(steven);
			Assert.AreEqual(steven.FirstName, "Steven");
			Assert.AreEqual(steven.LastName, "Buchanan");
			
			// steven reports to Andrew
			NW.table.Employees andy = steven.parent٠Employees٠By٠ReportsTo(_connection);
			Assert.IsNotNull(andy);
			Assert.AreEqual(andy.FirstName, "Andrew");
			Assert.AreEqual(andy.LastName, "Fuller");

			// Andrew is the big cheese
			NW.table.Employees neville = andy.parent٠Employees٠By٠ReportsTo(_connection);
			Assert.IsNull(neville);
		}

		[Test]
		public void TestEmployeesTerritories()
		{
			NW.table.EmployeeTerritoriesFactory factory = new NW.table.EmployeeTerritoriesFactory();

			NW.table.EmployeeTerritories et = factory.LoadByPrimaryKeyˡ(_connection, 1, "06897" ) ;
			Assert.IsNotNull(et);

			NW.table.Employees nancy = et.parent٠Employees٠By٠EmployeeID(_connection);
			Assert.IsNotNull(nancy);
			Assert.AreEqual(nancy.FirstName, "Nancy");

			NW.table.Territories terr = et.parent٠Territories٠By٠TerritoryID( _connection ) ;
			Assert.IsNotNull(terr);
			Assert.AreEqual(terr.TerritoryDescription.Trim(), "Wilton");

			NW.table.Region region =  terr.parent٠Region٠By٠RegionID(_connection);
			Assert.IsNotNull(region);
			Assert.AreEqual(region.RegionDescription.Trim(), "Eastern");
		}


	}
} 