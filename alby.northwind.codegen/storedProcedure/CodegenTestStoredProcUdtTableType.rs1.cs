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
	public partial class CodegenTestStoredProcUdtTableType٠rs1 : acr.RowBase
	{
		public const string column٠Name  = "Name" ;
		public const string column٠MyGeography  = "MyGeography" ;
		public const string column٠MyGeometry  = "MyGeometry" ;
		public const string column٠MyHierarchyid  = "MyHierarchyid" ;
		 
		public string Name
		{
			get
			{
				return base.GetValueˡ<string>( _dicˡ, column٠Name ) ; 
			}
			set
			{
				base.SetValueˡ<string>( _dicˡ, column٠Name, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public mst.SqlGeography MyGeography
		{
			get
			{
				return base.GetValueˡ<mst.SqlGeography>( _dicˡ, column٠MyGeography ) ; 
			}
			set
			{
				base.SetValueˡ<mst.SqlGeography>( _dicˡ, column٠MyGeography, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public mst.SqlGeometry MyGeometry
		{
			get
			{
				return base.GetValueˡ<mst.SqlGeometry>( _dicˡ, column٠MyGeometry ) ; 
			}
			set
			{
				base.SetValueˡ<mst.SqlGeometry>( _dicˡ, column٠MyGeometry, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public mst.SqlHierarchyId? MyHierarchyid
		{
			get
			{
				return base.GetValueˡ<mst.SqlHierarchyId?>( _dicˡ, column٠MyHierarchyid ) ; 
			}
			set
			{
				base.SetValueˡ<mst.SqlHierarchyId?>( _dicˡ, column٠MyHierarchyid, value, ref _dirtyˡ ) ; 
			}
		}
		 
		public CodegenTestStoredProcUdtTableType٠rs1() : base()
		{
			base._dicˡ[ column٠Name ] = null ;
			base._dicˡ[ column٠MyGeography ] = null ;
			base._dicˡ[ column٠MyGeometry ] = null ;
			base._dicˡ[ column٠MyHierarchyid ] = null ;
		 
		}

	}

}

