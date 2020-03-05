using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
	public interface IArchiveBookingEngine
	{
		List<ArchiveBooking> GetArchiveBookings();
		ArchiveBooking GetArchiveBookingByID(int id);
		ArchiveBooking GetArchiveBookingByDocumentNumber(string number);
		ArchiveBooking GetArchiveBookingByEntryCode(string entryCode);
		List<ArchiveBooking> GetArchiveBookingsByDate(DateTime date);
		List<ArchiveBooking> GetArchiveBookingsByYear(int year);
		List<ArchiveBooking> GetArchiveBookingsBySubject(string subject);
		List<ArchiveBooking> GetArchiveBookingsByArchiveCode(string code);
		List<ArchiveBooking> GetArchiveBookingsBySender(string sender);
		void InsertArchiveBooking(ArchiveBooking booking);
		void InsertArchiveBookings(List<ArchiveBooking> bookings);
		void DeleteArchiveBookingById(int id);
		void DeleteArchiveBookingsByArchiveCodeID(int id);
		void DeleteArchiveBookingsBySenderID(int id);
		void DeleteArchiveBookingsByYear(int year);
		void DeleteArchiveBookingsByDocumentNumber(string number);
		void DeleteArchiveBookingsByDate(DateTime date);
		void DeleteArchiveBookingsBySubject(string subject);
		void DeleteArchiveBookingsByEntryCode(string entryCode);
		void UpdateArchiveBookingByID(int id, ArchiveBooking booking);

	}
}
