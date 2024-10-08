﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRProject.EntityLayer.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public string FullName { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Subject { get; set; }
        public string MessageContent { get; set; }
        public DateTime SendDate { get; set; }
        public bool Status { get; set; }
    }
}
