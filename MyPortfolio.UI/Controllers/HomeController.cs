﻿using Entities;
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
            _service= service;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
           
        ModeratorFullViewModel model = new ModeratorFullViewModel();

            model.Moderators= _context.Moderators.ToList();
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



        [HttpPost]
        public async Task<IActionResult> Index(Comment lang)
        {
            var langs = await _service.AddAsync(lang);
            return View(langs);
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
    }
}