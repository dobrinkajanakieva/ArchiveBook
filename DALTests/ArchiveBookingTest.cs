using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DALTests
{
	public class ArchiveBookingTest
	{
        [Fact]
        public void Test1() 
        {
            //Arrange
            var archiveBookingService = new ArchiveBookingService();
            const int ID_ArchiveCode = 22;
            const string DocumentNumber = "01";
            DateTime Date = new DateTime(2020, 03, 03);
            const int Year = 20;
            const string Subject = "gfgvfd";
            const int ID_Sender = 2;
            const string EntryCode = "02-03/20";

            //Act
            ArchiveBooking booking = archiveBookingService.GetArchiveBookingByID(30);
            bool isValid = true;
            if (ID_ArchiveCode != booking.ID_ArchiveCode || DocumentNumber != booking.DocumentNumber || Date.Date != booking.Date ||
                Year != booking.Year || Subject != booking.Subject || ID_Sender != booking.ID_Sender || EntryCode != booking.EntryCode)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Archive Booking with ID=30 is not valid");
        }

        [Fact]
        public void Test2() 
        {
            //Arrange
            var archiveBookingService = new ArchiveBookingService();
            const int ID_ArchiveCode = 22;
            const string DocumentNumber = "01";
            DateTime Date = new DateTime(2020, 03, 03);
            const int Year = 20;
            const string Subject = "gfgvfd";
            const int ID_Sender = 2;
            const string EntryCode = "02-03/20";

            //Act
            ArchiveBooking booking = archiveBookingService.GetArchiveBookingByDocumentNumber(DocumentNumber);
            bool isValid = true;
            if (ID_ArchiveCode != booking.ID_ArchiveCode || DocumentNumber != booking.DocumentNumber || Date.Date != booking.Date ||
                Year != booking.Year || Subject != booking.Subject || ID_Sender != booking.ID_Sender || EntryCode != booking.EntryCode)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Archive Booking with Document Number=01 is not valid");
        }

        [Fact]
        public void Test3()
        {
            //Arrange
            var archiveBookingService = new ArchiveBookingService();
            List<ArchiveBooking> bookings = new List<ArchiveBooking>();
            const int ID_ArchiveCode = 22;
            const string DocumentNumber = "01";
            DateTime Date = new DateTime(2020, 03, 03);
            const int Year = 20;
            const string Subject = "ghjkfl";
            const int ID_Sender = 1;
            const string EntryCode = "04-01/20";

            //Act
            ArchiveBooking booking = new ArchiveBooking();
            booking.ID_ArchiveCode = ID_ArchiveCode;
            booking.DocumentNumber = DocumentNumber;
            booking.Date = Date.Date;
            booking.Year = Year;
            booking.Subject = Subject;
            booking.ID_Sender = ID_Sender;
            booking.EntryCode = EntryCode;
            bookings.Add(booking);
            List<ArchiveBooking> result = archiveBookingService.GetArchiveBookingsByYear(Year);
            bool isValid = true;
            foreach(ArchiveBooking b in result)
            {
                if (b.Year != Year)
                    isValid = false;
            }

            //Assert
            Assert.True(isValid, "The Archive Booking with Year=20 is not valid");
        }

        [Fact]
        public void Test4()
        {
            //Arrange
            var archiveBookingService = new ArchiveBookingService();
            List<ArchiveBooking> bookings = new List<ArchiveBooking>();
            const int ID_ArchiveCode = 22;
            const string DocumentNumber = "01";
            DateTime Date = new DateTime(2020, 03, 03);
            const int Year = 20;
            const string Subject = "ghjkfl";
            const int ID_Sender = 1;
            const string EntryCode = "04-01/20";

            //Act
            ArchiveBooking booking = new ArchiveBooking();
            booking.ID_ArchiveCode = ID_ArchiveCode;
            booking.DocumentNumber = DocumentNumber;
            booking.Date = Date;
            booking.Year = Year;
            booking.Subject = Subject;
            booking.ID_Sender = ID_Sender;
            booking.EntryCode = EntryCode;
            bookings.Add(booking);
            List<ArchiveBooking> result = archiveBookingService.GetArchiveBookingsBySubject(Subject);
            bool isValid = true;
            foreach (ArchiveBooking b in result)
            {
                if (b.Subject != Subject)
                    isValid = false;
            }

            //Assert
            Assert.True(isValid, "The Archive Booking with Subject=ghjkfl is not valid");
        }

        [Fact]
        public void Test5()
        {
            //Arrange
            var archiveBookingService = new ArchiveBookingService();
            List<ArchiveBooking> bookings = new List<ArchiveBooking>();
            const string ArchiveCode = "04";
            const int ID_ArchiveCode = 22;
            const string DocumentNumber = "01";
            DateTime Date = new DateTime(2020, 03, 03);
            const int Year = 20;
            const string Subject = "ghjkfl";
            const int ID_Sender = 1;
            const string EntryCode = "04-01/20";

            //Act
            ArchiveBooking booking = new ArchiveBooking();
            booking.ID_ArchiveCode = ID_ArchiveCode;
            booking.DocumentNumber = DocumentNumber;
            booking.Date = Date;
            booking.Year = Year;
            booking.Subject = Subject;
            booking.ID_Sender = ID_Sender;
            booking.EntryCode = EntryCode;
            bookings.Add(booking);
            List<ArchiveBooking> result = archiveBookingService.GetArchiveBookingsByArchiveCode(ArchiveCode);
            bool isValid = true;
            foreach (ArchiveBooking b in result)
            {
                if (b.ID_ArchiveCode != 22)
                    isValid = false;
            }

            //Assert
            Assert.True(isValid, "The Archive Booking with Archive Code=04 is not valid");
        }

        [Fact]
        public void Test6()
        {
            //Arrange
            var archiveBookingService = new ArchiveBookingService();
            List<ArchiveBooking> bookings = new List<ArchiveBooking>();
            const string Sender = "gtdhtd";
            const int ID_ArchiveCode = 22;
            const string DocumentNumber = "01";
            DateTime Date = new DateTime(2020, 03, 03);
            const int Year = 20;
            const string Subject = "ghjkfl";
            const int ID_Sender = 1;
            const string EntryCode = "04-01/20";

            //Act
            ArchiveBooking booking = new ArchiveBooking();
            booking.ID_ArchiveCode = ID_ArchiveCode;
            booking.DocumentNumber = DocumentNumber;
            booking.Date = Date;
            booking.Year = Year;
            booking.Subject = Subject;
            booking.ID_Sender = ID_Sender;
            booking.EntryCode = EntryCode;
            bookings.Add(booking);
            List<ArchiveBooking> result = archiveBookingService.GetArchiveBookingsBySender(Sender);
            bool isValid = true;
            foreach (ArchiveBooking b in result)
            {
                if (b.ID_Sender != 3)
                    isValid = false;
            }

            //Assert
            Assert.True(isValid, "The Archive Booking with Sender=gfresf is not valid");
        }

        [Fact]
        public void Test7() 
        {
            //Arrange
            var archiveBookingService = new ArchiveBookingService();
            const int ID = 100;
            const int ID_ArchiveCode = 22;
            const string DocumentNumber = "02";
            DateTime Date = new DateTime(2020, 03, 03);
            const int Year = 20;
            const string Subject = "ghjkfl";
            const int ID_Sender = 2;
            const string EntryCode = "04-02/20";

            //Act
            ArchiveBooking booking = new ArchiveBooking(ID, ID_ArchiveCode, DocumentNumber, Date.Date, Year, Subject, ID_Sender, EntryCode);
            archiveBookingService.InsertArchiveBooking(booking);
            booking = null;
            booking = archiveBookingService.GetArchiveBookingByDocumentNumber(DocumentNumber);
            bool isValid = true;
            if (booking.DocumentNumber != DocumentNumber)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Archive Booking with Document Number=02 is not valid");
        }

        [Fact]
        public void Test8()
        {
            //Arrange
            var archiveBookingService = new ArchiveBookingService();
            List<ArchiveBooking> bookings = new List<ArchiveBooking>();
            List<ArchiveBooking> result = new List<ArchiveBooking>();
            const int ID1 = 100;
            const int ID_ArchiveCode1 = 22;
            const string DocumentNumber1 = "02";
            DateTime Date1 = new DateTime(2020, 03, 03);
            const int Year1 = 20;
            const string Subject1 = "ghjkfl";
            const int ID_Sender1 = 2;
            const string EntryCode1 = "04-02/20";
            const int ID2 = 100;
            const int ID_ArchiveCode2 = 22;
            const string DocumentNumber2 = "02";
            DateTime Date2 = new DateTime(2020, 03, 03);
            const int Year2 = 20;
            const string Subject2 = "ghjkfl";
            const int ID_Sender2 = 2;
            const string EntryCode2 = "04-02/20";
            const int ID3 = 100;
            const int ID_ArchiveCode3 = 22;
            const string DocumentNumber3 = "02";
            DateTime Date3 = new DateTime(2020, 03, 03);
            const int Year3 = 20;
            const string Subject3 = "ghjkfl";
            const int ID_Sender3 = 2;
            const string EntryCode3 = "04-02/20";

            //Act
            ArchiveBooking booking1 = new ArchiveBooking(ID1, ID_ArchiveCode1, DocumentNumber1, Date1.Date, Year1, Subject1, ID_Sender1, EntryCode1);
            ArchiveBooking booking2 = new ArchiveBooking(ID2, ID_ArchiveCode2, DocumentNumber2, Date2.Date, Year2, Subject2, ID_Sender2, EntryCode2);
            ArchiveBooking booking3 = new ArchiveBooking(ID3, ID_ArchiveCode3, DocumentNumber3, Date3.Date, Year3, Subject3, ID_Sender3, EntryCode3);
            bookings.Add(booking1);
            bookings.Add(booking2);
            bookings.Add(booking3);
            archiveBookingService.InsertArchiveBookings(bookings);
            result.Add(archiveBookingService.GetArchiveBookingByDocumentNumber(DocumentNumber1));
            result.Add(archiveBookingService.GetArchiveBookingByDocumentNumber(DocumentNumber2));
            result.Add(archiveBookingService.GetArchiveBookingByDocumentNumber(DocumentNumber3));
            bool isValid = true;
            foreach(ArchiveBooking booking in result)
            {
                if (booking.DocumentNumber!=DocumentNumber1)
                    isValid = false;
            }

            //Assert
            Assert.True(isValid, "Not valid");
        }

        [Fact]
        public void Test9() 
        {
            //Arrange
            var archiveBookingService = new ArchiveBookingService();
            const int ID = 100;
            const int ID_ArchiveCode = 22;
            const string DocumentNumber = "02";
            DateTime Date = new DateTime(2020, 03, 03);
            const int Year = 20;
            const string Subject = "ghjkfl";
            const int ID_Sender = 2;
            const string EntryCode = "04-02/20";

            //Act
            ArchiveBooking booking = new ArchiveBooking(ID, ID_ArchiveCode, DocumentNumber, Date.Date, Year, Subject, ID_Sender, EntryCode);
            archiveBookingService.UpdateArchiveBookingByID(1, booking);
            booking = null;
            booking = archiveBookingService.GetArchiveBookingByID(1);
            bool isValid = true;
            if (DocumentNumber != booking.DocumentNumber)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Archive Booking with ID=1 is not valid");
        }

        [Fact]
        public void Test10()
        {
            //Arrange
            var archiveBookingService = new ArchiveBookingService();
            const int ID = 100;
            const int ID_ArchiveCode = 22;
            const string DocumentNumber = "03";
            DateTime Date = new DateTime(2020, 03, 03);
            const int Year = 20;
            const string Subject = "ghjkfl";
            const int ID_Sender = 2;
            const string EntryCode = "04-02/20";

            //Act
            ArchiveBooking booking = new ArchiveBooking(ID, ID_ArchiveCode, DocumentNumber, Date.Date, Year, Subject, ID_Sender, EntryCode);
            archiveBookingService.InsertArchiveBooking(booking);
            archiveBookingService.DeleteArchiveBookingsByArchiveCodeID(ID_ArchiveCode);
            booking = null;
            booking = archiveBookingService.GetArchiveBookingByDocumentNumber(DocumentNumber);
            bool isValid = true;
            if (booking.DocumentNumber != null)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Archive booking with Archive Code ID=22 is not valid");
        }

        [Fact]
        public void Test11()
        {
            //Arrange
            var archiveBookingService = new ArchiveBookingService();

            //Act
            archiveBookingService.DeleteArchiveBookingById(1);
            ArchiveBooking booking = null;
            booking = archiveBookingService.GetArchiveBookingByID(1);
            bool isValid = true;
            if (booking.DocumentNumber != null)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Archive booking with ID=1 is not valid");
        }

        [Fact]
        public void Test12()
        {
            //Arrange
            var archiveBookingService = new ArchiveBookingService();
            const int ID = 100;
            const int ID_ArchiveCode = 22;
            const string DocumentNumber = "03";
            DateTime Date = new DateTime(2020, 03, 03);
            const int Year = 20;
            const string Subject = "ghjkfl";
            const int ID_Sender = 2;
            const string EntryCode = "04-02/20";

            //Act
            ArchiveBooking booking = new ArchiveBooking(ID, ID_ArchiveCode, DocumentNumber, Date.Date, Year, Subject, ID_Sender, EntryCode);
            archiveBookingService.InsertArchiveBooking(booking);
            archiveBookingService.DeleteArchiveBookingsBySenderID(ID_Sender);
            booking = null;
            booking = archiveBookingService.GetArchiveBookingByDocumentNumber(DocumentNumber);
            bool isValid = true;
            if (booking.DocumentNumber != null)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Archive booking with Sender ID=2 is not valid");
        }

        [Fact]
        public void Test13()
        {
            //Arrange
            var archiveBookingService = new ArchiveBookingService();
            const int ID = 100;
            const int ID_ArchiveCode = 22;
            const string DocumentNumber = "03";
            DateTime Date = new DateTime(2020, 03, 03);
            const int Year = 20;
            const string Subject = "ghjkfl";
            const int ID_Sender = 2;
            const string EntryCode = "04-02/20";

            //Act
            ArchiveBooking booking = new ArchiveBooking(ID, ID_ArchiveCode, DocumentNumber, Date.Date, Year, Subject, ID_Sender, EntryCode);
            archiveBookingService.InsertArchiveBooking(booking);
            archiveBookingService.DeleteArchiveBookingsByYear(Year);
            booking = null;
            booking = archiveBookingService.GetArchiveBookingByDocumentNumber(DocumentNumber);
            bool isValid = true;
            if (booking.DocumentNumber != null)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Archive booking with Year=20 is not valid");
        }

        [Fact]
        public void Test14()
        {
            //Arrange
            var archiveBookingService = new ArchiveBookingService();
            const int ID = 100;
            const int ID_ArchiveCode = 22;
            const string DocumentNumber = "03";
            DateTime Date = new DateTime(2020, 03, 03);
            const int Year = 20;
            const string Subject = "ghjkfl";
            const int ID_Sender = 2;
            const string EntryCode = "04-02/20";

            //Act
            ArchiveBooking booking = new ArchiveBooking(ID, ID_ArchiveCode, DocumentNumber, Date.Date, Year, Subject, ID_Sender, EntryCode);
            archiveBookingService.InsertArchiveBooking(booking);
            archiveBookingService.DeleteArchiveBookingsByDocumentNumber(DocumentNumber);
            booking = null;
            booking = archiveBookingService.GetArchiveBookingByDocumentNumber(DocumentNumber);
            bool isValid = true;
            if (booking.DocumentNumber != null)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Archive booking with Year=20 is not valid");
        }

        [Fact]
        public void Test15()
        {
            //Arrange
            var archiveBookingService = new ArchiveBookingService();
            const int ID = 100;
            const int ID_ArchiveCode = 22;
            const string DocumentNumber = "03";
            DateTime Date = new DateTime(2020, 03, 03);
            const int Year = 20;
            const string Subject = "ghjkfl";
            const int ID_Sender = 2;
            const string EntryCode = "04-02/20";

            //Act
            ArchiveBooking booking = new ArchiveBooking(ID, ID_ArchiveCode, DocumentNumber, Date.Date, Year, Subject, ID_Sender, EntryCode);
            archiveBookingService.InsertArchiveBooking(booking);
            archiveBookingService.DeleteArchiveBookingsByDate(Date);
            booking = null;
            booking = archiveBookingService.GetArchiveBookingByDocumentNumber(DocumentNumber);
            bool isValid = true;
            if (booking.DocumentNumber != null)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Archive booking with Date=2020-03-03 is not valid");
        }

        [Fact]
        public void Test16()
        {
            //Arrange
            var archiveBookingService = new ArchiveBookingService();
            const int ID = 100;
            const int ID_ArchiveCode = 22;
            const string DocumentNumber = "03";
            DateTime Date = new DateTime(2020, 03, 03);
            const int Year = 20;
            const string Subject = "ghjkfl";
            const int ID_Sender = 2;
            const string EntryCode = "04-02/20";

            //Act
            ArchiveBooking booking = new ArchiveBooking(ID, ID_ArchiveCode, DocumentNumber, Date.Date, Year, Subject, ID_Sender, EntryCode);
            archiveBookingService.InsertArchiveBooking(booking);
            archiveBookingService.DeleteArchiveBookingsBySubject(Subject);
            booking = null;
            booking = archiveBookingService.GetArchiveBookingByDocumentNumber(DocumentNumber);
            bool isValid = true;
            if (booking.DocumentNumber != null)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Archive booking with Year=20 is not valid");
        }

        [Fact]
        public void Test17()
        {
            //Arrange
            var archiveBookingService = new ArchiveBookingService();
            const int ID = 100;
            const int ID_ArchiveCode = 22;
            const string DocumentNumber = "03";
            DateTime Date = new DateTime(2020, 03, 03);
            const int Year = 20;
            const string Subject = "ghjkfl";
            const int ID_Sender = 2;
            const string EntryCode = "04-02/20";

            //Act
            ArchiveBooking booking = new ArchiveBooking(ID, ID_ArchiveCode, DocumentNumber, Date.Date, Year, Subject, ID_Sender, EntryCode);
            archiveBookingService.InsertArchiveBooking(booking);
            archiveBookingService.DeleteArchiveBookingsByEntryCode(EntryCode);
            booking = null;
            booking = archiveBookingService.GetArchiveBookingByEntryCode(EntryCode);
            bool isValid = true;
            if (booking.DocumentNumber != null)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Archive booking with EntryCode=04-02/20 is not valid");
        }
    }
}
