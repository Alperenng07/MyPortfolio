﻿using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Service.BaseService;

namespace MyPortfolio.UI.Controllers
{
    [Authorize]
    public class OfferController : Controller
    {
        private readonly IBaseService<Offer> _service;

        public OfferController(IBaseService<Offer> service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var langs = await _service.GetAllAsync();
            return View(langs);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Offer lang)
        {
            var langs = await _service.AddAsync(lang);
            return View(langs);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(Guid id)
        {
            var use = await _service.GetByIdAsync(id);
            if (use == null)
            {
                return RedirectToPage("Index");
            }
            return View(use);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var use = await _service.GetByIdAsync(id);
            if (use == null)
            {
                return RedirectToPage("Index");
            }
            await _service.DeleteAsync(id);
            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var use = await _service.GetByIdAsync(id);
            if (use == null)
            {
                return RedirectToPage("Index");
            }

            return View(use);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Offer lang)
        {
            var langs = await _service.UpdateAsync(lang);
            return View(langs);
        }
    }
}
