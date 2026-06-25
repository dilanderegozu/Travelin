using Microsoft.AspNetCore.Mvc;
using Project3Travelin.Dtos.CategoryDtos;
using Project3Travelin.Dtos.TourDtos;
using Project3Travelin.Services.CategoryServices;
using Project3Travelin.Services.CommentServices;
using Project3Travelin.Services.TourServices;

namespace Project3Travelin.Controllers
{
    public class TourController : Controller
    {
        private readonly ITourService _tourService;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;

        public TourController(ITourService tourService, ICategoryService categoryService, ICommentService commentService)
        {
            _tourService = tourService;
            _categoryService = categoryService;
            _commentService = commentService;
        }

        public IActionResult CreateTour()
        {
            return View();
        }

        [HttpPost] 
        public async Task<IActionResult> CreateTour(CreateTourDto createTourDto)
        {
         
            await _tourService.CreateTourAsync(createTourDto);
            return RedirectToAction("TourList");

        }

        public async Task<IActionResult> TourList(int page = 1)
        {
            ViewBag.Page = page;
            return View();
        }

        public async Task<IActionResult> TourDetail(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            var values = await _tourService.GetTourByIdAsync(id);

            if (values == null)
            {
                return NotFound();
            }

            ViewBag.Categories = await _categoryService.GetAllCategoryAsync();
            ViewBag.Comments = await _commentService.GetCommentsByTourAsync(id);
            ViewBag.CommentCount = await _commentService.GetCommentCountByTourAsync(id);

            ViewBag.AverageScore = await _commentService.GetAverageScoreByTourAsync(id);

            return View(values);
        }
        public async Task<IActionResult> TourDestination()
        {
            var values = await _tourService.GetAllTourAsync();
            return View(values);
        }

        public async Task<IActionResult> TourListGrid(int page=1)
        {
            const int pageSize = 3;

            var totalCount = await _tourService.GetTourCountAsync();
            var values = await _tourService.GetPagedToursAsync(page, pageSize);
            ViewBag.Categories = await _categoryService.GetAllCategoryAsync();
            ViewBag.CurrentPage = page;
            ViewBag.TotalCount = totalCount;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            ViewBag.StartItem = (page - 1) * pageSize + 1;
            ViewBag.EndItem = Math.Min((long)(page * pageSize), totalCount);
            return View(values);
        }

     

    }
}
