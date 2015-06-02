using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Reflection;
using System.Transactions;
using Microsoft.SqlServer.Types;

using NUnit.Framework;
using alby.codegen.runtime;

using db = alby.northwind.codegen.database ;
using t  = alby.northwind.codegen.table  ;

namespace alby.northwind.codegen.test.table
{
	[TestFixture]
	public class UnicodeFruitTest : CodeGenUnitTestBase
	{
		#region setup

		public UnicodeFruitTest() : base()
		{}

		public override string ConnectionString
		{
			get
			{
				return ( new CodeGenUnitTestClass() ).ConnectionString ; 
			}
		}

		public override bool QuietMode
		{
			get
			{
				return true ;
			}
		}

		public override bool DisableTriggers
		{
			get
			{
				return false ;
			}
		}

		public override bool DisableCheckConstraints
		{
			get
			{
				return false ;
			}
		}

		public override void SetUp()
		{
			base.SetUp() ;
		}

		#endregion

		public void SetupData()
		{
			t.フル_ツFactory factory = new t.フル_ツFactory() ;
			factory.Truncateˡ( _connection ) ;
			Assert.AreEqual( 0, factory.GetRowCountˡ( _connection ) ) ;

			List<t.フル_ツ> list = new List<t.フル_ツ>() ;
			list.Add( new t.フル_ツ() 
				{ 	
					fruit		= "apple", 
					フル_ツ_		= "リンゴ", 
					פרי			= "תפוח",
					καρπός		= "μήλο", 
					update_date = DateTime.Now 
				} 
			) ;
			list.Add( new t.フル_ツ() 
				{ 	
					fruit		= "banana", 
					フル_ツ_		= "バナナ", 
					פרי			= "בננה",
					καρπός		= "μπανάνα", 
					update_date = DateTime.Now 
				} 
			) ;
			list.Add( new t.フル_ツ() 
				{ 	
					fruit		= "cherry", 
					フル_ツ_		= "チェリー", 
					פרי			= "דובדבן",
					καρπός		= "κεράσι", 
					update_date = DateTime.Now 
				} 
			) ;

			list.Add( new t.フル_ツ() 
				{ 	
					fruit		= "lemon", 
					フル_ツ_		= "レモン", 
					פרי			= "לימון",
					καρπός		= "λεμόνι", 
					update_date = DateTime.Now 
				} 
			) ;

			list.Add( new t.フル_ツ() 
				{ 	
					fruit		= "mango", 
					フル_ツ_		= "マンゴー", 
					פרי			= "מנגו",
					καρπός		= "μάνγκο", 
					update_date = DateTime.Now 
				} 
			) ;
			list.Add( new t.フル_ツ() 
				{ 	
					fruit		= "orange", 
					フル_ツ_		= "オレンジ", 
					פרי			= "תפוז",
					καρπός		= "πορτοκάλι", 
					update_date = DateTime.Now 
				} 
			) ;
			list.Add( new t.フル_ツ() 
				{ 	
					fruit		= "pear", 
					フル_ツ_		= "梨", 
					פרי			= "אגס",
					καρπός		= "αχλάδι", 
					update_date = DateTime.Now 
				} 
			) ;
			list.Add( new t.フル_ツ() 
				{ 	
					fruit		= "watermelon", 
					フル_ツ_		= "スイカ", 
					פרי			= "אבטיח",
					καρπός		= "καρπούζι", 
					update_date = DateTime.Now 
				} 
			) ;

			factory.Saveˡ( _connection, list ) ;
			Assert.AreEqual( list.Count, factory.GetRowCountˡ( _connection ) ) ;
		}

