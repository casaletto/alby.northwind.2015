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
	public partial class TestTable6aFactory : acr.FactoryBase< TestTable6a, ns.database.NorthwindDatabaseSingletonHelper, ns.database.NorthwindDatabase >
	{
		static TestTable6aFactory() 
		{
			_assemblyˡ = sr.Assembly.GetExecutingAssembly() ;
			_schemaˡ = "dbo" ;
			_tableˡ = "TestTable6a" ;
			_selectˡ = "select * from {0} t " ;
			_insertˡ = "insert {0} ( [ID], [Name], [Age], [update_date] ) values ( @ID, @Name, @Age, @update_date ) " ;
			_insertIdentityˡ = "insert {0} ( [ID], [Name], [Age], [update_date] ) values ( @ID, @Name, @Age, @update_date ) " ;
			_updateˡ = "update {0} set [ID] = @ID, [Name] = @Name, [Age] = @Age, [update_date] = @update_date " ;
			_deleteˡ = "delete {0} " ;
			_whereLoadPKˡ = "where [ID] = @pk_ID " ;
			_whereSavePKˡ = "where [ID] = @pk_ID and [update_date] = @concurrency_update_date " ;
		}

		public TestTable6a Saveˡ( sds.SqlConnection connˡ, TestTable6a rowˡ, acr.CodeGenSaveStrategy saveStrategyˡ = acr.CodeGenSaveStrategy.Normal, bool identityProvidedˡ = false, sds.SqlTransaction tranˡ = null )
		{
			scg.List<sds.SqlParameter> parametersˡ = new scg.List<sds.SqlParameter>();
			base.AddParameterˡ( parametersˡ, "@pk_ID", rowˡ.PrimaryKeyDictionaryˡ[ TestTable6a.column٠ID ] );
			base.AddParameterˡ( parametersˡ, "@concurrency_update_date", rowˡ.ConcurrencyTimestampˡ );
			base.AddParameterˡ( parametersˡ, "@ID", rowˡ.ID, sd.SqlDbType.Int );
			base.AddParameterˡ( parametersˡ, "@Name", rowˡ.Name, sd.SqlDbType.NText );
			base.AddParameterˡ( parametersˡ, "@Age", rowˡ.Age, sd.SqlDbType.Int );
			base.AddParameterˡ( parametersˡ, "@update_date", rowˡ.update_date, sd.SqlDbType.DateTime );

			int? identityIDˡ = null ;
			object objˡ = null ;
		 
			acr.SaveEnum saveResultˡ ;
		 
			if ( saveStrategyˡ != acr.CodeGenSaveStrategy.Normal )
			{
				saveResultˡ = base.ExecuteForceSaveˡ( rowˡ, connˡ, tranˡ, parametersˡ, saveStrategyˡ, _insertˡ, _insertIdentityˡ, _updateˡ, _deleteˡ, _whereLoadPKˡ, false, identityProvidedˡ, out objˡ ) ;
				if ( objˡ != null )
					identityIDˡ = int.Parse( objˡ.ToString() ) ;
			}
			else
			{
				saveResultˡ = base.ExecuteSaveˡ( rowˡ, connˡ, tranˡ, parametersˡ, _insertˡ, _insertIdentityˡ, _updateˡ, _deleteˡ, _whereSavePKˡ, false, identityProvidedˡ, out objˡ ) ;
				if ( objˡ != null )
					identityIDˡ = int.Parse( objˡ.ToString() ) ;
			}
		 
			if ( saveResultˡ == acr.SaveEnum.Update ) 
				return this.LoadByPrimaryKeyˡ( connˡ, rowˡ.ID, tranˡ ) ;
			else
			if ( saveResultˡ == acr.SaveEnum.Insert ) 
				return this.LoadByPrimaryKeyˡ( connˡ, rowˡ.ID, tranˡ ) ;
			else
			if ( saveResultˡ == acr.SaveEnum.Delete )
				return null ;
			else
				return rowˡ ;
		}

		public scg.List<TestTable6a> Saveˡ( sds.SqlConnection connˡ, scg.List<TestTable6a> rowListˡ, acr.CodeGenSaveStrategy saveStrategyˡ = acr.CodeGenSaveStrategy.Normal,  bool identityProvidedˡ = false, sds.SqlTransaction tranˡ = null )
		{
			scg.List<TestTable6a> rowList2ˡ = new scg.List<TestTable6a>();
			foreach( TestTable6a rowˡ in rowListˡ )
			{
				TestTable6a row2ˡ = this.Saveˡ( connˡ, rowˡ, saveStrategyˡ, identityProvidedˡ, tranˡ ) ;
				if ( row2ˡ != null )	rowList2ˡ.Add( row2ˡ ) ;
			}
			return rowList2ˡ ;
		}

		public TestTable6a LoadByPrimaryKeyˡ
		(
			sds.SqlConnection connˡ,
			int? ID,
			sds.SqlTransaction tranˡ = null
		)
		{
			scg.List<sds.SqlParameter> parametersˡ = new scg.List<sds.SqlParameter>();
			base.AddParameterˡ( parametersˡ, "@pk_ID", ID );
			return base.ExecuteQueryReturnOneˡ( connˡ, tranˡ, parametersˡ, _assemblyˡ, _selectˡ, false, _whereLoadPKˡ, false ) ;
		}

		public scg.List<TestTable6a> Loadˡ
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

		public scg.List<TestTable6a> LoadByWhereˡ
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
