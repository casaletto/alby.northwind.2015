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
	public partial class TestTable2bFactory : acr.FactoryBase< TestTable2b, ns.database.NorthwindDatabaseSingletonHelper, ns.database.NorthwindDatabase >
	{
		static TestTable2bFactory() 
		{
			_assemblyˡ = sr.Assembly.GetExecutingAssembly() ;
			_schemaˡ = "dbo" ;
			_tableˡ = "TestTable2b" ;
			_selectˡ = "select * from {0} t " ;
			_insertˡ = "insert {0} ( [Person], [MailPostCode], [MailState], [HomePostCode], [HomeState], [update_date] ) values ( @Person, @MailPostCode, @MailState, @HomePostCode, @HomeState, @update_date ) " ;
			_insertIdentityˡ = "insert {0} ( [Person], [MailPostCode], [MailState], [HomePostCode], [HomeState], [update_date] ) values ( @Person, @MailPostCode, @MailState, @HomePostCode, @HomeState, @update_date ) " ;
			_updateˡ = "update {0} set [Person] = @Person, [MailPostCode] = @MailPostCode, [MailState] = @MailState, [HomePostCode] = @HomePostCode, [HomeState] = @HomeState, [update_date] = @update_date " ;
			_deleteˡ = "delete {0} " ;
			_whereLoadPKˡ = "where [Person] = @pk_Person " ;
			_whereSavePKˡ = "where [Person] = @pk_Person and [update_date] = @concurrency_update_date " ;
		}

		public TestTable2b Saveˡ( sds.SqlConnection connˡ, TestTable2b rowˡ, acr.CodeGenSaveStrategy saveStrategyˡ = acr.CodeGenSaveStrategy.Normal, bool identityProvidedˡ = false, sds.SqlTransaction tranˡ = null )
		{
			scg.List<sds.SqlParameter> parametersˡ = new scg.List<sds.SqlParameter>();
			base.AddParameterˡ( parametersˡ, "@pk_Person", rowˡ.PrimaryKeyDictionaryˡ[ TestTable2b.column٠Person ] );
			base.AddParameterˡ( parametersˡ, "@concurrency_update_date", rowˡ.ConcurrencyTimestampˡ );
			base.AddParameterˡ( parametersˡ, "@Person", rowˡ.Person, sd.SqlDbType.NText );
			base.AddParameterˡ( parametersˡ, "@MailPostCode", rowˡ.MailPostCode, sd.SqlDbType.NText );
			base.AddParameterˡ( parametersˡ, "@MailState", rowˡ.MailState, sd.SqlDbType.NText );
			base.AddParameterˡ( parametersˡ, "@HomePostCode", rowˡ.HomePostCode, sd.SqlDbType.NText );
			base.AddParameterˡ( parametersˡ, "@HomeState", rowˡ.HomeState, sd.SqlDbType.NText );
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
				return this.LoadByPrimaryKeyˡ( connˡ, rowˡ.Person, tranˡ ) ;
			else
			if ( saveResultˡ == acr.SaveEnum.Insert ) 
				return this.LoadByPrimaryKeyˡ( connˡ, rowˡ.Person, tranˡ ) ;
			else
			if ( saveResultˡ == acr.SaveEnum.Delete )
				return null ;
			else
				return rowˡ ;
		}

		public scg.List<TestTable2b> Saveˡ( sds.SqlConnection connˡ, scg.List<TestTable2b> rowListˡ, acr.CodeGenSaveStrategy saveStrategyˡ = acr.CodeGenSaveStrategy.Normal,  bool identityProvidedˡ = false, sds.SqlTransaction tranˡ = null )
		{
			scg.List<TestTable2b> rowList2ˡ = new scg.List<TestTable2b>();
			foreach( TestTable2b rowˡ in rowListˡ )
			{
				TestTable2b row2ˡ = this.Saveˡ( connˡ, rowˡ, saveStrategyˡ, identityProvidedˡ, tranˡ ) ;
				if ( row2ˡ != null )	rowList2ˡ.Add( row2ˡ ) ;
			}
			return rowList2ˡ ;
		}

		public TestTable2b LoadByPrimaryKeyˡ
		(
			sds.SqlConnection connˡ,
			string Person,
			sds.SqlTransaction tranˡ = null
		)
		{
			scg.List<sds.SqlParameter> parametersˡ = new scg.List<sds.SqlParameter>();
			base.AddParameterˡ( parametersˡ, "@pk_Person", Person );
			return base.ExecuteQueryReturnOneˡ( connˡ, tranˡ, parametersˡ, _assemblyˡ, _selectˡ, false, _whereLoadPKˡ, false ) ;
		}

		public scg.List<TestTable2b> LoadByForeignKey٠From٠TestTable2a٠By٠HomeStateHomePostCode
		(
			sds.SqlConnection connˡ,
			string HomeState,
			string HomePostCode,
			int? topNˡ = null,
			scg.List<acr.CodeGenOrderBy> orderByˡ = null,
			sds.SqlTransaction tranˡ = null
		)
		{
			scg.List<sds.SqlParameter> parametersˡ = new scg.List<sds.SqlParameter>();
			base.AddParameterˡ( parametersˡ, "@HomeState", HomeState );
			base.AddParameterˡ( parametersˡ, "@HomePostCode", HomePostCode );
			string whereˡ = "where [HomeState] = @HomeState and [HomePostCode] = @HomePostCode " ; 
			string sqlˡ = "" ; 
			return base.ExecuteQueryˡ( connˡ, tranˡ, parametersˡ, _assemblyˡ, _selectˡ, false, whereˡ, false, topNˡ, orderByˡ, out sqlˡ ) ;
		}

		public scg.List<TestTable2b> LoadByForeignKey٠From٠TestTable2a٠By٠MailStateMailPostCode
		(
			sds.SqlConnection connˡ,
			string MailState,
			string MailPostCode,
			int? topNˡ = null,
			scg.List<acr.CodeGenOrderBy> orderByˡ = null,
			sds.SqlTransaction tranˡ = null
		)
		{
			scg.List<sds.SqlParameter> parametersˡ = new scg.List<sds.SqlParameter>();
			base.AddParameterˡ( parametersˡ, "@MailState", MailState );
			base.AddParameterˡ( parametersˡ, "@MailPostCode", MailPostCode );
			string whereˡ = "where [MailState] = @MailState and [MailPostCode] = @MailPostCode " ; 
			string sqlˡ = "" ; 
			return base.ExecuteQueryˡ( connˡ, tranˡ, parametersˡ, _assemblyˡ, _selectˡ, false, whereˡ, false, topNˡ, orderByˡ, out sqlˡ ) ;
		}

		public scg.List<TestTable2b> Loadˡ
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

		public scg.List<TestTable2b> LoadByWhereˡ
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
