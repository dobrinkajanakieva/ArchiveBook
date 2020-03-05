using DAL.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL.EF
{
	public class DocumentScanEngine : IDocumentScanEngine
	{
		public DocumentScanEngine(ArchiveBookContext context)
		{
			this.context = context;
		}

		public List<DocumentScan> GetDocuments()
		{
			return context.DocumentScans.ToList();
		}

		public DocumentScan GetDocumentByID(int id)
		{
			return context.DocumentScans.Where(d => d.ID_DocumentScan == id).FirstOrDefault();
		}

		public List<DocumentScan> GetDocumentsByArchiveBooking(int id)
		{
			return context.DocumentScans.Where(d => d.ID_ArchiveBooking == id).ToList();
		}

		public void InsertDocument(DocumentScan document)
		{
			context.DocumentScans.Add(document);
			context.SaveChanges();
		}

		public void InsertDocuments(List<DocumentScan> documents)
		{
			context.DocumentScans.AddRange(documents);
			context.SaveChanges();
		}

		public void DeleteDocumentById(int id)
		{
			DocumentScan docScan = context.DocumentScans.Where(d => d.ID_DocumentScan == id).FirstOrDefault();
			context.DocumentScans.Remove(docScan);
			context.SaveChanges();
		}

		public void DeleteDocumentByArchiveBooking(int id)
		{
			DocumentScan docScan = context.DocumentScans.Where(d => d.ID_ArchiveBooking == id).FirstOrDefault();
			context.DocumentScans.Remove(docScan);
			context.SaveChanges();
		}

		public void UpdateDocumentScanByID(int id, DocumentScan document)
		{
			DocumentScan docScan = context.DocumentScans.Where(d => d.ID_DocumentScan == id).FirstOrDefault();
			docScan.ID_ArchiveBooking = document.ID_ArchiveBooking;
			docScan.DocumentPath = document.DocumentPath;
			context.DocumentScans.Update(docScan);
			context.SaveChanges();
		}

		ArchiveBookContext context;
	}
}
