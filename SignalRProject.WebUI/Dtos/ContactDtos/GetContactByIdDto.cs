﻿namespace SignalRProject.WebUI.Dtos.ContactDtos
{
    public class GetContactByIdDto
    {
        public int ContactId { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string FooterDescription { get; set; }
    }
}
