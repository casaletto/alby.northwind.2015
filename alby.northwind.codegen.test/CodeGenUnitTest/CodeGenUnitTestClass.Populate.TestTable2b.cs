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
		protected void Populate٠TestTable2b( bool insert, t.TestTable2b obj )
		{
			if ( insert )
			{
				obj.Person = "@" ;
				obj.MailPostCode = obj1٠TestTable2a != null ? obj1٠TestTable2a.PostCode : obj0٠TestTable2a.PostCode ;
				obj.MailState = obj1٠TestTable2a != null ? obj1٠TestTable2a.State : obj0٠TestTable2a.State ;
				obj.HomePostCode = obj1٠TestTable2a != null ? obj1٠TestTable2a.PostCode : obj0٠TestTable2a.PostCode ;
				obj.HomeState = obj1٠TestTable2a != null ? obj1٠TestTable2a.State : obj0٠TestTable2a.State ;
				obj.update_date = new DateTime(1900,1,1) ;
			}
			else // update
			{
				obj.update_date = new DateTime(1901,12,31) ;
			}
			 
		}
	}

}

