using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_Interfaces
{
	public interface IArchiveCodeEngine
	{
		List<ArchiveCode> GetArchiveCodes();
		List<ArchiveCode> GetArchiveCodesByCodes(List<string> codes);
		ArchiveCode GetArchiveCodeByID(int id);
		ArchiveCode GetArchiveCodeByCode(string code);
		void InsertArchiveCode(ArchiveCode code);
		void InsertArchiveCodes(List<ArchiveCode> codes);
		void DeleteArchiveCodeById(int id);
		void DeleteArchiveCodeByCode(string code);
		void DeleteArchiveCodesByCodes(List<string> codes);
		void UpdateArchiveCodeByID(int id, ArchiveCode code);
		void UpdateArchiveCodeByCode(string c, ArchiveCode code);

	}
}
