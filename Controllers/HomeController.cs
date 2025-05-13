using Microsoft.AspNetCore.Mvc;

namespace TvujProjekt.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
