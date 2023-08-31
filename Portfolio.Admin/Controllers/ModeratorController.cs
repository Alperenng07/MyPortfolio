using Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Admin.Models;
using Portfolio.Business.Service.BaseService;

namespace Portfolio.Admin.Controllers
{
    public class ModeratorController : Controller
    {

        private readonly IBaseService<Moderator> _service;
        private readonly IWebHostEnvironment _webHostEnvironment;
       
        public ModeratorController(IBaseService<Moderator> service, IWebHostEnvironment webHostEnvironment)
        {
            _service = service;
            _webHostEnvironment = webHostEnvironment;
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
        public async Task<IActionResult> Create(Moderator lang, ModeratorImgModelView umv)
        {
           



                var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                if (!Directory.Exists(imagePath))
                {
                    Directory.CreateDirectory(imagePath);
                }
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(umv.ImageFile.FileName);
                var filePath = Path.Combine(imagePath, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await umv.ImageFile.CopyToAsync(fileStream);
                }

            //if (GetCurrentUserId() == -1)
            //{
            //    return RedirectToAction("Index");
            //}

            var blog = new Moderator
                {
                    ImageFile = fileName
                };
                await _service.AddAsync(blog);
                return RedirectToAction("Index");
            



            //var langs = await _service.AddAsync(lang);
            //return View(langs);
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
        public async Task<IActionResult> Update(Moderator moderator, ModeratorImgModelView umv)
        {



            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            if (!Directory.Exists(imagePath))
            {
                Directory.CreateDirectory(imagePath);
            }
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(umv.ImageFile.FileName);
            var filePath = Path.Combine(imagePath, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await umv.ImageFile.CopyToAsync(fileStream);
            }

            //if (GetCurrentUserId() == -1)
            //{
            //    return RedirectToAction("Index");
            //}

            var blog = new Moderator
            {       
            //Name = umv.Name,
            //Password = umv.Password,
            //Phone= umv.Phone,
            //Email = umv.Email,
            //Adress = umv.Adress,
            //Github = umv.Github,
            //Linedln = umv.Linedln,
            //Instagram = umv.Instagram,
            //Twitter = umv.Twitter,
            ImageFile = filePath,
            };
            //await _service.AddAsync(blog);
            //return RedirectToAction("Index");






            var langs = await _service.UpdateAsync(blog);
            return View(langs);
        }





    }
}
