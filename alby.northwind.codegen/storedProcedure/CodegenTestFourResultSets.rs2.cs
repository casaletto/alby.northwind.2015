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
	public partial class CodegenTestFourResultSets٠rs2 : acr.RowBase
	{
		public const string column٠CustomerID  = "CustomerID" ;
		public const string column٠CompanyName  = "CompanyName" ;
		public const string column٠Address  = "Address" ;
		 
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
		 
		public string CompanyName
		{
			get
			{
				return base.GetValueˡ<string>( _dicˡ, column٠CompanyName ) ; 
			}
			set
			{
				base.SetValueˡ<string>( _dicˡ, column٠CompanyName, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public string Address
		{
			get
			{
				return base.GetValueˡ<string>( _dicˡ, column٠Address ) ; 
			}
			set
			{
				base.SetValueˡ<string>( _dicˡ, column٠Address, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public CodegenTestFourResultSets٠rs2() : base()
		{
			base._dicˡ[ column٠CustomerID ] = null ;
			base._dicˡ[ column٠CompanyName ] = null ;
			base._dicˡ[ column٠Address ] = null ;
		 
		}

	}

}

