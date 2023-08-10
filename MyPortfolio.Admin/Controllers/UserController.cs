using Microsoft.AspNetCore.Mvc;

namespace MyBlogWebSite.Admin.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
