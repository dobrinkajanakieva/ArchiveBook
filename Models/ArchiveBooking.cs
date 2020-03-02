using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    class ArchiveBooking
    {
        public ArchiveBooking() { }
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
