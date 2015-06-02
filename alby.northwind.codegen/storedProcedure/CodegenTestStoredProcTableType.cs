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
		public int CodegenTestStoredProcTableType
		(
			sds.SqlConnection connˡ, 
			scg.List<NameAddressTableType٠tt> dt, 
			out scg.List<CodegenTestStoredProcTableType٠rs1> rsˡ1, 
			sds.SqlTransaction tranˡ = null
		)
		{
			const string schemaˡ = "dbo" ; 
			const string spˡ = "CodegenTestStoredProcTableType" ; 
			 
			scg.List<sds.SqlParameter> parametersˡ = new scg.List<sds.SqlParameter>() ;
			sds.SqlParameter paramˡdt = base.AddParameterTableTypeˡ( parametersˡ, "@dt", this.CodegenTestStoredProcTableType٠dtˡ( dt ), "dbo.NameAddressTableType" ) ; 
			sds.SqlParameter paramˡrcˡ = base.AddParameterReturnValueˡ( parametersˡ, "@rcˡ" ) ; 
			 
			sd.DataSet dsˡ = base.Executeˡ( connˡ, tranˡ, schemaˡ, spˡ, parametersˡ ) ;
			 
			rsˡ1 = base.ToRecordsetˡ<CodegenTestStoredProcTableType٠rs1>( dsˡ, 1 ) ;
			 
			return base.GetParameterValueˡ<int>( paramˡrcˡ ) ;
		}
		 
		protected object CodegenTestStoredProcTableType٠dtˡ( scg.List<NameAddressTableType٠tt> list )
		{
			if ( list == null ) return null ;
			if ( list.Count == 0 ) return null ;
			return new  ns.storedProcedure.NameAddressTableType٠ttlist( list ) ;
		}
	}

}

