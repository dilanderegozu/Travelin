using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project3Travelin.Dtos.AccountDtos;
using Project3Travelin.Dtos.TourDtos;
using Project3Travelin.Services.CategoryServices;
using Project3Travelin.Services.CommentServices;
using Project3Travelin.Services.ReservationServices;
using Project3Travelin.Services.TourServices;

namespace Project3Travelin.Controllers
{
    public class AdminTourController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IReservationService _reservationService;
        private readonly ITourService _tourService;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;

        public AdminTourController(UserManager<AppUser> userManager, IReservationService reservationService, ITourService tourService, ICategoryService categoryService, ICommentService commentService)
        {
            _userManager = userManager;
            _reservationService = reservationService;
            _tourService = tourService;
            _categoryService = categoryService;
            _commentService = commentService;
        }

        public async Task<IActionResult> Index()
        {
            var allReservations = await _reservationService.GetAllReservationsAsync();
            var allTours = await _tourService.GetAllTourAsync();
        
            var categoryDistribution = allReservations
      .GroupBy(r => {
          var tour = allTours.FirstOrDefault(t => t.TourId == r.TourId);
          return tour?.CategoryName ?? "Diğer";
      })
      .Select(g => new {
          CategoryName = g.Key,
          Count = g.Count(),
          Percentage = Math.Round((double)g.Count() / allReservations.Count * 100)
      })
      .OrderByDescending(x => x.Count)
      .ToList();

            var topTours = allTours.Take(5).ToList();

            ViewBag.TopTours = topTours.Select(t => new { t.Title, t.ImageUrl }).ToList();
            ViewBag.CategoryDistribution = categoryDistribution;
            ViewBag.TotalCustomers = _userManager.Users.Count();
            ViewBag.TotalReservations = allReservations.Count;
            ViewBag.PendingReservations = allReservations.Count(x => x.Status == "Beklemede");
            ViewBag.ApprovedReservations = allReservations.Count(x => x.Status == "Onaylandı");
            ViewBag.TotalTours = allTours.Count;

   
            var now = DateTime.Now;
            var monthly12 = Enumerable.Range(0, 12)
                .Select(i => {
                    var month = now.AddMonths(-11 + i);
                    return new
                    {
                        Label = month.ToString("MMM", new System.Globalization.CultureInfo("tr-TR")),
                        Count = allReservations.Count(r =>
                            r.CreatedAt.Year == month.Year &&
                            r.CreatedAt.Month == month.Month)
                    };
                }).ToList();

            ViewBag.ChartLabels12 = System.Text.Json.JsonSerializer.Serialize(monthly12.Select(x => x.Label));
            ViewBag.ChartData12 = System.Text.Json.JsonSerializer.Serialize(monthly12.Select(x => x.Count));

          
            var monthly6 = monthly12.TakeLast(6).ToList();
            ViewBag.ChartLabels6 = System.Text.Json.JsonSerializer.Serialize(monthly6.Select(x => x.Label));
            ViewBag.ChartData6 = System.Text.Json.JsonSerializer.Serialize(monthly6.Select(x => x.Count));

            return View();
        }
        public async Task<IActionResult> CreateTour()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTour(CreateTourDto createTourDto)
        {
            await _tourService.CreateTourAsync(createTourDto);
            return RedirectToAction("TourList");
        }
        public async Task<IActionResult> TourList()
        {
            var values=await _tourService.GetAllTourAsync();
            var totalTour = values.Select(x=>true).Count();
            var totalActiveTour = values.Where(x => x.IsStatus).Count();
            var totalCapacity = values.Sum(x => x.Capacity);

            ViewBag.TotalCapasite = totalCapacity;
            ViewBag.TotalActiveTour = totalActiveTour;
            ViewBag.TotalTour = totalTour;
            return View(values);
        }

        public async Task<IActionResult> TourCategory()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            var allTours = await _tourService.GetAllTourAsync();

            ViewBag.TotalCategory = values.Count;
            ViewBag.ActiveCategory = values.Count(x => x.IsStatus);
            ViewBag.TotalActiveTour = allTours.Count(x => x.IsStatus);

         
            var tourCountByCategory = allTours
                .GroupBy(t => t.CategoryName)
                .ToDictionary(g => g.Key ?? "", g => g.Count());

