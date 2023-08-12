using Entities;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Service.BaseService;

namespace Portfolio.Admin.Controllers
{
    public class ModeratorController : Controller
    {

        private readonly IBaseService<Moderator> _service;

        public ModeratorController(IBaseService<Moderator> service)
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
        public async Task<IActionResult> Create(Moderator lang)
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
        public async Task<IActionResult> Update(Moderator lang)
        {
            var langs = await _service.UpdateAsync(lang);
            return View(langs);
        }
    }
}
