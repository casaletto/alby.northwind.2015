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
	public partial class MyBigIntTableType٠tt : acr.RowBase
	{
		public const string column٠ID  = "ID" ;
		 
		public long? ID
		{
			get
			{
				return base.GetValueˡ<long?>( _dicˡ, column٠ID ) ; 
			}
			set
			{
				base.SetValueˡ<long?>( _dicˡ, column٠ID, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public MyBigIntTableType٠tt() : base()
		{
			base._dicˡ[ column٠ID ] = null ;
		 
		}

	}

}
