﻿using Entities;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Admin.Models;
using Portfolio.Business.Service.BaseService;
using System.Diagnostics;

namespace Portfolio.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBaseService<Comment> _service;

        public HomeController(ILogger<HomeController> logger, IBaseService<Comment> service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
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