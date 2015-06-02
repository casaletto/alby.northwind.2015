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
	public partial class StoredProcedureFactory : acr.StoredProcedureFactoryBase< ns.database.NorthwindDatabaseSingletonHelper, ns.database.NorthwindDatabase >
	{
		public int CodegenTestStoredProcUdtTableType
		(
			sds.SqlConnection connˡ, 
			scg.List<MyUdtTableType٠tt> myudt1, 
			scg.List<MyUdtTableType٠tt> myudt2, 
			out scg.List<CodegenTestStoredProcUdtTableType٠rs1> rsˡ1, 
			sds.SqlTransaction tranˡ = null
		)
		{
			const string schemaˡ = "dbo" ; 
			const string spˡ = "CodegenTestStoredProcUdtTableType" ; 
			 
			scg.List<sds.SqlParameter> parametersˡ = new scg.List<sds.SqlParameter>() ;
			sds.SqlParameter paramˡmyudt1 = base.AddParameterTableTypeˡ( parametersˡ, "@myudt1", this.CodegenTestStoredProcUdtTableType٠myudt1ˡ( myudt1 ), "dbo.MyUdtTableType" ) ; 
			sds.SqlParameter paramˡmyudt2 = base.AddParameterTableTypeˡ( parametersˡ, "@myudt2", this.CodegenTestStoredProcUdtTableType٠myudt2ˡ( myudt2 ), "dbo.MyUdtTableType" ) ; 
			sds.SqlParameter paramˡrcˡ = base.AddParameterReturnValueˡ( parametersˡ, "@rcˡ" ) ; 
			 
			sd.DataSet dsˡ = base.Executeˡ( connˡ, tranˡ, schemaˡ, spˡ, parametersˡ ) ;
			 
			rsˡ1 = base.ToRecordsetˡ<CodegenTestStoredProcUdtTableType٠rs1>( dsˡ, 1 ) ;
			 
			return base.GetParameterValueˡ<int>( paramˡrcˡ ) ;
		}
		 
		protected object CodegenTestStoredProcUdtTableType٠myudt1ˡ( scg.List<MyUdtTableType٠tt> list )
		{
			if ( list == null ) return null ;
			if ( list.Count == 0 ) return null ;
			return new  ns.storedProcedure.MyUdtTableType٠ttlist( list ) ;
		}
		 
		protected object CodegenTestStoredProcUdtTableType٠myudt2ˡ( scg.List<MyUdtTableType٠tt> list )
		{
			if ( list == null ) return null ;
			if ( list.Count == 0 ) return null ;
			return new  ns.storedProcedure.MyUdtTableType٠ttlist( list ) ;
		}
	}

}
