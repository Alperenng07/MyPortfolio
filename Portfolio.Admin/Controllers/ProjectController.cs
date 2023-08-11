using Entities;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Service.BaseService;

namespace Portfolio.Admin.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IBaseService<Project> _service;

        public ProjectController(IBaseService<Project> service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var skills = await _service.GetAllAsync();
            return View(skills);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Project skills)
        {
            var _skills = await _service.AddAsync(skills);
            return View(_skills);
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
        public async Task<IActionResult> Update(Project skill)
        {
            var _skill = await _service.UpdateAsync(skill);
            return View(_skill);
        }
    }
}
