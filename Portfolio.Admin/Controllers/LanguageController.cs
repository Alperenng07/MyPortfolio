using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Admin.Controllers
{
    public class LanguageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
