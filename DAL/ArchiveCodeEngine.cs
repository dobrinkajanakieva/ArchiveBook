using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
	public class ArchiveCodeEngine : DBConnection
	{
		public ArchiveCodeEngine()  //(string connectionString)
			: base() { }  // (connectionString) { }

		#region Functions

		public List<ArchiveCode> GetArchiveCodes()
		{
			List<ArchiveCode> result = new List<ArchiveCode>();

			try
			{
				connection.Open();

				string sql = "SELECT * FROM ArchiveCode";
				command = new SqlCommand(sql, connection);
				reader = command.ExecuteReader();

				while (reader.Read())
				{
					ArchiveCode code = new ArchiveCode(reader.GetInt32("ID_ArchiveCode"), reader.GetString("Code"), reader.GetString("Name"));

					result.Add(code);
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

		public List<ArchiveCode> GetArchiveCodesByCodes(List<string> codes)
		{
			List<ArchiveCode> result = new List<ArchiveCode>();
			try
			{
				foreach (string code in codes)
				{
					result.Add(GetArchiveCodeByCode(code));
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message.ToString());
			}
			return result;
		}

		public ArchiveCode GetArchiveCodeByID(int id)
		{
			ArchiveCode result = new ArchiveCode();

			try
			{
				connection.Open();

				string sql = "SELECT * FROM ArchiveCode WHERE ID_ArchiveCode = @id";
				command = new SqlCommand(sql, connection);
				command.Parameters.AddWithValue("@id", id);
				reader = command.ExecuteReader();

				while (reader.Read())
				{
					result.ID_ArchiveCode = reader.GetInt32("ID_ArchiveCode");
					result.Code = reader.GetString("Code");
					result.Name = reader.GetString("Name");
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

		public ArchiveCode GetArchiveCodeByCode(string code)
		{
			ArchiveCode result = new ArchiveCode();

			try
			{
				connection.Open();

				string sql = "SELECT * FROM ArchiveCode WHERE Code = @code";
				command = new SqlCommand(sql, connection);
				command.Parameters.AddWithValue("@code", code);
				reader = command.ExecuteReader();

				while (reader.Read())
				{
					result.ID_ArchiveCode = reader.GetInt32("ID_ArchiveCode");
					result.Code = reader.GetString("Code");
					result.Name = reader.GetString("Name");
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

		public void InsertArchiveCode(ArchiveCode code)
		{
			try
			{
				connection.Open();
				adapter = new SqlDataAdapter();

				string sql = "INSERT INTO ArchiveCode(Code, Name) VALUES(@code, @name)";
				command = new SqlCommand(sql, connection);
				command.Parameters.AddWithValue("@code", code.Code);
				command.Parameters.AddWithValue("@name", code.Name);
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

		public void InsertArchiveCodes(List<ArchiveCode> codes)
		{
			try
			{
				foreach (ArchiveCode code in codes)
				{
					InsertArchiveCode(code);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message.ToString());
			}
		}

		public void DeleteArchiveCodeById(int id)
		{
			try
			{
				connection.Open();
				adapter = new SqlDataAdapter();

				string sql = "DELETE FROM ArchiveCode WHERE ID_ArchiveCode = @id";

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

		public void DeleteArchiveCodeByCode(string code)
		{
			try
			{
				connection.Open();
				adapter = new SqlDataAdapter();

				string sql = "DELETE FROM ArchiveCode WHERE Code = @code";

				command = new SqlCommand(sql, connection);
				command.Parameters.AddWithValue("@code", code);
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

		public void DeleteArchiveCodesByCodes(List<string> codes)
		{
			try
			{
				foreach (string code in codes)
				{
					DeleteArchiveCodeByCode(code);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message.ToString());
			}
		}

		public void UpdateArchiveCodeByID(int id, ArchiveCode code)
		{
			try
			{
				connection.Open();
				adapter = new SqlDataAdapter();

				string sql = "UPDATE ArchiveCode SET Code = @code, Name = @name WHERE ID_ArchiveCode = @id";

				command = new SqlCommand(sql, connection);
				command.Parameters.AddWithValue("@code", code.Code);
				command.Parameters.AddWithValue("@name", code.Name);
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

		public void UpdateArchiveCodeByCode(string c, ArchiveCode code)
		{
			try
			{
				connection.Open();
				adapter = new SqlDataAdapter();

				string sql = "UPDATE ArchiveCode SET Code = @code, Name = @name WHERE Code = @c";

				command = new SqlCommand(sql, connection);
				command.Parameters.AddWithValue("@code", code.Code);
				command.Parameters.AddWithValue("@name", code.Name);
				command.Parameters.AddWithValue("@c", c);
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
