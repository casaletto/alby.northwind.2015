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
		protected void Populate٠TestTable3( bool insert, t.TestTable3 obj )
		{
			if ( insert )
			{
				obj.ID = toint( factory٠TestTable3Factory.GetNextIdˡ( _connection, t.TestTable3.column٠ID, true ).ToString() ) ;
				obj.A = -100 ;
				obj.B = -100 ;
				obj.C = -100 ;
				obj.update_date = new DateTime(1900,1,1) ;
			}
			else // update
			{
				obj.A = -200 ;
				obj.B = -200 ;
				obj.C = -200 ;
				obj.update_date = new DateTime(1901,12,31) ;
			}
			 
		}
	}

}

