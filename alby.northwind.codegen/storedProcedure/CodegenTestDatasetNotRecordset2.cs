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
		public int CodegenTestDatasetNotRecordset2
		(
			sds.SqlConnection connˡ, 
			int? orderID, 
			out sd.DataSet dsˡ, 
			sds.SqlTransaction tranˡ = null
		)
		{
			const string schemaˡ = "dbo" ; 
			const string spˡ = "CodegenTestDatasetNotRecordset2" ; 
			 
			scg.List<sds.SqlParameter> parametersˡ = new scg.List<sds.SqlParameter>() ;
			sds.SqlParameter paramˡorderID = base.AddParameterˡ( parametersˡ, "@orderID", orderID, sd.SqlDbType.Int, true, null, 10, 0 ) ; 
			sds.SqlParameter paramˡrcˡ = base.AddParameterReturnValueˡ( parametersˡ, "@rcˡ" ) ; 
			 
			dsˡ = base.Executeˡ( connˡ, tranˡ, schemaˡ, spˡ, parametersˡ ) ;
			 
			return base.GetParameterValueˡ<int>( paramˡrcˡ ) ;
		}
	}

}

