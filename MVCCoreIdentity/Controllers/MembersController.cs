using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCCoreIdentity.Models;
using MVCCoreIdentity.ViewModels;

namespace MVCCoreIdentity.Controllers
{
    public class MembersController : Controller
    {
        private readonly SignInManager<BaseUser> _signInManager;

        public MembersController(SignInManager<BaseUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.Title = "Login Page";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(vm.Email, vm.Password, vm.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "MemberHome");
                }
                ModelState.AddModelError("", "Invalid login attempt");
                return View(vm);
            }
            return View(vm);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}