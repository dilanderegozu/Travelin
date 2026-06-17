namespace Project3Travelin.Dtos.TourDtos
{
    public class CreateTourDto
    {
         public string MyProperty { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public DateTime TourDate { get; set; }
        public string DayNight { get; set; }
    }
}
