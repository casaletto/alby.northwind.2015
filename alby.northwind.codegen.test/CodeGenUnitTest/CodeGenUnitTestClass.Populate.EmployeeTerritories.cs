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
		protected void Populate٠EmployeeTerritories( bool insert, t.EmployeeTerritories obj )
		{
			if ( insert )
			{
				obj.EmployeeID = obj1٠Employees != null ? obj1٠Employees.EmployeeID : obj0٠Employees.EmployeeID ;
				obj.TerritoryID = obj1٠Territories != null ? obj1٠Territories.TerritoryID : obj0٠Territories.TerritoryID ;
			}
			else // update
			{
				obj.IsDirtyˡ = true ;
			}
			 
		}
	}

}

