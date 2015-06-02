﻿
// This file was automatically generated by the code gen tool - do not modify.

using System ;
using scg = System.Collections.Generic ;
using sd = System.Data ;
using sds = System.Data.SqlClient ;
using sr = System.Reflection ;
using mst = Microsoft.SqlServer.Types ;
using mss = Microsoft.SqlServer.Server ;
using acr = alby.codegen.runtime ;

using nu = NUnit.Framework;
using t = alby.northwind.codegen.table ;

namespace alby.northwind.codegen.test
{
	public partial class CodeGenUnitTestClass : acr.CodeGenUnitTestBase
	{
		protected void Populate٠Orders( bool insert, t.Orders obj )
		{
			if ( insert )
			{
				obj.CustomerID = obj1٠Customers != null ? obj1٠Customers.CustomerID : obj0٠Customers.CustomerID ;
				obj.EmployeeID = obj1٠Employees != null ? obj1٠Employees.EmployeeID : obj0٠Employees.EmployeeID ;
				obj.OrderDate = new DateTime(1900,1,1) ;
				obj.RequiredDate = new DateTime(1900,1,1) ;
				obj.ShippedDate = new DateTime(1900,1,1) ;
				obj.ShipVia = obj1٠Shippers != null ? obj1٠Shippers.ShipperID : obj0٠Shippers.ShipperID ;
				obj.Freight = -1.0m ;
				obj.ShipName = "@" ;
				obj.ShipAddress = "@" ;
				obj.ShipCity = "@" ;
				obj.ShipRegion = "@" ;
				obj.ShipPostalCode = "@" ;
				obj.ShipCountry = "@" ;
			}
			else // update
			{
				obj.OrderDate = new DateTime(1901,12,31) ;
				obj.RequiredDate = new DateTime(1901,12,31) ;
				obj.ShippedDate = new DateTime(1901,12,31) ;
				obj.Freight = -2.0m ;
				obj.ShipName = "#" ;
				obj.ShipAddress = "#" ;
				obj.ShipCity = "#" ;
				obj.ShipRegion = "#" ;
				obj.ShipPostalCode = "#" ;
				obj.ShipCountry = "#" ;
			}
			 
		}
	}

}

