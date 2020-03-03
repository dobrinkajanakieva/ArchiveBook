using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
	public class SenderService
	{
		public SenderService()
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
				Sender sender = new Sender(int.Parse(reader.GetInt32(0).ToString()), reader.GetString(1));

				result.Add(sender);
			}

			reader.Close();
			command.Dispose();
			connection.Close();

			return result;
		}

		public List<Sender> GetSendersByNames(List<string> names)
		{
			List<Sender> result = new List<Sender>();

			connection.Open();

			StringBuilder sql = new StringBuilder("SELECT * FROM Sender WHERE SenderName IN (");
			for (int i = 0; i < names.Count; i++)
			{
				sql.Append("'" + names[i] + "', ");
			}
			string sqlCommand = sql.ToString().Substring(0, sql.ToString().Length - 2) + ")";
			command = new SqlCommand(sqlCommand, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				Sender sender = new Sender(int.Parse(reader.GetInt32(0).ToString()), reader.GetString(1));

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

			string sql = "SELECT * FROM Sender WHERE ID_Sender=" + id;
			command = new SqlCommand(sql, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				result.ID_Sender = int.Parse(reader.GetInt32(0).ToString());
				result.SenderName = reader.GetString(1);
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

			string sql = "SELECT * FROM Sender WHERE SenderName='" + name + "'";
			command = new SqlCommand(sql, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				result.ID_Sender = int.Parse(reader.GetInt32(0).ToString());
				result.SenderName = reader.GetString(1);
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

			string sql = "INSERT INTO Sender(SenderName) VALUES('" + sender.SenderName + "')";
			command = new SqlCommand(sql, connection);
			adapter.InsertCommand = command;
			adapter.InsertCommand.ExecuteNonQuery();

			command.Dispose();
			connection.Close();
		}

		public void InsertSenders(List<Sender> senders)
		{
			connection.Open();
			adapter = new SqlDataAdapter();

			StringBuilder sql = new StringBuilder("INSERT INTO Sender(SenderName) VALUES");

			foreach (Sender sender in senders)
			{
				sql.Append("('" + sender.SenderName + "'),");
			}

			command = new SqlCommand(sql.ToString().Substring(0, sql.ToString().Length - 1), connection);
			adapter.InsertCommand = command;
			adapter.InsertCommand.ExecuteNonQuery();

			command.Dispose();
			connection.Close();
		}

		public void DeleteSenderById(int id)
		{
			connection.Open();
			adapter = new SqlDataAdapter();

			string sql = "DELETE FROM Sender WHERE ID_Sender=" + id;

			command = new SqlCommand(sql, connection);
			adapter.DeleteCommand = command;
			adapter.DeleteCommand.ExecuteNonQuery();

			command.Dispose();
			connection.Close();
		}

		public void DeleteSenderByName(string name)
		{
			connection.Open();
			adapter = new SqlDataAdapter();

			string sql = "DELETE FROM Sender WHERE SenderName='" + name + "'";

			command = new SqlCommand(sql, connection);
			adapter.DeleteCommand = command;
			adapter.DeleteCommand.ExecuteNonQuery();

			command.Dispose();
			connection.Close();
		}

		public void DeleteSendersByNames(List<string> names)
		{
			connection.Open();
			adapter = new SqlDataAdapter();

			StringBuilder sql = new StringBuilder("DELETE FROM Sender WHERE SenderName IN (");

			for (int i = 0; i < names.Count; i++)
			{
				sql.Append("'" + names[i] + "', ");
			}

			string sqlCommand = sql.ToString().Substring(0, sql.ToString().Length - 2) + ")";

			command = new SqlCommand(sqlCommand, connection);
			adapter.DeleteCommand = command;
			adapter.DeleteCommand.ExecuteNonQuery();

			command.Dispose();
			connection.Close();
		}

		public void UpdateSenderById(int id, Sender sender)
		{
			connection.Open();
			adapter = new SqlDataAdapter();

			string sql = "UPDATE Sender SET SenderName='" + sender.SenderName + "' WHERE ID_Sender=" + id;

			command = new SqlCommand(sql, connection);
			adapter.UpdateCommand = command;
			adapter.UpdateCommand.ExecuteNonQuery();

			command.Dispose();
			connection.Close();
		}

		public void UpdateSenderByName(string name, Sender sender)
		{
			connection.Open();
			adapter = new SqlDataAdapter();

			string sql = "UPDATE Sender SET SenderName='" + sender.SenderName + "' WHERE SenderName='" + name + "'";

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
