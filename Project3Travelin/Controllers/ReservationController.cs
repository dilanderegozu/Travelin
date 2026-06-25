using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project3Travelin.Dtos.ReservationDtos;
using Project3Travelin.Entities;
using Project3Travelin.Services.ReservationServices;
using Project3Travelin.Services.TourServices;

namespace Project3Travelin.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITourService _tourService;

        public ReservationController(IReservationService reservationService, UserManager<AppUser> userManager, ITourService tourService)
        {
            _reservationService = reservationService;
            _userManager = userManager;
            _tourService = tourService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            var reservations = await _reservationService.GetReservationsByUserIdAsync(user.Id.ToString());
            return View(reservations);
        }
        [HttpGet]
        public async Task<IActionResult> Create(string tourId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            // Tur bilgilerini çek
            var tour = await _tourService.GetTourByIdAsync(tourId);

            ViewBag.TourTitle = tour?.Title;
            ViewBag.TourPrice = tour?.Price;

            var dto = new CreateReservationDto
            {
                TourId = tourId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateReservationDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            dto.UserId = user.Id.ToString();

            await _reservationService.CreateReservationAsync(dto);

            TempData["Success"] = "Rezervasyonunuz başarıyla oluşturuldu.";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            await _reservationService.DeleteReservationAsync(id);
            TempData["Success"] = "Rezervasyon iptal edildi.";
            return RedirectToAction("Index");
        }
    }
}