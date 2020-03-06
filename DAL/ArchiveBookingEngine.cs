using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.SQLServer
{
	public class ArchiveBookingEngine : DBClass, IArchiveBookingEngine
	{
		public ArchiveBookingEngine()
			: base() { }

		#region Functions

		public List<ArchiveBooking> GetArchiveBookings()
		{
			List<ArchiveBooking> result = new List<ArchiveBooking>();

			using(connection = new SqlConnection(connectionString))
			{
				connection.Open();

				string sql = "SELECT * FROM ArchiveBooking";
				command = new SqlCommand(sql, connection);

				using (reader = command.ExecuteReader())
				{
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
				}

				reader.Close();
				command.Dispose();
				connection.Close();
			}

			return result;
		}

		public ArchiveBooking GetArchiveBookingByID(int id)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("ID cannot be 0.");

			ArchiveBooking booking = new ArchiveBooking();

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				string sql = "SELECT * FROM ArchiveBooking WHERE ID_ArchiveBooking=@id";
				command = new SqlCommand(sql, connection);
				command.Parameters.AddWithValue("@id", id);

				using (reader = command.ExecuteReader())
				{
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
			}

			return booking;
		}

		public ArchiveBooking GetArchiveBookingByDocumentNumber(string number)
		{
			if (number == null)
				throw new IndexOutOfRangeException("DocumentNumber cannot be null.");

			ArchiveBooking booking = new ArchiveBooking();
			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				string sql = "SELECT * FROM ArchiveBooking WHERE DocumentNumber=@number";
				command = new SqlCommand(sql, connection);
				command.Parameters.AddWithValue("@number", number);

				using (reader = command.ExecuteReader())
				{
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
				}
				reader.Close();
				command.Dispose();
				connection.Close();
			}

			return booking;
		}

		public ArchiveBooking GetArchiveBookingByEntryCode(string entryCode)
		{
			if (entryCode == null)
				throw new IndexOutOfRangeException("EntryCode cannot be null.");

			ArchiveBooking booking = new ArchiveBooking();

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				string sql = "SELECT * FROM ArchiveBooking WHERE EntryCode = @entryCode";
				command = new SqlCommand(sql, connection);
				command.Parameters.AddWithValue("@entryCode", entryCode);

				using (reader = command.ExecuteReader())
				{
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
				}
				reader.Close();
				command.Dispose();
				connection.Close();
			}

			return booking;
		}

		public List<ArchiveBooking> GetArchiveBookingsByDate(DateTime date)
		{
			if (date == null)
				throw new IndexOutOfRangeException("Date cannot be null.");

			List<ArchiveBooking> result = new List<ArchiveBooking>();

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				string sql = "SELECT * FROM ArchiveBooking WHERE Date=@date";
				command = new SqlCommand(sql, connection);
				command.Parameters.AddWithValue("@date", date);

				using (reader = command.ExecuteReader())
				{
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
				}
				reader.Close();
				command.Dispose();
				connection.Close();
			}

			return result;
		}

		public List<ArchiveBooking> GetArchiveBookingsByYear(int year)
		{
			if (year == 0)
				throw new IndexOutOfRangeException("Year cannot be null.");

			List<ArchiveBooking> result = new List<ArchiveBooking>();

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				string sql = "SELECT * FROM ArchiveBooking WHERE Year=@year";
				command = new SqlCommand(sql, connection);
				command.Parameters.AddWithValue("@year", year);

				using (reader = command.ExecuteReader())
				{
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
				}
				reader.Close();
				command.Dispose();
				connection.Close();
			}

			return result;
		}

		public List<ArchiveBooking> GetArchiveBookingsBySubject(string subject)
		{
			if (subject == null)
				throw new IndexOutOfRangeException("Subject cannot be null.");

			List<ArchiveBooking> result = new List<ArchiveBooking>();

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				string sql = "SELECT * FROM ArchiveBooking WHERE Subject=@subject";
				command = new SqlCommand(sql, connection);
				command.Parameters.AddWithValue("@subject", subject);

				using (reader = command.ExecuteReader())
				{
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
				}
				reader.Close();
				command.Dispose();
				connection.Close();
			}

			return result;
		}

		public List<ArchiveBooking> GetArchiveBookingsByArchiveCode(string code)
		{
			if (code == null)
				throw new IndexOutOfRangeException("ArchiveCode cannot be null.");

			List<ArchiveBooking> result = new List<ArchiveBooking>();

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				string sql = "SELECT ID_ArchiveCode FROM ArchiveCode WHERE Code=@code";
				int id = 0;
				command = new SqlCommand(sql, connection);
				command.Parameters.AddWithValue("@code", code);

				using (reader = command.ExecuteReader())
				{
					if (reader.Read())
						id = reader.GetInt32(0);
				}

				sql = "SELECT * FROM ArchiveBooking WHERE ID_ArchiveCode=@id";
				command = new SqlCommand(sql, connection);
				command.Parameters.AddWithValue("@id", id);

				using (reader = command.ExecuteReader())
				{
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
				}
				reader.Close();
				command.Dispose();
				connection.Close();
			}

			return result;
		}

		public List<ArchiveBooking> GetArchiveBookingsBySender(string sender)
		{
			if (sender == null)
				throw new IndexOutOfRangeException("No booking.");

			List<ArchiveBooking> result = new List<ArchiveBooking>();

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				string sql = "SELECT ID_Sender FROM Sender WHERE SenderName=@sender";
				int id = 0;
				command = new SqlCommand(sql, connection);
				command.Parameters.AddWithValue("@sender", sender);

				using (reader = command.ExecuteReader())
				{
					if (reader.Read())
						id = reader.GetInt32(0);
				}

				sql = "SELECT * FROM ArchiveBooking WHERE ID_Sender=@id";
				command = new SqlCommand(sql, connection);
				command.Parameters.AddWithValue("@id", id);

				using (reader = command.ExecuteReader())
				{
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
				}
				reader.Close();
				command.Dispose();
				connection.Close();
			}

			return result;
		}

		public void InsertArchiveBooking(ArchiveBooking booking)
		{
			if (booking == null)
				throw new Exception("parameter booking is null.");

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (adapter = new SqlDataAdapter())
				{
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
				}
				command.Dispose();
				connection.Close();
			}
		}

		public void InsertArchiveBookings(List<ArchiveBooking> bookings)
		{
			if (bookings.Count == 0)
				throw new IndexOutOfRangeException("Cannot add empty list.");

			foreach (ArchiveBooking booking in bookings)
			{
				InsertArchiveBooking(booking);
			}
		}

		public void DeleteArchiveBookingById(int id)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("No booking.");

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (adapter = new SqlDataAdapter())
				{
					string sql = "DELETE FROM ArchiveBooking WHERE ID_ArchiveBooking=@id";

					command = new SqlCommand(sql, connection);
					command.Parameters.AddWithValue("@id", id);
					adapter.DeleteCommand = command;
					adapter.DeleteCommand.ExecuteNonQuery();
				}
				command.Dispose();
				connection.Close();
			}
		}

		public void DeleteArchiveBookingsByArchiveCodeID(int id)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("No booking.");

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (adapter = new SqlDataAdapter())
				{
					string sql = "DELETE FROM ArchiveBooking WHERE ID_ArchiveCode=@id";

					command = new SqlCommand(sql, connection);
					command.Parameters.AddWithValue("@id", id);
					adapter.DeleteCommand = command;
					adapter.DeleteCommand.ExecuteNonQuery();
				}
				command.Dispose();
				connection.Close();
			}
		}

		public void DeleteArchiveBookingsBySenderID(int id)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("No booking.");

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (adapter = new SqlDataAdapter())
				{
					string sql = "DELETE FROM ArchiveBooking WHERE ID_Sender=@id";

					command = new SqlCommand(sql, connection);
					command.Parameters.AddWithValue("@id", id);
					adapter.DeleteCommand = command;
					adapter.DeleteCommand.ExecuteNonQuery();
				}
				command.Dispose();
				connection.Close();
			}
		}

		public void DeleteArchiveBookingsByYear(int year)
		{
			if (year == 0)
				throw new IndexOutOfRangeException("No booking.");

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (adapter = new SqlDataAdapter())
				{
					string sql = "DELETE FROM ArchiveBooking WHERE Year = @year";

					command = new SqlCommand(sql, connection);
					command.Parameters.AddWithValue("@year", year);
					adapter.DeleteCommand = command;
					adapter.DeleteCommand.ExecuteNonQuery();
				}
				command.Dispose();
				connection.Close();
			}
		}

		public void DeleteArchiveBookingByDocumentNumber(string number)
		{
			if (number == null)
				throw new IndexOutOfRangeException("No booking.");

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (adapter = new SqlDataAdapter())
				{
					string sql = "DELETE FROM ArchiveBooking WHERE DocumentNumber=@number";

					command = new SqlCommand(sql, connection);
					command.Parameters.AddWithValue("@number", number);
					adapter.DeleteCommand = command;
					adapter.DeleteCommand.ExecuteNonQuery();
				}
				command.Dispose();
				connection.Close();
			}
		}

		public void DeleteArchiveBookingsByDate(DateTime date)
		{
			if (date == null)
				throw new IndexOutOfRangeException("No booking.");

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (adapter = new SqlDataAdapter())
				{
					string sql = "DELETE FROM ArchiveBooking WHERE Date=@date";

					command = new SqlCommand(sql, connection);
					command.Parameters.AddWithValue("@date", date);
					adapter.DeleteCommand = command;
					adapter.DeleteCommand.ExecuteNonQuery();
				}
				command.Dispose();
				connection.Close();
			}
		}

		public void DeleteArchiveBookingsBySubject(string subject)
		{
			if (subject == null)
				throw new IndexOutOfRangeException("No booking.");

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (adapter = new SqlDataAdapter())
				{
					string sql = "DELETE FROM ArchiveBooking WHERE Subject=@subject";

					command = new SqlCommand(sql, connection);
					command.Parameters.AddWithValue("@subject", subject);
					adapter.DeleteCommand = command;
					adapter.DeleteCommand.ExecuteNonQuery();
				}
				command.Dispose();
				connection.Close();
			}
		}

		public void DeleteArchiveBookingsByEntryCode(string entryCode)
		{
			if (entryCode == null)
				throw new IndexOutOfRangeException("No booking.");

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (adapter = new SqlDataAdapter())
				{
					string sql = "DELETE FROM ArchiveBooking WHERE EntryCode=@entryCode";

					command = new SqlCommand(sql, connection);
					command.Parameters.AddWithValue("@entryCode", entryCode);
					adapter.DeleteCommand = command;
					adapter.DeleteCommand.ExecuteNonQuery();
				}
				command.Dispose();
				connection.Close();
			}

		}

		public void UpdateArchiveBookingByID(int id, ArchiveBooking booking)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("No booking.");

			if (booking == null)
				throw new IndexOutOfRangeException("No booking.");

			using (connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (adapter = new SqlDataAdapter())
				{
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
