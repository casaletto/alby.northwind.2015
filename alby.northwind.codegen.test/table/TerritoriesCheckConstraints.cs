using System;
using System.Collections.Generic;
using System.IO ;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Transactions ;

using NUnit.Framework ;

using NW = alby.northwind.codegen  ;

namespace alby.northwind.codegen.test.table
{
	[TestFixture]
	public class TerritoriesCheckConstraints : NW.test.TransactionScopeTestBase
	{
		public TerritoriesCheckConstraints()
		{
			_connectionString = Settings.ConnectionString();
		}

		[Test]
		public void InsertRegionThenTerritory()
		{
			var factoryRegion = new NW.table.RegionFactory() ;
			var factoryTerritories = new NW.table.TerritoriesFactory() ;

			var rowRegion = new NW.table.Region() ;
			rowRegion.RegionID = -1 ;
			rowRegion.RegionDescription = "fred" ;
			rowRegion = factoryRegion.Saveˡ( _connection, rowRegion ) ; 

			var rowTerritory = new NW.table.Territories() ;
			rowTerritory.TerritoryID = "R2D2" ;
			rowTerritory.RegionID = -1 ;
			rowTerritory.TerritoryDescription  = "fred" ;

			rowRegion = factoryRegion.Saveˡ( _connection, rowRegion ) ; 
			rowTerritory = factoryTerritories.Saveˡ( _connection, rowTerritory ) ; 
		}

		[Test, ExpectedException( MatchType = MessageMatch.Regex, ExpectedMessage = "The INSERT statement conflicted with the FOREIGN KEY constraint" )]
		public void InsertTerritoryThenRegionWithCheckConstraintsEnabled()
		{
			var factoryRegion = new NW.table.RegionFactory() ;
			var factoryTerritories = new NW.table.TerritoriesFactory() ;

			var rowTerritory = new NW.table.Territories() ;
			rowTerritory.TerritoryID = "R2D2" ;
			rowTerritory.RegionID = -1 ;
			rowTerritory.TerritoryDescription  = "fred" ;

			rowTerritory = factoryTerritories.Saveˡ( _connection, rowTerritory ) ; 
		}

		[Test]
		public void InsertTerritoryThenRegionWithCheckConstraintsDisabled()
		{

			var factoryRegion = new NW.table.RegionFactory() ;
			var factoryTerritories = new NW.table.TerritoriesFactory() ;

			var rowTerritory = new NW.table.Territories() ;
			rowTerritory.TerritoryID = "R2D2" ;
			rowTerritory.RegionID = -1 ;
			rowTerritory.TerritoryDescription  = "fred" ;
			 
			var rowRegion = new NW.table.Region() ;
			rowRegion.RegionID = -1 ;
			rowRegion.RegionDescription = "fred" ;

			// the bogus save
			try
			{
				factoryTerritories.SetCheckConstraintsˡ( _connection, false ) ;

				rowTerritory = factoryTerritories.Saveˡ( _connection, rowTerritory ) ; 
				rowRegion = factoryRegion.Saveˡ( _connection, rowRegion ) ; 
			}
			finally 
			{
				factoryTerritories.SetCheckConstraintsˡ( _connection, true ) ;
			}
		}

	} // end class
}
