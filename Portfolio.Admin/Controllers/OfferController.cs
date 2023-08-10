using Microsoft.AspNetCore.Mvc;

namespace Portfolio.Admin.Controllers
{
    public class OfferController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
