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
		protected void Assert٠DatabaseVersion( bool insert, t.DatabaseVersion newobj, t.DatabaseVersion oldobj )
		{
			acr.CodeGenEtc.ConsoleMessage( ! this.QuietMode, "[4/24] DatabaseVersion - assert" ) ;
		 
			nu.Assert.IsNotNull( newobj.DatabaseVersionID, "DatabaseVersion.DatabaseVersionID" ) ;
			nu.Assert.IsNotNull( newobj.VersionText, "DatabaseVersion.VersionText" ) ;
			nu.Assert.IsNotNull( newobj.VersionFile, "DatabaseVersion.VersionFile" ) ;
			nu.Assert.IsNotNull( newobj.UpdateUserName, "DatabaseVersion.UpdateUserName" ) ;
			nu.Assert.IsNotNull( newobj.UpdateDateTime, "DatabaseVersion.UpdateDateTime" ) ;
			nu.Assert.IsNotNull( newobj.UpdateTimetamp, "DatabaseVersion.UpdateTimetamp" ) ;
		 
			base.AssertAreEqual( newobj.DatabaseVersionID, oldobj.DatabaseVersionID, "DatabaseVersion.DatabaseVersionID" ) ;
			base.AssertAreEqual( newobj.VersionText, oldobj.VersionText, "DatabaseVersion.VersionText" ) ;
			base.AssertAreEqual( newobj.VersionFile, oldobj.VersionFile, "DatabaseVersion.VersionFile" ) ;
			base.AssertAreEqual( newobj.UpdateUserName, oldobj.UpdateUserName, "DatabaseVersion.UpdateUserName" ) ;
			base.AssertAreEqual( newobj.UpdateDateTime, oldobj.UpdateDateTime, "DatabaseVersion.UpdateDateTime" ) ;
		 
		}
	}

}
