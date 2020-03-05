using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
	public interface IDocumentScanEngine
	{
		List<DocumentScan> GetDocuments();
		DocumentScan GetDocumentByID(int id);
		List<DocumentScan> GetDocumentsByArchiveBooking(int id);
		void InsertDocument(DocumentScan document);
		void InsertDocuments(List<DocumentScan> documents);
		void DeleteDocumentById(int id);
		void DeleteDocumentByArchiveBooking(int id);
		void UpdateDocumentScanByID(int id, DocumentScan document);

	}
}
