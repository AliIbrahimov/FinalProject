using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithRepositoryDesignPattern.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult OurFeatures()
        {
            return View();
        }
        public IActionResult FreeQuote()
        {
            return View();
        }
        public IActionResult Developers()
        {
            return View();
        }
    }
}
