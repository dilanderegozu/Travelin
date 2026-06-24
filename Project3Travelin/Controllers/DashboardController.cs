using Microsoft.AspNetCore.Mvc;
using Project3Travelin.Services.CategoryServices;
using Project3Travelin.Services.TourServices;

namespace Project3Travelin.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ITourService _tourService;
        private readonly ICategoryService _categoryService;

        public DashboardController(ITourService tourService, ICategoryService categoryService)
        {
            _tourService = tourService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _tourService.GetAllTourAsync();
            ViewBag.Categories = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
        public async Task<IActionResult> Search(string? city, string? categoryId, string? dayNight, string? date)
        {
            var results = await _tourService.GetFilteredToursAsync(city, categoryId, dayNight);

            if (results == null || !results.Any())
                return View("NoResult");

            return RedirectToAction("TourList", "Tour", new { city, categoryId, dayNight });
        }
    }
}