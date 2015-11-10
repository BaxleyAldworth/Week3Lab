using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Week3Lab.Models
{
    public class Message
    {
        public int ID { get; set; }
        public string Author { get; set; }
        public string Body { get; set; }
        public DateTime PostedDate { get; set; }
    }
}