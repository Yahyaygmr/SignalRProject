﻿namespace SignalRProject.DtoLayer.MessageDtos
{
    public class UpdateMessageDto
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