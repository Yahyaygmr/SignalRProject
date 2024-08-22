namespace SignalRProject.WebUI.Dtos.BookingDtos
{
    public class CreateBookingDto
    {
        public string Title { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Description { get; set; }
        public int PersonCount { get; set; }
        public DateTime Date { get; set; }
    }
}
