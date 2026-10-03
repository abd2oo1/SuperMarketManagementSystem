using Microsoft.AspNetCore.Mvc;

namespace WebApp.AddControllersWithViews
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("index");
        }
    }
}