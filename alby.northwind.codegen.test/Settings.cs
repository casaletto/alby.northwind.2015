using System;
using System.Collections.Generic;
using System.Text;
using System.Data ;
using System.Data.Common ;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Transactions;
using System.Net ;

using NUnit.Framework;

namespace alby.northwind.codegen.test
{
	[TestFixture]
	public class Settings
	{
		public Settings()
		{
		}

        public static string ConnectionString() // this is the main connection string
		{
            return GetConnectionString( "localhost", SQL_SERVER_INSTANCE, NORTHWIND_DATABASE ) ;
		}

		public static string ConnectionStringNorthwindClone()
		{
            return GetConnectionString( "localhost", SQL_SERVER_INSTANCE, NORTHWIND_CLONE_DATABASE ) ;
		}

        protected static string SQL_SERVER_INSTANCE         = @"" ; // "SQLEXPRESS" ;
        protected static string NORTHWIND_DATABASE          = @"Northwind"  ;
        protected static string NORTHWIND_CLONE_DATABASE    = @"NorthwindClone"  ;
        protected static string UID                         = @"datareader" ;
        protected static string PWD                         = @"datareader" ;

		protected static string BASE_CONNECTION_STRING = @"Data Source={0}{1};Initial Catalog={2};Network Library=DBMSSOCN;Type System Version=SQL Server 2012;";

        #region helpers

        protected static string GetConnectionString( string server, string instance, string database )
        {
            if ( instance.Length > 0 )
                instance = @"\" + instance ; 

            return string.Format( BASE_CONNECTION_STRING, server, instance, database ) + "Integrated Security=SSPI;" ;
        }

        protected static string GetConnectionString( string server, string instance, string database, string uid, string pwd )
        {
            if ( instance.Length > 0 )
                instance = @"\" + instance ; 

            return string.Format( BASE_CONNECTION_STRING, server, instance, database ) + 
                   string.Format( "User Id={0};Password={1};", uid, pwd ) ;
        }

        protected void TestConnection()
        {
        }

        #endregion

        #region database connection tests

/*
// USE Northwind  ; EXEC sp_revokedbaccess 'datareader' ; EXEC sp_grantdbaccess 'datareader' ; 
// user master ; grant view server state to [datareader]
 
use northwind 
 
select * 
from sys.schemas s
where s.principal_id = user_id( 'datareader')

alter authorization on schema::db_owner to dbo

drop user datareader
 */
		protected void DoConnectionTest( string connectionString )
        {
			Console.WriteLine("Connecting to [{0}]", connectionString); 

            string netTransport = "" ;
            string sql = @"select * from sys.dm_exec_connections where session_id = @@spid" ; 
            // user master ; grant view server state to [datareader]

            using ( SqlConnection conn = new SqlConnection( connectionString ))
            {
                conn.Open() ;
				using (SqlCommand cmd = new SqlCommand(sql, conn))
				{
					cmd.CommandTimeout = 10 ; // 10 secs to connect
					using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable() ;
						da.Fill( table );
      
                        Assert.IsTrue( table.Rows.Count > 0, "Did not get any connection data back." ) ;
                        DataRow row = table.Rows[0]  ;

                        foreach( string colname in  new string[] {  "net_transport", 
                                                                    "net_packet_size", 
                                                                    "client_net_address", 
                                                                    "client_tcp_port", 
                                                                    "local_net_address", 
                                                                    "local_tcp_port" } )
                        {
                            DataColumn col = table.Columns[ colname ] ;
                            Console.WriteLine( "{0}=[{1}]", col.ColumnName, row[ col.ColumnName ].ToString() ) ; 
                        }
                        netTransport = row[ "net_transport" ].ToString() ;
                    }
				}
            }

            // make sure connection was tcp ip
            Assert.AreEqual( "TCP", netTransport ) ;
            Console.WriteLine( "Connected ok.") ;
        }

        [Test]
        public void NorthwindConnectionString()
        {
            string connectionString = Settings.ConnectionString() ;
            DoConnectionTest( connectionString ) ;
        }

        [Test, Explicit ]
        public void NorthwindCloneConnectionString()
        {
            string connectionString = Settings.ConnectionStringNorthwindClone() ;
            DoConnectionTest( connectionString ) ;
        }

