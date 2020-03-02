using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    class DocumentScan
    {
        public DocumentScan() { }

        public int ID_DocumentScan { get; set; }
        public int ID_ArchiveBooking { get; set; }
        public string DocumentPath { get; set; }
    }
}
