using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Sender
    {
        public Sender() { }

        public Sender(int id, string name) 
        {
            ID_Sender = id;
            SenderName = name;
        }

        public int ID_Sender { get; set; }
        public string SenderName { get; set; }
    }
}
