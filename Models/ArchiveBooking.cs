using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ArchiveBooking
    {
        public ArchiveBooking() { }

        public ArchiveBooking(int id, int id_ArchiveCode, string docNumber, DateTime date, int year, string subject, int id_Sender, string entryCode) 
        {
            ID_ArchiveBooking = id;
            ID_ArchiveBooking = id_ArchiveCode;
            DocumentNumber = docNumber;
            Date = date;
            Year = year;
            Subject = subject;
            ID_Sender = id_Sender;
            EntryCode = entryCode;
        }

        public int ID_ArchiveBooking { get; set; }
        public int ID_ArchiveCode { get; set; }
        public string DocumentNumber { get; set; }
        public DateTime Date { get; set; }
        public int Year { get; set; }
        public string Subject { get; set; }
        public int ID_Sender { get; set; }
        public string EntryCode { get; set; }
    }
}