        [Test]
        public void SqlServerConnection_Northwind_Localhost()
        {
            string connectionString = GetConnectionString( "localhost", SQL_SERVER_INSTANCE, NORTHWIND_DATABASE ) ;
            DoConnectionTest( connectionString ) ;
        }

		// WTF
		// Connecting to [Data Source=::1;Initial Catalog=Northwind;Network Library=DBMSSOCN;Integrated Security=SSPI;]
		// Test 'alby.northwind.codegen.test.Settings.SqlServerConnection_Northwind_ColonColon1' failed: System.Data.SqlClient.SqlException : 
		// Login failed. The login is from an untrusted domain and cannot be used with Windows authentication.
		//
        [Test]
        public void SqlServerConnection_Northwind_ColonColon1()
        {
            string connectionString = GetConnectionString( "::1", SQL_SERVER_INSTANCE, NORTHWIND_DATABASE ) ;
            DoConnectionTest( connectionString ) ;
        }

		[Test, ExpectedException(typeof(SqlException), ExpectedMessage = "Login failed. The login is from an untrusted domain and cannot be used with Windows authentication.")]
		//[Test]
        public void SqlServerConnection_Northwind_127_0_0_1()
        {
            string connectionString = GetConnectionString( "127.0.0.1", SQL_SERVER_INSTANCE, NORTHWIND_DATABASE ) ;
            DoConnectionTest( connectionString ) ;
        }

        [Test]
        public void SqlServerConnection_Northwind_DnsName()
        {
            string connectionString = GetConnectionString( Environment.MachineName, SQL_SERVER_INSTANCE, NORTHWIND_DATABASE ) ;
            DoConnectionTest( connectionString ) ;
        }

        [Test, ExpectedException( typeof(SqlException), ExpectedMessage="Login failed. The login is from an untrusted domain and cannot be used with Windows authentication." ) ]
        //[Test]
        public void SqlServerConnection_Northwind_Ip4Address_IntegratedSecurity() //_NegativeTest()
        {
            //try
            {
                foreach ( IPAddress address in Dns.GetHostAddresses( "" ) )
                    if ( address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork )
                    {
                        string connectionString = GetConnectionString( address.ToString(), SQL_SERVER_INSTANCE, NORTHWIND_DATABASE ) ;
                        DoConnectionTest( connectionString ) ;
                    }
            }
            //catch( SqlException ex )
            //{
            //    Assert.IsTrue( ex.Message.ToUpper().Contains( "LOGIN FAILED" ) ) ;
            //    return ;
            //}

            //Assert.Fail( "Expected login failed error message." ) ;
        }

        //[Test, ExpectedException( typeof(SqlException), ExpectedMessage="Login failed. The login is from an untrusted domain and cannot be used with Windows authentication." ) ]
        [Test]
        public void SqlServerConnection_Northwind_Ip6Address_IntegratedSecurity() //_NegativeTest()
        {
            //try
            {
                foreach ( IPAddress address in Dns.GetHostAddresses( "" ) )
                    if ( address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6 )
                    {
                        string connectionString = GetConnectionString( address.ToString(), SQL_SERVER_INSTANCE, NORTHWIND_DATABASE ) ;
                        DoConnectionTest( connectionString ) ;
                    }
            }
        //    catch( SqlException ex )
        //    {
        //        Assert.IsTrue( ex.Message.ToUpper().Contains( "LOGIN FAILED" ) ) ;
        //        return ;
        //    }

        //    Assert.Fail( "Expected login failed error message." ) ;
        }

        [Test]    
        public void SqlServerConnection_Northwind_Ip4Address_SqlServerSecurity()
        {
            foreach ( IPAddress address in Dns.GetHostAddresses( "" ) )
                if ( address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork )
                {
                    string connectionString = GetConnectionString( address.ToString(), SQL_SERVER_INSTANCE, NORTHWIND_DATABASE, UID, PWD ) ;
                    DoConnectionTest( connectionString ) ;
                }
        }

        [Test]
        public void SqlServerConnection_Northwind_Ip6Address_SqlServerSecurity()
        {
            foreach ( IPAddress address in Dns.GetHostAddresses( "" ) )
                if ( address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6 )
                {
                    string connectionString = GetConnectionString( address.ToString(), SQL_SERVER_INSTANCE, NORTHWIND_DATABASE, UID, PWD ) ;
                    DoConnectionTest( connectionString ) ;
                }
        }
        
        #endregion

	}
}

