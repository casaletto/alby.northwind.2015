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
	public partial class Order_Details : acr.RowBase
	{
		public const string column٠OrderID  = "OrderID" ;
		public const string column٠ProductID  = "ProductID" ;
		public const string column٠UnitPrice  = "UnitPrice" ;
		public const string column٠Quantity  = "Quantity" ;
		public const string column٠Discount  = "Discount" ;
		 
		public int? OrderID
		{
			get
			{
				return base.GetValueˡ<int?>( _dicˡ, column٠OrderID ) ; 
			}
			set
			{
				base.SetValueˡ<int?>( _dicˡ, column٠OrderID, value, ref _dirtyˡ ) ; 
			}
		}
		 
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
		 
		public short? Quantity
		{
			get
			{
				return base.GetValueˡ<short?>( _dicˡ, column٠Quantity ) ; 
			}
			set
			{
				base.SetValueˡ<short?>( _dicˡ, column٠Quantity, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public float? Discount
		{
			get
			{
				return base.GetValueˡ<float?>( _dicˡ, column٠Discount ) ; 
			}
			set
			{
				base.SetValueˡ<float?>( _dicˡ, column٠Discount, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public Order_Details() : base()
		{
			base._dicˡ[ column٠OrderID ] = null ;
			base._dicˡ[ column٠ProductID ] = null ;
			base._dicˡ[ column٠UnitPrice ] = null ;
			base._dicˡ[ column٠Quantity ] = null ;
			base._dicˡ[ column٠Discount ] = null ;
		 
			base._dicPKˡ[ column٠OrderID ] = null ;
			base._dicPKˡ[ column٠ProductID ] = null ;
		 
		}

	}

}

