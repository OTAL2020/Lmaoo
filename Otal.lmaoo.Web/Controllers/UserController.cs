using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Otal.lmaoo.Core.Entities;
using Otal.lmaoo.Core.Enums;
using Otal.lmaoo.Services.Interfaces;
using Otal.lmaoo.Web.ViewModels;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

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
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = "/")
        {
            var vm = new LoginViewModel
            { 
                ReturnUrl = returnUrl 
            };

            return View(vm);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var user = _userService.GetByUsernameAndPassword(vm.Username, vm.Password);

            if (user == null)
            {
                TempData["Error"] = "Username and Password does not match";
                return View(vm);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.GivenName, user.Password),
                new Claim(ClaimTypes.Surname, user.Surname),
                new Claim(ClaimTypes.Role, user.Level.ToString()),
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal);

            return Redirect(vm.ReturnUrl);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            RegisterViewModel vm = new RegisterViewModel();
            return View(vm);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(RegisterViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var user = _userService.GetByUsername(vm.Username);
            
            if (user != null)
            {
                TempData["Error"] = "Username already exists";
                return View(vm);
            }

            var newUser = new User
            {
                Forename = vm.Forename,
                Surname = vm.Surname,
                Username = vm.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(vm.Password),
            };

            _userService.RegisterUser(newUser);
            TempData["Message"] = "Registration Successful";
            return View("Login");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return View("Login");
        }
    }
}
