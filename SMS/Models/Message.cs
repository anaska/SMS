using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public DateTime SentDate { get; set; }
        public bool ReadStatus { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}