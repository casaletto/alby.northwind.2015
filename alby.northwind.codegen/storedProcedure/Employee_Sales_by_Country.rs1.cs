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
	public partial class Employee_Sales_by_Country٠rs1 : acr.RowBase
	{
		public const string column٠Country  = "Country" ;
		public const string column٠LastName  = "LastName" ;
		public const string column٠FirstName  = "FirstName" ;
		public const string column٠ShippedDate  = "ShippedDate" ;
		public const string column٠OrderID  = "OrderID" ;
		public const string column٠SaleAmount  = "SaleAmount" ;
		 
		public string Country
		{
			get
			{
				return base.GetValueˡ<string>( _dicˡ, column٠Country ) ; 
			}
			set
			{
				base.SetValueˡ<string>( _dicˡ, column٠Country, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public string LastName
		{
			get
			{
				return base.GetValueˡ<string>( _dicˡ, column٠LastName ) ; 
			}
			set
			{
				base.SetValueˡ<string>( _dicˡ, column٠LastName, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public string FirstName
		{
			get
			{
				return base.GetValueˡ<string>( _dicˡ, column٠FirstName ) ; 
			}
			set
			{
				base.SetValueˡ<string>( _dicˡ, column٠FirstName, value, ref _dirtyˡ ) ; 
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
		 
		public decimal? SaleAmount
		{
			get
			{
				return base.GetValueˡ<decimal?>( _dicˡ, column٠SaleAmount ) ; 
			}
			set
			{
				base.SetValueˡ<decimal?>( _dicˡ, column٠SaleAmount, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public Employee_Sales_by_Country٠rs1() : base()
		{
			base._dicˡ[ column٠Country ] = null ;
			base._dicˡ[ column٠LastName ] = null ;
			base._dicˡ[ column٠FirstName ] = null ;
			base._dicˡ[ column٠ShippedDate ] = null ;
			base._dicˡ[ column٠OrderID ] = null ;
			base._dicˡ[ column٠SaleAmount ] = null ;
		 
		}

	}

}

