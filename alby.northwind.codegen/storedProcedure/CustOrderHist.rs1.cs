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
	public partial class CustOrderHist٠rs1 : acr.RowBase
	{
		public const string column٠ProductName  = "ProductName" ;
		public const string column٠Total  = "Total" ;
		 
		public string ProductName
		{
			get
			{
				return base.GetValueˡ<string>( _dicˡ, column٠ProductName ) ; 
			}
			set
			{
				base.SetValueˡ<string>( _dicˡ, column٠ProductName, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public int? Total
		{
			get
			{
				return base.GetValueˡ<int?>( _dicˡ, column٠Total ) ; 
			}
			set
			{
				base.SetValueˡ<int?>( _dicˡ, column٠Total, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public CustOrderHist٠rs1() : base()
		{
			base._dicˡ[ column٠ProductName ] = null ;
			base._dicˡ[ column٠Total ] = null ;
		 
		}

	}

}
