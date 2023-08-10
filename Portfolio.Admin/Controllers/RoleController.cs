using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Admin.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
