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
	public partial class MyBigIntTableType٠ttlist : scg.List< MyBigIntTableType٠tt >, scg.IEnumerable< mss.SqlDataRecord >
	{
		scg.List< MyBigIntTableType٠tt > _list = null ;
		 
		public MyBigIntTableType٠ttlist( scg.List< MyBigIntTableType٠tt > list )
		{
			_list = list ;
		}
		 
		scg.IEnumerator< mss.SqlDataRecord > scg.IEnumerable< mss.SqlDataRecord >.GetEnumerator()
		{
			var sdr = new mss.SqlDataRecord
			(
				new mss.SqlMetaData( "ID", sd.SqlDbType.BigInt ) 
			) ;
			 
			foreach ( var i in this._list ) 
			{
				if ( i.ID == null )
					sdr.SetDBNull( 0 ) ;
				else
					sdr.SetInt64( 0, i.ID.Value ) ; 
			 
				yield return sdr ; 
			}
			 
		}

	}

}

