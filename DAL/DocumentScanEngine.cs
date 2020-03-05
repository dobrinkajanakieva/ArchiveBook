using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.SQLServer
{
	public class DocumentScanEngine : DBClass, IDocumentScanEngine
	{
		public DocumentScanEngine()  
			: base() { }  

		#region Functions

		public List<DocumentScan> GetDocuments()
		{
			List<DocumentScan> result = new List<DocumentScan>();

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				string sql = "SELECT * FROM DocumentScan";
				command = new SqlCommand(sql, connection);

				using (reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						DocumentScan document = new DocumentScan(reader.GetInt32("ID_DocumentScan"), reader.GetInt32("ID_ArchiveBooking"), reader.GetString("DocumentPath"));

						result.Add(document);
					}
				}
				reader.Close();
				command.Dispose();
				connection.Close();
			}

			return result;
		}

		public DocumentScan GetDocumentByID(int id)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("No such document.");

			DocumentScan result = new DocumentScan();

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				string sql = "SELECT * FROM DocumentScan WHERE ID_DocumentScan = @id";
				command = new SqlCommand(sql, connection);
				command.Parameters.AddWithValue("@id", id);

				using (reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						result.ID_DocumentScan = reader.GetInt32("ID_DocumentScan");
						result.ID_ArchiveBooking = reader.GetInt32("ID_ArchiveBooking");
						result.DocumentPath = reader.GetString("DocumentPath");
					}
				}
				reader.Close();
				command.Dispose();
				connection.Close();
			}

			return result;
		}

		public List<DocumentScan> GetDocumentsByArchiveBooking(int id)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("No such document.");

			List<DocumentScan> result = new List<DocumentScan>();

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				string sql = "SELECT * FROM DocumentScan WHERE ID_ArchiveBooking = @id";
				command = new SqlCommand(sql, connection);
				command.Parameters.AddWithValue("@id", id);

				using (reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						DocumentScan document = new DocumentScan(reader.GetInt32("ID_DocumentScan"), reader.GetInt32("ID_ArchiveBooking"), reader.GetString("DocumentPath"));

						result.Add(document);
					}
				}
				reader.Close();
				command.Dispose();
				connection.Close();
			}

			return result;
		}

		public void InsertDocument(DocumentScan document)
		{
			if (document == null)
				throw new IndexOutOfRangeException("Empty document.");

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (adapter = new SqlDataAdapter())
				{
					string sql = "INSERT INTO DocumentScan(ID_ArchiveBooking, DocumentPath) VALUES(@id, @path)";
					command = new SqlCommand(sql, connection);
					command.Parameters.AddWithValue("@id", document.ID_ArchiveBooking);
					command.Parameters.AddWithValue("@path", document.DocumentPath);
					adapter.InsertCommand = command;
					adapter.InsertCommand.ExecuteNonQuery();
				}
				command.Dispose();
				connection.Close();
			}
		}

		public void InsertDocuments(List<DocumentScan> documents)
		{
			if (documents.Count == 0)
				throw new IndexOutOfRangeException("No documents.");

			foreach (DocumentScan document in documents)
			{
				InsertDocument(document);
			}
		}

		public void DeleteDocumentById(int id)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("No such document.");

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (adapter = new SqlDataAdapter())
				{
					string sql = "DELETE FROM DocumentScan WHERE ID_DocumentScan = @id";

					command = new SqlCommand(sql, connection);
					command.Parameters.AddWithValue("@id", id);
					adapter.DeleteCommand = command;
					adapter.DeleteCommand.ExecuteNonQuery();
				}
				command.Dispose();
				connection.Close();
			}
		}

		public void DeleteDocumentByArchiveBooking(int id)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("No such document.");

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (adapter = new SqlDataAdapter())
				{
					string sql = "DELETE FROM DocumentScan WHERE ID_ArchiveBooking = @id";

					command = new SqlCommand(sql, connection);
					command.Parameters.AddWithValue("@id", id);
					adapter.DeleteCommand = command;
					adapter.DeleteCommand.ExecuteNonQuery();
				}
				command.Dispose();
				connection.Close();
			}
		}

		public void UpdateDocumentScanByID(int id, DocumentScan document)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("No such document.");

			if (document == null)
				throw new IndexOutOfRangeException("Empty document.");

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (adapter = new SqlDataAdapter())
				{
					string sql = "UPDATE DocumentScan SET ID_ArchiveBooking = @archiveId, DocumentPath = @path WHERE ID_DocumentScan = @id";

					command = new SqlCommand(sql, connection);
					command.Parameters.AddWithValue("@archiveId", document.ID_ArchiveBooking);
					command.Parameters.AddWithValue("@path", document.DocumentPath);
					command.Parameters.AddWithValue("@id", id);
					adapter.UpdateCommand = command;
					adapter.UpdateCommand.ExecuteNonQuery();
				}
				command.Dispose();
				connection.Close();
			}
		}

		#endregion

		#region Properties


		#endregion
	}
}

