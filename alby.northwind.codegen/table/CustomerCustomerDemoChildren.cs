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
	public partial class CustomerCustomerDemo : acr.RowBase
	{
		public CustomerDemographics parent٠CustomerDemographics٠By٠CustomerTypeID( sds.SqlConnection connˡ, sds.SqlTransaction tranˡ = null )
		{
			CustomerDemographicsFactory factoryˡ = new CustomerDemographicsFactory() ; 
			return factoryˡ.LoadByPrimaryKeyˡ
			(
				connˡ,
				this.CustomerTypeID, 
				tranˡ
			) ;
		}

		public Customers parent٠Customers٠By٠CustomerID( sds.SqlConnection connˡ, sds.SqlTransaction tranˡ = null )
		{
			CustomersFactory factoryˡ = new CustomersFactory() ; 
			return factoryˡ.LoadByPrimaryKeyˡ
			(
				connˡ,
				this.CustomerID, 
				tranˡ
			) ;
		}

	}

}

