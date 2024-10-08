﻿namespace SignalRProject.WebUI.Dtos.PoductDtos
{
    public class ResultProductWithCategoryDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryName { get; set; }
        public bool Status { get; set; }

        public int CategoryId { get; set; }
    }
}
