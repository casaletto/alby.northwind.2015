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
	public partial class Product_Sales_for_1997 : acr.RowBase
	{
		public const string column٠CategoryName  = "CategoryName" ;
		public const string column٠ProductName  = "ProductName" ;
		public const string column٠ProductSales  = "ProductSales" ;
		 
		public string CategoryName
		{
			get
			{
				return base.GetValueˡ<string>( _dicˡ, column٠CategoryName ) ; 
			}
			set
			{
				base.SetValueˡ<string>( _dicˡ, column٠CategoryName, value, ref _dirtyˡ ) ; 
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
		 
		public decimal? ProductSales
		{
			get
			{
				return base.GetValueˡ<decimal?>( _dicˡ, column٠ProductSales ) ; 
			}
			set
			{
				base.SetValueˡ<decimal?>( _dicˡ, column٠ProductSales, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public Product_Sales_for_1997() : base()
		{
			base._dicˡ[ column٠CategoryName ] = null ;
			base._dicˡ[ column٠ProductName ] = null ;
			base._dicˡ[ column٠ProductSales ] = null ;
		 
		 
		}

	}

}

