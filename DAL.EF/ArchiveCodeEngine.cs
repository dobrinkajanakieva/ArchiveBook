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
		public ArchiveCodeEngine(ArchiveBookContext context)
		{
			this.context = context;
		}

		public List<ArchiveCode> GetArchiveCodes()
		{
			return context.ArchiveCodes.ToList();
		}

		public List<ArchiveCode> GetArchiveCodesByCodes(List<string> codes)
		{
			return context.ArchiveCodes.Where(c => codes.Contains(c.Code)).ToList();
		}

		public ArchiveCode GetArchiveCodeByID(int id)
		{
			return context.ArchiveCodes.Where(c => c.ID_ArchiveCode == id).FirstOrDefault();
		}

		public ArchiveCode GetArchiveCodeByCode(string code)
		{
			return context.ArchiveCodes.Where(c => c.Code == code).FirstOrDefault();
		}

		public void InsertArchiveCode(ArchiveCode code)
		{
			context.Add(code);
			context.SaveChanges();
		}

		public void InsertArchiveCodes(List<ArchiveCode> codes)
		{
			context.AddRange(codes);
			context.SaveChanges();
		}

		public void DeleteArchiveCodeById(int id)
		{
			ArchiveCode code = context.ArchiveCodes.Where(c => c.ID_ArchiveCode == id).FirstOrDefault();
			context.ArchiveCodes.Remove(code);
			context.SaveChanges();
		}

		public void DeleteArchiveCodeByCode(string code)
		{
			ArchiveCode c = context.ArchiveCodes.Where(c => c.Code == code).FirstOrDefault();
			context.ArchiveCodes.Remove(c);
			context.SaveChanges();
		}

		public void DeleteArchiveCodesByCodes(List<string> codes)
		{
			List<ArchiveCode> c = context.ArchiveCodes.Where(c => codes.Contains(c.Code)).ToList();
			context.ArchiveCodes.RemoveRange(c);
			context.SaveChanges();
		}

		public void UpdateArchiveCodeByID(int id, ArchiveCode code)
		{
			ArchiveCode oldCode = context.ArchiveCodes.Where(c => c.ID_ArchiveCode == id).FirstOrDefault();
			oldCode.Code = code.Code;
			oldCode.Name = code.Name;
			context.ArchiveCodes.Remove(oldCode);
			context.SaveChanges();
		}

		public void UpdateArchiveCodeByCode(string c, ArchiveCode code)
		{
			ArchiveCode oldCode = context.ArchiveCodes.Where(ac => ac.Code == c).FirstOrDefault();
			oldCode.Code = code.Code;
			oldCode.Name = code.Name;
			context.ArchiveCodes.Remove(oldCode);
			context.SaveChanges();
		}

		ArchiveBookContext context;
	}
}
