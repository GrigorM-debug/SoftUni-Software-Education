using Microsoft.AspNetCore.Mvc;

namespace EventMI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
