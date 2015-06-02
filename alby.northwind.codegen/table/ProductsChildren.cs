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
	public partial class Products : acr.RowBase
	{
		public Categories parent٠Categories٠By٠CategoryID( sds.SqlConnection connˡ, sds.SqlTransaction tranˡ = null )
		{
			CategoriesFactory factoryˡ = new CategoriesFactory() ; 
			return factoryˡ.LoadByPrimaryKeyˡ
			(
				connˡ,
				this.CategoryID, 
				tranˡ
			) ;
		}

		public Suppliers parent٠Suppliers٠By٠SupplierID( sds.SqlConnection connˡ, sds.SqlTransaction tranˡ = null )
		{
			SuppliersFactory factoryˡ = new SuppliersFactory() ; 
			return factoryˡ.LoadByPrimaryKeyˡ
			(
				connˡ,
				this.SupplierID, 
				tranˡ
			) ;
		}

		public scg.List<Order_Details> children٠Order_Details٠By٠ProductID( sds.SqlConnection connˡ, int? topNˡ = null, scg.List<acr.CodeGenOrderBy> orderByˡ = null, sds.SqlTransaction tranˡ = null )
		{
			Order_DetailsFactory factoryˡ = new Order_DetailsFactory() ; 
			return factoryˡ.LoadByForeignKey٠From٠Products٠By٠ProductID
			(
				connˡ,
				this.ProductID, 
				topNˡ,
				orderByˡ,
				tranˡ
			) ;
		}

		public scg.List<TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_> children٠TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_٠By٠ProductID( sds.SqlConnection connˡ, int? topNˡ = null, scg.List<acr.CodeGenOrderBy> orderByˡ = null, sds.SqlTransaction tranˡ = null )
		{
			TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_Factory factoryˡ = new TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_Factory() ; 
			return factoryˡ.LoadByForeignKey٠From٠Products٠By٠ProductID
			(
				connˡ,
				this.ProductID, 
				topNˡ,
				orderByˡ,
				tranˡ
			) ;
		}

	}

}
