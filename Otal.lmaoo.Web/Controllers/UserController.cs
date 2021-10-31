using Microsoft.AspNetCore.Mvc;
using Otal.lmaoo.Services.Interfaces;

namespace Otal.lmaoo.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Users()
        {
            return Json(_userService.Get(1));
        }
    }
}
