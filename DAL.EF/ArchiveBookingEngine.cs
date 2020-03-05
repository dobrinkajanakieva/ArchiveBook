using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.EF
{
	public class ArchiveBookingEngine : IArchiveBookingEngine
	{
		public ArchiveBookingEngine(ArchiveBookContext context)
		{
			this.context = context;
		}

		public List<ArchiveBooking> GetArchiveBookings()
		{
			return context.ArchiveBookings.ToList();
		}

		public ArchiveBooking GetArchiveBookingByID(int id)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("ID cannot be 0.");

			return context.ArchiveBookings.Where(a => a.ID_ArchiveBooking == id).FirstOrDefault();
		}

		public ArchiveBooking GetArchiveBookingByDocumentNumber(string number)
		{
			if (number == null)
				throw new IndexOutOfRangeException("DocumentNumber cannot be null.");

			return context.ArchiveBookings.Where(a => a.DocumentNumber == number).FirstOrDefault();
		}

		public ArchiveBooking GetArchiveBookingByEntryCode(string entryCode)
		{
			if (entryCode == null)
				throw new IndexOutOfRangeException("EntryCode cannot be null.");

			return context.ArchiveBookings.Where(a => a.EntryCode == entryCode).FirstOrDefault();
		}

		public List<ArchiveBooking> GetArchiveBookingsByDate(DateTime date)
		{
			if (date == null)
				throw new IndexOutOfRangeException("Date cannot be null.");

			return context.ArchiveBookings.Where(a => a.Date == date).ToList();
		}

		public List<ArchiveBooking> GetArchiveBookingsByYear(int year)
		{
			if (year == 0)
				throw new IndexOutOfRangeException("Year cannot be null.");

			return context.ArchiveBookings.Where(a => a.Year == year).ToList();
		}

		public List<ArchiveBooking> GetArchiveBookingsBySubject(string subject)
		{
			if (subject == null)
				throw new IndexOutOfRangeException("Subject cannot be null.");

			return context.ArchiveBookings.Where(a => a.Subject == subject).ToList();
		}

		public List<ArchiveBooking> GetArchiveBookingsByArchiveCode(string code)
		{
			if (code == null)
				throw new IndexOutOfRangeException("ArchiveCode cannot be null.");

			int id = context.ArchiveCodes.Where(c => c.Code == code).FirstOrDefault().ID_ArchiveCode;
			return context.ArchiveBookings.Where(a => a.ID_ArchiveCode == id).ToList();
		}

		public List<ArchiveBooking> GetArchiveBookingsBySender(string sender)
		{
			if (sender == null)
				throw new IndexOutOfRangeException("No booking.");

			int id = context.Senders.Where(s => s.SenderName == sender).FirstOrDefault().ID_Sender;
			return context.ArchiveBookings.Where(a => a.ID_Sender == id).ToList();
		}

		public void InsertArchiveBooking(ArchiveBooking booking)
		{
			if (booking == null)
				throw new Exception("parameter booking is null.");

			context.ArchiveBookings.Add(booking);
			context.SaveChanges();
		}

		public void InsertArchiveBookings(List<ArchiveBooking> bookings)
		{
			if (bookings.Count == 0)
				throw new IndexOutOfRangeException("Cannot add empty list.");

			context.ArchiveBookings.AddRange(bookings);
			context.SaveChanges();
		}

		public void DeleteArchiveBookingById(int id)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("No booking.");

			ArchiveBooking booking = context.ArchiveBookings.Where(a => a.ID_ArchiveBooking == id).FirstOrDefault();
			context.ArchiveBookings.Remove(booking);
			context.SaveChanges();
		}

		public void DeleteArchiveBookingsByArchiveCodeID(int id)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("No booking.");

			ArchiveBooking booking = context.ArchiveBookings.Where(a => a.ID_ArchiveCode == id).FirstOrDefault();
			context.ArchiveBookings.Remove(booking);
			context.SaveChanges();
		}

		public void DeleteArchiveBookingsBySenderID(int id)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("No booking.");

			ArchiveBooking booking = context.ArchiveBookings.Where(a => a.ID_Sender == id).FirstOrDefault();
			context.ArchiveBookings.Remove(booking);
			context.SaveChanges();
		}

		public void DeleteArchiveBookingsByYear(int year)
		{
			if (year == 0)
				throw new IndexOutOfRangeException("No booking.");

			ArchiveBooking booking = context.ArchiveBookings.Where(a => a.Year == year).FirstOrDefault();
			context.ArchiveBookings.Remove(booking);
			context.SaveChanges();
		}

		public void DeleteArchiveBookingsByDocumentNumber(string number)
		{
			if (number == null)
				throw new IndexOutOfRangeException("No booking.");

			ArchiveBooking booking = context.ArchiveBookings.Where(a => a.DocumentNumber == number).FirstOrDefault();
			context.ArchiveBookings.Remove(booking);
			context.SaveChanges();
		}

		public void DeleteArchiveBookingsByDate(DateTime date)
		{
			if (date == null)
				throw new IndexOutOfRangeException("No booking.");

			ArchiveBooking booking = context.ArchiveBookings.Where(a => a.Date == date).FirstOrDefault();
			context.ArchiveBookings.Remove(booking);
			context.SaveChanges();
		}

		public void DeleteArchiveBookingsBySubject(string subject)
		{
			if (subject == null)
				throw new IndexOutOfRangeException("No booking.");

			ArchiveBooking booking = context.ArchiveBookings.Where(a => a.Subject == subject).FirstOrDefault();
			context.ArchiveBookings.Remove(booking);
			context.SaveChanges();
		}

		public void DeleteArchiveBookingsByEntryCode(string entryCode)
		{
			if (entryCode == null)
				throw new IndexOutOfRangeException("No booking.");

			ArchiveBooking booking = context.ArchiveBookings.Where(a => a.EntryCode == entryCode).FirstOrDefault();
			context.ArchiveBookings.Remove(booking);
			context.SaveChanges();
		}

		public void UpdateArchiveBookingByID(int id, ArchiveBooking booking)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("No booking.");

			if (booking == null)
				throw new IndexOutOfRangeException("No booking.");

			ArchiveBooking oldBooking = context.ArchiveBookings.Where(a => a.ID_ArchiveBooking == id).FirstOrDefault();
			oldBooking.ID_ArchiveCode = booking.ID_ArchiveCode;
			oldBooking.DocumentNumber = booking.DocumentNumber;
			oldBooking.Date = booking.Date;
			oldBooking.Year = booking.Year;
			oldBooking.ID_Sender = booking.ID_Sender;
			oldBooking.Subject = booking.Subject;
			oldBooking.EntryCode = booking.EntryCode;
			context.ArchiveBookings.Update(oldBooking);
			context.SaveChanges();
		}

		ArchiveBookContext context;
	}
}
