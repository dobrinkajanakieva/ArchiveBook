using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
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

			connection.Open();

			string sql = "SELECT * FROM ArchiveCode";
			command = new SqlCommand(sql, connection);
			reader = command.ExecuteReader();

			while(reader.Read())
			{
				ArchiveCode code = new ArchiveCode(reader.GetInt32("ID_ArchiveCode"), reader.GetString("Code"), reader.GetString("Name"));

				result.Add(code);
			}

			reader.Close();
			command.Dispose();
			connection.Close();

			return result;
		}

		public List<ArchiveCode> GetArchiveCodesByCodes(List<string> codes)
		{
			List<ArchiveCode> result = new List<ArchiveCode>();
			foreach(string code in codes)
			{
				result.Add(GetArchiveCodeByCode(code));
			}
			return result;
		}

		public ArchiveCode GetArchiveCodeByID(int id)
		{
			ArchiveCode result = new ArchiveCode();

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

			return result;
		}

		public ArchiveCode GetArchiveCodeByCode(string code)
		{
			ArchiveCode result = new ArchiveCode();

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

			return result;
		}

		public void InsertArchiveCode(ArchiveCode code)
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

		public void InsertArchiveCodes(List<ArchiveCode> codes)
		{
			foreach(ArchiveCode code in codes)
			{
				InsertArchiveCode(code);
			}
		}

		public void DeleteArchiveCodeById(int id)
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

		public void DeleteArchiveCodeByCode(string code)
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

		public void DeleteArchiveCodesByCodes(List<string> codes)
		{
			foreach(string code in codes)
			{
				DeleteArchiveCodeByCode(code);
			}
		}

		public void UpdateArchiveCodeByID(int id, ArchiveCode code)
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

		public void UpdateArchiveCodeByCode(string c, ArchiveCode code)
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
