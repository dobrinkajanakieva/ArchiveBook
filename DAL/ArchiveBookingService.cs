using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
	public class ArchiveBookingService
	{
		public ArchiveBookingService()
		{
			connection = new SqlConnection(connectionString);
		}

		#region Functions

		public List<ArchiveBooking> GetArchiveBookings()
		{
			List<ArchiveBooking> result = new List<ArchiveBooking>();

			connection.Open();

			string sql = "SELECT * FROM ArchiveBooking";
			command = new SqlCommand(sql, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				ArchiveBooking booking = new ArchiveBooking();

				booking.ID_ArchiveBooking = int.Parse(reader.GetInt32(0).ToString());
				booking.ID_ArchiveCode = int.Parse(reader.GetInt32(1).ToString());
				booking.DocumentNumber = reader.GetString(2);
				booking.Date = reader.GetDateTime(3);
				booking.Year = int.Parse(reader.GetInt32(4).ToString());
				booking.Subject = reader.GetString(5);
				booking.ID_Sender = int.Parse(reader.GetInt32(6).ToString());
				booking.EntryCode = reader.GetString(7);

				result.Add(booking);
			}

			reader.Close();
			command.Dispose();
			connection.Close();

			return result;
		}

		public ArchiveBooking GetArchiveBookingByID(int id)
		{
			ArchiveBooking booking = new ArchiveBooking();

			connection.Open();

			string sql = "SELECT * FROM ArchiveBooking WHERE ID_ArchiveBooking=" + id;
			command = new SqlCommand(sql, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				booking.ID_ArchiveBooking = int.Parse(reader.GetInt32(0).ToString());
				booking.ID_ArchiveCode = int.Parse(reader.GetInt32(1).ToString());
				booking.DocumentNumber = reader.GetString(2);
				booking.Date = reader.GetDateTime(3).Date;
				booking.Year = int.Parse(reader.GetInt32(4).ToString());
				booking.Subject = reader.GetString(5);
				booking.ID_Sender = int.Parse(reader.GetInt32(6).ToString());
				booking.EntryCode = reader.GetString(7);
			}

			reader.Close();
			command.Dispose();
			connection.Close();

			return booking;
		}

		public ArchiveBooking GetArchiveBookingByDocumentNumber(string number)
		{
			ArchiveBooking booking = new ArchiveBooking();

			connection.Open();

			string sql = "SELECT * FROM ArchiveBooking WHERE DocumentNumber='" + number + "'";
			command = new SqlCommand(sql, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				booking.ID_ArchiveBooking = int.Parse(reader.GetInt32(0).ToString());
				booking.ID_ArchiveCode = int.Parse(reader.GetInt32(1).ToString());
				booking.DocumentNumber = reader.GetString(2);
				booking.Date = reader.GetDateTime(3).Date;
				booking.Year = int.Parse(reader.GetInt32(4).ToString());
				booking.Subject = reader.GetString(5);
				booking.ID_Sender = int.Parse(reader.GetInt32(6).ToString());
				booking.EntryCode = reader.GetString(7);
			}

			reader.Close();
			command.Dispose();
			connection.Close();

			return booking;
		}

		public ArchiveBooking GetArchiveBookingByEntryCode(string entryCode)
		{
			ArchiveBooking booking = new ArchiveBooking();

			connection.Open();

			string sql = "SELECT * FROM ArchiveBooking WHERE EntryCode='" + entryCode + "'";
			command = new SqlCommand(sql, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				booking.ID_ArchiveBooking = int.Parse(reader.GetInt32(0).ToString());
				booking.ID_ArchiveCode = int.Parse(reader.GetInt32(1).ToString());
				booking.DocumentNumber = reader.GetString(2);
				booking.Date = reader.GetDateTime(3).Date;
				booking.Year = int.Parse(reader.GetInt32(4).ToString());
				booking.Subject = reader.GetString(5);
				booking.ID_Sender = int.Parse(reader.GetInt32(6).ToString());
				booking.EntryCode = reader.GetString(7);
			}

			reader.Close();
			command.Dispose();
			connection.Close();

			return booking;
		}

		public List<ArchiveBooking> GetArchiveBookingsByDate(DateTime date)
		{
			List<ArchiveBooking> result = new List<ArchiveBooking>();

			connection.Open();

			string sql = "SELECT * FROM ArchiveBooking WHERE Date='" + date.Date + "'";
			command = new SqlCommand(sql, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				ArchiveBooking booking = new ArchiveBooking();

				booking.ID_ArchiveBooking = int.Parse(reader.GetInt32(0).ToString());
				booking.ID_ArchiveCode = int.Parse(reader.GetInt32(1).ToString());
				booking.DocumentNumber = reader.GetString(2);
				booking.Date = reader.GetDateTime(3).Date;
				booking.Year = int.Parse(reader.GetInt32(4).ToString());
				booking.Subject = reader.GetString(5);
				booking.ID_Sender = int.Parse(reader.GetInt32(6).ToString());
				booking.EntryCode = reader.GetString(7);

				result.Add(booking);
			}

			reader.Close();
			command.Dispose();
			connection.Close();

			return result;
		}

		public List<ArchiveBooking> GetArchiveBookingsByYear(int year)
		{
			List<ArchiveBooking> result = new List<ArchiveBooking>();

			connection.Open();

			string sql = "SELECT * FROM ArchiveBooking WHERE Year=" + year;
			command = new SqlCommand(sql, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				ArchiveBooking booking = new ArchiveBooking();

				booking.ID_ArchiveBooking = int.Parse(reader.GetInt32(0).ToString());
				booking.ID_ArchiveCode = int.Parse(reader.GetInt32(1).ToString());
				booking.DocumentNumber = reader.GetString(2);
				booking.Date = reader.GetDateTime(3).Date;
				booking.Year = int.Parse(reader.GetInt32(4).ToString());
				booking.Subject = reader.GetString(5);
				booking.ID_Sender = int.Parse(reader.GetInt32(6).ToString());
				booking.EntryCode = reader.GetString(7);

				result.Add(booking);
			}

			reader.Close();
			command.Dispose();
			connection.Close();

			return result;
		}

		public List<ArchiveBooking> GetArchiveBookingsBySubject(string subject)
		{
			List<ArchiveBooking> result = new List<ArchiveBooking>();

			connection.Open();

			string sql = "SELECT * FROM ArchiveBooking WHERE Subject='" + subject + "'";
			command = new SqlCommand(sql, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				ArchiveBooking booking = new ArchiveBooking();

				booking.ID_ArchiveBooking = int.Parse(reader.GetInt32(0).ToString());
				booking.ID_ArchiveCode = int.Parse(reader.GetInt32(1).ToString());
				booking.DocumentNumber = reader.GetString(2);
				booking.Date = reader.GetDateTime(3).Date;
				booking.Year = int.Parse(reader.GetInt32(4).ToString());
				booking.Subject = reader.GetString(5);
				booking.ID_Sender = int.Parse(reader.GetInt32(6).ToString());
				booking.EntryCode = reader.GetString(7);

				result.Add(booking);
			}

			reader.Close();
			command.Dispose();
			connection.Close();

			return result;
		}

		public List<ArchiveBooking> GetArchiveBookingsByArchiveCode(string code)
		{
			List<ArchiveBooking> result = new List<ArchiveBooking>();

			connection.Open();

			string sql = "SELECT ID_ArchiveCode FROM ArchiveCode WHERE Code='" + code + "'";

			command = new SqlCommand(sql, connection);
			reader = command.ExecuteReader();
			int id = 0;
			if(reader.Read())
				id = reader.GetInt32(0);

			sql = "SELECT * FROM ArchiveBooking WHERE ID_ArchiveCode=" + id;
			command = new SqlCommand(sql, connection);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
				ArchiveBooking booking = new ArchiveBooking();

				booking.ID_ArchiveBooking = int.Parse(reader.GetInt32(0).ToString());
				booking.ID_ArchiveCode = int.Parse(reader.GetInt32(1).ToString());
				booking.DocumentNumber = reader.GetString(2);
				booking.Date = reader.GetDateTime(3).Date;
				booking.Year = int.Parse(reader.GetInt32(4).ToString());
				booking.Subject = reader.GetString(5);
				booking.ID_Sender = int.Parse(reader.GetInt32(6).ToString());
				booking.EntryCode = reader.GetString(7);

				result.Add(booking);
			}

			reader.Close();
			command.Dispose();
			connection.Close();

			return result;
		}

		public List<ArchiveBooking> GetArchiveBookingsBySender(string sender)
		{
			List<ArchiveBooking> result = new List<ArchiveBooking>();

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

				booking.ID_ArchiveBooking = int.Parse(reader.GetInt32(0).ToString());
				booking.ID_ArchiveCode = int.Parse(reader.GetInt32(1).ToString());
				booking.DocumentNumber = reader.GetString(2);
				booking.Date = reader.GetDateTime(3).Date;
				booking.Year = int.Parse(reader.GetInt32(4).ToString());
				booking.Subject = reader.GetString(5);
				booking.ID_Sender = int.Parse(reader.GetInt32(6).ToString());
				booking.EntryCode = reader.GetString(7);

				result.Add(booking);
			}

			reader.Close();
			command.Dispose();
			connection.Close();

			return result;
		}

		public void InsertArchiveBooking(ArchiveBooking booking)
		{
			connection.Open();
			adapter = new SqlDataAdapter();

			string sql = "INSERT INTO ArchiveBooking(ID_ArchiveCode, DocumentNumber, Date, Year, Subject, ID_Sender, EntryCode) VALUES(" 
				+ booking.ID_ArchiveCode + ", '" + booking.DocumentNumber + "', '" + booking.Date.Date + "', " + booking.Year 
				+ ", '" + booking.Subject + "', " + booking.ID_Sender + ", '" + booking.EntryCode+ "')";
			command = new SqlCommand(sql, connection);
			adapter.InsertCommand = command;
			adapter.InsertCommand.ExecuteNonQuery();

			command.Dispose();
			connection.Close();
		}

		public void InsertArchiveBookings(List<ArchiveBooking> bookings)
		{

			foreach (ArchiveBooking booking in bookings)
			{
				InsertArchiveBooking(booking);
			}
		}

		public void DeleteArchiveBookingById(int id)
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

		public void DeleteArchiveBookingsByArchiveCodeID(int id)
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

		public void DeleteArchiveBookingsBySenderID(int id)
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

		public void DeleteArchiveBookingsByYear(int year)
		{
			connection.Open();
			adapter = new SqlDataAdapter();

			string sql = "DELETE FROM ArchiveBooking WHERE Year=" + year;

			command = new SqlCommand(sql, connection);
			adapter.DeleteCommand = command;
			adapter.DeleteCommand.ExecuteNonQuery();

			command.Dispose();
			connection.Close();
		}

		public void DeleteArchiveBookingsByDocumentNumber(string number)
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

		public void DeleteArchiveBookingsByDate(DateTime date)
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

		public void DeleteArchiveBookingsBySubject(string subject)
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

		public void DeleteArchiveBookingsByEntryCode(string entryCode)
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

		public void UpdateArchiveBookingByID(int id, ArchiveBooking booking)
		{
			connection.Open();
			adapter = new SqlDataAdapter();

			string sql = "UPDATE ArchiveBooking SET ID_ArchiveCode=" + booking.ID_ArchiveCode + ", DocumentNumber='" 
				+ booking.DocumentNumber + "', Date='" + booking.Date.Date + "', Year=" + booking.Year + ", Subject='" + booking.Subject 
				+ "', ID_Sender=" + booking.ID_Sender + ", EntryCode='" + booking.EntryCode + "' WHERE ID_ArchiveBooking=" + id;

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
