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
		// Categories
		protected t.CategoriesFactory factory٠CategoriesFactory = new t.CategoriesFactory() ;
		 
		protected t.Categories obj0٠Categories = new t.Categories() ;
		protected t.Categories obj1٠Categories = null ;
		protected t.Categories obj2٠Categories = null ;
		protected t.Categories obj3٠Categories = null ;
		 
		protected int rowcount0٠Categories = 0 ;
		protected int rowcount1٠Categories = 0 ;
		protected int rowcount2٠Categories = 0 ;
		protected int rowcount3٠Categories = 0 ;
		 
		// CustomerCustomerDemo
		protected t.CustomerCustomerDemoFactory factory٠CustomerCustomerDemoFactory = new t.CustomerCustomerDemoFactory() ;
		 
		protected t.CustomerCustomerDemo obj0٠CustomerCustomerDemo = new t.CustomerCustomerDemo() ;
		protected t.CustomerCustomerDemo obj1٠CustomerCustomerDemo = null ;
		protected t.CustomerCustomerDemo obj2٠CustomerCustomerDemo = null ;
		protected t.CustomerCustomerDemo obj3٠CustomerCustomerDemo = null ;
		 
		protected int rowcount0٠CustomerCustomerDemo = 0 ;
		protected int rowcount1٠CustomerCustomerDemo = 0 ;
		protected int rowcount2٠CustomerCustomerDemo = 0 ;
		protected int rowcount3٠CustomerCustomerDemo = 0 ;
		 
		// CustomerDemographics
		protected t.CustomerDemographicsFactory factory٠CustomerDemographicsFactory = new t.CustomerDemographicsFactory() ;
		 
		protected t.CustomerDemographics obj0٠CustomerDemographics = new t.CustomerDemographics() ;
		protected t.CustomerDemographics obj1٠CustomerDemographics = null ;
		protected t.CustomerDemographics obj2٠CustomerDemographics = null ;
		protected t.CustomerDemographics obj3٠CustomerDemographics = null ;
		 
		protected int rowcount0٠CustomerDemographics = 0 ;
		protected int rowcount1٠CustomerDemographics = 0 ;
		protected int rowcount2٠CustomerDemographics = 0 ;
		protected int rowcount3٠CustomerDemographics = 0 ;
		 
		// Customers
		protected t.CustomersFactory factory٠CustomersFactory = new t.CustomersFactory() ;
		 
		protected t.Customers obj0٠Customers = new t.Customers() ;
		protected t.Customers obj1٠Customers = null ;
		protected t.Customers obj2٠Customers = null ;
		protected t.Customers obj3٠Customers = null ;
		 
		protected int rowcount0٠Customers = 0 ;
		protected int rowcount1٠Customers = 0 ;
		protected int rowcount2٠Customers = 0 ;
		protected int rowcount3٠Customers = 0 ;
		 
		// DatabaseVersion
		protected t.DatabaseVersionFactory factory٠DatabaseVersionFactory = new t.DatabaseVersionFactory() ;
		 
		protected t.DatabaseVersion obj0٠DatabaseVersion = new t.DatabaseVersion() ;
		protected t.DatabaseVersion obj1٠DatabaseVersion = null ;
		protected t.DatabaseVersion obj2٠DatabaseVersion = null ;
		protected t.DatabaseVersion obj3٠DatabaseVersion = null ;
		 
		protected int rowcount0٠DatabaseVersion = 0 ;
		protected int rowcount1٠DatabaseVersion = 0 ;
		protected int rowcount2٠DatabaseVersion = 0 ;
		protected int rowcount3٠DatabaseVersion = 0 ;
		 
		// Employees
		protected t.EmployeesFactory factory٠EmployeesFactory = new t.EmployeesFactory() ;
		 
		protected t.Employees obj0٠Employees = new t.Employees() ;
		protected t.Employees obj1٠Employees = null ;
		protected t.Employees obj2٠Employees = null ;
		protected t.Employees obj3٠Employees = null ;
		 
		protected int rowcount0٠Employees = 0 ;
		protected int rowcount1٠Employees = 0 ;
		protected int rowcount2٠Employees = 0 ;
		protected int rowcount3٠Employees = 0 ;
		 
		// EmployeeTerritories
		protected t.EmployeeTerritoriesFactory factory٠EmployeeTerritoriesFactory = new t.EmployeeTerritoriesFactory() ;
		 
		protected t.EmployeeTerritories obj0٠EmployeeTerritories = new t.EmployeeTerritories() ;
		protected t.EmployeeTerritories obj1٠EmployeeTerritories = null ;
		protected t.EmployeeTerritories obj2٠EmployeeTerritories = null ;
		protected t.EmployeeTerritories obj3٠EmployeeTerritories = null ;
		 
		protected int rowcount0٠EmployeeTerritories = 0 ;
		protected int rowcount1٠EmployeeTerritories = 0 ;
		protected int rowcount2٠EmployeeTerritories = 0 ;
		protected int rowcount3٠EmployeeTerritories = 0 ;
		 
		// Order_Details
		protected t.Order_DetailsFactory factory٠Order_DetailsFactory = new t.Order_DetailsFactory() ;
		 
		protected t.Order_Details obj0٠Order_Details = new t.Order_Details() ;
		protected t.Order_Details obj1٠Order_Details = null ;
		protected t.Order_Details obj2٠Order_Details = null ;
		protected t.Order_Details obj3٠Order_Details = null ;
		 
		protected int rowcount0٠Order_Details = 0 ;
		protected int rowcount1٠Order_Details = 0 ;
		protected int rowcount2٠Order_Details = 0 ;
		protected int rowcount3٠Order_Details = 0 ;
		 
		// Orders
		protected t.OrdersFactory factory٠OrdersFactory = new t.OrdersFactory() ;
		 
		protected t.Orders obj0٠Orders = new t.Orders() ;
		protected t.Orders obj1٠Orders = null ;
		protected t.Orders obj2٠Orders = null ;
		protected t.Orders obj3٠Orders = null ;
		 
		protected int rowcount0٠Orders = 0 ;
		protected int rowcount1٠Orders = 0 ;
		protected int rowcount2٠Orders = 0 ;
		protected int rowcount3٠Orders = 0 ;
		 
		// Products
		protected t.ProductsFactory factory٠ProductsFactory = new t.ProductsFactory() ;
		 
		protected t.Products obj0٠Products = new t.Products() ;
		protected t.Products obj1٠Products = null ;
		protected t.Products obj2٠Products = null ;
		protected t.Products obj3٠Products = null ;
		 
		protected int rowcount0٠Products = 0 ;
		protected int rowcount1٠Products = 0 ;
		protected int rowcount2٠Products = 0 ;
		protected int rowcount3٠Products = 0 ;
		 
		// Region
		protected t.RegionFactory factory٠RegionFactory = new t.RegionFactory() ;
		 
		protected t.Region obj0٠Region = new t.Region() ;
		protected t.Region obj1٠Region = null ;
		protected t.Region obj2٠Region = null ;
		protected t.Region obj3٠Region = null ;
		 
		protected int rowcount0٠Region = 0 ;
		protected int rowcount1٠Region = 0 ;
		protected int rowcount2٠Region = 0 ;
		protected int rowcount3٠Region = 0 ;
		 
		// Shippers
		protected t.ShippersFactory factory٠ShippersFactory = new t.ShippersFactory() ;
		 
		protected t.Shippers obj0٠Shippers = new t.Shippers() ;
		protected t.Shippers obj1٠Shippers = null ;
		protected t.Shippers obj2٠Shippers = null ;
		protected t.Shippers obj3٠Shippers = null ;
		 
		protected int rowcount0٠Shippers = 0 ;
		protected int rowcount1٠Shippers = 0 ;
		protected int rowcount2٠Shippers = 0 ;
		protected int rowcount3٠Shippers = 0 ;
		 
		// Suppliers
		protected t.SuppliersFactory factory٠SuppliersFactory = new t.SuppliersFactory() ;
		 
		protected t.Suppliers obj0٠Suppliers = new t.Suppliers() ;
		protected t.Suppliers obj1٠Suppliers = null ;
		protected t.Suppliers obj2٠Suppliers = null ;
		protected t.Suppliers obj3٠Suppliers = null ;
		 
		protected int rowcount0٠Suppliers = 0 ;
		protected int rowcount1٠Suppliers = 0 ;
		protected int rowcount2٠Suppliers = 0 ;
		protected int rowcount3٠Suppliers = 0 ;
		 
		// sysdiagrams
		protected t.sysdiagramsFactory factory٠sysdiagramsFactory = new t.sysdiagramsFactory() ;
		 
		protected t.sysdiagrams obj0٠sysdiagrams = new t.sysdiagrams() ;
		protected t.sysdiagrams obj1٠sysdiagrams = null ;
		protected t.sysdiagrams obj2٠sysdiagrams = null ;
		protected t.sysdiagrams obj3٠sysdiagrams = null ;
		 
		protected int rowcount0٠sysdiagrams = 0 ;
		protected int rowcount1٠sysdiagrams = 0 ;
		protected int rowcount2٠sysdiagrams = 0 ;
		protected int rowcount3٠sysdiagrams = 0 ;
		 
		// Territories
		protected t.TerritoriesFactory factory٠TerritoriesFactory = new t.TerritoriesFactory() ;
		 
		protected t.Territories obj0٠Territories = new t.Territories() ;
		protected t.Territories obj1٠Territories = null ;
		protected t.Territories obj2٠Territories = null ;
		protected t.Territories obj3٠Territories = null ;
		 
		protected int rowcount0٠Territories = 0 ;
		protected int rowcount1٠Territories = 0 ;
		protected int rowcount2٠Territories = 0 ;
		protected int rowcount3٠Territories = 0 ;
		 
		// TestTable1
		protected t.TestTable1Factory factory٠TestTable1Factory = new t.TestTable1Factory() ;
		 
		protected t.TestTable1 obj0٠TestTable1 = new t.TestTable1() ;
		protected t.TestTable1 obj1٠TestTable1 = null ;
		protected t.TestTable1 obj2٠TestTable1 = null ;
		protected t.TestTable1 obj3٠TestTable1 = null ;
		 
		protected int rowcount0٠TestTable1 = 0 ;
		protected int rowcount1٠TestTable1 = 0 ;
		protected int rowcount2٠TestTable1 = 0 ;
		protected int rowcount3٠TestTable1 = 0 ;
		 
		// TestTable2a
		protected t.TestTable2aFactory factory٠TestTable2aFactory = new t.TestTable2aFactory() ;
		 
		protected t.TestTable2a obj0٠TestTable2a = new t.TestTable2a() ;
		protected t.TestTable2a obj1٠TestTable2a = null ;
		protected t.TestTable2a obj2٠TestTable2a = null ;
		protected t.TestTable2a obj3٠TestTable2a = null ;
		 
		protected int rowcount0٠TestTable2a = 0 ;
		protected int rowcount1٠TestTable2a = 0 ;
		protected int rowcount2٠TestTable2a = 0 ;
		protected int rowcount3٠TestTable2a = 0 ;
		 
		// TestTable2b
		protected t.TestTable2bFactory factory٠TestTable2bFactory = new t.TestTable2bFactory() ;
		 
		protected t.TestTable2b obj0٠TestTable2b = new t.TestTable2b() ;
		protected t.TestTable2b obj1٠TestTable2b = null ;
		protected t.TestTable2b obj2٠TestTable2b = null ;
		protected t.TestTable2b obj3٠TestTable2b = null ;
		 
		protected int rowcount0٠TestTable2b = 0 ;
		protected int rowcount1٠TestTable2b = 0 ;
		protected int rowcount2٠TestTable2b = 0 ;
		protected int rowcount3٠TestTable2b = 0 ;
		 
		// TestTable3
		protected t.TestTable3Factory factory٠TestTable3Factory = new t.TestTable3Factory() ;
		 
		protected t.TestTable3 obj0٠TestTable3 = new t.TestTable3() ;
		protected t.TestTable3 obj1٠TestTable3 = null ;
		protected t.TestTable3 obj2٠TestTable3 = null ;
		protected t.TestTable3 obj3٠TestTable3 = null ;
		 
		protected int rowcount0٠TestTable3 = 0 ;
		protected int rowcount1٠TestTable3 = 0 ;
		protected int rowcount2٠TestTable3 = 0 ;
		protected int rowcount3٠TestTable3 = 0 ;
		 
		// TestTable4
		protected t.TestTable4Factory factory٠TestTable4Factory = new t.TestTable4Factory() ;
		 
		protected t.TestTable4 obj0٠TestTable4 = new t.TestTable4() ;
		protected t.TestTable4 obj1٠TestTable4 = null ;
		protected t.TestTable4 obj2٠TestTable4 = null ;
		protected t.TestTable4 obj3٠TestTable4 = null ;
		 
		protected int rowcount0٠TestTable4 = 0 ;
		protected int rowcount1٠TestTable4 = 0 ;
		protected int rowcount2٠TestTable4 = 0 ;
		protected int rowcount3٠TestTable4 = 0 ;
		 
		// TestTable5
		protected t.TestTable5Factory factory٠TestTable5Factory = new t.TestTable5Factory() ;
		 
		protected t.TestTable5 obj0٠TestTable5 = new t.TestTable5() ;
		protected t.TestTable5 obj1٠TestTable5 = null ;
		protected t.TestTable5 obj2٠TestTable5 = null ;
		protected t.TestTable5 obj3٠TestTable5 = null ;
		 
		protected int rowcount0٠TestTable5 = 0 ;
		protected int rowcount1٠TestTable5 = 0 ;
		protected int rowcount2٠TestTable5 = 0 ;
		protected int rowcount3٠TestTable5 = 0 ;
		 
		// TestTable6a
		protected t.TestTable6aFactory factory٠TestTable6aFactory = new t.TestTable6aFactory() ;
		 
		protected t.TestTable6a obj0٠TestTable6a = new t.TestTable6a() ;
		protected t.TestTable6a obj1٠TestTable6a = null ;
		protected t.TestTable6a obj2٠TestTable6a = null ;
		protected t.TestTable6a obj3٠TestTable6a = null ;
		 
		protected int rowcount0٠TestTable6a = 0 ;
		protected int rowcount1٠TestTable6a = 0 ;
		protected int rowcount2٠TestTable6a = 0 ;
		protected int rowcount3٠TestTable6a = 0 ;
		 
		// TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_
		protected t.TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_Factory factory٠TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_Factory = new t.TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_Factory() ;
		 
		protected t.TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_ obj0٠TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_ = new t.TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_() ;
		protected t.TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_ obj1٠TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_ = null ;
		protected t.TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_ obj2٠TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_ = null ;
		protected t.TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_ obj3٠TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_ = null ;
		 
		protected int rowcount0٠TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_ = 0 ;
		protected int rowcount1٠TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_ = 0 ;
		protected int rowcount2٠TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_ = 0 ;
		protected int rowcount3٠TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_ = 0 ;
		 
		// フル_ツ
		protected t.フル_ツFactory factory٠フル_ツFactory = new t.フル_ツFactory() ;
		 
		protected t.フル_ツ obj0٠フル_ツ = new t.フル_ツ() ;
		protected t.フル_ツ obj1٠フル_ツ = null ;
		protected t.フル_ツ obj2٠フル_ツ = null ;
		protected t.フル_ツ obj3٠フル_ツ = null ;
		 
		protected int rowcount0٠フル_ツ = 0 ;
		protected int rowcount1٠フル_ツ = 0 ;
		protected int rowcount2٠フル_ツ = 0 ;
		protected int rowcount3٠フル_ツ = 0 ;
		 
	}

}
