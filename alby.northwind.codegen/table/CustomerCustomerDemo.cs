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

namespace alby.northwind.codegen.table
{
	public partial class CustomerCustomerDemo : acr.RowBase
	{
		public const string column٠CustomerID  = "CustomerID" ;
		public const string column٠CustomerTypeID  = "CustomerTypeID" ;
		 
		public string CustomerID
		{
			get
			{
				return base.GetValueˡ<string>( _dicˡ, column٠CustomerID ) ; 
			}
			set
			{
				base.SetValueˡ<string>( _dicˡ, column٠CustomerID, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public string CustomerTypeID
		{
			get
			{
				return base.GetValueˡ<string>( _dicˡ, column٠CustomerTypeID ) ; 
			}
			set
			{
				base.SetValueˡ<string>( _dicˡ, column٠CustomerTypeID, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public CustomerCustomerDemo() : base()
		{
			base._dicˡ[ column٠CustomerID ] = null ;
			base._dicˡ[ column٠CustomerTypeID ] = null ;
		 
			base._dicPKˡ[ column٠CustomerID ] = null ;
			base._dicPKˡ[ column٠CustomerTypeID ] = null ;
		 
		}

	}

}
