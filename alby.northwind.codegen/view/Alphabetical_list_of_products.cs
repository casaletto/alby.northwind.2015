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
	public partial class Alphabetical_list_of_products : acr.RowBase
	{
		public const string column٠ProductID  = "ProductID" ;
		public const string column٠ProductName  = "ProductName" ;
		public const string column٠SupplierID  = "SupplierID" ;
		public const string column٠CategoryID  = "CategoryID" ;
		public const string column٠QuantityPerUnit  = "QuantityPerUnit" ;
		public const string column٠UnitPrice  = "UnitPrice" ;
		public const string column٠UnitsInStock  = "UnitsInStock" ;
		public const string column٠UnitsOnOrder  = "UnitsOnOrder" ;
		public const string column٠ReorderLevel  = "ReorderLevel" ;
		public const string column٠Discontinued  = "Discontinued" ;
		public const string column٠CategoryName  = "CategoryName" ;
		 
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
		 
		public int? SupplierID
		{
			get
			{
				return base.GetValueˡ<int?>( _dicˡ, column٠SupplierID ) ; 
			}
			set
			{
				base.SetValueˡ<int?>( _dicˡ, column٠SupplierID, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public int? CategoryID
		{
			get
			{
				return base.GetValueˡ<int?>( _dicˡ, column٠CategoryID ) ; 
			}
			set
			{
				base.SetValueˡ<int?>( _dicˡ, column٠CategoryID, value, ref _dirtyˡ ) ; 
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
		 
		public decimal? UnitPrice
		{
			get
			{
				return base.GetValueˡ<decimal?>( _dicˡ, column٠UnitPrice ) ; 
			}
			set
			{
				base.SetValueˡ<decimal?>( _dicˡ, column٠UnitPrice, value, ref _dirtyˡ ) ; 
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
		 
		public short? UnitsOnOrder
		{
			get
			{
				return base.GetValueˡ<short?>( _dicˡ, column٠UnitsOnOrder ) ; 
			}
			set
			{
				base.SetValueˡ<short?>( _dicˡ, column٠UnitsOnOrder, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public short? ReorderLevel
		{
			get
			{
				return base.GetValueˡ<short?>( _dicˡ, column٠ReorderLevel ) ; 
			}
			set
			{
				base.SetValueˡ<short?>( _dicˡ, column٠ReorderLevel, value, ref _dirtyˡ ) ; 
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
		 
		public Alphabetical_list_of_products() : base()
		{
			base._dicˡ[ column٠ProductID ] = null ;
			base._dicˡ[ column٠ProductName ] = null ;
			base._dicˡ[ column٠SupplierID ] = null ;
			base._dicˡ[ column٠CategoryID ] = null ;
			base._dicˡ[ column٠QuantityPerUnit ] = null ;
			base._dicˡ[ column٠UnitPrice ] = null ;
			base._dicˡ[ column٠UnitsInStock ] = null ;
			base._dicˡ[ column٠UnitsOnOrder ] = null ;
			base._dicˡ[ column٠ReorderLevel ] = null ;
			base._dicˡ[ column٠Discontinued ] = null ;
			base._dicˡ[ column٠CategoryName ] = null ;
		 
		 
		}

	}

}

