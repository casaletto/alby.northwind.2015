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
	public partial class Products_by_Category : acr.RowBase
	{
		public const string column٠CategoryName  = "CategoryName" ;
		public const string column٠ProductName  = "ProductName" ;
		public const string column٠QuantityPerUnit  = "QuantityPerUnit" ;
		public const string column٠UnitsInStock  = "UnitsInStock" ;
		public const string column٠Discontinued  = "Discontinued" ;
		 
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
		 
		public string QuantityPerUnit
		{
			get
			{
				return base.GetValueˡ<string>( _dicˡ, column٠QuantityPerUnit ) ; 
			}
			set
			{
				base.SetValueˡ<string>( _dicˡ, column٠QuantityPerUnit, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public short? UnitsInStock
		{
			get
			{
				return base.GetValueˡ<short?>( _dicˡ, column٠UnitsInStock ) ; 
			}
			set
			{
				base.SetValueˡ<short?>( _dicˡ, column٠UnitsInStock, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public bool? Discontinued
		{
			get
			{
				return base.GetValueˡ<bool?>( _dicˡ, column٠Discontinued ) ; 
			}
			set
			{
				base.SetValueˡ<bool?>( _dicˡ, column٠Discontinued, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public Products_by_Category() : base()
		{
			base._dicˡ[ column٠CategoryName ] = null ;
			base._dicˡ[ column٠ProductName ] = null ;
			base._dicˡ[ column٠QuantityPerUnit ] = null ;
			base._dicˡ[ column٠UnitsInStock ] = null ;
			base._dicˡ[ column٠Discontinued ] = null ;
		 
		 
		}

	}

}

