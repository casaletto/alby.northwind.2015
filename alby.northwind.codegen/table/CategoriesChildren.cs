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
	public partial class Categories : acr.RowBase
	{
		public scg.List<Products> children٠Products٠By٠CategoryID( sds.SqlConnection connˡ, int? topNˡ = null, scg.List<acr.CodeGenOrderBy> orderByˡ = null, sds.SqlTransaction tranˡ = null )
		{
			ProductsFactory factoryˡ = new ProductsFactory() ; 
			return factoryˡ.LoadByForeignKey٠From٠Categories٠By٠CategoryID
			(
				connˡ,
				this.CategoryID, 
				topNˡ,
				orderByˡ,
				tranˡ
			) ;
		}

		public scg.List<TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_> children٠TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_٠By٠CategoryID( sds.SqlConnection connˡ, int? topNˡ = null, scg.List<acr.CodeGenOrderBy> orderByˡ = null, sds.SqlTransaction tranˡ = null )
		{
			TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_Factory factoryˡ = new TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_Factory() ; 
			return factoryˡ.LoadByForeignKey٠From٠Categories٠By٠CategoryID
			(
				connˡ,
				this.CategoryID, 
				topNˡ,
				orderByˡ,
				tranˡ
			) ;
		}

	}

}

