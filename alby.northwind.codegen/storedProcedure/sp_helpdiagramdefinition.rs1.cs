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
	public partial class sp_helpdiagramdefinition٠rs1 : acr.RowBase
	{
		public const string column٠version  = "version" ;
		public const string column٠definition  = "definition" ;
		 
		public int? version
		{
			get
			{
				return base.GetValueˡ<int?>( _dicˡ, column٠version ) ; 
			}
			set
			{
				base.SetValueˡ<int?>( _dicˡ, column٠version, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public byte[] definition
		{
			get
			{
				return base.GetValueˡ<byte[]>( _dicˡ, column٠definition ) ; 
			}
			set
			{
				base.SetValueˡ<byte[]>( _dicˡ, column٠definition, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public sp_helpdiagramdefinition٠rs1() : base()
		{
			base._dicˡ[ column٠version ] = null ;
			base._dicˡ[ column٠definition ] = null ;
		 
		}

	}

}

