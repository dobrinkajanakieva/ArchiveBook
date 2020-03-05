using DAL_Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL_SQLServer
{
	public class SenderEngine : DBClass, ISenderEngine
	{
		public SenderEngine() 
			: base() { }  

		#region Functions

		public List<Sender> GetSenders()
		{
			List<Sender> result = new List<Sender>();

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				string sql = "SELECT * FROM Sender";
				command = new SqlCommand(sql, connection);

				using (reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						Sender sender = new Sender(reader.GetInt32("ID_Sender"), reader.GetString("SenderName"));

						result.Add(sender);
					}
				}
				reader.Close();
				command.Dispose();
				connection.Close();
			}

			return result;
		}

		public Sender GetSenderByID(int id)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("No such sender.");

			Sender result = new Sender();

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				string sql = "SELECT * FROM Sender WHERE ID_Sender = @id";
				command = new SqlCommand(sql, connection);
				command.Parameters.AddWithValue("@id", id);

				using (reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						result.ID_Sender = reader.GetInt32("ID_Sender");
						result.SenderName = reader.GetString("SenderName");
					}
				}
				reader.Close();
				command.Dispose();
				connection.Close();
			}

			return result;
		}

		public Sender GetSenderByName(string name)
		{
			if (name == null)
				throw new IndexOutOfRangeException("No such sender.");

			Sender result = new Sender();

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				string sql = "SELECT * FROM Sender WHERE SenderName = @name";
				command = new SqlCommand(sql, connection);
				command.Parameters.AddWithValue("@name", name);

				using (reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						result.ID_Sender = reader.GetInt32("ID_Sender");
						result.SenderName = reader.GetString("SenderName");
					}
				}
				reader.Close();
				command.Dispose();
				connection.Close();
			}

			return result;
		}

		public void InsertSender(Sender sender)
		{
			if (sender == null)
				throw new IndexOutOfRangeException("Empty sender.");

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (adapter = new SqlDataAdapter())
				{
					string sql = "INSERT INTO Sender(SenderName) VALUES(@name)";
					command = new SqlCommand(sql, connection);
					command.Parameters.AddWithValue("@name", sender.SenderName);
					adapter.InsertCommand = command;
					adapter.InsertCommand.ExecuteNonQuery();
				}
				command.Dispose();
				connection.Close();
			}
		}

		public void InsertSenders(List<Sender> senders)
		{
			if (senders.Count == 0)
				throw new IndexOutOfRangeException("No senders.");

			foreach (Sender sender in senders)
			{
				InsertSender(sender);
			}
		}

		public void DeleteSenderById(int id)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("No such sender."); 

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (adapter = new SqlDataAdapter())
				{
					string sql = "DELETE FROM Sender WHERE ID_Sender = @id";

					command = new SqlCommand(sql, connection);
					command.Parameters.AddWithValue("@id", id);
					adapter.DeleteCommand = command;
					adapter.DeleteCommand.ExecuteNonQuery();
				}
				command.Dispose();
				connection.Close();
			}
		}

		public void DeleteSenderByName(string name)
		{
			if (name == null)
				throw new IndexOutOfRangeException("No such sender.");

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (adapter = new SqlDataAdapter())
				{
					string sql = "DELETE FROM Sender WHERE SenderName = @name";

					command = new SqlCommand(sql, connection);
					command.Parameters.AddWithValue("@name", name);
					adapter.DeleteCommand = command;
					adapter.DeleteCommand.ExecuteNonQuery();
				}
				command.Dispose();
				connection.Close();
			}
		}

		public void DeleteSendersByNames(List<string> names)
		{
			if (names.Count == 0)
				throw new IndexOutOfRangeException("No senders.");

			foreach (string name in names)
			{
				DeleteSenderByName(name);
			}
		}

		public void UpdateSenderById(int id, Sender sender)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("No such sender.");

			if (sender == null)
				throw new IndexOutOfRangeException("Empty sender.");

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (adapter = new SqlDataAdapter())
				{
					string sql = "UPDATE Sender SET SenderName = @name WHERE ID_Sender = @id";

					command = new SqlCommand(sql, connection);
					command.Parameters.AddWithValue("@name", sender.SenderName);
					command.Parameters.AddWithValue("@id", id);
					adapter.UpdateCommand = command;
					adapter.UpdateCommand.ExecuteNonQuery();
				}
				command.Dispose();
				connection.Close();
			}
		}

		public void UpdateSenderByName(string name, Sender sender)
		{
			if (name == null)
				throw new IndexOutOfRangeException("No such sender.");

			if (sender == null)
				throw new IndexOutOfRangeException("Empty sender.");

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (adapter = new SqlDataAdapter())
				{
					string sql = "UPDATE Sender SET SenderName = @newname WHERE SenderName = @name";

					command = new SqlCommand(sql, connection);
					command.Parameters.AddWithValue("@newname", sender.SenderName);
					command.Parameters.AddWithValue("@name", name);
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
