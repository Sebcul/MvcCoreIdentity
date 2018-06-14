using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreIdentity.ViewModels
{
    public class RegisterViewModel
    {
        [Required, EmailAddress, MaxLength(256)]
        public string Email { get; set; }

        [Required, MinLength(6), MaxLength(50), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, Compare("Password", ErrorMessage = "Passwords does not match."), MinLength(6), MaxLength(50), DataType(DataType.Password), Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required, Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last name")]
        public string LastName { get; set; }
    }
}
