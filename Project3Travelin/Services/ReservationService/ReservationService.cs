using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;
using Project3Travelin.Dtos.ReservationDtos;
using Project3Travelin.Entities;
using Project3Travelin.Services.TourServices;
using Project3Travelin.Settings;

namespace Project3Travelin.Services.ReservationServices
{
    public class ReservationService : IReservationService
    {
        private readonly IMongoCollection<Reservation> _reservations;
        private readonly IMongoCollection<Tour> _tours;

        public ReservationService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _reservations = database.GetCollection<Reservation>("Reservations");
            _tours = database.GetCollection<Tour>("Tours");
        }
        public async Task CreateReservationAsync(CreateReservationDto dto)
        {
            var reservation = new Reservation
            {
                UserId = dto.UserId,
                TourId = dto.TourId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                TourDate = dto.TourDate,
                PersonCount = dto.PersonCount,
                Note = dto.Note,
                Status = "Beklemede",
                CreatedAt = DateTime.Now
            };

            await _reservations.InsertOneAsync(reservation);
        }

        public async Task<List<Reservation>> GetReservationsByUserIdAsync(string userId)
        {
            return await _reservations
                .Find(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task<List<ResultReservationDto>> GetAllReservationsAsync()
        {
            var reservations = await _reservations.Find(_ => true).ToListAsync();
            var result = new List<ResultReservationDto>();

            foreach (var r in reservations)
            {
                var tour = await _tours.Find(t => t.TourId == r.TourId).FirstOrDefaultAsync();
                result.Add(new ResultReservationDto
                {
                    Id = r.Id,
                    UserId = r.UserId,
                    TourId = r.TourId,
                    TourName = tour?.Title ?? "Bilinmiyor",
                    FirstName = r.FirstName,
                    LastName = r.LastName,
                    Email = r.Email,
                    Phone = r.Phone,
                    TourDate = r.TourDate,
                    PersonCount = r.PersonCount,
                    Note = r.Note,
                    Status = r.Status,
                    CreatedAt = r.CreatedAt
                });
            }

            return result;
        }

        public async Task<Reservation> GetReservationByIdAsync(string id)
        {
            return await _reservations
                .Find(x => x.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task UpdateReservationStatusAsync(string id, string status)
        {
            var update = Builders<Reservation>.Update.Set(x => x.Status, status);
            await _reservations.UpdateOneAsync(x => x.Id == id, update);
        }

        public async Task DeleteReservationAsync(string id)
        {
            await _reservations.DeleteOneAsync(x => x.Id == id);
        }
    }
}