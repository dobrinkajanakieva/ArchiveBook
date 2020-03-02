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

		public List<ArchiveBooking> getArchiveBookings()
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

		public ArchiveBooking getArchiveBookingByID(int id)
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
				booking.Date = reader.GetDateTime(3);
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

			string sql = "INSERT INTO ArchiveCode(Code, Name) VALUES('" + code.Code + "', '" + code.Name + "')";
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

			foreach (ArchiveCode code in codes)
			{
				sql.Append("('" + code.Code + "', '" + code.Name + "'),");
			}

			command = new SqlCommand(sql.ToString().Substring(0, sql.ToString().Length - 1), connection);
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
