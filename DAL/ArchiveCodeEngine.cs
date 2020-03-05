using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.SQLServer
{
	public class ArchiveCodeEngine : DBClass, IArchiveCodeEngine
	{
		public ArchiveCodeEngine()  
			: base() { }  

		#region Functions

		public List<ArchiveCode> GetArchiveCodes()
		{
			List<ArchiveCode> result = new List<ArchiveCode>();

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				string sql = "SELECT * FROM ArchiveCode";
				command = new SqlCommand(sql, connection);

				using (reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						ArchiveCode code = new ArchiveCode(reader.GetInt32("ID_ArchiveCode"), reader.GetString("Code"), reader.GetString("Name"));

						result.Add(code);
					}
				}
				reader.Close();
				command.Dispose();
				connection.Close();
			}

			return result;
		}

		public List<ArchiveCode> GetArchiveCodesByCodes(List<string> codes)
		{
			if (codes.Count == 0)
				throw new IndexOutOfRangeException("No codes.");

			List<ArchiveCode> result = new List<ArchiveCode>();

			foreach (string code in codes)
			{
				result.Add(GetArchiveCodeByCode(code));
			}

			return result;
		}

		public ArchiveCode GetArchiveCodeByID(int id)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("No such code.");
			
			ArchiveCode result = new ArchiveCode();

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				string sql = "SELECT * FROM ArchiveCode WHERE ID_ArchiveCode = @id";
				command = new SqlCommand(sql, connection);
				command.Parameters.AddWithValue("@id", id);

				using (reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						result.ID_ArchiveCode = reader.GetInt32("ID_ArchiveCode");
						result.Code = reader.GetString("Code");
						result.Name = reader.GetString("Name");
					}
				}
				reader.Close();
				command.Dispose();
				connection.Close();
			}

			return result;
		}

		public ArchiveCode GetArchiveCodeByCode(string code)
		{
			if (code == null)
				throw new IndexOutOfRangeException("No such code.");

			ArchiveCode result = new ArchiveCode();

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				string sql = "SELECT * FROM ArchiveCode WHERE Code = @code";
				command = new SqlCommand(sql, connection);
				command.Parameters.AddWithValue("@code", code);

				using (reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						result.ID_ArchiveCode = reader.GetInt32("ID_ArchiveCode");
						result.Code = reader.GetString("Code");
						result.Name = reader.GetString("Name");
					}
				}
				reader.Close();
				command.Dispose();
				connection.Close();
			}

			return result;
		}

		public void InsertArchiveCode(ArchiveCode code)
		{
			if (code.ID_ArchiveCode == 0)
				throw new IndexOutOfRangeException("Empty code.");

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (adapter = new SqlDataAdapter())
				{
					string sql = "INSERT INTO ArchiveCode(Code, Name) VALUES(@code, @name)";
					command = new SqlCommand(sql, connection);
					command.Parameters.AddWithValue("@code", code.Code);
					command.Parameters.AddWithValue("@name", code.Name);
					adapter.InsertCommand = command;
					adapter.InsertCommand.ExecuteNonQuery();
				}
				command.Dispose();
				connection.Close();
			}
		}

		public void InsertArchiveCodes(List<ArchiveCode> codes)
		{
			if (codes.Count == 0)
				throw new IndexOutOfRangeException("No codes.");

			foreach (ArchiveCode code in codes)
			{
				InsertArchiveCode(code);
			}
		}

		public void DeleteArchiveCodeById(int id)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("No such code.");

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (adapter = new SqlDataAdapter())
				{
					string sql = "DELETE FROM ArchiveCode WHERE ID_ArchiveCode = @id";

					command = new SqlCommand(sql, connection);
					command.Parameters.AddWithValue("@id", id);
					adapter.DeleteCommand = command;
					adapter.DeleteCommand.ExecuteNonQuery();
				}
				command.Dispose();
				connection.Close();
			}
		}

		public void DeleteArchiveCodeByCode(string code)
		{
			if (code == null)
				throw new IndexOutOfRangeException("No such code.");

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (adapter = new SqlDataAdapter())
				{
					string sql = "DELETE FROM ArchiveCode WHERE Code = @code";

					command = new SqlCommand(sql, connection);
					command.Parameters.AddWithValue("@code", code);
					adapter.DeleteCommand = command;
					adapter.DeleteCommand.ExecuteNonQuery();
				}
				command.Dispose();
				connection.Close();
			}
		}

		public void DeleteArchiveCodesByCodes(List<string> codes)
		{
			if (codes.Count == 0)
				throw new IndexOutOfRangeException("No codes.");

			foreach (string code in codes)
			{
				DeleteArchiveCodeByCode(code);
			}
		}

		public void UpdateArchiveCodeByID(int id, ArchiveCode code)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("No such code.");
			if (code == null)
				throw new IndexOutOfRangeException("No codes.");

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (adapter = new SqlDataAdapter())
				{
					string sql = "UPDATE ArchiveCode SET Code = @code, Name = @name WHERE ID_ArchiveCode = @id";

					command = new SqlCommand(sql, connection);
					command.Parameters.AddWithValue("@code", code.Code);
					command.Parameters.AddWithValue("@name", code.Name);
					command.Parameters.AddWithValue("@id", id);
					adapter.UpdateCommand = command;
					adapter.UpdateCommand.ExecuteNonQuery();
				}
				command.Dispose();
				connection.Close();
			}
		}

		public void UpdateArchiveCodeByCode(string c, ArchiveCode code)
		{
			if (c == null)
				throw new IndexOutOfRangeException("No such code.");

			if (code == null)
				throw new IndexOutOfRangeException("No codes.");

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (adapter = new SqlDataAdapter())
				{
					string sql = "UPDATE ArchiveCode SET Code = @code, Name = @name WHERE Code = @c";

					command = new SqlCommand(sql, connection);
					command.Parameters.AddWithValue("@code", code.Code);
					command.Parameters.AddWithValue("@name", code.Name);
					command.Parameters.AddWithValue("@c", c);
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
