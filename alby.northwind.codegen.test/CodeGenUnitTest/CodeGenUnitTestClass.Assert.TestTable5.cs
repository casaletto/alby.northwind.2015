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
		protected void Assert٠TestTable5( bool insert, t.TestTable5 newobj, t.TestTable5 oldobj )
		{
			acr.CodeGenEtc.ConsoleMessage( ! this.QuietMode, "[13/24] TestTable5 - assert" ) ;
		 
			nu.Assert.IsNotNull( newobj.ID, "TestTable5.ID" ) ;
			nu.Assert.IsNotNull( newobj.f_int, "TestTable5.f_int" ) ;
			nu.Assert.IsNotNull( newobj.f_nvarchar, "TestTable5.f_nvarchar" ) ;
			nu.Assert.IsNotNull( newobj.update_date, "TestTable5.update_date" ) ;
		 
			base.AssertAreEqual( newobj.f_int, oldobj.f_int, "TestTable5.f_int" ) ;
			base.AssertAreEqual( newobj.f_nvarchar, oldobj.f_nvarchar, "TestTable5.f_nvarchar" ) ;
			base.AssertAreEqual( newobj.update_date, oldobj.update_date, "TestTable5.update_date" ) ;
		 
		}
	}

}

