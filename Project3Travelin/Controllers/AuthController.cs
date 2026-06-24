using Microsoft.AspNetCore.Mvc;

namespace Project3Travelin.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
