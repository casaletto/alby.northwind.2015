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
	public partial class CustOrdersOrders٠rs1 : acr.RowBase
	{
		public const string column٠OrderID  = "OrderID" ;
		public const string column٠OrderDate  = "OrderDate" ;
		public const string column٠RequiredDate  = "RequiredDate" ;
		public const string column٠ShippedDate  = "ShippedDate" ;
		 
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
		 
		public DateTime? OrderDate
		{
			get
			{
				return base.GetValueˡ<DateTime?>( _dicˡ, column٠OrderDate ) ; 
			}
			set
			{
				base.SetValueˡ<DateTime?>( _dicˡ, column٠OrderDate, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public DateTime? RequiredDate
		{
			get
			{
				return base.GetValueˡ<DateTime?>( _dicˡ, column٠RequiredDate ) ; 
			}
			set
			{
				base.SetValueˡ<DateTime?>( _dicˡ, column٠RequiredDate, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public DateTime? ShippedDate
		{
			get
			{
				return base.GetValueˡ<DateTime?>( _dicˡ, column٠ShippedDate ) ; 
			}
			set
			{
				base.SetValueˡ<DateTime?>( _dicˡ, column٠ShippedDate, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public CustOrdersOrders٠rs1() : base()
		{
			base._dicˡ[ column٠OrderID ] = null ;
			base._dicˡ[ column٠OrderDate ] = null ;
			base._dicˡ[ column٠RequiredDate ] = null ;
			base._dicˡ[ column٠ShippedDate ] = null ;
		 
		}

	}

}

