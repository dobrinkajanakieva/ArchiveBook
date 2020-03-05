using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL.EF
{
	public class SenderEngine : ISenderEngine
	{
		public SenderEngine(ArchiveBookContext context)
		{
			this.context = context;
		}

		public List<Sender> GetSenders()
		{
			return context.Senders.ToList();
		}

		public Sender GetSenderByID(int id)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("No such sender.");

			return context.Senders.Where(s => s.ID_Sender == id).FirstOrDefault();
		}

		public Sender GetSenderByName(string name)
		{
			if (name == null)
				throw new IndexOutOfRangeException("No such sender.");

			return context.Senders.Where(s => s.SenderName == name).FirstOrDefault();
		}

		public void InsertSender(Sender sender)
		{
			if (sender == null)
				throw new IndexOutOfRangeException("Empty sender.");

			context.Senders.Add(sender);
			context.SaveChanges();
		}

		public void InsertSenders(List<Sender> senders)
		{
			if (senders.Count == 0)
				throw new IndexOutOfRangeException("No senders.");

			context.Senders.AddRange(senders);
			context.SaveChanges();
		}

		public void DeleteSenderById(int id)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("No such sender.");

			Sender sender = context.Senders.Where(s => s.ID_Sender == id).FirstOrDefault();
			context.Senders.Remove(sender);
			context.SaveChanges();
		}

		public void DeleteSenderByName(string name)
		{
			if (name == null)
				throw new IndexOutOfRangeException("No such sender.");

			Sender sender = context.Senders.Where(s => s.SenderName == name).FirstOrDefault();
			context.Senders.Remove(sender);
			context.SaveChanges();
		}

		public void DeleteSendersByNames(List<string> names)
		{
			if (names.Count == 0)
				throw new IndexOutOfRangeException("No senders.");

			List<Sender> s = context.Senders.Where(s => names.Contains(s.SenderName)).ToList();
			context.Senders.RemoveRange(s);
			context.SaveChanges();
		}

		public void UpdateSenderById(int id, Sender sender)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("No such sender.");

			if (sender == null)
				throw new IndexOutOfRangeException("Empty sender.");

			Sender oldSender = context.Senders.Where(s => s.ID_Sender == id).FirstOrDefault();
			oldSender.SenderName = sender.SenderName;
			context.Senders.Update(oldSender);
			context.SaveChanges();
		}

		public void UpdateSenderByName(string name, Sender sender)
		{
			if (name == null)
				throw new IndexOutOfRangeException("No such sender.");

			if (sender == null)
				throw new IndexOutOfRangeException("Empty sender.");

			Sender oldSender = context.Senders.Where(s => s.SenderName == name).FirstOrDefault();
			oldSender.SenderName = sender.SenderName;
			context.Senders.Remove(oldSender);
			context.SaveChanges();
		}

		ArchiveBookContext context;
	}
}
