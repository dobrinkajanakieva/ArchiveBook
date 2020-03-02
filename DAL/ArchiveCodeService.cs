using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace DAL
{
	public class ArchiveCodeService
	{
		public ArchiveCodeService() 
		{
			connection = new SqlConnection(connectionString);
		}

		#region Functions

		public List<ArchiveCode> getArchiveCodes()
		{
			List<ArchiveCode> result = new List<ArchiveCode>();

			connection.Open();

			string sql = "SELECT * FROM ArchiveCode";
			command = new SqlCommand(sql, connection);
			reader = command.ExecuteReader();

			while(reader.Read())
			{
				ArchiveCode code = new ArchiveCode(int.Parse(reader.GetInt32(0).ToString()), reader.GetString(1), reader.GetString(2));

				result.Add(code);
			}

			reader.Close();
			command.Dispose();
			connection.Close();

			return result;
		}

		public ArchiveCode getArchiveCodeByID(int id)
		{
			ArchiveCode result = new ArchiveCode();

			connection.Open();

			string sql = "SELECT * FROM ArchiveCode WHERE ID_ArchiveCode="+id;
			command = new SqlCommand(sql, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				result.ID_ArchiveCode = int.Parse(reader.GetInt32(0).ToString());
				result.Code = reader.GetString(1);
				result.Name = reader.GetString(2);
			}

			reader.Close();
			command.Dispose();
			connection.Close();

			return result;
		}

		public ArchiveCode getArchiveCodeByCode(string code)
		{
			ArchiveCode result = new ArchiveCode();

			connection.Open();

			string sql = "SELECT * FROM ArchiveCode WHERE Code='" + code + "'";
			command = new SqlCommand(sql, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				result.ID_ArchiveCode = int.Parse(reader.GetInt32(0).ToString());
				result.Code = reader.GetString(1);
				result.Name = reader.GetString(2);
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

			string sql = "INSERT INTO ArchiveCode(Code, Name) VALUES('"+ code.Code + "', '" + code.Name + "')";
			command = new SqlCommand(sql, connection);
			adapter.InsertCommand = command;
			adapter.InsertCommand.ExecuteNonQuery();

			command.Dispose();
			connection.Close();
		}

		public void InsertArchiveCodes(List<ArchiveCode> codes)
		{
			connection.Open();
			adapter = new SqlDataAdapter();

			StringBuilder sql = new StringBuilder("INSERT INTO ArchiveCode(Code, Name) VALUES");

			foreach(ArchiveCode code in codes)
			{
				sql.Append("('" + code.Code + "', '" + code.Name + "'),");
			}

			command = new SqlCommand(sql.ToString().Substring(0, sql.ToString().Length-1), connection);
			adapter.InsertCommand = command;
			adapter.InsertCommand.ExecuteNonQuery();

			command.Dispose();
			connection.Close();
		}

		public void DeleteArchiveCodeById(int id)
		{
			connection.Open();
			adapter = new SqlDataAdapter();

			string sql = "DELETE FROM ArchiveCode WHERE ID_ArchiveCode=" + id;

			command = new SqlCommand(sql, connection);
			adapter.DeleteCommand = command;
			adapter.DeleteCommand.ExecuteNonQuery();

			command.Dispose();
			connection.Close();
		}

		public void DeleteArchiveCodeByCode(string code)
		{
			connection.Open();
			adapter = new SqlDataAdapter();

			string sql = "DELETE FROM ArchiveCode WHERE Code='" + code + "'";

			command = new SqlCommand(sql, connection);
			adapter.DeleteCommand = command;
			adapter.DeleteCommand.ExecuteNonQuery();

			command.Dispose();
			connection.Close();
		}

		public void UpdateArchiveCodeByID(int id, ArchiveCode code)
		{
			connection.Open();
			adapter = new SqlDataAdapter();

			string sql = "UPDATE ArchiveCode SET Code='" + code.Code + "', Name='" + code.Name + "' WHERE ID_ArchiveCode=" + id;

			command = new SqlCommand(sql, connection);
			adapter.UpdateCommand = command;
			adapter.UpdateCommand.ExecuteNonQuery();

			command.Dispose();
			connection.Close();
		}

		public void UpdateArchiveCodeByCode(string c, ArchiveCode code)
		{
			connection.Open();
			adapter = new SqlDataAdapter();

			string sql = "UPDATE ArchiveCode SET Code='" + code.Code + "', Name='" + code.Name + "' WHERE Code='" + c + "'";

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
