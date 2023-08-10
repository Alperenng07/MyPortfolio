using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Admin.Controllers
{
    public class ModeratorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
