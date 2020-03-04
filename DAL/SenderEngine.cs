using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
	public class SenderEngine : DBConnection
	{
		public SenderEngine() //(string connectionString)
			: base() { }  // (connectionString) { }

		#region Functions

		public List<Sender> GetSenders()
		{
			List<Sender> result = new List<Sender>();
			try
			{
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

		public Sender GetSenderByID(int id)
		{
			Sender result = new Sender();
			try
			{
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

		public Sender GetSenderByName(string name)
		{
			Sender result = new Sender();
			try
			{
				connection.Open();

				string sql = "SELECT * FROM Sender WHERE SenderName = @name";
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

		public void InsertSender(Sender sender)
		{
			try
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

		public void InsertSenders(List<Sender> senders)
		{
			try
			{
				foreach (Sender sender in senders)
				{
					InsertSender(sender);
				}
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

		public void DeleteSenderById(int id)
		{
			try
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

		public void DeleteSenderByName(string name)
		{
			try
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

		public void DeleteSendersByNames(List<string> names)
		{
			try
			{
				foreach (string name in names)
				{
					DeleteSenderByName(name);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message.ToString());
			}
		}

		public void UpdateSenderById(int id, Sender sender)
		{
			try
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

		public void UpdateSenderByName(string name, Sender sender)
		{
			try
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