            ViewBag.TourCountByCategory = tourCountByCategory;

            return View(values);
        }

        public async Task<IActionResult> DeleteTour(string id)
        {
            await _tourService.DeleteTourAsync(id);
            return RedirectToAction("TourList");

        }

        public async Task<IActionResult> UpdateTour(string id)
        {
            var values = await _tourService.GetTourByIdAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTour(UpdateTourDto updateTourDto)
        {
            await _tourService.UpdateTourAsync(updateTourDto);
            return RedirectToAction("TourList");
        }
        public async Task<IActionResult> TourDate()
        {
            var allTours = await _tourService.GetAllTourAsync();
            ViewBag.Tours = allTours;
            return View();
        }

        public async Task<IActionResult> ReservationManagament()
        {
            var values = await _reservationService.GetAllReservationsAsync();
            ViewBag.TotalReservations = values.Count;
            ViewBag.PendingReservations = values.Count(x => x.Status == "Beklemede");
            ViewBag.ApprovedReservations = values.Count(x => x.Status == "Onaylandı");
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateReservationStatus(string id, string status)
        {
            await _reservationService.UpdateReservationStatusAsync(id, status);
            return RedirectToAction("ReservationManagament");
        }
        public async Task<IActionResult> CustomerManagament()
        {
            var users = _userManager.Users.ToList();
            var allReservations = await _reservationService.GetAllReservationsAsync();

            ViewBag.TotalCustomers = users.Count;

            var userStats = users.Select(u => new
            {
                User = u,
                TourCount = allReservations.Count(r => r.UserId == u.Id.ToString()),
                LastReservation = allReservations
                    .Where(r => r.UserId == u.Id.ToString())
                    .OrderByDescending(r => r.CreatedAt)
                    .FirstOrDefault()?.CreatedAt
            }).ToList();

            ViewBag.UserStats = userStats;
            return View(users);
        }
        public async Task<IActionResult> CustomerComment()
        {
            var comments = await _commentService.GetAllCommentAsync();
            ViewBag.TotalComments = comments.Count;
            ViewBag.PendingComments = comments.Count(x => !x.IsStatus);
            ViewBag.AverageScore = comments.Any()
                ? Math.Round(comments.Average(x => x.Score), 1)
                : 0;
            return View(comments);
        }

        [HttpPost]
        public async Task<IActionResult> ApproveComment(string id)
        {
            await _commentService.ApproveCommentAsync(id);
            return RedirectToAction("CustomerComment");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteComment(string id)
        {
            await _commentService.DeleteCommentAsync(id);
            return RedirectToAction("CustomerComment");
        }

        public IActionResult Report()
        {
            return View();
        }

        public async Task<IActionResult> Settings()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfile(UpdateProfileDto dto)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login", "Account");

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;
            user.ImageUrl = dto.ImageUrl;
            user.Phone = dto.Phone;
            user.Address = dto.Address;
            user.Website = dto.Website;
            user.Facebook = dto.Facebook;
            user.Instagram = dto.Instagram;
            user.SupportEmail = dto.SupportEmail;

            await _userManager.UpdateAsync(user);
            TempData["Success"] = "Profil güncellendi.";
            return RedirectToAction("Settings");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto dto)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToAction("Login", "Account");

            if (dto.NewPassword != dto.ConfirmPassword)
            {
                TempData["PasswordError"] = "Şifreler eşleşmiyor.";
                return RedirectToAction("Settings");
            }

            var result = await _userManager.ChangePasswordAsync(user, dto.CurrentPassword, dto.NewPassword);
            if (!result.Succeeded)
            {
                TempData["PasswordError"] = string.Join(", ", result.Errors.Select(e => e.Description));
                return RedirectToAction("Settings");
            }

            TempData["PasswordSuccess"] = "Şifre güncellendi.";
            return RedirectToAction("Settings");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
                await _userManager.DeleteAsync(user);
            return RedirectToAction("CustomerManagament");
        }
    }
}

