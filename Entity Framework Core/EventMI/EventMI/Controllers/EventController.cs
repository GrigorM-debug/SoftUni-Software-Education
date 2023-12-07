using Microsoft.AspNetCore.Mvc;

namespace EventMI.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
