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

namespace alby.northwind.codegen.table
{
	public partial class TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_Factory : acr.FactoryBase< TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_, ns.database.NorthwindDatabaseSingletonHelper, ns.database.NorthwindDatabase >
	{
		static TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_Factory() 
		{
			_assemblyˡ = sr.Assembly.GetExecutingAssembly() ;
			_schemaˡ = "dbo" ;
			_tableˡ = "TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒˇˈˊⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏۝" ;
			_selectˡ = "select * from {0} t " ;
			_insertˡ = "insert {0} ( [CategoryID], [CustomerID], [EmployeeID], [OrderID], [ProductID], [RegionID], [ShipperID], [SupplierID], [TerritoryID], [update_date] ) values ( @CategoryID, @CustomerID, @EmployeeID, @OrderID, @ProductID, @RegionID, @ShipperID, @SupplierID, @TerritoryID, @update_date ) " ;
			_insertIdentityˡ = "insert {0} ( [ID_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒˇˈˊⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏۝], [CategoryID], [CustomerID], [EmployeeID], [OrderID], [ProductID], [RegionID], [ShipperID], [SupplierID], [TerritoryID], [update_date] ) values ( @ID_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_, @CategoryID, @CustomerID, @EmployeeID, @OrderID, @ProductID, @RegionID, @ShipperID, @SupplierID, @TerritoryID, @update_date ) " ;
			_updateˡ = "update {0} set [CategoryID] = @CategoryID, [CustomerID] = @CustomerID, [EmployeeID] = @EmployeeID, [OrderID] = @OrderID, [ProductID] = @ProductID, [RegionID] = @RegionID, [ShipperID] = @ShipperID, [SupplierID] = @SupplierID, [TerritoryID] = @TerritoryID, [update_date] = @update_date " ;
			_deleteˡ = "delete {0} " ;
			_whereLoadPKˡ = "where [ID_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒˇˈˊⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏۝] = @pk_ID_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_ " ;
			_whereSavePKˡ = "where [ID_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒˇˈˊⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏۝] = @pk_ID_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_ and [update_date] = @concurrency_update_date " ;
		}

		public TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_ Saveˡ( sds.SqlConnection connˡ, TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_ rowˡ, acr.CodeGenSaveStrategy saveStrategyˡ = acr.CodeGenSaveStrategy.Normal, bool identityProvidedˡ = false, sds.SqlTransaction tranˡ = null )
		{
			scg.List<sds.SqlParameter> parametersˡ = new scg.List<sds.SqlParameter>();
			base.AddParameterˡ( parametersˡ, "@pk_ID_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_", rowˡ.PrimaryKeyDictionaryˡ[ TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_.column٠ID_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_ ] );
			base.AddParameterˡ( parametersˡ, "@concurrency_update_date", rowˡ.ConcurrencyTimestampˡ );
			base.AddParameterˡ( parametersˡ, "@ID_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_", rowˡ.ID_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_, sd.SqlDbType.Int );
			base.AddParameterˡ( parametersˡ, "@CategoryID", rowˡ.CategoryID, sd.SqlDbType.Int );
			base.AddParameterˡ( parametersˡ, "@CustomerID", rowˡ.CustomerID, sd.SqlDbType.NText );
			base.AddParameterˡ( parametersˡ, "@EmployeeID", rowˡ.EmployeeID, sd.SqlDbType.Int );
			base.AddParameterˡ( parametersˡ, "@OrderID", rowˡ.OrderID, sd.SqlDbType.Int );
			base.AddParameterˡ( parametersˡ, "@ProductID", rowˡ.ProductID, sd.SqlDbType.Int );
			base.AddParameterˡ( parametersˡ, "@RegionID", rowˡ.RegionID, sd.SqlDbType.Int );
			base.AddParameterˡ( parametersˡ, "@ShipperID", rowˡ.ShipperID, sd.SqlDbType.Int );
			base.AddParameterˡ( parametersˡ, "@SupplierID", rowˡ.SupplierID, sd.SqlDbType.Int );
			base.AddParameterˡ( parametersˡ, "@TerritoryID", rowˡ.TerritoryID, sd.SqlDbType.NText );
			base.AddParameterˡ( parametersˡ, "@update_date", rowˡ.update_date, sd.SqlDbType.DateTime );

			int? identityIDˡ = null ;
			object objˡ = null ;
		 
			acr.SaveEnum saveResultˡ ;
		 
			if ( saveStrategyˡ != acr.CodeGenSaveStrategy.Normal )
			{
				saveResultˡ = base.ExecuteForceSaveˡ( rowˡ, connˡ, tranˡ, parametersˡ, saveStrategyˡ, _insertˡ, _insertIdentityˡ, _updateˡ, _deleteˡ, _whereLoadPKˡ, true, identityProvidedˡ, out objˡ ) ;
				if ( objˡ != null )
					identityIDˡ = int.Parse( objˡ.ToString() ) ;
			}
			else
			{
				saveResultˡ = base.ExecuteSaveˡ( rowˡ, connˡ, tranˡ, parametersˡ, _insertˡ, _insertIdentityˡ, _updateˡ, _deleteˡ, _whereSavePKˡ, true, identityProvidedˡ, out objˡ ) ;
				if ( objˡ != null )
					identityIDˡ = int.Parse( objˡ.ToString() ) ;
			}
		 
			if ( saveResultˡ == acr.SaveEnum.Update ) 
				return this.LoadByPrimaryKeyˡ( connˡ, rowˡ.ID_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_, tranˡ ) ;
			else
			if ( saveResultˡ == acr.SaveEnum.Insert ) 
				return this.LoadByPrimaryKeyˡ( connˡ, identityIDˡ, tranˡ ) ;
			else
			if ( saveResultˡ == acr.SaveEnum.Delete )
				return null ;
			else
				return rowˡ ;
		}

