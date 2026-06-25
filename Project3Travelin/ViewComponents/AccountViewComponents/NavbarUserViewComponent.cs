using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project3Travelin.Entities;

public class NavbarUserViewComponent : ViewComponent
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public NavbarUserViewComponent(UserManager<AppUser> userManager,
                                   SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        if (!_signInManager.IsSignedIn(HttpContext.User))
            return View("Default", (AppUser)null);

        var user = await _userManager.GetUserAsync(HttpContext.User);
        return View("Default", user);
    }
}