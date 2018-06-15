using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MVCCoreIdentity.Controllers
{
    [Authorize(Roles = "Member")]
    public class MemberHomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


    }
}