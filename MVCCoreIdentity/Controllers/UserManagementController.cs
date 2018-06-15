using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCCoreIdentity.Models;
using MVCCoreIdentity.ViewModels;

namespace MVCCoreIdentity.Controllers
{
    public class UserManagementController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<BaseUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserManagementController(AppDbContext dbContext, UserManager<BaseUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {

            var vm = new UserManagementIndexViewModel
            {
                Users = _dbContext.Users.OrderBy(u => u.Email).ToList()
            };

            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> AddRole(string id)
        {
            var user = await GetUserById(id);

            var vm = new UserManagementAddRoleViewModel
            {
                Roles = GetAllRoles(),
                UserId = id,
                Email = user.Email
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(UserManagementAddRoleViewModel vm)
        {
            var user = await GetUserById(vm.UserId);
            if (ModelState.IsValid)
            {

                var result = await _userManager.AddToRoleAsync(user, vm.NewRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }

            vm.Email = user.Email;
            vm.Roles = GetAllRoles();
            return View(vm);
        }

        private async Task<BaseUser> GetUserById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        private SelectList GetAllRoles()
        {
            return new SelectList(_roleManager.Roles.OrderBy(r => r.Name));
        }
    }
}