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
using ns = alby.northwind.codegen;

namespace alby.northwind.codegen.storedProcedure
{
	public partial class MyVarmaxUnicodeTableType3٠tt : acr.RowBase
	{
		public const string column٠MyChar  = "MyChar" ;
		 
		public string MyChar
		{
			get
			{
				return base.GetValueˡ<string>( _dicˡ, column٠MyChar ) ; 
			}
			set
			{
				base.SetValueˡ<string>( _dicˡ, column٠MyChar, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public MyVarmaxUnicodeTableType3٠tt() : base()
		{
			base._dicˡ[ column٠MyChar ] = null ;
		 
		}

	}

}
