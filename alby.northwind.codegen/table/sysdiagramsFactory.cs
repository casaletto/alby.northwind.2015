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
	public partial class sysdiagramsFactory : acr.FactoryBase< sysdiagrams, ns.database.NorthwindDatabaseSingletonHelper, ns.database.NorthwindDatabase >
	{
		static sysdiagramsFactory() 
		{
			_assemblyˡ = sr.Assembly.GetExecutingAssembly() ;
			_schemaˡ = "dbo" ;
			_tableˡ = "sysdiagrams" ;
			_selectˡ = "select * from {0} t " ;
			_insertˡ = "insert {0} ( [name], [principal_id], [version], [definition] ) values ( @name, @principal_id, @version, @definition ) " ;
			_insertIdentityˡ = "insert {0} ( [name], [principal_id], [diagram_id], [version], [definition] ) values ( @name, @principal_id, @diagram_id, @version, @definition ) " ;
			_updateˡ = "update {0} set [name] = @name, [principal_id] = @principal_id, [version] = @version, [definition] = @definition " ;
			_deleteˡ = "delete {0} " ;
			_whereLoadPKˡ = "where [diagram_id] = @pk_diagram_id " ;
			_whereSavePKˡ = "where [diagram_id] = @pk_diagram_id " ;
		}

		public sysdiagrams Saveˡ( sds.SqlConnection connˡ, sysdiagrams rowˡ, acr.CodeGenSaveStrategy saveStrategyˡ = acr.CodeGenSaveStrategy.Normal, bool identityProvidedˡ = false, sds.SqlTransaction tranˡ = null )
		{
			scg.List<sds.SqlParameter> parametersˡ = new scg.List<sds.SqlParameter>();
			base.AddParameterˡ( parametersˡ, "@pk_diagram_id", rowˡ.PrimaryKeyDictionaryˡ[ sysdiagrams.column٠diagram_id ] );
			base.AddParameterˡ( parametersˡ, "@name", rowˡ.name, sd.SqlDbType.NText );
			base.AddParameterˡ( parametersˡ, "@principal_id", rowˡ.principal_id, sd.SqlDbType.Int );
			base.AddParameterˡ( parametersˡ, "@diagram_id", rowˡ.diagram_id, sd.SqlDbType.Int );
			base.AddParameterˡ( parametersˡ, "@version", rowˡ.version, sd.SqlDbType.Int );
			base.AddParameterˡ( parametersˡ, "@definition", rowˡ.definition, sd.SqlDbType.Image );

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
				return this.LoadByPrimaryKeyˡ( connˡ, rowˡ.diagram_id, tranˡ ) ;
			else
			if ( saveResultˡ == acr.SaveEnum.Insert ) 
				return this.LoadByPrimaryKeyˡ( connˡ, identityIDˡ, tranˡ ) ;
			else
			if ( saveResultˡ == acr.SaveEnum.Delete )
				return null ;
			else
				return rowˡ ;
		}

		public scg.List<sysdiagrams> Saveˡ( sds.SqlConnection connˡ, scg.List<sysdiagrams> rowListˡ, acr.CodeGenSaveStrategy saveStrategyˡ = acr.CodeGenSaveStrategy.Normal,  bool identityProvidedˡ = false, sds.SqlTransaction tranˡ = null )
		{
			scg.List<sysdiagrams> rowList2ˡ = new scg.List<sysdiagrams>();
			foreach( sysdiagrams rowˡ in rowListˡ )
			{
				sysdiagrams row2ˡ = this.Saveˡ( connˡ, rowˡ, saveStrategyˡ, identityProvidedˡ, tranˡ ) ;
				if ( row2ˡ != null )	rowList2ˡ.Add( row2ˡ ) ;
			}
			return rowList2ˡ ;
		}

		public sysdiagrams LoadByPrimaryKeyˡ
		(
			sds.SqlConnection connˡ,
			int? diagram_id,
			sds.SqlTransaction tranˡ = null
		)
		{
			scg.List<sds.SqlParameter> parametersˡ = new scg.List<sds.SqlParameter>();
			base.AddParameterˡ( parametersˡ, "@pk_diagram_id", diagram_id );
			return base.ExecuteQueryReturnOneˡ( connˡ, tranˡ, parametersˡ, _assemblyˡ, _selectˡ, false, _whereLoadPKˡ, false ) ;
		}

		public scg.List<sysdiagrams> Loadˡ
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

		public scg.List<sysdiagrams> LoadByWhereˡ
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

