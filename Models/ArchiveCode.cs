using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ArchiveCode
    {
        public ArchiveCode() { }
        public ArchiveCode(int id, string code, string name) 
        {
            ID_ArchiveCode = id;
            Code = code;
            Name = name;
        }

        public int? ID_ArchiveCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
