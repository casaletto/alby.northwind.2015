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
		protected void Populate٠sysdiagrams( bool insert, t.sysdiagrams obj )
		{
			if ( insert )
			{
				obj.name = "@" ;
				obj.principal_id = -100 ;
				obj.version = -100 ;
				obj.definition = new byte[] { 0x01 } ;
			}
			else // update
			{
				obj.name = "#" ;
				obj.principal_id = -200 ;
				obj.version = -200 ;
				obj.definition = new byte[] { 0x02 } ;
			}
			 
		}
	}

}

