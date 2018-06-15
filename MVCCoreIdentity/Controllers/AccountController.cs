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
    public class AccountController : Controller
    {
        private readonly UserManager<BaseUser> _userManager;
        private readonly SignInManager<BaseUser> _signInManager;

        public AccountController(UserManager<BaseUser> userManager, 
            SignInManager<BaseUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel vm)
        {
            
            if (ModelState.IsValid)
            {
                var user = new BaseUser
                {
                    Email = vm.Email,
                    UserName = vm.Email,
                    DateOfBirth = DateTime.Now,
                    Age = new Random().Next(16, 69),
                    FirstName = vm.FirstName,
                    LastName = vm.LastName
                };
                var result = await _userManager.CreateAsync(user, vm.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "MemberHome");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }
            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Members");
        }
    }
}