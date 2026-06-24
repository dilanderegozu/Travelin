using Microsoft.AspNetCore.Mvc;
using Project3Travelin.Dtos.CommentDtos;
using Project3Travelin.Services.CommentServices;

namespace Project3Travelin.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IActionResult> GetAllComment()
        {
            var values= await _commentService.GetAllCommentAsync();
            return View(values);
        }

        public IActionResult CreateComment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
        {
            createCommentDto.ImageUrl = "/travelin/images/reviewer/user.png";

            await _commentService.CreateCommentAsync(createCommentDto);

            return RedirectToAction("TourDetail", "Tour", new
            {
                id = createCommentDto.TourId
            });
        }



    }
}
