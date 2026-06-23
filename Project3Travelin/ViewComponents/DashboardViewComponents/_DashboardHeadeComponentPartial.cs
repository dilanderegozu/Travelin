using Microsoft.AspNetCore.Mvc;

namespace Project3Travelin.ViewComponents.DashboardViewComponents
{
    public class _DashboardHeadeComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
