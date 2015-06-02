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
		public int sp_helpdiagrams
		(
			sds.SqlConnection connˡ, 
			string diagramname, 
			int? owner_id, 
			out scg.List<sp_helpdiagrams٠rs1> rsˡ1, 
			sds.SqlTransaction tranˡ = null
		)
		{
			const string schemaˡ = "dbo" ; 
			const string spˡ = "sp_helpdiagrams" ; 
			 
			scg.List<sds.SqlParameter> parametersˡ = new scg.List<sds.SqlParameter>() ;
			sds.SqlParameter paramˡdiagramname = base.AddParameterˡ( parametersˡ, "@diagramname", diagramname, sd.SqlDbType.NVarChar, true, 128, null, null ) ; 
			sds.SqlParameter paramˡowner_id = base.AddParameterˡ( parametersˡ, "@owner_id", owner_id, sd.SqlDbType.Int, true, null, 10, 0 ) ; 
			sds.SqlParameter paramˡrcˡ = base.AddParameterReturnValueˡ( parametersˡ, "@rcˡ" ) ; 
			 
			sd.DataSet dsˡ = base.Executeˡ( connˡ, tranˡ, schemaˡ, spˡ, parametersˡ ) ;
			 
			rsˡ1 = base.ToRecordsetˡ<sp_helpdiagrams٠rs1>( dsˡ, 1 ) ;
			 
			return base.GetParameterValueˡ<int>( paramˡrcˡ ) ;
		}
	}

}

