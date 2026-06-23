using Microsoft.AspNetCore.Mvc;
using Project3Travelin.Dtos.TourDtos;
using Project3Travelin.Services.CategoryServices;
using Project3Travelin.Services.TourServices;

namespace Project3Travelin.Controllers
{
    public class AdminTourController : Controller
    {

        private readonly ITourService _tourService;
        private readonly ICategoryService _categoryService;

        public AdminTourController(ITourService tourService, ICategoryService categoryService)
        {
            _tourService = tourService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
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
            return View(values);
        }

        public async Task<IActionResult> TourCategory()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
        public IActionResult TourDate()
        {
            return View();
        }

        public IActionResult ReservationManagament()
        {
            return View();
        }
        public IActionResult CustomerManagament()
        {
            return View();
        }

        public IActionResult CustomerComment()
        {
            return View();
        }

        public IActionResult Report()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }
    }
}

