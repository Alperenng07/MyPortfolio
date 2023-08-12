using Entities;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Business.Service.BaseService;

namespace Portfolio.Admin.Controllers
{
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

        
    }
}
