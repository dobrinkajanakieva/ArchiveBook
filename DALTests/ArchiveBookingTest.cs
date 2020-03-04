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
        public void GetBookingByID() 
        {
            //Arrange
            var archiveBookingEngine = new ArchiveBookingEngine();

            //Act
            ArchiveBooking booking = archiveBookingEngine.GetArchiveBookingByID(53);

            //Assert
            Assert.Equal(53, booking.ID_ArchiveBooking);
            Assert.Equal(24, booking.ID_ArchiveCode);
            Assert.Equal("03", booking.DocumentNumber);
            Assert.Equal(new DateTime(2020,03,04), booking.Date);
            Assert.Equal(20, booking.Year);
            Assert.Equal("grgrg", booking.Subject);
            Assert.Equal(1, booking.ID_Sender);
            Assert.Equal("04-03/20", booking.EntryCode);
        }

        [Fact]
        public void GetBookingByDocumentNumber() 
        {
            //Arrange
            var archiveBookingEngine = new ArchiveBookingEngine();

            //Act
            ArchiveBooking booking = archiveBookingEngine.GetArchiveBookingByDocumentNumber("03");

            //Assert
            Assert.Equal(53, booking.ID_ArchiveBooking);
            Assert.Equal(24, booking.ID_ArchiveCode);
            Assert.Equal("03", booking.DocumentNumber);
            Assert.Equal(new DateTime(2020, 03, 04), booking.Date);
            Assert.Equal(20, booking.Year);
            Assert.Equal("grgrg", booking.Subject);
            Assert.Equal(1, booking.ID_Sender);
            Assert.Equal("04-03/20", booking.EntryCode);
        }

        [Fact]
        public void GetBookingByEntryCode()
        {
            //Arrange
            var archiveBookingEngine = new ArchiveBookingEngine();

            //Act
            ArchiveBooking booking = archiveBookingEngine.GetArchiveBookingByEntryCode("04-03/20");

            //Assert
            Assert.Equal(53, booking.ID_ArchiveBooking);
            Assert.Equal(24, booking.ID_ArchiveCode);
            Assert.Equal("03", booking.DocumentNumber);
            Assert.Equal(new DateTime(2020, 03, 04), booking.Date);
            Assert.Equal(20, booking.Year);
            Assert.Equal("grgrg", booking.Subject);
            Assert.Equal(1, booking.ID_Sender);
            Assert.Equal("04-03/20", booking.EntryCode);
        }

        [Fact]
        public void GetBookingsByYear()
        {
            //Arrange
            var archiveBookingEngine = new ArchiveBookingEngine();

            //Act
            List<ArchiveBooking> result = archiveBookingEngine.GetArchiveBookingsByYear(20);

            //Assert
            foreach (ArchiveBooking booking in result)
            {
                Assert.Equal(53, booking.ID_ArchiveBooking);
                Assert.Equal(24, booking.ID_ArchiveCode);
                Assert.Equal("03", booking.DocumentNumber);
                Assert.Equal(new DateTime(2020, 03, 04), booking.Date);
                Assert.Equal(20, booking.Year);
                Assert.Equal("grgrg", booking.Subject);
                Assert.Equal(1, booking.ID_Sender);
                Assert.Equal("04-03/20", booking.EntryCode);
            }
        }

        [Fact]
        public void GetBookingsBySubject()
        {
            //Arrange
            var archiveBookingEngine = new ArchiveBookingEngine();

            //Act

            List<ArchiveBooking> result = archiveBookingEngine.GetArchiveBookingsBySubject("grgrg");

            //Assert
            foreach (ArchiveBooking booking in result)
            {
                Assert.Equal(53, booking.ID_ArchiveBooking);
                Assert.Equal(24, booking.ID_ArchiveCode);
                Assert.Equal("03", booking.DocumentNumber);
                Assert.Equal(new DateTime(2020, 03, 04), booking.Date);
                Assert.Equal(20, booking.Year);
                Assert.Equal("grgrg", booking.Subject);
                Assert.Equal(1, booking.ID_Sender);
                Assert.Equal("04-03/20", booking.EntryCode);
            }
        }

        [Fact]
        public void GetBookingsByArchiveCode()
        {
            //Arrange
            var archiveBookingEngine = new ArchiveBookingEngine();

            //Act
            List<ArchiveBooking> result = archiveBookingEngine.GetArchiveBookingsByArchiveCode("0402");


            //Assert
            foreach (ArchiveBooking booking in result)
            {
                Assert.Equal(53, booking.ID_ArchiveBooking);
                Assert.Equal(24, booking.ID_ArchiveCode);
                Assert.Equal("03", booking.DocumentNumber);
                Assert.Equal(new DateTime(2020, 03, 04), booking.Date);
                Assert.Equal(20, booking.Year);
                Assert.Equal("grgrg", booking.Subject);
                Assert.Equal(1, booking.ID_Sender);
                Assert.Equal("04-03/20", booking.EntryCode);
            }
        }

        [Fact]
        public void GetBookingsBySender()
        {
            //Arrange
            var archiveBookingEngine = new ArchiveBookingEngine();

            //Act
            List<ArchiveBooking> result = archiveBookingEngine.GetArchiveBookingsBySender("gfresf");
            
            //Assert
            foreach (ArchiveBooking booking in result)
            {
                Assert.Equal(53, booking.ID_ArchiveBooking);
                Assert.Equal(24, booking.ID_ArchiveCode);
                Assert.Equal("03", booking.DocumentNumber);
                Assert.Equal(new DateTime(2020, 03, 04), booking.Date);
                Assert.Equal(20, booking.Year);
                Assert.Equal("grgrg", booking.Subject);
                Assert.Equal(1, booking.ID_Sender);
                Assert.Equal("04-03/20", booking.EntryCode);
            }
        }

        [Fact]
        public void InsertArchiveBooking() 
        {
            //Arrange
            var archiveBookingEngine = new ArchiveBookingEngine();
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
            archiveBookingEngine.InsertArchiveBooking(booking);
            booking = null;
            booking = archiveBookingEngine.GetArchiveBookingByDocumentNumber(DocumentNumber);

            //Assert
            Assert.Equal(22, booking.ID_ArchiveCode);
            Assert.Equal("02", booking.DocumentNumber);
            Assert.Equal(new DateTime(2020, 03, 03), booking.Date);
            Assert.Equal(20, booking.Year);
            Assert.Equal("ghjkfl", booking.Subject);
            Assert.Equal(2, booking.ID_Sender);
            Assert.Equal("04-02/20", booking.EntryCode);
        }

        [Fact]
        public void InsertArchiveBookings()
        {
            //Arrange
            var archiveBookingEngine = new ArchiveBookingEngine();
            List<ArchiveBooking> bookings = new List<ArchiveBooking>();
            List<ArchiveBooking> result = new List<ArchiveBooking>();
            const int ID1 = 100;
            const int ID_ArchiveCode1 = 22;
            const string DocumentNumber1 = "04";
            DateTime Date1 = new DateTime(2020, 03, 03);
            const int Year1 = 20;
            const string Subject1 = "ghjkfl";
            const int ID_Sender1 = 2;
            const string EntryCode1 = "04-02/20";
            const int ID2 = 100;
            const int ID_ArchiveCode2 = 22;
            const string DocumentNumber2 = "05";
            DateTime Date2 = new DateTime(2020, 03, 03);
            const int Year2 = 20;
            const string Subject2 = "ghjkfl";
            const int ID_Sender2 = 2;
            const string EntryCode2 = "04-02/20";
            const int ID3 = 100;
            const int ID_ArchiveCode3 = 22;
            const string DocumentNumber3 = "06";
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
            archiveBookingEngine.InsertArchiveBookings(bookings);
            result.Add(archiveBookingEngine.GetArchiveBookingByDocumentNumber(DocumentNumber1));
            result.Add(archiveBookingEngine.GetArchiveBookingByDocumentNumber(DocumentNumber2));
            result.Add(archiveBookingEngine.GetArchiveBookingByDocumentNumber(DocumentNumber3));
            bool isValid = true;

            //Assert
            for(int i=0; i<result.Count; i++)
            {
                Assert.Equal(bookings[i].ID_ArchiveCode, result[i].ID_ArchiveCode);
                Assert.Equal(bookings[i].DocumentNumber, result[i].DocumentNumber);
                Assert.Equal(bookings[i].Date, result[i].Date);
                Assert.Equal(bookings[i].Year, result[i].Year);
                Assert.Equal(bookings[i].Subject, result[i].Subject);
                Assert.Equal(bookings[i].ID_Sender, result[i].ID_Sender);
                Assert.Equal(bookings[i].EntryCode, result[i].EntryCode);
            }
        }

        [Fact]
        public void UpdateArchiveBookingByID() 
        {
            //Arrange
            var archiveBookingEngine = new ArchiveBookingEngine();
            const int ID = 100;
            const int ID_ArchiveCode = 22;
            const string DocumentNumber = "02";
            DateTime Date = new DateTime(2020, 03, 03);
            const int Year = 20;
            const string Subject = "grdfdger";
            const int ID_Sender = 2;
            const string EntryCode = "04-02/20";

            //Act
            ArchiveBooking booking = new ArchiveBooking(ID, ID_ArchiveCode, DocumentNumber, Date.Date, Year, Subject, ID_Sender, EntryCode);
            archiveBookingEngine.UpdateArchiveBookingByID(56, booking);
            booking = null;
            booking = archiveBookingEngine.GetArchiveBookingByID(56);

            //Assert
            Assert.Equal(22, booking.ID_ArchiveCode);
            Assert.Equal("02", booking.DocumentNumber);
            Assert.Equal(Date, booking.Date);
            Assert.Equal(20, booking.Year);
            Assert.Equal("grdfdger", booking.Subject);
            Assert.Equal(2, booking.ID_Sender);
            Assert.Equal("04-02/20", booking.EntryCode);
        }

        [Fact]
        public void DeleteBookingsByArchiveCodeID()
        {
            //Arrange
            var archiveBookingEngine = new ArchiveBookingEngine();
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
            archiveBookingEngine.InsertArchiveBooking(booking);
            archiveBookingEngine.DeleteArchiveBookingsByArchiveCodeID(ID_ArchiveCode);
            booking = null;
            booking = archiveBookingEngine.GetArchiveBookingByDocumentNumber(DocumentNumber);
            bool isValid = true;
            if (booking.DocumentNumber != null)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Archive booking with Archive Code ID=22 is not valid");
        }

        [Fact]
        public void DeleteBookingById()
        {
            //Arrange
            var archiveBookingEngine = new ArchiveBookingEngine();

            //Act
            archiveBookingEngine.DeleteArchiveBookingById(1);
            ArchiveBooking booking = null;
            booking = archiveBookingEngine.GetArchiveBookingByID(1);
            bool isValid = true;
            if (booking.DocumentNumber != null)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Archive booking with ID=1 is not valid");
        }

        [Fact]
        public void DeleteBookingsBySenderID()
        {
            //Arrange
            var archiveBookingEngine = new ArchiveBookingEngine();
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
            archiveBookingEngine.InsertArchiveBooking(booking);
            archiveBookingEngine.DeleteArchiveBookingsBySenderID(ID_Sender);
            booking = null;
            booking = archiveBookingEngine.GetArchiveBookingByDocumentNumber(DocumentNumber);
            bool isValid = true;
            if (booking.DocumentNumber != null)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Archive booking with Sender ID=2 is not valid");
        }

        [Fact]
        public void DeleteBookingsByYear()
        {
            //Arrange
            var archiveBookingEngine = new ArchiveBookingEngine();
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
            archiveBookingEngine.InsertArchiveBooking(booking);
            archiveBookingEngine.DeleteArchiveBookingsByYear(Year);
            booking = null;
            booking = archiveBookingEngine.GetArchiveBookingByDocumentNumber(DocumentNumber);
            bool isValid = true;
            if (booking.DocumentNumber != null)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Archive booking with Year=20 is not valid");
        }

        [Fact]
        public void DeleteBookingsByDocumentNumber()
        {
            //Arrange
            var archiveBookingEngine = new ArchiveBookingEngine();
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
            archiveBookingEngine.InsertArchiveBooking(booking);
            archiveBookingEngine.DeleteArchiveBookingsByDocumentNumber(DocumentNumber);
            booking = null;
            booking = archiveBookingEngine.GetArchiveBookingByDocumentNumber(DocumentNumber);
            bool isValid = true;
            if (booking.DocumentNumber != null)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Archive booking with Year=20 is not valid");
        }

        [Fact]
        public void DeleteBookingsByDate()
        {
            //Arrange
            var archiveBookingEngine = new ArchiveBookingEngine();
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
            archiveBookingEngine.InsertArchiveBooking(booking);
            archiveBookingEngine.DeleteArchiveBookingsByDate(Date);
            booking = null;
            booking = archiveBookingEngine.GetArchiveBookingByDocumentNumber(DocumentNumber);
            bool isValid = true;
            if (booking.DocumentNumber != null)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Archive booking with Date=2020-03-03 is not valid");
        }

        [Fact]
        public void DeleteBookingsBySubject()
        {
            //Arrange
            var archiveBookingEngine = new ArchiveBookingEngine();
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
            archiveBookingEngine.InsertArchiveBooking(booking);
            archiveBookingEngine.DeleteArchiveBookingsBySubject(Subject);
            booking = null;
            booking = archiveBookingEngine.GetArchiveBookingByDocumentNumber(DocumentNumber);
            bool isValid = true;
            if (booking.DocumentNumber != null)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Archive booking with Year=20 is not valid");
        }

        [Fact]
        public void DeleteBookingsByEntryCode()
        {
            //Arrange
            var archiveBookingEngine = new ArchiveBookingEngine();
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
            archiveBookingEngine.InsertArchiveBooking(booking);
            archiveBookingEngine.DeleteArchiveBookingsByEntryCode(EntryCode);
            booking = null;
            booking = archiveBookingEngine.GetArchiveBookingByEntryCode(EntryCode);
            bool isValid = true;
            if (booking.DocumentNumber != null)
                isValid = false;

            //Assert
            Assert.True(isValid, "The Archive booking with EntryCode=04-02/20 is not valid");
        }
    }
}