		public scg.List<TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_> Saveˡ( sds.SqlConnection connˡ, scg.List<TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_> rowListˡ, acr.CodeGenSaveStrategy saveStrategyˡ = acr.CodeGenSaveStrategy.Normal,  bool identityProvidedˡ = false, sds.SqlTransaction tranˡ = null )
		{
			scg.List<TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_> rowList2ˡ = new scg.List<TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_>();
			foreach( TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_ rowˡ in rowListˡ )
			{
				TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_ row2ˡ = this.Saveˡ( connˡ, rowˡ, saveStrategyˡ, identityProvidedˡ, tranˡ ) ;
				if ( row2ˡ != null )	rowList2ˡ.Add( row2ˡ ) ;
			}
			return rowList2ˡ ;
		}

		public TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_ LoadByPrimaryKeyˡ
		(
			sds.SqlConnection connˡ,
			int? ID_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_,
			sds.SqlTransaction tranˡ = null
		)
		{
			scg.List<sds.SqlParameter> parametersˡ = new scg.List<sds.SqlParameter>();
			base.AddParameterˡ( parametersˡ, "@pk_ID_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_", ID_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_ );
			return base.ExecuteQueryReturnOneˡ( connˡ, tranˡ, parametersˡ, _assemblyˡ, _selectˡ, false, _whereLoadPKˡ, false ) ;
		}

		public scg.List<TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_> LoadByForeignKey٠From٠Categories٠By٠CategoryID
		(
			sds.SqlConnection connˡ,
			int? CategoryID,
			int? topNˡ = null,
			scg.List<acr.CodeGenOrderBy> orderByˡ = null,
			sds.SqlTransaction tranˡ = null
		)
		{
			scg.List<sds.SqlParameter> parametersˡ = new scg.List<sds.SqlParameter>();
			base.AddParameterˡ( parametersˡ, "@CategoryID", CategoryID );
			string whereˡ = "where [CategoryID] = @CategoryID " ; 
			string sqlˡ = "" ; 
			return base.ExecuteQueryˡ( connˡ, tranˡ, parametersˡ, _assemblyˡ, _selectˡ, false, whereˡ, false, topNˡ, orderByˡ, out sqlˡ ) ;
		}

