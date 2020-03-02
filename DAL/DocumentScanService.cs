using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
	public class DocumentScanService
	{
		public DocumentScanService()
		{
			connection = new SqlConnection(connectionString);
		}

		#region Functions

		public List<DocumentScan> getDocuments()
		{
			List<DocumentScan> result = new List<DocumentScan>();

			connection.Open();

			string sql = "SELECT * FROM DocumentScan";
			command = new SqlCommand(sql, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				DocumentScan document = new DocumentScan(int.Parse(reader.GetInt32(0).ToString()), int.Parse(reader.GetInt32(1).ToString()), reader.GetString(2));

				result.Add(document);
			}

			reader.Close();
			command.Dispose();
			connection.Close();

			return result;
		}

		public DocumentScan getDocumentByID(int id)
		{
			DocumentScan result = new DocumentScan();

			connection.Open();

			string sql = "SELECT * FROM DocumentScan WHERE ID_DocumentScan=" + id;
			command = new SqlCommand(sql, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				result.ID_DocumentScan = int.Parse(reader.GetInt32(0).ToString());
				result.ID_ArchiveBooking = int.Parse(reader.GetInt32(1).ToString());
				result.DocumentPath = reader.GetString(2);
			}

			reader.Close();
			command.Dispose();
			connection.Close();

			return result;
		}

		public List<DocumentScan> getDocumentsByArchiveBooking(int id)
		{
			List<DocumentScan> result = new List<DocumentScan>();

			connection.Open();

			string sql = "SELECT * FROM DocumentScan WHERE ID_ArchiveBooking=" + id;
			command = new SqlCommand(sql, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				DocumentScan document = new DocumentScan(int.Parse(reader.GetInt32(0).ToString()), int.Parse(reader.GetInt32(1).ToString()), reader.GetString(2));

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

			string sql = "INSERT INTO DocumentScan(ID_ArchiveBooking, DocumentPath) VALUES(" + document.ID_ArchiveBooking + ", '" + document.DocumentPath + "')";
			command = new SqlCommand(sql, connection);
			adapter.InsertCommand = command;
			adapter.InsertCommand.ExecuteNonQuery();

			command.Dispose();
			connection.Close();
		}

		public void InsertDocuments(List<DocumentScan> documents)
		{
			connection.Open();
			adapter = new SqlDataAdapter();

			StringBuilder sql = new StringBuilder("INSERT INTO DocumentScan(ID_ArchiveBooking, DocumentPath) VALUES");

			foreach (DocumentScan document in documents)
			{
				sql.Append("(" + document.ID_ArchiveBooking + ", '" + document.DocumentPath + "'),");
			}

			command = new SqlCommand(sql.ToString().Substring(0, sql.ToString().Length - 1), connection);
			adapter.InsertCommand = command;
			adapter.InsertCommand.ExecuteNonQuery();

			command.Dispose();
			connection.Close();
		}

		public void DeleteDocumentById(int id)
		{
			connection.Open();
			adapter = new SqlDataAdapter();

			string sql = "DELETE FROM DocumentScan WHERE ID_DocumentScan=" + id;

			command = new SqlCommand(sql, connection);
			adapter.DeleteCommand = command;
			adapter.DeleteCommand.ExecuteNonQuery();

			command.Dispose();
			connection.Close();
		}

		public void DeleteDocumentByArchiveBooking(int id)
		{
			connection.Open();
			adapter = new SqlDataAdapter();

			string sql = "DELETE FROM DocumentScan WHERE ID_ArchiveBooking=" + id;

			command = new SqlCommand(sql, connection);
			adapter.DeleteCommand = command;
			adapter.DeleteCommand.ExecuteNonQuery();

			command.Dispose();
			connection.Close();
		}

		public void UpdateArchiveCodeByID(int id, DocumentScan document)
		{
			connection.Open();
			adapter = new SqlDataAdapter();

			string sql = "UPDATE DocumentScan SET ID_ArchiveBooking=" + document.ID_ArchiveBooking + ", DocumentPath='" + document.DocumentPath + "' WHERE ID_DocumentScan=" + id;

			command = new SqlCommand(sql, connection);
			adapter.UpdateCommand = command;
			adapter.UpdateCommand.ExecuteNonQuery();

			command.Dispose();
			connection.Close();
		}

		#endregion

		#region Properties
		public string connectionString = "Server=(localdb)\\mssqllocaldb;Database=Archive;Trusted_Connection=True;MultipleActiveResultSets=true";

		public SqlConnection connection { get; set; }
		public SqlCommand command { get; set; }
		public SqlDataReader reader { get; set; }
		public SqlDataAdapter adapter { get; set; }

		#endregion
	}
}
