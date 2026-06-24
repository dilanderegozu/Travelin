using Project3Travelin.Entities;

namespace Project3Travelin.Dtos.TourDtos
{
    public class GetTourByIdDto
    {
        public string TourId { get; set; }

        public string Title { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int Capacity { get; set; }

        public DateTime TourDate { get; set; }

        public string DayNight { get; set; }

        public string CategoryName { get; set; }

        public decimal Rating { get; set; }

        public int ReviewCount { get; set; }

        public decimal Price { get; set; }

        public string Currency { get; set; }

        public int MinAge { get; set; }

        public string PickupLocation { get; set; }

        public string DepartureLocation { get; set; }

        public string ReturnLocation { get; set; }

        public string DepartureTime { get; set; }

        public int BedroomCount { get; set; }

        public List<string> Languages { get; set; }

        public List<string> Includes { get; set; }

        public List<string> Excludes { get; set; }

        public List<string> Highlights { get; set; }

        public List<TourPlan> TourPlans { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
