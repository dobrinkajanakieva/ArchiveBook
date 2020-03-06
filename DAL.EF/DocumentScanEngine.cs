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
		public DocumentScanEngine()
		{
			this.context = new ArchiveBookContext();
		}

		public List<DocumentScan> GetDocuments()
		{
			List<DocumentScan> documents = context.DocumentScans.ToList();
			//if (documents == null)
			//	throw new ArgumentNullException("No documents");
			//	return;
			return documents;
		}

		public DocumentScan GetDocumentByID(int id)
		{
			if (id == 0)
				throw new ArgumentNullException("Invalid id.");

			return context.DocumentScans.Where(d => d.ID_DocumentScan == id).FirstOrDefault();
		}

		public List<DocumentScan> GetDocumentsByArchiveBooking(int id)
		{
			if (id == 0)
				throw new ArgumentNullException("Invalid id.");

			return context.DocumentScans.Where(d => d.ID_ArchiveBooking == id).ToList();
		}

		public void InsertDocument(DocumentScan document)
		{
			if (document == null)
				throw new ArgumentNullException("Empty document.");

			document.ID_DocumentScan = null;

			context.DocumentScans.Add(document);
			context.SaveChanges();
		}

		public void InsertDocuments(List<DocumentScan> documents)
		{
			if (documents.Count == 0)
				throw new ArgumentNullException("No documents.");

			foreach (DocumentScan document in documents)
				document.ID_DocumentScan = null;

			context.DocumentScans.AddRange(documents);
			context.SaveChanges();
		}

		public void DeleteDocumentById(int id)
		{
			if (id == 0)
				throw new ArgumentNullException("Invalid id.");

			DocumentScan docScan = context.DocumentScans.Where(d => d.ID_DocumentScan == id).FirstOrDefault();
			if (docScan == null)
				//throw new ArgumentNullException("No document with that id in db.");
				return;
			context.DocumentScans.Remove(docScan);
			context.SaveChanges();
		}

		public void DeleteDocumentByArchiveBooking(int id)
		{
			if (id == 0)
				throw new ArgumentNullException("Invalid id.");

			DocumentScan docScan = context.DocumentScans.Where(d => d.ID_ArchiveBooking == id).FirstOrDefault();
			if(docScan == null)
				//throw new ArgumentNullException("No document from that archive booking in db.");
				return;
			context.DocumentScans.Remove(docScan);
			context.SaveChanges();
		}

		public void UpdateDocumentScanByID(int id, DocumentScan document)
		{
			if (id == 0)
				throw new ArgumentNullException("Invalid id.");

			if (document == null)
				throw new ArgumentNullException("Empty document.");

			DocumentScan docScan = context.DocumentScans.Where(d => d.ID_DocumentScan == id).FirstOrDefault();
			if (docScan == null)
				//throw new NullReferenceException("No document with that id in the db.");
				return;
			docScan.ID_ArchiveBooking = document.ID_ArchiveBooking;
			docScan.DocumentPath = document.DocumentPath;
			context.DocumentScans.Update(docScan);
			context.SaveChanges();
		}

		ArchiveBookContext context;
	}
}
