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
		public int CodegenTestStoredProcLoadTest
		(
			sds.SqlConnection connˡ, 
			scg.List<MyBigIntTableType٠tt> list, 
			ref long? theCount, 
			ref long? theFirstOne, 
			ref long? theLastOne, 
			sds.SqlTransaction tranˡ = null
		)
		{
			const string schemaˡ = "dbo" ; 
			const string spˡ = "CodegenTestStoredProcLoadTest" ; 
			 
			scg.List<sds.SqlParameter> parametersˡ = new scg.List<sds.SqlParameter>() ;
			sds.SqlParameter paramˡlist = base.AddParameterTableTypeˡ( parametersˡ, "@list", this.CodegenTestStoredProcLoadTest٠listˡ( list ), "dbo.MyBigIntTableType" ) ; 
			sds.SqlParameter paramˡtheCount = base.AddParameterˡ( parametersˡ, "@theCount", theCount, sd.SqlDbType.BigInt, false, null, 19, 0 ) ; 
			sds.SqlParameter paramˡtheFirstOne = base.AddParameterˡ( parametersˡ, "@theFirstOne", theFirstOne, sd.SqlDbType.BigInt, false, null, 19, 0 ) ; 
			sds.SqlParameter paramˡtheLastOne = base.AddParameterˡ( parametersˡ, "@theLastOne", theLastOne, sd.SqlDbType.BigInt, false, null, 19, 0 ) ; 
			sds.SqlParameter paramˡrcˡ = base.AddParameterReturnValueˡ( parametersˡ, "@rcˡ" ) ; 
			 
			sd.DataSet dsˡ = base.Executeˡ( connˡ, tranˡ, schemaˡ, spˡ, parametersˡ ) ;
			 
			theCount = base.GetParameterValueˡ<long?>( paramˡtheCount ) ;
			theFirstOne = base.GetParameterValueˡ<long?>( paramˡtheFirstOne ) ;
			theLastOne = base.GetParameterValueˡ<long?>( paramˡtheLastOne ) ;
			return base.GetParameterValueˡ<int>( paramˡrcˡ ) ;
		}
		 
		protected object CodegenTestStoredProcLoadTest٠listˡ( scg.List<MyBigIntTableType٠tt> list )
		{
			if ( list == null ) return null ;
			if ( list.Count == 0 ) return null ;
			return new  ns.storedProcedure.MyBigIntTableType٠ttlist( list ) ;
		}
	}

}
