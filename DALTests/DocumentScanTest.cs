using DAL_SQLServer;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DALTests
{
	public class DocumentScanTest
	{
        [Fact]
        public void GetDocumentByID()
        {
            //Arrange
            var documentScanEngine = new DocumentScanEngine();

            //Act
            DocumentScan document = documentScanEngine.GetDocumentByID(17);

            //Assert
            Assert.Equal(70, document.ID_ArchiveBooking);
            Assert.Equal("novo", document.DocumentPath);
        }

        [Fact]
        public void GetDocumentsByArchiveBooking()
        {
            //Arrange
            var documentScanEngine = new DocumentScanEngine();

            //Act
            List<DocumentScan> documents = documentScanEngine.GetDocumentsByArchiveBooking(69);
            
            //Assert
            foreach (DocumentScan document in documents)
            {
                Assert.Equal(69, document.ID_ArchiveBooking);
            }
        }

        [Fact]
        public void InsertDocument()
        {
            //Arrange
            var documentScanEngine = new DocumentScanEngine();
            const int ID_ArchiveBooking = 70;
            const string DocumentPath = "novo";

            //Act
            DocumentScan document = new DocumentScan(100, ID_ArchiveBooking, DocumentPath);
            documentScanEngine.InsertDocument(document);
            List<DocumentScan> documents = documentScanEngine.GetDocumentsByArchiveBooking(70);

            //Assert
            foreach(DocumentScan doc in documents)
                Assert.Equal(DocumentPath, doc.DocumentPath);
        }

        [Fact]
        public void UpdateDocumentByID()
        {
            //Arrange
            var documentScanEngine = new DocumentScanEngine();
            const int ID_ArchiveBooking = 70;
            const string DocumentPath = "updated";

            //Act
            DocumentScan document = new DocumentScan(100, ID_ArchiveBooking, DocumentPath);
            documentScanEngine.UpdateDocumentScanByID(24, document);
            document = documentScanEngine.GetDocumentByID(24);

            //Assert
            Assert.Equal(DocumentPath, document.DocumentPath);
        }

        [Fact]
        public void DeleteDocumentById()
        {
            //Arrange
            var documentScanEngine = new DocumentScanEngine();

            //Act
            documentScanEngine.DeleteDocumentById(12);
            DocumentScan document = documentScanEngine.GetDocumentByID(12);

            //Assert
            Assert.Null(document.DocumentPath);
        }

        [Fact]
        public void DeleteDocumentByArchiveBooking()
        {
            //Arrange
            var documentScanEngine = new DocumentScanEngine();

            //Act
            documentScanEngine.DeleteDocumentByArchiveBooking(69);
            DocumentScan document = documentScanEngine.GetDocumentByID(11);

            //Assert
            Assert.Null(document.DocumentPath);
        }

        [Fact]
        public void InsertDocuments()
        {
            //Arrange
            var documentScanEngine = new DocumentScanEngine();
            const int ID_ArchiveBooking1 = 72;
            const string DocumentPath1 = "novo"; 
            const int ID_ArchiveBooking2 = 70;
            const string DocumentPath2 = "novo"; 
            const int ID_ArchiveBooking3 = 72;
            const string DocumentPath3 = "novo";
            List<DocumentScan> documents = new List<DocumentScan>();
            List<DocumentScan> result = new List<DocumentScan>();

            //Act
            DocumentScan document1 = new DocumentScan(100, ID_ArchiveBooking1, DocumentPath1);
            DocumentScan document2 = new DocumentScan(101, ID_ArchiveBooking2, DocumentPath2);
            DocumentScan document3 = new DocumentScan(102, ID_ArchiveBooking3, DocumentPath3);

            documents.Add(document1);
            documents.Add(document2);
            documents.Add(document3);

            documentScanEngine.InsertDocuments(documents);

            result = documentScanEngine.GetDocumentsByArchiveBooking(70);

            //Assert
            foreach (DocumentScan document in result)
            {
                Assert.Equal("novo", document.DocumentPath);
            }
        }
    }
}
