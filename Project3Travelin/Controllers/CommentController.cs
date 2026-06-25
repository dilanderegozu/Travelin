using AutoMapper;
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
            var values = await _commentService.GetAllCommentAsync();
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
        {
            createCommentDto.ImageUrl = "https://ui-avatars.com/api/?name=" +
                Uri.EscapeDataString(createCommentDto.NameSurname) +
                "&background=1D9E75&color=fff&size=80";

            await _commentService.CreateCommentAsync(createCommentDto);
            return RedirectToAction("TourDetail", "Tour", new { id = createCommentDto.TourId });
        }
    }
}