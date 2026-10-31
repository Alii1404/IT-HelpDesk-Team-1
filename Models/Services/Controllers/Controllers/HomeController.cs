using Microsoft.AspNetCore.Mvc;

namespace ITHelpDesk
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
