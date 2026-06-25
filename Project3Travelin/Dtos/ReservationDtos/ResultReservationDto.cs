namespace Project3Travelin.Dtos.ReservationDtos
{
    public class ResultReservationDto
    {
        public string TourName { get; set; }
        public string Id { get; set; }

        public string UserId { get; set; }
        public string TourId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }

        public DateTime TourDate { get; set; }

        public int PersonCount { get; set; }

        public string Status { get; set; }
        public string? Note { get; set; }
        public DateTime CreatedAt { get; set; }
    
    }
}