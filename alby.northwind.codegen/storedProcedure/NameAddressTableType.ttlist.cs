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
	public partial class NameAddressTableType٠ttlist : scg.List< NameAddressTableType٠tt >, scg.IEnumerable< mss.SqlDataRecord >
	{
		scg.List< NameAddressTableType٠tt > _list = null ;
		 
		public NameAddressTableType٠ttlist( scg.List< NameAddressTableType٠tt > list )
		{
			_list = list ;
		}
		 
		scg.IEnumerator< mss.SqlDataRecord > scg.IEnumerable< mss.SqlDataRecord >.GetEnumerator()
		{
			var sdr = new mss.SqlDataRecord
			(
				new mss.SqlMetaData( "Name", sd.SqlDbType.VarChar, 50 ) ,
				new mss.SqlMetaData( "Address", sd.SqlDbType.VarChar, 50 ) ,
				new mss.SqlMetaData( "State", sd.SqlDbType.VarChar, 50 ) 
			) ;
			 
			foreach ( var i in this._list ) 
			{
				if ( i.Name == null )
					sdr.SetDBNull( 0 ) ;
				else
					sdr.SetString( 0, i.Name ) ; 
			 
				if ( i.Address == null )
					sdr.SetDBNull( 1 ) ;
				else
					sdr.SetString( 1, i.Address ) ; 
			 
				if ( i.State == null )
					sdr.SetDBNull( 2 ) ;
				else
					sdr.SetString( 2, i.State ) ; 
			 
				yield return sdr ; 
			}
			 
		}

	}

}
