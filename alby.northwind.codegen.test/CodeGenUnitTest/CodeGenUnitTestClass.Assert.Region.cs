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
		protected void Assert٠Region( bool insert, t.Region newobj, t.Region oldobj )
		{
			acr.CodeGenEtc.ConsoleMessage( ! this.QuietMode, "[5/24] Region - assert" ) ;
		 
			nu.Assert.IsNotNull( newobj.RegionID, "Region.RegionID" ) ;
			nu.Assert.IsNotNull( newobj.RegionDescription, "Region.RegionDescription" ) ;
		 
			base.AssertAreEqual( newobj.RegionID, oldobj.RegionID, "Region.RegionID" ) ;
			base.AssertAreEqual( newobj.RegionDescription, oldobj.RegionDescription, "Region.RegionDescription" ) ;
		 
		}
	}

}
