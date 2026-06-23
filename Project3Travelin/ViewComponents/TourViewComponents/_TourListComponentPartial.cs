using Microsoft.AspNetCore.Mvc;
using Project3Travelin.Services.TourServices;

namespace Project3Travelin.ViewComponents.TourViewComponents
{
    public class _TourListComponentPartial:ViewComponent
    {

        private readonly ITourService _tourService;

        public _TourListComponentPartial(ITourService tourService)
        {
            _tourService = tourService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int page = 1)
        {
            const int pageSize = 3;

            var totalCount = await _tourService.GetTourCountAsync();
            var values = await _tourService.GetPagedToursAsync(page, pageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalCount = totalCount;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            ViewBag.StartItem = (page - 1) * pageSize + 1;
            ViewBag.EndItem = Math.Min((long)(page * pageSize), totalCount);

            return View(values);
        }
    }
}
