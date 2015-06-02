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
	public partial class MyAllTypesInATableType٠ttlist : scg.List< MyAllTypesInATableType٠tt >, scg.IEnumerable< mss.SqlDataRecord >
	{
		scg.List< MyAllTypesInATableType٠tt > _list = null ;
		 
		public MyAllTypesInATableType٠ttlist( scg.List< MyAllTypesInATableType٠tt > list )
		{
			_list = list ;
		}
		 
		scg.IEnumerator< mss.SqlDataRecord > scg.IEnumerable< mss.SqlDataRecord >.GetEnumerator()
		{
			var sdr = new mss.SqlDataRecord
			(
				new mss.SqlMetaData( "the_bigint", sd.SqlDbType.BigInt ) ,
				new mss.SqlMetaData( "the_binary", sd.SqlDbType.Binary, 100 ) ,
				new mss.SqlMetaData( "the_bit", sd.SqlDbType.Bit ) ,
				new mss.SqlMetaData( "the_char", sd.SqlDbType.Char, 100 ) ,
				new mss.SqlMetaData( "the_date", sd.SqlDbType.Date ) ,
				new mss.SqlMetaData( "the_datetime", sd.SqlDbType.DateTime ) ,
				new mss.SqlMetaData( "the_datetime2", sd.SqlDbType.DateTime2 ) ,
				new mss.SqlMetaData( "the_datetimeoffset", sd.SqlDbType.DateTimeOffset ) ,
				new mss.SqlMetaData( "the_decimal", sd.SqlDbType.Decimal, 28, 12 ) ,
				new mss.SqlMetaData( "the_float", sd.SqlDbType.Float ) ,
				new mss.SqlMetaData( "the_geography", sd.SqlDbType.NVarChar, -1 ) ,
				new mss.SqlMetaData( "the_geometry", sd.SqlDbType.NVarChar, -1 ) ,
				new mss.SqlMetaData( "the_hierarchyid", sd.SqlDbType.NVarChar, -1 ) ,
				new mss.SqlMetaData( "the_image", sd.SqlDbType.Image ) ,
				new mss.SqlMetaData( "the_int", sd.SqlDbType.Int ) ,
				new mss.SqlMetaData( "the_money", sd.SqlDbType.Money ) ,
				new mss.SqlMetaData( "the_nchar", sd.SqlDbType.NChar, 100 ) ,
				new mss.SqlMetaData( "the_ntext", sd.SqlDbType.NText ) ,
				new mss.SqlMetaData( "the_numeric", sd.SqlDbType.Decimal, 28, 12 ) ,
				new mss.SqlMetaData( "the_nvarchar", sd.SqlDbType.NVarChar, 100 ) ,
				new mss.SqlMetaData( "the_real", sd.SqlDbType.Real ) ,
				new mss.SqlMetaData( "the_smalldatetime", sd.SqlDbType.SmallDateTime ) ,
				new mss.SqlMetaData( "the_smallint", sd.SqlDbType.SmallInt ) ,
				new mss.SqlMetaData( "the_smallmoney", sd.SqlDbType.SmallMoney ) ,
				new mss.SqlMetaData( "the_sql_variant", sd.SqlDbType.Variant ) ,
				new mss.SqlMetaData( "the_text", sd.SqlDbType.Text ) ,
				new mss.SqlMetaData( "the_time", sd.SqlDbType.Time ) ,
				new mss.SqlMetaData( "the_tinyint", sd.SqlDbType.TinyInt ) ,
				new mss.SqlMetaData( "the_uniqueidentifier", sd.SqlDbType.UniqueIdentifier ) ,
				new mss.SqlMetaData( "the_varbinary", sd.SqlDbType.VarBinary, 100 ) ,
				new mss.SqlMetaData( "the_varchar", sd.SqlDbType.VarChar, 100 ) ,
				new mss.SqlMetaData( "the_xml", sd.SqlDbType.Xml ) ,
				new mss.SqlMetaData( "the_timestamp", sd.SqlDbType.Timestamp, true, false, sds.SortOrder.Unspecified, -1 ) 
			) ;
			 
			foreach ( var i in this._list ) 
			{
				if ( i.the_bigint == null )
					sdr.SetDBNull( 0 ) ;
				else
					sdr.SetInt64( 0, i.the_bigint.Value ) ; 
			 
				if ( i.the_binary == null )
					sdr.SetDBNull( 1 ) ;
				else
					sdr.SetBytes( 1, 0, i.the_binary, 0, i.the_binary.Length ) ; 
			 
				if ( i.the_bit == null )
					sdr.SetDBNull( 2 ) ;
				else
					sdr.SetBoolean( 2, i.the_bit.Value ) ; 
			 
				if ( i.the_char == null )
					sdr.SetDBNull( 3 ) ;
				else
					sdr.SetString( 3, i.the_char ) ; 
			 
				if ( i.the_date == null )
					sdr.SetDBNull( 4 ) ;
				else
					sdr.SetDateTime( 4, i.the_date.Value ) ; 
			 
				if ( i.the_datetime == null )
					sdr.SetDBNull( 5 ) ;
				else
					sdr.SetDateTime( 5, i.the_datetime.Value ) ; 
			 
				if ( i.the_datetime2 == null )
					sdr.SetDBNull( 6 ) ;
				else
					sdr.SetDateTime( 6, i.the_datetime2.Value ) ; 
			 
				if ( i.the_datetimeoffset == null )
					sdr.SetDBNull( 7 ) ;
				else
					sdr.SetDateTimeOffset( 7, i.the_datetimeoffset.Value ) ; 
			 
				if ( i.the_decimal == null )
					sdr.SetDBNull( 8 ) ;
				else
					sdr.SetDecimal( 8, i.the_decimal.Value ) ; 
			 
				if ( i.the_float == null )
					sdr.SetDBNull( 9 ) ;
				else
					sdr.SetDouble( 9, i.the_float.Value ) ; 
			 
				if ( i.the_geography == null )
					sdr.SetDBNull( 10 ) ;
				else
					sdr.SetValue( 10, i.the_geography.ToString() ) ; 
			 
				if ( i.the_geometry == null )
					sdr.SetDBNull( 11 ) ;
				else
					sdr.SetValue( 11, i.the_geometry.ToString() ) ; 
			 
				if ( i.the_hierarchyid == null )
					sdr.SetDBNull( 12 ) ;
				else
					sdr.SetValue( 12, i.the_hierarchyid.ToString() ) ; 
			 
				if ( i.the_image == null )
					sdr.SetDBNull( 13 ) ;
				else
					sdr.SetBytes( 13, 0, i.the_image, 0, i.the_image.Length ) ; 
			 
				if ( i.the_int == null )
					sdr.SetDBNull( 14 ) ;
				else
					sdr.SetInt32( 14, i.the_int.Value ) ; 
			 
				if ( i.the_money == null )
					sdr.SetDBNull( 15 ) ;
				else
					sdr.SetDecimal( 15, i.the_money.Value ) ; 
			 
				if ( i.the_nchar == null )
					sdr.SetDBNull( 16 ) ;
				else
					sdr.SetString( 16, i.the_nchar ) ; 
			 
				if ( i.the_ntext == null )
					sdr.SetDBNull( 17 ) ;
				else
					sdr.SetString( 17, i.the_ntext ) ; 
			 
				if ( i.the_numeric == null )
					sdr.SetDBNull( 18 ) ;
				else
					sdr.SetDecimal( 18, i.the_numeric.Value ) ; 
			 
				if ( i.the_nvarchar == null )
					sdr.SetDBNull( 19 ) ;
				else
					sdr.SetString( 19, i.the_nvarchar ) ; 
			 
				if ( i.the_real == null )
					sdr.SetDBNull( 20 ) ;
				else
					sdr.SetFloat( 20, i.the_real.Value ) ; 
			 
				if ( i.the_smalldatetime == null )
					sdr.SetDBNull( 21 ) ;
				else
					sdr.SetDateTime( 21, i.the_smalldatetime.Value ) ; 
			 
				if ( i.the_smallint == null )
					sdr.SetDBNull( 22 ) ;
				else
					sdr.SetInt16( 22, i.the_smallint.Value ) ; 
			 
				if ( i.the_smallmoney == null )
					sdr.SetDBNull( 23 ) ;
				else
					sdr.SetDecimal( 23, i.the_smallmoney.Value ) ; 
			 
				if ( i.the_sql_variant == null )
					sdr.SetDBNull( 24 ) ;
				else
					sdr.SetValue( 24, i.the_sql_variant.ToString() ) ; 
			 
				if ( i.the_text == null )
					sdr.SetDBNull( 25 ) ;
				else
					sdr.SetString( 25, i.the_text ) ; 
			 
				if ( i.the_time == null )
					sdr.SetDBNull( 26 ) ;
				else
					sdr.SetValue( 26, i.the_time.Value ) ; 
			 
				if ( i.the_tinyint == null )
					sdr.SetDBNull( 27 ) ;
				else
					sdr.SetByte( 27, i.the_tinyint.Value ) ; 
			 
				if ( i.the_uniqueidentifier == null )
					sdr.SetDBNull( 28 ) ;
				else
					sdr.SetGuid( 28, i.the_uniqueidentifier.Value ) ; 
			 
				if ( i.the_varbinary == null )
					sdr.SetDBNull( 29 ) ;
				else
					sdr.SetBytes( 29, 0, i.the_varbinary, 0, i.the_varbinary.Length ) ; 
			 
				if ( i.the_varchar == null )
					sdr.SetDBNull( 30 ) ;
				else
					sdr.SetString( 30, i.the_varchar ) ; 
			 
				if ( i.the_xml == null )
					sdr.SetDBNull( 31 ) ;
				else
					sdr.SetString( 31, i.the_xml ) ; 
			 
				if ( i.the_timestamp == null )
					sdr.SetDBNull( 32 ) ;
				else
					sdr.SetBytes( 32, 0, i.the_timestamp, 0, i.the_timestamp.Length ) ; 
			 
				yield return sdr ; 
			}
			 
		}

	}

}

