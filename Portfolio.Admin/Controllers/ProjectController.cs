using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Admin.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
