using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL.EF
{
	public class ArchiveCodeEngine : IArchiveCodeEngine
	{
		public ArchiveCodeEngine()
		{
			this.context = new ArchiveBookContext();
		}

		public List<ArchiveCode> GetArchiveCodes()
		{
			return context.ArchiveCodes.ToList();
		}

		public List<ArchiveCode> GetArchiveCodesByCodes(List<string> codes)
		{
			if (codes.Count == 0)
				throw new IndexOutOfRangeException("No codes.");

			return context.ArchiveCodes.Where(c => codes.Contains(c.Code)).ToList();
		}

		public ArchiveCode GetArchiveCodeByID(int id)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("Invalid id.");

			return context.ArchiveCodes.Where(c => c.ID_ArchiveCode == id).FirstOrDefault();
		}

		public ArchiveCode GetArchiveCodeByCode(string code)
		{
			if (code == null)
				throw new IndexOutOfRangeException("Invalid code.");

			return context.ArchiveCodes.Where(c => c.Code == code).FirstOrDefault();
		}

		public void InsertArchiveCode(ArchiveCode code)
		{
			if (code.ID_ArchiveCode == 0)
				throw new IndexOutOfRangeException("Empty code.");

			code.ID_ArchiveCode = null;

			context.Add(code);
			context.SaveChanges();
		}

		public void InsertArchiveCodes(List<ArchiveCode> codes)
		{
			if (codes.Count == 0)
				throw new IndexOutOfRangeException("No codes.");

			foreach (ArchiveCode code in codes)
				code.ID_ArchiveCode = null;

			context.AddRange(codes);
			context.SaveChanges();
		}

		public void DeleteArchiveCodeById(int id)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("Invalid id.");

			ArchiveCode code = context.ArchiveCodes.Where(c => c.ID_ArchiveCode == id).FirstOrDefault();
			if (code == null)
				//throw new ArgumentNullException("No code with that id in db.");
				return;
			context.ArchiveCodes.Remove(code);
			context.SaveChanges();
		}

		public void DeleteArchiveCodeByCode(string code)
		{
			if (code == null)
				throw new IndexOutOfRangeException("Invalid code.");

			ArchiveCode c = context.ArchiveCodes.Where(c => c.Code == code).FirstOrDefault();
			if (c == null)
				//throw new ArgumentNullException("No code with that code in db.");
				return;
			context.ArchiveCodes.Remove(c);
			context.SaveChanges();
		}

		public void DeleteArchiveCodesByCodes(List<string> codes)
		{
			if (codes.Count == 0)
				throw new IndexOutOfRangeException("No codes.");

			List<ArchiveCode> c = context.ArchiveCodes.Where(c => codes.Contains(c.Code)).ToList();
			if (c == null)
				//throw new ArgumentNullException("No code with those codes in db.");
				return;
			context.ArchiveCodes.RemoveRange(c);
			context.SaveChanges();
		}

		public void UpdateArchiveCodeByID(int id, ArchiveCode code)
		{
			if (id == 0)
				throw new IndexOutOfRangeException("Invalid id.");
			if (code == null)
				throw new IndexOutOfRangeException("No codes.");

			ArchiveCode oldCode = context.ArchiveCodes.Where(c => c.ID_ArchiveCode == id).FirstOrDefault();
			if (oldCode == null)
				//throw new ArgumentNullException("No code with that id in db.");
				return;
			oldCode.Code = code.Code;
			oldCode.Name = code.Name;
			context.ArchiveCodes.Remove(oldCode);
			context.SaveChanges();
		}

		public void UpdateArchiveCodeByCode(string c, ArchiveCode code)
		{
			if (c == null)
				throw new IndexOutOfRangeException("Invalid code.");

			if (code == null)
				throw new IndexOutOfRangeException("No codes.");

			ArchiveCode oldCode = context.ArchiveCodes.Where(ac => ac.Code == c).FirstOrDefault();
			if (oldCode == null)
				//throw new ArgumentNullException("No code with that code in db.");
				return;
			oldCode.Code = code.Code;
			oldCode.Name = code.Name;
			context.ArchiveCodes.Remove(oldCode);
			context.SaveChanges();
		}

		ArchiveBookContext context;
	}
}
