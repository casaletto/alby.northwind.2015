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
	public partial class TestTable2a : acr.RowBase
	{
		public scg.List<TestTable2b> children٠TestTable2b٠By٠HomeStateHomePostCode( sds.SqlConnection connˡ, int? topNˡ = null, scg.List<acr.CodeGenOrderBy> orderByˡ = null, sds.SqlTransaction tranˡ = null )
		{
			TestTable2bFactory factoryˡ = new TestTable2bFactory() ; 
			return factoryˡ.LoadByForeignKey٠From٠TestTable2a٠By٠HomeStateHomePostCode
			(
				connˡ,
				this.State, 
				this.PostCode, 
				topNˡ,
				orderByˡ,
				tranˡ
			) ;
		}

		public scg.List<TestTable2b> children٠TestTable2b٠By٠MailStateMailPostCode( sds.SqlConnection connˡ, int? topNˡ = null, scg.List<acr.CodeGenOrderBy> orderByˡ = null, sds.SqlTransaction tranˡ = null )
		{
			TestTable2bFactory factoryˡ = new TestTable2bFactory() ; 
			return factoryˡ.LoadByForeignKey٠From٠TestTable2a٠By٠MailStateMailPostCode
			(
				connˡ,
				this.State, 
				this.PostCode, 
				topNˡ,
				orderByˡ,
				tranˡ
			) ;
		}

	}

}

