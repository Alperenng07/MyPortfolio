using Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.UI.Models.Auth;
using Portfolio.Business.Service.BaseService;
using System.Security.Claims;

namespace MyPortfolio.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IBaseService<User> _service;
        public LoginController(IBaseService<User> service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(SignInViewModel signInViewModel)
        {
            if (!ModelState.IsValid) return View();

            if (signInViewModel.Email == "Alperen" && signInViewModel.Password == "1234")
            {
                var claims= new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,signInViewModel.Email),
                    new Claim(ClaimTypes.Name,signInViewModel.Email),
                    new Claim(ClaimTypes.Role,"User")
                };

                var claimsIdendity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties= new AuthenticationProperties { };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdendity),authProperties);
                return RedirectToAction("Index", "Home");

            }
            ModelState.AddModelError("Password", "Error:Invalid credentials.");
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    Name = registerViewModel.Name,
                    SurName = registerViewModel.SurName,
                    Email = registerViewModel.Email,
                    Phone = registerViewModel.Phone,
                    Password = registerViewModel.Password
                };

                var result = await this._service.AddAsync(user);
                
               
                    return RedirectToAction("Login","Login");
                

            }
            return View();
        }
    }
}
