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
	public partial class TestTable3 : acr.RowBase
	{
		public const string column٠ID  = "ID" ;
		public const string column٠A  = "A" ;
		public const string column٠B  = "B" ;
		public const string column٠C  = "C" ;
		public const string column٠TheSum  = "TheSum" ;
		public const string column٠TheProduct  = "TheProduct" ;
		public const string column٠update_date  = "update_date" ;
		 
		public int? ID
		{
			get
			{
				return base.GetValueˡ<int?>( _dicˡ, column٠ID ) ; 
			}
			set
			{
				base.SetValueˡ<int?>( _dicˡ, column٠ID, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public int? A
		{
			get
			{
				return base.GetValueˡ<int?>( _dicˡ, column٠A ) ; 
			}
			set
			{
				base.SetValueˡ<int?>( _dicˡ, column٠A, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public int? B
		{
			get
			{
				return base.GetValueˡ<int?>( _dicˡ, column٠B ) ; 
			}
			set
			{
				base.SetValueˡ<int?>( _dicˡ, column٠B, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public int? C
		{
			get
			{
				return base.GetValueˡ<int?>( _dicˡ, column٠C ) ; 
			}
			set
			{
				base.SetValueˡ<int?>( _dicˡ, column٠C, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public int? TheSum
		{
			get
			{
				return base.GetValueˡ<int?>( _dicˡ, column٠TheSum ) ; 
			}
			set
			{
				base.SetValueˡ<int?>( _dicˡ, column٠TheSum, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public int? TheProduct
		{
			get
			{
				return base.GetValueˡ<int?>( _dicˡ, column٠TheProduct ) ; 
			}
			set
			{
				base.SetValueˡ<int?>( _dicˡ, column٠TheProduct, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public DateTime? update_date
		{
			get
			{
				return base.GetValueˡ<DateTime?>( _dicˡ, column٠update_date ) ; 
			}
			set
			{
				base.SetValueˡ<DateTime?>( _dicˡ, column٠update_date, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public TestTable3() : base()
		{
			base._dicˡ[ column٠ID ] = null ;
			base._dicˡ[ column٠A ] = null ;
			base._dicˡ[ column٠B ] = null ;
			base._dicˡ[ column٠C ] = null ;
			base._dicˡ[ column٠TheSum ] = null ;
			base._dicˡ[ column٠TheProduct ] = null ;
			base._dicˡ[ column٠update_date ] = null ;
		 
			base._dicPKˡ[ column٠ID ] = null ;
		 
			base.ConcurrencyColumnˡ = "update_date" ;
		}

	}

}

