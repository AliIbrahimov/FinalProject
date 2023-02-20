using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithRepositoryDesignPattern.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
