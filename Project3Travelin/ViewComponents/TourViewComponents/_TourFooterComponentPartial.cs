using Microsoft.AspNetCore.Mvc;
using Project3Travelin.Services.CategoryServices;
using Project3Travelin.Services.TourServices;

namespace Project3Travelin.ViewComponents.TourViewComponents
{
    public class _TourFooterComponentPartial:ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _TourFooterComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
    }
}
