using System;
using System.Collections.Generic;
using System.IO ;
using System.Text;
using System.Xml ;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Transactions ;
using NUnit.Framework ;

using ACR = alby.codegen.runtime;
using NW = alby.northwind.codegen  ;

namespace alby.northwind.codegen.test.table
{	
	[TestFixture  ]
	public class TestTable4BigLoad 
	{
		protected string				_connectionString  ;
		protected TransactionOptions	_transactionOptions = new TransactionOptions() ;
		
		[SetUp]
		public void Setup()
		{
			ACR.CodeGenEtc.DebugSql = false;
		}

		[TearDown]
		public void TearDown()
		{
		}

		
		public TestTable4BigLoad()
		{
			_connectionString = Settings.ConnectionString();
			_transactionOptions.IsolationLevel = IsolationLevel.Serializable;
		}
		
		protected const string UNICODE_TEXT_FILE = @"c:\albyStuff\development\alby.northwind.2015\doc\alp-ch04-threads.txt";
		protected const string JPEG_IMAGE_FILE = @"c:\albyStuff\development\alby.northwind.2015\doc\tarantula_eso_big.jpg";

		[Test]
		public void TestInsertBigNText()
		{
			NW.table.TestTable4Factory factory = new NW.table.TestTable4Factory();

			Guid pk = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa0");

			// load test file from file system
			string text = File.ReadAllText(UNICODE_TEXT_FILE, Encoding.Unicode);
			Assert.IsNotNull(text);
			Console.WriteLine("Inserting text file [{0}] into database, size = [{1}] bytes", UNICODE_TEXT_FILE, text.Length);
			Assert.IsTrue(text.Length > 50000); // need something very big

			using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.RequiresNew, _transactionOptions))
			{
				using ( SqlConnection connection = new SqlConnection(_connectionString))
				{
					connection.Open() ;

					NW.table.TestTable4 row = factory.LoadByPrimaryKeyˡ(connection, pk);
					if ( row != null )
					{
						row.MarkForDeletionˡ = true ;
						factory.Saveˡ( connection, row ) ; // delete if already exists
					}

					row = new NW.table.TestTable4() ;
					row.ID = pk ;
					row.f_ntext = text ;
					factory.Saveˡ( connection, row ) ; // insert it
				
					transaction.Complete() ; // commit
				}		
			}