		[Test]
		public void UnicodeTopNSortFruitTest()
		{
			SetupData() ;
			var factory = new t.フル_ツFactory() ;

			// turn on sql debug to dbmon or dbgview (windows api ::OutputDebugString)
			CodeGenEtc.DebugSql = true ; 

			// top 1, sorted by english fruit asc
			var order = new List<CodeGenOrderBy>() ;
			order.Add( new CodeGenOrderBy( t.フル_ツ.column٠fruit, CodeGenSort.Asc ) ) ;
			var list = factory.Loadˡ( _connection, 1, order ) ;
			Console.WriteLine( CodeGenEtc.Sql ) ;
			Assert.AreEqual( 1, list.Count ) ;
			Console.WriteLine( list[0].fruit ) ;
			Assert.AreEqual( list[0].fruit, "apple" ) ;

			// top 1, sorted by english fruit desc
			order = new List<CodeGenOrderBy>() ;
			order.Add( new CodeGenOrderBy( t.フル_ツ.column٠fruit, CodeGenSort.Desc ) ) ;
			list = factory.Loadˡ( _connection, 1, order ) ;
			Console.WriteLine( CodeGenEtc.Sql ) ;
			Assert.AreEqual( 1, list.Count ) ;
			Console.WriteLine( list[0].fruit ) ;
			Assert.AreEqual( list[0].fruit, "watermelon" ) ;

			// top 1, sorted by greek fruit asc
			order = new List<CodeGenOrderBy>() ;
			order.Add( new CodeGenOrderBy( t.フル_ツ.column٠καρπός, CodeGenSort.Asc ) ) ;
			list = factory.Loadˡ( _connection, 1, order ) ;
			Console.WriteLine( CodeGenEtc.Sql ) ;
			Assert.AreEqual( 1, list.Count ) ;
			Console.WriteLine( "{0} ({1})", list[0].καρπός, list[0].fruit ) ;
			Assert.AreEqual( list[0].καρπός, "αχλάδι" ) ; // pear

			// top 1, sorted by greek fruit desc
			order = new List<CodeGenOrderBy>() ;
			order.Add( new CodeGenOrderBy( t.フル_ツ.column٠καρπός, CodeGenSort.Desc ) ) ;
			list = factory.Loadˡ( _connection, 1, order ) ;
			Console.WriteLine( CodeGenEtc.Sql ) ;
			Assert.AreEqual( 1, list.Count ) ;
			Console.WriteLine( "{0} ({1})", list[0].καρπός, list[0].fruit ) ;
			Assert.AreEqual( list[0].καρπός, "πορτοκάλι" ) ; // orange

			// top 1, sorted by japanese fruit asc
			order = new List<CodeGenOrderBy>() ;
			order.Add( new CodeGenOrderBy( t.フル_ツ.column٠フル_ツ_, CodeGenSort.Asc ) ) ;
			list = factory.Loadˡ( _connection, 1, order ) ;
			Console.WriteLine( CodeGenEtc.Sql ) ; // select top 1 * from [Northwind].[dbo].[フルーツ] t order by [フルーツ] Asc

			Assert.AreEqual( 1, list.Count ) ;
			Console.WriteLine( "{0} ({1})", list[0].フル_ツ_, list[0].fruit ) ;
			Assert.AreEqual( list[0].フル_ツ_, "オレンジ" ) ; // orange

			// top 1, sorted by japanese fruit desc
			order = new List<CodeGenOrderBy>() ;
			order.Add( new CodeGenOrderBy( t.フル_ツ.column٠フル_ツ_, CodeGenSort.Desc ) ) ;
			list = factory.Loadˡ( _connection, 1, order ) ;
			Console.WriteLine( CodeGenEtc.Sql ) ; // select top 1 * from [Northwind].[dbo].[フルーツ] t order by [フルーツ] Desc
			Assert.AreEqual( 1, list.Count ) ;
			Console.WriteLine( "{0} ({1})", list[0].フル_ツ_, list[0].fruit ) ;
			Assert.AreEqual( list[0].フル_ツ_, "梨" ) ; // pear

			// freestyle where clause
			list = factory.LoadByWhereˡ( _connection, "where t.[フルーツ] = N'梨' " ) ;
			Assert.AreEqual( 1, list.Count ) ;
		}


	} // end class

}

