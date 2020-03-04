using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
	public class ArchiveBookingEngine : DBConnection
	{
		public ArchiveBookingEngine() //(string connectionString)
			: base() { }  // (connectionString) { }

		#region Functions

		public List<ArchiveBooking> GetArchiveBookings()
		{
			List<ArchiveBooking> result = new List<ArchiveBooking>();

			try
			{
				connection.Open();

				string sql = "SELECT * FROM ArchiveBooking";
				command = new SqlCommand(sql, connection);
				reader = command.ExecuteReader();

				while (reader.Read())
				{
					ArchiveBooking booking = new ArchiveBooking();

					booking.ID_ArchiveBooking = reader.GetInt32("ID_ArchiveBooking");
					booking.ID_ArchiveCode = reader.GetInt32("ID_ArchiveCode");
					booking.DocumentNumber = reader.GetString("DocumentNumber");
					booking.Date = reader.GetDateTime("Date");
					booking.Year = reader.GetInt32("Year");
					booking.Subject = reader.GetString("Subject");
					booking.ID_Sender = reader.GetInt32("ID_Sender");
					booking.EntryCode = reader.GetString("EntryCode");

					result.Add(booking);
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

		public ArchiveBooking GetArchiveBookingByID(int id)
		{
			ArchiveBooking booking = new ArchiveBooking();

			try
			{
				connection.Open();

				string sql = "SELECT * FROM ArchiveBooking WHERE ID_ArchiveBooking=" + id;
				command = new SqlCommand(sql, connection);
				reader = command.ExecuteReader();

				while (reader.Read())
				{
					booking.ID_ArchiveBooking = reader.GetInt32("ID_ArchiveBooking");
					booking.ID_ArchiveCode = reader.GetInt32("ID_ArchiveCode");
					booking.DocumentNumber = reader.GetString("DocumentNumber");
					booking.Date = reader.GetDateTime("Date");
					booking.Year = reader.GetInt32("Year");
					booking.Subject = reader.GetString("Subject");
					booking.ID_Sender = reader.GetInt32("ID_Sender");
					booking.EntryCode = reader.GetString("EntryCode");
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

			return booking;
		}

		public ArchiveBooking GetArchiveBookingByDocumentNumber(string number)
		{
			ArchiveBooking booking = new ArchiveBooking();

			try
			{
				connection.Open();

				string sql = "SELECT * FROM ArchiveBooking WHERE DocumentNumber='" + number + "'";
				command = new SqlCommand(sql, connection);
				reader = command.ExecuteReader();

				while (reader.Read())
				{
					booking.ID_ArchiveBooking = reader.GetInt32("ID_ArchiveBooking");
					booking.ID_ArchiveCode = reader.GetInt32("ID_ArchiveCode");
					booking.DocumentNumber = reader.GetString("DocumentNumber");
					booking.Date = reader.GetDateTime("Date");
					booking.Year = reader.GetInt32("Year");
					booking.Subject = reader.GetString("Subject");
					booking.ID_Sender = reader.GetInt32("ID_Sender");
					booking.EntryCode = reader.GetString("EntryCode");
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

			return booking;
		}

		public ArchiveBooking GetArchiveBookingByEntryCode(string entryCode)
		{
			ArchiveBooking booking = new ArchiveBooking();

			try
			{
				connection.Open();

				string sql = "SELECT * FROM ArchiveBooking WHERE EntryCode = @parameter";
				command = new SqlCommand(sql, connection);
				command.Parameters.AddWithValue("@parameter", entryCode);
				reader = command.ExecuteReader();

				while (reader.Read())
				{
					booking.ID_ArchiveBooking = reader.GetInt32("ID_ArchiveBooking");
					booking.ID_ArchiveCode = reader.GetInt32("ID_ArchiveCode");
					booking.DocumentNumber = reader.GetString("DocumentNumber");
					booking.Date = reader.GetDateTime("Date");
					booking.Year = reader.GetInt32("Year");
					booking.Subject = reader.GetString("Subject");
					booking.ID_Sender = reader.GetInt32("ID_Sender");
					booking.EntryCode = reader.GetString("EntryCode");
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

			return booking;
		}

		public List<ArchiveBooking> GetArchiveBookingsByDate(DateTime date)
		{
			List<ArchiveBooking> result = new List<ArchiveBooking>();

			try
			{
				connection.Open();

				string sql = "SELECT * FROM ArchiveBooking WHERE Date='" + date.Date + "'";
				command = new SqlCommand(sql, connection);
				reader = command.ExecuteReader();

				while (reader.Read())
				{
					ArchiveBooking booking = new ArchiveBooking();

					booking.ID_ArchiveBooking = reader.GetInt32("ID_ArchiveBooking");
					booking.ID_ArchiveCode = reader.GetInt32("ID_ArchiveCode");
					booking.DocumentNumber = reader.GetString("DocumentNumber");
					booking.Date = reader.GetDateTime("Date");
					booking.Year = reader.GetInt32("Year");
					booking.Subject = reader.GetString("Subject");
					booking.ID_Sender = reader.GetInt32("ID_Sender");
					booking.EntryCode = reader.GetString("EntryCode");

					result.Add(booking);
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

		public List<ArchiveBooking> GetArchiveBookingsByYear(int year)
		{
			List<ArchiveBooking> result = new List<ArchiveBooking>();

			try
			{
				connection.Open();

				string sql = "SELECT * FROM ArchiveBooking WHERE Year=" + year;
				command = new SqlCommand(sql, connection);
				reader = command.ExecuteReader();

				while (reader.Read())
				{
					ArchiveBooking booking = new ArchiveBooking();

					booking.ID_ArchiveBooking = reader.GetInt32("ID_ArchiveBooking");
					booking.ID_ArchiveCode = reader.GetInt32("ID_ArchiveCode");
					booking.DocumentNumber = reader.GetString("DocumentNumber");
					booking.Date = reader.GetDateTime("Date");
					booking.Year = reader.GetInt32("Year");
					booking.Subject = reader.GetString("Subject");
					booking.ID_Sender = reader.GetInt32("ID_Sender");
					booking.EntryCode = reader.GetString("EntryCode");

					result.Add(booking);
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

		public List<ArchiveBooking> GetArchiveBookingsBySubject(string subject)
		{
			List<ArchiveBooking> result = new List<ArchiveBooking>();

			try
			{
				connection.Open();

				string sql = "SELECT * FROM ArchiveBooking WHERE Subject='" + subject + "'";
				command = new SqlCommand(sql, connection);
				reader = command.ExecuteReader();

				while (reader.Read())
				{
					ArchiveBooking booking = new ArchiveBooking();

					booking.ID_ArchiveBooking = reader.GetInt32("ID_ArchiveBooking");
					booking.ID_ArchiveCode = reader.GetInt32("ID_ArchiveCode");
					booking.DocumentNumber = reader.GetString("DocumentNumber");
					booking.Date = reader.GetDateTime("Date");
					booking.Year = reader.GetInt32("Year");
					booking.Subject = reader.GetString("Subject");
					booking.ID_Sender = reader.GetInt32("ID_Sender");
					booking.EntryCode = reader.GetString("EntryCode");

					result.Add(booking);
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

		public List<ArchiveBooking> GetArchiveBookingsByArchiveCode(string code)
		{
			List<ArchiveBooking> result = new List<ArchiveBooking>();

			try
			{
				connection.Open();

				string sql = "SELECT ID_ArchiveCode FROM ArchiveCode WHERE Code='" + code + "'";

				command = new SqlCommand(sql, connection);
				reader = command.ExecuteReader();
				int id = 0;
				if (reader.Read())
					id = reader.GetInt32(0);

				sql = "SELECT * FROM ArchiveBooking WHERE ID_ArchiveCode=" + id;
				command = new SqlCommand(sql, connection);
				reader = command.ExecuteReader();

				while (reader.Read())
				{
					ArchiveBooking booking = new ArchiveBooking();

					booking.ID_ArchiveBooking = reader.GetInt32("ID_ArchiveBooking");
					booking.ID_ArchiveCode = reader.GetInt32("ID_ArchiveCode");
					booking.DocumentNumber = reader.GetString("DocumentNumber");
					booking.Date = reader.GetDateTime("Date");
					booking.Year = reader.GetInt32("Year");
					booking.Subject = reader.GetString("Subject");
					booking.ID_Sender = reader.GetInt32("ID_Sender");
					booking.EntryCode = reader.GetString("EntryCode");

					result.Add(booking);
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

		public List<ArchiveBooking> GetArchiveBookingsBySender(string sender)
		{
			List<ArchiveBooking> result = new List<ArchiveBooking>();

			try
			{
				connection.Open();

				string sql = "SELECT ID_Sender FROM Sender WHERE SenderName='" + sender + "'";

				command = new SqlCommand(sql, connection);
				reader = command.ExecuteReader();

				int id = 0;
				if (reader.Read())
					id = reader.GetInt32(0);

				sql = "SELECT * FROM ArchiveBooking WHERE ID_Sender=" + id;
				command = new SqlCommand(sql, connection);
				reader = command.ExecuteReader();

				while (reader.Read())
				{
					ArchiveBooking booking = new ArchiveBooking();

					booking.ID_ArchiveBooking = reader.GetInt32("ID_ArchiveBooking");
					booking.ID_ArchiveCode = reader.GetInt32("ID_ArchiveCode");
					booking.DocumentNumber = reader.GetString("DocumentNumber");
					booking.Date = reader.GetDateTime("Date");
					booking.Year = reader.GetInt32("Year");
					booking.Subject = reader.GetString("Subject");
					booking.ID_Sender = reader.GetInt32("ID_Sender");
					booking.EntryCode = reader.GetString("EntryCode");

					result.Add(booking);
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

		public void InsertArchiveBooking(ArchiveBooking booking)
		{
			try
			{
				connection.Open();
				adapter = new SqlDataAdapter();

				string sql = "INSERT INTO ArchiveBooking(ID_ArchiveCode, DocumentNumber, Date, Year, Subject, ID_Sender, EntryCode) VALUES(" +
					"@archiveCode, @docNumber, @date, @year, @subject, @sender, @entryCode)";
				command = new SqlCommand(sql, connection);
				command.Parameters.AddWithValue("@archiveCode", booking.ID_ArchiveCode);
				command.Parameters.AddWithValue("@docNumber", booking.DocumentNumber);
				command.Parameters.AddWithValue("@date", booking.Date);
				command.Parameters.AddWithValue("@year", booking.Year);
				command.Parameters.AddWithValue("@subject", booking.Subject);
				command.Parameters.AddWithValue("@sender", booking.ID_Sender);
				command.Parameters.AddWithValue("@entryCode", booking.EntryCode);
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

		public void InsertArchiveBookings(List<ArchiveBooking> bookings)
		{
			try
			{

				foreach (ArchiveBooking booking in bookings)
				{
					InsertArchiveBooking(booking);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message.ToString());
			}
		}

		public void DeleteArchiveBookingById(int id)
		{
			try
			{
				connection.Open();
				adapter = new SqlDataAdapter();

				string sql = "DELETE FROM ArchiveBooking WHERE ID_ArchiveBooking=" + id;

				command = new SqlCommand(sql, connection);
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

		public void DeleteArchiveBookingsByArchiveCodeID(int id)
		{
			try
			{
				connection.Open();
				adapter = new SqlDataAdapter();

				string sql = "DELETE FROM ArchiveBooking WHERE ID_ArchiveCode=" + id;

				command = new SqlCommand(sql, connection);
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

		public void DeleteArchiveBookingsBySenderID(int id)
		{
			try
			{
				connection.Open();
				adapter = new SqlDataAdapter();

				string sql = "DELETE FROM ArchiveBooking WHERE ID_Sender=" + id;

				command = new SqlCommand(sql, connection);
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

		public void DeleteArchiveBookingsByYear(int year)
		{
			try
			{
				connection.Open();
				adapter = new SqlDataAdapter();

				string sql = "DELETE FROM ArchiveBooking WHERE Year = @year";

				command = new SqlCommand(sql, connection);
				command.Parameters.AddWithValue("@year", year);
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

		public void DeleteArchiveBookingsByDocumentNumber(string number)
		{
			try
			{
				connection.Open();
				adapter = new SqlDataAdapter();

				string sql = "DELETE FROM ArchiveBooking WHERE DocumentNumber='" + number + "'";

				command = new SqlCommand(sql, connection);
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

		public void DeleteArchiveBookingsByDate(DateTime date)
		{
			try
			{
				connection.Open();
				adapter = new SqlDataAdapter();

				string sql = "DELETE FROM ArchiveBooking WHERE Date='" + date.Date + "'";

				command = new SqlCommand(sql, connection);
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

		public void DeleteArchiveBookingsBySubject(string subject)
		{
			try
			{
				connection.Open();
				adapter = new SqlDataAdapter();

				string sql = "DELETE FROM ArchiveBooking WHERE Subject='" + subject + "'";

				command = new SqlCommand(sql, connection);
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

		public void DeleteArchiveBookingsByEntryCode(string entryCode)
		{
			try
			{
				connection.Open();
				adapter = new SqlDataAdapter();

				string sql = "DELETE FROM ArchiveBooking WHERE EntryCode='" + entryCode + "'";

				command = new SqlCommand(sql, connection);
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

		public void UpdateArchiveBookingByID(int id, ArchiveBooking booking)
		{
			try
			{
				connection.Open();
				adapter = new SqlDataAdapter();

				string sql = "UPDATE ArchiveBooking SET ID_ArchiveCode = @archiveCode, DocumentNumber = @docNumber, Date = @date, " +
						"Year = @year, Subject = @subject, ID_Sender = @sender, EntryCode = @entryCode WHERE ID_ArchiveBooking = @id";

				command = new SqlCommand(sql, connection);
				command.Parameters.AddWithValue("@archiveCode", booking.ID_ArchiveCode);
				command.Parameters.AddWithValue("@docNumber", booking.DocumentNumber);
				command.Parameters.AddWithValue("@date", booking.Date);
				command.Parameters.AddWithValue("@year", booking.Year);
				command.Parameters.AddWithValue("@subject", booking.Subject);
				command.Parameters.AddWithValue("@sender", booking.ID_Sender);
				command.Parameters.AddWithValue("@entryCode", booking.EntryCode);
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
