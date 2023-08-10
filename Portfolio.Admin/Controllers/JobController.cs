using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Admin.Controllers
{
    public class JobController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
