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
			return context.ArchiveBookings.Where(a => a.ID_ArchiveBooking == id).FirstOrDefault();
		}

		public ArchiveBooking GetArchiveBookingByDocumentNumber(string number)
		{
			return context.ArchiveBookings.Where(a => a.DocumentNumber == number).FirstOrDefault();
		}

		public ArchiveBooking GetArchiveBookingByEntryCode(string entryCode)
		{
			return context.ArchiveBookings.Where(a => a.EntryCode == entryCode).FirstOrDefault();
		}

		public List<ArchiveBooking> GetArchiveBookingsByDate(DateTime date)
		{
			return context.ArchiveBookings.Where(a => a.Date == date).ToList();
		}

		public List<ArchiveBooking> GetArchiveBookingsByYear(int year)
		{
			return context.ArchiveBookings.Where(a => a.Year == year).ToList();
		}

		public List<ArchiveBooking> GetArchiveBookingsBySubject(string subject)
		{
			return context.ArchiveBookings.Where(a => a.Subject == subject).ToList();
		}

		public List<ArchiveBooking> GetArchiveBookingsByArchiveCode(string code)
		{
			int id = context.ArchiveCodes.Where(c => c.Code == code).FirstOrDefault().ID_ArchiveCode;
			return context.ArchiveBookings.Where(a => a.ID_ArchiveCode == id).ToList();
		}

		public List<ArchiveBooking> GetArchiveBookingsBySender(string sender)
		{
			int id = context.Senders.Where(s => s.SenderName == sender).FirstOrDefault().ID_Sender;
			return context.ArchiveBookings.Where(a => a.ID_Sender == id).ToList();
		}

		public void InsertArchiveBooking(ArchiveBooking booking)
		{
			context.ArchiveBookings.Add(booking);
			context.SaveChanges();
		}

		public void InsertArchiveBookings(List<ArchiveBooking> bookings)
		{
			context.ArchiveBookings.AddRange(bookings);
			context.SaveChanges();
		}

		public void DeleteArchiveBookingById(int id)
		{
			ArchiveBooking booking = context.ArchiveBookings.Where(a => a.ID_ArchiveBooking == id).FirstOrDefault();
			context.ArchiveBookings.Remove(booking);
			context.SaveChanges();
		}

		public void DeleteArchiveBookingsByArchiveCodeID(int id)
		{
			ArchiveBooking booking = context.ArchiveBookings.Where(a => a.ID_ArchiveCode == id).FirstOrDefault();
			context.ArchiveBookings.Remove(booking);
			context.SaveChanges();
		}

		public void DeleteArchiveBookingsBySenderID(int id)
		{
			ArchiveBooking booking = context.ArchiveBookings.Where(a => a.ID_Sender == id).FirstOrDefault();
			context.ArchiveBookings.Remove(booking);
			context.SaveChanges();
		}

		public void DeleteArchiveBookingsByYear(int year)
		{
			ArchiveBooking booking = context.ArchiveBookings.Where(a => a.Year == year).FirstOrDefault();
			context.ArchiveBookings.Remove(booking);
			context.SaveChanges();
		}

		public void DeleteArchiveBookingsByDocumentNumber(string number)
		{
			ArchiveBooking booking = context.ArchiveBookings.Where(a => a.DocumentNumber == number).FirstOrDefault();
			context.ArchiveBookings.Remove(booking);
			context.SaveChanges();
		}

		public void DeleteArchiveBookingsByDate(DateTime date)
		{
			ArchiveBooking booking = context.ArchiveBookings.Where(a => a.Date == date).FirstOrDefault();
			context.ArchiveBookings.Remove(booking);
			context.SaveChanges();
		}

		public void DeleteArchiveBookingsBySubject(string subject)
		{
			ArchiveBooking booking = context.ArchiveBookings.Where(a => a.Subject == subject).FirstOrDefault();
			context.ArchiveBookings.Remove(booking);
			context.SaveChanges();
		}

		public void DeleteArchiveBookingsByEntryCode(string entryCode)
		{
			ArchiveBooking booking = context.ArchiveBookings.Where(a => a.EntryCode == entryCode).FirstOrDefault();
			context.ArchiveBookings.Remove(booking);
			context.SaveChanges();
		}

		public void UpdateArchiveBookingByID(int id, ArchiveBooking booking)
		{
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
