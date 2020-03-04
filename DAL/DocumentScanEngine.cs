using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

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

			try
			{
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
			}
			catch (SqlException ex)
			{
				StringBuilder errorMessages = new StringBuilder();
				for (int i = 0; i < ex.Errors.Count; i++)
				{
					errorMessages.Append("Index #" + i + "\n" +
						"Message: " + ex.Errors[i].Message + "\n" +
						"LineNumber: " + ex.Errors[i].LineNumber + "\n" +
						"Source: " + ex.Errors[i].Source + "\n" +
						"Procedure: " + ex.Errors[i].Procedure + "\n");
				}
				Console.WriteLine(errorMessages.ToString());
			}

			return result;
		}

		public DocumentScan GetDocumentByID(int id)
		{
			DocumentScan result = new DocumentScan();

			try
			{
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
			}
			catch (SqlException ex)
			{
				StringBuilder errorMessages = new StringBuilder();
				for (int i = 0; i < ex.Errors.Count; i++)
				{
					errorMessages.Append("Index #" + i + "\n" +
						"Message: " + ex.Errors[i].Message + "\n" +
						"LineNumber: " + ex.Errors[i].LineNumber + "\n" +
						"Source: " + ex.Errors[i].Source + "\n" +
						"Procedure: " + ex.Errors[i].Procedure + "\n");
				}
				Console.WriteLine(errorMessages.ToString());
			}

			return result;
		}

		public List<DocumentScan> GetDocumentsByArchiveBooking(int id)
		{
			List<DocumentScan> result = new List<DocumentScan>();

			try
			{
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
			}
			catch (SqlException ex)
			{
				StringBuilder errorMessages = new StringBuilder();
				for (int i = 0; i < ex.Errors.Count; i++)
				{
					errorMessages.Append("Index #" + i + "\n" +
						"Message: " + ex.Errors[i].Message + "\n" +
						"LineNumber: " + ex.Errors[i].LineNumber + "\n" +
						"Source: " + ex.Errors[i].Source + "\n" +
						"Procedure: " + ex.Errors[i].Procedure + "\n");
				}
				Console.WriteLine(errorMessages.ToString());
			}

			return result;
		}

		public void InsertDocument(DocumentScan document)
		{
			try
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
			catch (SqlException ex)
			{
				StringBuilder errorMessages = new StringBuilder();
				for (int i = 0; i < ex.Errors.Count; i++)
				{
					errorMessages.Append("Index #" + i + "\n" +
						"Message: " + ex.Errors[i].Message + "\n" +
						"LineNumber: " + ex.Errors[i].LineNumber + "\n" +
						"Source: " + ex.Errors[i].Source + "\n" +
						"Procedure: " + ex.Errors[i].Procedure + "\n");
				}
				Console.WriteLine(errorMessages.ToString());
			}
		}

		public void InsertDocuments(List<DocumentScan> documents)
		{
			try
			{
				foreach (DocumentScan document in documents)
				{
					InsertDocument(document);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message.ToString());
			}
		}

		public void DeleteDocumentById(int id)
		{
			try
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
			catch (SqlException ex)
			{
				StringBuilder errorMessages = new StringBuilder();
				for (int i = 0; i < ex.Errors.Count; i++)
				{
					errorMessages.Append("Index #" + i + "\n" +
						"Message: " + ex.Errors[i].Message + "\n" +
						"LineNumber: " + ex.Errors[i].LineNumber + "\n" +
						"Source: " + ex.Errors[i].Source + "\n" +
						"Procedure: " + ex.Errors[i].Procedure + "\n");
				}
				Console.WriteLine(errorMessages.ToString());
			}
		}

		public void DeleteDocumentByArchiveBooking(int id)
		{
			try
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
			catch (SqlException ex)
			{
				StringBuilder errorMessages = new StringBuilder();
				for (int i = 0; i < ex.Errors.Count; i++)
				{
					errorMessages.Append("Index #" + i + "\n" +
						"Message: " + ex.Errors[i].Message + "\n" +
						"LineNumber: " + ex.Errors[i].LineNumber + "\n" +
						"Source: " + ex.Errors[i].Source + "\n" +
						"Procedure: " + ex.Errors[i].Procedure + "\n");
				}
				Console.WriteLine(errorMessages.ToString());
			}
		}

		public void UpdateDocumentScanByID(int id, DocumentScan document)
		{
			try
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
			catch (SqlException ex)
			{
				StringBuilder errorMessages = new StringBuilder();
				for (int i = 0; i < ex.Errors.Count; i++)
				{
					errorMessages.Append("Index #" + i + "\n" +
						"Message: " + ex.Errors[i].Message + "\n" +
						"LineNumber: " + ex.Errors[i].LineNumber + "\n" +
						"Source: " + ex.Errors[i].Source + "\n" +
						"Procedure: " + ex.Errors[i].Procedure + "\n");
				}
				Console.WriteLine(errorMessages.ToString());
			}
		}

		#endregion

		#region Properties


		#endregion
	}
}

