﻿using Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.UI.Models.Auth;
using System.Security.Claims;

namespace MyPortfolio.UI.Controllers
{
    public class LoginController : Controller
    {
     
        public LoginController()
        {
            
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

        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new User()
        //        {
        //            Name = registerViewModel.FullName,
        //            SurName = registerViewModel.Email,
        //            Password = registerViewModel.Password
        //        };

        //        var result = await HttpContext.CreateAsync(user, registerViewModel.Password);
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("Login");
        //        }
        //    }
        //    return View();
        //}
    }
}
