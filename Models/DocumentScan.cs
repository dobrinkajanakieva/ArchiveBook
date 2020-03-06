using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class DocumentScan
    {
        public DocumentScan() { }

        public DocumentScan(int id_DocumentScan, int id_ArchiveBooking, string documentPath) 
        {
            ID_DocumentScan = id_DocumentScan;
            ID_ArchiveBooking = id_ArchiveBooking;
            DocumentPath = documentPath;
        }

        public int? ID_DocumentScan { get; set; }
        public int ID_ArchiveBooking { get; set; }
        public string DocumentPath { get; set; }
    }
}
