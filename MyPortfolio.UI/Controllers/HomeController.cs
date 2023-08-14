using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.UI.Models;
using System.Diagnostics;


namespace MyPortfolio.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;
        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
           _context = context;
        }


        //DataContext db = new();
        public async Task<IActionResult> Index()
        {
           
        ModeratorFullViewModel model = new ModeratorFullViewModel();

        model.Moderators= _context.Moderators.ToList();

        return View(model);

          
        }



        //[HttpPost]
        //public async Task<IActionResult> Index(ModeratorFullViewModel lang)
        //{
        //    var langs = await _service.AddAsync(lang);
        //    return View(langs);
        //}







        public IActionResult Privacy()
        {
            return View();
        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}