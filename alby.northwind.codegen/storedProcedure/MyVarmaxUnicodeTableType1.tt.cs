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
	public partial class MyVarmaxUnicodeTableType1٠tt : acr.RowBase
	{
		public const string column٠MyVarBinary  = "MyVarBinary" ;
		public const string column٠MyVarChar  = "MyVarChar" ;
		public const string column٠MyNVarChar  = "MyNVarChar" ;
		public const string column٠MyText  = "MyText" ;
		public const string column٠MyNText  = "MyNText" ;
		public const string column٠MyImage  = "MyImage" ;
		public const string column٠MyXml  = "MyXml" ;
		 
		public byte[] MyVarBinary
		{
			get
			{
				return base.GetValueˡ<byte[]>( _dicˡ, column٠MyVarBinary ) ; 
			}
			set
			{
				base.SetValueˡ<byte[]>( _dicˡ, column٠MyVarBinary, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public string MyVarChar
		{
			get
			{
				return base.GetValueˡ<string>( _dicˡ, column٠MyVarChar ) ; 
			}
			set
			{
				base.SetValueˡ<string>( _dicˡ, column٠MyVarChar, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public string MyNVarChar
		{
			get
			{
				return base.GetValueˡ<string>( _dicˡ, column٠MyNVarChar ) ; 
			}
			set
			{
				base.SetValueˡ<string>( _dicˡ, column٠MyNVarChar, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public string MyText
		{
			get
			{
				return base.GetValueˡ<string>( _dicˡ, column٠MyText ) ; 
			}
			set
			{
				base.SetValueˡ<string>( _dicˡ, column٠MyText, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public string MyNText
		{
			get
			{
				return base.GetValueˡ<string>( _dicˡ, column٠MyNText ) ; 
			}
			set
			{
				base.SetValueˡ<string>( _dicˡ, column٠MyNText, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public byte[] MyImage
		{
			get
			{
				return base.GetValueˡ<byte[]>( _dicˡ, column٠MyImage ) ; 
			}
			set
			{
				base.SetValueˡ<byte[]>( _dicˡ, column٠MyImage, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public string MyXml
		{
			get
			{
				return base.GetValueˡ<string>( _dicˡ, column٠MyXml ) ; 
			}
			set
			{
				base.SetValueˡ<string>( _dicˡ, column٠MyXml, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public MyVarmaxUnicodeTableType1٠tt() : base()
		{
			base._dicˡ[ column٠MyVarBinary ] = null ;
			base._dicˡ[ column٠MyVarChar ] = null ;
			base._dicˡ[ column٠MyNVarChar ] = null ;
			base._dicˡ[ column٠MyText ] = null ;
			base._dicˡ[ column٠MyNText ] = null ;
			base._dicˡ[ column٠MyImage ] = null ;
			base._dicˡ[ column٠MyXml ] = null ;
		 
		}

	}

}

