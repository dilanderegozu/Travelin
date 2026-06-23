using Microsoft.AspNetCore.Mvc;

namespace Project3Travelin.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
