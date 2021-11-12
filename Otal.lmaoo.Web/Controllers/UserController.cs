using Microsoft.AspNetCore.Mvc;
using Otal.lmaoo.Services.Interfaces;
using Otal.lmaoo.Web.ViewModels;

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
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            return View("Login");
        }
    }
}