			// read it back - start another connection
			using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.RequiresNew, _transactionOptions))
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					connection.Open();
					
					NW.table.TestTable4 row = factory.LoadByPrimaryKeyˡ(connection, pk);
					Assert.IsNotNull( row ) ;
					Assert.AreEqual( row.ID, pk ) ;
					
					string text2 = row.f_ntext ;
					Assert.IsNotNull(text2);
					Assert.AreEqual( text, text2 ) ;
				}
			}
			
		}
	
		[Test]
		public void TestInsertBigText()
		{
			NW.table.TestTable4Factory factory = new NW.table.TestTable4Factory();

			Guid pk = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa1");

			// load test file from file system
			string text = File.ReadAllText(UNICODE_TEXT_FILE, Encoding.Unicode);
			Assert.IsNotNull(text);
			Console.WriteLine("Inserting text file [{0}] into database, size = [{1}] bytes", UNICODE_TEXT_FILE, text.Length);
			Assert.IsTrue(text.Length > 50000); // need something very big

			using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.RequiresNew, _transactionOptions))
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					connection.Open();
					
					NW.table.TestTable4 row = factory.LoadByPrimaryKeyˡ(connection, pk);
					if (row != null)
					{
						row.MarkForDeletionˡ = true;
						factory.Saveˡ( connection, row ); // delete if already exists
					}

					row = new NW.table.TestTable4();
					row.ID = pk;
					row.f_text = text;
					factory.Saveˡ( connection, row ); // insert it

					transaction.Complete(); // commit
				}
			}

			// read it back - start another connection
			using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.RequiresNew, _transactionOptions))
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					connection.Open();
					
					NW.table.TestTable4 row = factory.LoadByPrimaryKeyˡ(connection, pk);
					Assert.IsNotNull(row);
					Assert.AreEqual(row.ID, pk);

					string text2 = row.f_text;
					Assert.IsNotNull(text2);
					Assert.AreEqual(text, text2);
				}
			}
		}

		[Test]
		public void TestInsertBigXml()
		{
			NW.table.TestTable4Factory factory = new NW.table.TestTable4Factory();

			Guid pk = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa2");

			// load test file from file system
			string text = File.ReadAllText(UNICODE_TEXT_FILE, Encoding.Unicode);
			Assert.IsNotNull(text);

			XmlDocument doc = new XmlDocument() ;
			XmlElement root = doc.CreateElement( "root" ) ;
			root.InnerText = text ;
			doc.AppendChild( root ) ;

			text = root.OuterXml ;
			
			Console.WriteLine("Inserting text file [{0}] into database, size = [{1}] bytes", UNICODE_TEXT_FILE, text.Length);
			Assert.IsTrue(text.Length > 50000); // need something very big

			using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.RequiresNew, _transactionOptions))
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					connection.Open();
					
					NW.table.TestTable4 row = factory.LoadByPrimaryKeyˡ(connection, pk);
					if (row != null)
					{
						row.MarkForDeletionˡ = true;
						factory.Saveˡ( connection, row ); // delete if already exists
					}

					row = new NW.table.TestTable4();
					row.ID = pk;
					row.f_xml = text;
					factory.Saveˡ( connection, row ); // insert it

					transaction.Complete(); // commit
				}
			}

			// read it back - start another connection
			using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.RequiresNew, _transactionOptions))
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					connection.Open();
					
					NW.table.TestTable4 row = factory.LoadByPrimaryKeyˡ(connection, pk);
					Assert.IsNotNull(row);
					Assert.AreEqual(row.ID, pk);

					string text2 = row.f_xml;
					Assert.IsNotNull(text2);
					Assert.AreEqual(text, text2);
				}
			}
		}

		[Test]
		public void TestInsertBigImage()
		{
			NW.table.TestTable4Factory factory = new NW.table.TestTable4Factory();

			Guid pk = new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa3");

			// load test file from file system
			byte[] image = File.ReadAllBytes(JPEG_IMAGE_FILE);
			Assert.IsNotNull(image);

			Console.WriteLine("Inserting image file [{0}] into database, size = [{1}] bytes", JPEG_IMAGE_FILE, image.Length);
			Assert.IsTrue(image.Length > 50000); // need something very big

			using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.RequiresNew, _transactionOptions))
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					connection.Open();
					
					NW.table.TestTable4 row = factory.LoadByPrimaryKeyˡ(connection, pk);
					if (row != null)
					{
						row.MarkForDeletionˡ = true;
						factory.Saveˡ( connection, row ); // delete if already exists
					}

					row = new NW.table.TestTable4();
					row.ID = pk;
					row.f_image = image ;
					factory.Saveˡ( connection, row ); // insert it

					transaction.Complete(); // commit
				}
			}

			// read it back - start another connection
			using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.RequiresNew, _transactionOptions))
			{
				using (SqlConnection connection = new SqlConnection(_connectionString))
				{
					connection.Open();
					
					NW.table.TestTable4 row = factory.LoadByPrimaryKeyˡ(connection, pk);
					Assert.IsNotNull(row);
					Assert.AreEqual(row.ID, pk);

					byte[] image2 = row.f_image;
					Assert.IsNotNull(image2);
					Assert.AreEqual(image.Length, image2.Length);
					
					string hash1 = Convert.ToBase64String( Hash(image ) ) ;
					string hash2 = Convert.ToBase64String( Hash(image2) );
					Assert.AreEqual(hash1, hash2);
				}
			}
		}
		
		#region helpers
		
		protected byte[] Hash( byte[] bytes )
		{
			System.Security.Cryptography.SHA512Managed hash = new System.Security.Cryptography.SHA512Managed();
			return hash.ComputeHash( bytes ) ;
		}
		
		protected byte[] Hash( string str )
		{
			return this.Hash( System.Text.Encoding.Unicode.GetBytes( str )  ) ;		
		}

		#endregion
	}
}