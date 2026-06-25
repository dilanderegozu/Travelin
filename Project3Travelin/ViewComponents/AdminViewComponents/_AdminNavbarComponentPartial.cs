using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Project3Travelin.ViewComponents.AdminViewComponents
{
    public class _AdminNavbarComponentPartial:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _AdminNavbarComponentPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return View("Default", user);
        }
    }
}
