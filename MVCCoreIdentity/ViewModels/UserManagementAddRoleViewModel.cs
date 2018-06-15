using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCCoreIdentity.Models;

namespace MVCCoreIdentity.ViewModels
{
    public class UserManagementAddRoleViewModel
    {
        public string UserId { get; set; }

        public string Email { get; set; }

        public string NewRole { get; set; }

        public SelectList Roles { get; set; }

    }
}
