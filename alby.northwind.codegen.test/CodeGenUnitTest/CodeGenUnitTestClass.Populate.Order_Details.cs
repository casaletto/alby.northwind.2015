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
		protected void Populate٠Order_Details( bool insert, t.Order_Details obj )
		{
			if ( insert )
			{
				obj.OrderID = obj1٠Orders != null ? obj1٠Orders.OrderID : obj0٠Orders.OrderID ;
				obj.ProductID = obj1٠Products != null ? obj1٠Products.ProductID : obj0٠Products.ProductID ;
				obj.UnitPrice = -1.0m ;
				obj.Quantity = -100 ;
				obj.Discount = -1.0f ;
			}
			else // update
			{
				obj.UnitPrice = -2.0m ;
				obj.Quantity = -200 ;
				obj.Discount = -2.0f ;
			}
			 
		}
	}

}
