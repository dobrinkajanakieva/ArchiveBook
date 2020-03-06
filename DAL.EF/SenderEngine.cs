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
		public SenderEngine()
		{
			this.context = new ArchiveBookContext();
		}

		public List<Sender> GetSenders()
		{
			return context.Senders.ToList();
		}

		public Sender GetSenderByID(int id)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("Invalid id.");

			return context.Senders.Where(s => s.ID_Sender == id).FirstOrDefault();
		}

		public Sender GetSenderByName(string name)
		{
			if (name == null)
				throw new IndexOutOfRangeException("Invalid name.");

			return context.Senders.Where(s => s.SenderName == name).FirstOrDefault();
		}

		public void InsertSender(Sender sender)
		{
			if (sender == null)
				throw new IndexOutOfRangeException("Empty sender.");

			sender.ID_Sender = null;

			context.Senders.Add(sender);
			context.SaveChanges();
		}

		public void InsertSenders(List<Sender> senders)
		{
			if (senders.Count == 0)
				throw new IndexOutOfRangeException("No senders.");

			foreach (Sender sender in senders)
				sender.ID_Sender = null;

			context.Senders.AddRange(senders);
			context.SaveChanges();
		}

		public void DeleteSenderById(int id)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("Invalid id.");

			Sender sender = context.Senders.Where(s => s.ID_Sender == id).FirstOrDefault();
			if (sender == null)
				//throw new ArgumentNullException("No sender with that id in db.");
				return;
			context.Senders.Remove(sender);
			context.SaveChanges();
		}

		public void DeleteSenderByName(string name)
		{
			if (name == null)
				throw new IndexOutOfRangeException("Invalid name.");

			Sender sender = context.Senders.Where(s => s.SenderName == name).FirstOrDefault();
			if (sender == null)
				//throw new ArgumentNullException("No sender with that name in db.");
				return;
			context.Senders.Remove(sender);
			context.SaveChanges();
		}

		public void DeleteSendersByNames(List<string> names)
		{
			if (names.Count == 0)
				throw new IndexOutOfRangeException("No senders.");

			List<Sender> s = context.Senders.Where(s => names.Contains(s.SenderName)).ToList();
			if (s == null)
				//throw new ArgumentNullException("No senders with those names in db.");
				return;
			context.Senders.RemoveRange(s);
			context.SaveChanges();
		}

		public void UpdateSenderById(int id, Sender sender)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("Invalid id.");

			if (sender == null)
				throw new IndexOutOfRangeException("Empty sender.");

			Sender oldSender = context.Senders.Where(s => s.ID_Sender == id).FirstOrDefault();
			if (oldSender == null)
				//throw new ArgumentNullException("No sender with that name in db.");
				return;
			oldSender.SenderName = sender.SenderName;
			context.Senders.Update(oldSender);
			context.SaveChanges();
		}

		public void UpdateSenderByName(string name, Sender sender)
		{
			if (name == null)
				throw new IndexOutOfRangeException("Invalid name.");

			if (sender == null)
				throw new IndexOutOfRangeException("Empty sender.");

			Sender oldSender = context.Senders.Where(s => s.SenderName == name).FirstOrDefault();
			if (oldSender == null)
				//throw new ArgumentNullException("No sender with that name in db.");
				return;
			oldSender.SenderName = sender.SenderName;
			context.Senders.Update(oldSender);
			context.SaveChanges();
		}

		ArchiveBookContext context;
	}
}
