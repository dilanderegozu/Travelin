using Project3Travelin.Dtos.ReservationDtos;
using Project3Travelin.Entities;

namespace Project3Travelin.Services.ReservationServices
{
    public interface IReservationService
    {
        Task CreateReservationAsync(CreateReservationDto dto);
        Task<List<Reservation>> GetReservationsByUserIdAsync(string userId);
        Task<List<ResultReservationDto>> GetAllReservationsAsync();
        Task<Reservation> GetReservationByIdAsync(string id);
        Task UpdateReservationStatusAsync(string id, string status);
        Task DeleteReservationAsync(string id);
    }
}