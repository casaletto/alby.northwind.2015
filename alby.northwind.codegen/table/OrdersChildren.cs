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
	public partial class Orders : acr.RowBase
	{
		public Customers parent٠Customers٠By٠CustomerID( sds.SqlConnection connˡ, sds.SqlTransaction tranˡ = null )
		{
			CustomersFactory factoryˡ = new CustomersFactory() ; 
			return factoryˡ.LoadByPrimaryKeyˡ
			(
				connˡ,
				this.CustomerID, 
				tranˡ
			) ;
		}

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

		public Shippers parent٠Shippers٠By٠ShipVia( sds.SqlConnection connˡ, sds.SqlTransaction tranˡ = null )
		{
			ShippersFactory factoryˡ = new ShippersFactory() ; 
			return factoryˡ.LoadByPrimaryKeyˡ
			(
				connˡ,
				this.ShipVia, 
				tranˡ
			) ;
		}

		public scg.List<Order_Details> children٠Order_Details٠By٠OrderID( sds.SqlConnection connˡ, int? topNˡ = null, scg.List<acr.CodeGenOrderBy> orderByˡ = null, sds.SqlTransaction tranˡ = null )
		{
			Order_DetailsFactory factoryˡ = new Order_DetailsFactory() ; 
			return factoryˡ.LoadByForeignKey٠From٠Orders٠By٠OrderID
			(
				connˡ,
				this.OrderID, 
				topNˡ,
				orderByˡ,
				tranˡ
			) ;
		}

		public scg.List<TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_> children٠TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_٠By٠OrderID( sds.SqlConnection connˡ, int? topNˡ = null, scg.List<acr.CodeGenOrderBy> orderByˡ = null, sds.SqlTransaction tranˡ = null )
		{
			TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_Factory factoryˡ = new TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_Factory() ; 
			return factoryˡ.LoadByForeignKey٠From٠Orders٠By٠OrderID
			(
				connˡ,
				this.OrderID, 
				topNˡ,
				orderByˡ,
				tranˡ
			) ;
		}

	}

}
