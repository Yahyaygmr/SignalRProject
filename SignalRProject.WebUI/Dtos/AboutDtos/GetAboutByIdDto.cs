﻿namespace SignalRProject.WebUI.Dtos.AboutDtos
{
    public class GetAboutByIdDto
    {
        public int AboutId { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
