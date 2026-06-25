using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Project3Travelin.Entities
{
    public class Tour
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TourId { get; set; }

        public string Title { get; set; }
        public string Country { get; set; }
        public string ImageUrl { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public DateTime TourDate { get; set; }
        public string DayNight { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string CategoryId { get; set; }

        [BsonIgnore]
        public string CategoryName { get; set; }

        public decimal Rating { get; set; }

        public decimal Price { get; set; }

        public string Currency { get; set; } = "₺";
        // Minimum Yaş
        public int MinAge { get; set; }

        // Alınış Noktası
        public string PickupLocation { get; set; }

        // Kalkış Lokasyonu
        public string DepartureLocation { get; set; }

        // Dönüş Lokasyonu
        public string ReturnLocation { get; set; }

        // Kalkış Saati
        public string DepartureTime { get; set; }

        // Oda Sayısı
        public int BedroomCount { get; set; }

        // Konuşulan Diller
        public List<string> Languages { get; set; }

        // Fiyata Dahil Olanlar
        public List<string> Includes { get; set; }

        // Fiyata Dahil Olmayanlar
        public List<string> Excludes { get; set; }

        // Öne Çıkan Özellikler
        public List<string> Highlights { get; set; }

        // Tur Programı (1. Gün, 2. Gün vb.)
        public List<TourPlan> TourPlans { get; set; }

        // Harita Enlem Bilgisi
        public double Latitude { get; set; }

        // Harita Boylam Bilgisi
        public double Longitude { get; set; }
        public bool IsStatus { get; set; }
    }

    public class TourPlan
    {
        // Gün Numarası
        public int DayNumber { get; set; }

        // Gün Başlığı
        public string Title { get; set; }

        // Gün Açıklaması
        public string Description { get; set; }
    }
}
