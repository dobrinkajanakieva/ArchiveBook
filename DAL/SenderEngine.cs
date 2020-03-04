using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
	public class SenderEngine
	{
		public SenderEngine()
		{
			connection = new SqlConnection(connectionString);
		}

		#region Functions

		public List<Sender> GetSenders()
		{
			List<Sender> result = new List<Sender>();

			connection.Open();

			string sql = "SELECT * FROM Sender";
			command = new SqlCommand(sql, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				Sender sender = new Sender(reader.GetInt32("ID_Sender"), reader.GetString("SenderName"));

				result.Add(sender);
			}

			reader.Close();
			command.Dispose();
			connection.Close();

			return result;
		}

		public Sender GetSenderByID(int id)
		{
			Sender result = new Sender();

			connection.Open();

			string sql = "SELECT * FROM Sender WHERE ID_Sender = @id";
			command = new SqlCommand(sql, connection);
			command.Parameters.AddWithValue("@id", id);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				result.ID_Sender = reader.GetInt32("ID_Sender");
				result.SenderName = reader.GetString("SenderName");
			}

			reader.Close();
			command.Dispose();
			connection.Close();

			return result;
		}

		public Sender GetSenderByName(string name)
		{
			Sender result = new Sender();

			connection.Open();

			string sql = "SELECT * FROM Sender WHERE SenderName = :@name";
			command = new SqlCommand(sql, connection);
			command.Parameters.AddWithValue("@name", name);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				result.ID_Sender = reader.GetInt32("ID_Sender");
				result.SenderName = reader.GetString("SenderName");
			}

			reader.Close();
			command.Dispose();
			connection.Close();

			return result;
		}

		public void InsertSender(Sender sender)
		{
			connection.Open();
			adapter = new SqlDataAdapter();

			string sql = "INSERT INTO Sender(SenderName) VALUES(@name)";
			command = new SqlCommand(sql, connection);
			command.Parameters.AddWithValue("@name", sender.SenderName);
			adapter.InsertCommand = command;
			adapter.InsertCommand.ExecuteNonQuery();

			command.Dispose();
			connection.Close();
		}

		public void InsertSenders(List<Sender> senders)
		{

			foreach (Sender sender in senders)
			{
				InsertSender(sender);
			}
		}

		public void DeleteSenderById(int id)
		{
			connection.Open();
			adapter = new SqlDataAdapter();

			string sql = "DELETE FROM Sender WHERE ID_Sender = @id";

			command = new SqlCommand(sql, connection);
			command.Parameters.AddWithValue("@id", id);
			adapter.DeleteCommand = command;
			adapter.DeleteCommand.ExecuteNonQuery();

			command.Dispose();
			connection.Close();
		}

		public void DeleteSenderByName(string name)
		{
			connection.Open();
			adapter = new SqlDataAdapter();

			string sql = "DELETE FROM Sender WHERE SenderName = @name";

			command = new SqlCommand(sql, connection);
			command.Parameters.AddWithValue("@name", name);
			adapter.DeleteCommand = command;
			adapter.DeleteCommand.ExecuteNonQuery();

			command.Dispose();
			connection.Close();
		}

		public void DeleteSendersByNames(List<string> names)
		{
			foreach(string name in names)
			{
				DeleteSenderByName(name);
			}
		}

		public void UpdateSenderById(int id, Sender sender)
		{
			connection.Open();
			adapter = new SqlDataAdapter();

			string sql = "UPDATE Sender SET SenderName = @name WHERE ID_Sender = @id";

			command = new SqlCommand(sql, connection);
			command.Parameters.AddWithValue("@name", sender.SenderName);
			command.Parameters.AddWithValue("@id", id);
			adapter.UpdateCommand = command;
			adapter.UpdateCommand.ExecuteNonQuery();

			command.Dispose();
			connection.Close();
		}

		public void UpdateSenderByName(string name, Sender sender)
		{
			connection.Open();
			adapter = new SqlDataAdapter();

			string sql = "UPDATE Sender SET SenderName = @newname WHERE SenderName = @name";

			command = new SqlCommand(sql, connection);
			command.Parameters.AddWithValue("@newname", sender.SenderName);
			command.Parameters.AddWithValue("@name", name);
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