		public scg.List<TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_> LoadByForeignKey٠From٠Customers٠By٠CustomerID
		(
			sds.SqlConnection connˡ,
			string CustomerID,
			int? topNˡ = null,
			scg.List<acr.CodeGenOrderBy> orderByˡ = null,
			sds.SqlTransaction tranˡ = null
		)
		{
			scg.List<sds.SqlParameter> parametersˡ = new scg.List<sds.SqlParameter>();
			base.AddParameterˡ( parametersˡ, "@CustomerID", CustomerID );
			string whereˡ = "where [CustomerID] = @CustomerID " ; 
			string sqlˡ = "" ; 
			return base.ExecuteQueryˡ( connˡ, tranˡ, parametersˡ, _assemblyˡ, _selectˡ, false, whereˡ, false, topNˡ, orderByˡ, out sqlˡ ) ;
		}

		public scg.List<TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_> LoadByForeignKey٠From٠Employees٠By٠EmployeeID
		(
			sds.SqlConnection connˡ,
			int? EmployeeID,
			int? topNˡ = null,
			scg.List<acr.CodeGenOrderBy> orderByˡ = null,
			sds.SqlTransaction tranˡ = null
		)
		{
			scg.List<sds.SqlParameter> parametersˡ = new scg.List<sds.SqlParameter>();
			base.AddParameterˡ( parametersˡ, "@EmployeeID", EmployeeID );
			string whereˡ = "where [EmployeeID] = @EmployeeID " ; 
			string sqlˡ = "" ; 
			return base.ExecuteQueryˡ( connˡ, tranˡ, parametersˡ, _assemblyˡ, _selectˡ, false, whereˡ, false, topNˡ, orderByˡ, out sqlˡ ) ;
		}

		public scg.List<TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_> LoadByForeignKey٠From٠Orders٠By٠OrderID
		(
			sds.SqlConnection connˡ,
			int? OrderID,
			int? topNˡ = null,
			scg.List<acr.CodeGenOrderBy> orderByˡ = null,
			sds.SqlTransaction tranˡ = null
		)
		{
			scg.List<sds.SqlParameter> parametersˡ = new scg.List<sds.SqlParameter>();
			base.AddParameterˡ( parametersˡ, "@OrderID", OrderID );
			string whereˡ = "where [OrderID] = @OrderID " ; 
			string sqlˡ = "" ; 
			return base.ExecuteQueryˡ( connˡ, tranˡ, parametersˡ, _assemblyˡ, _selectˡ, false, whereˡ, false, topNˡ, orderByˡ, out sqlˡ ) ;
		}

		public scg.List<TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_> LoadByForeignKey٠From٠Products٠By٠ProductID
		(
			sds.SqlConnection connˡ,
			int? ProductID,
			int? topNˡ = null,
			scg.List<acr.CodeGenOrderBy> orderByˡ = null,
			sds.SqlTransaction tranˡ = null
		)
		{
			scg.List<sds.SqlParameter> parametersˡ = new scg.List<sds.SqlParameter>();
			base.AddParameterˡ( parametersˡ, "@ProductID", ProductID );
			string whereˡ = "where [ProductID] = @ProductID " ; 
			string sqlˡ = "" ; 
			return base.ExecuteQueryˡ( connˡ, tranˡ, parametersˡ, _assemblyˡ, _selectˡ, false, whereˡ, false, topNˡ, orderByˡ, out sqlˡ ) ;
		}

		public scg.List<TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_> LoadByForeignKey٠From٠Region٠By٠RegionID
		(
			sds.SqlConnection connˡ,
			int? RegionID,
			int? topNˡ = null,
			scg.List<acr.CodeGenOrderBy> orderByˡ = null,
			sds.SqlTransaction tranˡ = null
		)
		{
			scg.List<sds.SqlParameter> parametersˡ = new scg.List<sds.SqlParameter>();
			base.AddParameterˡ( parametersˡ, "@RegionID", RegionID );
			string whereˡ = "where [RegionID] = @RegionID " ; 
			string sqlˡ = "" ; 
			return base.ExecuteQueryˡ( connˡ, tranˡ, parametersˡ, _assemblyˡ, _selectˡ, false, whereˡ, false, topNˡ, orderByˡ, out sqlˡ ) ;
		}

