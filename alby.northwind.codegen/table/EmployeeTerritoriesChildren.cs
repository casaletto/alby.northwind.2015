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

namespace alby.northwind.codegen.table
{
	public partial class EmployeeTerritories : acr.RowBase
	{
		public Employees parent٠Employees٠By٠EmployeeID( sds.SqlConnection connˡ, sds.SqlTransaction tranˡ = null )
		{
			EmployeesFactory factoryˡ = new EmployeesFactory() ; 
			return factoryˡ.LoadByPrimaryKeyˡ
			(
				connˡ,
				this.EmployeeID, 
				tranˡ
			) ;
		}

		public Territories parent٠Territories٠By٠TerritoryID( sds.SqlConnection connˡ, sds.SqlTransaction tranˡ = null )
		{
			TerritoriesFactory factoryˡ = new TerritoriesFactory() ; 
			return factoryˡ.LoadByPrimaryKeyˡ
			(
				connˡ,
				this.TerritoryID, 
				tranˡ
			) ;
		}

	}

}

