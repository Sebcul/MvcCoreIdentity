using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCCoreIdentity.Models;

namespace MVCCoreIdentity.Controllers
{
    //[Authorize(Roles = "Member")]
    public class MemberHomeController : Controller
    {
        private readonly UserManager<BaseUser> _userManager;

        public MemberHomeController(UserManager<BaseUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            //await _userManager.AddClaimAsync(user, new Claim("First Name", "Sebastian"));
            var storedClaims = await _userManager.GetClaimsAsync(user);
            var claimToRemove = storedClaims.FirstOrDefault(c => c.Type == "First Name");
            await _userManager.RemoveClaimAsync(user, claimToRemove);
            var claims = await _userManager.GetClaimsAsync(user);

           // var claims = User.Claims;

            return View();
        }


    }
}