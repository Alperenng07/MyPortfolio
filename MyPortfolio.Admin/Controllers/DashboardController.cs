using Microsoft.AspNetCore.Mvc;

namespace MyBlogWebSite.Admin.Controllers
{
    public class DashboardController : Controller
    {
        public DashboardController()
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
