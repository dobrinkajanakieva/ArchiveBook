using Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
	public class DocumentScanEngine : DBConnection
	{
		public DocumentScanEngine()  //(string connectionString)
			: base() { }  // (connectionString) { }

		#region Functions

		public List<DocumentScan> GetDocuments()
		{
			List<DocumentScan> result = new List<DocumentScan>();

			connection.Open();

			string sql = "SELECT * FROM DocumentScan";
			command = new SqlCommand(sql, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				DocumentScan document = new DocumentScan(reader.GetInt32("ID_DocumentScan"), reader.GetInt32("ID_ArchiveBooking"), reader.GetString("DocumentPath"));

				result.Add(document);
			}

			reader.Close();
			command.Dispose();
			connection.Close();

			return result;
		}

		public DocumentScan GetDocumentByID(int id)
		{
			DocumentScan result = new DocumentScan();

			connection.Open();

			string sql = "SELECT * FROM DocumentScan WHERE ID_DocumentScan = @id";
			command = new SqlCommand(sql, connection);
			command.Parameters.AddWithValue("@id", id);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				result.ID_DocumentScan = reader.GetInt32("ID_DocumentScan");
				result.ID_ArchiveBooking = reader.GetInt32("ID_ArchiveBooking");
				result.DocumentPath = reader.GetString("DocumentPath");
			}

			reader.Close();
			command.Dispose();
			connection.Close();

			return result;
		}

		public List<DocumentScan> GetDocumentsByArchiveBooking(int id)
		{
			List<DocumentScan> result = new List<DocumentScan>();

			connection.Open();

			string sql = "SELECT * FROM DocumentScan WHERE ID_ArchiveBooking = @id";
			command = new SqlCommand(sql, connection);
			command.Parameters.AddWithValue("@id", id);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				DocumentScan document = new DocumentScan(reader.GetInt32("ID_DocumentScan"), reader.GetInt32("ID_ArchiveBooking"), reader.GetString("DocumentPath"));

				result.Add(document);
			}

			reader.Close();
			command.Dispose();
			connection.Close();

			return result;
		}

		public void InsertDocument(DocumentScan document)
		{
			connection.Open();
			adapter = new SqlDataAdapter();

			string sql = "INSERT INTO DocumentScan(ID_ArchiveBooking, DocumentPath) VALUES(@id, @path)";
			command = new SqlCommand(sql, connection);
			command.Parameters.AddWithValue("@id", document.ID_ArchiveBooking);
			command.Parameters.AddWithValue("@path", document.DocumentPath);
			adapter.InsertCommand = command;
			adapter.InsertCommand.ExecuteNonQuery();

			command.Dispose();
			connection.Close();
		}

		public void InsertDocuments(List<DocumentScan> documents)
		{
			foreach (DocumentScan document in documents)
			{
				InsertDocument(document);
			}
		}

		public void DeleteDocumentById(int id)
		{
			connection.Open();
			adapter = new SqlDataAdapter();

			string sql = "DELETE FROM DocumentScan WHERE ID_DocumentScan = @id";

			command = new SqlCommand(sql, connection);
			command.Parameters.AddWithValue("@id", id);
			adapter.DeleteCommand = command;
			adapter.DeleteCommand.ExecuteNonQuery();

			command.Dispose();
			connection.Close();
		}

		public void DeleteDocumentByArchiveBooking(int id)
		{
			connection.Open();
			adapter = new SqlDataAdapter();

			string sql = "DELETE FROM DocumentScan WHERE ID_ArchiveBooking = @id";

			command = new SqlCommand(sql, connection);
			command.Parameters.AddWithValue("@id", id);
			adapter.DeleteCommand = command;
			adapter.DeleteCommand.ExecuteNonQuery();

			command.Dispose();
			connection.Close();
		}

		public void UpdateDocumentScanByID(int id, DocumentScan document)
		{
			connection.Open();
			adapter = new SqlDataAdapter();

			string sql = "UPDATE DocumentScan SET ID_ArchiveBooking = @archiveId, DocumentPath = @path WHERE ID_DocumentScan = @id";

			command = new SqlCommand(sql, connection);
			command.Parameters.AddWithValue("@archiveId", document.ID_ArchiveBooking);
			command.Parameters.AddWithValue("@path", document.DocumentPath);
			command.Parameters.AddWithValue("@id", id);
			adapter.UpdateCommand = command;
			adapter.UpdateCommand.ExecuteNonQuery();

			command.Dispose();
			connection.Close();
		}

		#endregion

		#region Properties


		#endregion
	}
}

