using DAL;
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
        public void Test1()
        {
            //Arrange
            var documentScanService = new DocumentScanService();
            const int ID_ArchiveBooking = 30;
            const string DocumentPath = "htrgtd";

            //Act
            DocumentScan document = documentScanService.GetDocumentByID(2);
            bool isValid = true;
            if (ID_ArchiveBooking != document.ID_ArchiveBooking || DocumentPath != document.DocumentPath)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Document with ID=2 is not valid");
        }

        [Fact]
        public void Test2()
        {
            //Arrange
            var documentScanService = new DocumentScanService();

            //Act
            List<DocumentScan> documents = documentScanService.GetDocumentsByArchiveBooking(30);
            bool isValid = true;
            foreach (DocumentScan document in documents)
            {
                if (30 != document.ID_ArchiveBooking)
                    isValid = false;
            }

            //Assert
            Assert.True(isValid, "The Document with Archive Booking ID=30 is not valid");
        }

        [Fact]
        public void Test3()
        {
            //Arrange
            var documentScanService = new DocumentScanService();
            const int ID_ArchiveBooking = 30;
            const string DocumentPath = "novo";

            //Act
            DocumentScan document = new DocumentScan(100, ID_ArchiveBooking, DocumentPath);
            documentScanService.InsertDocument(document);
            document = documentScanService.GetDocumentByID(4);
            bool isValid = true;
            if (DocumentPath != document.DocumentPath)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Document with ID=4 is not valid");
        }

        [Fact]
        public void Test4()
        {
            //Arrange
            var documentScanService = new DocumentScanService();
            const int ID_ArchiveBooking = 30;
            const string DocumentPath = "novo";

            //Act
            DocumentScan document = new DocumentScan(100, ID_ArchiveBooking, DocumentPath);
            documentScanService.UpdateDocumentScanByID(3, document);
            document = documentScanService.GetDocumentByID(3);
            bool isValid = true;
            if (DocumentPath != document.DocumentPath)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Document with Path=novo is not valid");
        }

        [Fact]
        public void Test5()
        {
            //Arrange
            var documentScanService = new DocumentScanService();

            //Act
            documentScanService.DeleteDocumentById(3);
            DocumentScan document = documentScanService.GetDocumentByID(3);
            bool isValid = true;
            if (document.DocumentPath != null)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Sender with Name=test9 is not valid");
        }

        [Fact]
        public void Test6()
        {
            //Arrange
            var documentScanService = new DocumentScanService();
            const int ID_ArchiveBooking1 = 30;
            const string DocumentPath1 = "novo"; 
            const int ID_ArchiveBooking2 = 30;
            const string DocumentPath2 = "novo"; 
            const int ID_ArchiveBooking3 = 30;
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

            documentScanService.InsertDocuments(documents);

            result = documentScanService.GetDocumentsByArchiveBooking(30);

            bool isValid = true;
            foreach (DocumentScan document in result)
            {
                if (document.DocumentPath != DocumentPath3)
                    isValid = false;
            }

            documentScanService.DeleteDocumentByArchiveBooking(30);

            //Assert
            Assert.True(isValid, "Not valid");
        }
    }
}
