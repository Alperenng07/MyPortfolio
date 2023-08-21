using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.UI.Models;
using Portfolio.Business.Service.BaseService;
using System.Diagnostics;


namespace MyPortfolio.UI.Controllers
{
  
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;
        private readonly IBaseService<Comment> _service;
        public HomeController(ILogger<HomeController> logger, DataContext context, IBaseService<Comment> service)
        {
            _logger = logger;
            _context = context;
            _service = service;
        }




        [HttpGet]
        public async Task<IActionResult> Index()
        {

            ModeratorFullViewModel model = new ModeratorFullViewModel();

            model.Moderators = _context.Moderators.ToList();
            model.Jobs = _context.Jobs.ToList();
            model.Projects = _context.Projects.ToList();
            model.Languages = _context.Languages.ToList();
            model.Skills = _context.Skills.ToList();
            model.Educations = _context.Educations.ToList();
            model.Experiences = _context.Experiences.ToList();
            model.Offers = _context.Offers.ToList();
            model.Users = _context.Users.ToList();
            model.Comments = _context.Comments.ToList();

            return View(model);


        }



        public IActionResult Privacy()
        {
            return View();
        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

  
        public ActionResult Create()
        {
            CommentView model = new CommentView();

         
            return PartialView("_CreateComment", model);
        }
      
        [HttpPost]
        public ActionResult ActionCreate(CommentView model)
        {
            var comment = new Comment();
            comment.Answer = model.Answer;
            comment.Text = model.Text;
            comment.UserId = model.UserId;
            var response = this._service.AddAsync(comment);

            return this.RedirectToAction("Index");
        }






    }
}