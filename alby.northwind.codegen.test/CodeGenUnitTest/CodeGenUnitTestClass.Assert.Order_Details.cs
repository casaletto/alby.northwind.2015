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
		protected void Assert٠Order_Details( bool insert, t.Order_Details newobj, t.Order_Details oldobj )
		{
			acr.CodeGenEtc.ConsoleMessage( ! this.QuietMode, "[20/24] Order_Details - assert" ) ;
		 
			nu.Assert.IsNotNull( newobj.OrderID, "Order_Details.OrderID" ) ;
			nu.Assert.IsNotNull( newobj.ProductID, "Order_Details.ProductID" ) ;
			nu.Assert.IsNotNull( newobj.UnitPrice, "Order_Details.UnitPrice" ) ;
			nu.Assert.IsNotNull( newobj.Quantity, "Order_Details.Quantity" ) ;
			nu.Assert.IsNotNull( newobj.Discount, "Order_Details.Discount" ) ;
		 
			base.AssertAreEqual( newobj.OrderID, oldobj.OrderID, "Order_Details.OrderID" ) ;
			base.AssertAreEqual( newobj.ProductID, oldobj.ProductID, "Order_Details.ProductID" ) ;
			base.AssertAreEqual( newobj.UnitPrice, oldobj.UnitPrice, "Order_Details.UnitPrice" ) ;
			base.AssertAreEqual( newobj.Quantity, oldobj.Quantity, "Order_Details.Quantity" ) ;
			base.AssertAreEqual( newobj.Discount, oldobj.Discount, "Order_Details.Discount" ) ;
		 
		}
	}

}
