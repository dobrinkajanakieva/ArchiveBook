using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.EF
{
	public class ArchiveBookingEngine : IArchiveBookingEngine
	{
		public ArchiveBookingEngine()
		{
			this.context = new ArchiveBookContext();
		}

		public List<ArchiveBooking> GetArchiveBookings()
		{
			return context.ArchiveBookings.ToList();
		}

		public ArchiveBooking GetArchiveBookingByID(int id)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("Invalid id.");

			return context.ArchiveBookings.Where(a => a.ID_ArchiveBooking == id).FirstOrDefault();
		}

		public ArchiveBooking GetArchiveBookingByDocumentNumber(string number)
		{
			if (number == null)
				throw new IndexOutOfRangeException("Invalid DocumentNumber.");

			return context.ArchiveBookings.Where(a => a.DocumentNumber == number).FirstOrDefault();
		}

		public ArchiveBooking GetArchiveBookingByEntryCode(string entryCode)
		{
			if (entryCode == null)
				throw new IndexOutOfRangeException("Invalid EntryCode.");

			return context.ArchiveBookings.Where(a => a.EntryCode == entryCode).FirstOrDefault();
		}

		public List<ArchiveBooking> GetArchiveBookingsByDate(DateTime date)
		{
			if (date == null)
				throw new IndexOutOfRangeException("Invalid Date.");

			return context.ArchiveBookings.Where(a => a.Date == date).ToList();
		}

		public List<ArchiveBooking> GetArchiveBookingsByYear(int year)
		{
			if (year == 0)
				throw new IndexOutOfRangeException("Invalid Year.");

			return context.ArchiveBookings.Where(a => a.Year == year).ToList();
		}

		public List<ArchiveBooking> GetArchiveBookingsBySubject(string subject)
		{
			if (subject == null)
				throw new IndexOutOfRangeException("Invalid Subject.");

			return context.ArchiveBookings.Where(a => a.Subject == subject).ToList();
		}

		public List<ArchiveBooking> GetArchiveBookingsByArchiveCode(string code)
		{
			if (code == null)
				throw new IndexOutOfRangeException("Invalid ArchiveCode.");

			int? id = context.ArchiveCodes.Where(c => c.Code == code).FirstOrDefault().ID_ArchiveCode;
			return context.ArchiveBookings.Where(a => a.ID_ArchiveCode == id).ToList();
		}

		public List<ArchiveBooking> GetArchiveBookingsBySender(string sender)
		{
			if (sender == null)
				throw new IndexOutOfRangeException("Invalid Sender.");

			int? id = context.Senders.Where(s => s.SenderName == sender).FirstOrDefault().ID_Sender;
			return context.ArchiveBookings.Where(a => a.ID_Sender == id).ToList();
		}

		public void InsertArchiveBooking(ArchiveBooking booking)
		{
			if (booking == null)
				throw new Exception("Empty booking.");

			booking.ID_ArchiveBooking = null;

			context.ArchiveBookings.Add(booking);
			context.Entry<ArchiveBooking>(booking).State = EntityState.Detached;
			context.SaveChanges();
		}

		public void InsertArchiveBookings(List<ArchiveBooking> bookings)
		{
			if (bookings.Count == 0)
				throw new IndexOutOfRangeException("No bookings.");

			foreach (ArchiveBooking booking in bookings)
				booking.ID_ArchiveBooking = null;

			context.ArchiveBookings.AddRange(bookings);
			context.SaveChanges();
		}

		public void DeleteArchiveBookingById(int id)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("Invalid id.");

			ArchiveBooking booking = context.ArchiveBookings.Where(a => a.ID_ArchiveBooking == id).FirstOrDefault();
			if (booking == null)
				//throw new ArgumentNullException("No booking with that id in db.");
				return;
			context.ArchiveBookings.Remove(booking);
			context.SaveChanges();
		}

		public void DeleteArchiveBookingsByArchiveCodeID(int id)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("Invalid id.");

			List<ArchiveBooking> bookings = context.ArchiveBookings.Where(a => a.ID_ArchiveCode == id).ToList();
			if (bookings == null)
				//throw new ArgumentNullException("No bookings with that code id in db.");
				return;
			context.ArchiveBookings.RemoveRange(bookings);
			context.SaveChanges();
		}

		public void DeleteArchiveBookingsBySenderID(int id)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("Invalid id.");

			List<ArchiveBooking> bookings = context.ArchiveBookings.Where(a => a.ID_Sender == id).ToList();
			if (bookings.Count == 0)
				//throw new ArgumentNullException("No bookings with that sender id in db.");
				return;
			context.ArchiveBookings.RemoveRange(bookings);
			context.SaveChanges();
		}

		public void DeleteArchiveBookingsByYear(int year)
		{
			if (year == 0)
				throw new IndexOutOfRangeException("Invalid year.");

			List<ArchiveBooking> bookings = context.ArchiveBookings.Where(a => a.Year == year).ToList();
			if (bookings == null)
				//throw new ArgumentNullException("No bookings with that year in db.");
				return;
			context.ArchiveBookings.RemoveRange(bookings);
			context.SaveChanges();
		}

		public void DeleteArchiveBookingByDocumentNumber(string number)
		{
			if (number == null)
				throw new IndexOutOfRangeException("Invalid DocumentNumber.");

			ArchiveBooking booking = context.ArchiveBookings.Where(a => a.DocumentNumber == number).FirstOrDefault();
			if (booking == null)
				//throw new ArgumentNullException("No booking with that Document Number in db.");
				return;
			context.ArchiveBookings.Remove(booking);
			context.SaveChanges();
		}

		public void DeleteArchiveBookingsByDate(DateTime date)
		{
			if (date == null)
				throw new IndexOutOfRangeException("Invalid date.");

			List<ArchiveBooking> bookings = context.ArchiveBookings.Where(a => a.Date == date).ToList();
			if (bookings == null)
				//throw new ArgumentNullException("No bookings with that date in db.");
				return;
			context.ArchiveBookings.RemoveRange(bookings);
			context.SaveChanges();
		}

		public void DeleteArchiveBookingsBySubject(string subject)
		{
			if (subject == null)
				throw new IndexOutOfRangeException("Invalid subject.");

			List<ArchiveBooking> bookings = context.ArchiveBookings.Where(a => a.Subject == subject).ToList();
			if (bookings == null)
				//throw new ArgumentNullException("No bookings with that subject in db.");
				return;
			context.ArchiveBookings.RemoveRange(bookings);
			context.SaveChanges();
		}

		public void DeleteArchiveBookingsByEntryCode(string entryCode)
		{
			if (entryCode == null)
				throw new IndexOutOfRangeException("Invalid entryCode.");

			ArchiveBooking booking = context.ArchiveBookings.Where(a => a.EntryCode == entryCode).FirstOrDefault();
			if (booking == null)
				//throw new ArgumentNullException("No booking with that Entry Code in db.");
				return;
			context.ArchiveBookings.Remove(booking);
			context.SaveChanges();
		}

		public void UpdateArchiveBookingByID(int id, ArchiveBooking booking)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("Invalid id.");

			if (booking == null)
				throw new IndexOutOfRangeException("Empty booking.");

			ArchiveBooking oldBooking = context.ArchiveBookings.Where(a => a.ID_ArchiveBooking == id).FirstOrDefault();
			if (oldBooking == null)
				//throw new ArgumentNullException("No booking with that id in db.");
				return;
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