		public scg.List<TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_> LoadByForeignKey٠From٠Shippers٠By٠ShipperID
		(
			sds.SqlConnection connˡ,
			int? ShipperID,
			int? topNˡ = null,
			scg.List<acr.CodeGenOrderBy> orderByˡ = null,
			sds.SqlTransaction tranˡ = null
		)
		{
			scg.List<sds.SqlParameter> parametersˡ = new scg.List<sds.SqlParameter>();
			base.AddParameterˡ( parametersˡ, "@ShipperID", ShipperID );
			string whereˡ = "where [ShipperID] = @ShipperID " ; 
			string sqlˡ = "" ; 
			return base.ExecuteQueryˡ( connˡ, tranˡ, parametersˡ, _assemblyˡ, _selectˡ, false, whereˡ, false, topNˡ, orderByˡ, out sqlˡ ) ;
		}

		public scg.List<TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_> LoadByForeignKey٠From٠Suppliers٠By٠SupplierID
		(
			sds.SqlConnection connˡ,
			int? SupplierID,
			int? topNˡ = null,
			scg.List<acr.CodeGenOrderBy> orderByˡ = null,
			sds.SqlTransaction tranˡ = null
		)
		{
			scg.List<sds.SqlParameter> parametersˡ = new scg.List<sds.SqlParameter>();
			base.AddParameterˡ( parametersˡ, "@SupplierID", SupplierID );
			string whereˡ = "where [SupplierID] = @SupplierID " ; 
			string sqlˡ = "" ; 
			return base.ExecuteQueryˡ( connˡ, tranˡ, parametersˡ, _assemblyˡ, _selectˡ, false, whereˡ, false, topNˡ, orderByˡ, out sqlˡ ) ;
		}

		public scg.List<TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_> LoadByForeignKey٠From٠Territories٠By٠TerritoryID
		(
			sds.SqlConnection connˡ,
			string TerritoryID,
			int? topNˡ = null,
			scg.List<acr.CodeGenOrderBy> orderByˡ = null,
			sds.SqlTransaction tranˡ = null
		)
		{
			scg.List<sds.SqlParameter> parametersˡ = new scg.List<sds.SqlParameter>();
			base.AddParameterˡ( parametersˡ, "@TerritoryID", TerritoryID );
			string whereˡ = "where [TerritoryID] = @TerritoryID " ; 
			string sqlˡ = "" ; 
			return base.ExecuteQueryˡ( connˡ, tranˡ, parametersˡ, _assemblyˡ, _selectˡ, false, whereˡ, false, topNˡ, orderByˡ, out sqlˡ ) ;
		}

		public scg.List<TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_> Loadˡ
		(
			sds.SqlConnection connˡ,
			int? topNˡ = null,
			scg.List<acr.CodeGenOrderBy> orderByˡ = null,
			sds.SqlTransaction tranˡ = null
		)
		{
			scg.List<sds.SqlParameter> parametersˡ = new scg.List<sds.SqlParameter>();
			string whereˡ = "";
			string sqlˡ = "" ; 
			return base.ExecuteQueryˡ( connˡ, tranˡ, parametersˡ, _assemblyˡ, _selectˡ, false, whereˡ, false, topNˡ, orderByˡ, out sqlˡ ) ;
		}

		public scg.List<TestTable7Unicode_ẻẽếℚℛℜᾈᾉᾊᄐᄑᄒ___ⅠⅡⅢⅴⅵⅶɑ̀ɒ́ɑ̂ािी०१२︳︴﹍﹎﹏_> LoadByWhereˡ
		(
			sds.SqlConnection connˡ,
			string whereˡ,
			scg.List<sds.SqlParameter> parametersˡ = null,
			int? topNˡ = null,
			scg.List<acr.CodeGenOrderBy> orderByˡ = null,
			sds.SqlTransaction tranˡ = null
		)
		{
			string sqlˡ = "" ; 
			return base.ExecuteQueryˡ( connˡ, tranˡ, parametersˡ, _assemblyˡ, _selectˡ, false, whereˡ, false, topNˡ, orderByˡ, out sqlˡ ) ;
		}

	}

}

