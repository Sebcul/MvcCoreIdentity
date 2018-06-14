using System;
using Microsoft.AspNetCore.Identity;

namespace MVCCoreIdentity.Models
{
    public class BaseUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
