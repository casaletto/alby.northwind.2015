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

namespace alby.northwind.codegen.view
{
	public partial class Current_Product_List : acr.RowBase
	{
		public const string column٠ProductID  = "ProductID" ;
		public const string column٠ProductName  = "ProductName" ;
		 
		public int? ProductID
		{
			get
			{
				return base.GetValueˡ<int?>( _dicˡ, column٠ProductID ) ; 
			}
			set
			{
				base.SetValueˡ<int?>( _dicˡ, column٠ProductID, value, ref _dirtyˡ ) ; 
			}
		}
		 
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
		 
		public Current_Product_List() : base()
		{
			base._dicˡ[ column٠ProductID ] = null ;
			base._dicˡ[ column٠ProductName ] = null ;
		 
		 
		}

	}

}
