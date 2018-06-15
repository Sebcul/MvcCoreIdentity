using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MVCCoreIdentity.Models;

namespace MVCCoreIdentity.Configuration
{
    public class UserRoleSeed
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRoleSeed(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async void Seed()
        {
            if (await _roleManager.FindByNameAsync("Member") == null)
            {
                await CreateRoleAsync("Member");
            }

            if (await _roleManager.FindByNameAsync("Supervisor") == null)
            {
                await CreateRoleAsync("Supervisor");
            }

            if (await _roleManager.FindByNameAsync("Admin") == null)
            {
                await CreateRoleAsync("Admin");
            }
        }

        private async Task CreateRoleAsync(string roleName)
        {
            await _roleManager.CreateAsync(new IdentityRole { Name = roleName });
        }
    }
}
